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

namespace INIF_KUTUPHANE_OTOMASYON.Formlar.Ogrenci
{
    public partial class frmOgrenciEkrani : Form
    {
        public frmOgrenciEkrani()
        {
            InitializeComponent();
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        MySqlConnection connection = new MySqlConnection(@"Server=172.21.54.3; uid=yazilim16; pwd=Yazılım.16;database=yazilim16");
        public string tc, sifre, tel;

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            Formlar.Ogrenci.frmOgrenciGüncelle fr = new frmOgrenciGüncelle();
            fr.tel = lblTel.Text;
            fr.sifre = lblSifre.Text;
            fr.id = label9.Text;
            fr.Show();
        }

        private void frmOgrenciEkrani_Load(object sender, EventArgs e)
        {
            connection.Open();
            MySqlCommand command = new MySqlCommand("select * from Ogrenci where OkulNo=@p1", connection);
            command.Parameters.AddWithValue("@p1", tc);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                lblOkulNo.Text = reader[1].ToString();
                lblAd.Text = reader[2].ToString();
                lblSoyad.Text = reader[3].ToString();
                lblTel.Text = reader[4].ToString();
                lblSifre.Text = reader[10].ToString();
                lblEmanet.Text = reader[9].ToString();
                label8.Text = reader[6].ToString();
                label9.Text = reader[0].ToString();
            }
            connection.Close();
            connection.Open();
            MySqlCommand command1 = new MySqlCommand("select * from Odünç where KartId=@p1", connection);
            command1.Parameters.AddWithValue("@p1", label8.Text);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command1);
            DataTable table = new DataTable();
            adapter.Fill(table);
            gridControl2.DataSource = table;
            connection.Close();
            connection.Open();
            MySqlCommand command2 = new MySqlCommand("select * from Kitap where Durum=1 and Durum2=1", connection);
            adapter = new MySqlDataAdapter(command2);
            table = new DataTable();
            adapter.Fill(table);
            gridControl1.DataSource = table;
            connection.Close();
            tel = lblTel.Text;
            sifre = lblSifre.Text;
        }
    }
}
