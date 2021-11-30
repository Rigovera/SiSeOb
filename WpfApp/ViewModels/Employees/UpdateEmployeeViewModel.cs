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
    public class UpdateEmployeeViewModel:ViewModelBase
    {
        private ISystemAdministrationLogic _systemAdministration = new SystemAdministrationLogic();

        public UpdateEmployeeViewModel(Employee employee)
        {
            IdEmpleado = employee.IdEmployee;
            Nombres = employee.FirstName;
            Apellidos = employee.LastName;
            Direccion = employee.Address;
            Nacimiento = employee.Birthdate;
            Telefono1 = employee.PhoneNumber1;
            Telefono2 = employee.PhoneNumber2;
            Documento = employee.DNI;
            Cuil = employee.Cuil;
            Ingreso = employee.AdmissionDate;
            SalarioAcordado = employee.AgreedSalary;
            TiposEmpleado = new ObservableCollection<EmployeeType>();
            CargarTiposEmpleadoExistente();
            TipoEmpleadoSeleccionado = TiposEmpleado
                .Single(x=> x.IdEmployeeType == employee.EmployeeType.IdEmployeeType);
        }
        private int _idEmpleado;
        public int IdEmpleado
        {
            get { return _idEmpleado; }
            set { SetProperty(ref _idEmpleado, value); }
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
            if (empleado != null)
            {
                _systemAdministration.UpdateEmployee(empleado);
                return true;
            }
            return false;
        }

        private Employee MapearModelo()
        {
            var empleado = new Employee();
            if (!string.IsNullOrEmpty(Nombres) && !string.IsNullOrEmpty(Apellidos))
            {
                empleado.IdEmployee = IdEmpleado;
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

        private void CargarTiposEmpleadoExistente()
        {
            var tiposEmpleado = _systemAdministration.GetAllEmployeeTypes();
            if (tiposEmpleado.Any())
            {
                foreach (var item in tiposEmpleado)
                {
                    TiposEmpleado.Add(item);
                }                
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
        }
    }
}
