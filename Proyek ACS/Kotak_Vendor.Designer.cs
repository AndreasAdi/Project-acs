namespace Proyek_ACS
{
    partial class Kotak_Vendor
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label_parsing_id = new System.Windows.Forms.Label();
            this.label_parsing_namadist = new System.Windows.Forms.Label();
            this.textBox_parsing_alamatdist = new System.Windows.Forms.TextBox();
            this.button_Update = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 19);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Id Distributor :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 57);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nama Distributor : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 96);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Alamat Distributor : ";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(22, 133);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(553, 165);
            this.dataGridView1.TabIndex = 3;
            // 
            // label_parsing_id
            // 
            this.label_parsing_id.AutoSize = true;
            this.label_parsing_id.Location = new System.Drawing.Point(124, 19);
            this.label_parsing_id.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_parsing_id.Name = "label_parsing_id";
            this.label_parsing_id.Size = new System.Drawing.Size(10, 13);
            this.label_parsing_id.TabIndex = 4;
            this.label_parsing_id.Text = "-";
            // 
            // label_parsing_namadist
            // 
            this.label_parsing_namadist.AutoSize = true;
            this.label_parsing_namadist.Location = new System.Drawing.Point(124, 57);
            this.label_parsing_namadist.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_parsing_namadist.Name = "label_parsing_namadist";
            this.label_parsing_namadist.Size = new System.Drawing.Size(10, 13);
            this.label_parsing_namadist.TabIndex = 5;
            this.label_parsing_namadist.Text = "-";
            // 
            // textBox_parsing_alamatdist
            // 
            this.textBox_parsing_alamatdist.Location = new System.Drawing.Point(124, 96);
            this.textBox_parsing_alamatdist.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox_parsing_alamatdist.Name = "textBox_parsing_alamatdist";
            this.textBox_parsing_alamatdist.Size = new System.Drawing.Size(452, 20);
            this.textBox_parsing_alamatdist.TabIndex = 7;
            // 
            // button_Update
            // 
            this.button_Update.Location = new System.Drawing.Point(505, 315);
            this.button_Update.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_Update.Name = "button_Update";
            this.button_Update.Size = new System.Drawing.Size(70, 28);
            this.button_Update.TabIndex = 8;
            this.button_Update.Text = "Update";
            this.button_Update.UseVisualStyleBackColor = true;
            // 
            // Kotak_Vendor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.button_Update);
            this.Controls.Add(this.textBox_parsing_alamatdist);
            this.Controls.Add(this.label_parsing_namadist);
            this.Controls.Add(this.label_parsing_id);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Kotak_Vendor";
            this.Text = "Kotak_Vendor";
            this.Load += new System.EventHandler(this.Kotak_Vendor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label label_parsing_id;
        public System.Windows.Forms.Label label_parsing_namadist;
        public System.Windows.Forms.DataGridView dataGridView1;
        public System.Windows.Forms.TextBox textBox_parsing_alamatdist;
        private System.Windows.Forms.Button button_Update;
    }
}