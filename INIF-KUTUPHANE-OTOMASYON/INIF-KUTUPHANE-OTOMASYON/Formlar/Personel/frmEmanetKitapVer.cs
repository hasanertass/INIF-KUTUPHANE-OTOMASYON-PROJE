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
using System.Net.Mail;
namespace INIF_KUTUPHANE_OTOMASYON.Formlar
{
    public partial class frmEmanetKitapVer : Form
    {
        public frmEmanetKitapVer()
        {
            InitializeComponent();
        }
        MySqlConnection connection = new MySqlConnection(@"Server=172.21.54.3; uid=yazilim16; pwd=Yazılım.16;database=yazilim16");
        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }
        MailMessage mail = new MailMessage();
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void frmEmanetKitapVer_Load(object sender, EventArgs e)
        {
            //gridcontrolde veri listeleme
            List();
            DateTime bugun = System.DateTime.Today.AddDays(15);
            dateTimePicker2.Value=bugun;
        }
        private void List()
        {
            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand("select * from Kitap where durum=1 and durum2=1", connection);
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
                int adet = 0;
                connection.Open();
                MySqlCommand command3 = new MySqlCommand("select DISTINCT(Odünç.KartId),Ogrenci.EmanetAdeti from Odünç INNER JOIN Ogrenci on Ogrenci.KartId = Odünç.KartId where Odünç.KartId=@p1", connection);
                command3.Parameters.AddWithValue("@p1", txtKartId.Text);
                MySqlDataReader reader1 = command3.ExecuteReader();
                if (reader1.Read()) 
                {
                    adet = Convert.ToInt32(reader1[1].ToString());
                }
                connection.Close();
                if (adet <= 3)
                {
                    connection.Open();
                    MySqlCommand command1 = new MySqlCommand("select stok from Kitap Where Barkod=@p1", connection);
                    command1.Parameters.AddWithValue("@p1", txtBarkod.Text);
                    MySqlDataReader reader = command1.ExecuteReader();
                    while (reader.Read())
                    {
                        labelControl2.Text = reader[0].ToString();
                    }
                    connection.Close();
                    int stok = Convert.ToInt32(labelControl2.Text);
                    if (stok == 1)
                    {
                        connection.Open();
                        MySqlCommand command2 = new MySqlCommand("Update Kitap Set Durum=0,Stok=@p2 where Barkod=@p1", connection);
                        command2.Parameters.AddWithValue("@p1", txtBarkod.Text);
                        command2.Parameters.AddWithValue("@p2", stok - 1);
                        command2.ExecuteNonQuery();
                        connection.Close();
                    }
                    else if (stok > 1)
                    {
                        connection.Open();
                        MySqlCommand command2 = new MySqlCommand("Update Kitap Set stok=@p1 where barkod=@p2", connection);
                        command2.Parameters.AddWithValue("@p1", stok - 1);
                        command2.Parameters.AddWithValue("@p2", txtBarkod.Text);
                        command2.ExecuteNonQuery();
                        connection.Close();
                    }
                    DateTime dateTime = Convert.ToDateTime(dateTimePicker1.Text);
                    DateTime dateTime1 = Convert.ToDateTime(dateTimePicker2.Text);
                    int durum = 1;

                    connection.Open();
                    MySqlCommand command = new MySqlCommand("insert into Odünç (Barkod,KartId,AlisTarihi,TeslimTarihi,OduncDurum) values (@p1,@p2,@p3,@p4,@p5)", connection);
                    command.Parameters.AddWithValue("@p1", txtBarkod.Text);
                    command.Parameters.AddWithValue("@p2", txtKartId.Text);
                    command.Parameters.AddWithValue("@p3", dateTime.ToString("yyyy-MM-dd"));
                    command.Parameters.AddWithValue("@p4", dateTime1.ToString("yyyy-MM-dd"));
                    command.Parameters.AddWithValue("@p5", durum);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Kitap Emanet Edilmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    connection.Close();
                    connection.Open();
                    int emanet;
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
                    emanet++;
                    MySqlCommand command5 = new MySqlCommand("update Ogrenci set EmanetAdeti=@p1 where KartId=@p2", connection);
                    command5.Parameters.AddWithValue("@p1", emanet);
                    command5.Parameters.AddWithValue("@p2", txtKartId.Text);
                    command5.ExecuteNonQuery();
                    connection.Close();
                    string alici, konu = "İnif Kütüphane", ad;
                    DateTime date;
                    connection.Open();
                    command = new MySqlCommand("select Concat(Ogrenci.OgrenciAdi,' ', Ogrenci.OgrenciSoyadi) as Ad ,Odünç.KartId,Ogrenci.OgrenciEposta,Odünç.TeslimTarihi from Odünç INNER JOIN Ogrenci on Ogrenci.KartId = Odünç.KartId where Odünç.KartId=@p1", connection);
                    command.Parameters.AddWithValue("@p1", txtKartId.Text);
                    reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        ad = reader[0].ToString();
                        alici = reader[2].ToString();
                        date = Convert.ToDateTime(reader[3].ToString());
                        string body = "Sevgili Öğrencimiz " + ad + "; \n Teslim almış olduğunuz kitabın son teslim tarihi : " + date.ToString("dd-MMMM-yyyy-ddddd") + " 'dır. \n Bilginize";


                        mail.From = new MailAddress("ertas7843@gmail.com");
                        mail.To.Add(alici);
                        mail.Subject = konu;
                        mail.Body = body;
                        SmtpClient smtp = new SmtpClient();
                        smtp.Credentials = new System.Net.NetworkCredential("ertas7843@gmail.com", "He15280780528");
                        smtp.Port = 587;
                        smtp.Host = "smtp.gmail.com";
                        smtp.EnableSsl = true;
                        smtp.Send(mail);
                       // MessageBox.Show("Mail başarı ile gönderilmiştir.");
                    }
                    connection.Close();
                }
                else
                {
                    MessageBox.Show("Öğrenci alabileceği kitap limitine ulaşmıştır.\n Tekrar kitap alabilmesi için daha önce elinde bulunan kitapları iade etmesi gerekir.","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }

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
            txtBarkod.Text = gridView1.GetFocusedRowCellValue("Barkod").ToString();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

        }
    }
}
