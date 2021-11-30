using CoreTier.SystemAdministration;
using CoreTier.Works;
using LogicTier.SystemAdministrationLogic;
using LogicTier.WorksLogic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.ViewModels.Works
{
    public class NewWorkViewModel:ViewModelBase
    {
        private IWorksLogic _workLogic { get; set; }
        private ISystemAdministrationLogic _systemAdministration { get; set; }
        public NewWorkViewModel()
        {
            ListaClientes = new ObservableCollection<Client>();
            ListaTiposObra = new ObservableCollection<WorkType>();
            ListaUbicaciones = new ObservableCollection<Location>();
            CargarClientes();
            CargarTiposObra();
            CargarUbicaciones();
            FechaInicio = DateTime.Now;
            FechaFinPosible = DateTime.Now;
        }

        private string _nombre;
        public string Nombre
        {
            get { return _nombre; }
            set { SetProperty(ref _nombre, value); }
        }

        private DateTime _fechaInicio;
        public DateTime FechaInicio
        {
            get { return _fechaInicio; }
            set { SetProperty(ref _fechaInicio, value); }
        }

        private DateTime _fechaFinPosible;
        public DateTime FechaFinPosible
        {
            get { return _fechaFinPosible; }
            set { SetProperty(ref _fechaFinPosible, value); }
        }

        private WorkType _tipoObraSeleccionada;
        public WorkType TipoObraSeleccionado
        {
            get { return _tipoObraSeleccionada; }
            set { SetProperty(ref _tipoObraSeleccionada, value); }
        }

        private Location _ubicacionSeleccionada;
        public Location UbicacionSeleccionada
        {
            get { return _ubicacionSeleccionada; }
            set { SetProperty(ref _ubicacionSeleccionada, value); }
        }

        private Client _clienteSeleccionado;
        public Client ClienteSeleccionado
        {
            get { return _clienteSeleccionado; }
            set { SetProperty(ref _clienteSeleccionado, value); }
        }

        private string _descripcion;
        public string Descripcion
        {
            get { return _descripcion; }
            set { SetProperty(ref _descripcion, value); }
        }

        public ObservableCollection<WorkType> ListaTiposObra { get; set; }
        public ObservableCollection<Location> ListaUbicaciones { get; set; }
        public ObservableCollection<Client> ListaClientes { get; set; }

        public void CargarTiposObra()
        {
            _systemAdministration = new SystemAdministrationLogic();
            var tiposObra = _systemAdministration.GetAllWorkTypes().OrderBy(x => x.Name);
            if (tiposObra.Any())
            {
                foreach (var item in tiposObra)
                {
                    ListaTiposObra.Add(item);
                }
                TipoObraSeleccionado = ListaTiposObra.First();
            }
        }

        public void CargarUbicaciones()
        {
            _systemAdministration = new SystemAdministrationLogic();
            var ubicaciones = _systemAdministration.GetAllLocations().OrderBy(x => x.Name);
            if (ubicaciones.Any())
            {
                foreach (var item in ubicaciones)
                {
                    ListaUbicaciones.Add(item);
                }
                UbicacionSeleccionada = ListaUbicaciones.First();
            }
        }

        public void CargarClientes()
        {
            _workLogic = new WorksLogic();
            var clientes = _workLogic.GetAllClients().OrderBy(x => x.Name);
            if (clientes.Any())
            {
                foreach (var item in clientes)
                {
                    ListaClientes.Add(item);
                }
                ClienteSeleccionado = ListaClientes.First();
            }
        }

        private Work MapearModelo()
        {
            var obra = new Work();
            if (!string.IsNullOrEmpty(Nombre))
            {
                obra.Name = Nombre;
                obra.StartDate = FechaInicio;
                obra.PossibleEndDate = FechaFinPosible;
                obra.FinishDate = FechaFinPosible;
                obra.Client = ClienteSeleccionado;
                obra.Location = UbicacionSeleccionada;
                obra.WorkType = TipoObraSeleccionado;
                obra.Description = Descripcion;
                return obra;
            }
            return null;
        }

        public void GuardarObra()
        {
            var obra = MapearModelo();
            _workLogic = new WorksLogic();
            _workLogic.InsertWork(obra);
        }

        public void LimpiarViewModel()
        {

            Nombre = string.Empty;
            Descripcion = string.Empty;
            TipoObraSeleccionado = ListaTiposObra.FirstOrDefault();
            UbicacionSeleccionada = ListaUbicaciones.FirstOrDefault();
            ClienteSeleccionado = ListaClientes.FirstOrDefault();
            FechaInicio = DateTime.Now;
            FechaFinPosible = DateTime.Now;
        }


    }
}
