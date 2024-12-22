using IronPython.Hosting;
using Microsoft.Scripting.Hosting;

namespace MIPATemp
{
    public partial class Meniu_principal : Form
    {
        //VARIABILE SI INSTANTE
        Fconectare input_db = new Fconectare();
        public bool conectat = false;
        public readonly string adresa_script = AppDomain.CurrentDomain.BaseDirectory + "/script.py"; // adresa script python
        private string adresa_conectare = "";
        private string[] db_data = { "", "", "", "" };
        private bool selectat = false;
        MySqlConnection conn = new MySqlConnection();
        ///
        public Meniu_principal()
        {
            InitializeComponent();
            continut_bd.Hide(); 
        }
        public string string_conectare(string server, string user, string password, string database) //functie de creare string conectare
        {
            return @"host = '" + server + "'; port = '3306';" + " user = '" + user + "'; password = '" + password + "'; database = '" + database + "';";
        }
        void citire_fisier(string adresa_fisier)
        {
            db_data = File.ReadAllLines(input_db.db_file);
        }

        void Conexiune(string buton)
        {
        try
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            else
            {
                conn.ConnectionString = adresa_conectare;
                conn.Open();

                if (buton != "bNou")
                {
                    string query;
                    query = "SHOW TABLES";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable data = new DataTable();
                    adapter.Fill(data);

                    continut_bd.DataSource = data;
                }
                else //PARTE SCRIPT 
                {
                        /*ScriptEngine engine = Python.CreateEngine();
                        if(File.Exists(adresa_script))
                        {
                            ScriptScope scope = engine.CreateScope();
                            engine.ExecuteFile(adresa_script, scope);
                            dynamic rezultat = scope.GetVariable("rezultat");
                            Console.WriteLine(rezultat);
                        }
                        else
                        {
                            Console.WriteLine("Eroare: Nu exista fisier");
                        }*/
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }

        void Selectat(string buton)
        {
            if (!selectat)
            {
                selectat = true;
                if(buton!="bNou") { continut_bd.Show(); }
                switch (buton)
                {
                    case "bNou":
                        bGE.Enabled = false;
                        bSE.Enabled = false;
                        break;
                    case "bGE":
                        bNou.Enabled = false;
                        bSE.Enabled = false;
                        break;
                    case "bSE":
                        bNou.Enabled = false;
                        bGE.Enabled = false;
                        break;
                }
            }
            else {
                continut_bd.Hide();
                selectat = false;
                bNou.Enabled = true;
                bGE.Enabled = true;
                bSE.Enabled = true;
            }
        }

        private void bNou_Click(object sender, EventArgs e) //BUTON GRAFIC NOU
        {
            if (adresa_conectare != "")
            {
                Conexiune("bNou");
                Selectat(bNou.Name.ToString());
            }
            else MessageBox.Show("You need to connect to a database first", "New Graph", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void bSE_Click(object sender, EventArgs e) // BUTON STERGERE GRAFIC
        {
            if (adresa_conectare != "")
            {
                Conexiune("bSE");
                Selectat(bSE.Name.ToString());
            }
            else MessageBox.Show("You need to connect to a database first", "Delete Graph", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void bGE_Click(object sender, EventArgs e) // BUTON GRAFIC EXISTENT
        {
            if (adresa_conectare != "")
            {
                Conexiune("bGE");
                Selectat(bGE.Name.ToString());
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
           if(selectat)
           {
                DialogResult result = MessageBox.Show("If you close the application your work will not be saved!\nClose?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    Application.Exit();
                }
           }
           else
           {
                Application.Exit();
           }
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
