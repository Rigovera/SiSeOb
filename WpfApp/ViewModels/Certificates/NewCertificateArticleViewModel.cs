using CoreTier.SystemAdministration;
using LogicTier.SystemAdministrationLogic;
using Omu.ValueInjecter;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.ViewModels.Certificates
{
    public class NewCertificateArticleViewModel:ViewModelBase
    {
        private ISystemAdministrationLogic _systemAdministration { get; set; }
        public NewCertificateArticleViewModel()
        {
            Rubros = new ObservableCollection<CertificateArticleItem>();
            UnidadesMedida = new ObservableCollection<MeasurementUnit>();
            ListasPrecios = new ObservableCollection<PriceList>();
            PreciosArticulo = new ObservableCollection<ArticlePrices>();
            ListaPreciosSeleccionada = new PriceList();
            CargarRubrosArticulos();
            CargarUnidadesMedida();
            CargarListasPrecios();
            MostrarPrecioLista();
        }

        private int _idArticulo;
        public int IdArticulo
        {
            get { return _idArticulo; }
            set { SetProperty(ref _idArticulo, value); }
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

        private decimal _costoUnitario;
        public decimal CostoUnitario
        {
            get { return _costoUnitario; }
            set { SetProperty(ref _costoUnitario, value); }
        }

        private CertificateArticleItem _rubroSeleccionado;
        public CertificateArticleItem RubroSeleccionado
        {
            get { return _rubroSeleccionado; }
            set { SetProperty(ref _rubroSeleccionado, value); }
        }

        private MeasurementUnit _unidadMedida;
        public MeasurementUnit UnidadMedidaSeleccionada
        {
            get { return _unidadMedida; }
            set { SetProperty(ref _unidadMedida, value); }
        }

        private PriceList _listaPreciosSeleccionada;
        public PriceList ListaPreciosSeleccionada
        {
            get { return _listaPreciosSeleccionada; }
            set { SetProperty(ref _listaPreciosSeleccionada, value); }
        }

        public ObservableCollection<CertificateArticleItem> Rubros { get; set; }

        public ObservableCollection<MeasurementUnit> UnidadesMedida { get; set; }

        public ObservableCollection<PriceList> ListasPrecios { get; set; }

        public ObservableCollection<ArticlePrices> PreciosArticulo { get; set; }

        private CertificateArticle MapearModelo()
        {
            var articulo = new CertificateArticle();
            if (!string.IsNullOrEmpty(Nombre))
            {
                articulo.IdCertificateArticles = IdArticulo;
                articulo.Name = Nombre;
                articulo.Description = Descripcion;
                articulo.UnitCost = CostoUnitario;
                articulo.CertificateArticleItem = RubroSeleccionado;
                articulo.MeasurementUnit = UnidadMedidaSeleccionada;
                articulo.ArticlePrices = PreciosArticulo.ToList();
                foreach(var item in articulo.ArticlePrices)
                {
                    item.CertificateArticle = articulo;
                } 
                return articulo;
            }
            return null;
        }

        public void AgregarPrecioLista()
        {
            if(!PreciosArticulo.Any(x => x.PriceList.IdPriceList == ListaPreciosSeleccionada.IdPriceList))
            {
                var precioArticulo = new ArticlePrices
                {
                    UnitCost = CostoUnitario,
                };
                precioArticulo.PriceList = new PriceList();
                precioArticulo.PriceList.InjectFrom(ListaPreciosSeleccionada);
                PreciosArticulo.Add(precioArticulo);
            }
            else
            {
                var precioArticulo = PreciosArticulo
                    .First(x => x.PriceList.IdPriceList == ListaPreciosSeleccionada.IdPriceList);
                precioArticulo.UnitCost = CostoUnitario;
            }            
        }

        public void MostrarPrecioLista()
        {
            if (PreciosArticulo.Any(x => x.PriceList.IdPriceList == ListaPreciosSeleccionada.IdPriceList))
            {
                CostoUnitario = PreciosArticulo
                    .First(x => x.PriceList.IdPriceList == ListaPreciosSeleccionada.IdPriceList).UnitCost;
            }
            else
                CostoUnitario = 0;
        }

        public void CargarRubrosArticulos()
        {
            _systemAdministration = new SystemAdministrationLogic();
            var rubros = _systemAdministration.GetAllCertificateArticleItem();
            Rubros.Clear();
            if (rubros.Any())
            {
                foreach (var item in rubros)
                {
                    Rubros.Add(item);
                }
                RubroSeleccionado = Rubros.First();
            }
        }

        public void CargarUnidadesMedida()
        {
            _systemAdministration = new SystemAdministrationLogic();
            var unidades = _systemAdministration.GetAllMeasurementUnit();
            UnidadesMedida.Clear();
            if (unidades.Any())
            {
                foreach (var item in unidades)
                {
                    UnidadesMedida.Add(item);
                }
                UnidadMedidaSeleccionada = UnidadesMedida.First();
            }
        }

        public void CargarListasPrecios()
        {
            _systemAdministration = new SystemAdministrationLogic();
            var listasPrecios = _systemAdministration.GetAllPriceLists();
            ListasPrecios.Clear();
            if (listasPrecios.Any())
            {
                foreach (var item in listasPrecios)
                {
                    ListasPrecios.Add(item);
                    var precioArticulo = new ArticlePrices();
                    precioArticulo.PriceList = new PriceList();
                    precioArticulo.PriceList.InjectFrom(item);
                    PreciosArticulo.Add(precioArticulo);
                }
                ListaPreciosSeleccionada = ListasPrecios.First();
            }
        }

        public void GuardarArtituculo()
        {
            _systemAdministration = new SystemAdministrationLogic();
            var articulo = MapearModelo();
            _systemAdministration.InsertCertificateArticle(articulo);            
        }

        public void LimpiarViewModel()
        {
            IdArticulo = 0;
            Nombre = string.Empty;
            Descripcion = string.Empty;
            CostoUnitario = 0;
        }
    }
}
