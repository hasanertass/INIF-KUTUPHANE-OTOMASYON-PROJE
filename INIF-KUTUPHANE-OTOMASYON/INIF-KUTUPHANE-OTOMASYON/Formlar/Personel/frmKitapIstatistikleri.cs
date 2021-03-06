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
    public partial class frmKitapIstatistikleri : Form
    {
        public frmKitapIstatistikleri()
        {
            InitializeComponent();
            Rectangle cozunurluk = new Rectangle();
            cozunurluk = Screen.GetBounds(cozunurluk);
            float YWidth = ((float)cozunurluk.Width / (float)1942);
            float YHeight = ((float)cozunurluk.Height / (float)1071);
            SizeF scale = new SizeF(YWidth, YHeight);
            this.Scale(scale);
            foreach (Control control in this.Controls)//panel içindeyse this.Panel1.Controls
            {
                control.Font = new Font("Microsoft Sans Serif", control.Font.SizeInPoints * YHeight * YWidth);
            }
        }
        MySqlConnection connection = new MySqlConnection(@"Server=172.21.54.3; uid=yazilim16; pwd=Yazılım.16;database=yazilim16");
        private void frmKitapIstatistikleri_Load(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand("select Count(*) from Kitap where Durum2=1",connection);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    labelControl1.Text = reader[0].ToString();
                }
                connection.Close();
                connection.Open();
                command = new MySqlCommand("select Sum(Stok) from Kitap where Durum2=1",connection);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    labelControl17.Text = reader[0].ToString();
                }
                connection.Close();
                connection.Open();
                command = new MySqlCommand("select Count(*) from Yazar where Durum=1", connection);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    labelControl4.Text = reader[0].ToString();
                }
                connection.Close();
                connection.Open();
                command = new MySqlCommand("select Count(*) from Odünç where OduncDurum=1", connection);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    labelControl2.Text = reader[0].ToString();
                }
                connection.Close();
                connection.Open(); 
                command = new MySqlCommand("select Kategori.KategoriAdi,COUNT(Kategori) from Odünç INNER JOIN Kitap ON Kitap.Barkod = Odünç.Barkod INNER JOIN Kategori ON Kategori.id = Kitap.Kategori where Durum2 = 1 GROUP by Kategori", connection);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    chart2.Series["Series1"].Points.AddXY(reader[0].ToString(),Convert.ToInt32(reader[1].ToString()));
                }
                connection.Close();
                connection.Open();
                command = new MySqlCommand("SELECT Kategori.KategoriAdi,SUM(Kitap.Stok) from Kitap INNER JOIN Kategori on Kategori.id=Kitap.Kategori GROUP BY Kitap.Kategori", connection);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    chart1.Series["Series1"].Points.AddXY(reader[0].ToString(), Convert.ToInt32(reader[1].ToString()));
                }
                connection.Close();
                connection.Open();
                command = new MySqlCommand("select Kategori.KategoriAdi,COUNT(Kitap.Kategori) from Odünç INNER JOIN Kitap on Kitap.Barkod=Odünç.Barkod INNER JOIN Kategori on Kategori.id=Kitap.Kategori GROUP by Kitap.Kategori ASC",connection);
                reader = command.ExecuteReader();
                if (reader.Read())
                {
                    labelControl6.Text = reader[0].ToString();
                }
                connection.Close();
                connection.Open();
                command = new MySqlCommand("select CONCAT(Yazar.YazarAdi,' ',Yazar.YazarSoyadi) as YazarAdSoyad,COUNT(Kitap.Yazar) from Odünç INNER JOIN Kitap on Kitap.Barkod=Odünç.Barkod INNER JOIN Yazar on Yazar.id=Kitap.Yazar GROUP by Kitap.Yazar ASC", connection);
                reader = command.ExecuteReader();
                if (reader.Read())
                {
                    labelControl15.Text = reader[0].ToString();
                }
                connection.Close();
                connection.Open();
                DateTime ay = DateTime.Now.AddMonths(-1);
                //DateTime date = DateTime.Now;
                command = new MySqlCommand("SELECT Count(OduncId) FROM Odünç where TeslimTarihi>=@p1 and OduncDurum=0",connection);
                command.Parameters.AddWithValue("@p1", ay);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    labelControl18.Text = reader[0].ToString();
                }
                connection.Close();
                connection.Open();
                string date = DateTime.Now.ToString("yyyy-MM-dd");
                command = new MySqlCommand("select Count(OduncId) from Odünç where Teslimtarihi<=@p1 and OduncDurum=1",connection);
                command.Parameters.AddWithValue("@p1", date);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    labelControl12.Text = reader[0].ToString();
                }
                connection.Close();
                connection.Open();
                MySqlCommand command1 = new MySqlCommand("SELECT Concat(Ogrenci.OgrenciAdi,' ',Ogrenci.OgrenciSoyadi) as ad,COUNT(Odünç.OduncId) FROM Odünç INNER JOIN Ogrenci ON Odünç.KartId = Ogrenci.KartId Where Ogrenci.Cinsiyet = 'ERKEK' and OgrenciDurum=1 GROUP BY ad DESC", connection);
                reader = command1.ExecuteReader();
                if (reader.Read())
                {
                    labelControl10.Text = reader[0].ToString();
                }
                connection.Close();
                connection.Open();
                MySqlCommand command2 = new MySqlCommand("SELECT Concat(Ogrenci.OgrenciAdi,' ',Ogrenci.OgrenciSoyadi) as ad,COUNT(Odünç.OduncId) FROM Odünç INNER JOIN Ogrenci ON Odünç.KartId = Ogrenci.KartId Where Ogrenci.Cinsiyet = 'KADIN' and OgrenciDurum=1 GROUP BY ad DESC", connection);
               MySqlDataReader reader2 = command2.ExecuteReader();
                if (reader2.Read())
                {
                    labelControl8.Text = reader2[0].ToString();
                }
                connection.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Hatalı İşlem !!!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                connection.Close();
            }
        }
    }
}
