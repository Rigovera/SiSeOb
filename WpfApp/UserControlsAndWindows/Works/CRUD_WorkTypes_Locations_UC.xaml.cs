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
    /// Interaction logic for CRUD_WorkTypes_Locations_UC.xaml
    /// </summary>
    public partial class CRUD_WorkTypes_Locations_UC : UserControl
    {
        public CRUD_WorkTypes_Locations_UC()
        {
            InitializeComponent();
        }

        private void btn_AdmTiposObra_Click(object sender, RoutedEventArgs e)
        {
            if (sp_UserControls1.Children.Count == 0)
            {
                sp_UserControls1.Children.Clear();
                sp_UserControls1.Children.Add(new AdmWorkTypes_UC());
            }
            else
            {
                sp_UserControls1.Children.Clear();
            }

        }

        private void btn_AdmUbicacionesObra_Click(object sender, RoutedEventArgs e)
        {
            if(sp_UserControls2.Children.Count == 0)
            {
                sp_UserControls2.Children.Clear();
                sp_UserControls2.Children.Add(new AdmLocations_UC());
            }
            else
            {
                sp_UserControls2.Children.Clear();
            }
            
        }
    }
}
