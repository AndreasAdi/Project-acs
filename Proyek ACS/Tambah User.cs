using Oracle.DataAccess.Client;
using System;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Proyek_ACS
{
    public partial class Tambah_User : Form
    {
        public Tambah_User()
        {
            InitializeComponent();
        }
        DataTable dt;
        DataTable branch;
        private void Label4_Click(object sender, EventArgs e)
        {

        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Tambah_User_Load(object sender, EventArgs e)
        {
            loaddgvpegawai();
            load_cbBranch();
            tbid.Text = autogen_id_Pegawai();
        }
        void loaddgvpegawai()
        {
            dt = new DataTable();
            dataGridView1.DataSource = null;
            string query = "select Id_Pegawai,nama_Pegawai,id_branch,manager from pegawai";
            OracleDataAdapter adpt = new OracleDataAdapter(query, Form1.oc);
            adpt.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        void load_cbBranch()
        {
            Form1.oc.Close();
            Form1.oc.Open();
            string q = "select id_branch,alamat from branch";
            comboBox1.DataSource = null;
            branch = new DataTable();
            OracleDataAdapter orabranch = new OracleDataAdapter(q, Form1.oc);
            orabranch.Fill(branch);
            comboBox1.DataSource = branch;
            comboBox1.ValueMember = "id_branch";
            comboBox1.DisplayMember = "alamat";
            Form1.oc.Close();
        }
        string autogen_id_Pegawai()
        {
            Form1.oc.Close();
            Form1.oc.Open();
            string idpegawai = "PEG";
            string queryid = "select Count(id_pegawai) from pegawai";
            int nourut;
            OracleCommand cmdid = new OracleCommand(queryid, Form1.oc);
            cmdid.ExecuteNonQuery();
            nourut = Convert.ToInt32(cmdid.ExecuteScalar()) + 1;
            if (nourut > 9)
            {
                idpegawai = idpegawai + "0" + nourut;
            }
            else if (nourut > 99)
            {
                idpegawai = idpegawai + nourut;
            }
            else
            {
                idpegawai = idpegawai + "00" + nourut;
            }
            return idpegawai;
            Form1.oc.Close();
        }
        void insert_pegawai(string id, string nama, string password, string idbranch, int idmanager)
        {
            Form1.oc.Close();
            Form1.oc.Open();
            MessageBox.Show(idbranch);
            string qinsert = "insert into pegawai values('" + id + "','" + nama + "','" + password + "','" + idbranch + "'," + idmanager + ")";
            OracleCommand cmdinsert = new OracleCommand(qinsert, Form1.oc);
            cmdinsert.ExecuteNonQuery();
            Form1.oc.Close();

        }
        void update_pegawai(string id, string nama, string password, string idbranch, int idmanager)
        {
            Form1.oc.Close();
            Form1.oc.Open();
            string qupdate = "update pegawai set set nama_pegawai='" + nama + "',password='" + password + "',id_branch='" + idbranch + "',manager=" + idmanager + " where id_pegawai='" + id + "'";
            OracleCommand cmdupdate = new OracleCommand(qupdate, Form1.oc);
            cmdupdate.ExecuteNonQuery();
            Form1.oc.Close();

        }
        void delete_pegawai(string id)
        {
            Form1.oc.Close();
            Form1.oc.Open();

            string qdelete = "delete from pegawai where id_pegawai='" + id + "'";
            OracleCommand cmddelete = new OracleCommand(qdelete, Form1.oc);
            cmddelete.ExecuteNonQuery();
            Form1.oc.Close();


        }
        private void Button1_Click(object sender, EventArgs e)
        {
            insert_pegawai(tbid.Text, tbnama.Text, SHA512(tbpass.Text), comboBox1.SelectedValue.ToString(), Convert.ToInt32(idmanager.Text));
            loaddgvpegawai();
            tbid.Text = autogen_id_Pegawai();
            tbnama.Text = "";
            tbpass.Text = "";
            idmanager.Text = "";
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            tbnama.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            idmanager.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            update_pegawai(tbid.Text, tbnama.Text, tbpass.Text, comboBox1.SelectedValue.ToString(), Convert.ToInt32(idmanager.Text));
            loaddgvpegawai();
            tbid.Text = autogen_id_Pegawai();
            tbnama.Text = "";
            tbpass.Text = "";
            idmanager.Text = "";
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            delete_pegawai(tbid.Text);
            loaddgvpegawai();
            tbid.Text = autogen_id_Pegawai();
            tbnama.Text = "";
            tbpass.Text = "";
            idmanager.Text = "";
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

