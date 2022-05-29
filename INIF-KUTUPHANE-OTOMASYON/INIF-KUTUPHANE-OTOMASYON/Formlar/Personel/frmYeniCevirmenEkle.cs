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
    public partial class frmYeniCevirmenEkle : Form
    {
        public frmYeniCevirmenEkle()
        {
            InitializeComponent();
        }
        MySqlConnection connection = new MySqlConnection(@"Server=172.21.54.3; uid=yazilim16; pwd=Yazılım.16;database=yazilim16");
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Sorgulama.KontrolEt("CevirmenAdi", "Cevrimen", "CevirmenDurum", txtCvrmnAd.Text))
                {
                    // aynı ise
                    MessageBox.Show("Girdiğiniz çevirmen adı ile eşdeğer başka bir bölüm vardır.\nLütfen tekrar deneyiniz.");
                }
                else
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand("insert into Cevirmen (CevirmenAdi,CevirmenSoyadi,CevirmenDurum) values (@p1,@p2,1)", connection);
                    command.Parameters.AddWithValue("@p1", txtCvrmnAd.Text);
                    command.Parameters.AddWithValue("@p2", txttxtCvrmnSoyad.Text);
                    command.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("Yeni Çevirmen Eklenmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
    }
}
