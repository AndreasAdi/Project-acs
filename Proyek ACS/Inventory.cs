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
    public partial class Inventory : Form
    {
        DataTable dtinventory;
        string perintahinventory = "select stok.id_barang as ID_BARANG, barang.nama_barang as NAMA_BARANG, barang.detail_barang as Deskripsi, stok.jumlah_stok as JUMLAH, stok.tanggal_masuk as TANGGAL_MASUK " +
                "from stok, barang " +
                "where stok.id_barang = barang.id_barang ";
        public Inventory()
        {
            InitializeComponent();
        }

        private void Inventory_Load(object sender, EventArgs e)
        {
            load_dgv_inventory(perintahinventory);
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
                if (comboBox1.SelectedIndex == 2){filter = "detail_barang";}
                search = perintahinventory + " and lower("+filter+") like '%"+keyword+"%'";
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

        }
    }
}
