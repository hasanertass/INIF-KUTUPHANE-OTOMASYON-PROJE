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
    public partial class frmYeniPersonelEkle : Form
    {
        public frmYeniPersonelEkle()
        {
            InitializeComponent();
        }
        MySqlConnection connection = new MySqlConnection(@"Server=172.21.54.3; uid=yazilim16; pwd=Yazılım.16;database=yazilim16");
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            string ciniyet = "Erkek";
            if (rdKadın.Checked == true)
            {
                ciniyet = "Kadın";
            }
            connection.Open();
            MySqlCommand command = new MySqlCommand("insert into Personel (PersonelTc,PersonelAdi,PersonelSoyadi,Cinsiyet,Sifre,PersonelDurum) Values (@p1,@p2,@p3,@p4,@p5,1)", connection);
            command.Parameters.AddWithValue("@p1", txttc.Text);
            command.Parameters.AddWithValue("@p2", txtadi.Text);
            command.Parameters.AddWithValue("@p3", txtsoyad.Text);
            command.Parameters.AddWithValue("@p4", ciniyet);
            command.Parameters.AddWithValue("@p5", txtsifre.Text);
            command.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Yeni Personel Eklenmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
