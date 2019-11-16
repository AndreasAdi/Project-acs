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
        public Purchase_Order()
        {
            InitializeComponent();
        }

        private void Purchase_Order_Load(object sender, EventArgs e)
        {

        }

        private void Label7_Click(object sender, EventArgs e)
        {

        }


        private void Button2_Click_1(object sender, EventArgs e)
        {
            Detail d = new Detail();
            d.Show();
        }
    }
}
