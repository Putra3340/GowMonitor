namespace GowMonitor
{
    partial class GUI
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            lbl_igt = new Label();
            lbl_death = new Label();
            lbl_kratoshealth = new Label();
            lbl_kratosmagic = new Label();
            lbl_kratosrage = new Label();
            lbl_kratos = new Label();
            lbl_wad1 = new Label();
            lbl_wad2 = new Label();
            lbl_kratosposx = new Label();
            lbl_kratosorb = new Label();
            dataGridView1 = new DataGridView();
            button1 = new Button();
            lbl_status = new Label();
            lbl_kratosposy = new Label();
            lbl_kratosposz = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // lbl_igt
            // 
            lbl_igt.AutoSize = true;
            lbl_igt.Font = new Font("Comic Sans MS", 18F, FontStyle.Bold);
            lbl_igt.Location = new Point(396, 28);
            lbl_igt.Name = "lbl_igt";
            lbl_igt.Size = new Size(101, 35);
            lbl_igt.TabIndex = 0;
            lbl_igt.Text = "Time : ";
            // 
            // lbl_death
            // 
            lbl_death.AutoSize = true;
            lbl_death.Font = new Font("Comic Sans MS", 18F, FontStyle.Bold);
            lbl_death.Location = new Point(396, 63);
            lbl_death.Name = "lbl_death";
            lbl_death.Size = new Size(103, 35);
            lbl_death.TabIndex = 2;
            lbl_death.Text = "Death :";
            // 
            // lbl_kratoshealth
            // 
            lbl_kratoshealth.AutoSize = true;
            lbl_kratoshealth.Font = new Font("Comic Sans MS", 18F, FontStyle.Bold);
            lbl_kratoshealth.Location = new Point(57, 192);
            lbl_kratoshealth.Name = "lbl_kratoshealth";
            lbl_kratoshealth.Size = new Size(152, 35);
            lbl_kratoshealth.TabIndex = 3;
            lbl_kratoshealth.Text = "Curr Health";
            // 
            // lbl_kratosmagic
            // 
            lbl_kratosmagic.AutoSize = true;
            lbl_kratosmagic.Font = new Font("Comic Sans MS", 18F, FontStyle.Bold);
            lbl_kratosmagic.Location = new Point(57, 227);
            lbl_kratosmagic.Name = "lbl_kratosmagic";
            lbl_kratosmagic.Size = new Size(81, 35);
            lbl_kratosmagic.TabIndex = 4;
            lbl_kratosmagic.Text = "Magic";
            // 
            // lbl_kratosrage
            // 
            lbl_kratosrage.AutoSize = true;
            lbl_kratosrage.Font = new Font("Comic Sans MS", 18F, FontStyle.Bold);
            lbl_kratosrage.Location = new Point(57, 262);
            lbl_kratosrage.Name = "lbl_kratosrage";
            lbl_kratosrage.Size = new Size(69, 35);
            lbl_kratosrage.TabIndex = 5;
            lbl_kratosrage.Text = "Rage";
            // 
            // lbl_kratos
            // 
            lbl_kratos.AutoSize = true;
            lbl_kratos.Font = new Font("Comic Sans MS", 18F, FontStyle.Bold);
            lbl_kratos.Location = new Point(57, 137);
            lbl_kratos.Name = "lbl_kratos";
            lbl_kratos.Size = new Size(73, 35);
            lbl_kratos.TabIndex = 6;
            lbl_kratos.Text = "name";
            // 
            // lbl_wad1
            // 
            lbl_wad1.AutoSize = true;
            lbl_wad1.Font = new Font("Comic Sans MS", 18F, FontStyle.Bold);
            lbl_wad1.Location = new Point(399, 121);
            lbl_wad1.Name = "lbl_wad1";
            lbl_wad1.Size = new Size(100, 35);
            lbl_wad1.TabIndex = 7;
            lbl_wad1.Text = "WAD 1";
            // 
            // lbl_wad2
            // 
            lbl_wad2.AutoSize = true;
            lbl_wad2.Font = new Font("Comic Sans MS", 18F, FontStyle.Bold);
            lbl_wad2.Location = new Point(399, 171);
            lbl_wad2.Name = "lbl_wad2";
            lbl_wad2.Size = new Size(100, 35);
            lbl_wad2.TabIndex = 8;
            lbl_wad2.Text = "WAD 2";
            // 
            // lbl_kratosposx
            // 
            lbl_kratosposx.AutoSize = true;
            lbl_kratosposx.Font = new Font("Comic Sans MS", 18F, FontStyle.Bold);
            lbl_kratosposx.Location = new Point(57, 370);
            lbl_kratosposx.Name = "lbl_kratosposx";
            lbl_kratosposx.Size = new Size(53, 35);
            lbl_kratosposx.TabIndex = 9;
            lbl_kratosposx.Text = "pos";
            // 
            // lbl_kratosorb
            // 
            lbl_kratosorb.AutoSize = true;
            lbl_kratosorb.Font = new Font("Comic Sans MS", 18F, FontStyle.Bold);
            lbl_kratosorb.Location = new Point(57, 297);
            lbl_kratosorb.Name = "lbl_kratosorb";
            lbl_kratosorb.Size = new Size(54, 35);
            lbl_kratosorb.TabIndex = 11;
            lbl_kratosorb.Text = "orb";
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.Location = new Point(399, 241);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(392, 265);
            dataGridView1.TabIndex = 13;
            dataGridView1.CellFormatting += dataGridView1_CellFormatting;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.Location = new Point(57, 47);
            button1.Name = "button1";
            button1.Size = new Size(139, 51);
            button1.TabIndex = 14;
            button1.Text = "Connect";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // lbl_status
            // 
            lbl_status.AutoSize = true;
            lbl_status.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_status.Location = new Point(57, 19);
            lbl_status.Name = "lbl_status";
            lbl_status.Size = new Size(62, 25);
            lbl_status.TabIndex = 15;
            lbl_status.Text = "Status";
            // 
            // lbl_kratosposy
            // 
            lbl_kratosposy.AutoSize = true;
            lbl_kratosposy.Font = new Font("Comic Sans MS", 18F, FontStyle.Bold);
            lbl_kratosposy.Location = new Point(57, 405);
            lbl_kratosposy.Name = "lbl_kratosposy";
            lbl_kratosposy.Size = new Size(53, 35);
            lbl_kratosposy.TabIndex = 16;
            lbl_kratosposy.Text = "pos";
            // 
            // lbl_kratosposz
            // 
            lbl_kratosposz.AutoSize = true;
            lbl_kratosposz.Font = new Font("Comic Sans MS", 18F, FontStyle.Bold);
            lbl_kratosposz.Location = new Point(57, 438);
            lbl_kratosposz.Name = "lbl_kratosposz";
            lbl_kratosposz.Size = new Size(53, 35);
            lbl_kratosposz.TabIndex = 17;
            lbl_kratosposz.Text = "pos";
            // 
            // GUI
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(815, 566);
            Controls.Add(lbl_kratosposz);
            Controls.Add(lbl_kratosposy);
            Controls.Add(lbl_status);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Controls.Add(lbl_kratosorb);
            Controls.Add(lbl_kratosposx);
            Controls.Add(lbl_wad2);
            Controls.Add(lbl_wad1);
            Controls.Add(lbl_kratos);
            Controls.Add(lbl_kratosrage);
            Controls.Add(lbl_kratosmagic);
            Controls.Add(lbl_kratoshealth);
            Controls.Add(lbl_death);
            Controls.Add(lbl_igt);
            Name = "GUI";
            Text = "GowMonitor";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_igt;
        private Label lbl_death;
        private Label lbl_kratoshealth;
        private Label lbl_kratosmagic;
        private Label lbl_kratosrage;
        private Label lbl_kratos;
        private Label lbl_wad1;
        private Label lbl_wad2;
        private Label lbl_kratosposx;
        private Label lbl_kratosorb;
        private DataGridView dataGridView1;
        private Button button1;
        private Label lbl_status;
        private Label lbl_kratosposy;
        private Label lbl_kratosposz;
    }
}
