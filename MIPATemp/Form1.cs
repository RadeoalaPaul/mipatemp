using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using System.Diagnostics;
using ScottPlot;
using K4os.Compression.LZ4.Streams.Adapters;

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
        private bool afisat = false;
        private bool salvat = false;
        MySqlConnection conn = new MySqlConnection();
        ///
        public Meniu_principal()
        {
            InitializeComponent();
            continut_bd.Hide();
            gfTemperatura.Hide();
            gfUmiditate.Hide();
            TSSave.Visible = false; //de adaugat
        }
        public string string_conectare(string server, string user, string password, string database) //functie de creare string conectare
        {
            return @"host = '" + server + "'; port = '3306';" + " user = '" + user + "'; password = '" + password + "'; database = '" + database + "';";
        }
        void citire_fisierDB(string adresa_fisier) //CITIRE DATE INPUT BAZA DE DATE 
        {
            db_data = File.ReadAllLines(input_db.db_file);
        }
        void afisare_grafica() //AFISARE GRAFICE SI SCRIERE IN FISIERE
        {
            if (afisat)
            {
                afisat = false;
                gfTemperatura.Hide();
                gfUmiditate.Hide();
                TSSave.Visible = false; //de adaugat
            }
            else
            {
                gfTemperatura.Show();
                gfUmiditate.Show();

                gfTemperatura.Plot.Clear();
                gfUmiditate.Plot.Clear();

                List<float> temperatura = new List<float>();
                List<float> umiditate = new List<float>();
                List<float> timp = new List<float>();

                foreach (var line in File.ReadLines(AppDomain.CurrentDomain.BaseDirectory + "/temperatura.in")) //SCRIERE FISIER
                {
                    if (float.TryParse(line, out float val))
                    {
                        temperatura.Add(val);
                    }
                }
                foreach (var line in File.ReadLines(AppDomain.CurrentDomain.BaseDirectory + "/umiditate.in")) //SCRIERE FISIER
                {
                    if (float.TryParse(line, out float val))
                    {
                        umiditate.Add(val);
                    }
                }
                Console.Clear();
                Console.WriteLine("Timp");
                for (int i = 0; i < temperatura.Count; i++)
                {
                    timp.Add(2 * i);
                    Console.WriteLine(2 * i);
                }
                Console.WriteLine("Temperatura");
                for (int i = 0; i < temperatura.Count; i++)
                {
                    Console.WriteLine(temperatura[i]);
                }
                Console.WriteLine("Umiditate");
                for (int i = 0; i < temperatura.Count; i++)
                {
                    Console.WriteLine(umiditate[i]);
                }

                gfTemperatura.Plot.Add.Scatter(timp, temperatura);
                gfUmiditate.Plot.Add.Scatter(timp, umiditate);
                afisat = true;
                if (adresa_conectare != "") // de adaugat
                {
                    TSSave.Visible = true;
                }
            }
        }
        void prelucrare_python() //PORNIRE SCRIPT PYTHON SI PRELUCRARI
            {
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = @"C:\Users\Mucea\AppData\Local\Programs\Python\Python313\python.exe",
                Arguments = @"C:\Users\Mucea\AppData\Local\Programs\Python\Python313\script\script.py",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };
            using (Process process = new Process { StartInfo = startInfo })
            {
                process.Start();

                string error = process.StandardError.ReadToEnd();

                process.WaitForExit();

                if (!string.IsNullOrEmpty(error))
                {
                    MessageBox.Show("Connect the arduino to your PC!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Selectat("bNou");
                }
                else
                {
                    afisare_grafica();
                }
            }
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
                    if (buton != "bNou")
                    {
                        conn.ConnectionString = adresa_conectare;
                        conn.Open();
                        MySqlDataAdapter adapter = new MySqlDataAdapter("SHOW TABLES", conn);
                        DataTable data = new DataTable();
                        adapter.Fill(data);
                        continut_bd.DataSource = data;
                        continut_bd.Show();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        void Selectat(string denumire_buton) //FUNCTIE SELECTIE/DESELECTIE
        {
            if (!selectat)
            {
                selectat = true;
                foreach (Control control in this.Controls)
                {
                    if (control is Button button)
                    {
                        if (button.Name != denumire_buton && button.Name != "bIesire" && button.Name != "bConectare")
                        {
                            button.Enabled = false;
                        }
                    }
                }
            }
            else
            {
                selectat = false;
                foreach (Control control in this.Controls)
                {
                    if (control is Button button)
                    {
                        if (button.Name != denumire_buton && button.Name != "bIesire" && button.Name != "bConectare")
                        {
                            if (button.Name == "bSE" || button.Name == "bGE")
                            {
                                continut_bd.Hide();
                            }
                            button.Enabled = true;
                        }
                    }
                }
            }
        }
        private void bNou_Click(object sender, EventArgs e) //BUTON GRAFIC NOU
        {
            if (!selectat)
            {
                Selectat("bNou");
                prelucrare_python();
            }
            else
            {
                if (!salvat)
                {
                    DialogResult raspuns = MessageBox.Show("If you click yes, you will lose this graph by not saving it!", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (raspuns == DialogResult.Yes)
                    {
                        Selectat("bNou");
                        afisare_grafica();
                    }
                }
                else
                {
                    salvat = false;
                    Selectat("bNou");
                    afisare_grafica();
                }
            }
        }
        private void bSE_Click(object sender, EventArgs e) // BUTON STERGERE GRAFIC
        {
            if (adresa_conectare != "")
            {
                Selectat("bSE");
                Conexiune("bSE");
            }
            else MessageBox.Show("You need to connect to a database first", "Delete Graph", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void bGE_Click(object sender, EventArgs e) // BUTON GRAFIC EXISTENT
        {
            if (adresa_conectare != "")
            {
                Selectat("bGE");
                Conexiune("bGE");
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
            if (selectat)
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
        private void Meniu_principal_Shown(object sender, EventArgs e) //CAND ESTE AFISAT MENIUL PRINCIPAL
        {
            if (conectat)
            {
                bConectare.Hide();
                citire_fisierDB(input_db.db_file);
                adresa_conectare = string_conectare(db_data[0], db_data[1], db_data[2], db_data[3]);
            }
        }
        void salvare_grafic() //FUNCTIE SALVARE GRAFIC
        {
            //citire fisiere
            float result;
            int c = 0;
            List<float> temperaturi = new List<float>();
            List<float> umiditati = new List<float>();
            List<int> timp = new List<int>();
            foreach (string line in File.ReadLines(AppDomain.CurrentDomain.BaseDirectory + "/temperatura.in"))
            {
                result = float.Parse(line);
                temperaturi.Add(result);
                timp.Add(c*2);
                c++;
            }
            foreach (string line in File.ReadLines(AppDomain.CurrentDomain.BaseDirectory + "/umiditate.in"))
            {
                result = float.Parse(line);
                umiditati.Add(result);
            }
            //creare tabel
            //denumire
            DateTime time = DateTime.Now;
            string time_string = time.ToString("ddMMHHmmss");
            Console.WriteLine(time_string);
            //////////
            MySqlCommand comanda_creare = new MySqlCommand("CREATE TABLE grafic" + time_string + " (X FLOAT, Yt FLOAT, Yu FLOAT);", conn);
            comanda_creare.ExecuteNonQuery();
            Console.Clear();
            Console.WriteLine("Salvat!");
            //scriere tabel
            for(int i = 0; i < timp.Count; i++)
            {
                using(MySqlCommand comanda_scriere = new MySqlCommand("INSERT INTO grafic" + time_string + " (X,Yt,Yu) VALUES (@X,@Yt,@Yu);",conn))
                {
                    comanda_scriere.Parameters.AddWithValue("@X", timp[i]);
                    comanda_scriere.Parameters.AddWithValue("@Yt", temperaturi[i]);
                    comanda_scriere.Parameters.AddWithValue("@Yu", umiditati[i]);

                    comanda_scriere.ExecuteNonQuery();
                }
            }
            conn.Close();
        }
        private void TSSave_Click(object sender, EventArgs e) //de adaugat
        {
            conn.ConnectionString = adresa_conectare;
            conn.Open();
            salvare_grafic();
            conn.Close();

            salvat = true;
        }
    }
}
