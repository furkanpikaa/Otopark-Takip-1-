namespace Otopark_Takip
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            frmAraçOtoparkKaydý kayit = new  frmAraçOtoparkKaydý();
            kayit.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmAraçOtoparkYerleri yer = new frmAraçOtoparkYerleri();
            yer.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmAraçOtoparkÇýkýþý çýkýþ = new frmAraçOtoparkÇýkýþý();
            çýkýþ.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult sonuc;
            sonuc = MessageBox.Show("Çýkýþ yapmak istediðinize emin misiniz?","Çýkýþ", MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
            if (sonuc== DialogResult.No)
            {

            }
            if (sonuc == DialogResult.Yes)
            {
                this.Close();
                Application.Exit();
            }

        }
        int Move;
        int Mouse_X;
        int Mouse_Y;

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            Move = 0;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            Move = 1;
            Mouse_X = e.X;
            Mouse_Y = e.Y;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (Move == 1)
            {
                this.SetDesktopLocation(MousePosition.X - Mouse_X, MousePosition.Y - Mouse_Y);
            }
        }
    }
}