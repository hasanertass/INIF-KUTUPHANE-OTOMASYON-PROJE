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
    public partial class FrmKitapListesi : Form
    {
        public FrmKitapListesi()
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
        int durum = 0, durum2 = 0;
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
                komut.Parameters.AddWithValue("@p8", txtkonum.Text);
                komut.Parameters.AddWithValue("@p9", txtsayfa.Text);
                komut.Parameters.AddWithValue("@p10", txtstok.Text);
                komut.Parameters.AddWithValue("@p11", lkpdtCevirmen.EditValue);
                komut.Parameters.AddWithValue("@p12", lkpdtyazar.EditValue);
                komut.Parameters.AddWithValue("@p13", txtBaski.Text);
                komut.Parameters.AddWithValue("@p14", txtOzet.Text);
                komut.Parameters.AddWithValue("@p15", txtYayınEvi.Text);
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
        private void FrmKitapListesi_Load_1(object sender, EventArgs e)
        {
            //gridcontrolde veri listeleme

            gridControl1.DataSource = ListeleTablolari(connection, "SELECT Kitap.id,Kitap.Barkod,Kitap.ISBN,Kitap.KitapAdi,Kitap.YayinYili," +
            " Kitap.Tur, Kategori.KategoriAdi As Kategori, Kitap.KayitTarihi, Kitap.Konum, Kitap.SayfaSayisi, Kitap.Stok, " +
            " CONCAT(Cevirmen.CevirmenAdi,' ', Cevirmen.CevirmenSoyadi) As Cevirmen " +
            " , CONCAT(Yazar.YazarAdi, ' ', Yazar.YazarSoyadi) as Yazar, " +
            " Kitap.Baski, Kitap.Ozet, Kitap.YayinEvi, Kitap.Durum, Kitap.Durum2 " +
            " FROM Kitap INNER JOIN Kategori ON Kitap.Kategori = Kategori.id " +
            " INNER JOIN Cevirmen ON Kitap.Cevirmen = Cevirmen.id " +
            " INNER JOIN Yazar on Kitap.Yazar = Yazar.id");

            //connection.Open();
            //MySqlCommand command = new MySqlCommand("select * from Kitap", connection);
            //MySqlDataAdapter da = new MySqlDataAdapter(command);
            //DataTable dt = new DataTable();
            //da.Fill(dt);
            //gridControl1.DataSource = dt;

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

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            lkpdtKategori.Properties.ValueMember = gridView1.GetFocusedRowCellValue("Kategori").ToString();
            txtKitapid.Text = gridView1.GetFocusedRowCellValue("id").ToString();
            txtBarkod.Text = gridView1.GetFocusedRowCellValue("Barkod").ToString();
            txtISBN.Text = gridView1.GetFocusedRowCellValue("ISBN").ToString();
            txtAd.Text = gridView1.GetFocusedRowCellValue("KitapAdi").ToString();
            txtYayinYili.Text = gridView1.GetFocusedRowCellValue("YayinYili").ToString();
            txtTür.Text = gridView1.GetFocusedRowCellValue("Tur").ToString();
            txtkonum.Text = gridView1.GetFocusedRowCellValue("Konum").ToString();
            txtsayfa.Text = gridView1.GetFocusedRowCellValue("SayfaSayisi").ToString();
            txtstok.Text = gridView1.GetFocusedRowCellValue("Stok").ToString();
            lkpdtCevirmen.Properties.ValueMember = gridView1.GetFocusedRowCellValue("Cevirmen").ToString();
            lkpdtyazar.Properties.ValueMember = gridView1.GetFocusedRowCellValue("Yazar").ToString();
            txtBaski.Text = gridView1.GetFocusedRowCellValue("Baski").ToString();
            txtOzet.Text = gridView1.GetFocusedRowCellValue("Ozet").ToString();
            txtYayınEvi.Text = gridView1.GetFocusedRowCellValue("YayinEvi").ToString();
            dateEdit2.Text = gridView1.GetFocusedRowCellValue("KayitTarihi").ToString();
            if (gridView1.GetFocusedRowCellValue("Durum").ToString() == "True")
            {
                rdZimmet.Checked = true;
            }
            else
            {
                rdEmanet.Checked = true;
            }
            if (gridView1.GetFocusedRowCellValue("Durum2").ToString() == "True")
            {
                rdMevcut.Checked = true;
            }
            else
            {
                rdMevcutDegil.Checked = true;
            }
        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            //try
            //{
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
            MySqlCommand command = new MySqlCommand("UPDATE Kitap SET Barkod=@u1,ISBN=@u2,KitapAdi=@u3,YayinYili=@u4,Tur=@u5,Kategori=@u6,KayitTarihi=@u7,Konum=@u8,SayfaSayisi=@u9,Stok=@u10,Cevirmen=@u11,Yazar=@u12,Baski=@u13,Ozet=@u14,YayinEvi=@u15,Durum=@u16,Durum2=@u17 WHERE id=@u18", connection);
            command.Parameters.AddWithValue("@u1", txtBarkod.Text);
            command.Parameters.AddWithValue("@u2", txtISBN.Text);
            command.Parameters.AddWithValue("@u3", txtAd.Text);
            command.Parameters.AddWithValue("@u4", txtYayinYili.Text);
            command.Parameters.AddWithValue("@u5", txtTür.Text);
            command.Parameters.AddWithValue("@u6", lkpdtKategori.EditValue);
            command.Parameters.AddWithValue("@u7", kayıt.ToString("yyyy-MM-dd"));
            command.Parameters.AddWithValue("@u8", txtkonum.Text);
            command.Parameters.AddWithValue("@u9", txtsayfa.Text);
            command.Parameters.AddWithValue("@u10", txtstok.Text);
            command.Parameters.AddWithValue("@u11", lkpdtCevirmen.EditValue);
            command.Parameters.AddWithValue("@u12", lkpdtyazar.EditValue);
            command.Parameters.AddWithValue("@u13", txtBaski.Text);
            command.Parameters.AddWithValue("@u14", txtOzet.Text);
            command.Parameters.AddWithValue("@u15", txtYayınEvi.Text);
            command.Parameters.AddWithValue("@u16", durum);
            command.Parameters.AddWithValue("@u17", durum2);
            command.Parameters.AddWithValue("@u18", txtKitapid.Text);
            command.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Güncelleme İşlemi Gerçekleşmiştir");
            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("Hatalı İşlem !!!","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
            //}

        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            // List();
            gridControl1.DataSource = ListeleTablolari(connection, "SELECT Kitap.id,Kitap.Barkod,Kitap.ISBN,Kitap.KitapAdi,Kitap.YayinYili," +
            " Kitap.Tur, Kategori.KategoriAdi As Kategori, Kitap.KayitTarihi, Kitap.Konum, Kitap.SayfaSayisi, Kitap.Stok, " +
            " CONCAT(Cevirmen.CevirmenAdi,' ', Cevirmen.CevirmenSoyadi) As Cevirmen " +
            " , CONCAT(Yazar.YazarAdi, ' ', Yazar.YazarSoyadi) as Yazar, " +
            " Kitap.Baski, Kitap.Ozet, Kitap.YayinEvi, Kitap.Durum, Kitap.Durum2 " +
            " FROM Kitap INNER JOIN Kategori ON Kitap.Kategori = Kategori.id " +
            " INNER JOIN Cevirmen ON Kitap.Cevirmen = Cevirmen.id " +
            " INNER JOIN Yazar on Kitap.Yazar = Yazar.id");
        }

        private void List()
        {
            //gridcontrolde veri listeleme
            connection.Open();
            MySqlCommand command = new MySqlCommand("select * from Kitap", connection);
            MySqlDataAdapter da = new MySqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;
            connection.Close();
        }

        /// <summary>
        /// Verilen Connetcion ve sorguyu datatable olarak döndürür
        /// </summary>
        /// <param name="con">bağlantıyı verin</param>
        /// <param name="sorgu">select sorgunuzu gönderin</param>
        /// <returns></returns>
        public DataTable ListeleTablolari(MySqlConnection con, string sorgu)
        {
            con.Open();
            MySqlCommand command = new MySqlCommand(sorgu, con);
            MySqlDataAdapter da = new MySqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                MySqlCommand komut = new MySqlCommand("Update Kitap set Durum2=0,Durum=0 where id=@p1", connection);
                komut.Parameters.AddWithValue("@p1", txtKitapid.Text);
                komut.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Silme İŞlemi Gerçekleşmiştir");
            }
            catch (Exception)
            {
                MessageBox.Show("Hatalı İşlem !!!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
