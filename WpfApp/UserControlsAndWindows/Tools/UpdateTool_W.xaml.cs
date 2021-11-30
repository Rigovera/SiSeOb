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
using WpfApp.ViewModels.Tools;

namespace WpfApp.UserControlsAndWindows.Tools
{
    /// <summary>
    /// Interaction logic for UpdateTool_W.xaml
    /// </summary>
    public partial class UpdateTool_W : Window
    {
        private UpdateToolViewModel _viewModel { get; set; }
        public UpdateTool_W(Tool tool)
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();
            _viewModel = new UpdateToolViewModel(tool);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = _viewModel;
        }

        private void btn_Guardar_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.GuardarHerramienta();
            MessageBoxResult result = MessageBox.Show("La Herramienta se Actualizó Correctamente", "Correcto", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
