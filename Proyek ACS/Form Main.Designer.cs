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
            this.assignPrevilegeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1067, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // makeOrderToolStripMenuItem
            // 
            this.makeOrderToolStripMenuItem.Name = "makeOrderToolStripMenuItem";
            this.makeOrderToolStripMenuItem.Size = new System.Drawing.Size(101, 24);
            this.makeOrderToolStripMenuItem.Text = "Make Order";
            this.makeOrderToolStripMenuItem.Click += new System.EventHandler(this.MakeOrderToolStripMenuItem_Click);
            // 
            // lihatKontakToolStripMenuItem
            // 
            this.lihatKontakToolStripMenuItem.Name = "lihatKontakToolStripMenuItem";
            this.lihatKontakToolStripMenuItem.Size = new System.Drawing.Size(105, 24);
            this.lihatKontakToolStripMenuItem.Text = "Lihat Kontak";
            this.lihatKontakToolStripMenuItem.Click += new System.EventHandler(this.LihatKontakToolStripMenuItem_Click);
            // 
            // lihatInventoryToolStripMenuItem
            // 
            this.lihatInventoryToolStripMenuItem.Name = "lihatInventoryToolStripMenuItem";
            this.lihatInventoryToolStripMenuItem.Size = new System.Drawing.Size(120, 24);
            this.lihatInventoryToolStripMenuItem.Text = "Lihat Inventory";
            this.lihatInventoryToolStripMenuItem.Click += new System.EventHandler(this.LihatInventoryToolStripMenuItem_Click);
            // 
            // lihatOrderToolStripMenuItem
            // 
            this.lihatOrderToolStripMenuItem.Name = "lihatOrderToolStripMenuItem";
            this.lihatOrderToolStripMenuItem.Size = new System.Drawing.Size(97, 24);
            this.lihatOrderToolStripMenuItem.Text = "Lihat Order";
            this.lihatOrderToolStripMenuItem.Click += new System.EventHandler(this.LihatOrderToolStripMenuItem_Click);
            // 
            // assignPrevilegeToolStripMenuItem
            // 
            this.assignPrevilegeToolStripMenuItem.Name = "assignPrevilegeToolStripMenuItem";
            this.assignPrevilegeToolStripMenuItem.Size = new System.Drawing.Size(131, 24);
            this.assignPrevilegeToolStripMenuItem.Text = "Assign Previlege";
            this.assignPrevilegeToolStripMenuItem.Click += new System.EventHandler(this.AssignPrevilegeToolStripMenuItem_Click);
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form_Main";
            this.Text = "Form_Main";
            this.Load += new System.EventHandler(this.Form_Main_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem makeOrderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lihatKontakToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lihatInventoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lihatOrderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem assignPrevilegeToolStripMenuItem;
    }
}