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
    
    public partial class Approved_Draft : Form
    {

        OracleConnection conn = Form1.oc;
        public Approved_Draft()
        {
            InitializeComponent();
        }
       
        public string status;
        public string query;
        public string id_order;
        public string id_pegawai = Form1.id_pegawai;
        public string distributor;
        public string author;
        public string date;
        OracleCommand cmd;
        private void Approved_Draft_Load(object sender, EventArgs e)
        {
            label12.Text = status;
            label1.Text = id_order;
            lblauthor.Text = author;
            label10.Text = date;
            if (status =="Draft")
            {
                button2.Text = "Approve";
            }
            load_barang();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (button2.Text == "Approve")
            {
                conn.Close();
                conn.Open();
                query = "select count(id_pegawai) from hak_akses where id_pegawai = '"+id_pegawai+"' and id_hak_akses = 'HA003'";
                cmd = new OracleCommand(query,conn);
                int bolehapprove = int.Parse(cmd.ExecuteScalar().ToString());

                query = "select count(id_pegawai) from hak_akses where id_pegawai = '" + id_pegawai + "' and id_hak_akses = 'HA006'";
                cmd = new OracleCommand(query, conn);
                bolehapprove += int.Parse(cmd.ExecuteScalar().ToString());
                if (bolehapprove > 0)
                {
                    query = "Update order_header set status_order = 1  where id_order = '" + id_order + "' ";
                    cmd = new OracleCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    listorder lo = new listorder();
                    lo.Show();
                }
                else {
                    MessageBox.Show("Tidak Memiliki Akses");
                }


            }
        }
        void load_barang() {
            conn.Close();
            conn.Open();

          
            query = "Select ID_BARANG,NAMA_BARANG,JUMLAH_ORDER,HARGA  from order_detail where id_order = '"+id_order+"'";
            //cmd = new OracleCommand(query, conn);
            //OracleDataAdapter adap = new OracleDataAdapter(cmd);
            //DataTable dt = new DataTable();
            //adap.Fill(dt);

            //dataGridView1.DataSource = dt;
            Database ds = new Database(conn);
            dataGridView1.DataSource = ds.executeDataTable(query);

        }
    }
}
