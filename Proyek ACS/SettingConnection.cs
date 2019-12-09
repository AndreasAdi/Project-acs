using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;  
using System.Runtime.Serialization;  
using System.Runtime.Serialization.Formatters.Binary; 

namespace Proyek_ACS
{
    public partial class SettingConnection : Form
    {
        public SettingConnection()
        {
            InitializeComponent();
        }
        string connstring;
        private void SettingConnection_Load(object sender, EventArgs e)
        {

            //connstring = "";
            //try
            //{
            //    // Create an instance of StreamReader to read from a file.
            //    // The using statement also closes the StreamReader.
            //    using (StreamReader sr = new StreamReader(Application.StartupPath + "//conn.txt"))
            //    {
            //        string line;

            //        // Read and display lines from the file until 
            //        // the end of the file is reached. 
            //        while ((line = sr.ReadLine()) != null)
            //        {
            //            connstring = connstring + "\n" +line; 
            //        }
            //    }

            //}
            //catch (Exception ex)
            //{
            //    // Let the user know what went wrong.
            //    Console.WriteLine("The file could not be read:");
            //    Console.WriteLine(ex.Message);
            //}
            load();

        }

        private void Button1_Click(object sender, EventArgs e)
        {


            File.Create(Application.StartupPath+"//conn.txt").Close();
            connstring = textBox1.Text + "\n" + textBox2.Text + "\n" + textBox3.Text + "\n"+ textBox4.Text + "\n";

            System.IO.File.WriteAllText(@"conn.txt", connstring);

            Form1 f = new Form1();
            f.Show();
  

        }

        void load() {

            List<string> connstring = new List<string>();
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

            textBox1.Text = connstring[0].ToString();
            textBox2.Text = connstring[1].ToString();
            textBox3.Text = connstring[2].ToString();
            textBox4.Text = connstring[3].ToString();
        }
    }

    
}
