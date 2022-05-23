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
    public partial class frmLoginForm : Form
    {
        public frmLoginForm()
        {
            InitializeComponent();
        }
        private void pctPersonel_Click_1(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }
        MySqlConnection connection = new MySqlConnection(@"Server=172.21.54.3; uid=yazilim16; pwd=Yazılım.16;database=yazilim16");
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://uludag.edu.tr/inif");
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (txtKullaniciAdi.Text.Length==11)
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand("select * from Personel where PersonelTc=@p1 and Sifre=@p2", connection);
                command.Parameters.AddWithValue("@p1", txtKullaniciAdi.Text);
                command.Parameters.AddWithValue("@p2", txtSifre.Text);
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    Form1 fr = new Form1();
                    fr.Show();
                    this.Hide();
                }
                else
                {
                    label3.Visible = true;
                }
                //else
                //{
                //    MessageBox.Show("Hatalı Kullanıcı Adı yada Şifre\n Lütfen Kontrol Edip Tekrar Deneyin", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //}
                //connection.Close();
            }
            if (txtKullaniciAdi.Text.Length==9)
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand("select * from Ogrenci where OkulNo=@p1 and OgrenciSifre=@p2", connection);
                command.Parameters.AddWithValue("@p1", txtKullaniciAdi.Text);
                command.Parameters.AddWithValue("@p2", txtSifre.Text);
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    Formlar.Ogrenci.frmOgrenciEkrani fr = new Formlar.Ogrenci.frmOgrenciEkrani();
                    fr.tc = txtKullaniciAdi.Text;
                    fr.sifre = txtSifre.Text;
                    fr.Show();
                    this.Hide();
                }
                else
                {
                    label3.Visible = true;
                }
                connection.Close();
            }
            else
            {
                label3.Visible = true;
            }
            
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmLoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
