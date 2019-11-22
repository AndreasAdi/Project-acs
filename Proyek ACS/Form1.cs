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
        public static bool en = false;
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void Button1_Click(object sender, EventArgs e)
        {
            oc.Open();
            Form_Main fm = new Form_Main();
          
            string ceklog = "select count(id_pegawai) from pegawai where password='" + textBox2.Text + "' and id_pegawai='"+textBox1.Text+"'";
            OracleCommand cmd = new OracleCommand(ceklog, oc);
            cmd.ExecuteNonQuery();
            int cek = Convert.ToInt32(cmd.ExecuteScalar());
            if (cek >= 1)
            {
                this.Hide();
                string cekakses = "select id_Hak_Akses from Hak_Akses where id_Pegawai='" + textBox1.Text + "'";
                OracleCommand cm = new OracleCommand(cekakses, oc);
               
                OracleDataReader read = cm.ExecuteReader() ;
               while (read.Read()) {
                    string akses = read.GetString(0);
                    if (akses == "HA001")
                    {
                        fm.lihatKontakToolStripMenuItem.Enabled = true;
                    }
                    else if (akses == "HA002")
                    {
                        fm.lihatKontakToolStripMenuItem.Enabled = true;
                        en = true;
                    }
                    else if (akses == "HA003")
                    {
                        fm.approveOrderToolStripMenuItem.Enabled = true;
                        fm.lihatOrderToolStripMenuItem.Enabled = true;
                    }
                    else if (akses == "HA004")
                    {
                        fm.assignPrevilegeToolStripMenuItem.Enabled = true;
                    }
                    else if (akses == "HA005") {
                        fm.makeOrderToolStripMenuItem.Enabled = true;
                    }
                    else if (akses == "HA006")
                    {
                        fm.lihatKontakToolStripMenuItem.Enabled = true;
                        fm.approveOrderToolStripMenuItem.Enabled = true;
                        fm.lihatOrderToolStripMenuItem.Enabled = true;
                        fm.makeOrderToolStripMenuItem.Enabled = true;
                        fm.makeOrderToolStripMenuItem.Enabled = true;
                        fm.lihatInventoryToolStripMenuItem.Enabled = true;
                        fm.assignPrevilegeToolStripMenuItem.Enabled = true;
                        en = true;
                    }
                    else if (akses == "HA007")
                    {
                        fm.makeOrderToolStripMenuItem.Enabled = true;
                    }
                    else if (akses == "HA007")
                    {
                        fm.makeOrderToolStripMenuItem.Enabled = true;
                    }
                }
                read.Close();
                fm.ShowDialog();
                this.Close();
            }
            else if (textBox1.Text=="master" && textBox2.Text=="master") {
               
                fm.ShowDialog();
                this.Close();
            }
            else{
                MessageBox.Show("Gagal Login password atau username salah");
            }
            oc.Close();
        }
    }
}
