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
using WpfApp.ViewModels.Employees;

namespace WpfApp.UserControlsAndWindows.Employees
{
    /// <summary>
    /// Interaction logic for AdmTiposEmpleado.xaml
    /// </summary>
    public partial class AdmEmployeeTypes_W : Window
    {
        private AdmEmployeeTypesViewModel _viewModel {get;set;}
        public AdmEmployeeTypes_W()
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();
            _viewModel = new AdmEmployeeTypesViewModel();            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = _viewModel;
        }

        private void btn_Guardar_Click(object sender, RoutedEventArgs e)
        {           
            try
            {
                _viewModel.GuardarTipoEmpleado();
                btn_Borrar.IsEnabled = true;
                btn_Actualizar.IsEnabled = true;
                MessageBoxResult result = MessageBox.Show("El Tipo de Empleado se Guardó Correctamente ", "Correcto", MessageBoxButton.OK, MessageBoxImage.Information);
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
                    var tipo = (EmployeeType)listView.SelectedItem;

                    _viewModel.Nombre = tipo.Name;
                    _viewModel.Descripcion = tipo.Description;
                    _viewModel.IdTipoEmpleado = tipo.IdEmployeeType;               
                }
                else
                {
                    MessageBoxResult result = MessageBox.Show("Debe Seleccionar Un Rubro Para Poder Actualizarlo", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
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
            btn_Borrar.IsEnabled = true;
            btn_Actualizar.IsEnabled = true;
            listView.SelectedItem = null;
        }

        private void btn_Borrar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
