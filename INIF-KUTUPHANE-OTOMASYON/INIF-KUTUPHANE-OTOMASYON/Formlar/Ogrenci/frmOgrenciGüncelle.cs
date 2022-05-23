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
    public partial class frmOgrenciGüncelle : Form
    {
        public frmOgrenciGüncelle()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        MySqlConnection connection = new MySqlConnection(@"Server=172.21.54.3; uid=yazilim16; pwd=Yazılım.16;database=yazilim16");
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }
        public string tel, sifre,id;

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            connection.Open();
            MySqlCommand command = new MySqlCommand("update Ogrenci set OgrenciTelefon=@p1,OgrenciSifre=@p2 where id=@p3",connection);
            command.Parameters.AddWithValue("@p1",txtTel.Text);
            command.Parameters.AddWithValue("@p2",txtSifre.Text);
            command.Parameters.AddWithValue("@p3",id);
            command.ExecuteNonQuery();
            connection.Close();
            this.Hide();
        }

        private void frmOgrenciGüncelle_Load(object sender, EventArgs e)
        {
            txtSifre.Text =tel;
            txtTel.Text = sifre;
        }
    }
}
