using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using MySql.Data.MySqlClient;

namespace INIF_KUTUPHANE_OTOMASYON.Formlar
{
    public partial class frmOgrenciIsleri : Form
    {
        public frmOgrenciIsleri()
        {
            InitializeComponent();
        }

        private void ribbonStatusBar1_Click(object sender, EventArgs e)
        {

        }

        MySqlConnection connection = new MySqlConnection(@"Server=172.21.54.3; uid=yazilim16; pwd=Yazılım.16;database=yazilim16");
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // öğrencinin bilgilerini labellara aktarma
            string kart = " ";
            connection.Open();
            MySqlCommand command = new MySqlCommand("SELECT Ogrenci.OkulNo,Ogrenci.OgrenciAdi,Ogrenci.OgrenciSoyadi,Ogrenci.OgrenciTelefon,Ogrenci.OgrenciEposta,Bölüm.BolumAdi,Ogrenci.Cinsiyet,Ogrenci.EmanetAdeti,Ogrenci.KartId FROM Ogrenci INNER JOIN Bölüm on Ogrenci.BolumId=Bölüm.İd where Ogrenci.OkulNo=@p1", connection);
            command.Parameters.AddWithValue("@p1", txtOkulNo.Text);
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                lblOkulno.Text = reader[0].ToString();
                lblAdi.Text = reader[1].ToString();
                lblSoyadi.Text = reader[2].ToString();
                lblTel.Text = reader[3].ToString();
                lblPosta.Text = reader[4].ToString();
                lblBölüm.Text = reader[5].ToString();
                lblCinsiyet.Text = reader[6].ToString();
                lblEmanet.Text = reader[7].ToString();
                kart = reader[8].ToString();

                iTextSharp.text.Document document = new iTextSharp.text.Document();
                PdfWriter.GetInstance(document, new FileStream("C:" + lblOkulno.Text + " " + lblAdi.Text + " " + lblSoyadi.Text + ".Pdf", FileMode.Create));
                iTextSharp.text.Font corbel = iTextSharp.text.FontFactory.GetFont("Arial", 20, color: BaseColor.BLACK);
                iTextSharp.text.pdf.BaseFont STF_Helvetica_Turkish = iTextSharp.text.pdf.BaseFont.CreateFont("Helvetica", "CP1254", iTextSharp.text.pdf.BaseFont.NOT_EMBEDDED);

                iTextSharp.text.Font fontNormal = new iTextSharp.text.Font(STF_Helvetica_Turkish, 18, iTextSharp.text.Font.NORMAL, color: BaseColor.BLACK);
                iTextSharp.text.Font fontNormal1 = new iTextSharp.text.Font(STF_Helvetica_Turkish, 12, iTextSharp.text.Font.NORMAL, color: BaseColor.BLACK);
                document.AddAuthor("İNİF ÖĞRENCİ İŞLERİ");
                document.AddCreationDate();
                document.AddCreator("İNİF ÖĞRENCİ İŞLERİ");
                document.AddSubject("Kütüphane Kitap Durumu");
                document.AddKeywords("Anahtar Kelime");
                if (document.IsOpen() == false)
                {
                    document.Open();
                }
                document.Add(new Paragraph("\n\n\n      Uludağ Üniversitesi Kütüphanesi Öğrenci Bilgileri Dosyası", fontNormal));
                if (lblEmanet.Text == "0")
                {
                    string two = "\n\n\n    " + lblOkulno.Text + " no'lu " + lblAdi.Text + " " + lblSoyadi.Text + " adllı öğrencinin zimmetin de Uludağ Üniversitesi İnegöl İşletme Fakültesi Kütüphanesine ait kitap bulunmamaktadır.";
                    document.Add(new Paragraph(two, fontNormal1));
                }
                else
                {
                    string theree = "\n\n\n    " + lblOkulno.Text + " no'lu " + lblAdi.Text + " " + lblSoyadi.Text + " adlı öğrencinin zimmetin de Uludağ Üniversitesi İnegöl İşletme Fakültesi Kütüphanesine ait toplam " + lblEmanet.Text + " adet kitap bulunmamaktadır. \n Kitap bilgileri aşağıda belirtildiği gibidir;\n\n\n\n\n";
                    document.Add(new Paragraph(theree, fontNormal1));
                    PdfPTable table1 = new PdfPTable(1);
                    PdfPCell cell = new PdfPCell(new Phrase(" -------- Eksik Kitaplar ----------"));
                    cell.HorizontalAlignment = 1; //0=Sola, 1=Orta, 2=sağ
                    table1.AddCell(cell);
                    PdfPTable table = new PdfPTable(6);
                    table.AddCell("BARKOD");
                    table.AddCell("KITAP ADI");
                    table.AddCell("KATEGORI");
                    table.AddCell("SAYFA SAYISI");
                    table.AddCell("YAZAR ADI");
                    table.AddCell("YAYIN EVI");
                    cell.Colspan = 6;
                    connection.Open();
                    // pdf e veri tabanından tablo ekleme
                    command = new MySqlCommand("SELECT Odünç.Barkod,Kitap.KitapAdi,Kategori.KategoriAdi,Kitap.SayfaSayisi,Concat(Yazar.YazarAdi,' ',YazarSoyadi) as Yazar,Kitap.YayinEvi FROM Ogrenci INNER JOIN Odünç ON Odünç.KartId=Ogrenci.KartId INNER JOIN Kitap on Kitap.Barkod=Odünç.Barkod INNER JOIN Kategori on Kategori.id=Kitap.Kategori inner joın Yazar on Yazar.id=Kitap.Yazar WHERE Ogrenci.KartId=@p1 and Odünç.OduncDurum=1", connection);
                    command.Parameters.AddWithValue("@p1", kart);
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            table.AddCell(reader[i].ToString());
                        }
                    }
                    //table.AddCell()
                    connection.Close();
                    document.Add(table1);
                    document.Add(table);
                }
                string pdfyol = lblOkulno.Text + " " + lblAdi.Text + " " + lblSoyadi.Text + ".Pdf";
                document.Close();
                OpenFileDialog open = new OpenFileDialog();
                textEdit1.Text = @"C:\Users\Hasan\Documents\GitHub\INIF-KUTUPHANE-OTOMASYON-PROJE\INIF-KUTUPHANE-OTOMASYON\INIF-KUTUPHANE-OTOMASYON\bin\Debug\" + pdfyol;
                open.FileName = textEdit1.Text;
                axAcroPDF1.LoadFile(open.FileName);
            }
            else
            {
                lblOkulno.Text = "";
                lblAdi.Text = "";
                lblSoyadi.Text = "";
                lblTel.Text = "";
                lblPosta.Text = "";
                lblBölüm.Text = "";
                lblCinsiyet.Text = "";
                lblEmanet.Text = "";
            }
            connection.Close();
            //bilgileri içeren bir pdf yapacaksın 
            //sonra bu pdfyi yanda açacaksın
            ////////pdf oluşturma ve içini doldurma
            
            //C:\Users\Hasan\Documents\GitHub\INIF-KUTUPHANE-OTOMASYON-PROJE\INIF-KUTUPHANE-OTOMASYON\INIF-KUTUPHANE-OTOMASYON\bin\Debug
        }
    }
}
