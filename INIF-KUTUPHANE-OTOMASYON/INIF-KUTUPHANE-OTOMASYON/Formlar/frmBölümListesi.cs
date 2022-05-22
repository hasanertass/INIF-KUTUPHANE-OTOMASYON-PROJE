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
    public partial class frmBölümListesi : Form
    {
        public frmBölümListesi()
        {
            InitializeComponent();
        }
        MySqlConnection connection = new MySqlConnection(@"Server=172.21.54.3; uid=yazilim16; pwd=Yazılım.16;database=yazilim16");
        private void frmBölümListesi_Load(object sender, EventArgs e)
        {
            List();
            // Toplam Bölüm Sayısı
            connection.Open();
            MySqlCommand command = new MySqlCommand("select count(*) from Bölüm",connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                labelControl1.Text = reader[0].ToString();
            }
            connection.Close();
        }

        private void List()
        {
            connection.Open();
            MySqlCommand command = new MySqlCommand("select * from Bölüm where Durum=1", connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            gridControl1.DataSource = table;
            connection.Close();
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            List();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            connection.Open();
            MySqlCommand command = new MySqlCommand("insert into Bölüm (BolumAdi,Durum) values (@p1,1)",connection);
            command.Parameters.AddWithValue("@p1", txtad.Text);
            command.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Yeni Bölüm Eklenmiştir", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            connection.Open();
            MySqlCommand command = new MySqlCommand("Update Bölüm Set Durum=0 where id=@p1",connection);
            command.Parameters.AddWithValue("@p1", txtid.Text);
            command.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Geçerli Bölüm Silinmiştir", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            connection.Open();
            MySqlCommand command = new MySqlCommand("Update Bölüm set BolumAdi=@p1 where id=@p2", connection);
            command.Parameters.AddWithValue("@p1", txtad.Text);
            command.Parameters.AddWithValue("@p2", txtid.Text);
            command.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Geçerli Bölüm Bilgileri Güncellenmiştir", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtid.Text = gridView1.GetFocusedRowCellValue("id").ToString();
            txtad.Text = gridView1.GetFocusedRowCellValue("BolumAdi").ToString();
        }
    }
}
