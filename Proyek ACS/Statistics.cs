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
    public partial class Statistics : Form
    {
        public Statistics()
        {
            InitializeComponent();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void crystalReportViewer1_Load_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CrystalReport2 crpt = new CrystalReport2();
            try
            {
                crpt.SetDatabaseLogon("proyek", "proyek");
            }
            catch (Exception)
            {

                throw;
            }
            crystalReportViewer1.ReportSource = crpt;
            crpt.SetParameterValue("Tanggal_Awal", dateTimePicker1.Value);
            crpt.SetParameterValue("Tanggal Akhir", dateTimePicker2.Value);
        }

        private void Statistics_Load(object sender, EventArgs e)
        {
            /*
            OracleConnection conn = new OracleConnection("data source=xe;user id=latihan;password=lat");
            conn.Open();
            */
        }
    }
}
