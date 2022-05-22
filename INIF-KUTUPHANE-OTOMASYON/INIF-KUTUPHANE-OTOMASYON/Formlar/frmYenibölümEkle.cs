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
    public partial class frmYenibölümEkle : Form
    {
        public frmYenibölümEkle()
        {
            InitializeComponent();
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        MySqlConnection connection = new MySqlConnection(@"Server=172.21.54.3; uid=yazilim16; pwd=Yazılım.16;database=yazilim16");
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            connection.Open();
            MySqlCommand command = new MySqlCommand("insert into Bölüm (BolumAdi,Durum) values (@p1,1)", connection);
            command.Parameters.AddWithValue("@p1", txtad.Text);
            command.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Yeni Bölüm Eklenmiştir", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
