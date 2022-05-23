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
            connection.Open();
            MySqlCommand command3 = new MySqlCommand("SELECT Bölüm.BolumAdi,Count(Ogrenci.id) FROM `Ogrenci` INNER JOIN Bölüm on Bölüm.id=Ogrenci.BolumId GROUP BY Ogrenci.id", connection);
            MySqlDataReader reader3 = command3.ExecuteReader();
            while (reader3.Read())
            {
                chart1.Series["Series1"].Points.AddXY(reader3[0].ToString(), reader3[1].ToString());
            }
            connection.Close();
            connection.Open();
            command3 = new MySqlCommand();
            connection.Close();
        }
    }
}
