using CoreTier.Assignments;
using CoreTier.SystemAdministration;
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
    /// Interaction logic for Assignments_W.xaml
    /// </summary>
    public partial class Assignments_W : Window
    {
        public AssignmentsViewModel _viewModel { get; set; }
        public Assignments_W(Work work)
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();
            _viewModel = new AssignmentsViewModel(work);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = _viewModel;
        }

        private void btn_Guardar_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.GuardarAsignaciones();
            MessageBoxResult result = MessageBox.Show("Las Asignaciones se Guardaron Correctamente", "Correcto", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void btn_AsignarEmpleado_Click(object sender, RoutedEventArgs e)
        {
            if (lv_EmpleadosDisponibles.SelectedItem != null)
            {
                var empleado = (Employee)lv_EmpleadosDisponibles.SelectedItem;
                _viewModel.AsignarEmpleado(empleado);               
            }
        }

        private void btn_LiberarEmpleado_Click(object sender, RoutedEventArgs e)
        {
            if (lv_EmpleadosAsignados.SelectedItem != null)
            {
                var empleado = (AssignedEmployee)lv_EmpleadosAsignados.SelectedItem;
                _viewModel.LiberarEmpleado(empleado);
            }
        }

        private void btn_AsignarHerramienta_Click(object sender, RoutedEventArgs e)
        {
            if (lv_HerramientasDisponibles.SelectedItem != null)
            {
                var herramienta = (Tool)lv_HerramientasDisponibles.SelectedItem;
                _viewModel.AsignarHerramienta(herramienta);
            }
        }

        private void btn_LiberarHerramienta_Click(object sender, RoutedEventArgs e)
        {
            if (lv_HerramientasAsignadas.SelectedItem != null)
            {
                var herramienta = (AssignedTool)lv_HerramientasAsignadas.SelectedItem;
                _viewModel.LiberarHerramienta(herramienta);
            }
        }

        private void cbx_TipoHerramienta_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _viewModel.CargarHerramientasDisponiblesPorTipo();
        }

        private void cbx_TipoEmpleado_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _viewModel.CargarEmpleadosDisponiblesPorTipo();
        }
    }
}
