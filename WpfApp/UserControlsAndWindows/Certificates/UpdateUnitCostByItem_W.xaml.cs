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
using WpfApp.ViewModels.Certificates;

namespace WpfApp.UserControlsAndWindows.Certificates
{
    /// <summary>
    /// Interaction logic for UpdateUnitCostByItem_W.xaml
    /// </summary>
    public partial class UpdateUnitCostByItem_W : Window
    {
        private UpdateUnitCostByItemViewModel _viewModel { get; set; }
        public UpdateUnitCostByItem_W(int idRubro, string rubro)
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();
            _viewModel = new UpdateUnitCostByItemViewModel(idRubro);
            lbl_Rubro.Content = lbl_Rubro.Content + " " + rubro;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = _viewModel;
        }

        private void btn_Aumentar_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.ActualizarCostosArticulos("+");
            MessageBoxResult result = MessageBox.Show("Los Costos se Modificaron Correctamente", "Correcto", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void btn_Disminuir_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.ActualizarCostosArticulos("-");
            MessageBoxResult result = MessageBox.Show("Los Costos se Modificaron Correctamente", "Correcto", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void cbx_Listas_Precios_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
