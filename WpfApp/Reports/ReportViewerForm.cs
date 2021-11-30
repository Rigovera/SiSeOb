using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using WpfApp.ViewModels.Works;

namespace WpfApp.Reports
{
    public partial class ReportViewerForm : Form
    {
        private WorkStateViewModel _viewModel { get; set; }
        public ReportViewerForm(WorkStateViewModel viewModel)
        {
            StartPosition = FormStartPosition.CenterScreen;
            _viewModel = viewModel;
            InitializeComponent();
        }

        private void ReportViewerForm_Load(object sender, EventArgs e)
        {
            try
            {
                workStateViewModelBindingSource.DataSource = _viewModel.EmpleadosAsignados;
                workStateViewModelBindingSource1.DataSource = _viewModel.HerramientasAsignadas;
                workStateViewModelBindingSource2.DataSource = _viewModel.ListaCertificadosObra;
                workStateViewModelBindingSource3.DataSource = _viewModel.ListaMovimientosObra;
                workStateViewModelBindingSource4.DataSource = _viewModel;
                reportViewer.RefreshReport();
            }
            catch (Exception ex)
            {
                var mensaje = ex.Message;
            }
            
        }


    }
}
