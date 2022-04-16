using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            fr.Show();
        }

        private void BarbtnOgrenciListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.frmOgrencilistesi fr = new Formlar.frmOgrencilistesi();
            fr.MdiParent = this;
            fr.Show();
        }

        private void BarBtnYeniOgrenciEkle_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.frmYeniogrenciListesi fr = new Formlar.frmYeniogrenciListesi();
            fr.Show();
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
            fr.Show();
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
            System.Diagnostics.Process.Start("");
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
            fr.Show();
        }

        private void btnYeniYazar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.frmYeniYazarEkle fr = new Formlar.frmYeniYazarEkle();
            fr.Show();
        }

        private void btnYeniCevirmen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.frmYeniCevirmenEkle fr = new Formlar.frmYeniCevirmenEkle();
            fr.Show();
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
            Formlar.frmEmanetVer fr = new Formlar.frmEmanetVer();
            fr.MdiParent = this;
            fr.Show();
        }

        private void btnEmanetAl_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.frmEmanetAl fr = new Formlar.frmEmanetAl();
            fr.MdiParent = this;
            fr.Show();
        }

        private void btnEmanetIstatistikleri_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.frmEmanetIstatistikleri fr = new Formlar.frmEmanetIstatistikleri();
            fr.MdiParent = this;
            fr.Show();
        }

        private void btnKategoriIstatistikleri_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.frmKategoriIstatistikleri fr = new Formlar.frmKategoriIstatistikleri();
            fr.MdiParent = this;
            fr.Show();
        }

        private void btnOgrenciIstatistikleri_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.frmOgrenciIstatistikleri fr = new Formlar.frmOgrenciIstatistikleri();
            fr.MdiParent = this;
            fr.Show();
        }

        private void btnBölümIstatistikleri_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.frmBölümIstatistikleri fr = new Formlar.frmBölümIstatistikleri();
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
            fr.Show();
        }
    }
}
