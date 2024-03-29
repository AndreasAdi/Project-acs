﻿using Oracle.DataAccess.Client;
using System;
using System.Data;
using System.Windows.Forms;

namespace Proyek_ACS
{

    public partial class OrderDetail : Form
    {

        OracleConnection conn = Form1.oc;
        public OrderDetail()
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
        public string payment_terms;
        public string payment_type;

        OracleCommand cmd;
        private void Approved_Draft_Load(object sender, EventArgs e)
        {
            label12.Text = status;
            label1.Text = id_order;
            lblauthor.Text = author;
            label10.Text = date;
            label2.Text = distributor;
            label9.Text = payment_terms;
            label8.Text = payment_type;
            if (status == "Draft")
            {
                button2.Text = "Approve";
            }
            else if (status == "Ordered")
            {
                button2.Text = "Receive";
            }
            if (status != "Draft")
            {
                button5.Enabled = false;
                button4.Enabled = false;
            }
            load_barang();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (button2.Text == "Approve")
            {
                conn.Close();
                conn.Open();


                query = "select count(id_pegawai) from hak_akses where id_pegawai = '" + id_pegawai + "' and id_hak_akses = 'HA003'";
                cmd = new OracleCommand(query, conn);
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
                    Hide();
                    lo.ShowDialog();
                    Close();

                }
                else
                {
                    MessageBox.Show("Tidak Memiliki Akses");
                }

                conn.Close();
            }
            else if (button2.Text == "Make Order")
            {
                conn.Close();
                conn.Open();


                query = "Update order_header set status_order = 6  where id_order = '" + id_order + "' ";
                cmd = new OracleCommand(query, conn);
                cmd.ExecuteNonQuery();
                listorder lo = new listorder();
                Hide();
                lo.ShowDialog();
                Close();

                conn.Close();

            }
            else if (button2.Text == "Receive")
            {
                conn.Close();
                conn.Open();


                query = "Update order_header set status_order = 4  where id_order = '" + id_order + "' ";
                cmd = new OracleCommand(query, conn);
                cmd.ExecuteNonQuery();
                listorder lo = new listorder();
                Hide();
                lo.ShowDialog();
                Close();
                conn.Close();
            }
        }
        void load_barang()
        {
            conn.Close();
            conn.Open();


            query = "Select ID_BARANG,NAMA_BARANG,JUMLAH_ORDER,HARGA,pajak,diskon,total_kotor,total_bersih from order_detail where id_order = '" + id_order + "'";
            cmd = new OracleCommand(query, conn);
            OracleDataAdapter adap = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();
            adap.Fill(dt);

            dataGridView1.DataSource = dt;

            //   Database ds = new Database(conn);
            //  dataGridView1.DataSource = ds.executeDataTable(query);
            query = "Select sum (total_bersih) from order_detail where id_order = '" + id_order + "' ";
            cmd = new OracleCommand(query, conn);
            label13.Text = cmd.ExecuteScalar().ToString();
            conn.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Laporan l = new Laporan();
            l.idorder = id_order;
            l.Show();
        }

        private void Button4_Click(object sender, EventArgs e)
        {

            List_Barang l = new List_Barang();
            l.id_order = label1.Text;
            Hide();
            l.ShowDialog();
            Close();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            conn.Close();
            conn.Open();
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                query = "update order_detail set harga = " + dataGridView1.Rows[i].Cells[3].Value.ToString() + " where id_barang = '" + dataGridView1.Rows[i].Cells[0].Value.ToString() + "' and id_order ='" + id_order + "'";
                cmd = new OracleCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
            query = "update order_header set subtotal = 0  where id_order ='" + id_order + "'";
            cmd = new OracleCommand(query, conn);
            cmd.ExecuteNonQuery();

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                query = "update order_header set subtotal = subtotal+" + dataGridView1.Rows[i].Cells[3].Value.ToString() + " * " + dataGridView1.Rows[i].Cells[2].Value.ToString() + "*( 100 + " + dataGridView1.Rows[i].Cells[4].Value.ToString() + ")/100 where id_order ='" + id_order + "'";
                cmd = new OracleCommand(query, conn);
                cmd.ExecuteNonQuery();
            }


            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                query = "update order_detail set pajak = " + dataGridView1.Rows[i].Cells[4].Value.ToString() + " where id_barang = '" + dataGridView1.Rows[i].Cells[0].Value.ToString() + "' and id_order ='" + id_order + "'";
                cmd = new OracleCommand(query, conn);
                cmd.ExecuteNonQuery();
            }

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                query = "update order_detail set diskon = " + dataGridView1.Rows[i].Cells[5].Value.ToString() + " where id_barang = '" + dataGridView1.Rows[i].Cells[0].Value.ToString() + "' and id_order ='" + id_order + "'";
                cmd = new OracleCommand(query, conn);
                cmd.ExecuteNonQuery();
            }

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                query = "update order_detail set total_kotor =  " + dataGridView1.Rows[i].Cells[3].Value.ToString() + " * " + dataGridView1.Rows[i].Cells[2].Value.ToString() + " where id_order ='" + id_order + "' and id_barang = '" + dataGridView1.Rows[i].Cells[0].Value.ToString() + "' ";
                cmd = new OracleCommand(query, conn);
                cmd.ExecuteNonQuery();
            }


            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                query = "update order_detail set total_bersih = " + dataGridView1.Rows[i].Cells[3].Value.ToString() + " * " + dataGridView1.Rows[i].Cells[2].Value.ToString() + "*(( 100 + " + dataGridView1.Rows[i].Cells[4].Value.ToString() + ")/100)  - " + dataGridView1.Rows[i].Cells[5].Value.ToString() + "  where id_order ='" + id_order + "' and id_barang = '" + dataGridView1.Rows[i].Cells[0].Value.ToString() + "'";
                cmd = new OracleCommand(query, conn);
                cmd.ExecuteNonQuery();
            }


            MessageBox.Show("Berhasil Update");
            load_barang();
            query = "Select sum (total_bersih) from order_detail where id_order = '" + id_order + "' ";

            conn.Open();
            cmd = new OracleCommand(query, conn);
            label13.Text = int.Parse(cmd.ExecuteScalar().ToString()).ToString("#,##0");




            conn.Close();



        }

        private void Label9_Click(object sender, EventArgs e)
        {

        }

        private void Approved_Draft_FormClosed(object sender, FormClosedEventArgs e)
        {
            listorder l = new listorder();
            l.Show();
        }
    }
}
