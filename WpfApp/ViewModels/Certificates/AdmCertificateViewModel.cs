using CoreTier.Certificates;
using CoreTier.SystemAdministration;
using CoreTier.Works;
using LogicTier.CertificatesLogic;
using LogicTier.SystemAdministrationLogic;
using Omu.ValueInjecter;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp.ViewModels.Certificates
{
    public class AdmCertificateViewModel : ViewModelBase
    {
        private ICertificasteLogic _certificateLogic { get; set; }
        private ISystemAdministrationLogic _systemAdministration { get; set; }
        public AdmCertificateViewModel(Work obra)
        {
            DetalleCertificado = new ObservableCollection<CertificateDetail>();
            TipoCertificadoSeleccionado = new CertificateType();
            RubroSeleccionado = new CertificateArticleItem();
            ArticuloSeleccionado = new CertificateArticle();
            PrecioSeleccionado = new ArticlePrices();

            ListaRubrosArticulosCertificado = new ObservableCollection<CertificateArticleItem>();
            CargarRubrosArticulosCertificado();

            ListaCertificadosObra = new ObservableCollection<Certificate>();
            CargarCertificadosObra(obra);

            ArticulosCertificado = new ObservableCollection<CertificateArticle>();
            CargarArticulosCertificado();

            TiposCertificado = new ObservableCollection<CertificateType>();
            CargarTiposCertificado();

            ObraSeleccionada = obra;
            PreciosArticuloSeleccionado = new ObservableCollection<ArticlePrices>();
            Cantidad = 1;
        }

        private Work _obraSeleccionada;
        public Work ObraSeleccionada
        {
            get { return _obraSeleccionada; }
            set { SetProperty(ref _obraSeleccionada, value); }
        }

        private int _idCertificado;
        public int IdCertificado
        {
            get { return _idCertificado; }
            set { SetProperty(ref _idCertificado, value); }
        }

        private CertificateArticleItem _rubroSeleccionado;
        public CertificateArticleItem RubroSeleccionado
        {
            get { return _rubroSeleccionado; }
            set { SetProperty(ref _rubroSeleccionado, value); }
        }

        private CertificateType _tipoCertificadoSeleccionado;
        public CertificateType TipoCertificadoSeleccionado
        {
            get { return _tipoCertificadoSeleccionado; }
            set { SetProperty(ref _tipoCertificadoSeleccionado, value); }
        }

        private Certificate _certificadoSeleccionado;
        public Certificate CertificadoSeleccionado
        {
            get { return _certificadoSeleccionado; }
            set { SetProperty(ref _certificadoSeleccionado, value); }
        }

        private ArticlePrices _precioSeleccionado;
        public ArticlePrices PrecioSeleccionado
        {
            get { return _precioSeleccionado; }
            set { SetProperty(ref _precioSeleccionado, value); }
        }

        private CertificateArticle _articuloSeleccionado;
        public CertificateArticle ArticuloSeleccionado
        {
            get { return _articuloSeleccionado; }
            set { SetProperty(ref _articuloSeleccionado, value); }
        }

        private decimal _avance;
        public decimal Avance
        {
            get { return _avance; }
            set { SetProperty(ref _avance, value); }
        }

        private decimal _montoTotal;
        public decimal MontoTotal
        {
            get { return _montoTotal; }
            set { SetProperty(ref _montoTotal, value); }
        }


        private int _cantidad;
        public int Cantidad
        {
            get { return _cantidad; }
            set { SetProperty(ref _cantidad, value); }
        }


        public ObservableCollection<CertificateArticleItem> ListaRubrosArticulosCertificado { get; set; }
        public ObservableCollection<CertificateDetail> DetalleCertificado { get; set; }
        public ObservableCollection<Certificate> ListaCertificadosObra { get; set; }
        public ObservableCollection<CertificateArticle> ArticulosCertificado { get; set; }
        public ObservableCollection<CertificateType> TiposCertificado { get; set; }
        public ObservableCollection<ArticlePrices> PreciosArticuloSeleccionado { get; set; }

        private void CargarRubrosArticulosCertificado()
        {
            _systemAdministration = new SystemAdministrationLogic();
            ListaRubrosArticulosCertificado.Clear();
            var rubrosArticulo = _systemAdministration.GetAllCertificateArticleItem();
            if (rubrosArticulo.Any())
            {
                ListaRubrosArticulosCertificado.Add(new CertificateArticleItem() { Name = "Todos", IdCertificateArticleItem = 0 });
                foreach (var item in rubrosArticulo)
                {
                    ListaRubrosArticulosCertificado.Add(item);
                }
            }
        }

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

        public void CargarTiposCertificado()
        {
            _systemAdministration = new SystemAdministrationLogic();
            TiposCertificado.Clear();
            var tiposCertificado = _systemAdministration.GetAllCertificateTypes();
            if (tiposCertificado.Any())
            {
                foreach (var item in tiposCertificado)
                {
                    //var tienePresupuestoCreado = ListaCertificadosObra.Any(x => x.CertificateType.IdCertificateType == 1);
                    //if(!tienePresupuestoCreado || item.IdCertificateType != 1)
                    TiposCertificado.Add(item);
                }
                TipoCertificadoSeleccionado = tiposCertificado.First();
            }
        }

        public void MostrarPreciosArticulo()
        {
            PreciosArticuloSeleccionado.Clear();
            foreach (var item in ArticuloSeleccionado.ArticlePrices)
            {
                var precio = new ArticlePrices
                {
                    UnitCost = item.UnitCost,
                    IdArticlePrices = item.IdArticlePrices,
                    PriceList = new PriceList()
                };
                precio.PriceList.Name = item.PriceList.Name + " $" + item.UnitCost.ToString();
                PreciosArticuloSeleccionado.Add(precio);
            }
            PrecioSeleccionado = PreciosArticuloSeleccionado.First();
        }

        public void CalcularTotalArticuloDetalle()
        {
            if (PrecioSeleccionado != null)
            {
                var articulo = new CertificateArticle();
                articulo.InjectFrom(ArticuloSeleccionado);
                articulo.UnitCost = Cantidad * PrecioSeleccionado.UnitCost;
                ArticuloSeleccionado = null;
                ArticuloSeleccionado = articulo;
            }
        }

        public bool AgregarArticuloCertificado()
        {
            var resultado = false;
            var articuloDetalle = new CertificateDetail
            {
                CertificateArticle = new CertificateArticle()
            };

            var validado = true;
            if (TipoCertificadoSeleccionado.IdCertificateType == (int)CertificateTypeEnum.Avance ||
                TipoCertificadoSeleccionado.IdCertificateType == (int)CertificateTypeEnum.Finalizacion)
            {
                validado = ValidarContraPresupuesto();
            }

            if (validado)
            {
                if (!DetalleCertificado
               .Any(x => x.CertificateArticle.IdCertificateArticles == ArticuloSeleccionado.IdCertificateArticles))
                {
                    articuloDetalle.CertificateArticle.InjectFrom(ArticuloSeleccionado);
                    articuloDetalle.UnitCost = PrecioSeleccionado.UnitCost;
                    articuloDetalle.TotalCost = PrecioSeleccionado.UnitCost * Cantidad;
                    articuloDetalle.Quantity = Cantidad;
                    DetalleCertificado.Add(articuloDetalle);
                }
                else
                {
                    articuloDetalle = DetalleCertificado
                        .Single(x => x.CertificateArticle.IdCertificateArticles == ArticuloSeleccionado.IdCertificateArticles);

                    articuloDetalle.UnitCost = PrecioSeleccionado.UnitCost;
                    articuloDetalle.TotalCost = PrecioSeleccionado.UnitCost * Cantidad;
                    articuloDetalle.Quantity = Cantidad;
                    DetalleCertificado.Remove(articuloDetalle);
                    DetalleCertificado.Add(articuloDetalle);
                }
                resultado = true;
            }
            MontoTotal = DetalleCertificado.Sum(x => x.TotalCost);
            return resultado;
        }

        public void CargarCertificadosObra(Work obra)
        {
            _certificateLogic = new CertificatesLogic();
            var certificadosObra = _certificateLogic.GetAllCertificates(obra);
            ListaCertificadosObra.Clear();
            foreach (var certificado in certificadosObra)
            {
                ListaCertificadosObra.Add(certificado);
            }
        }

        private Certificate MapearModelo()
        {
            var certificado = new Certificate();
            if (Avance >= 0 && DetalleCertificado.Count >= 0)
            {
                certificado.IdCertificate = IdCertificado;
                certificado.WorkProgress = Avance;
                certificado.TotalAmount = MontoTotal;
                certificado.CertificateType = TipoCertificadoSeleccionado;
                certificado.Work = ObraSeleccionada;
                certificado.CreationDate = DateTime.Now;
                certificado.CertificateDetail = new List<CertificateDetail>();
                foreach (var item in DetalleCertificado)
                {
                    certificado.CertificateDetail.Add(item);
                }
                return certificado;
            }
            return null;
        }

        public void GuardarCertificado()
        {
            var certificado = MapearModelo();
            if (certificado != null)
            {
                _certificateLogic = new CertificatesLogic();
                if (certificado.IdCertificate == 0)
                    _certificateLogic.InsertCertificate(certificado);
                else
                    _certificateLogic.UpdateCertificate(certificado);
            }
        }

        public void LimpiarViewModel()
        {
            Avance = 0;
            TipoCertificadoSeleccionado = TiposCertificado.First();
            DetalleCertificado.Clear();
        }

        public void QuitarArticuloDetalle(CertificateDetail articuloDetalle)
        {
            var articuloPorBorrar = DetalleCertificado
                .Single(x => x.CertificateArticle.IdCertificateArticles == articuloDetalle.CertificateArticle.IdCertificateArticles);

            DetalleCertificado.Remove(articuloPorBorrar);
            MontoTotal = DetalleCertificado.Sum(x => x.TotalCost);
        }

        public void CargarArticulosDisponiblesPorTipo()
        {
            _systemAdministration = new SystemAdministrationLogic();
            ArticulosCertificado.Clear();
            if (RubroSeleccionado.IdCertificateArticleItem == 0)
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

        public bool ValidarContraPresupuesto()
        {
            bool resultado = false;

            var presupuesto = ListaCertificadosObra.
                SingleOrDefault(x => x.CertificateType.IdCertificateType == (int)CertificateTypeEnum.Presupuesto);

            var cantidadEnPresupuesto = 0;
            var articuloEnPresupuesto = presupuesto.CertificateDetail.
                SingleOrDefault(x => x.CertificateArticle.IdCertificateArticles == ArticuloSeleccionado.IdCertificateArticles);

            if (articuloEnPresupuesto != null)
                cantidadEnPresupuesto = articuloEnPresupuesto.Quantity;

            var avances = ListaCertificadosObra.
                Where(x => x.CertificateType.IdCertificateType == TipoCertificadoSeleccionado.IdCertificateType).ToList();

            var cantidadEnAvances = 0;
            foreach (var item in avances)
            {
                if (item.CertificateDetail != null)
                {
                    cantidadEnAvances += item.CertificateDetail
                        .Where(x => x.CertificateArticle.IdCertificateArticles == ArticuloSeleccionado.IdCertificateArticles)
                        .Sum(x => x.Quantity);
                }
            }

            if ((cantidadEnAvances + Cantidad) <= cantidadEnPresupuesto)
                resultado = true;

            return resultado;
        }
    }
}
