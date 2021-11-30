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

namespace WpfApp.UserControlsAndWindows.Works
{
    /// <summary>
    /// Interaction logic for CRUD_Works_UC.xaml
    /// </summary>
    public partial class CRUD_Works_UC : UserControl
    {
        public CRUD_Works_UC()
        {
            InitializeComponent();
        }

        private void btn_NuevaObra_Click(object sender, RoutedEventArgs e)
        {
            sp_UserControls.Children.Clear();
            sp_UserControls.Children.Add(new NewWork_UC());
        }

        private void btn_AdministrarObras_Click(object sender, RoutedEventArgs e)
        {
            sp_UserControls.Children.Clear();
            sp_UserControls.Children.Add(new AdmWorks_UC());
        }
    }
}
