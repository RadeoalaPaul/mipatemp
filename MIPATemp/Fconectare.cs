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

        public readonly string db_file = AppDomain.CurrentDomain.BaseDirectory + "/db_info.txt"; //definire adresa fisier
        //public readonly string server, database, user, password;

        bool Conexiune_db(string server, string user, string password, string database)
        {
            MySqlConnection conn = new MySqlConnection();
            Meniu_principal principal = new Meniu_principal();
            conn.ConnectionString = principal.string_conectare(server,user,password,database);
            try
            {
                conn.Open();
                conn.Close();
                MessageBox.Show("Connected successfully!");
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error has occured during the process: " + ex.Message);
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
                //Creare / Modificare fisier
                if (!File.Exists(db_file))
                {
                    File.AppendAllLines(db_file, [server, user, password, database]);
                }
                else
                {
                    File.WriteAllLines(db_file, [server,user,password,database]);
                }
                /////////////////
                this.Hide();
                principal.Show();
                principal.conectat = true;
            }
            else { }

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
