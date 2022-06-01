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
    public partial class frmYenibölümEkle : Form
    {
        public frmYenibölümEkle()
        {
            InitializeComponent();
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        MySqlConnection connection = new MySqlConnection(@"Server=172.21.54.3; uid=yazilim16; pwd=Yazılım.16;database=yazilim16");
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (Sorgulama.KontrolEt("BolumAdi", "Bölüm", "Durum", txtad.Text))
                {
                    //aynı ise
                    MessageBox.Show("Girdiğiniz bölüm adı ile eşdeğer başka bir bölüm vardır.\nLütfen tekrar deneyiniz.");
                }
                else
                {
                    // aynı değil ise
                    connection.Open();
                    connection.Close();
                    connection.Open();
                    MySqlCommand command = new MySqlCommand("insert into Bölüm (BolumAdi,Durum) values (@p1,1)", connection);
                    command.Parameters.AddWithValue("@p1", txtad.Text);
                    command.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("Yeni Bölüm Eklenmiştir", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Hatalı İşlem !!!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                connection.Close();
            }
        }
    }
}
