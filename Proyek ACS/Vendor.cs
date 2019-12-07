using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;

namespace Proyek_ACS
{
    public partial class Vendor : Form
    {
        DataTable dtvendor;
        string loaddgv = "Select Id_Distributor, Nama_Distributor, Alamat_Distributor from distributor ";
        public Vendor()
        {
            InitializeComponent();
        }
        //Database db = new Database("xe", "proyekacs", "123");
        private void Vendor_Load(object sender, EventArgs e)
        {
            //dataGridView1.DataSource= db.executeDataTable("Select * From Distributor");
            load_dgv_vendor(loaddgv);
        }

        private void load_dgv_vendor(string perintah)
        {
            dtvendor = new DataTable();
            OracleDataAdapter adapvendor = new OracleDataAdapter(perintah, Form1.oc);
            adapvendor.Fill(dtvendor);
            dataGridView1.DataSource = dtvendor;
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Kotak_Vendor formvendor = new Kotak_Vendor();

            if (e.RowIndex > -1)
            {
                formvendor.label_parsing_id.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                formvendor.label_parsing_namadist.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                formvendor.textBox_parsing_alamatdist.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();

                DataTable dtkontakdistributor = new DataTable();
                OracleDataAdapter adapkontakdist = new OracleDataAdapter("Select Kontak_Distributor.No_Telp, Kontak_Distributor.Staff, Kontak_Distributor.Email " +
                    "from Kontak_Distributor, Distributor " +
                    "where Distributor.Id_Distributor = Kontak_Distributor.Id_Distributor " +
                    "and Distributor.Id_Distributor = '"+ formvendor.label_parsing_id.Text +"'",Form1.oc);
                adapkontakdist.Fill(dtkontakdistributor);
                formvendor.dataGridView1.DataSource = dtkontakdistributor;
                formvendor.Show();
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {                     
            string search = "";
            if (textBox1.Text == "")
            {
                MessageBox.Show("Masukkan isian text search");
            }
            string keywordsearch = textBox1.Text;
            if (comboBox_filter.SelectedIndex < 0)
            {
                search = loaddgv + 
                         " where lower(id_distributor) like '%"+keywordsearch+"%' or" +
                         " lower(nama_distributor) like '%" + keywordsearch + "%' or " +
                         " lower(alamat_distributor) like '%" + keywordsearch + "%' ";                
            }
            else if (comboBox_filter.SelectedIndex >= 0)
            {
                string filter = comboBox_filter.SelectedItem.ToString();
                search = loaddgv + 
                    " where lower("+filter+ ") like '%" + keywordsearch + "%' ";
            }
            load_dgv_vendor(search);
            
        }

        private void Button_reset_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            comboBox_filter.SelectedIndex = -1;
            load_dgv_vendor(loaddgv);
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
