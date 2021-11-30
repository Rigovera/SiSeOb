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
    /// Interaction logic for UpdateCertificateArticle_W.xaml
    /// </summary>
    public partial class UpdateCertificateArticle_W : Window
    {
        private UpdateCertificateArticleViewModel _viewModel { get; set; }
        public UpdateCertificateArticle_W(CertificateArticle articuloCertificado)
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();
            _viewModel = new UpdateCertificateArticleViewModel(articuloCertificado);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = _viewModel;
        }

        private void btn_Guardar_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.GuardarArtituculo();
            MessageBoxResult result = MessageBox.Show("El Articulo se Actualizó Correctamente", "Correcto", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void btn_Agregar_Precio_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _viewModel.AgregarPrecioLista();
                MessageBoxResult result = MessageBox.Show("El Precio se Agregó Correctamente", "Correcto", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            catch (Exception ex)
            {
                Logger.Log.Error("btn_Agregar_Precio_Click", ex);
                throw ex;
            }
        }

        private void cbx_Listas_Precios_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _viewModel.MostrarPrecioLista();
        }
    }
}
