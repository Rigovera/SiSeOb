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
using WpfApp.UserControlsAndWindows.Works;
using WpfApp.ViewModels.Works;

namespace WpfApp.UserControlsAndWindows.Works
{
    /// <summary>
    /// Interaction logic for NewWork_UC.xaml
    /// </summary>
    public partial class NewWork_UC : UserControl
    {
        private NewWorkViewModel _viewModel { get; set; }
        public NewWork_UC()
        {
            InitializeComponent();
            _viewModel = new NewWorkViewModel();
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = _viewModel;
        }

        private void btn_Adm_Clientes_Click(object sender, RoutedEventArgs e)
        {
            var ventanaAdmClientes = new AdmClients_W();
            ventanaAdmClientes.ShowDialog();
            _viewModel.CargarClientes();
        }

        private void btn_Guardar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _viewModel.GuardarObra();
                _viewModel.LimpiarViewModel();
                MessageBoxResult result = MessageBox.Show("La Obra se Guardó Correctamente", "Correcto", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                Logger.Log.Error("btn_Guardar_Click", ex);
            }
        }

        private void btn_Cancelar_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.LimpiarViewModel();
        }
    }
}
