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
using WpfApp.UserControlsAndWindows.Employees;
using WpfApp.UserControlsAndWindows.Tools;
using WpfApp.UserControlsAndWindows.Certificates;
using WpfApp.UserControlsAndWindows.Finances;
using WpfApp.UserControlsAndWindows.Works;
using Microsoft.Win32;
using System.Diagnostics;
using System.IO;
using LogicTier.SystemAdministrationLogic;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            log4net.Config.XmlConfigurator.Configure();
            InitializeComponent();
            Logger.Log.Info("Inicio de programa");
        }

        public StackPanel StackPanel { get; set; }

        private void tvi_ADM_Empleados_Selected(object sender, RoutedEventArgs e)
        {
            sp_CRUD.Children.Clear();
            sp_CRUD.Children.Add(new CRUD_Employees_UC());
        }

        private void tvi_ADM_Herramientas_Selected(object sender, RoutedEventArgs e)
        {
            sp_CRUD.Children.Clear();
            sp_CRUD.Children.Add(new CRUD_Tools_UC());
        }

        private void tvi_ADM_Certificados_Selected(object sender, RoutedEventArgs e)
        {
            sp_CRUD.Children.Clear();
            sp_CRUD.Children.Add(new CRUD_CertificateArticles_UC());

        }

        private void tvi_ADM_Contabilidad_Selected(object sender, RoutedEventArgs e)
        {
            sp_CRUD.Children.Clear();
            sp_CRUD.Children.Add(new CRUD_MovementTypes_UC());
        }

        private void tvi_ADM_Obras_Selected(object sender, RoutedEventArgs e)
        {
            sp_CRUD.Children.Clear();
            sp_CRUD.Children.Add(new CRUD_WorkTypes_Locations_UC());
        }

        private void tvi_Obras_Selected(object sender, RoutedEventArgs e)
        {
            sp_CRUD.Children.Clear();
            sp_CRUD.Children.Add(new CRUD_Works_UC());
        }

        private void tvi_ADM_TiposCertificado_Selected(object sender, RoutedEventArgs e)
        {
            sp_CRUD.Children.Clear();
            sp_CRUD.Children.Add(new CRUD_CertificateType_UC());
        }

        private void tvi_ADM_RestoreDB_Selected(object sender, RoutedEventArgs e)
        {
            MessageBoxResult dialogResult = MessageBox.Show("Se Generará un archivo de respaldo del estado de la base de datos actual", "Respaldar Base de Datos", MessageBoxButton.YesNo);
            if (dialogResult == MessageBoxResult.Yes)
            {
                ISystemAdministrationLogic systemAdministration = new SystemAdministrationLogic();
                systemAdministration.BackupDB();
            }
            else if (dialogResult == MessageBoxResult.No)
            {
                //do something else
            }           
        }
    }
}
