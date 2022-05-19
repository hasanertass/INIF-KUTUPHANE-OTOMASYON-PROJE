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
        int durum = 0;
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            DateTime date = Convert.ToDateTime(dateTimePicker1.Text);
            DateTime date1 = Convert.ToDateTime(dateTimePicker2.Text);
            connection.Open();
            int durum = 0;
            MySqlCommand command = new MySqlCommand("update Odünç set Barkod=@u1,KartId=@u2,AlisTarihi=@u3,TeslimTarihi=@u4,OduncDurum=@u5 where Barkod=@u6",connection);
            command.Parameters.AddWithValue("@u1", txtKitapBarkod.Text);
            command.Parameters.AddWithValue("@u2", txtKartId.Text);
            command.Parameters.AddWithValue("@u3", date.ToString("yyyy-MM-dd"));
            command.Parameters.AddWithValue("@u4", date1.ToString("yyyy-MM-dd"));
            command.Parameters.AddWithValue("@u5", durum);
            command.Parameters.AddWithValue("@u6", txtKitapBarkod.Text);
            command.ExecuteNonQuery();
            MessageBox.Show("Emanet Kitap Alınmıştır.","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            connection.Close();
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
            DateTime date =Convert.ToDateTime(dateTimePicker1.Text);
            DateTime date1 =Convert.ToDateTime(dateTimePicker2.Text);
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
