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
    /// Interaction logic for AdmPricesLists_W.xaml
    /// </summary>
    public partial class AdmPricesLists_W : Window
    {
        private AdmPriceListsViewModel _viewModel { get; set; }
        public AdmPricesLists_W()
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();
            _viewModel = new AdmPriceListsViewModel();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = _viewModel;
        }

        private void btn_Cancelar_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.LimpiarViewModel();
            btn_Borrar.IsEnabled = true;
            btn_Actualizar.IsEnabled = true;
            listView.SelectedItem = null;
        }

        private void btn_Guardar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _viewModel.GuardarListaPrecios();
                btn_Borrar.IsEnabled = true;
                btn_Actualizar.IsEnabled = true;
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
                if (listView.SelectedItem != null)
                {
                    btn_Borrar.IsEnabled = false;
                    btn_Actualizar.IsEnabled = false;
                    var listaPrecio = (PriceList)listView.SelectedItem;

                    _viewModel.Nombre = listaPrecio.Name;
                    _viewModel.Descripcion = listaPrecio.Description;
                    _viewModel.IdListaPrecio = listaPrecio.IdPriceList;
                }
                else
                {
                    MessageBoxResult result = MessageBox.Show("Debe Seleccionar Una Lista Para Poder Actualizarlo", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (Exception ex)
            {
                Logger.Log.Error("btn_Actualizar_Click", ex);
            }
        }
    }
}
