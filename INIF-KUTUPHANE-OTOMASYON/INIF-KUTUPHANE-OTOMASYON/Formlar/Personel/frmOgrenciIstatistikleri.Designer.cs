
namespace INIF_KUTUPHANE_OTOMASYON.Formlar
{
    partial class frmOgrenciIstatistikleri
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
            DevExpress.XtraCharts.XYDiagram xyDiagram1 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.XYDiagram xyDiagram2 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.Series series2 = new DevExpress.XtraCharts.Series();
            this.chartControl1 = new DevExpress.XtraCharts.ChartControl();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chartControl2 = new DevExpress.XtraCharts.ChartControl();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).BeginInit();
            this.SuspendLayout();
            // 
            // chartControl1
            // 
            this.chartControl1.BackColor = System.Drawing.Color.Transparent;
            this.chartControl1.BorderOptions.Visibility = DevExpress.Utils.DefaultBoolean.False;
            xyDiagram1.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram1.AxisY.VisibleInPanesSerializable = "-1";
            this.chartControl1.Diagram = xyDiagram1;
            this.chartControl1.IndicatorsPaletteName = "Yellow Orange";
            this.chartControl1.Legend.BackColor = System.Drawing.Color.Transparent;
            this.chartControl1.Legend.Border.Visibility = DevExpress.Utils.DefaultBoolean.False;
            this.chartControl1.Legend.Name = "Default Legend";
            this.chartControl1.Legend.Title.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.chartControl1.Legend.Title.Visible = true;
            this.chartControl1.Location = new System.Drawing.Point(9, 78);
            this.chartControl1.Name = "chartControl1";
            this.chartControl1.PaletteName = "Blue Green";
            series1.Name = "Bolumler";
            this.chartControl1.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1};
            this.chartControl1.Size = new System.Drawing.Size(946, 743);
            this.chartControl1.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Corbel", 24.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(128, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(589, 40);
            this.label1.TabIndex = 22;
            this.label1.Text = "ÖĞRENCİLERİN BÖLÜMLERE DAĞILIMI";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Corbel", 24.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(1136, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(537, 40);
            this.label2.TabIndex = 23;
            this.label2.Text = "ÖĞRENCİLERİN CİNSİYET DAĞILIMI";
            // 
            // chartControl2
            // 
            this.chartControl2.BackColor = System.Drawing.Color.Transparent;
            this.chartControl2.BorderOptions.Visibility = DevExpress.Utils.DefaultBoolean.False;
            xyDiagram2.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram2.AxisY.VisibleInPanesSerializable = "-1";
            this.chartControl2.Diagram = xyDiagram2;
            this.chartControl2.Legend.BackColor = System.Drawing.Color.Transparent;
            this.chartControl2.Legend.Border.Visibility = DevExpress.Utils.DefaultBoolean.False;
            this.chartControl2.Legend.Name = "Default Legend";
            this.chartControl2.Location = new System.Drawing.Point(960, 78);
            this.chartControl2.Name = "chartControl2";
            series2.Name = "Cinsiyet";
            this.chartControl2.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series2};
            this.chartControl2.Size = new System.Drawing.Size(946, 743);
            this.chartControl2.TabIndex = 24;
            // 
            // frmOgrenciIstatistikleri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PapayaWhip;
            this.ClientSize = new System.Drawing.Size(1924, 832);
            this.Controls.Add(this.chartControl2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chartControl1);
            this.Name = "frmOgrenciIstatistikleri";
            this.Text = "Öğrenci İstatistikleri";
            this.Load += new System.EventHandler(this.frmOgrenciIstatistikleri_Load);
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraCharts.ChartControl chartControl1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraCharts.ChartControl chartControl2;
    }
}