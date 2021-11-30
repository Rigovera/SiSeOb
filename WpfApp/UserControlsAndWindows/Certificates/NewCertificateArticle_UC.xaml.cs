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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp.ViewModels.Certificates;

namespace WpfApp.UserControlsAndWindows.Certificates
{
    /// <summary>
    /// Interaction logic for NewCertificateArticle.xaml
    /// </summary>
    public partial class NewCertificateArticle_UC : UserControl
    {
        private NewCertificateArticleViewModel _viewModel;
        public NewCertificateArticle_UC()
        {
            InitializeComponent();
            _viewModel = new NewCertificateArticleViewModel();
        }

        private void btn_Adm_Rubros_Click(object sender, RoutedEventArgs e)
        {
            var ventanaRubro = new AdmCertificateArticleItem_W();
            ventanaRubro.ShowDialog();
            _viewModel.CargarRubrosArticulos();
        }

        private void btn_Adm_Unidades_Click(object sender, RoutedEventArgs e)
        {
            var ventanaUnidades = new AdmMeasurementUnit_W();
            ventanaUnidades.ShowDialog();
            _viewModel.CargarUnidadesMedida();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = _viewModel;
        }

        private void btn_Guardar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _viewModel.GuardarArtituculo();
                _viewModel.LimpiarViewModel();
                MessageBoxResult result = MessageBox.Show("El Articulo se Guardó Correctamente", "Correcto", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch(Exception ex)
            {
                Logger.Log.Error("btn_Guardar_Click", ex);
                throw ex;
            }            
        }

        private void btn_Cancelar_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.LimpiarViewModel();
        }

        private void btn_Adm_Listas_Click(object sender, RoutedEventArgs e)
        {
            var ventanaListasPrecios = new AdmPricesLists_W();
            ventanaListasPrecios.ShowDialog();
            _viewModel.CargarListasPrecios();
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
            if(_viewModel.ListaPreciosSeleccionada != null)
                _viewModel.MostrarPrecioLista();
        }
    }
}
