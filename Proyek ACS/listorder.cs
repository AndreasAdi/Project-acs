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
        public listorder()
        {
            InitializeComponent();
        }

        private void Listorder_Load(object sender, EventArgs e)
        {
            dtlistpo = new DataTable();
            OracleDataAdapter adaplistpo = new OracleDataAdapter("Select * from Order_Header", Form1.oc);
            adaplistpo.Fill(dtlistpo);
            dataGridView1.DataSource = dtlistpo;
        }
    }
}
