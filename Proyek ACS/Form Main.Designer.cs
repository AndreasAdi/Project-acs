namespace Proyek_ACS
{
    partial class Form_Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.makeOrderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lihatKontakToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lihatInventoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lihatOrderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.assignPrevilegeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.laporanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.makeOrderToolStripMenuItem,
            this.lihatKontakToolStripMenuItem,
            this.lihatInventoryToolStripMenuItem,
            this.lihatOrderToolStripMenuItem,
            this.assignPrevilegeToolStripMenuItem,
            this.laporanToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // makeOrderToolStripMenuItem
            // 
            this.makeOrderToolStripMenuItem.Enabled = false;
            this.makeOrderToolStripMenuItem.Name = "makeOrderToolStripMenuItem";
            this.makeOrderToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.makeOrderToolStripMenuItem.Text = "Make Order";
            this.makeOrderToolStripMenuItem.Click += new System.EventHandler(this.MakeOrderToolStripMenuItem_Click);
            // 
            // lihatKontakToolStripMenuItem
            // 
            this.lihatKontakToolStripMenuItem.Enabled = false;
            this.lihatKontakToolStripMenuItem.Name = "lihatKontakToolStripMenuItem";
            this.lihatKontakToolStripMenuItem.Size = new System.Drawing.Size(85, 20);
            this.lihatKontakToolStripMenuItem.Text = "Lihat Kontak";
            this.lihatKontakToolStripMenuItem.Click += new System.EventHandler(this.LihatKontakToolStripMenuItem_Click);
            // 
            // lihatInventoryToolStripMenuItem
            // 
            this.lihatInventoryToolStripMenuItem.Enabled = false;
            this.lihatInventoryToolStripMenuItem.Name = "lihatInventoryToolStripMenuItem";
            this.lihatInventoryToolStripMenuItem.Size = new System.Drawing.Size(98, 20);
            this.lihatInventoryToolStripMenuItem.Text = "Lihat Inventory";
            this.lihatInventoryToolStripMenuItem.Click += new System.EventHandler(this.LihatInventoryToolStripMenuItem_Click);
            // 
            // lihatOrderToolStripMenuItem
            // 
            this.lihatOrderToolStripMenuItem.Enabled = false;
            this.lihatOrderToolStripMenuItem.Name = "lihatOrderToolStripMenuItem";
            this.lihatOrderToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.lihatOrderToolStripMenuItem.Text = "Lihat Order";
            this.lihatOrderToolStripMenuItem.Click += new System.EventHandler(this.LihatOrderToolStripMenuItem_Click);
            // 
            // assignPrevilegeToolStripMenuItem
            // 
            this.assignPrevilegeToolStripMenuItem.Enabled = false;
            this.assignPrevilegeToolStripMenuItem.Name = "assignPrevilegeToolStripMenuItem";
            this.assignPrevilegeToolStripMenuItem.Size = new System.Drawing.Size(105, 20);
            this.assignPrevilegeToolStripMenuItem.Text = "Assign Previlege";
            this.assignPrevilegeToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.assignPrevilegeToolStripMenuItem.Click += new System.EventHandler(this.AssignPrevilegeToolStripMenuItem_Click);
            // 
            // laporanToolStripMenuItem
            // 
            this.laporanToolStripMenuItem.Enabled = false;
            this.laporanToolStripMenuItem.Name = "laporanToolStripMenuItem";
            this.laporanToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.laporanToolStripMenuItem.Text = "Laporan";
            this.laporanToolStripMenuItem.Click += new System.EventHandler(this.LaporanToolStripMenuItem_Click);
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form_Main";
            this.Text = "Form_Main";
            this.Load += new System.EventHandler(this.Form_Main_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.MenuStrip menuStrip1;
        public System.Windows.Forms.ToolStripMenuItem makeOrderToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem lihatKontakToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem lihatInventoryToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem lihatOrderToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem assignPrevilegeToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem laporanToolStripMenuItem;
    }
}