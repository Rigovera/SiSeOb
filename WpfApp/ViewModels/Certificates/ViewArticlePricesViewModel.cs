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
    public class ViewArticlePricesViewModel : ViewModelBase
    {
        private ISystemAdministrationLogic _systemAdministration { get; set; }
        public ViewArticlePricesViewModel(int idArticulo)
        {
            PreciosArticulo = new ObservableCollection<ArticlePrices>();
            CargarPreciosArticulo(idArticulo);
        }

        private decimal _procentaje;
        public decimal Porcentaje
        {
            get { return _procentaje; }
            set { SetProperty(ref _procentaje, value); }
        }

        private ArticlePrices _precioArticulo;
        public ArticlePrices PrecioArticuloSeleccionado
        {
            get { return _precioArticulo; }
            set { SetProperty(ref _precioArticulo, value); }
        }

        public ObservableCollection<ArticlePrices> PreciosArticulo { get; set; }

        public void CargarPreciosArticulo(int idArticulo)
        {
            _systemAdministration = new SystemAdministrationLogic();
            PreciosArticulo.Clear();
            var precios = _systemAdministration.GetArticlePricesByIdCertificateArticle(idArticulo);
            if (precios.Any())
            {
                foreach (var item in precios)
                {
                    PreciosArticulo.Add(item);
                }
            }
        }

        public void AjustarPrecio(string signo)
        {
            var nuevoCostoUnitario = 0m;
            if (signo == "+")
                nuevoCostoUnitario = PrecioArticuloSeleccionado.UnitCost + ((PrecioArticuloSeleccionado.UnitCost / 100) * Porcentaje);
            else if (signo == "-")
                nuevoCostoUnitario = PrecioArticuloSeleccionado.UnitCost - ((PrecioArticuloSeleccionado.UnitCost / 100) * Porcentaje);

            var precio = PreciosArticulo.First(x => x.IdArticlePrices == PrecioArticuloSeleccionado.IdArticlePrices);
            precio.UnitCost = nuevoCostoUnitario;
            _systemAdministration.UpdateArticlePrice(precio);
            CargarPreciosArticulo(precio.CertificateArticle.IdCertificateArticles);
        }
    }
}
