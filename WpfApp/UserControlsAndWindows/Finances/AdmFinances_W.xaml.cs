using CoreTier.Finances;
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
using WpfApp.ViewModels.Finances;

namespace WpfApp.UserControlsAndWindows.Finances
{
    /// <summary>
    /// Interaction logic for AdmFinances.xaml
    /// </summary>
    public partial class AdmFinances_W : Window
    {
        private AdmFinancesViewModel _viewModel { get; set; }
        public AdmFinances_W(Work work)
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();
            _viewModel = new AdmFinancesViewModel(work);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = _viewModel;
        }

        private void btn_ActualizarMovimiento_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (listView.SelectedItem != null)
                {
                    btn_ActualizarMovimiento.IsEnabled = false;
                    var movimiento = (MoneyMovement)listView.SelectedItem;
                    _viewModel.IdMovimiento = movimiento.IdMoneyMovement;
                    _viewModel.Monto = movimiento.Amount;
                    _viewModel.TipoMovimientoSeleccionado = _viewModel.TiposMovimientoContable
                        .Single(x => x.IdMoneyMovementType == movimiento.MoneyMovementType.IdMoneyMovementType);
                }
                else
                {
                    MessageBoxResult result = MessageBox.Show("Debe Seleccionar Un Movimiento Contable para poder Actualizarlo", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (Exception ex)
            {
                Logger.Log.Error("btn_Actualizar_Click", ex);
            }
        }

        private void btn_GuardarMovimiento_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _viewModel.GuardarMovimientoContable();
                _viewModel.LimpiarViewModel();
                btn_ActualizarMovimiento.IsEnabled = true;
            }
            catch(Exception ex)
            {
                Logger.Log.Error("btn_GuardarMovimiento_Click", ex);
            }
        }

        private void btn_Cancelar_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.LimpiarViewModel();
            btn_ActualizarMovimiento.IsEnabled = true;
        }
    }
}
