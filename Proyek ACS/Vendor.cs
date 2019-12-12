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
            button1.Enabled = false;
            if (e.RowIndex > -1)
            {
                label7.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
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
                         " where lower(id_distributor) like '%" + keywordsearch + "%' or" +
                         " lower(nama_distributor) like '%" + keywordsearch + "%' or " +
                         " lower(alamat_distributor) like '%" + keywordsearch + "%' ";
            }
            else if (comboBox_filter.SelectedIndex >= 0)
            {
                string filter = comboBox_filter.SelectedItem.ToString();
                search = loaddgv +
                    " where lower(" + filter + ") like '%" + keywordsearch + "%' ";
            }
            load_dgv_vendor(search);

        }

        private void Button_reset_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            comboBox_filter.SelectedIndex = -1;
            load_dgv_vendor(loaddgv);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                OracleCommand oauto = new OracleCommand("select fautoinvendor('abc') from dual", Form1.oc);
                string hasil = oauto.ExecuteScalar().ToString();
                OracleCommand ocom = new OracleCommand("Insert into distributor values(:a,:b,:c)", Form1.oc);
                ocom.Parameters.Add(":a", hasil);
                ocom.Parameters.Add(":b", textBox2.Text);
                ocom.Parameters.Add(":c", textBox3.Text);
                ocom.ExecuteNonQuery();
                MessageBox.Show("Sukses Tambah Vendor");
                load_dgv_vendor(loaddgv);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eror di : " + ex.Message);
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Kotak_Vendor formvendor = new Kotak_Vendor();
            formvendor.label_parsing_id.Text = label7.Text;
            formvendor.label_parsing_namadist.Text = textBox2.Text;
            formvendor.textBox_parsing_alamatdist.Text = textBox3.Text;


            DataTable dtkontakdistributor = new DataTable();
            OracleDataAdapter adapkontakdist = new OracleDataAdapter("Select Kontak_Distributor.Id_Kontak, Kontak_Distributor.Staff,Kontak_Distributor.No_Telp, Kontak_Distributor.Email " +
                "from Kontak_Distributor, Distributor " +
                "where Distributor.Id_Distributor = Kontak_Distributor.Id_Distributor " +
                "and Distributor.Id_Distributor = '" + formvendor.label_parsing_id.Text + "'", Form1.oc);
            adapkontakdist.Fill(dtkontakdistributor);
            formvendor.dataGridView1.DataSource = dtkontakdistributor;
            formvendor.dataGridView1.Columns[0].Visible = false;
            formvendor.ShowDialog();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
            textBox2.Clear();
            textBox3.Clear();
            label7.Text = "";
        }

        private void Button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                OracleCommand ocomupdate = new OracleCommand("Update Distributor set nama_distributor = :a , alamat_distributor = :b where id_distributor = '" + label7.Text + "' ", Form1.oc);
                ocomupdate.Parameters.Add(":a", textBox2.Text);
                ocomupdate.Parameters.Add(":b", textBox3.Text);
                ocomupdate.ExecuteNonQuery();
                MessageBox.Show("Sukses Update");
                load_dgv_vendor(loaddgv);
                Button4_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal Update");
            }
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            try
            {
                OracleCommand ocomdelete = new OracleCommand("Delete Distributor where id_distributor = '" + label7.Text + "' ", Form1.oc);
                ocomdelete.ExecuteNonQuery();
                MessageBox.Show("Sukses Delete");
                load_dgv_vendor(loaddgv);
                Button4_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal Delete Karena Table Tereferensi Table Lain");
            }
        }
        
    }
}
