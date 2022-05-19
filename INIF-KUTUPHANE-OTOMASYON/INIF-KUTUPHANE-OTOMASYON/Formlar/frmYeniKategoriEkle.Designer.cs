
namespace INIF_KUTUPHANE_OTOMASYON.Formlar
{
    partial class frmYeniKategoriEkle
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmYeniKategoriEkle));
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.txtKtgriAd = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.btnKaydet = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.btnVazgec = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKtgriAd.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox7.Image")));
            this.pictureBox7.Location = new System.Drawing.Point(12, 12);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(106, 69);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox7.TabIndex = 136;
            this.pictureBox7.TabStop = false;
            // 
            // txtKtgriAd
            // 
            this.txtKtgriAd.Location = new System.Drawing.Point(119, 109);
            this.txtKtgriAd.Name = "txtKtgriAd";
            this.txtKtgriAd.Size = new System.Drawing.Size(198, 20);
            this.txtKtgriAd.TabIndex = 0;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl3.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Appearance.Options.UseForeColor = true;
            this.labelControl3.Location = new System.Drawing.Point(25, 110);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(92, 16);
            this.labelControl3.TabIndex = 141;
            this.labelControl3.Text = "KATEGORİ ADI :";
            // 
            // btnKaydet
            // 
            this.btnKaydet.Appearance.Font = new System.Drawing.Font("Viner Hand ITC", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKaydet.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnKaydet.Appearance.Options.UseFont = true;
            this.btnKaydet.Appearance.Options.UseForeColor = true;
            this.btnKaydet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKaydet.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnKaydet.ImageOptions.Image")));
            this.btnKaydet.Location = new System.Drawing.Point(49, 150);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnKaydet.Size = new System.Drawing.Size(268, 65);
            this.btnKaydet.TabIndex = 1;
            this.btnKaydet.Text = "KAYDET";
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Snap ITC", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(130, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(222, 50);
            this.label1.TabIndex = 144;
            this.label1.Text = "YENİ KATEGORİ \r\n       EKLE";
            // 
            // btnVazgec
            // 
            this.btnVazgec.Appearance.Font = new System.Drawing.Font("Viner Hand ITC", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVazgec.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnVazgec.Appearance.Options.UseFont = true;
            this.btnVazgec.Appearance.Options.UseForeColor = true;
            this.btnVazgec.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVazgec.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnVazgec.ImageOptions.Image")));
            this.btnVazgec.Location = new System.Drawing.Point(49, 221);
            this.btnVazgec.Name = "btnVazgec";
            this.btnVazgec.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnVazgec.Size = new System.Drawing.Size(268, 65);
            this.btnVazgec.TabIndex = 2;
            this.btnVazgec.Text = "VAZGEÇ";
            this.btnVazgec.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // frmYeniKategoriEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.ClientSize = new System.Drawing.Size(365, 289);
            this.Controls.Add(this.btnVazgec);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.txtKtgriAd);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.pictureBox7);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmYeniKategoriEkle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmYeniKategoriEkle";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKtgriAd.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox7;
        private DevExpress.XtraEditors.TextEdit txtKtgriAd;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.SimpleButton btnKaydet;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton btnVazgec;
    }
}