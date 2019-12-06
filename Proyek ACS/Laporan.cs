using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

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

            
            crpt.SetDatabaseLogon("proyek", "proyek");
            crpt.SetParameterValue("ID_ORDER", idorder);
            crystalReportViewer1.ReportSource = crpt;

            try
            {
                foreach (CrystalDecisions.CrystalReports.Engine.Table table in crpt.Database.Tables)
                {
                    TableLogOnInfo ci = new TableLogOnInfo();
                    /** 
                     * @notes Ini itterate di masing-masing tabel pada RPT yang dibuat, sehingga koneksi berubah jadi ini
                     * Database itu dikosongi agar databasenya tetap seperti sebelumnya
                     * @see https://stackoverflow.com/q/17914605 
                     * @see https://stackoverflow.com/questions/4864169/crystal-report-and-problem-with-connection
                     */
                    ci.ConnectionInfo.DatabaseName = "";
                    ci.ConnectionInfo.ServerName = "192.168.1.5"; //ganti ipnya
                    ci.ConnectionInfo.UserID = "proyek";
                    ci.ConnectionInfo.Password = "proyek";
                    table.ApplyLogOnInfo(ci);
                }
                
                
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
