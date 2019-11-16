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
    public partial class Inventory : Form
    {
        DataTable dtinventory;

        public Inventory()
        {
            InitializeComponent();
        }

        private void Inventory_Load(object sender, EventArgs e)
        {
            load_dgv_inventory();
        }

        private void load_dgv_inventory()
        {
            dtinventory = new DataTable();
            OracleDataAdapter adapinventory = new OracleDataAdapter("Select * from Stok", Form1.oc);
            adapinventory.Fill(dtinventory);
            dataGridView1.DataSource = dtinventory;
        }

        private void Button2_Click(object sender, EventArgs e)
        {

        }
    }
}
