using Oracle.DataAccess.Client;
using System;
using System.Windows.Forms;

namespace Proyek_ACS
{
    public partial class Form_Main : Form
    {
        public Form_Main()
        {
            InitializeComponent();
        }


        private void LihatOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Approved_Draft ad = new Approved_Draft();
            //ad.Show();
            listorder l = new listorder();
            l.Show();
        }

        private void LihatInventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Inventory i = new Inventory();
            i.Show();
        }

        private void LihatKontakToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Vendor v = new Vendor();
            v.Show();
        }

        private void AssignPrevilegeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Assign asgn = new Assign();
            asgn.Show();
        }

        private void Form_Main_Load(object sender, EventArgs e)
        {
            string query = "Select Nama_pegawai from pegawai where id_pegawai =  '" + Form1.id_pegawai + "' ";
            OracleCommand cmd = new OracleCommand(query, Form1.oc);

            label3.Text = cmd.ExecuteScalar().ToString();
        }

        private void LaporanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Statistics s = new Statistics();
            s.ShowDialog();
        }


        private void Label4_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            Hide();
            f.ShowDialog();
            Close();
        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void TambahUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Tambah_User tu = new Tambah_User();
            Hide();
            tu.ShowDialog();
            Close();
        }
    }
}
