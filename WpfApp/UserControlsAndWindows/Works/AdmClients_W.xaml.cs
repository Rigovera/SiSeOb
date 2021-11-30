using CoreTier.Works;
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
using WpfApp.ViewModels.Works;

namespace WpfApp.UserControlsAndWindows.Works
{
    /// <summary>
    /// Interaction logic for AdmClients.xaml
    /// </summary>
    public partial class AdmClients_W : Window
    {
        private AdmClientsViewModel _viewModel { get; set; }
        public AdmClients_W()
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();
            _viewModel = new AdmClientsViewModel();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = _viewModel;
        }

        private void btn_Guardar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _viewModel.GuardarCliente();
                btn_Borrar.IsEnabled = true;
                btn_Actualizar.IsEnabled = true;
                MessageBoxResult result = MessageBox.Show("Los datos del Cliente se Guardaron Correctamente", "Correcto", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                Logger.Log.Error("btn_Guardar_Click", ex);
            }
        }

        private void btn_Cancelar_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.LimpiarViewModel();
            btn_Borrar.IsEnabled = true;
            btn_Actualizar.IsEnabled = true;
            dataGrid_Clientes.SelectedItem = null;
        }

        private void btn_Actualizar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dataGrid_Clientes.SelectedItem != null)
                {
                    btn_Borrar.IsEnabled = false;
                    btn_Actualizar.IsEnabled = false;
                    var cliente = (Client)dataGrid_Clientes.SelectedItem;

                    _viewModel.IdCliente = cliente.IdClient;
                    _viewModel.Nombre = cliente.Name;
                    _viewModel.Direccion = cliente.Address;
                    _viewModel.Documento = cliente.CuitCuil;
                    _viewModel.Telefono1 = cliente.PhoneNumber1;
                    _viewModel.Telefono2 = cliente.PhoneNumber2;

                }
                else
                {
                    MessageBoxResult result = MessageBox.Show("Debe Seleccionar Un Cliente Para Poder Actualizarlo", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (Exception ex)
            {
                Logger.Log.Error("btn_Actualizar_Click", ex);
            }
        }

        private void btn_Borrar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
