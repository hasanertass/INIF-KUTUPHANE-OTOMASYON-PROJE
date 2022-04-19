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
    public partial class FrmKitapListesi : Form
    {
        public FrmKitapListesi()
        {
            InitializeComponent();
            Rectangle cozunurluk = new Rectangle();
            cozunurluk = Screen.GetBounds(cozunurluk);
            float YWidth = ((float)cozunurluk.Width / (float)this.Width);
            float YHeight = ((float)cozunurluk.Height / (float)this.Height);
            SizeF scale = new SizeF(YWidth, YHeight);
            this.Scale(scale);
            foreach (Control control in this.Controls)//panel içindeyse this.Panel1.Controls
            {
                control.Font = new Font("Microsoft Sans Serif", control.Font.SizeInPoints * YHeight * YWidth);
            }
            //int width, height;
            //width = Convert.ToInt32(this.Width);
            //height = Convert.ToInt32(this.Height);
            //txtKitapid.Text = width.ToString();
            //txtISBN.Text = height.ToString();
        }

        private void FrmKitapListesi_Load(object sender, EventArgs e)
        {
            int width, height;
            width = Convert.ToInt32(FrmKitapListesi.ActiveForm.Size.Width);
            height = Convert.ToInt32(FrmKitapListesi.ActiveForm.Size.Height);
            txtKitapid.Text = width.ToString();
            txtISBN.Text = height.ToString();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            
        }

        private void FrmKitapListesi_Load_1(object sender, EventArgs e)
        {

        }
    }
}
