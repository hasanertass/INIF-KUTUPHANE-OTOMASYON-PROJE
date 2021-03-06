using DevExpress.XtraGrid.Views.Grid;
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
    public partial class frmEmanetListesi : Form
    {
        public frmEmanetListesi()
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
        private void frmEmanetListesi_Load(object sender, EventArgs e)
        {
            try
            {
                //gridcontrolde veri listeleme
                connection.Open();
                MySqlCommand command = new MySqlCommand("SELECT Odünç.Barkod,Kitap.KitapAdi,Kitap.SayfaSayisi,Kitap.YayinEvi,Kategori.KategoriAdi,Concat(Yazar.YazarAdi,' ',Yazar.YazarSoyadi) as Yazar,Concat(Cevirmen.CevirmenAdi,' ',Cevirmen.CevirmenSoyadi) as Cevirmen,Ogrenci.OkulNo,Concat(Ogrenci.OgrenciAdi,' ',Ogrenci.OgrenciSoyadi) AS Ogrenci,Odünç.AlisTarihi,Odünç.TeslimTarihi,Odünç.OduncDurum FROM Odünç INNER JOIN Kitap on Kitap.Barkod=Odünç.Barkod INNER JOIN Kategori ON Kategori.id=Kitap.Kategori INNER JOIN Yazar ON Yazar.id=Kitap.Yazar INNER JOIN Cevirmen on Cevirmen.id=Kitap.Cevirmen INNER JOIN Ogrenci ON Ogrenci.KartId=Odünç.KartId", connection);
                MySqlDataAdapter da = new MySqlDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gridControl1.DataSource = dt;
            }
            catch (Exception)
            {
                return;
            }
        }
    }
}
