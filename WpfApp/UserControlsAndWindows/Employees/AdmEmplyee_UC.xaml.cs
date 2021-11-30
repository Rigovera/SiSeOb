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
using WpfApp.ViewModels.Employees;

namespace WpfApp.UserControlsAndWindows.Employees
{
    /// <summary>
    /// Interaction logic for AdmEmplyee_UC.xaml
    /// </summary>
    public partial class AdmEmplyee_UC : UserControl
    {
        private AdmEmployeeViewModel _viewModel { get; set; }
        public AdmEmplyee_UC()
        {
            InitializeComponent();
            _viewModel = new AdmEmployeeViewModel();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = _viewModel;
        }

        private void btn_ActualizarEmpleado_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dataGrid_Empleados.SelectedItem != null)
                {
                    var empleado = (Employee)dataGrid_Empleados.SelectedItem;
                    var ventanaActualizarEmpleado = new UpdateEmployee_W(empleado);
                    ventanaActualizarEmpleado.ShowDialog();
                    _viewModel.CargarEmpleadosExistente();
                }
                else
                {
                    MessageBoxResult result = MessageBox.Show("Debe Seleccionar Un Empleado Para Poder Actualizarlo", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (Exception ex)
            {
                Logger.Log.Error("btn_ActualizarEmpleado_Click", ex);
            }
        }

        private void btn_Filtrar_Nombre_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.CargarEmpleadosPorNombre();
        }

        private void btn_Filtrar_Apellido_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.CargarEmpleadosPorApellido();
        }

        private void btn_Filtrar_DNI_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.CargarEmpleadosPorDNI();
        }

        private void dpk_Ingreso_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            _viewModel.CargarEmpleadosPorFechaIngreso();
        }

        private void cbx_TipoEmpleado_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _viewModel.CargarEmpleadosPorTipo();
        }
    }
}
