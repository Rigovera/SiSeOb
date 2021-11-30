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
    public class AdmWoksViewModel :ViewModelBase
    {
        private IWorksLogic _workLogic { get; set; }
        private ISystemAdministrationLogic _systemAdministration { get; set; }
        public AdmWoksViewModel()
        {
            ListaClientes = new ObservableCollection<Client>();
            ListaTiposObra = new ObservableCollection<WorkType>();
            ListaUbicaciones = new ObservableCollection<Location>();
            CargarClientes();
            CargarTiposObra();
            CargarUbicaciones();
            Obras = new ObservableCollection<Work>();
            CargarObras();
        }

        private string _nombre;
        public string Nombre
        {
            get { return _nombre; }
            set { SetProperty(ref _nombre, value); }
        }

        private DateTime? _fechaInicio;
        public DateTime? FechaInicio
        {
            get { return _fechaInicio; }
            set { SetProperty(ref _fechaInicio, value); }
        }

        private DateTime? _fechaFinPosible;
        public DateTime? FechaFinPosible
        {
            get { return _fechaFinPosible; }
            set { SetProperty(ref _fechaFinPosible, value); }
        }

        private DateTime? _fechaFin;
        public DateTime? FechaFin
        {
            get { return _fechaFin; }
            set { SetProperty(ref _fechaFin, value); }
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

        public ObservableCollection<WorkType> ListaTiposObra { get; set; }
        public ObservableCollection<Location> ListaUbicaciones { get; set; }
        public ObservableCollection<Client> ListaClientes { get; set; }
        public ObservableCollection<Work> Obras { get; set; }

        public void CargarTiposObra()
        {
            _systemAdministration = new SystemAdministrationLogic();
            var tiposObra = _systemAdministration.GetAllWorkTypes().OrderBy(x => x.Name);
            if (tiposObra.Any())
            {
                //ListaTiposObra.Add(new WorkType() {Name = "Todos", IdWorkType = 0 });
                foreach (var item in tiposObra)
                {
                    ListaTiposObra.Add(item);
                }
                //TipoObraSeleccionado = ListaTiposObra.First();
            }
        }

        public void CargarUbicaciones()
        {
            _systemAdministration = new SystemAdministrationLogic();
            var ubicaciones = _systemAdministration.GetAllLocations().OrderBy(x => x.Name);
            if (ubicaciones.Any())
            {
                //ListaUbicaciones.Add(new Location() { Name = "Todas", IdLocation = 0 });
                foreach (var item in ubicaciones)
                {
                    ListaUbicaciones.Add(item);
                }
                //UbicacionSeleccionada = ListaUbicaciones.First();
            }
        }

        public void CargarClientes()
        {
            _workLogic = new WorksLogic();
            var clientes = _workLogic.GetAllClients().OrderBy(x => x.Name);
            if (clientes.Any())
            {
                //ListaClientes.Add( new Client() {Name = "Todos", IdClient = 0});
                foreach (var item in clientes)
                {
                    ListaClientes.Add(item);
                }
                //ClienteSeleccionado = ListaClientes.First();
            }
        }

        public void CargarObras()
        {
            Obras.Clear();
            _workLogic = new WorksLogic();
            var obras = _workLogic.GetAllWorks();
            if (obras.Any())
            {
                foreach (var item in obras)
                {
                    Obras.Add(item);
                }
            }
        }

        public void CargarObrasPorNombre()
        {
            Obras.Clear();
            _workLogic = new WorksLogic();
            var obras = _workLogic.GetAllWorksWhoseNameContains(Nombre);
            if (obras != null && obras.Any())
            {
                foreach (var item in obras)
                {
                    Obras.Add(item);
                }
            }
        }

        public void CargarObrasPorTipo()
        {
            Obras.Clear();
            _workLogic = new WorksLogic();
            var obras = _workLogic.GetAllWorksByWorkType(TipoObraSeleccionado.IdWorkType);
            if (obras.Any())
            {
                foreach (var item in obras)
                {
                    Obras.Add(item);
                }
            }
        }

        public void CargarObrasPorUbicacion()
        {
            Obras.Clear();
            _workLogic = new WorksLogic();
            var obras = _workLogic.GetAllWorksByLocation(UbicacionSeleccionada.IdLocation);
            if (obras.Any())
            {
                foreach (var item in obras)
                {
                    Obras.Add(item);
                }
            }
        }

        public void CargarObrasPorCliente()
        {
            Obras.Clear();
            _workLogic = new WorksLogic();
            var obras = _workLogic.GetAllWorksByClient(ClienteSeleccionado.IdClient);
            if (obras.Any())
            {
                foreach (var item in obras)
                {
                    Obras.Add(item);
                }
            }
        }

        public void CargarObrasPorFechaInicio()
        {            
            if(FechaInicio != null)
            {
                _workLogic = new WorksLogic();
                var obras = _workLogic.GetAllWorksByStartDate(Convert.ToDateTime(FechaInicio));
                if (obras.Any())
                {
                    Obras.Clear();
                    foreach (var item in obras)
                    {
                        Obras.Add(item);
                    }
                }
            }          
        }

        public void CargarObrasPorFechaPosibleFin()
        {
            if(FechaFinPosible != null)
            {
                _workLogic = new WorksLogic();
                var obras = _workLogic.GetAllWorksByPossibleEndDate(Convert.ToDateTime(FechaFinPosible));
                if (obras.Any())
                {
                    Obras.Clear();
                    foreach (var item in obras)
                    {
                        Obras.Add(item);
                    }
                }
            }           
        }

        public void CargarObrasPorFechaFin()
        {
            if(FechaFin != null)
            {
                _workLogic = new WorksLogic();
                var obras = _workLogic.GetAllWorksByFinishDate(Convert.ToDateTime(FechaFin));
                if (obras.Any())
                {
                    Obras.Clear();
                    foreach (var item in obras)
                    {
                        Obras.Add(item);
                    }
                }
            }
        }
    }
}
