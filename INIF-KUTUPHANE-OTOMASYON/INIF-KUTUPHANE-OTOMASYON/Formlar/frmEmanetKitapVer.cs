﻿using MySql.Data.MySqlClient;
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void frmEmanetKitapVer_Load(object sender, EventArgs e)
        {
            //gridcontrolde veri listeleme
            connection.Open();
            MySqlCommand command = new MySqlCommand("select * from Kitap where durum=1 and durum2=1", connection);
            MySqlDataAdapter da = new MySqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;
            connection.Close();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            //try
            //{
            connection.Open();
            MySqlCommand command1 = new MySqlCommand("select stok from Kitap Where Barkod=@p1",connection);
            command1.Parameters.AddWithValue("@p1", txtBarkod.Text);
            MySqlDataReader reader = command1.ExecuteReader();
            while (reader.Read())
            {
                labelControl2.Text = reader[0].ToString();
            }
            connection.Close();
            int stok = Convert.ToInt32(labelControl2.Text);
            if (stok==1)
            {
                connection.Open();
                MySqlCommand command2 = new MySqlCommand("Update Kitap Set Durum=0,Stok=@p2 where Barkod=@p1",connection);
                command2.Parameters.AddWithValue("@p1", txtBarkod.Text);
                command2.Parameters.AddWithValue("@p2", stok-1);
                command2.ExecuteNonQuery();
                connection.Close();
            }
            else if (stok>1)
            {
                connection.Open();
                MySqlCommand command2 = new MySqlCommand("Update Kitap Set stok=@p1 where barkod=@p2",connection);
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
            //}
            //catch (Exception)
            //{

            //}

        }
    }
}
