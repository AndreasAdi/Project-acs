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
            this.label1.Location = new System.Drawing.Point(57, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Id Distributor :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nama Distributor : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Alamat Distributor : ";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(30, 164);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(737, 203);
            this.dataGridView1.TabIndex = 3;
            // 
            // label_parsing_id
            // 
            this.label_parsing_id.AutoSize = true;
            this.label_parsing_id.Location = new System.Drawing.Point(165, 23);
            this.label_parsing_id.Name = "label_parsing_id";
            this.label_parsing_id.Size = new System.Drawing.Size(13, 17);
            this.label_parsing_id.TabIndex = 4;
            this.label_parsing_id.Text = "-";
            // 
            // label_parsing_namadist
            // 
            this.label_parsing_namadist.AutoSize = true;
            this.label_parsing_namadist.Location = new System.Drawing.Point(165, 70);
            this.label_parsing_namadist.Name = "label_parsing_namadist";
            this.label_parsing_namadist.Size = new System.Drawing.Size(13, 17);
            this.label_parsing_namadist.TabIndex = 5;
            this.label_parsing_namadist.Text = "-";
            // 
            // textBox_parsing_alamatdist
            // 
            this.textBox_parsing_alamatdist.Location = new System.Drawing.Point(165, 118);
            this.textBox_parsing_alamatdist.Name = "textBox_parsing_alamatdist";
            this.textBox_parsing_alamatdist.Size = new System.Drawing.Size(602, 22);
            this.textBox_parsing_alamatdist.TabIndex = 7;
            // 
            // button_Update
            // 
            this.button_Update.Location = new System.Drawing.Point(673, 388);
            this.button_Update.Name = "button_Update";
            this.button_Update.Size = new System.Drawing.Size(94, 34);
            this.button_Update.TabIndex = 8;
            this.button_Update.Text = "Update";
            this.button_Update.UseVisualStyleBackColor = true;
            // 
            // Kotak_Vendor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button_Update);
            this.Controls.Add(this.textBox_parsing_alamatdist);
            this.Controls.Add(this.label_parsing_namadist);
            this.Controls.Add(this.label_parsing_id);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
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