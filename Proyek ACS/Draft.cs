﻿using System;
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
    public partial class Purchase_Order : Form
    {
        OracleConnection conn = Form1.oc;
        public Purchase_Order()
        {
            InitializeComponent();
        }

        private void Purchase_Order_Load(object sender, EventArgs e)
        {
            load();  
        }

        private void Label7_Click(object sender, EventArgs e)
        {

        }


        private void Button2_Click_1(object sender, EventArgs e)
        {
            Detail d = new Detail();
            d.Show();
        }

        void load() {
            conn.Close();
            conn.Open();
            string query = "Select * id_distributor , nama_distributor from distributor";
            comboBox4.DataSource = null;
            OracleDataAdapter adap = new OracleDataAdapter(query, conn);
            DataTable dt = new DataTable();
            adap.Fill(dt);
            comboBox4.DataSource = dt;
            comboBox4.ValueMember = "id_distributor";
            comboBox4.DisplayMember = "nama_distributor";

            //comboBox1
        }
    }
}
