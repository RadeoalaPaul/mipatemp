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
        
        public readonly string db_info = @"D:\facultate\proiectSAIV\MIPATemp\bd_info.txt";

        bool Conexiune_db(string server, string user, string password, string database)
        {
            MySqlConnection conn = new MySqlConnection();
            string string_conexiune = @"host = '" + server + "'; port = '3306';" + " password = '" + password + "'; user = '" + user + "'; database = '" + database + "';";
            Conexiune conexiune = new Conexiune(string_conexiune);
            conn.ConnectionString = conexiune.string_conexiune;
            try
            {
                conn.Open();
                Meniu_principal principal = new Meniu_principal();
                MessageBox.Show("Conexiune reusita!");
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
            //Creare fisier
            if (!File.Exists(db_info))
            {
                File.Create(db_info);
                MessageBox.Show("A fost creat un fisier in ", db_info);
            }
            else
            {
                MessageBox.Show("Fisierul a fost modificat la adresa ", db_info);
            }
            /////////////////
            if (Conexiune_db(server,user,password,database)) { this.Close(); principal.Show(); }
            else { }

        }

        private void Fconectare_Load(object sender, EventArgs e)
        {

        }
    }
}
