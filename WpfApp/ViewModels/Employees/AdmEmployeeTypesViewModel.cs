using CoreTier.SystemAdministration;
using LogicTier.SystemAdministrationLogic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp.ViewModels.Employees
{
    public class AdmEmployeeTypesViewModel : ViewModelBase
    {
        private ISystemAdministrationLogic _systemAdministration { get; set; }
        public AdmEmployeeTypesViewModel()
        {
            ListaTiposEmpleado = new ObservableCollection<EmployeeType>();
            CargarTiposEmpleadoExistente();
        }
        
        private int _idTipoEmpleado;
        public int IdTipoEmpleado
        {
            get { return _idTipoEmpleado; }
            set { SetProperty(ref _idTipoEmpleado, value); }
        }

        private string  _nombre;
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

        public ObservableCollection<EmployeeType> ListaTiposEmpleado { get; set; }

        public void GuardarTipoEmpleado()
        {
            _systemAdministration = new SystemAdministrationLogic();
            var tipoEmpleado = MapearModelo();
            if (tipoEmpleado.IdEmployeeType == 0)
            {
                _systemAdministration.InsertEmployeeType(tipoEmpleado);
                ListaTiposEmpleado.Add(tipoEmpleado);
            }                
            else if (tipoEmpleado.IdEmployeeType > 0)
            {
                _systemAdministration.UpdateEmployeeType(tipoEmpleado);
                CargarTiposEmpleadoExistente();
            }
            LimpiarViewModel();                               
        }

        private EmployeeType MapearModelo ()
        {
            var tipoEmpleado = new EmployeeType();
            if (!string.IsNullOrEmpty(Nombre))
            {
                tipoEmpleado.IdEmployeeType = IdTipoEmpleado;
                tipoEmpleado.Name = Nombre;
                tipoEmpleado.Description = Descripcion;                
                return tipoEmpleado;
            }
            return null;            
        }

        private void CargarTiposEmpleadoExistente()
        {
            _systemAdministration = new SystemAdministrationLogic();
            ListaTiposEmpleado.Clear();
            var tiposEmpleado = _systemAdministration.GetAllEmployeeTypes();
            if (tiposEmpleado.Any())
            {
                foreach(var item in tiposEmpleado)
                {
                    ListaTiposEmpleado.Add(item);
                }
            }
        }

        public void LimpiarViewModel()
        {
            IdTipoEmpleado = 0;
            Nombre = string.Empty;
            Descripcion = string.Empty;
        }
    }
}
