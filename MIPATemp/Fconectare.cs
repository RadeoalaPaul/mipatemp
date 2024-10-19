using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MIPATemp
{
    public partial class Fconectare : Form
    {
        public Fconectare()
        {
            InitializeComponent();
        }

        private void bIesireFcon_Click(object sender, EventArgs e)
        {
            Meniu_principal principal = new Meniu_principal();
            this.Close();
            principal.Show();

        }

        public readonly string db_info = AppDomain.CurrentDomain.BaseDirectory + "/db_info.txt"; //definire adresa fisier

        bool Conexiune_db(string server, string user, string password, string database)
        {
            MySqlConnection conn = new MySqlConnection();
            string string_conexiune = @"host = '" + server + "'; port = '3306';" + " password = '" + password + "'; user = '" + user + "'; database = '" + database + "';";
            conn.ConnectionString = string_conexiune;
            try
            {
                conn.Open();
                Meniu_principal principal = new Meniu_principal();
                MessageBox.Show("Connected successfully!");
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private void bConFcon_Click(object sender, EventArgs e)
        {
            Meniu_principal principal = new Meniu_principal();
            string server, database, user, password;
            server = t1Fcon.Text;
            database = t4Fcon.Text;
            password = t3Fcon.Text;
            user = t2Fcon.Text;

            if (Conexiune_db(server, user, password, database))
            {
                //Creare fisier
                if (!File.Exists(db_info))
                {
                    File.Create(db_info);
                    File.WriteAllLines(db_info, [server,user,password,database]);
                }
                else
                {
                    File.WriteAllLines(db_info, [server,user,password,database]);
                }
                /////////////////
                this.Close();
                principal.Show();
            }
            else { }

        }

        private void Fconectare_Load(object sender, EventArgs e)
        {

        }

        private void TSInfo1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Fill in the blanks recording to descriptions in order to make a connection", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void TSHelp1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Server -> the server to connect to (if you want to simulate on your PC type 'localhost'\nID -> the user that connects (for localhost type 'root')\nPassword -> Password of your database (by default it's null)\nName of database -> your database name (ex. 'database1')", "Help", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
    }
}
