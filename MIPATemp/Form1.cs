namespace MIPATemp
{
    public partial class Meniu_principal : Form
    {
        Fconectare input_db = new Fconectare();

        public Meniu_principal()
        {
            InitializeComponent();

        }
        private void bIesire_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bConectare_Click(object sender, EventArgs e)
        {
            this.Hide();
            input_db.Show();
        }

        private void bNou_Click(object sender, EventArgs e)
        {
            
        }
    }
}
