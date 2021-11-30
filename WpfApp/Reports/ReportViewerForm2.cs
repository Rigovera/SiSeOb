using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WpfApp.ViewModels.Certificates;

namespace WpfApp.Reports
{
    public partial class ReportViewerForm2 : Form
    {
        public AdmCertificateViewModel _viewModel { get; set; }
        public ReportViewerForm2(AdmCertificateViewModel viewModel)
        {
            StartPosition = FormStartPosition.CenterScreen;
            _viewModel = viewModel;
            InitializeComponent();
        }

        private void ReportViewerForm2_Load(object sender, EventArgs e)
        {
            try
            {
                certificateBindingSource.DataSource = _viewModel.CertificadoSeleccionado;
                detalleCertificadoBindingSource.DataSource = _viewModel.CertificadoSeleccionado.CertificateDetail;
                reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                var mensaje = ex.Message;
            }

        }
    }
}
