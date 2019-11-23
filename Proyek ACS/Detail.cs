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
    public partial class Detail : Form
    {
        OracleConnection conn = Form1.oc;
        public Detail()
        {
            InitializeComponent();
        }
        //public Detail(string iddistributor, string paymentterm, string paymenttype, DateTime tanggal, DataGridView datagrid)
        //{
        //    InitializeComponent();
        //    datagrid.Rows.Add(iddistributor, paymentterm, paymenttype, tanggal);
        //}
        private void Button1_Click(object sender, EventArgs e)
        {
            Order ord = new Order();
            ord.Show();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Detail_Load(object sender, EventArgs e)
        {
            string query = "select autogen_id from dual";
            OracleCommand cmd = new OracleCommand(query,conn);

            label1.Text = cmd.ExecuteScalar().ToString();

        }
    }
}
