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
    public partial class Form1 : Form
    {
        /*
         * CATATAN :
         * Jangan lupa remove connection di references lalu add lagi
         * Lalu ganti data source ke XE kalau pakai EXPRESS
         * Aku pakai orcl soalnya terlanjur instal enterprise
         */
        public static OracleConnection oc = new OracleConnection("User id = proyekacs ; password = 123 ; data source = xe");
        public Form1()
        {
            InitializeComponent();            
        }

        private void koneksi()
        {
            try
            {
                oc.Open();
                MessageBox.Show("Sukses Login");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error di : " + ex.Message);
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
           
            Form_Main main = new Form_Main();
            this.Hide();
            main.ShowDialog();
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            koneksi();
            //Database db = new Database("xe","proyekacs","123");
        }
    }
}
