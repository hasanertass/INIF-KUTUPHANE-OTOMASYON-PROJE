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
    public partial class frmyenikitap : Form
    {
        public frmyenikitap()
        {
            InitializeComponent();
        }

        private void textEdit10_EditValueChanged(object sender, EventArgs e)
        {

        }
        public class kategori
        {
            public string KategoriAdi { get; set; }
            public int KategoriId { get; set; }

            public kategori(int kategoriId, string kategoriAdi)
            {
                this.KategoriId = kategoriId;
                this.KategoriAdi = kategoriAdi;
            }
        }
        public class cevirmen
        {
            public string AdSoyad { get; set; }
            public int id { get; set; }


            public cevirmen(int id, string adSoyad)
            {
                this.id = id;
                this.AdSoyad = adSoyad;
            }
        }
        public class yazar
        {
            public string AdSoyad { get; set; }
            public int id { get; set; }


            public yazar(int id, string adSoyad)
            {
                this.id = id;
                this.AdSoyad = adSoyad;
            }
        }
        List<kategori> kategoris = new List<kategori>();
        List<cevirmen> cevirmens = new List<cevirmen>();
        List<yazar> yazars = new List<yazar>();
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        MySqlConnection connection = new MySqlConnection(@"Server=172.21.54.3; uid=yazilim16; pwd=Yazılım.16;database=yazilim16");
        int durum = 0, durum2 = 0;

        private void frmyenikitap_Load(object sender, EventArgs e)
        {
            connection.Open();
            // lookupedite kategori ekleme 
            MySqlCommand command1 = new MySqlCommand("select * from Kategori", connection);
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command1);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                kategoris.Add(new kategori(dt.Rows[i].Field<int>("id"), dt.Rows[i].Field<string>("KategoriAdi")));
            }
            lkpdtKategori.Properties.DataSource = kategoris;
            lkpdtKategori.Properties.DisplayMember = "KategoriAdi";
            lkpdtKategori.Properties.ValueMember = "KategoriId";
            //lkpdtKategori.Properties.Columns[1].Visible = false;


            // lookupedite cevirmen ekleme 
            MySqlCommand command2 = new MySqlCommand("SELECT id,CONCAT(CevirmenAdi ,' ',CevirmenSoyadi) AS AdSoyad FROM Cevirmen", connection);
            MySqlDataAdapter dataAdapter1 = new MySqlDataAdapter(command2);
            dt = new DataTable();
            dataAdapter1.Fill(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cevirmens.Add(new cevirmen(dt.Rows[i].Field<int>("id"), dt.Rows[i].Field<string>("AdSoyad")));
            }
            lkpdtCevirmen.Properties.DataSource = cevirmens;
            lkpdtCevirmen.Properties.DisplayMember = "AdSoyad";
            lkpdtCevirmen.Properties.ValueMember = "id";

            // lookupedite yazar ekleme 
            MySqlCommand command3 = new MySqlCommand("SELECT id,CONCAT(YazarAdi ,' ',YazarSoyadi) AS AdSoyad FROM Yazar", connection);
            MySqlDataAdapter dataAdapter2 = new MySqlDataAdapter(command3);
            dt = new DataTable();
            dataAdapter2.Fill(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                yazars.Add(new yazar(dt.Rows[i].Field<int>("id"), dt.Rows[i].Field<string>("AdSoyad")));
            }
            lkpdtyazar.Properties.DataSource = yazars;
            lkpdtyazar.Properties.DisplayMember = "AdSoyad";
            lkpdtyazar.Properties.ValueMember = "id";
            connection.Close();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                if (rdEmanet.Checked == true)
                {
                    durum = 1;
                }
                if (rdMevcutDegil.Checked == true)
                {
                    durum2 = 1;
                }
                DateTime kayıt = Convert.ToDateTime(dateEdit2.Text);
                connection.Open();
                MySqlCommand komut = new MySqlCommand("insert into Kitap (Barkod, ISBN, KitapAdi, YayinYili, Tur, Kategori, KayitTarihi, Konum, SayfaSayisi, Stok, Cevirmen, Yazar, Baski, Ozet, YayinEvi, Durum, Durum2) VALUES " +
                    "(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13,@p14,@p15,@p16,@p17) ", connection);
                komut.Parameters.AddWithValue("@p1", txtBarkod.Text);
                komut.Parameters.AddWithValue("@p2", txtISBN.Text);
                komut.Parameters.AddWithValue("@p3", txtAd.Text);
                komut.Parameters.AddWithValue("@p4", txtYayinYili.Text);
                komut.Parameters.AddWithValue("@p5", txtTür.Text);
                komut.Parameters.AddWithValue("@p6", lkpdtKategori.EditValue);
                komut.Parameters.AddWithValue("@p7", kayıt.ToString("yyyy-MM-dd"));
                komut.Parameters.AddWithValue("@p8", txtKonum.Text);
                komut.Parameters.AddWithValue("@p9", txtsayfa.Text);
                komut.Parameters.AddWithValue("@p10", txtstok.Text);
                komut.Parameters.AddWithValue("@p11", lkpdtCevirmen.EditValue);
                komut.Parameters.AddWithValue("@p12", lkpdtyazar.EditValue);
                komut.Parameters.AddWithValue("@p13", txtBaski.Text);
                komut.Parameters.AddWithValue("@p14", txtOzet.Text);
                komut.Parameters.AddWithValue("@p15", txtYayinEvi.Text);
                komut.Parameters.AddWithValue("@p16", durum);
                komut.Parameters.AddWithValue("@p17", durum2);
                komut.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Ekleme İşlemi Gerçekleşmiştir");
            }
            catch (Exception)
            {
                MessageBox.Show("Hatalı Ekleme İşlemi !!!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
