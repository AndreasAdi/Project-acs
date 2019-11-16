using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyek_ACS
{
    public partial class Vendor : Form
    {
        public Vendor()
        {
            InitializeComponent();
        }
        Database db = new Database("xe", "proyekacs", "123");
        private void Vendor_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource= db.executeDataTable("Select * From Distributor");
        }
    }
}
