namespace Proyek_ACS
{
    partial class List_Barang
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.button3 = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.ID_BARANG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NAMA_BARANG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DESKRIPSI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JUMLAH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 95);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(636, 377);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellClick);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(38, 37);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(810, 22);
            this.textBox1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(879, 36);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Search";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1295, 514);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(93, 49);
            this.button2.TabIndex = 3;
            this.button2.Text = "OK";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID_BARANG,
            this.NAMA_BARANG,
            this.DESKRIPSI,
            this.JUMLAH});
            this.dataGridView2.Location = new System.Drawing.Point(774, 95);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(614, 377);
            this.dataGridView2.TabIndex = 4;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(654, 242);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(114, 87);
            this.button3.TabIndex = 5;
            this.button3.Text = ">";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(654, 214);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(114, 22);
            this.numericUpDown1.TabIndex = 6;
            // 
            // ID_BARANG
            // 
            this.ID_BARANG.HeaderText = "ID BARANG";
            this.ID_BARANG.MinimumWidth = 6;
            this.ID_BARANG.Name = "ID_BARANG";
            this.ID_BARANG.ReadOnly = true;
            // 
            // NAMA_BARANG
            // 
            this.NAMA_BARANG.HeaderText = "NAMA BARANG";
            this.NAMA_BARANG.MinimumWidth = 6;
            this.NAMA_BARANG.Name = "NAMA_BARANG";
            this.NAMA_BARANG.ReadOnly = true;
            // 
            // DESKRIPSI
            // 
            this.DESKRIPSI.HeaderText = "DESKRIPSI";
            this.DESKRIPSI.MinimumWidth = 6;
            this.DESKRIPSI.Name = "DESKRIPSI";
            this.DESKRIPSI.ReadOnly = true;
            // 
            // JUMLAH
            // 
            this.JUMLAH.HeaderText = "JUMLAH";
            this.JUMLAH.MinimumWidth = 6;
            this.JUMLAH.Name = "JUMLAH";
            this.JUMLAH.ReadOnly = true;
            // 
            // List_Barang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1400, 574);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dataGridView1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "List_Barang";
            this.Text = "List_Barang";
            this.Load += new System.EventHandler(this.List_Barang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_BARANG;
        private System.Windows.Forms.DataGridViewTextBoxColumn NAMA_BARANG;
        private System.Windows.Forms.DataGridViewTextBoxColumn DESKRIPSI;
        private System.Windows.Forms.DataGridViewTextBoxColumn JUMLAH;
    }
}