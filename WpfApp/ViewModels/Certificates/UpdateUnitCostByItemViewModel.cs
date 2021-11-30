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
    public class UpdateUnitCostByItemViewModel :ViewModelBase
    {
        private ISystemAdministrationLogic _systemAdministration = new SystemAdministrationLogic();
        public UpdateUnitCostByItemViewModel(int idRubroArticulo)
        {
            IdRubroArticulo = idRubroArticulo;
            ListasPrecios = new ObservableCollection<PriceList>();
            CargarListasPrecios();
        }

        private int _idRubroArticulo;
        public int IdRubroArticulo
        {
            get { return _idRubroArticulo; }
            set { SetProperty(ref _idRubroArticulo, value); }
        }

        private decimal _procentaje;
        public decimal Porcentaje
        {
            get { return _procentaje; }
            set { SetProperty(ref _procentaje, value); }
        }

        public void ActualizarCostosArticulos(string signo)
        {
            _systemAdministration.UpdateUnitCostByItem(IdRubroArticulo, Porcentaje, signo, ListaPreciosSeleccionada.IdPriceList);
        }

        private PriceList _ListaPrecios;
        public PriceList ListaPreciosSeleccionada
        {
            get { return _ListaPrecios; }
            set { SetProperty(ref _ListaPrecios, value); }
        }

        public ObservableCollection<PriceList> ListasPrecios { get; set; }


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
                }
                ListaPreciosSeleccionada = ListasPrecios.First();
            }
        }
    }
}
