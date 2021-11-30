using CoreTier.SystemAdministration;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp.UserControlsAndWindows.Certificates;
using WpfApp.UserControlsAndWindows.Finances;
using WpfApp.ViewModels.Works;

namespace WpfApp.UserControlsAndWindows.Works
{
    /// <summary>
    /// Interaction logic for AdmWorks_UC.xaml
    /// </summary>
    public partial class AdmWorks_UC : UserControl
    {
        private AdmWoksViewModel _viewModel { get;}
        public AdmWorks_UC()
        {
            InitializeComponent();
            _viewModel = new AdmWoksViewModel();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = _viewModel;
        }

        private void btn_ActualizarObra_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dataGrid_Obras.SelectedItem != null)
                {
                    var obra = (Work)dataGrid_Obras.SelectedItem;
                    var ventanaActualizaroObra = new UpdateWork_W(obra);
                    ventanaActualizaroObra.ShowDialog();
                    _viewModel.CargarObras();
                }
                else
                {
                    MessageBoxResult result = MessageBox.Show("Debe Seleccionar Una Obra Para Poder Actualizarla", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (Exception ex)
            {
                Logger.Log.Error("btn_ActualizarObra_Click", ex);
            }
        }

        private void btn_BorrarObra_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_ConsultarSituacion_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dataGrid_Obras.SelectedItem != null)
                {
                    var obra = (Work)dataGrid_Obras.SelectedItem;
                    var ventanaSituacionObra = new WorkState_W(obra);
                    ventanaSituacionObra.ShowDialog();
                    _viewModel.CargarObras();
                }
                else
                {
                    MessageBoxResult result = MessageBox.Show("Debe Seleccionar Una Obra Para Poder Consultar Su Situación", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (Exception ex)
            {
                Logger.Log.Error("btn_ConsultarSituacion_Click", ex);
            }
        }

        private void btn_Asignaciones_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dataGrid_Obras.SelectedItem != null)
                {
                    var obra = (Work)dataGrid_Obras.SelectedItem;
                    var ventanaAsignaciones = new Assignments_W(obra);
                    ventanaAsignaciones.ShowDialog();
                    _viewModel.CargarObras();
                }
                else
                {
                    MessageBoxResult result = MessageBox.Show("Debe Seleccionar Una Obra Para Poder Asignarle Recursos", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (Exception ex)
            {
                Logger.Log.Error("btn_Asignaciones_Click", ex);
            }
           
        }

        private void btn_AdministrarFinanzas_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dataGrid_Obras.SelectedItem != null)
                {
                    var obra = (Work)dataGrid_Obras.SelectedItem;
                    var ventanaActualizaroObra = new AdmFinances_W(obra);
                    ventanaActualizaroObra.ShowDialog();
                    _viewModel.CargarObras();
                }
                else
                {
                    MessageBoxResult result = MessageBox.Show("Debe Seleccionar Una Obra Para Poder Administrar sus Finanzas", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (Exception ex)
            {
                Logger.Log.Error("btn_AdministrarFinanzas_Click", ex);
            }
        }

        private void btn_AdministrarCertificados_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dataGrid_Obras.SelectedItem != null)
                {
                    var obra = (Work)dataGrid_Obras.SelectedItem;
                    var ventanaAdministrarCertificados = new AdmCertificate_W(obra);
                    ventanaAdministrarCertificados.ShowDialog();
                    _viewModel.CargarObras();
                }
                else
                {
                    MessageBoxResult result = MessageBox.Show("Debe Seleccionar Una Obra Para Poder Administrar sus Certificados", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (Exception ex)
            {
                Logger.Log.Error("btn_AdministrarCertificados_Click", ex);
            }
        }

        private void btn_Filtrar_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.CargarObrasPorNombre();
        }

        private void cbx_TiposObra_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _viewModel.CargarObrasPorTipo();
        }

        private void cbx_Ubicaciones_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _viewModel.CargarObrasPorUbicacion();
        }

        private void cbx_Clientes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _viewModel.CargarObrasPorCliente();
        }

        private void dpk_FinPosible_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            _viewModel.CargarObrasPorFechaPosibleFin();
            _viewModel.TipoObraSeleccionado = null;
            _viewModel.UbicacionSeleccionada = null;
            _viewModel.ClienteSeleccionado = null;
        }

        private void dpk_Fin_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            _viewModel.CargarObrasPorFechaFin();
            _viewModel.TipoObraSeleccionado = null;
            _viewModel.UbicacionSeleccionada = null;
            _viewModel.ClienteSeleccionado = null;
        }

        private void dpk_Inicio_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

            _viewModel.CargarObrasPorFechaInicio();
            _viewModel.TipoObraSeleccionado = null;
            _viewModel.UbicacionSeleccionada = null;
            _viewModel.ClienteSeleccionado = null;
        }
    }
}
