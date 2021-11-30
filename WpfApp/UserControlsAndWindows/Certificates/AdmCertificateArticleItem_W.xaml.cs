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
using WpfApp.ViewModels.Certificates;
using log4net;
using Omu.ValueInjecter;

namespace WpfApp.UserControlsAndWindows.Certificates
{
    /// <summary>
    /// Interaction logic for AdmCertificateArticleItem_W.xaml
    /// </summary>
    public partial class AdmCertificateArticleItem_W : Window
    {
        private AdmCertificateArticleItemViewModel _viewModel { get; set; }

        public AdmCertificateArticleItem_W()
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();
            _viewModel = new AdmCertificateArticleItemViewModel();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = _viewModel;
        }

        private void btn_Guardar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _viewModel.GuardarRubroArticulos();
                btn_Borrar.IsEnabled = true;
                btn_Actualizar.IsEnabled = true;
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
                if(listView.SelectedItem != null)
                {
                    btn_Borrar.IsEnabled = false;
                    btn_Actualizar.IsEnabled = false;
                    var rubro = (CertificateArticleItem)listView.SelectedItem;

                    _viewModel.Nombre = rubro.Name;
                    _viewModel.Descripcion = rubro.Description;
                    _viewModel.IdRubroArticulo = rubro.IdCertificateArticleItem;
                }
                else
                {
                    MessageBoxResult result = MessageBox.Show("Debe Seleccionar Un Rubro Para Poder Actualizarlo","Advertencia",MessageBoxButton.OK,MessageBoxImage.Warning);
                }               
            }
            catch (Exception ex)
            {
                Logger.Log.Error("btn_Actualizar_Click", ex);
            }
        }

        private void btn_Borrar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (listView.SelectedItem != null)
                {
                    var rubro = (CertificateArticleItem)listView.SelectedItem;
                    _viewModel.RubroSeleccionado.InjectFrom(rubro);
                    _viewModel.BorrarRubroArticulo();
                }
                else
                {
                    MessageBoxResult result = MessageBox.Show("Debe Seleccionar Un Rubro Para Poder Actualizarlo", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (Exception ex)
            {
                Logger.Log.Error("btn_Actualizar_Click", ex);
            }
        }


    }
}
