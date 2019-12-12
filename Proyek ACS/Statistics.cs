using CrystalDecisions.Shared;
using System;
using System.Windows.Forms;

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
                    ci.ConnectionInfo.ServerName = Form1.ip; //ganti ipnya
                    ci.ConnectionInfo.UserID = "proyek";
                    ci.ConnectionInfo.Password = "proyek";
                    table.ApplyLogOnInfo(ci);
                }


            }
            catch (Exception)
            {

                throw;
            }
            crpt.SetDatabaseLogon("proyek", "proyek");
            crystalReportViewer1.ReportSource = crpt;


            crpt.SetParameterValue("Tanggal_Awal", dateTimePicker1.Value);
            crpt.SetParameterValue("Tanggal Akhir", dateTimePicker2.Value);
            //    crpt.SetParameterValue("idcabang", );



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
