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
        private void Approved_Draft_Load(object sender, EventArgs e)
        {
            label12.Text = status;
            if (status =="Draft")
            {
                button2.Text = "Approve";
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (button2.Text == "Approve")
            {
                conn.Close();
                conn.Open();
                query = "select count(id_pegawai) from hak_akses where id_pegawai = '"+id_pegawai+"' and id_hak_akses ='HA003'";
                OracleCommand cmd = new OracleCommand(query,conn);
                int bolehapprove = int.Parse(cmd.ExecuteScalar().ToString());

                query = "select count(id_pegawai) from hak_akses where id_pegawai = '" + id_pegawai + "' and id_hak_akses ='HA006'";
                cmd = new OracleCommand(query, conn);
                bolehapprove += int.Parse(cmd.ExecuteScalar().ToString());
                if (bolehapprove > 0)
                {
                    query = "Update order_header set status_order = 1  where id_order = '" + id_order + "' ";
                    cmd = new OracleCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    
                }
                else {
                    MessageBox.Show("Tidak Memiliki Akses");
                }


            }
        }
    }
}
