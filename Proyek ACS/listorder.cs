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
    public partial class listorder : Form
    {
        DataTable dtlistpo;
       public string perintahlistpo = "select oh.Id_Order, p.Nama_Pegawai, d.Nama_Distributor, d.Alamat_Distributor, oh.Tanggal_Order, oh.Plan_Date_Delivery, oh.Pajak , oh.Subtotal, " +
            "Case when oh.Status_Order = '0' then 'Draft' " +
                "when oh.Status_Order = '1' then 'Approved' " +
                "when oh.Status_Order = '2' then 'Dibatalkan' " +
                "when oh.Status_Order = '3' then 'Diterima Sebagian' " +
                "when oh.Status_Order = '4' then 'Diterima Penuh' " +
                "when oh.Status_Order = '5' then 'Order Closed' " +
                "end as Status " +
            "from Order_Header oh, Distributor d, Pegawai p " +
            "where oh.id_distributor = d.id_distributor " +
            "and oh.Id_Pegawai = p.Id_Pegawai";
        public listorder()
        {
            InitializeComponent();
        }

        private void Listorder_Load(object sender, EventArgs e)
        {
            load_dgv_listorder(perintahlistpo);
            comboBox_status.Enabled = false;
        }

        public void load_dgv_listorder(string perintahlistpo)
        {
            dtlistpo = new DataTable();
            OracleDataAdapter adaplistpo = new OracleDataAdapter(perintahlistpo, Form1.oc);
            adaplistpo.Fill(dtlistpo);
            dataGridView1.DataSource = dtlistpo;
        }

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {            
            if (comboBox_kategori.SelectedIndex == 6 )
            {
                comboBox_status.Enabled = true;
            }
            else if (comboBox_kategori.SelectedIndex <6 || comboBox_kategori.SelectedIndex >6)
            {
                comboBox_status.Enabled = false;
            }
        }

        private void Button_reset_Click(object sender, EventArgs e)
        {
            comboBox_tanggal.SelectedIndex = 0;
            comboBox_kategori.SelectedIndex = 0;
            comboBox_status.SelectedIndex = 0;
            load_dgv_listorder(perintahlistpo);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Masukkan isian search");
            }
            String keyword = textBox1.Text;
            string search = "";
            if (comboBox_tanggal.SelectedIndex < 0 || 
                comboBox_kategori.SelectedIndex < 0 || 
                comboBox_status.SelectedIndex <0)
            {
                search = perintahlistpo + " and (" +
                    "order_header.Id_Order like '%" + keyword + "%' or " +
                    "pegawai.Nama_Pegawai like '%" + keyword + "%' or " +
                    "Distributor.Nama_Distributor like '%" + keyword + "%' or " +
                    "Distributor.Alamat_Distributor like '%" + keyword + "%' or " +
                    "Order_Header.Pajak like '%" + keyword + "%' or " +
                    "Order_Header.Subtotal like '%" + keyword + "%' or " +
                    "Order_Header.Status_Order like '%" + keyword + "%'  " +
                    ")";
            }
            else if (comboBox_tanggal.SelectedIndex > 0 ||
                comboBox_kategori.SelectedIndex > 0 ||
                comboBox_status.SelectedIndex > 0)
            {
                string filtertanggal = comboBox_tanggal.SelectedItem.ToString();
                string filterkategori = comboBox_kategori.SelectedItem.ToString();
                string filterstatus = Convert.ToString(comboBox_status.SelectedIndex);

                search = perintahlistpo + " and (" +
                    "" +
                    ")";
            }
            load_dgv_listorder(search);
        }

        public string status;
        string id_order;
        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex>-1)
            {
                status = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
                id_order = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                Approved_Draft A = new Approved_Draft();
                A.status = status;
                A.id_order = id_order;
                this.Hide();
                A.Show();
                this.Close();
            }
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
