using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Security.Cryptography;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
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

        // public static OracleConnection oc = new OracleConnection("User id = latihan ; password = latihan ; data source = Orcl");
        public static OracleConnection oc;
        List<string> connstring = new List<string>();
        public static string idbranch;
        public static string idb;
        public static string ip = "192.168.43.129";
        //public static string ip = "10.11.238.40";
        public static string dbname ="xe", userid ="proyek", password="proyek";
        //public static string dbname ="xe", userid ="proyek", password="proyek";
        //public static OracleConnection oc = new OracleConnection("User id = latihan ; password = latihan ; data source = xe");
public Form1()
        {
            InitializeComponent();            
        }
        public static bool en = false;
        private void Form1_Load(object sender, EventArgs e)
        {
            loadconnection();
                oc = new OracleConnection("Data Source=" +
                    "(DESCRIPTION=" +
                    "(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)" +
                    "(HOST = "+ip+")(PORT=1521)))" + //host ipnya ganti
                    "(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME="+dbname+")));" +
                    "user id="+userid+";password="+password+" ");

        }
        public static string id_pegawai;
        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                oc.Close();
                oc.Open();

                Form_Main fm = new Form_Main();
                id_pegawai = textBox1.Text;
                //MessageBox.Show(id_pegawai);
               // MessageBox.Show(textBox2.Text);
                string ceklog = "select count(id_pegawai) from pegawai where password='"+SHA512(textBox2.Text) +"' and id_pegawai='"+textBox1.Text+"'";
                //string ceklog = "select count(*) from Pegawai where pegawai.id_pegawai ='" + textBox1.Text + "' and(select my_decrypt(Password, 'aplikasi client server') from Pegawai where pegawai.id_pegawai ='" + textBox1.Text + "') = '" + textBox2.Text + "'";
                OracleCommand cmd = new OracleCommand(ceklog, oc);
                cmd.ExecuteNonQuery();
                int cek = Convert.ToInt32(cmd.ExecuteScalar());

              //  MessageBox.Show(cek + "");
                if (cek >= 1)
                {
                    this.Hide();
                    string cekakses = "select id_Hak_Akses from Hak_Akses where id_Pegawai='" + textBox1.Text + "'";
                    idbranch = "select id_branch from pegawai where id_Pegawai='" + textBox1.Text + "'";
                    OracleCommand cari_id_branch = new OracleCommand(idbranch, oc);
                    idb = cari_id_branch.ExecuteScalar().ToString();
                    OracleCommand cm = new OracleCommand(cekakses, oc);
                    OracleDataReader read = cm.ExecuteReader();
                    while (read.Read())
                    {
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
                            fm.lihatOrderToolStripMenuItem.Enabled = true;
                        }
                        else if (akses == "HA004")
                        {
                            fm.assignPrevilegeToolStripMenuItem.Enabled = true;
                        }
                        else if (akses == "HA005")
                        {
                            fm.lihatInventoryToolStripMenuItem.Enabled = true;
                        }
                        else if (akses == "HA006")
                        {
                            fm.lihatKontakToolStripMenuItem.Enabled = true;
                            fm.lihatOrderToolStripMenuItem.Enabled = true;
                            fm.tambahUserToolStripMenuItem.Enabled = true;
                            fm.lihatInventoryToolStripMenuItem.Enabled = true;
                            fm.assignPrevilegeToolStripMenuItem.Enabled = true;
                            fm.laporanToolStripMenuItem.Enabled = true;
                            en = true;
                        }
                        else if (akses == "HA007")
                        {
                            fm.laporanToolStripMenuItem.Enabled = true;
                        }
                        else if (akses == "HA008")
                        {
                            fm.lihatOrderToolStripMenuItem.Enabled = true;
                        }
                        else if (akses == "HA009")
                        {
                            fm.tambahUserToolStripMenuItem.Enabled = true;
                        }
                    }
                    read.Close();
                    id_pegawai = textBox1.Text;
                    fm.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Gagal Login password atau username salah");
                }
                oc.Close();
            }
            catch (OracleException ex)
            {
                MessageBox.Show(Convert.ToString(ex));
                MessageBox.Show("error");
                SettingConnection s = new SettingConnection();
                s.Show();

            }
           
           
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }



        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {
            Close();
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private void Form1_MouseDown_1(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            SettingConnection s = new SettingConnection();
            s.Show();
        }

        void loadconnection() {
          
            try
            {
                // Create an instance of StreamReader to read from a file.
                // The using statement also closes the StreamReader.
                using (StreamReader sr = new StreamReader(Application.StartupPath + "//conn.txt"))
                {
                    string line;

                    // Read and display lines from the file until 
                    // the end of the file is reached. 
                    while ((line = sr.ReadLine()) != null)
                    {
                        connstring.Add(line);
                    }

                    
                }
            }
            catch (Exception ex)
            {
                // Let the user know what went wrong.
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(ex.Message);
            }

            ip = connstring[0].Trim();
            dbname = connstring[1].Trim();
            userid = connstring[2].Trim();
            password = connstring[3].Trim();
        }

        private static string GenerateHashString(HashAlgorithm algo, string text)
        {
            // Compute hash from text parameter
            algo.ComputeHash(Encoding.UTF8.GetBytes(text));

            // Get has value in array of bytes
            var result = algo.Hash;

            // Return as hexadecimal string
            return string.Join(
                string.Empty,
                result.Select(x => x.ToString("x2")));
        }

        public static string SHA512(string text)
        {
            var result = default(string);

            using (var algo = new SHA512Managed())
            {
                result = GenerateHashString(algo, text);
            }

            return result;
        }
    }
}
