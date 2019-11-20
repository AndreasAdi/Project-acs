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
        string perintahlistpo = "select oh.Id_Order, p.Nama_Pegawai, d.Nama_Distributor, d.Alamat_Distributor, oh.Tanggal_Order, oh.Plan_Date_Delivery, oh.Pajak , oh.Subtotal, " +
            "Case when oh.Status_Order = '0' then 'Not yet approved' " +
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
