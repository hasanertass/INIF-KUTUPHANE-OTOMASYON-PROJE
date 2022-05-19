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
    public partial class frmOgrencilistesi : Form
    {
        public frmOgrencilistesi()
        {
            InitializeComponent();
        }
        MySqlConnection connection = new MySqlConnection(@"Server=172.21.54.3; uid=yazilim16; pwd=Yazılım.16;database=yazilim16");
        int durum = 0;
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
        private void frmOgrencilistesi_Load(object sender, EventArgs e)
        {
            //gridcontrolde veri listeleme
            connection.Open();
            MySqlCommand command = new MySqlCommand("SELECT o.id,o.OkulNo,o.OgrenciAdi,o.OgrenciSoyadi,o.OgrenciTelefon,o.OgrenciEposta,o.KartId,b.BolumAdi,o.Cinsiyet,o.EmanetAdeti,o.OgrenciSifre,o.OgrenciDurum FROM Ogrenci as o INNER JOIN Bölüm as b ON o.BolumId=b.id WHERE o.OgrenciDurum=1", connection);
            MySqlDataAdapter da = new MySqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;

            // lookupedite kategori ekleme 
            MySqlCommand command1 = new MySqlCommand("select * from Bölüm where durum=1", connection);
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command1);
            dt = new DataTable();
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

        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                MySqlCommand komut = new MySqlCommand("Update Ogrenci set OgrenciDurum=0 where id=@p1", connection);
                komut.Parameters.AddWithValue("@p1", txtOgrId.Text);
                komut.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Silme İŞlemi Gerçekleşmiştir");
            }
            catch (Exception)
            {
                MessageBox.Show("Hatalı İşlem !!!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtOgrId.Text = gridView1.GetFocusedRowCellValue("id").ToString();
            txtOkulNo.Text = gridView1.GetFocusedRowCellValue("OkulNo").ToString();
            txtOgrAd.Text = gridView1.GetFocusedRowCellValue("OgrenciAdi").ToString();
            txtOgrSoyad.Text = gridView1.GetFocusedRowCellValue("OgrenciSoyadi").ToString();
            txtOgrTel.Text = gridView1.GetFocusedRowCellValue("OgrenciTelefon").ToString();
            txtOgrEposta.Text = gridView1.GetFocusedRowCellValue("OgrenciEposta").ToString();
            txtOgrKartId.Text = gridView1.GetFocusedRowCellValue("KartId").ToString();
            txtEmanet.Text = gridView1.GetFocusedRowCellValue("EmanetAdeti").ToString();
            txtOgrSifre.Text = gridView1.GetFocusedRowCellValue("OgrenciSifre").ToString();
            lkpdtBolum.Properties.ValueMember = gridView1.GetFocusedRowCellValue("BolumAdi").ToString();
            if (gridView1.GetFocusedRowCellValue("Cinsiyet").ToString() == "Erkek")
            {
                rdErkek.Checked = true;
            }
            else
            {
                rdKadın.Checked = true;
            }

        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            connection.Open();
            MySqlCommand command = new MySqlCommand("SELECT o.id,o.OkulNo,o.OgrenciAdi,o.OgrenciSoyadi,o.OgrenciTelefon,o.OgrenciEposta,o.KartId,b.BolumAdi,o.Cinsiyet,o.EmanetAdeti,o.OgrenciSifre,o.OgrenciDurum FROM Ogrenci as o INNER JOIN Bölüm as b ON o.BolumId=b.id WHERE o.OgrenciDurum=1", connection);
            MySqlDataAdapter da = new MySqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;
            connection.Close();
        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            try
            {
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
                MySqlCommand command = new MySqlCommand("update Ogrenci set Okulno=@p1,OgrenciAdi=@p2,OgrenciSoyadi=@p3,OgrenciTelefon=@p4,OgrenciEposta=@p5,KartId=@p6,BolumId=@p7,Cinsiyet=@p8,EmanetAdeti=@p9,OgrenciSifre=@p10 where id=@p11", connection);
                command.Parameters.AddWithValue("@p1", txtOkulNo.Text);
                command.Parameters.AddWithValue("@p2", txtOgrAd.Text);
                command.Parameters.AddWithValue("@p3", txtOgrSoyad.Text);
                command.Parameters.AddWithValue("@p4", txtOgrTel.Text);
                command.Parameters.AddWithValue("@p5", txtOgrEposta.Text);
                command.Parameters.AddWithValue("@p6", txtOgrKartId.Text);
                command.Parameters.AddWithValue("@p7", lkpdtBolum.EditValue);
                command.Parameters.AddWithValue("@p8", cinsiyet);
                command.Parameters.AddWithValue("@p9", txtEmanet.Text);
                command.Parameters.AddWithValue("@p10", txtOgrSifre.Text);
                command.Parameters.AddWithValue("@p11", txtOgrId.Text);
                command.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Güncelleme İşlemi Yapılmıştır", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Hatalı İşlem !!!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
    }
}
