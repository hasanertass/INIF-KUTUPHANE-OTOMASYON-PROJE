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
    public partial class frmYazarCevirmenListesi : Form
    {
        public frmYazarCevirmenListesi()
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
        private void frmYazarCevirmenListesi_Load(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand("select * from Yazar where Durum=1", connection);
                MySqlDataAdapter da = new MySqlDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gridControl1.DataSource = dt;

                command = new MySqlCommand("select * from Cevirmen where CevirmenDurum=1", connection);
                da = new MySqlDataAdapter(command);
                dt = new DataTable();
                da.Fill(dt);
                gridControl2.DataSource = dt;
                connection.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Hatalı İşlem !!!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                connection.Close();
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                string text = txtYazarAdı + " " + txtYazarSoyad;
                if (Sorgulama.KontrolEt("Concat(YazarAdi,' ',YazarSoyadi)", "Yazar", "Durum",text))
                {
                    // aynı ise 
                    MessageBox.Show("Girdiğiniz yazar adı ile eşdeğer başka bir yazar vardır.\nLütfen tekrar deneyiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    //aynı değilse
                    connection.Open();
                    MySqlCommand command = new MySqlCommand("insert into Yazar (YazarAdi,YazarSoyadi,Durum) values (@p1,@p2,1)", connection);
                    command.Parameters.AddWithValue("@p1", txtYazarAdı.Text);
                    command.Parameters.AddWithValue("@p2", txtYazarSoyad.Text);
                    command.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("Yeni Yazar Eklenmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Hatalı İşlem !!!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                connection.Close();
            }
            ListYazar();
        }

        private void btnKaydet1_Click(object sender, EventArgs e)
        {
            try
            {
                string text = txtCvrmnAd + " " + txtCvrmnSoyad;
                if (Sorgulama.KontrolEt("Concat(CevirmenAdi,' ',CevirmenSoyadi)", "Cevirmen", "CevirmenDurum", text))
                {
                    // aynı ise
                    MessageBox.Show("Girdiğiniz çevirmen adı ile eşdeğer başka bir çevirmen vardır.\nLütfen tekrar deneyiniz.","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
                else
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand("insert into Cevirmen (CevirmenAdi,CevirmenSoyadi,CevirmenDurum) values (@p1,@p2,1)", connection);
                    command.Parameters.AddWithValue("@p1", txtCvrmnAd.Text);
                    command.Parameters.AddWithValue("@p2", txtCvrmnSoyad.Text);
                    command.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("Yeni Çevirmen Eklenmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Hatalı İşlem !!!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                connection.Close();
            }
            ListCevirmen();
        }
        private void ListYazar()
        {
            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand("select * from Yazar where Durum=1", connection);
                MySqlDataAdapter da = new MySqlDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gridControl1.DataSource = dt;
                connection.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Hatalı İşlem !!!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                connection.Close();
            }
        }
        private void ListCevirmen()
        {
            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand("select * from Cevirmen where CevirmenDurum=1", connection);
                MySqlDataAdapter da = new MySqlDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gridControl2.DataSource = dt;
                connection.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Hatalı İşlem !!!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                connection.Close();
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand("Update Yazar set durum=0 where id=@p1", connection);
                command.Parameters.AddWithValue("@p1", txtYazarid.Text);
                command.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Geçerli Yazar Silinmiştir", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception)
            {
                MessageBox.Show("Hatalı İşlem !!!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                connection.Close();
            }
            ListYazar();
        }

        private void btnSil1_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand("Update Cevirmen set CevirmenDurum=0 where id=@p1", connection);
                command.Parameters.AddWithValue("@p1", txtCvrmnid.Text);
                command.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Geçerli Çevirmen Silinmiştir", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception)
            {
                MessageBox.Show("Hatalı İşlem !!!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                connection.Close();
            }
            ListCevirmen();
        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand("Update Yazar set YazarAdi=@p1,YazarSoyadi=@p2 where id=@p3", connection);
                command.Parameters.AddWithValue("@p1", txtYazarAdı.Text);
                command.Parameters.AddWithValue("@p2", txtYazarSoyad.Text);
                command.Parameters.AddWithValue("@p3", txtYazarid.Text);
                command.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Geçerli Yazarın Bilgileri Füncellenmiştir.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception)
            {
                MessageBox.Show("Hatalı İşlem !!!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                connection.Close();
            }
            ListYazar();
        }

        private void btnGüncelle1_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand("Update Cevirmen set CevirmenAdi=@p1,CevirmenSoyadi=@p2 where id=@p3", connection);
                command.Parameters.AddWithValue("@p1", txtCvrmnAd.Text);
                command.Parameters.AddWithValue("@p2", txtCvrmnSoyad.Text);
                command.Parameters.AddWithValue("@p3", txtCvrmnid.Text);
                command.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Geçerli Çevirmen Güncellenmiştir", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception)
            {
                MessageBox.Show("Hatalı İşlem !!!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                connection.Close();
            }
            ListCevirmen();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                if (gridView1.FocusedRowHandle >= 0)
                {
                    //txtYazarid.Text = gridView1.GetFocusedRowCellValue("id").ToString(); 
                    txtYazarid.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "id").ToString();
                    //txtYazarAdı.Text = gridView1.GetFocusedRowCellValue("YazarAdi").ToString();
                    txtYazarAdı.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "YazarAdi").ToString();
                    //txtYazarSoyad.Text = gridView1.GetFocusedRowCellValue("YazarSoyadi").ToString();
                    txtYazarSoyad.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "YazarSoyadi").ToString();
                }

            }
            catch (Exception)
            {
                return;
            }

        }
        private void gridView2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtCvrmnid.Text = gridView2.GetFocusedRowCellValue("id").ToString();
            txtCvrmnAd.Text = gridView2.GetFocusedRowCellValue("CevirmenAdi").ToString();
            txtCvrmnSoyad.Text = gridView2.GetFocusedRowCellValue("CevirmenSoyadi").ToString();
        }
    }
}
