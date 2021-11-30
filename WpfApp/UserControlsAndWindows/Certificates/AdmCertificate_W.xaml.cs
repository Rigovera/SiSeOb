using CoreTier.Certificates;
using CoreTier.SystemAdministration;
using CoreTier.Works;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApp.Reports;
using WpfApp.ViewModels.Certificates;

namespace WpfApp.UserControlsAndWindows.Certificates
{
    /// <summary>
    /// Interaction logic for AdmCertificate_W.xaml
    /// </summary>
    public partial class AdmCertificate_W : Window
    {
        private AdmCertificateViewModel _viewModel { get; set; }
        public AdmCertificate_W(Work obra)
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();
            _viewModel = new AdmCertificateViewModel(obra);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = _viewModel;
        }

        private void btn_GuardarMovimiento_Click(object sender, RoutedEventArgs e)
        {
            var ventanaAgregarArticulos = new AddCertificateArticle_W(_viewModel);
            ventanaAgregarArticulos.ShowDialog();
        }

        private void btn_Guardar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var tipoCertificado = _viewModel.TipoCertificadoSeleccionado;
                var presupuestoExistente = _viewModel.ListaCertificadosObra.
                    SingleOrDefault(x => x.CertificateType.IdCertificateType == (int)CertificateTypeEnum.Presupuesto);

                if (tipoCertificado.IdCertificateType != (int)CertificateTypeEnum.Presupuesto || 
                    presupuestoExistente == null || 
                    _viewModel.IdCertificado > 0)
                {
                    _viewModel.GuardarCertificado();
                }
                else
                {
                    MessageBoxResult result = MessageBox.Show("Ya Existe un Certificado del Tipo Presupuesto", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                _viewModel.LimpiarViewModel();
                btn_Actualizar.IsEnabled = true;
                _viewModel.MontoTotal = 0;
                _viewModel.Avance = 0;
                _viewModel.CargarCertificadosObra(_viewModel.ObraSeleccionada);
                _viewModel.IdCertificado = 0;
            }
            catch (Exception ex)
            {
                Logger.Log.Error("btn_Guardar_Click", ex);
            }
        }

        private void btn_Actualizar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (listView_Certificados.SelectedItem != null)
                {
                    btn_Actualizar.IsEnabled = false;
                    var certificado = (Certificate)listView_Certificados.SelectedItem;

                    _viewModel.IdCertificado = certificado.IdCertificate;
                    _viewModel.TipoCertificadoSeleccionado = _viewModel.TiposCertificado
                        .Single(x => x.IdCertificateType == certificado.CertificateType.IdCertificateType);
                    _viewModel.Avance = certificado.WorkProgress;
                    _viewModel.MontoTotal = certificado.TotalAmount;

                    _viewModel.DetalleCertificado.Clear();
                    if (certificado.CertificateDetail != null)
                    {
                        foreach (var item in certificado.CertificateDetail)
                        {
                            _viewModel.DetalleCertificado.Add(item);
                        }
                    }
                }
                else
                {
                    MessageBoxResult result = MessageBox.Show("Debe Seleccionar Un certificado Para Poder Actualizarlo", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (Exception ex)
            {
                Logger.Log.Error("btn_Actualizar_Click", ex);
            }
        }

        private void btn_Cancelar_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.LimpiarViewModel();
            btn_Actualizar.IsEnabled = true;
            listView_Certificados.SelectedItem = null;
            _viewModel.MontoTotal = 0;
            _viewModel.Avance = 0;
            _viewModel.IdCertificado = 0;
        }

        private void btn_QuitarArticulo_Click(object sender, RoutedEventArgs e)
        {
            var articuloDetalle = dataGrid_Articulos.SelectedItem as CertificateDetail;
            if (articuloDetalle != null)
                _viewModel.QuitarArticuloDetalle(articuloDetalle);
        }

        private void btn_ImprimirCertificado_Click(object sender, RoutedEventArgs e)
        {
            if (listView_Certificados.SelectedItem != null && listView_Certificados.SelectedItem is Certificate)
            {
                _viewModel.CertificadoSeleccionado = listView_Certificados.SelectedItem as Certificate;
                var ventanaImprimir = new ReportViewerForm2(_viewModel);
                ventanaImprimir.ShowDialog();
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Debe Seleccionar Un certificado Para Poder Imprimirlo", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
