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
    public partial class frmEmanetAl : Form
    {
        public frmEmanetAl()
        {
            InitializeComponent();
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            groupBox1.Visible = true;
        }
        MySqlConnection connection = new MySqlConnection(@"Server=172.21.54.3; uid=yazilim16; pwd=Yazılım.16;database=yazilim16");
        private void frmEmanetAl_Load(object sender, EventArgs e)
        {
            try
            {
                int durum = 1;
                //gridcontrolde veri listeleme
                connection.Open();
                MySqlCommand command = new MySqlCommand("select * from Odünç where OduncDurum=@p1", connection);
                command.Parameters.AddWithValue("@p1", durum);
                MySqlDataAdapter da = new MySqlDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gridControl1.DataSource = dt;
                connection.Close();
            }
            catch (Exception)
            {
                return;
            }

        }
        int durum = 0;
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                MySqlCommand command1 = new MySqlCommand("select Stok from Kitap where Barkod=@p1", connection);
                command1.Parameters.AddWithValue("@p1", txtKitapBarkod.Text);
                MySqlDataReader reader = command1.ExecuteReader();
                while (reader.Read())
                {
                    labelControl8.Text = reader[0].ToString();
                }
                connection.Close();
                int stok = Convert.ToInt32(labelControl8.Text);
                if (stok == 0)
                {
                    connection.Open();
                    MySqlCommand command2 = new MySqlCommand("Update Kitap Set durum=0,stok=@p2 where Barkod=@p1", connection);
                    command2.Parameters.AddWithValue("@p1", txtKitapBarkod.Text);
                    command2.Parameters.AddWithValue("@p2", stok + 1);
                    command2.ExecuteNonQuery();
                    connection.Close();
                }
                if (stok >= 1)
                {
                    stok++;
                    connection.Open();
                    MySqlCommand command3 = new MySqlCommand("Update Kitap Set stok=@p1 where Barkod=@p2", connection);
                    command3.Parameters.AddWithValue("@p1", stok);
                    command3.Parameters.AddWithValue("@p2", txtKitapBarkod.Text);
                    command3.ExecuteNonQuery();
                    connection.Close();
                }
                DateTime date = Convert.ToDateTime(dateTimePicker1.Text);
                DateTime date1 = Convert.ToDateTime(dateTimePicker2.Text);
                connection.Open();
                int durum = 0;
                MySqlCommand command = new MySqlCommand("update Odünç set Barkod=@u1,KartId=@u2,AlisTarihi=@u3,TeslimTarihi=@u4,OduncDurum=@u5 where OduncId=@u6", connection);
                command.Parameters.AddWithValue("@u1", txtKitapBarkod.Text);
                command.Parameters.AddWithValue("@u2", txtKartId.Text);
                command.Parameters.AddWithValue("@u3", date.ToString("yyyy-MM-dd"));
                command.Parameters.AddWithValue("@u4", date1.ToString("yyyy-MM-dd"));
                command.Parameters.AddWithValue("@u5", durum);
                command.Parameters.AddWithValue("@u6", txtEmanetId.Text);
                command.ExecuteNonQuery();
                connection.Close();
                connection.Open();
                int emanet;
                // öğrenci tablosundaki emanet kısmı güncellenecek
                command = new MySqlCommand("select EmanetAdeti from Ogrenci where KartId=@p1", connection);
                command.Parameters.AddWithValue("@p1", txtKartId.Text);
                reader = command.ExecuteReader();
                if (reader.Read())
                {
                    labelControl9.Text = reader[0].ToString();
                }
                connection.Close();
                connection.Open();
                emanet = Convert.ToInt32(labelControl9.Text);
                emanet--;
                MySqlCommand command5 = new MySqlCommand("update Ogrenci set EmanetAdeti=@p1 where KartId=@p2", connection);
                command5.Parameters.AddWithValue("@p1", emanet);
                command5.Parameters.AddWithValue("@p2", txtKartId.Text);
                command5.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Emanet Kitap Alınmıştır.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                return;
            }

        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                txtEmanetId.Text = gridView1.GetFocusedRowCellValue("OduncId").ToString();
                txtKitapBarkod.Text = gridView1.GetFocusedRowCellValue("Barkod").ToString();
                txtKartId.Text = gridView1.GetFocusedRowCellValue("KartId").ToString();
                dateTimePicker1.Text = gridView1.GetFocusedRowCellValue("AlisTarihi").ToString();
                dateTimePicker2.Text = gridView1.GetFocusedRowCellValue("TeslimTarihi").ToString();
                if (gridView1.GetFocusedRowCellValue("OduncDurum").ToString() == "True")
                {
                    rdEmanet.Checked = true;
                }
                else
                {
                    rdZimmet.Checked = true;
                }
            }
            catch (Exception)
            {

            }

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime date = Convert.ToDateTime(dateTimePicker1.Text);
                DateTime date1 = Convert.ToDateTime(dateTimePicker2.Text);
                if (rdEmanet.Checked == true)
                {
                    durum = 1;
                }
                connection.Open();
                MySqlCommand command = new MySqlCommand("update Odünç set Barkod=@u1,KartId=@u2,AlisTarihi=@u3,TeslimTarihi=@u4 where OduncId=@u5", connection);
                command.Parameters.AddWithValue("@u1", txtKitapBarkod.Text);
                command.Parameters.AddWithValue("@u2", txtKartId.Text);
                command.Parameters.AddWithValue("@u3", date.ToString("yyyy-MM-dd"));
                command.Parameters.AddWithValue("@u4", date1.ToString("yyyy-MM-dd"));
                //command.Parameters.AddWithValue("@u5", durum);
                command.Parameters.AddWithValue("@u5", txtEmanetId.Text);
                command.ExecuteNonQuery();
                MessageBox.Show("Emanet Bilgileri Güncellenmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                connection.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Hatalı işlem yapılmıştır. Lütfen tekrara deneyiniz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            //gridcontrolde veri listeleme
            connection.Open();
            MySqlCommand command = new MySqlCommand("select * from Odünç where OduncDurum=@p1", connection);
            command.Parameters.AddWithValue("@p1", true);
            MySqlDataAdapter da = new MySqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;
            connection.Close();

        }
    }
}
