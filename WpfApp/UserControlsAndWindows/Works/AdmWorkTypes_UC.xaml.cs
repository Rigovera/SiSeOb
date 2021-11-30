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
using WpfApp.ViewModels.Works;

namespace WpfApp.UserControlsAndWindows.Works
{
    /// <summary>
    /// Interaction logic for AdmWorkTypes_UC.xaml
    /// </summary>
    public partial class AdmWorkTypes_UC : UserControl
    {
        private AdmWorkTypesViewModel _viewModel { get; set; }
        public AdmWorkTypes_UC()
        {
            InitializeComponent();
            _viewModel = new AdmWorkTypesViewModel();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = _viewModel;
        }

        private void btn_Guardar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _viewModel.GuardarTipoObra();
                btn_Borrar.IsEnabled = true;
                btn_Actualizar.IsEnabled = true;
                MessageBoxResult result = MessageBox.Show("Los datos del Tipo de Obra se guardaron Correctamente", "Correcto", MessageBoxButton.OK, MessageBoxImage.Information);
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

        private void btn_Actualizar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (listView.SelectedItem != null)
                {
                    btn_Borrar.IsEnabled = false;
                    btn_Actualizar.IsEnabled = false;
                    var tipo = (WorkType)listView.SelectedItem;

                    _viewModel.Nombre = tipo.Name;
                    _viewModel.Descripcion = tipo.Description;
                    _viewModel.IdTipoObra = tipo.IdWorkType;
                }
                else
                {
                    MessageBoxResult result = MessageBox.Show("Debe Seleccionar Un Tipo de Obra Para Poder Actualizarlo", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (Exception ex)
            {
                Logger.Log.Error("btn_Actualizar_Click", ex);
            }
        }

        private void btn_Borrar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
