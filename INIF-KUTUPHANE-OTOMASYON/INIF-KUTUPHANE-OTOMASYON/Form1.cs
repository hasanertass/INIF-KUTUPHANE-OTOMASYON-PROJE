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
            System.Diagnostics.Process.Start("ppoint");
        }
    }
}
