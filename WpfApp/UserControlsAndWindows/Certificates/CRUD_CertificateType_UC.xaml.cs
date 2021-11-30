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

namespace WpfApp.UserControlsAndWindows.Certificates
{
    /// <summary>
    /// Interaction logic for CRUD_CertificateType_UC.xaml
    /// </summary>
    public partial class CRUD_CertificateType_UC : UserControl
    {
        public CRUD_CertificateType_UC()
        {
            InitializeComponent();
        }

        private void btn_AdmTiposCertificado_Click(object sender, RoutedEventArgs e)
        {
            sp_UserControls.Children.Clear();
            sp_UserControls.Children.Add(new AdmCertificateType_UC());
        }
    }
}
