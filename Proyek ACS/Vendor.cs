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
    public partial class Vendor : Form
    {
        DataTable dtvendor;
        public Vendor()
        {
            InitializeComponent();
        }
        //Database db = new Database("xe", "proyekacs", "123");
        private void Vendor_Load(object sender, EventArgs e)
        {
            //dataGridView1.DataSource= db.executeDataTable("Select * From Distributor");
            load_dgv_vendor();
        }

        private void load_dgv_vendor()
        {
            dtvendor = new DataTable();
            OracleDataAdapter adapvendor = new OracleDataAdapter("Select * from distributor", Form1.oc);
            adapvendor.Fill(dtvendor);
            dataGridView1.DataSource = dtvendor;
        }
    }
}
