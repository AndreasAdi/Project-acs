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
    public partial class Purchase_Order : Form
    {
        OracleConnection conn = Form1.oc;
        public Purchase_Order()
        {
            InitializeComponent();
        }

        private void Purchase_Order_Load(object sender, EventArgs e)
        {
            load();  
        }

        private void Label7_Click(object sender, EventArgs e)
        {

        }


        private void Button2_Click_1(object sender, EventArgs e)
        {
            conn.Close();
            conn.Open();
            //Detail d = new Detail();
            //d.Show();
            string idpeg = Form1.id_pegawai;
            OracleCommand id = new OracleCommand("select AUTOGEN_ID from dual",conn);
            string idheader = id.ExecuteScalar().ToString();
            string idpayterm = comboBox2.SelectedValue.ToString();
            string idpaytype = comboBox1.SelectedValue.ToString();
            OracleCommand cmd = new OracleCommand("insert into order_header values('"+idheader+"','"+comboBox4.SelectedValue.ToString()+ "',to_date('" + dateTimePicker1.Value.ToString("dd/MM/yyyy") + "','DD/MM/YYYY'),to_date('" + DateTime.Now.ToString("dd/MM/yyyy")+"','DD/MM/YYYY'),0,'0','"+idpeg+"','"+idpayterm+"','"+idpaytype+"','"+Form1.idb+"')",conn);
            cmd.ExecuteNonQuery();
            listorder l = new listorder();
            this.Hide();
            l.ShowDialog();
            this.Close();
            conn.Close();
        }

        void load() {
            conn.Close();
            conn.Open();
            string query = "Select id_distributor , nama_distributor from distributor";
            comboBox4.DataSource = null;
            OracleDataAdapter adap = new OracleDataAdapter(query, conn);
            DataTable dt = new DataTable();
            adap.Fill(dt);
            comboBox4.DataSource = dt;
            comboBox4.ValueMember = "id_distributor";
            comboBox4.DisplayMember = "nama_distributor";


            query = "Select id_payment_term , nama from payment_terms";
            comboBox2.DataSource = null;
            adap = new OracleDataAdapter(query, conn);
            dt = new DataTable();
            adap.Fill(dt);
            comboBox2.DataSource = dt;
            comboBox2.ValueMember = "id_payment_term";
            comboBox2.DisplayMember = "nama";



            query = "Select id_payment_type, nama from payment_type";
            comboBox1.DataSource = null;
            adap = new OracleDataAdapter(query, conn);
            dt = new DataTable();
            adap.Fill(dt);
            comboBox1.DataSource = dt;
            comboBox1.ValueMember = "id_payment_type";
            comboBox1.DisplayMember = "nama";
            conn.Close();
        }
    }
}
