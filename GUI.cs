using System;
using System.Diagnostics;
using System.IO.MemoryMappedFiles;
using System.Net;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Xml.Linq;

namespace GowMonitor
{
    public partial class GUI : Form
    {
        public const string procname = "pcsx2-qt";
        public static string pcsx2MapName = string.Empty;
        const int MaxSharedSize = 0x8B00000 + 0x300000 + 0x100000; // EE + IOP + VU (143MB)
        MemoryMappedFile? mmf = null;
        MemoryMappedViewAccessor accessor = null;
        public static bool largemem = false;
        public static bool bigendian = false;
        public Process proc;
        private IntPtr procHandle;
        private const uint PROCESS_ALL_ACCESS = 0x001F0FFF;
        private const uint FILE_MAP_ALL_ACCESS = 0x000F001F;
        private const uint PAGE_EXECUTE_READWRITE = 0x40;
        private uint oldProtection;
        List<(string name, float health, float maxhealth)> enemylist = new List<(string name, float health, float maxhealth)>();
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        // PCSX2 Latest
        //IntPtr emuoffset = new IntPtr(0x7FF820000000); static
        // i found the way to find emuoffset by reading the source code of pcsx2 on allocating memory

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr OpenProcess(uint dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, int dwSize, out IntPtr lpNumberOfBytesRead);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool VirtualProtectEx(IntPtr hProcess, IntPtr lpAddress, uint dwSize, uint flNewProtect, out uint lpflOldProtect);
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr OpenFileMapping(uint dwDesiredAccess, bool bInheritHandle, string lpName);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr MapViewOfFile(IntPtr hFileMappingObject, uint dwDesiredAccess, uint dwFileOffsetHigh, uint dwFileOffsetLow, UIntPtr dwNumberOfBytesToMap);
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool UnmapViewOfFile(IntPtr lpBaseAddress);

        // Old BytesRead
        //public byte[] RBytes(int addr, int sizeToRead)
        //{
        //    IntPtr pos = IntPtr.Add(emuoffset, addr);
        //    byte[] buff = new byte[sizeToRead];
        //    IntPtr bytesRead;

        //    bool success = ReadProcessMemory(procHandle, pos, buff, buff.Length, out bytesRead);
        //    //if (!success)
        //    //    throw new Exception("Failed to read memory.");
        //    // for debugging,can make slower the process

        //    return buff;
        //}

        // New Method directly read from Shared Memory
        public byte[] ReadFromPCSX2SharedMemory(int offset, int size)
        {
            byte[] buffer = new byte[size];
            if (offset < 0 || offset + size > MaxSharedSize)
                return buffer;

            accessor.ReadArray(offset, buffer, 0, size);
            return buffer;
        }



        public string RAsciiStr(int addr)
        {
            //byte[] buff = RBytes(addr, 0x50);
            byte[] buff = ReadFromPCSX2SharedMemory(addr, 0x50);
            string result = Encoding.ASCII.GetString(buff).Split('\0')[0];
            return result;
        }
        public T ReadAndConvert<T>(int addr, int byteCount, string convertType, bool bigEndian = false)
        {
            //byte[] buff = RBytes(addr, byteCount);
            byte[] buff = ReadFromPCSX2SharedMemory(addr, byteCount);

            if (bigEndian)
                Array.Reverse(buff);

            return convertType switch
            {
                "Int16" => (T)(object)BitConverter.ToInt16(buff, 0),
                "Int32" => (T)(object)BitConverter.ToInt32(buff, 0),
                "Int64" => (T)(object)BitConverter.ToInt64(buff, 0),
                "UInt8" => (T)(object)buff[0],
                "UInt16" => (T)(object)BitConverter.ToUInt16(buff, 0),
                "UInt32" => (T)(object)BitConverter.ToUInt32(buff, 0),
                "UInt64" => (T)(object)BitConverter.ToUInt64(buff, 0),
                "Single" => (T)(object)BitConverter.ToSingle(buff, 0),
                _ => throw new ArgumentException($"Unknown conversion type {convertType}")
            };
        }
        public string GetNewNameLabel(int ptr)
        {
            try
            {
                int ptrPlus320 = ptr + 0x320;
                int firstPtr = RInt32(ptrPlus320);
                int firstPtrPlus8 = firstPtr + 0x8;
                int secondPtr = RInt32(firstPtrPlus8);
                int secondPtrPlus8 = secondPtr + 0x0;
                // like what? on the powershell its clear that + 8 + 8
                // $name = RAsciiStr((RInt32((RInt32($ptr + 0x320) + 0x8) + 0x8)))
                // it just give me error if i add +8 at last so i just add 0x0 or nothing, but it work STUPID MEMORY
                string ptrName = RAsciiStr(secondPtrPlus8);
                string newNameLabel = $"{ptrName}";
                return newNameLabel;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetNewNameLabel: {ex.Message}");
                return "Unknown";
            }
        }

        public short RInt16(int addr) => ReadAndConvert<short>(addr, 2, "Int16");
        public int RInt32(int addr) => ReadAndConvert<int>(addr, 4, "Int32");
        public long RInt64(int addr) => ReadAndConvert<long>(addr, 8, "Int64");
        public byte RUInt8(int addr) => ReadAndConvert<byte>(addr, 1, "UInt8");
        public ushort RUInt16(int addr) => ReadAndConvert<ushort>(addr, 2, "UInt16");
        public uint RUInt32(int addr) => ReadAndConvert<uint>(addr, 4, "UInt32");
        public ulong RUInt64(int addr) => ReadAndConvert<ulong>(addr, 8, "UInt64");
        public float RSingle(int addr) => ReadAndConvert<float>(addr, 4, "Single");

        public int GetEnemyPtr()
        {
            int enemyPtrAddress = 0x29cd58;
            int enemyPtrValue = RInt32(enemyPtrAddress);
            return RInt32(enemyPtrValue);
        }
        public GUI()
        {

            InitializeComponent();
            this.Load += GUI_Load;

        }

        private void GUI_Load(object sender = null, EventArgs e = null)
        {
            lbl_status.Text = "PCSX2 is not connected";
            proc = Process.GetProcessesByName(procname).FirstOrDefault();
            if (proc == null)
            {
                lbl_status.Text = "PCSX2 not found";
                return;
            }
            procHandle = OpenProcess(PROCESS_ALL_ACCESS, false, proc.Id);
            if (procHandle == IntPtr.Zero)
            {
                lbl_status.Text = "Failed to open process";
                return;
            }
            
            //emuoffset = GetEEBaseAddress();
            timer.Interval = 1000; // Set the interval to 1 second
            timer.Tick += new EventHandler(timer_Tick);
            
        }

        // Not working
        //private IntPtr GetEEBaseAddress()
        //{

        //    string mapName = $"pcsx2_{proc.Id}";
        //    var hMap = OpenFileMapping(FILE_MAP_ALL_ACCESS, false, mapName);
        //    IntPtr pMapView = MapViewOfFile(hMap, FILE_MAP_ALL_ACCESS, 0, 0, 0x8B00000);
        //    return pMapView;
        //}

        private void timer_Tick(object? sender, EventArgs e)
        {
            enemylist.Clear();
            // IGT
            string igt = Math.Floor((decimal)RSingle(0x302d0c)).ToString();
            TimeSpan ts = TimeSpan.FromSeconds(int.Parse(igt));
            lbl_igt.Text = "IGT : " + ts.ToString(@"hh\:mm\:ss") + $" ({igt})";

            // Death Count
            lbl_death.Text = "Death : " + RUInt32(0x302d08).ToString();

            // Enemy PTR
            var enemyptr = GetEnemyPtr();
            unsafe // maybe pointless but fuck it im leaving this here
            {
                enemyptr = RInt32(0x29cd58);
                enemyptr = RInt32(enemyptr);
                int ptr = enemyptr;
                // Current Health
                var health = RSingle((int)ptr + 0x178);
                var maxhealth = RSingle((int)ptr + 0x17c);
                lbl_kratoshealth.Text = "Health : " + health.ToString() + "/" + maxhealth.ToString();

                // Current Magic
                var magic = RSingle(0x302d1c);
                lbl_kratosmagic.Text = "Magic : " + magic.ToString();

                // Current Rage
                var rage = RSingle(0x302d20);
                lbl_kratosrage.Text = "Rage : " + rage.ToString();

                // Orbs
                var orbs = RInt16(0x302d28);
                lbl_kratosorb.Text = "Orbs : " + orbs.ToString();

                // Name
                string name = GetNewNameLabel(ptr);
                lbl_kratos.Text = name;


                // WAD
                var wad1 = RUInt32(0x335280);
                var wad2 = RUInt32(0x335284);

                var wad1text = RAsciiStr((int)wad1);
                var wad2text = RAsciiStr((int)wad2);
                lbl_wad1.Text = wad1text;
                lbl_wad2.Text = wad2text;

                // Pos
                var posptr = RUInt32(0x29cd58);
                posptr = RUInt32((int)posptr);

                var xpos = RSingle((int)posptr + 0x80);
                var ypos = RSingle((int)posptr + 0x84);
                var zpos = RSingle((int)posptr + 0x88);
                lbl_kratosposx.Text = "X :" + xpos.ToString();
                lbl_kratosposy.Text = "Y :" + ypos.ToString();
                lbl_kratosposz.Text = "Z :" + zpos.ToString();

                // enemy loop
                
                int i = 1;
                while (true)
                {
                    var singleptr = enemyptr + 0x360 * i;
                    var enemyhealth = RSingle((int)singleptr + 0x178);
                    var enemymaxhealth = RSingle((int)singleptr + 0x17c);
                    var enemyname = GetNewNameLabel((int)singleptr);

                    if (enemyhealth > 0 && enemyname != "")
                    {
                        enemylist.Add((enemyname, enemyhealth, enemymaxhealth));
                        //var enemyText = $"{enemyname}\n{enemyhealth}/{enemymaxhealth}";
                        //MessageBox.Show(enemyText);
                    }
                    i++;
                    if (i > 40) break;
                }
                //foreach (var enemy in enemylist)
                //{
                //    var enemyText = $"{enemy.name}\n{enemy.health}/{enemy.maxhealth}";
                //    MessageBox.Show(enemyText);
                //}
                dataGridView1.DataSource = enemylist.Select(e => new { Name = e.name, Health = e.health, MaxHealth = e.maxhealth }).ToList();
                lbl_status.ForeColor = Color.Green;
                lbl_status.Text = $"PCSX2 Connected ({proc.Id})";
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            proc = Process.GetProcessesByName(procname).FirstOrDefault();
            if (proc == null)
            {
                lbl_status.Text = "PCSX2 not found";
                timer.Stop();
                return;
            }
            procHandle = OpenProcess(PROCESS_ALL_ACCESS, false, proc.Id);
            if (procHandle == IntPtr.Zero)
            {
                lbl_status.Text = "Failed to open process";
                timer.Stop();
                return;
            }
            pcsx2MapName = $"pcsx2_{proc.Id}";
            // Open the memory-mapped file
            mmf = MemoryMappedFile.OpenExisting(pcsx2MapName);

            accessor = mmf.CreateViewAccessor(0, MaxSharedSize, MemoryMappedFileAccess.ReadWrite); // EE Mem Size
            timer.Start();
        }
    }
}
