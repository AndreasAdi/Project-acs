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
        public string perintahlistpo = "select oh.Id_Order, p.Nama_Pegawai, d.Nama_Distributor, d.Alamat_Distributor, oh.Tanggal_Order, oh.Plan_Date_Delivery,oh.Subtotal,Payment_Terms.nama as Payment_Terms ,payment_type.nama as Payment_Type,Case when oh.Status_Order = '0' then 'Draft' when oh.Status_Order = '1' then 'Approved' when oh.Status_Order = '2' then 'Dibatalkan' when oh.Status_Order = '3' then 'Diterima Sebagian' when oh.Status_Order = '4' then 'Diterima Penuh' when oh.Status_Order = '5' then 'Order Closed' when oh.Status_Order = '6' then 'Ordered' end as Status from Order_Header oh, Distributor d, Pegawai p, Payment_Terms, payment_type where oh.id_distributor = d.id_distributor and oh.Id_Pegawai = p.Id_Pegawai and Payment_Terms.id_payment_term = oh.id_payment_term and Payment_Terms.id_payment_term = oh.id_payment_term and payment_type.id_payment_type = oh.id_payment_type and oh.id_branch ='"+Form1.Cabang+"' ";
        public listorder()
        {
            InitializeComponent();
        }

        private void Listorder_Load(object sender, EventArgs e)
        {
            Form1.oc.Close();
            Form1.oc.Open();
            load_dgv_listorder(perintahlistpo);
            Form1.oc.Close();

        }

        public void load_dgv_listorder(string perintahlistpo)
        {
            dtlistpo = new DataTable();
            OracleDataAdapter adaplistpo = new OracleDataAdapter(perintahlistpo, Form1.oc);
            adaplistpo.Fill(dtlistpo);
            dataGridView1.DataSource = dtlistpo;
        }


        private void Button_reset_Click(object sender, EventArgs e)
        {
            comboBox_tanggal.SelectedIndex = 0;
            load_dgv_listorder(perintahlistpo);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (comboBox_tanggal.SelectedIndex > -1)
            {
                string berdasarkan = comboBox_tanggal.SelectedItem.ToString();
                string startday = dateTimePicker1.Value.ToString("yyyy/MM/dd");
                string endday = dateTimePicker2.Value.ToString("yyyy/MM/dd");
                string search = "";

                search = perintahlistpo +
                        " and ( to_char(oh." + berdasarkan + ",'yyyy/mm/dd') >= '" + startday + "' )" +
                         " and ( to_char(oh." + berdasarkan + ",'yyyy/mm/dd') <= '" + endday + "' )";
                load_dgv_listorder(search);
            }
            else
            {
                MessageBox.Show("Pilih search berdasarkan Tanggal Purchase atau Tanggal Plan Delivery");
            }

        }

        public string status;
        string id_order;
        string namapegawai;
        string date;
        string distributor;
        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Purchase_Order p = new Purchase_Order();
            this.Hide();
            p.ShowDialog();
            this.Close();
        }

        private void DataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                status = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
                id_order = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                namapegawai = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                date = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[5].Value).ToString("dd/MM/yyyy");

                Approved_Draft A = new Approved_Draft();
                A.status = status;
                A.id_order = id_order;
                A.author = namapegawai;
                A.date = date;
                A.distributor = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                A.payment_type = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
                A.payment_terms = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                Hide();
                A.Show();
                Close();
            }
        }

        private void DataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
