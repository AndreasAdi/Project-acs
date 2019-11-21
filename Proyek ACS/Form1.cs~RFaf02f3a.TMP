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
        //public static OracleConnection oc = new OracleConnection("User id = projectacs ; password = projectacs ; data source = orcl");
        public static OracleConnection oc = new OracleConnection("User id = latihan ; password = lat ; data source = xe");
        public Form1()
        {
            InitializeComponent();            
        }
        private void Form1_Load(object sender, EventArgs e)
        {

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
        void cek_login(string user) {
            Form_Main fm = new Form_Main();
            
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            oc.Open();
            string ceklog = "select count(id_pegawai) from pegawai where password='" + textBox2.Text + "' and id_pegawai='"+textBox1.Text+"'";
            OracleCommand cmd = new OracleCommand(ceklog, oc);
            cmd.ExecuteNonQuery();
            int cek = Convert.ToInt32(cmd.ExecuteScalar());
            if (cek >= 1)
            {
                Form_Main fm = new Form_Main();
                this.Hide();
                string cekakses = "select id_Hak_Akses from Hak_Akses where id_Pegawai='" + textBox1.Text + "'";
                OracleCommand cm = new OracleCommand(cekakses, oc);
                cm.ExecuteNonQuery();
                string idakses = cm.ExecuteScalar().ToString();
                if (idakses == "HA001")
                {
                    fm.lihatKontakToolStripMenuItem.Enabled = true;
                }
                else if (idakses == "HA002")
                {

                }
                else if (idakses == "HA003")
                {
                    fm.approveOrderToolStripMenuItem.Enabled = true;
                    fm.lihatOrderToolStripMenuItem.Enabled = true;
                }
                else if (idakses == "HA004")
                {
                    fm.assignPrevilegeToolStripMenuItem.Enabled = true;
                }
                else if (idakses == "HA005") {
                    fm.makeOrderToolStripMenuItem.Enabled = true;
                }
                fm.ShowDialog();
                this.Close();
            }
            else {
                MessageBox.Show("Gagal Login password atau username salah");
            }
        }
    }
}
