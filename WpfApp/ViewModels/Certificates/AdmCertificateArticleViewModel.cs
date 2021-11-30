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
    public class AdmCertificateArticleViewModel: ViewModelBase
    {
        private ISystemAdministrationLogic _systemAdministration { get; set; }
        public AdmCertificateArticleViewModel()
        {
            ArticulosCertificado = new ObservableCollection<CertificateArticle>();
            Rubros = new ObservableCollection<CertificateArticleItem>();
            CargarArticulosCertificado();
            CargarRubrosArticulosCertificado();
        }

        private string _nombre;
        public string Nombre
        {
            get { return _nombre; }
            set { SetProperty(ref _nombre, value); }
        }

        public ObservableCollection<CertificateArticle> ArticulosCertificado { get; set; }

        private CertificateArticleItem _rubroSeleccionado;

        public CertificateArticleItem RubroSeleccionado
        {
            get { return _rubroSeleccionado; }
            set { SetProperty(ref _rubroSeleccionado, value); }
        }

        public ObservableCollection<CertificateArticleItem> Rubros { get; set; }

        public void CargarArticulosCertificado()
        {
            _systemAdministration = new SystemAdministrationLogic();
            ArticulosCertificado.Clear();
            var articulos = _systemAdministration.GetAllCertificateArticles();
            if (articulos.Any())
            {
                foreach (var item in articulos)
                {
                    ArticulosCertificado.Add(item);
                }
            }
        }

        private void CargarRubrosArticulosCertificado()
        {
            _systemAdministration = new SystemAdministrationLogic();
            Rubros.Clear();
            var rubrosArticulo = _systemAdministration.GetAllCertificateArticleItem();
            if (rubrosArticulo.Any())
            {
                Rubros.Add( new CertificateArticleItem() {Name = "Todos", IdCertificateArticleItem = 0});
                foreach (var item in rubrosArticulo)
                {
                    Rubros.Add(item);
                }
                RubroSeleccionado = Rubros.First();
            }
        }

        public void CargarArticulosPorRubro()
        {
            _systemAdministration = new SystemAdministrationLogic();
            ArticulosCertificado.Clear();
            if(RubroSeleccionado.IdCertificateArticleItem == 0)
            {
                CargarArticulosCertificado();
            }
            else
            {
                var articulos = _systemAdministration
                            .GetAllCertificateArticlesByCertificateArticleitem(RubroSeleccionado.IdCertificateArticleItem);
                if (articulos.Any())
                {
                    foreach (var item in articulos)
                    {
                        ArticulosCertificado.Add(item);
                    }
                }
            }            
        }

        public void CargarArticulosPorNombre()
        {
            _systemAdministration = new SystemAdministrationLogic();
            ArticulosCertificado.Clear();
            if(!string.IsNullOrEmpty(Nombre))
            {
                var articulos = _systemAdministration.GetAllCertificateArticlesWhoseNameContains(Nombre);
                if (articulos.Any())
                {
                    foreach (var item in articulos)
                    {
                        ArticulosCertificado.Add(item);
                    }
                }
            }            
        }
    }
}
