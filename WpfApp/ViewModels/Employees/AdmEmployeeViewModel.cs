using CoreTier.SystemAdministration;
using LogicTier.SystemAdministrationLogic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.ViewModels.Employees
{
    public class AdmEmployeeViewModel:ViewModelBase
    {
        private ISystemAdministrationLogic _systemAdministration { get; set; }
        public AdmEmployeeViewModel()
        {
            Empleados = new ObservableCollection<Employee>();
            TiposEmpleado = new ObservableCollection<EmployeeType>();            
            CargarTiposEmpleadoExistente();
            CargarEmpleadosExistente();
        }

        public ObservableCollection<Employee> Empleados { get; set; }

        private EmployeeType _tiposEmpleadoSeleccionado;
        public EmployeeType TiposEmpleadoSeleccionado
        {
            get { return _tiposEmpleadoSeleccionado; }
            set { SetProperty(ref _tiposEmpleadoSeleccionado, value); }
        }

        public ObservableCollection<EmployeeType> TiposEmpleado { get; set; }

        private EmployeeType _tipoEmpleadoSeleccionado;
        public EmployeeType TipoEmpleadoSeleccionado
        {
            get { return _tipoEmpleadoSeleccionado; }
            set { SetProperty(ref _tipoEmpleadoSeleccionado, value); }
        }

        private string _nombre;
        public string Nombre
        {
            get { return _nombre; }
            set { SetProperty(ref _nombre, value); }
        }

        private string _apellido;
        public string Apellido
        {
            get { return _apellido; }
            set { SetProperty(ref _apellido, value); }
        }

        private string _dni;
        public string DNI
        {
            get { return _dni; }
            set { SetProperty(ref _dni, value); }
        }

        private DateTime? _ingreso;
        public DateTime? Ingreso
        {
            get { return _ingreso; }
            set { SetProperty(ref _ingreso, value); }
        }

        public void CargarEmpleadosExistente()
        {
            _systemAdministration = new SystemAdministrationLogic();
            Empleados.Clear();
            var empleados = _systemAdministration.GetAllEmployees();
            if (empleados.Any())
            {
                foreach (var item in empleados)
                {
                    Empleados.Add(item);
                }
            }
        }

        private void CargarTiposEmpleadoExistente()
        {
            _systemAdministration = new SystemAdministrationLogic();
            TiposEmpleado.Clear();
            var tiposEmpleado = _systemAdministration.GetAllEmployeeTypes();
            if (tiposEmpleado.Any())
            {
                foreach (var item in tiposEmpleado)
                {
                    TiposEmpleado.Add(item);
                }
            }
        }

        public void CargarEmpleadosPorDNI()
        {
            Empleados.Clear();
            _systemAdministration = new SystemAdministrationLogic();
            var empleados = _systemAdministration.GetAllEmployeesWhoseDNIContains(DNI);
            if (empleados.Any())
            {
                foreach (var item in empleados)
                {
                    Empleados.Add(item);
                }
            }
        }

        public void CargarEmpleadosPorNombre()
        {
            Empleados.Clear();
            _systemAdministration = new SystemAdministrationLogic();
            var empleados = _systemAdministration.GetAllEmployeesWhoseFirstNameContains(Nombre);
            if (empleados.Any())
            {
                foreach (var item in empleados)
                {
                    Empleados.Add(item);
                }
            }
        }

        public void CargarEmpleadosPorApellido()
        {
            Empleados.Clear();
            _systemAdministration = new SystemAdministrationLogic();
            var empleados = _systemAdministration.GetAllEmployeesWhoseLastNameContains(Apellido);
            if (empleados.Any())
            {
                foreach (var item in empleados)
                {
                    Empleados.Add(item);
                }
            }
        }

        public void CargarEmpleadosPorTipo()
        {
            Empleados.Clear();
            _systemAdministration = new SystemAdministrationLogic();
            var empleados = _systemAdministration.GetAllEmployeesByType(TipoEmpleadoSeleccionado.IdEmployeeType);
            if (empleados.Any())
            {
                foreach (var item in empleados)
                {
                    Empleados.Add(item);
                }
            }
        }

        public void CargarEmpleadosPorFechaIngreso()
        {
            if (Ingreso != null)
            {
                _systemAdministration = new SystemAdministrationLogic();
                var empleados = _systemAdministration.GetAllEmployessByAdmissionDate(Ingreso.Value);
                if (empleados.Any())
                {
                    Empleados.Clear();
                    foreach (var item in empleados)
                    {
                        Empleados.Add(item);
                    }
                }
            }                
        }
    }
}
