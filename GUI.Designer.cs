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
            lbl_igt = new Label();
            lbl_death = new Label();
            lbl_kratoshealth = new Label();
            lbl_kratosmagic = new Label();
            lbl_kratosrage = new Label();
            lbl_kratos = new Label();
            lbl_wad1 = new Label();
            lbl_wad2 = new Label();
            lbl_kratospos = new Label();
            lbl_kratosorb = new Label();
            tbx_emuaddress = new TextBox();
            dataGridView1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // lbl_igt
            // 
            lbl_igt.AutoSize = true;
            lbl_igt.Font = new Font("Comic Sans MS", 18F, FontStyle.Bold);
            lbl_igt.Location = new Point(53, 44);
            lbl_igt.Name = "lbl_igt";
            lbl_igt.Size = new Size(101, 35);
            lbl_igt.TabIndex = 0;
            lbl_igt.Text = "Time : ";
            // 
            // lbl_death
            // 
            lbl_death.AutoSize = true;
            lbl_death.Font = new Font("Comic Sans MS", 18F, FontStyle.Bold);
            lbl_death.Location = new Point(53, 93);
            lbl_death.Name = "lbl_death";
            lbl_death.Size = new Size(103, 35);
            lbl_death.TabIndex = 2;
            lbl_death.Text = "Death :";
            // 
            // lbl_kratoshealth
            // 
            lbl_kratoshealth.AutoSize = true;
            lbl_kratoshealth.Font = new Font("Comic Sans MS", 18F, FontStyle.Bold);
            lbl_kratoshealth.Location = new Point(53, 209);
            lbl_kratoshealth.Name = "lbl_kratoshealth";
            lbl_kratoshealth.Size = new Size(152, 35);
            lbl_kratoshealth.TabIndex = 3;
            lbl_kratoshealth.Text = "Curr Health";
            // 
            // lbl_kratosmagic
            // 
            lbl_kratosmagic.AutoSize = true;
            lbl_kratosmagic.Font = new Font("Comic Sans MS", 18F, FontStyle.Bold);
            lbl_kratosmagic.Location = new Point(53, 256);
            lbl_kratosmagic.Name = "lbl_kratosmagic";
            lbl_kratosmagic.Size = new Size(81, 35);
            lbl_kratosmagic.TabIndex = 4;
            lbl_kratosmagic.Text = "Magic";
            // 
            // lbl_kratosrage
            // 
            lbl_kratosrage.AutoSize = true;
            lbl_kratosrage.Font = new Font("Comic Sans MS", 18F, FontStyle.Bold);
            lbl_kratosrage.Location = new Point(57, 302);
            lbl_kratosrage.Name = "lbl_kratosrage";
            lbl_kratosrage.Size = new Size(69, 35);
            lbl_kratosrage.TabIndex = 5;
            lbl_kratosrage.Text = "Rage";
            // 
            // lbl_kratos
            // 
            lbl_kratos.AutoSize = true;
            lbl_kratos.Font = new Font("Comic Sans MS", 18F, FontStyle.Bold);
            lbl_kratos.Location = new Point(53, 153);
            lbl_kratos.Name = "lbl_kratos";
            lbl_kratos.Size = new Size(73, 35);
            lbl_kratos.TabIndex = 6;
            lbl_kratos.Text = "name";
            // 
            // lbl_wad1
            // 
            lbl_wad1.AutoSize = true;
            lbl_wad1.Font = new Font("Comic Sans MS", 18F, FontStyle.Bold);
            lbl_wad1.Location = new Point(290, 153);
            lbl_wad1.Name = "lbl_wad1";
            lbl_wad1.Size = new Size(100, 35);
            lbl_wad1.TabIndex = 7;
            lbl_wad1.Text = "WAD 1";
            // 
            // lbl_wad2
            // 
            lbl_wad2.AutoSize = true;
            lbl_wad2.Font = new Font("Comic Sans MS", 18F, FontStyle.Bold);
            lbl_wad2.Location = new Point(290, 209);
            lbl_wad2.Name = "lbl_wad2";
            lbl_wad2.Size = new Size(100, 35);
            lbl_wad2.TabIndex = 8;
            lbl_wad2.Text = "WAD 2";
            // 
            // lbl_kratospos
            // 
            lbl_kratospos.AutoSize = true;
            lbl_kratospos.Font = new Font("Comic Sans MS", 18F, FontStyle.Bold);
            lbl_kratospos.Location = new Point(290, 399);
            lbl_kratospos.Name = "lbl_kratospos";
            lbl_kratospos.Size = new Size(53, 35);
            lbl_kratospos.TabIndex = 9;
            lbl_kratospos.Text = "pos";
            // 
            // lbl_kratosorb
            // 
            lbl_kratosorb.AutoSize = true;
            lbl_kratosorb.Font = new Font("Comic Sans MS", 18F, FontStyle.Bold);
            lbl_kratosorb.Location = new Point(53, 351);
            lbl_kratosorb.Name = "lbl_kratosorb";
            lbl_kratosorb.Size = new Size(54, 35);
            lbl_kratosorb.TabIndex = 11;
            lbl_kratosorb.Text = "orb";
            // 
            // tbx_emuaddress
            // 
            tbx_emuaddress.Location = new Point(546, 36);
            tbx_emuaddress.Name = "tbx_emuaddress";
            tbx_emuaddress.Size = new Size(225, 23);
            tbx_emuaddress.TabIndex = 12;
            tbx_emuaddress.TextChanged += lbl_emuaddress_TextChanged;
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(396, 121);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(392, 265);
            dataGridView1.TabIndex = 13;
            // 
            // GUI
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridView1);
            Controls.Add(tbx_emuaddress);
            Controls.Add(lbl_kratosorb);
            Controls.Add(lbl_kratospos);
            Controls.Add(lbl_wad2);
            Controls.Add(lbl_wad1);
            Controls.Add(lbl_kratos);
            Controls.Add(lbl_kratosrage);
            Controls.Add(lbl_kratosmagic);
            Controls.Add(lbl_kratoshealth);
            Controls.Add(lbl_death);
            Controls.Add(lbl_igt);
            Name = "GUI";
            Text = "Form1";
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
        private Label lbl_kratospos;
        private Label lbl_kratosorb;
        private TextBox tbx_emuaddress;
        private DataGridView dataGridView1;
    }
}
