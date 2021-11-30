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
using WpfApp.ViewModels.Tools;

namespace WpfApp.UserControlsAndWindows.Tools
{
    /// <summary>
    /// Interaction logic for AdmTool_UC.xaml
    /// </summary>
    public partial class AdmTool_UC : UserControl
    {
        private AdmToolViewModel _viewModel { get; set; }
        public AdmTool_UC()
        {
            InitializeComponent();
            _viewModel = new AdmToolViewModel();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = _viewModel;
        }

        private void btn_ActualizarHerramienta_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dataGrid_Herramientas.SelectedItem != null)
                {
                    var empleado = (Tool)dataGrid_Herramientas.SelectedItem;
                    var ventanaActualizarEmpleado = new UpdateTool_W(empleado);
                    ventanaActualizarEmpleado.ShowDialog();
                    _viewModel.CargarHerramientasExistente();
                }
                else
                {
                    MessageBoxResult result = MessageBox.Show("Debe Seleccionar Una Herramienta Para Poder Actualizarla", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (Exception ex)
            {
                Logger.Log.Error("btn_ActualizarHerramienta_Click", ex);
            }
        }

        private void cbx_TipoHerramienta_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                _viewModel.CargarHerramientasPorTipo();
            }
            catch (Exception ex)
            {
                Logger.Log.Error("cbx_TipoHerramienta_SelectionChanged", ex);
                throw;
            }
        }

        private void btn_Filtrar_Nombre_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _viewModel.CargarHerramientasPorNombre();
            }
            catch (Exception ex)
            {
                Logger.Log.Error("btn_Filtrar_Nombre_Click", ex);
                throw;
            }
        }

        private void btn_Filtrar_Marca_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _viewModel.CargarHerramientasPorMarca();
            }
            catch (Exception ex)
            {
                Logger.Log.Error("btn_Filtrar_Marca_Click", ex);
                throw;
            }
        }
    }
}
