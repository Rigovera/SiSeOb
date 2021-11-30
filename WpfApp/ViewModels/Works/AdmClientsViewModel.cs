using CoreTier.SystemAdministration;
using CoreTier.Works;
using LogicTier.WorksLogic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.ViewModels.Works
{
    public class AdmClientsViewModel:ViewModelBase
    {
        private IWorksLogic _worksLogic { get; set; }
        public AdmClientsViewModel()
        {
            Clientes = new ObservableCollection<Client>();
            CargarClientes();
        }

        private int _idCliente;
        public int IdCliente
        {
            get { return _idCliente; }
            set { SetProperty(ref _idCliente, value); }
        }

        private string _nombre;
        public string Nombre
        {
            get { return _nombre; }
            set { SetProperty(ref _nombre, value); }
        }

        private string _documento;
        public string Documento
        {
            get { return _documento; }
            set { SetProperty(ref _documento, value); }
        }

        private string _direccion;
        public string Direccion
        {
            get { return _direccion; }
            set { SetProperty(ref _direccion, value); }
        }

        private string _telefono1;
        public string Telefono1
        {
            get { return _telefono1; }
            set { SetProperty(ref _telefono1, value); }
        }

        private string _telefono2;
        public string Telefono2
        {
            get { return _telefono2; }
            set { SetProperty(ref _telefono2, value); }
        }

        private Client _clienteSeleccionado;
        public Client ClienteSeleccionado
        {
            get { return _clienteSeleccionado; }
            set { SetProperty(ref _clienteSeleccionado, value); }
        }

        public ObservableCollection<Client> Clientes { get; set; }

        private Client MapearModelo()
        {
            var cliente = new Client();
            if (!string.IsNullOrEmpty(Nombre))
            {
                cliente.IdClient = IdCliente;
                cliente.Name = Nombre;
                cliente.CuitCuil= Documento;
                cliente.Address = Direccion;
                cliente.PhoneNumber1 = Telefono1;
                cliente.PhoneNumber2 = Telefono2;
                return cliente;
            }
            return null;
        }

        private void CargarClientes()
        {
            Clientes.Clear();
            _worksLogic = new WorksLogic();
            var clientes = _worksLogic.GetAllClients();
            if (clientes.Any())
            {
                foreach (var item in clientes)
                {
                    Clientes.Add(item);
                }
            }
        }

        public void GuardarCliente()
        {
            var cliente = MapearModelo();
            _worksLogic = new WorksLogic();
            if (cliente.IdClient == 0)
            {
                _worksLogic.InsertClient(cliente);
                Clientes.Add(cliente);
            }
            else if (cliente.IdClient > 0)
            {
                _worksLogic.UpdateClient(cliente);
                CargarClientes();
            }
            LimpiarViewModel();
        }

        public void BorrarTipoObra()
        {
            _worksLogic.DeleteClient(ClienteSeleccionado);
        }

        public void LimpiarViewModel()
        {
            IdCliente = 0;
            Nombre = string.Empty;
            Documento = string.Empty;
            Direccion = string.Empty;
            Telefono1 = string.Empty;
            Telefono2 = string.Empty;
        }
    }
}
