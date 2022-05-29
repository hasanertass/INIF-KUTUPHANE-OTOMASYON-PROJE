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
    public partial class frmYeniKategoriEkle : Form
    {
        public frmYeniKategoriEkle()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        MySqlConnection connection = new MySqlConnection(@"Server=172.21.54.3; uid=yazilim16; pwd=Yazılım.16;database=yazilim16");

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (Sorgulama.KontrolEt("KategoriAdi", "Kategori", "Durum", txtKtgriAd.Text))
                {
                    // aynı ise 
                    MessageBox.Show("Girdiğiniz Kategori adı ile eşdeğer başka bir bölüm vardır.\nLütfen tekrar deneyiniz.");
                }
                else
                {
                    int durum = 1;
                    connection.Open();
                    MySqlCommand command = new MySqlCommand("insert into Kategori (KategoriAdi,Durum) values (@p1,@p2)", connection);
                    command.Parameters.AddWithValue("@p1", txtKtgriAd.Text);
                    command.Parameters.AddWithValue("@p2", durum); ;
                    command.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("Kategori Kaydedilmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
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

        private void labelControl3_Click(object sender, EventArgs e)
        {

        }
    }
}
