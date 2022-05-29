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
    public partial class frmPersonelListesi : Form
    {
        public frmPersonelListesi()
        {
            InitializeComponent();
        }
        MySqlConnection connection = new MySqlConnection(@"Server=172.21.54.3; uid=yazilim16; pwd=Yazılım.16;database=yazilim16");
        private void labelControl1_Click(object sender, EventArgs e)
        {

        }

        private void frmPersonelListesi_Load(object sender, EventArgs e)
        {
            List();
        }

        private void List()
        {
            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand("select * from Personel where PersonelDurum=1 ", connection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);
                gridControl1.DataSource = table;
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
                if (Sorgulama.KontrolEt("PersonelTc", "Personel", "PersonelDurum", txttc.Text))
                {
                    // aynı ise 
                    MessageBox.Show("Girdiğiniz TC kimlik ile eşdeğer başka bir bölüm vardır.\nLütfen tekrar deneyiniz.");
                }
                else
                {
                    // aynı değil ise
                    string ciniyet = "Erkek";
                    if (rdKadın.Checked == true)
                    {
                        ciniyet = "Kadın";
                    }
                    connection.Open();
                    MySqlCommand command = new MySqlCommand("insert into Personel (PersonelTc,PersonelAdi,PersonelSoyadi,Cinsiyet,Sifre,PersonelDurum) Values (@p1,@p2,@p3,@p4,@p5,1)", connection);
                    command.Parameters.AddWithValue("@p1", txttc.Text);
                    command.Parameters.AddWithValue("@p2", txtad.Text);
                    command.Parameters.AddWithValue("@p3", txtsoyad.Text);
                    command.Parameters.AddWithValue("@p4", ciniyet);
                    command.Parameters.AddWithValue("@p5", txtsifre.Text);
                    command.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("Yeni Personel Eklenmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MySqlCommand command = new MySqlCommand("Update Personel Set PersonelDurum=0 Where PersonelId=@p1", connection);
                command.Parameters.AddWithValue("@p1", txtid.Text);
                command.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Geçerli Personel Silinmiştir.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                string cinsiyet = "Kadın";
                if (rderkek.Checked == true)
                {
                    cinsiyet = "Erkek";
                }
                connection.Open();
                MySqlCommand command = new MySqlCommand("Update Personel Set PersonelTc=@p1,PersonelAdi=@p2,PersonelSoyadi=@p3,Cinsiyet=@p4,Sifre=@p5 Where PersonelId=@p6", connection);
                command.Parameters.AddWithValue("@p1", txttc.Text);
                command.Parameters.AddWithValue("@p2", txtad.Text);
                command.Parameters.AddWithValue("@p3", txtsoyad.Text);
                command.Parameters.AddWithValue("@p4", cinsiyet);
                command.Parameters.AddWithValue("@p5", txtsifre.Text);
                command.Parameters.AddWithValue("@p6", txtid.Text);
                command.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Geçerli Personel Bilgileri Güncellenmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            txtid.Text = gridView1.GetFocusedRowCellValue("PersonelId").ToString();
            txttc.Text = gridView1.GetFocusedRowCellValue("PersonelTc").ToString();
            txtad.Text = gridView1.GetFocusedRowCellValue("PersonelAdi").ToString();
            txtsoyad.Text = gridView1.GetFocusedRowCellValue("PersonelSoyadi").ToString();
            txtsifre.Text = gridView1.GetFocusedRowCellValue("Sifre").ToString();
            if (gridView1.GetFocusedRowCellValue("Cinsiyet").ToString() == "Erkek")
            {
                rderkek.Checked = true;
            }
            else
            {
                rdKadın.Checked = true;
            }
        }
    }
}
