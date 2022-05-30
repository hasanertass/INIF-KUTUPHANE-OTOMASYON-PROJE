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
    public partial class frmKategoriListesi : Form
    {
        public frmKategoriListesi()
        {
            InitializeComponent();
        }
        MySqlConnection connection = new MySqlConnection(@"Server=172.21.54.3; uid=yazilim16; pwd=Yazılım.16;database=yazilim16");

        private void frmKategoriListesi_Load(object sender, EventArgs e)
        {
            List();
        }

        private void List()
        {
            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand("select * from Kategori where durum=1", connection);
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

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                if (Sorgulama.KontrolEt("KategoriAdi", "Kategori", "Durum", txtKtgriAd.Text))
                {
                    // aynı ise 
                    MessageBox.Show("Girdiğiniz Kategori adı ile eşdeğer başka bir bölüm vardır.\nLütfen tekrar deneyiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    int durum = 1;
                    connection.Open();
                    MySqlCommand command = new MySqlCommand("insert into Kategori (KategoriAdi,Durum) values (@p1,@p2)", connection);
                    command.Parameters.AddWithValue("@p1", txtKtgriAd.Text);
                    command.Parameters.AddWithValue("@p2", durum); ;
                    command.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("Kategori Kaydedilmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Hatalı İşlem !!!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                connection.Close();
            }
            List();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand("update Kategori set durum=0 where id=@p2", connection);
                command.Parameters.AddWithValue("@p2", txtKtgrid.Text);
                command.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Kategori Silinmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Hatalı İşlem !!!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                connection.Close();
            }
            List();
        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand("update Kategori set KategoriAdi=@p1 where id=@p2", connection);
                command.Parameters.AddWithValue("@p1", txtKtgriAd.Text);
                command.Parameters.AddWithValue("@p2", txtKtgrid.Text);
                command.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Kategori Güncelleniştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Hatalı İşlem !!!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                connection.Close();
            }
            List();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                txtKtgrid.Text = gridView1.GetFocusedRowCellValue("id").ToString();
                txtKtgriAd.Text = gridView1.GetFocusedRowCellValue("KategoriAdi").ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Hatalı İşlem !!!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
