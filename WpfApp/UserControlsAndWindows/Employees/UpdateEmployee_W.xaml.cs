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
    /// Interaction logic for UpdateEmployee_W.xaml
    /// </summary>
    public partial class UpdateEmployee_W : Window
    {
        private UpdateEmployeeViewModel _viewModel { get; set; }
        public UpdateEmployee_W(Employee employee)
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();
            _viewModel = new UpdateEmployeeViewModel(employee);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = _viewModel;
        }

        private void btn_Guardar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBoxResult messageBoxResult;
                var resultado = _viewModel.GuardarEmpleado();
                if (resultado)
                    messageBoxResult = MessageBox.Show("El Empleado se Actualizó correctamente", "Correcto", MessageBoxButton.OK, MessageBoxImage.Information);
                else
                    messageBoxResult = MessageBox.Show("No se pudo Actualizar el Empleado, (Nombre y Apellido son Obligatorios)", "Correcto", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch (Exception ex)
            {
                Logger.Log.Error("btn_Guardar_Click", ex);
                throw ex;
            }
        }
    }
}
