using CoreTier.SystemAdministration;
using System;
using System.Collections.Generic;
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
using WpfApp.ViewModels.Certificates;

namespace WpfApp.UserControlsAndWindows.Certificates
{
    /// <summary>
    /// Interaction logic for AddCertificateArticle_W.xaml
    /// </summary>
    public partial class AddCertificateArticle_W : Window
    {
        private AdmCertificateViewModel _viewModel { get; set; }
        public AddCertificateArticle_W(AdmCertificateViewModel viewModel)
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();
            _viewModel = viewModel;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = _viewModel;
        }

        private void btn_AgregarArticulo_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid_Articulos.SelectedItem != null)
            {                
                if(_viewModel.AgregarArticuloCertificado())
                    MessageBox.Show("El Articulo se Agrego Correctamente al Certificado", "Correcto", MessageBoxButton.OK, MessageBoxImage.Information);
                else
                    MessageBox.Show("La cantidad Solicitada Excede al presupuesto", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void cbx_RubroArticulo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _viewModel.CargarArticulosDisponiblesPorTipo();
        }

        private void dataGrid_Articulos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataGrid_Articulos.SelectedItem != null && dataGrid_Articulos.SelectedItem is CertificateArticle)
            {
                _viewModel.ArticuloSeleccionado = (CertificateArticle)dataGrid_Articulos.SelectedItem;
                _viewModel.MostrarPreciosArticulo();
            }
        }

        private void tbx_Cantidad_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                _viewModel.Cantidad = Convert.ToInt32(tbx_Cantidad.Text);
                _viewModel.CalcularTotalArticuloDetalle();
            }                
        }

        private void cbx_PreciosArticuloSeleccionado_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _viewModel.CalcularTotalArticuloDetalle();            
        }
    }
}
