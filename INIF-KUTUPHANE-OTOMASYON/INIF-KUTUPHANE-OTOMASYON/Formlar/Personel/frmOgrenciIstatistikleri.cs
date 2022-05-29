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
    public partial class frmOgrenciIstatistikleri : Form
    {
        public frmOgrenciIstatistikleri()
        {
            InitializeComponent();
        }
        MySqlConnection connection = new MySqlConnection(@"Server=172.21.54.3; uid=yazilim16; pwd=Yazılım.16;database=yazilim16");
        private void frmOgrenciIstatistikleri_Load(object sender, EventArgs e)
        {
            //try
            //{
                connection.Open();
                MySqlCommand command3 = new MySqlCommand("SELECT Bölüm.BolumAdi,Count(Ogrenci.id) As Sayi FROM `Ogrenci` INNER JOIN Bölüm on Bölüm.id=Ogrenci.BolumId Group BY Bölüm.BolumAdi", connection);
                MySqlDataReader reader3 = command3.ExecuteReader();
                
                while (reader3.Read())
                {
                    //chartControl1.Series["Bolumler"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(reader3[0].ToString(), int.Parse(reader3[1].ToString())));
                   
                    chartControl1.Series["Bolumler"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(reader3["BolumAdi"].ToString(), Convert.ToInt32(reader3["Sayi"])) );
                }
                chartControl1.Series["Bolumler"].ArgumentDataMember = "BolumAdi";
                chartControl1.Series["Bolumler"].ValueDataMembers.AddRange(new string[] { "Sayi" });
                connection.Close();
                connection.Open();
                command3 = new MySqlCommand();
                connection.Close();
                connection.Open();
                command3 = new MySqlCommand("SELECT Cinsiyet,COUNT(Cinsiyet) as 'Sayi' FROM Ogrenci where OgrenciDurum = 1 GROUP BY Cinsiyet ", connection);
                reader3 = command3.ExecuteReader();
                while (reader3.Read())
                {
                    chartControl2.Series["Cinsiyet"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(reader3[0].ToString(), Convert.ToInt32(reader3[1])));
                }
                connection.Close();
            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("Hatalı İşlem !!!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    connection.Close();
            //}
        }
    }
}
