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
    public partial class frmYeniogrenciEkle : Form
    {
        public frmYeniogrenciEkle()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        MySqlConnection connection = new MySqlConnection(@"Server=172.21.54.3; uid=yazilim16; pwd=Yazılım.16;database=yazilim16");
        List<Bölüm> bölüms = new List<Bölüm>();
        public class Bölüm
        {
            public string BölümAdi { get; set; }
            public int id { get; set; }

            public Bölüm(int id, string bölümAdi)
            {
                this.id = id;
                this.BölümAdi = bölümAdi;
            }
        }
        private void frmYeniogrenciEkle_Load(object sender, EventArgs e)
        {
            try
            {
                // lookupedite kategori ekleme 
                connection.Open();
                MySqlCommand command1 = new MySqlCommand("select * from Bölüm where durum=1", connection);
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command1);
                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    bölüms.Add(new Bölüm(dt.Rows[i].Field<int>("id"), dt.Rows[i].Field<string>("BolumAdi")));
                }
                lkpdtBolum.Properties.DataSource = bölüms;
                lkpdtBolum.Properties.DisplayMember = "BölümAdi";
                lkpdtBolum.Properties.ValueMember = "id";
                connection.Close();
            }
            catch (Exception)
            {
                return;
            }

        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                int emanet = 0, durum = 1;
                string cinsiyet = "Erkek";
                if (rdKadın.Checked == true)
                {
                    cinsiyet = "Kadın";
                }
                else if (rdErkek.Checked == true)
                {
                    cinsiyet = "Erkek";
                }
                connection.Open();
                MySqlCommand command = new MySqlCommand("insert into Ogrenci (OkulNo,OgrenciAdi,OgrenciSoyadi,OgrenciTelefon,OgrenciEposta,KartId,BolumId,Cinsiyet,EmanetAdeti,OgrenciŞifre,OgrenciDurum) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11)", connection);
                command.Parameters.AddWithValue("@p1", txtOkulNo.Text);
                command.Parameters.AddWithValue("@p2", txtOgrAd.Text);
                command.Parameters.AddWithValue("@p3", txtOgrSoyad.Text);
                command.Parameters.AddWithValue("@p4", txtOgrTel.Text);
                command.Parameters.AddWithValue("@p5", txtOgrEposta.Text);
                command.Parameters.AddWithValue("@p6", txtOgrKartId.Text);
                command.Parameters.AddWithValue("@p7", lkpdtBolum.EditValue);
                command.Parameters.AddWithValue("@p8", cinsiyet);
                command.Parameters.AddWithValue("@p9", emanet);
                command.Parameters.AddWithValue("@p10", txtOgrSifre.Text);
                command.Parameters.AddWithValue("@p11", durum);
                command.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Öğrenci Ekleme İşlemi Gerçekleşmiştir");
            }
            catch (Exception)
            {
                MessageBox.Show("Hatalı Ekleme İşlemi !!!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
