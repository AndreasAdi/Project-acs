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
        string perintahlistpo = "select Order_Header.Id_Order, Pegawai.Nama_Pegawai, Distributor.Nama_Distributor, Distributor.Alamat_Distributor, Order_Header.Tanggal_Order, Order_Header.Plan_Date_Delivery, Order_Header.Pajak , Order_Header.Subtotal, " +
            "Case when Order_Header.Status_Order = '0' then 'Not yet approved' " +
                "when Order_Header.Status_Order = '1' then 'Approved' " +
                "when Order_Header.Status_Order = '2' then 'Dibatalkan' " +
                "when Order_Header.Status_Order = '3' then 'Diterima Sebagian' " +
                "when Order_Header.Status_Order = '4' then 'Diterima Penuh' " +
                "when Order_Header.Status_Order = '5' then 'Order Closed' " +
                "end as Status " +
            "from Order_Header, Distributor, Pegawai " +
            "where Order_Header.id_distributor = Distributor.id_distributor " +
            "and Order_Header.Id_Pegawai = Pegawai.Id_Pegawai ";
        public listorder()
        {
            InitializeComponent();
        }

        private void Listorder_Load(object sender, EventArgs e)
        {
            load_dgv_listorder(perintahlistpo);
            comboBox1.Enabled = false;
        }

        private void load_dgv_listorder(string perintahlistpo)
        {
            dtlistpo = new DataTable();
            OracleDataAdapter adaplistpo = new OracleDataAdapter(perintahlistpo, Form1.oc);
            adaplistpo.Fill(dtlistpo);
            dataGridView1.DataSource = dtlistpo;
        }

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {            
            if (comboBox2.SelectedIndex == 6 )
            {
                comboBox1.Enabled = true;
            }
            else if (comboBox2.SelectedIndex <6 || comboBox2.SelectedIndex >6)
            {
                comboBox1.Enabled = false;
            }
        }

        private void Button_reset_Click(object sender, EventArgs e)
        {
            load_dgv_listorder(perintahlistpo);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Masukkan isian search");
            }
            String keyword = textBox1.Text;
            if (true)
            {

            }
        }
    }
}
