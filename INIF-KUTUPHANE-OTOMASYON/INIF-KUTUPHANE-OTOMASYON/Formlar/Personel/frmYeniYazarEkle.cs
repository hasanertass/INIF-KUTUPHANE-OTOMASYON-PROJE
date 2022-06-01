using INIF_KUTUPHANE_OTOMASYON.Formlar.Personel;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace INIF_KUTUPHANE_OTOMASYON.Formlar
{
    public partial class frmYeniYazarEkle : Form
    {
        public frmYeniYazarEkle()
        {
            InitializeComponent();
        }

        private void btnVazgec_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        MySqlConnection connection = new MySqlConnection(@"Server=172.21.54.3; uid=yazilim16; pwd=Yazılım.16;database=yazilim16");
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Sorgulama.KontrolEt("YazarAdi", "Yazar", "Durum", txtYzrAd.Text))
                {
                    // aynı ise
                    MessageBox.Show("Girdiğiniz yazar adı ile eşdeğer başka bir Yazar vardır.\nLütfen tekrar deneyiniz.");
                }
                else
                {
                    //aynı değilse
                    connection.Open();
                    MySqlCommand command = new MySqlCommand("insert into Yazar (YazarAdi,YazarSoyadi,Durum) values (@p1,@p2,1)", connection);
                    command.Parameters.AddWithValue("@p1", txtYzrAd.Text);
                    command.Parameters.AddWithValue("@p2", txtYzrSoyad.Text);
                    command.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("Yeni Yazar Eklenmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Hatalı İşlem !!!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                connection.Close();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
