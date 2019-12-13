using Oracle.DataAccess.Client;
using System;
using System.Data;
using System.Windows.Forms;

namespace Proyek_ACS
{
    public partial class Kotak_Vendor : Form
    {
        public Kotak_Vendor()
        {
            InitializeComponent();
        }

        private void Kotak_Vendor_Load(object sender, EventArgs e)
        {
      

        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                button1.Enabled = false;
                label8.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Form1.oc.Close();
            Form1.oc.Open();
            try
            {
                OracleCommand ocomautoin = new OracleCommand("select fautoinkontakvendor('abc') from dual", Form1.oc);
                String hasilautogen = ocomautoin.ExecuteScalar().ToString();
                OracleCommand ocominsertin = new OracleCommand("Insert into Kontak_Distributor values (:a,:b,:c,:d,:e)", Form1.oc);
                ocominsertin.Parameters.Add(":a", label_parsing_id.Text);
                ocominsertin.Parameters.Add(":b", hasilautogen);
                ocominsertin.Parameters.Add(":c", textBox1.Text);
                ocominsertin.Parameters.Add(":d", textBox2.Text);
                ocominsertin.Parameters.Add(":e", textBox3.Text);
                ocominsertin.ExecuteNonQuery();
                MessageBox.Show("Sukses Daftar Baru");
                load_dgv_kontak_vendor();
                Button4_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eror  di : " + ex.Message);
            }
            Form1.oc.Close();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Form1.oc.Close();
            Form1.oc.Open();
            try
            {
                OracleCommand ocomupdate = new OracleCommand("Update Kontak_Distributor set staff = :a , no_telp = :b , email = :c where Id_Kontak = '" + label8.Text + "' ", Form1.oc);
                ocomupdate.Parameters.Add(":a", textBox1.Text);
                ocomupdate.Parameters.Add(":b", textBox2.Text);
                ocomupdate.Parameters.Add(":c", textBox3.Text);
                ocomupdate.ExecuteNonQuery();
                MessageBox.Show("Sukses Update");
                Button4_Click(sender, e);
                load_dgv_kontak_vendor();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal Update");
            }
            Form1.oc.Close();
        }

        public void load_dgv_kontak_vendor()
        {
            DataTable dtkontakdistributorr = new DataTable();
            OracleDataAdapter adapkontakdistt = new OracleDataAdapter("Select Kontak_Distributor.Id_Kontak, Kontak_Distributor.Staff,Kontak_Distributor.No_Telp, Kontak_Distributor.Email " +
               "from Kontak_Distributor, Distributor " +
               "where Distributor.Id_Distributor = Kontak_Distributor.Id_Distributor " +
               "and Distributor.Id_Distributor = '" + label_parsing_id.Text + "'", Form1.oc);
            adapkontakdistt.Fill(dtkontakdistributorr);
            dataGridView1.DataSource = dtkontakdistributorr;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Form1.oc.Close();
            Form1.oc.Open();
            try
            {
                OracleCommand ocomdelete = new OracleCommand("Delete Kontak_Distributor where Kontak_Distributor.Id_Kontak = '" + label8.Text + "' ",Form1.oc);
                ocomdelete.ExecuteNonQuery();
                MessageBox.Show("Sukses Hapus Kontak atas nama " + textBox1.Text + "/" + textBox2.Text);
                Button4_Click(sender, e);
                load_dgv_kontak_vendor();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eror di : " + ex.Message);
            }
            Form1.oc.Close();
        }
    }
}
