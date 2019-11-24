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
            "and oh.Id_Pegawai = p.Id_Pegawai ";
        public listorder()
        {
            InitializeComponent();
        }

        private void Listorder_Load(object sender, EventArgs e)
        {
            load_dgv_listorder(perintahlistpo);
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
        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex>-1)
            {
                status = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
                id_order = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                namapegawai = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                date = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[5].Value).ToString("dd/MM/yyyy");

                Approved_Draft A = new Approved_Draft();
                A.status = status;
                A.id_order = id_order;
                A.author = namapegawai;
                A.date = date;
                Hide();
                A.Show();
                Close();
            }
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
    }
}
