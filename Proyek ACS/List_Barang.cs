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
    public partial class List_Barang : Form
    {
        DataTable dtinventory;
        string perintahinventory = "select stok.id_barang as ID_BARANG, barang.nama_barang as NAMA_BARANG, barang.detail_barang as Deskripsi, stok.jumlah_stok as STOK " +
                "from stok, barang " +
                "where stok.id_barang = barang.id_barang ";
        int idx;
        public string id_order;
        OracleConnection conn = Form1.oc;
        public List_Barang()
        {
            InitializeComponent();
     
        }

        private void List_Barang_Load(object sender, EventArgs e)
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

        private void Button3_Click(object sender, EventArgs e)
        {
            int ctr =0;
            int idx_sama =0;
            if (numericUpDown1.Value>0)
            {
                string id_barang = dataGridView1.Rows[idx].Cells[0].Value.ToString();
                string nama_barang = dataGridView1.Rows[idx].Cells[1].Value.ToString();
                string detail_barang = dataGridView1.Rows[idx].Cells[2].Value.ToString();
                string JUMLAH = numericUpDown1.Value.ToString();

                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                {
                    if (dataGridView2.Rows[i].Cells[0].Value.ToString() == id_barang)
                    {
                        idx_sama = i;
                        ctr++;
                    }
                }
                if (ctr ==0)
                {
                    dataGridView2.Rows.Add(id_barang, nama_barang, detail_barang, JUMLAH);
                }
                else if (ctr>0)
                {
                    dataGridView2.Rows[idx_sama].Cells[3].Value = Convert.ToString(Convert.ToInt32(dataGridView2.Rows[idx_sama].Cells[3].Value.ToString()) + numericUpDown1.Value);
                }
            }
            else
            {
                MessageBox.Show("Jumlah Barang Harus Lebih besar Dari 0");
            }
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex>-1)
            {
                idx = e.RowIndex;
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            conn.Close();
            conn.Open();
            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
               string query = "insert into order_detail values('"+id_order+"', '"+dataGridView2.Rows[i].Cells[0].Value.ToString()+"', '"+dataGridView2.Rows[i].Cells[1].Value.ToString()+"', "+dataGridView2.Rows[i].Cells[3].Value.ToString()+" , 0) ";

                OracleCommand cmd = new OracleCommand(query,conn);
                cmd.ExecuteNonQuery();
            }
            listorder l = new listorder();
            Hide();
            l.ShowDialog();
            Close();
            
            conn.Close();
        }
    }
}
