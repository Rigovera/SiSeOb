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
    public class UpdateWorkViewModel:ViewModelBase
    {
        private IWorksLogic _workLogic { get; set; }
        private ISystemAdministrationLogic _systemAdministration { get; set; }
        public UpdateWorkViewModel(Work work)
        {
            IdObra = work.IdWork;
            Nombre = work.Name;
            FechaInicio = work.StartDate;
            FechaFinPosible = work.PossibleEndDate;
            FechaFin = work.FinishDate;
            ListaTiposObra = new ObservableCollection<WorkType>();
            CargarTiposObra();
            TipoObraSeleccionado = ListaTiposObra.Single(x => x.IdWorkType == work.WorkType.IdWorkType);
            ListaUbicaciones = new ObservableCollection<Location>();
            CargarUbicaciones(); 
            UbicacionSeleccionada = ListaUbicaciones.Single(x => x.IdLocation == work.Location.IdLocation);
            ListaClientes = new ObservableCollection<Client>();
            CargarClientes();
            ClienteSeleccionado = ListaClientes.Single(x => x.IdClient == work.Client.IdClient);
            Descripcion = work.Description;
        }

        private int _idObra;
        public int IdObra
        {
            get { return _idObra; }
            set { SetProperty(ref _idObra, value); }
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

        private Nullable<DateTime> _fechaFin;
        public Nullable<DateTime> FechaFin
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
                obra.IdWork = IdObra;
                obra.Name = Nombre;
                obra.StartDate = FechaInicio;
                obra.PossibleEndDate = FechaFinPosible;
                obra.FinishDate = FechaFin;
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
            _workLogic.UpdateWork(obra);
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
