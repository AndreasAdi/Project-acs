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
    public partial class Laporan : Form
    {
        public string idorder;
        public Laporan()
        {
            InitializeComponent();
        }

        private void Laporan_Load(object sender, EventArgs e)
        {
            CrystalReport1 crpt = new CrystalReport1();
            try
            {
                crpt.SetDatabaseLogon("proyek", "proyek");
            }
            catch (Exception)
            {

                throw;
            }
            crystalReportViewer1.ReportSource = crpt;
            crpt.SetParameterValue("ID_ORDER", idorder);
        }
    }
}
