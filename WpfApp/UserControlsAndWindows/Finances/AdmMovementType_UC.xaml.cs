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
using WpfApp.ViewModels.Finances;

namespace WpfApp.UserControlsAndWindows.Finances
{
    /// <summary>
    /// Interaction logic for NewMovementType_UC.xaml
    /// </summary>
    public partial class AdmMovementType_UC : UserControl
    {
        private AdmMoneyMovementTypeViewModel _viewModel { get; set; }
        public AdmMovementType_UC()
        {
            InitializeComponent();
            _viewModel = new AdmMoneyMovementTypeViewModel();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = _viewModel;
        }

        private void btn_Actualizar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (listView.SelectedItem != null)
                {
                    btn_Borrar.IsEnabled = false;
                    btn_Actualizar.IsEnabled = false;
                    var tipo = (MoneyMovementType)listView.SelectedItem;
                    if (tipo.Sign == MovementSign.Credito)
                        rbtn_Credito.IsChecked = true;
                    if (tipo.Sign == MovementSign.Debito)
                        rbtn_Debito.IsChecked = true;

                    _viewModel.Nombre = tipo.Name;
                    _viewModel.Descripcion = tipo.Description;
                    _viewModel.IdTipoMovimientoDinero = tipo.IdMoneyMovementType;
                    _viewModel.Signo = tipo.Sign;
                }
                else
                {
                    MessageBoxResult result = MessageBox.Show("Debe Seleccionar Un Tipo de Movimiento Contable Para Poder Actualizarlo", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (Exception ex)
            {
                Logger.Log.Error("btn_Actualizar_Click", ex);
            }
        }

        private void btn_Guardar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(_viewModel.Signo > 0)
                {
                    _viewModel.GuardarTipoMovimiento();
                    btn_Borrar.IsEnabled = true;
                    btn_Actualizar.IsEnabled = true;
                }
                else
                {
                    MessageBoxResult result = MessageBox.Show("Elija si el movimiento que está por ingresar es de Debito o Credito", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                }                   
            }
            catch (Exception ex)
            {
                Logger.Log.Error("btn_Guardar_Click", ex);
            }
        }

        private void btn_Cancelar_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.LimpiarViewModel();
            btn_Borrar.IsEnabled = true;
            btn_Actualizar.IsEnabled = true;
            listView.SelectedItem = null;
        }

        private void btn_Borrar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void rbtn_Credito_Checked(object sender, RoutedEventArgs e)
        {
            _viewModel.Signo = MovementSign.Credito;
        }

        private void rbtn_Debito_Checked(object sender, RoutedEventArgs e)
        {
            _viewModel.Signo = MovementSign.Debito;
        }
    }
}
