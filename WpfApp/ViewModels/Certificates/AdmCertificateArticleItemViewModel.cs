using CoreTier.SystemAdministration;
using LogicTier.SystemAdministrationLogic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.ViewModels.Certificates
{
    public class AdmCertificateArticleItemViewModel : ViewModelBase
    {
        private ISystemAdministrationLogic _systemAdministration { get; set; }
        public AdmCertificateArticleItemViewModel()
        {
            ListaRubrosArticulosCertificado = new ObservableCollection<CertificateArticleItem>();
            RubroSeleccionado = new CertificateArticleItem();
            CargarRubrosArticulosCertificado();
        }

        private int _idRubroArticulo;
        public int IdRubroArticulo
        {
            get { return _idRubroArticulo; }
            set { SetProperty(ref _idRubroArticulo, value); }
        }

        private string _nombre;
        public string Nombre
        {
            get { return _nombre; }
            set { SetProperty(ref _nombre, value); }
        }

        private string _descripcion;
        public string Descripcion
        {
            get { return _descripcion; }
            set { SetProperty(ref _descripcion, value); }
        }

        private CertificateArticleItem _rubro;
        public CertificateArticleItem RubroSeleccionado
        {
            get { return _rubro; }
            set { SetProperty(ref _rubro, value); }
        }

        public ObservableCollection<CertificateArticleItem> ListaRubrosArticulosCertificado { get; set; }

        private CertificateArticleItem MapearModelo()
        {
            var rubroCertificado = new CertificateArticleItem();
            if (!string.IsNullOrEmpty(Nombre))
            {
                rubroCertificado.IdCertificateArticleItem = IdRubroArticulo;
                rubroCertificado.Name = Nombre;
                rubroCertificado.Description = Descripcion;
                return rubroCertificado;
            }
            return null;
        }

        private void CargarRubrosArticulosCertificado()
        {
            _systemAdministration = new SystemAdministrationLogic();
            ListaRubrosArticulosCertificado.Clear();
            var rubrosArticulo = _systemAdministration.GetAllCertificateArticleItem();
            if (rubrosArticulo.Any())
            {
                foreach (var item in rubrosArticulo)
                {
                    ListaRubrosArticulosCertificado.Add(item);
                }
            }
        }

        public void GuardarRubroArticulos()
        {
            _systemAdministration = new SystemAdministrationLogic();
            var rubroArticulo = MapearModelo();

            if(rubroArticulo.IdCertificateArticleItem == 0)
            {
                _systemAdministration.InsertCertificateArticleItem(rubroArticulo);
                ListaRubrosArticulosCertificado.Add(rubroArticulo);
            }
            else if(rubroArticulo.IdCertificateArticleItem > 0)
            {
                _systemAdministration.UpdateCertificateArticleItem(rubroArticulo);
                CargarRubrosArticulosCertificado();
            }
            LimpiarViewModel();
        }

        public void BorrarRubroArticulo()
        {
            _systemAdministration = new SystemAdministrationLogic();
            _systemAdministration.DeleteCertificateArticleItem(RubroSeleccionado);
        }

        public void  LimpiarViewModel()
        {
            IdRubroArticulo = 0;
            Nombre = string.Empty;
            Descripcion = string.Empty;
        }        
    }
}
