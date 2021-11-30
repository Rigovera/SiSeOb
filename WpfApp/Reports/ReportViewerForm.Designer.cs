namespace WpfApp.Reports
{
    partial class ReportViewerForm
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource4 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource5 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.workStateViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.workStateViewModelBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.workStateViewModelBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.workStateViewModelBindingSource3 = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.workStateViewModelBindingSource4 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.workStateViewModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.workStateViewModelBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.workStateViewModelBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.workStateViewModelBindingSource3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.workStateViewModelBindingSource4)).BeginInit();
            this.SuspendLayout();
            // 
            // workStateViewModelBindingSource
            // 
            this.workStateViewModelBindingSource.DataSource = typeof(WpfApp.ViewModels.Works.WorkStateViewModel);
            // 
            // workStateViewModelBindingSource1
            // 
            this.workStateViewModelBindingSource1.DataSource = typeof(WpfApp.ViewModels.Works.WorkStateViewModel);
            // 
            // workStateViewModelBindingSource2
            // 
            this.workStateViewModelBindingSource2.DataSource = typeof(WpfApp.ViewModels.Works.WorkStateViewModel);
            // 
            // workStateViewModelBindingSource3
            // 
            this.workStateViewModelBindingSource3.DataSource = typeof(WpfApp.ViewModels.Works.WorkStateViewModel);
            // 
            // reportViewer
            // 
            this.reportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "EmpleadosDataSet";
            reportDataSource1.Value = this.workStateViewModelBindingSource;
            reportDataSource2.Name = "HerramientasDataSet";
            reportDataSource2.Value = this.workStateViewModelBindingSource1;
            reportDataSource3.Name = "ListaCertificadosObraDataSet";
            reportDataSource3.Value = this.workStateViewModelBindingSource2;
            reportDataSource4.Name = "ListaMovimientosObraDataSet";
            reportDataSource4.Value = this.workStateViewModelBindingSource3;
            reportDataSource5.Name = "TotalesDataSet";
            reportDataSource5.Value = this.workStateViewModelBindingSource4;
            this.reportViewer.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer.LocalReport.DataSources.Add(reportDataSource4);
            this.reportViewer.LocalReport.DataSources.Add(reportDataSource5);
            this.reportViewer.LocalReport.ReportEmbeddedResource = "WpfApp.Reports.WorkStateReport.rdlc";
            this.reportViewer.Location = new System.Drawing.Point(0, 0);
            this.reportViewer.Name = "reportViewer";
            this.reportViewer.ServerReport.BearerToken = null;
            this.reportViewer.Size = new System.Drawing.Size(819, 476);
            this.reportViewer.TabIndex = 0;
            // 
            // workStateViewModelBindingSource4
            // 
            this.workStateViewModelBindingSource4.DataSource = typeof(WpfApp.ViewModels.Works.WorkStateViewModel);
            // 
            // ReportViewerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(819, 476);
            this.Controls.Add(this.reportViewer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ReportViewerForm";
            this.Text = "IMPRIMIR";
            this.Load += new System.EventHandler(this.ReportViewerForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.workStateViewModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.workStateViewModelBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.workStateViewModelBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.workStateViewModelBindingSource3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.workStateViewModelBindingSource4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer;
        private System.Windows.Forms.BindingSource workStateViewModelBindingSource;
        private System.Windows.Forms.BindingSource workStateViewModelBindingSource1;
        private System.Windows.Forms.BindingSource workStateViewModelBindingSource2;
        private System.Windows.Forms.BindingSource workStateViewModelBindingSource3;
        private System.Windows.Forms.BindingSource workStateViewModelBindingSource4;
    }
}