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
    public class AdmPriceListsViewModel : ViewModelBase
    {
        private ISystemAdministrationLogic _systemAdministration { get; set; }
        public AdmPriceListsViewModel()
        {
            ListasPrecios = new ObservableCollection<PriceList>();
            CargarListasPrecios();
        }
        private int _idListaPrecio;
        public int IdListaPrecio
        {
            get { return _idListaPrecio; }
            set { SetProperty(ref _idListaPrecio, value); }
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

        private PriceList _listaPrecios;
        public PriceList ListaPreciosSeleccionada
        {
            get { return _listaPrecios; }
            set { SetProperty(ref _listaPrecios, value); }
        }

        public ObservableCollection<PriceList> ListasPrecios { get; set; }

        private PriceList MapearModelo()
        {
            var listaPrecios = new PriceList();
            if (!string.IsNullOrEmpty(Nombre))
            {
                listaPrecios.IdPriceList = IdListaPrecio;
                listaPrecios.Name = Nombre;
                listaPrecios.Description = Descripcion;
                return listaPrecios;
            }
            return null;
        }

        private void CargarListasPrecios()
        {
            _systemAdministration = new SystemAdministrationLogic();
            ListasPrecios.Clear();
            var listasPrecios = _systemAdministration.GetAllPriceLists();
            if (listasPrecios.Any())
            {
                foreach (var item in listasPrecios)
                {
                    ListasPrecios.Add(item);
                }
                ListaPreciosSeleccionada = ListasPrecios.First();
            }
        }

        public void GuardarListaPrecios()
        {
            _systemAdministration = new SystemAdministrationLogic();
            var listaPrecios = MapearModelo();

            if (listaPrecios.IdPriceList == 0)
            {
                _systemAdministration.InsertPriceList(listaPrecios);
                ListasPrecios.Add(listaPrecios);
            }
            else if (listaPrecios.IdPriceList > 0)
            {
                _systemAdministration.UpdatePriceList(listaPrecios);
                CargarListasPrecios();
            }
            LimpiarViewModel();
        }

        public void LimpiarViewModel()
        {
            IdListaPrecio = 0;
            Nombre = string.Empty;
            Descripcion = string.Empty;
        }
    }
}
