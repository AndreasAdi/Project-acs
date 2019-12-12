using Oracle.DataAccess.Client;
using System;
using System.Data;
using System.Windows.Forms;

namespace Proyek_ACS
{
    public partial class Assign : Form
    {
        DataTable dthakakses;

        public Assign()
        {
            InitializeComponent();
        }

        private void Assign_Load(object sender, EventArgs e)
        {
            loaddgassign();
            loadcb();
            loadcb3();
            if (radioButton1.Checked)
            {
                groupBox1.Enabled = true;
                groupBox2.Enabled = false;
            }
            else if (radioButton2.Checked)
            {
                groupBox1.Enabled = false;
                groupBox2.Enabled = true;
            }
        }
        void loaddgassign()
        {
            string loaddgv = "Select id_Hak_Akses,Nama_akses from list_hak_akses";
            dgassign.DataSource = null;
            dthakakses = new DataTable();
            OracleDataAdapter adapakses = new OracleDataAdapter(loaddgv, Form1.oc);
            adapakses.Fill(dthakakses);
            dgassign.DataSource = dthakakses;
        }
        void loadcb()
        {
            string sql = "select Nama_pegawai,Id_pegawai from Pegawai";
            DataTable dtcb = new DataTable();
            OracleDataAdapter adapcb = new OracleDataAdapter(sql, Form1.oc);
            adapcb.Fill(dtcb);
            comboBox1.DataSource = dtcb;
            comboBox1.ValueMember = "id_pegawai";
            comboBox1.DisplayMember = "Nama_pegawai";
        }
        void loadcb3()
        {
            string sql = "select Nama_pegawai,Id_pegawai from Pegawai";
            DataTable dtcb = new DataTable();
            OracleDataAdapter adapcb = new OracleDataAdapter(sql, Form1.oc);
            adapcb.Fill(dtcb);
            comboBox3.DataSource = dtcb;
            comboBox3.ValueMember = "id_pegawai";
            comboBox3.DisplayMember = "Nama_pegawai";
            //Form1.oc.Close();
        }
        int idx;
        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            groupBox2.Enabled = false;
        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            groupBox1.Enabled = false;
            groupBox2.Enabled = true;
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox1.Text = comboBox1.SelectedValue.ToString();
            loadaksespegawai();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //Form1.oc.Open();
            if (radioButton1.Checked)
            {
                string assignakses = "insert into Hak_Akses Values('" + textBox1.Text + "','" + dgassign.Rows[idx].Cells[0].Value.ToString() + "')";
                //OracleCommand cmd = new OracleCommand(assignakses, Form1.oc);
                //cmd.ExecuteNonQuery();
                Database db = new Database(Form1.oc);
                db.executeNonQuery(assignakses);
                MessageBox.Show("Sukses Memberi Hak Akses");
            }
            else if (radioButton2.Checked)
            {
                string revoke = "delete From Hak_akses Where id_pegawai='" + comboBox3.SelectedValue.ToString() + "' and id_Hak_Akses='" + comboBox2.SelectedValue.ToString() + "'";
                Database db = new Database(Form1.oc);
                db.executeNonQuery(revoke);
                MessageBox.Show("Sukses Revoke Hak Akses");
            }
            //Form1.oc.Close();
        }
        void loadcbrevoke()
        {
            comboBox2.DataSource = null;
            string cbakses = "Select l.id_Hak_Akses,l.Nama_akses from list_hak_akses l,hak_akses h where h.id_pegawai='" + comboBox3.SelectedValue.ToString() + "' and h.id_hak_akses=l.id_hak_akses";
            DataTable dtcb = new DataTable();
            OracleDataAdapter adapcb = new OracleDataAdapter(cbakses, Form1.oc);
            adapcb.Fill(dtcb);
            comboBox2.DataSource = dtcb;
            comboBox2.ValueMember = "id_Hak_Akses";
            comboBox2.DisplayMember = "Nama_Akses";
        }
        private void Dgassign_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idx = e.RowIndex;
        }

        private void ComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox3.Text = "";
            textBox3.Text = comboBox3.SelectedValue.ToString();
            loadcbrevoke();
        }

        private void ComboBox3_MouseClick(object sender, MouseEventArgs e)
        {

        }
        void loadaksespegawai()
        {
            comboBox4.DataSource = null;
            string cbakses = "Select l.id_Hak_Akses,l.Nama_akses from list_hak_akses l,hak_akses h where h.id_pegawai='" + comboBox1.SelectedValue.ToString() + "' and h.id_hak_akses=l.id_hak_akses";
            DataTable dtcb = new DataTable();
            OracleDataAdapter adapcb = new OracleDataAdapter(cbakses, Form1.oc);
            adapcb.Fill(dtcb);
            comboBox4.DataSource = dtcb;
            comboBox4.ValueMember = "id_Hak_Akses";
            comboBox4.DisplayMember = "Nama_Akses";
        }
    }
}
