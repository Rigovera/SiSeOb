namespace WpfApp.Reports
{
    partial class ReportViewerForm2
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.detalleCertificadoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.certificateBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.detalleCertificadoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.certificateBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DetalleCertificadoDataSet";
            reportDataSource1.Value = this.detalleCertificadoBindingSource;
            reportDataSource2.Name = "CertificadoCabezaDataSet";
            reportDataSource2.Value = this.certificateBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "WpfApp.Reports.WorkCertificateReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(819, 476);
            this.reportViewer1.TabIndex = 0;
            // 
            // certificateBindingSource
            // 
            this.certificateBindingSource.DataSource = typeof(CoreTier.Certificates.Certificate);
            // 
            // ReportViewerForm2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(819, 476);
            this.Controls.Add(this.reportViewer1);
            this.Name = "ReportViewerForm2";
            this.Text = "IMPRIMIR";
            this.Load += new System.EventHandler(this.ReportViewerForm2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.detalleCertificadoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.certificateBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource detalleCertificadoBindingSource;
        private System.Windows.Forms.BindingSource certificateBindingSource;
    }
}