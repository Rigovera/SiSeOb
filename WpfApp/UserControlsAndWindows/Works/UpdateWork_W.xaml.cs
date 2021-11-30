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
    /// Interaction logic for UpdateWork_W.xaml
    /// </summary>
    public partial class UpdateWork_W : Window
    {
        public UpdateWorkViewModel _viewModel { get; set; }
        public UpdateWork_W(Work work)
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();
            _viewModel = new UpdateWorkViewModel(work);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = _viewModel;
        }

        private void btn_Guardar_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.GuardarObra();
            MessageBoxResult result = MessageBox.Show("La Obra se Actualizó Correctamente", "Correcto", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
