using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars.Ribbon.ViewInfo;
using INIF_KUTUPHANE_OTOMASYON.Formlar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Ribbon;
using System.Windows.Forms;

namespace INIF_KUTUPHANE_OTOMASYON
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void barbtnkitaplistesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmKitapListesi fr = new Formlar.FrmKitapListesi();
            fr.MdiParent = this;
            fr.Show();
        }

        private void BarBtnYeniKitapEkle_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.frmyenikitap fr = new Formlar.frmyenikitap();
            fr.ShowDialog();
        }

        private void BarbtnOgrenciListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.frmOgrencilistesi fr = new Formlar.frmOgrencilistesi();
            fr.MdiParent = this;
            fr.Show();
        }

        private void BarBtnYeniOgrenciEkle_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.frmYeniogrenciEkle fr = new Formlar.frmYeniogrenciEkle();
            fr.ShowDialog();
        }

        private void BarButonPersonelListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.frmPersonelListesi fr = new Formlar.frmPersonelListesi();
            fr.MdiParent = this;
            fr.Show();
        }

        private void BarBtnYeniPersonelEkle_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.frmYeniPersonelEkle fr = new Formlar.frmYeniPersonelEkle();
            fr.ShowDialog();
        }

        private void BarButonEmanetListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.frmEmanetListesi fr = new Formlar.frmEmanetListesi();
            fr.MdiParent = this;
            fr.Show();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("calc.exe");
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("winword");
        }

        private void barButtonItem11_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("excel");
        }

        private void barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           ///System.Diagnostics.Process.Start("");
        }

        private void barButtonItem12_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.frmKategoriListesi fr = new Formlar.frmKategoriListesi();
            fr.MdiParent = this;
            fr.Show();
        }

        private void barButtonItem19_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.frmYazarCevirmenListesi fr = new Formlar.frmYazarCevirmenListesi();
            fr.MdiParent = this;
            fr.Show();
        }

        private void btnYeniKategori_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.frmYeniKategoriEkle fr = new Formlar.frmYeniKategoriEkle();
            fr.ShowDialog();
        }

        private void btnYeniYazar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.frmYeniYazarEkle fr = new Formlar.frmYeniYazarEkle();
            fr.ShowDialog();
        }

        private void btnYeniCevirmen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.frmYeniCevirmenEkle fr = new Formlar.frmYeniCevirmenEkle();
            fr.ShowDialog();
        }

        private void ribbonControl1_Click(object sender, EventArgs e)
        {

        }

        private void btnKitapIstatistikleri_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.frmKitapIstatistikleri fr = new Formlar.frmKitapIstatistikleri();
            fr.MdiParent = this;
            fr.Show();
        }

        private void btnEmanetVer_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.frmEmanetKitapVer fr = new Formlar.frmEmanetKitapVer();
            fr.Show();
        }

        private void btnEmanetAl_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.frmEmanetAl fr = new Formlar.frmEmanetAl();
            fr.MdiParent = this;
            fr.Show();
        }

        private void btnOgrenciIstatistikleri_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.frmOgrenciIstatistikleri fr = new Formlar.frmOgrenciIstatistikleri();
            fr.MdiParent = this;
            fr.Show();
        }

        private void btnBölümListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.frmBölümListesi fr = new Formlar.frmBölümListesi();
            fr.MdiParent = this;
            fr.Show();
        }

        private void btnYeniBölümEkle_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.frmYenibölümEkle fr = new Formlar.frmYenibölümEkle();
            fr.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FrmKitapListesi form = new FrmKitapListesi();
            form.MdiParent = this;
            form.Show();
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1:
                    btnkitaplistesi.PerformClick();
                    break;
                case Keys.F2:
                    BarBtnYeniKitapEkle.PerformClick();
                    break;
                case Keys.F3:
                    btnKitapIstatistikleri.PerformClick();
                    break;
                case Keys.F4:
                    btnEmanetListesi.PerformClick();
                    break;
                case Keys.F5:
                    btnEmanetVer.PerformClick();
                    break;
                case Keys.F6:
                    btnEmanetAl.PerformClick();
                    break;
                case Keys.F7:
                    btnKategoriListesi.PerformClick();
                    break;
                case Keys.F8:
                    btnYeniKategori.PerformClick();
                    break;
                case Keys.F9:
                    btnYazarCevirmenListesi.PerformClick();
                    break;
                case Keys.F10:
                    btnYeniYazar.PerformClick();
                    break;
                case Keys.F11:
                    btnYeniCevirmen.PerformClick();
                    break;
            }
        }
    }
}
