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
    /// Interaction logic for ViewArticlePrices_W.xaml
    /// </summary>
    public partial class ViewArticlePrices_W : Window
    {
        private ViewArticlePricesViewModel _viewModel { get; set; }
        public ViewArticlePrices_W(int idArticulo)
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();
            _viewModel = new ViewArticlePricesViewModel(idArticulo);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = _viewModel;
        }

        private void btn_ActualizarCostos_Click(object sender, RoutedEventArgs e)
        {
            var algo = _viewModel.PreciosArticulo;
        }

        private void btn_Aumentar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dataGrid_PreciosArticulo.SelectedItem != null)
                {
                    var precio = (ArticlePrices)dataGrid_PreciosArticulo.SelectedItem;
                    _viewModel.PrecioArticuloSeleccionado = precio;

                    _viewModel.AjustarPrecio("+");
                }
                else
                {
                    MessageBoxResult result = MessageBox.Show("Debe Seleccionar Un Precio Para Poder Actualizarlo", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (Exception ex)
            {
                Logger.Log.Error("btn_Aumentar_Click", ex);
            }
        }

        private void btn_Disminuir_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dataGrid_PreciosArticulo.SelectedItem != null)
                {
                    var precio = (ArticlePrices)dataGrid_PreciosArticulo.SelectedItem;
                    _viewModel.PrecioArticuloSeleccionado = precio;
                    _viewModel.AjustarPrecio("-");
                }
                else
                {
                    MessageBoxResult result = MessageBox.Show("Debe Seleccionar Un Precio Para Poder Actualizarlo", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (Exception ex)
            {
                Logger.Log.Error("btn_Aumentar_Click", ex);
            }
        }
    }
}
