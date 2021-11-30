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
    public class NewEmployeeViewModel: ViewModelBase
    {
        private ISystemAdministrationLogic _systemAdministration { get; set; }
        public NewEmployeeViewModel()
        {
            TiposEmpleado = new ObservableCollection<EmployeeType>();
            CargarTiposEmpleadoExistente();
            Nacimiento = DateTime.Now;
            Ingreso = DateTime.Now;
        }
        private int _idEmployee;
        public int IdEmployee
        {
            get { return _idEmployee; }
            set { SetProperty(ref _idEmployee, value); }
        }

        private string _nombres;
        public string Nombres
        {
            get { return _nombres; }
            set { SetProperty(ref _nombres, value); }
        }

        private string _apellidos;
        public string Apellidos
        {
            get { return _apellidos; }
            set { SetProperty(ref _apellidos, value); }
        }

        private string _direccion;
        public string Direccion
        {
            get { return _direccion; }
            set { SetProperty(ref _direccion, value); }
        }

        private DateTime _nacimiento;
        public DateTime Nacimiento
        {
            get { return _nacimiento; }
            set { SetProperty(ref _nacimiento, value); }
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

        private string _documento;
        public string Documento
        {
            get { return _documento; }
            set { SetProperty(ref _documento, value); }
        }

        private string _cuil;
        public string Cuil
        {
            get { return _cuil; }
            set { SetProperty(ref _cuil, value); }
        }

        private DateTime _ingreso;
        public DateTime Ingreso
        {
            get { return _ingreso; }
            set { SetProperty(ref _ingreso, value); }
        }

        private decimal _salarioAcordado;
        public decimal SalarioAcordado
        {
            get { return _salarioAcordado; }
            set { SetProperty(ref _salarioAcordado, value); }
        }

        public EmployeeType _tipoEmpleadoSeleccionado;
        public EmployeeType TipoEmpleadoSeleccionado
        {
            get { return _tipoEmpleadoSeleccionado; }
            set { SetProperty(ref _tipoEmpleadoSeleccionado, value); }
        }

        public ObservableCollection<EmployeeType> TiposEmpleado { get; set; }

        public bool GuardarEmpleado()
        {
            var empleado = MapearModelo();
            if(empleado != null)
            {
                _systemAdministration.InsertEmployee(empleado);
                return true;
            }               
            return false;
        }

        private Employee MapearModelo()
        {
            var empleado = new Employee();
            if (!string.IsNullOrEmpty(Nombres) && 
                !string.IsNullOrEmpty(Apellidos))
            {
                empleado.FirstName = Nombres;
                empleado.LastName = Apellidos;
                empleado.Address = Direccion;
                empleado.Birthdate = Nacimiento;
                empleado.PhoneNumber1 = Telefono1;
                empleado.PhoneNumber2 = Telefono2;
                empleado.DNI = Documento;
                empleado.Cuil = Cuil;
                empleado.AdmissionDate = Ingreso;
                empleado.EmployeeType = TipoEmpleadoSeleccionado;
                empleado.AgreedSalary = SalarioAcordado;
                return empleado;
            }
            return null;
        }

        public void CargarTiposEmpleadoExistente()
        {
            _systemAdministration = new SystemAdministrationLogic();
            var tiposEmpleado = _systemAdministration.GetAllEmployeeTypes();
            TiposEmpleado.Clear();
            if (tiposEmpleado.Any())
            {
                foreach (var item in tiposEmpleado)
                {
                    TiposEmpleado.Add(item);
                }
                TipoEmpleadoSeleccionado = TiposEmpleado.First();
            }
        }

        public void LimpiarViewModel()
        {
            Nombres = string.Empty;
            Apellidos = string.Empty;
            Direccion = string.Empty;
            Nacimiento = DateTime.Now;
            Telefono1 = string.Empty;
            Telefono2 = string.Empty;
            Documento = string.Empty;
            Cuil = string.Empty;
            Ingreso = DateTime.Now;
            TipoEmpleadoSeleccionado = TiposEmpleado.First();
        }
    }
}
