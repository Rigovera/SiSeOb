using CoreTier.SystemAdministration;
using LogicTier.SystemAdministrationLogic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.ViewModels.Works
{
    public class AdmLocationViewModel:ViewModelBase
    {
        private ISystemAdministrationLogic _systemAdministration { get; set; }
        public AdmLocationViewModel()
        {
            Ubicaciones = new ObservableCollection<Location>();
            CargarUbicaciones();
        }

        private int _idUbicacion;
        public int IdUbicacion
        {
            get { return _idUbicacion; }
            set { SetProperty(ref _idUbicacion, value); }
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

        private Location _ubicacionSeleccionada;
        public Location UbicacionSeleccionada
        {
            get { return _ubicacionSeleccionada; }
            set { SetProperty(ref _ubicacionSeleccionada, value); }
        }

        public ObservableCollection<Location> Ubicaciones { get; set; }

        private Location MapearModelo()
        {
            var ubicacion = new Location();
            if (!string.IsNullOrEmpty(Nombre))
            {
                ubicacion.IdLocation = IdUbicacion;
                ubicacion.Name = Nombre;
                ubicacion.Description = Descripcion;
                return ubicacion;
            }
            return null;
        }

        private void CargarUbicaciones()
        {
            Ubicaciones.Clear();
            _systemAdministration = new SystemAdministrationLogic();
            var ubicaciones = _systemAdministration.GetAllLocations();
            if (ubicaciones.Any())
            {
                foreach (var item in ubicaciones)
                {
                    Ubicaciones.Add(item);
                }
            }
        }

        public void GuardarUbicacion()
        {
            var ubicacion = MapearModelo();
            _systemAdministration = new SystemAdministrationLogic();
            if (ubicacion.IdLocation == 0)
            {
                _systemAdministration.InsertLocation(ubicacion);
                Ubicaciones.Add(ubicacion);
            }
            else if (ubicacion.IdLocation > 0)
            {
                _systemAdministration.UpdateLocation(ubicacion);
                CargarUbicaciones();
            }
            LimpiarViewModel();
        }

        public void BorrarTipoObra()
        {
            _systemAdministration.DeleteLocation(UbicacionSeleccionada);
        }

        public void LimpiarViewModel()
        {
            IdUbicacion = 0;
            Nombre = string.Empty;
            Descripcion = string.Empty;
        }
    }
}
