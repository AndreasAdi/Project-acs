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
        void loaddgvpegawai() {
            dt = new DataTable();
            dataGridView1.DataSource = null;
            string query = "select Id_Pegawai,nama_Pegawai from pegawai";
            OracleDataAdapter adpt = new OracleDataAdapter(query, Form1.oc);
            adpt.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        void load_cbBranch() {
            string q = "select id_branch,alamat from branch";
            comboBox1.DataSource = null;
            branch = new DataTable();
            OracleDataAdapter orabranch = new OracleDataAdapter(q, Form1.oc);
            orabranch.Fill(branch);
            comboBox1.DataSource = branch;
            comboBox1.ValueMember = "id_branch";
            comboBox1.DisplayMember = "alamat";
        }
        string autogen_id_Pegawai() {
            string idpegawai="PEG";
            string queryid = "select Count(id_pegawai) from pegawai";
            int nourut;
            OracleCommand cmdid = new OracleCommand(queryid, Form1.oc);
            cmdid.ExecuteNonQuery();
            nourut =Convert.ToInt32(cmdid.ExecuteScalar())+1;
            if (nourut > 9)
            {
                idpegawai = idpegawai + "0" + nourut;
            }
            else if (nourut > 99)
            {
                idpegawai = idpegawai + nourut;
            }
            else {
                idpegawai = idpegawai + "00" + nourut;
            }
            return idpegawai;
        }
        void insert_pegawai(string id,string nama,string password,string idbranch,int idmanager) {
            string qinsert = "insert into pegawai values('" + id + "','" + nama + "','" + password + "','" + idbranch + "'," + idmanager + ")";
            OracleCommand cmdinsert = new OracleCommand(qinsert, Form1.oc);
            cmdinsert.ExecuteNonQuery();
        }
        void update_pegawai(string id, string nama, string password, string idbranch, int idmanager) {
            string qupdate = "update pegawai set set nama_pegawai='" + nama + "',password='"+password+"',id_branch='"+idbranch+"',manager="+idmanager+" where id_pegawai='"+id+"'";
            OracleCommand cmdupdate = new OracleCommand(qupdate, Form1.oc);
            cmdupdate.ExecuteNonQuery();
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            insert_pegawai(tbid.Text,tbnama.Text,tbpass.Text,comboBox1.SelectedValue.ToString(),Convert.ToInt32(idmanager.Text));
            loaddgvpegawai();
            tbid.Text = autogen_id_Pegawai();
            tbnama.Text = "";
            tbpass.Text = "";
            idmanager.Text = "";
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
