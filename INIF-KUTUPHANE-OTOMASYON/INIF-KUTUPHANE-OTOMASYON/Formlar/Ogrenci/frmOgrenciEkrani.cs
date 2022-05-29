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

namespace INIF_KUTUPHANE_OTOMASYON.Formlar.Ogrenci
{
    public partial class frmOgrenciEkrani : Form
    {
        public frmOgrenciEkrani()
        {
            InitializeComponent();
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        MySqlConnection connection = new MySqlConnection(@"Server=172.21.54.3; uid=yazilim16; pwd=Yazılım.16;database=yazilim16");
        public string tc, sifre, tel;

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            Formlar.Ogrenci.frmOgrenciGüncelle fr = new frmOgrenciGüncelle();
            fr.tel = lblTel.Text;
            fr.sifre = lblSifre.Text;
            fr.id = label9.Text;
            fr.Show();
        }

        private void frmOgrenciEkrani_Load(object sender, EventArgs e)
        {
            connection.Open();
            MySqlCommand command = new MySqlCommand("select * from Ogrenci where OkulNo=@p1", connection);
            command.Parameters.AddWithValue("@p1", tc);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                lblOkulNo.Text = reader[1].ToString();
                lblAd.Text = reader[2].ToString();
                lblSoyad.Text = reader[3].ToString();
                lblTel.Text = reader[4].ToString();
                lblSifre.Text = reader[10].ToString();
                lblEmanet.Text = reader[9].ToString();
                label8.Text = reader[6].ToString();
                label9.Text = reader[0].ToString();
            }
            if (lblEmanet.Text=="0")
            {
                gridControl2.Visible = false;
            }
            connection.Close();
            connection.Open();
            MySqlCommand command1 = new MySqlCommand("SELECT Odünç.Barkod,Kitap.KitapAdi,Kitap.Tur,Kategori.KategoriAdi,Kitap.SayfaSayisi,CONCAT(Yazar.YazarAdi,' ',Yazar.YazarSoyadi) as Yazar,Odünç.AlisTarihi,Odünç.TeslimTarihi FROM Odünç INNER JOIN Kitap on Kitap.Barkod = Odünç.Barkod INNER JOIN Kategori on Kategori.id = Kitap.Kategori INNER JOIN Yazar on Yazar.id = Kitap.Yazar where KartId=@p1 and OduncDurum=1", connection);
            command1.Parameters.AddWithValue("@p1", label8.Text);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command1);
            DataTable table = new DataTable();
            adapter.Fill(table);
            gridControl2.DataSource = table;
            connection.Close();
            
            connection.Open();
            MySqlCommand command2 = new MySqlCommand("SELECT Kitap.Barkod,Kitap.KitapAdi,Kitap.YayinYili,Kitap.Tur,Kategori.KategoriAdi,Kitap.Konum,Kitap.SayfaSayisi,Kitap.Stok,Concat(Cevirmen.CevirmenAdi,'     ',Cevirmen.CevirmenSoyadi) as Çevirmen,Concat(Yazar.YazarAdi,' ',Yazar.YazarSoyadi) AS Yazar ,Kitap.Dil,Kitap.Ozet,Kitap.Durum as 'Emanet Durumu',Kitap.Durum2 as 'Mevcut Durumu' FROM Kitap INNER JOIN Kategori on Kategori.id = Kitap.Kategori inner JOIN Yazar on Yazar.id = Kitap.Yazar INNER JOIN Cevirmen on Cevirmen.id = Kitap.Cevirmen where Kitap.Durum=1 and Kitap.Durum2=1", connection);
            adapter = new MySqlDataAdapter(command2);
            table = new DataTable();
            adapter.Fill(table);
            gridControl1.DataSource = table;
            connection.Close();
            tel = lblTel.Text;
            sifre = lblSifre.Text;

        }
    }
}
