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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp.ViewModels.Certificates;

namespace WpfApp.UserControlsAndWindows.Certificates
{
    /// <summary>
    /// Interaction logic for FindCertificate_UC.xaml
    /// </summary>
    public partial class AdmCertificateArticle_UC : UserControl
    {
        private AdmCertificateArticleViewModel _viewModel { get; set; }

        public AdmCertificateArticle_UC()
        {
            InitializeComponent();
            _viewModel = new AdmCertificateArticleViewModel();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = _viewModel;
        }

        private void btn_ActualizarArticulo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dataGrid_Articulos.SelectedItem != null)
                {
                    var rubro = (CertificateArticle)dataGrid_Articulos.SelectedItem;
                    var ventanaActualizarArticulo = new UpdateCertificateArticle_W(rubro);
                    ventanaActualizarArticulo.ShowDialog();
                    _viewModel.CargarArticulosCertificado();
                }
                else
                {
                    MessageBoxResult result = MessageBox.Show("Debe Seleccionar Un Articulo Para Poder Actualizarlo", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (Exception ex)
            {
                Logger.Log.Error("btn_ActualizarArticulo_Click", ex);
            }
        }

        private void btn_ActualizarCostos_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_viewModel.RubroSeleccionado != null &&
                    _viewModel.RubroSeleccionado.IdCertificateArticleItem > 0)
                {
                    var idRubro = _viewModel.RubroSeleccionado.IdCertificateArticleItem;
                    var ventanaActualizarCostosPorRubro = new UpdateUnitCostByItem_W(idRubro, _viewModel.RubroSeleccionado.Name);
                    ventanaActualizarCostosPorRubro.ShowDialog();
                    _viewModel.CargarArticulosCertificado();
                }
                else
                {
                    MessageBoxResult result = MessageBox.Show("Debe Seleccionar Un Rubro Para Poder Actualizarlo", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (Exception ex)
            {
                Logger.Log.Error("btn_ActualizarArticulo_Click", ex);
            }

        }

        private void cbx_RubroArticulo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _viewModel.CargarArticulosPorRubro();
        }

        private void btn_Filtrar_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.CargarArticulosPorNombre();
        }

        private void btn_VerPrecios_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid_Articulos.SelectedItem as CertificateArticle != null)
            {
                var articulo = (CertificateArticle)dataGrid_Articulos.SelectedItem;
                var ventanaPreciosArticulo = new ViewArticlePrices_W(articulo.IdCertificateArticles);
                ventanaPreciosArticulo.ShowDialog();
            }
        }
    }
}
