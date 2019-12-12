using Oracle.DataAccess.Client;
using System;
using System.Data;
using System.Windows.Forms;

namespace Proyek_ACS
{
    public partial class Inventory : Form
    {
        DataTable dtinventory;
        string perintahinventory = "select stok.id_barang as ID_BARANG, barang.nama_barang as NAMA_BARANG, barang.detail_barang as Deskripsi, stok.tanggal_masuk as TANGGAL_MASUK " +
                "from stok, barang " +
                "where stok.id_barang = barang.id_barang ";
        public Inventory()
        {
            InitializeComponent();
        }

        private void Inventory_Load(object sender, EventArgs e)
        {
            load_dgv_inventory(perintahinventory);
            textBox2.Text = autogen_id_barang();
        }

        private void load_dgv_inventory(String perintah)
        {
            dtinventory = new DataTable();
            OracleDataAdapter adapinventory = new OracleDataAdapter(perintah, Form1.oc);
            adapinventory.Fill(dtinventory);
            dataGridView1.DataSource = dtinventory;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            string search = "";
            if (textBox1.Text == "")
            {
                MessageBox.Show("Text Search Belum Diisi");
            }
            string keyword = textBox1.Text;
            if (comboBox1.SelectedIndex < 0)
            {
                search = perintahinventory + " and " +
                    "(stok.id_barang like '%" + keyword + "%' or " +
                    "barang.nama_barang like '%" + keyword + "%' or " +
                    "barang.detail_barang like '%" + keyword + "%' or " +
                    "stok.jumlah_stok like '%" + keyword + "%' ) ";
            }
            else if (comboBox1.SelectedIndex >= 0)
            {
                string filter = comboBox1.SelectedItem.ToString();
                if (comboBox1.SelectedIndex == 0) filter = "barang.id_barang";
                if (comboBox1.SelectedIndex == 2) { filter = "detail_barang"; }
                search = perintahinventory + " and lower(" + filter + ") like '%" + keyword + "%'";
            }
            load_dgv_inventory(search);
        }

        private void Button_reset_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = -1;
            textBox1.Text = "";
            load_dgv_inventory(perintahinventory);
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            richTextBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {

        }

        private void DataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {

        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }
        string autogen_id_barang()
        {
            Form1.oc.Close();
            Form1.oc.Open();
            string idfix = "BRG";
            string qidbarang = "select count(id_barang) from barang";
            OracleCommand cmd_id_barang = new OracleCommand(qidbarang, Form1.oc);
            int no_urut = Convert.ToInt32(cmd_id_barang.ExecuteScalar()) + 1;
            if (no_urut > 9)
            {
                idfix = idfix + "00" + no_urut;
            }
            else if (no_urut > 99)
            {
                idfix = idfix + "0" + no_urut;
            }
            else if (no_urut > 999)
            {
                idfix = idfix + no_urut;
            }
            else
            {
                idfix = idfix + "000" + no_urut;
            }
            Form1.oc.Close();
            return idfix;

        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            Form1.oc.Close();
            Form1.oc.Open();
            insert_barang(textBox2.Text, textBox3.Text, richTextBox1.Text);
            load_dgv_inventory(perintahinventory);
            textBox2.Text = autogen_id_barang();
            textBox3.Text = "";
            richTextBox1.Text = "";
            Form1.oc.Close();

        }
        void insert_barang(string idbarang, string nama, string deskripsi)
        {
            Form1.oc.Close();
            Form1.oc.Open();
            string insertbarang = "insert into barang values('" + idbarang + "','" + nama + "','" + deskripsi + "')";
            string insertstok = "insert into stok values('" + idbarang + "',0,to_date('" + DateTime.Now.ToString("dd/MM/yyyy") + "','DD/MM/yyyy'))";
            OracleCommand cmdbarang = new OracleCommand(insertbarang, Form1.oc);
            OracleCommand cmdstok = new OracleCommand(insertstok, Form1.oc);
            cmdbarang.ExecuteNonQuery();
            cmdstok.ExecuteNonQuery();

            Form1.oc.Close();
        }
        void update_barang(string idbarang, string nama, string deskripsi)
        {
            Form1.oc.Close();
            Form1.oc.Open();
            string updatebarang = "update barang set nama_barang='" + textBox3.Text + "',detail_barang='" + deskripsi + "' where id_barang='" + idbarang + "'";
            OracleCommand cmdupdate = new OracleCommand(updatebarang, Form1.oc);
            cmdupdate.ExecuteNonQuery();
            Form1.oc.Close();
        }

        private void Button2_Click_1(object sender, EventArgs e)
        {
            Form1.oc.Close();
            Form1.oc.Open();
            update_barang(textBox2.Text, textBox3.Text, richTextBox1.Text);
            load_dgv_inventory(perintahinventory);
            textBox2.Text = autogen_id_barang();
            textBox3.Text = "";
            richTextBox1.Text = "";
            Form1.oc.Close();
        }

    }
}
