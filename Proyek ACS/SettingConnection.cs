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
        List<string> connstring;
        private void SettingConnection_Load(object sender, EventArgs e)
        {
            connstring = new List<string>();
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

                MessageBox.Show(connstring[0].ToString());
                textBox1.Text = connstring[0].ToString();
                textBox2.Text = connstring[1].ToString();
                textBox3.Text = connstring[2].ToString();
                textBox4.Text = connstring[3].ToString();
            }
            catch (Exception ex)
            {
                // Let the user know what went wrong.
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(ex.Message);
            }


        }

        private void Button1_Click(object sender, EventArgs e)
        {
            
            connstring.Add(textBox1.Text);
            connstring.Add(textBox2.Text);
            connstring.Add(textBox3.Text);
            connstring.Add(textBox4.Text);

            using (StreamWriter sw = new StreamWriter("conn.txt"))
            {

                foreach (string s in connstring)
                {
                    sw.WriteLine(s);
                }
            }
            MessageBox.Show("Berhasil");
        }
    }

    
}
