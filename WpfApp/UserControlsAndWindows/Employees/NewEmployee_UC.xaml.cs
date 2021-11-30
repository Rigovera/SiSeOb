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
    /// Interaction logic for NewEmployee_UC.xaml
    /// </summary>
    public partial class NewEmployee_UC : UserControl
    {
        private NewEmployeeViewModel _viewModel { get; set; }
        public NewEmployee_UC()
        {
            InitializeComponent();
            _viewModel = new NewEmployeeViewModel();
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = _viewModel;
        }
        private void btn_Guardar_Click(object sender, RoutedEventArgs e)
        {            
            try
            {
                MessageBoxResult messageBoxResult;
                var resultado = _viewModel.GuardarEmpleado();
                if(resultado)
                    messageBoxResult = MessageBox.Show("El Nuevo Empleado se Guardó Correctamente", "Correcto", MessageBoxButton.OK, MessageBoxImage.Information);                
                else
                    messageBoxResult = MessageBox.Show("No se pudo Ingresar el Empleado, (Nombre y Apellido son Obligatorios)", "Correcto", MessageBoxButton.OK, MessageBoxImage.Warning);                                
            }
            catch (Exception ex)
            {
                Logger.Log.Error("btn_Guardar_Click", ex);
                throw ex;
            }
        }

        private void btn_Adm_TiposEmpleados_Click(object sender, RoutedEventArgs e)
        {
            var ventanaTiposEmpleado = new AdmEmployeeTypes_W();
            ventanaTiposEmpleado.ShowDialog();
            _viewModel.CargarTiposEmpleadoExistente();
        }

        private void btn_Cancelar_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.LimpiarViewModel();
        }
    }
}
