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
using WpfApp.Reports;
using WpfApp.ViewModels.Works;

namespace WpfApp.UserControlsAndWindows.Works
{
    /// <summary>
    /// Interaction logic for WorkState_W.xaml
    /// </summary>
    public partial class WorkState_W : Window
    {
        private WorkStateViewModel _viewModel { get; set; }
        public WorkState_W(Work obra)
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();
            _viewModel = new WorkStateViewModel(obra);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = _viewModel;
        }

        private void btn_ImprimirSituacion_Click(object sender, RoutedEventArgs e)
        {
            var ventanaImprimir = new ReportViewerForm(_viewModel);
            ventanaImprimir.ShowDialog();
        }
    }
}
