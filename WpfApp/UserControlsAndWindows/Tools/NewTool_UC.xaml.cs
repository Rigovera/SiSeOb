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
    /// Interaction logic for NewTool_UC.xaml
    /// </summary>
    public partial class NewTool_UC : UserControl
    {
        private NewToolViewModel _viewModel { get; set; }
        public NewTool_UC()
        {
            InitializeComponent();
            _viewModel = new NewToolViewModel();
        }

        private void btn_Adm_TipoHerramienta_Click(object sender, RoutedEventArgs e)
        {
            var ventanaTipoHerramientas = new AdmToolTypes();
            ventanaTipoHerramientas.ShowDialog();
            _viewModel.CargarTiposHerramientaExistente();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = _viewModel;
        }
        private void btn_Guardar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _viewModel.GuardarHerramienta();
                MessageBoxResult result = MessageBox.Show("La Nueva Herramienta se Guardó Correctamente", "Correcto", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                Logger.Log.Error("btn_Guardar_Click", ex);
                throw ex;
            }
        }

        private void btn_Cancelar_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.LimpiarViewModel();
        }
    }
}
