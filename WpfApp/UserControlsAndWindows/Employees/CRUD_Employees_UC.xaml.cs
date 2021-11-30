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

namespace WpfApp.UserControlsAndWindows.Employees
{
    /// <summary>
    /// Interaction logic for CRUD_Employees.xaml
    /// </summary>
    public partial class CRUD_Employees_UC : UserControl
    {
        public CRUD_Employees_UC()
        {
            InitializeComponent();
        }

        private void btn_NuevoEmpleado_Click(object sender, RoutedEventArgs e)
        {
            sp_UserControls.Children.Clear();
            sp_UserControls.Children.Add(new NewEmployee_UC());
        }

        private void btn_AdministrarEmpleados_Click(object sender, RoutedEventArgs e)
        {
            sp_UserControls.Children.Clear();
            sp_UserControls.Children.Add(new AdmEmplyee_UC());
        }
    }
}
