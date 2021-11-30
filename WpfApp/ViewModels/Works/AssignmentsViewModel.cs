using CoreTier.Assignments;
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
    public class AssignmentsViewModel:ViewModelBase
    {
        private IWorksLogic _workLogic { get; set; }
        private ISystemAdministrationLogic _systemAdministration { get; set; }
        public AssignmentsViewModel(Work work)
        {
            EmpleadosDisponibles = new ObservableCollection<Employee>();
            HerramientasDisponibles = new ObservableCollection<Tool>();
            CargarEmpleadosDisponibles();
            CargarHerramientasDisponibles();
            EmpleadosAsignados = new ObservableCollection<AssignedEmployee>();
            HerramientasAsignadas = new ObservableCollection<AssignedTool>();
            EmpleadosLiberados = new ObservableCollection<AssignedEmployee>();
            HerramientasLiberadas = new ObservableCollection<AssignedTool>();
            ObraSeleccionada = work;
            CargarEmpleadosAsignados();
            CargarHerramientasAsignadas();
            TiposEmpleado = new ObservableCollection<EmployeeType>();
            CargarTiposEmpleadoExistente();
            TiposHerramienta = new ObservableCollection<ToolType>();
            CargarTiposHerramientaExistente();
        }

        public ObservableCollection<Employee> EmpleadosDisponibles { get; set; }
        public ObservableCollection<Tool> HerramientasDisponibles { get; set; }

        public ObservableCollection<AssignedEmployee> EmpleadosAsignados { get; set; }
        public ObservableCollection<AssignedTool> HerramientasAsignadas { get; set; }

        public ObservableCollection<AssignedEmployee> EmpleadosLiberados { get; set; }
        public ObservableCollection<AssignedTool> HerramientasLiberadas { get; set; }

        private Employee _empleadoSeleccionado;
        public Employee EmpleadoSeleccionado
        {
            get { return _empleadoSeleccionado; }
            set { SetProperty(ref _empleadoSeleccionado, value); }
        }

        private Tool _herramientaSeleccionada;
        public Tool HerramientaSeleccionada
        {
            get { return _herramientaSeleccionada; }
            set { SetProperty(ref _herramientaSeleccionada, value); }
        }

        private Work _obraSeleccionada;
        public Work ObraSeleccionada
        {
            get { return _obraSeleccionada; }
            set { SetProperty(ref _obraSeleccionada, value); }
        }

        public EmployeeType _tipoEmpleadoSeleccionado;
        public EmployeeType TipoEmpleadoSeleccionado
        {
            get { return _tipoEmpleadoSeleccionado; }
            set { SetProperty(ref _tipoEmpleadoSeleccionado, value); }
        }

        public ObservableCollection<EmployeeType> TiposEmpleado { get; set; }

        public ToolType _tipoHerramientaSeleccionada;
        public ToolType TipoHerramientaSeleccionada
        {
            get { return _tipoHerramientaSeleccionada; }
            set { SetProperty(ref _tipoHerramientaSeleccionada, value); }
        }

        public ObservableCollection<ToolType> TiposHerramienta { get; set; }

        public void CargarTiposHerramientaExistente()
        {
            _systemAdministration = new SystemAdministrationLogic();
            TiposHerramienta.Clear();
            var tiposHerramienta = _systemAdministration.GetAllToolTypes();
            if (tiposHerramienta.Any())
            {
                TiposHerramienta.Add(new ToolType() { Name = "Todos", IdToolType = 0 });
                foreach (var item in tiposHerramienta)
                {
                    TiposHerramienta.Add(item);
                }
                TipoHerramientaSeleccionada = TiposHerramienta.First();
            }
        }

        public void CargarTiposEmpleadoExistente()
        {
            _systemAdministration = new SystemAdministrationLogic();
            var tiposEmpleado = _systemAdministration.GetAllEmployeeTypes();
            TiposEmpleado.Clear();
            if (tiposEmpleado.Any())
            {
                TiposEmpleado.Add(new EmployeeType() { Name = "Todos", IdEmployeeType = 0 });
                foreach (var item in tiposEmpleado)
                {
                    TiposEmpleado.Add(item);
                }
                TipoEmpleadoSeleccionado = TiposEmpleado.First();
            }
        }

        public void CargarEmpleadosDisponibles()
        {
            _systemAdministration = new SystemAdministrationLogic();
            EmpleadosDisponibles.Clear();
            var empleados = _systemAdministration.GetAllEmployees();
            if (empleados.Any())
            {
                foreach (var item in empleados)
                {
                    EmpleadosDisponibles.Add(item);
                }
            }
        }

        public void CargarHerramientasDisponibles()
        {
            _systemAdministration = new SystemAdministrationLogic();
            HerramientasDisponibles.Clear();
            var herramientas = _systemAdministration.GetAllTools();
            if (herramientas.Any())
            {
                foreach (var item in herramientas)
                {
                    HerramientasDisponibles.Add(item);
                }
            }
        }

        public void CargarEmpleadosAsignados()
        {
            _workLogic = new WorksLogic();
            EmpleadosAsignados.Clear();
            var empleados = _workLogic.GetAllAssignedEmployeesFromOneWork(ObraSeleccionada);
            if(empleados.Any())
            {
                foreach (var item in empleados)
                {
                    if (item.AssignmentState == AssignmentState.Assigned)
                        EmpleadosAsignados.Add(item);
                    else
                        EmpleadosLiberados.Add(item);
                }
            }
        }

        public void CargarHerramientasAsignadas()
        {
            _workLogic = new WorksLogic();
            HerramientasAsignadas.Clear();
            var herramientas = _workLogic.GetAllAssignedToolFromOneWork(ObraSeleccionada);
            if (herramientas.Any())
            {
                foreach (var item in herramientas)
                {
                    if (item.AssignmentState == AssignmentState.Assigned)
                        HerramientasAsignadas.Add(item);
                    else
                        HerramientasLiberadas.Add(item);
                }
            }
        }

        public void AsignarEmpleado(Employee empleado)
        {
            var empleadoAsignado = new AssignedEmployee();
            empleadoAsignado.Employee = empleado;
            empleadoAsignado.DateOfAssignment = DateTime.Now;
            empleadoAsignado.AssignmentState = AssignmentState.Assigned;
            empleadoAsignado.Work = ObraSeleccionada;
            if(!EmpleadosAsignados.Any(x => x.Employee.IdEmployee == empleado.IdEmployee))
            {
                EmpleadosAsignados.Add(empleadoAsignado);
            }
        }

        public void LiberarEmpleado(AssignedEmployee empleadoAsignado)
        {
            if (empleadoAsignado.IdAssignedEmployee != 0)
            {
                EmpleadosLiberados.Add(empleadoAsignado);
            }                
            EmpleadosAsignados.Remove(empleadoAsignado);
        }

        public void AsignarHerramienta(Tool herramienta)
        {
            var herramientaAsignada = new AssignedTool();
            herramientaAsignada.Tool = herramienta;
            herramientaAsignada.DateOfAssignment = DateTime.Now;
            herramientaAsignada.AssignmentState = AssignmentState.Assigned;
            herramientaAsignada.Work = ObraSeleccionada;
            if(!HerramientasAsignadas.Any(x => x.Tool.IdTool == herramienta.IdTool))
            {
                HerramientasAsignadas.Add(herramientaAsignada);
            }
        }

        public void LiberarHerramienta(AssignedTool herramientaAsignada)
        {
            if (herramientaAsignada.IdAssignedTool != 0)
            {
                HerramientasLiberadas.Add(herramientaAsignada);
            }
            HerramientasAsignadas.Remove(herramientaAsignada);
        }

        public void GuardarAsignaciones()
        {
            foreach(AssignedEmployee item in EmpleadosAsignados)
            {
                if(item.IdAssignedEmployee == 0)
                {
                    _workLogic.InsertAssignedEmployee(item);
                }
            }
            foreach(AssignedEmployee item in EmpleadosLiberados)
            {
                if(item.DateOfDeallocate == null)
                {
                    item.DateOfDeallocate = DateTime.Now;
                    item.AssignmentState = AssignmentState.Unassigned;
                    item.Work = ObraSeleccionada;
                    _workLogic.UpdateAssignedEmployee(item);
                }
            }
            foreach (AssignedTool item in HerramientasAsignadas)
            {
                if(item.IdAssignedTool == 0)
                {
                    _workLogic.InsertAssignedTool(item);
                }
            }
            foreach(AssignedTool item in HerramientasLiberadas)
            {
                if(item.DateOfDeallocate == null)
                {
                    item.DateOfDeallocate = DateTime.Now;
                    item.AssignmentState = AssignmentState.Unassigned;
                    item.Work = ObraSeleccionada;
                    _workLogic.UpdateAssignedTool(item);
                }
            }
            CargarEmpleadosAsignados();
            CargarHerramientasAsignadas();
            
        }

        public void CargarEmpleadosDisponiblesPorTipo()
        {
            _systemAdministration = new SystemAdministrationLogic();
            EmpleadosDisponibles.Clear();
            if (TipoEmpleadoSeleccionado.IdEmployeeType == 0)
            {
                CargarEmpleadosDisponibles();
            }
            else
            {
                var empleados = _systemAdministration.GetAllEmployeesByType(TipoEmpleadoSeleccionado.IdEmployeeType);
                if (empleados.Any())
                {
                    foreach (var item in empleados)
                    {
                        EmpleadosDisponibles.Add(item);
                    }
                }
            }           
        }

        public void CargarHerramientasDisponiblesPorTipo()
        {
            _systemAdministration = new SystemAdministrationLogic();
            HerramientasDisponibles.Clear();
            if (TipoHerramientaSeleccionada.IdToolType == 0)
            {
                CargarHerramientasDisponibles();
            }
            else
            {
                var herramientas = _systemAdministration.GetAllToolsByType(TipoHerramientaSeleccionada.IdToolType);
                if (herramientas.Any())
                {
                    foreach (var item in herramientas)
                    {
                        HerramientasDisponibles.Add(item);
                    }
                }
            }            
        }
    }
}
