using Microsoft.VisualBasic.ApplicationServices;

namespace MIPATemp
{
    public partial class Meniu_principal : Form
    {
        //VARIABILE SI INSTANTE
        Fconectare input_db = new Fconectare();
        public bool conectat = false;
        private string adresa_conectare = "";
        private string[] db_data = { "", "", "", "" };
        ///
        public Meniu_principal()
        {
            InitializeComponent();
        }
        public string string_conectare(string server, string user, string password, string database) //functie de creare string conectare
        {
            return @"host = '" + server + "'; port = '3306';" + " user = '" + user + "'; password = '" + password + "'; database = '" + database + "';";
        }
        void citire_fisier(string adresa_fisier)
        {
            db_data = File.ReadAllLines(input_db.db_file);
        }

        void Conexiune()
        {

        }
        private void bNou_Click(object sender, EventArgs e) //BUTON GRAFIC NOU
        {
            if (adresa_conectare != "")
            {

            }
            else MessageBox.Show("You need to connect to a database first", "New Graph", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void bSE_Click(object sender, EventArgs e) // BUTON STERGERE GRAFIC
        {
            if (adresa_conectare != "")
            {

            }
            else MessageBox.Show("You need to connect to a database first", "Delete Graph", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void bGE_Click(object sender, EventArgs e) // BUTON GRAFIC EXISTENT
        {
            if (adresa_conectare != "")
            {

            }
            else MessageBox.Show("You need to connect to a database first", "Existent Graph", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void bConectare_Click(object sender, EventArgs e) //BUTON CONECTARE
        {
            this.Hide();
            input_db.Show();
        }
        private void TSInfo_Click(object sender, EventArgs e) //BUTON INFO
        {
            MessageBox.Show("Software for viewing the variation of humidity and temperature in time", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void TSHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Connect to a database first\n1.New Graph -> Create a new Graph to put in database\n2.Delete Existent Graph - Delete a Graph from database\n3.Existent Graph - Choose an Existent Graph from database", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void bIesire_Click(object sender, EventArgs e) //BUTON IESIRE
        {
            Application.Exit();
        }

        private void Meniu_principal_Shown(object sender, EventArgs e)
        {
            //verificam daca suntem conectati
            if (conectat)
            {
                bConectare.Hide();

                citire_fisier(input_db.db_file);
                adresa_conectare = string_conectare(db_data[0], db_data[1], db_data[2], db_data[3]);
            }
        }
    }
}
