using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Otopark_Takip
{
    public partial class frmAraçOtoparkKaydı : Form
    {
        public frmAraçOtoparkKaydı()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=PIKAA\\SQLEXPRESS;Initial Catalog=araç_otopark;Integrated Security=True");
        private void frmAraçOtoparkKaydı_Load(object sender, EventArgs e)
        {
            BoşAraçlar();
            Marka();
            
        }

        

        private void Marka()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select marka from markabilgileri", baglanti);
            SqlDataReader read = komut.ExecuteReader();

            while (read.Read())
            {
                cbxMarka.Items.Add(read["marka"].ToString());
            }
            baglanti.Close();
        }

        private void BoşAraçlar()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select *from araçdurumu WHERE durumu='Boş'", baglanti);
            SqlDataReader read = komut.ExecuteReader();

            while (read.Read())
            {
                cbxParkyeri.Items.Add(read["parkyeri"].ToString());
            }
            baglanti.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into araç_otopark_kaydı(tc,ad,soyad,telefon,email,plaka,marka,seri,renk,parkyeri,tarih) values(@tc,@ad,@soyad,@telefon,@email,@plaka,@marka,@seri,@renk,@parkyeri,@tarih)", baglanti);
            komut.Parameters.AddWithValue("@tc",txtTc.Text);
            komut.Parameters.AddWithValue("@ad", txtAd.Text);
            komut.Parameters.AddWithValue("@soyad", txtsoyad.Text);
            komut.Parameters.AddWithValue("@telefon", txtTelefon.Text);
            komut.Parameters.AddWithValue("@email", txtEmail.Text);
            komut.Parameters.AddWithValue("@plaka", txtPlaka.Text);
            komut.Parameters.AddWithValue("@marka", cbxMarka.Text);
            komut.Parameters.AddWithValue("@seri", cbxSeri.Text);
            komut.Parameters.AddWithValue("@renk", txtRenk.Text);
            komut.Parameters.AddWithValue("@parkyeri", cbxParkyeri.Text);
            komut.Parameters.AddWithValue("@tarih", DateTime.Now.ToString());

            komut.ExecuteNonQuery();


            SqlCommand komut2 = new SqlCommand("update araçdurumu set durumu='Dolu' WHERE parkyeri='"+cbxParkyeri.SelectedItem+"'",baglanti);
            komut2.ExecuteNonQuery();

            baglanti.Close();
            MessageBox.Show("Araç Kaydı Oluşturuldu.","Kayıt");
            cbxParkyeri.Items.Clear();
            BoşAraçlar();
            cbxMarka.Items.Clear();
            Marka();
            cbxSeri.Items.Clear();
            

            foreach (Control item in grupKişi.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
            }
            foreach (Control item in grupAraç.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
            }
            foreach (Control item in grupAraç.Controls)
            {
                if (item is ComboBox)
                {
                    item.Text = "";
                }
            }

        }

        private void btnMarka_Click(object sender, EventArgs e)
        {
            frmMarka marka = new frmMarka();
            marka.ShowDialog();
        }

        private void btnSeri_Click(object sender, EventArgs e)
        {
            frmSeri seri = new frmSeri();
            seri.ShowDialog();
        }

        private void cbxMarka_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbxSeri.Items.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select marka,seri from seribilgileri where marka='"+cbxMarka.SelectedItem+"'", baglanti);
            SqlDataReader read = komut.ExecuteReader();

            while (read.Read())
            {
                cbxSeri.Items.Add(read["seri"].ToString());
            }
            baglanti.Close();

        }
    }
}
