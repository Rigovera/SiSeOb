using CoreTier.SystemAdministration;
using LogicTier.SystemAdministrationLogic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.ViewModels.Tools
{
    public class AdmToolViewModel :ViewModelBase
    {
        private ISystemAdministrationLogic _systemAdministration { get; set; }
        public AdmToolViewModel()
        {
            Herramientas = new ObservableCollection<Tool>();
            TiposHerramienta = new ObservableCollection<ToolType>();
            CargarHerramientasExistente();
            CargarTiposHerramientaExistente();
        }

        private ToolType _tipoHerramientaSeleccionada;
        public ToolType TipoHerramientaSeleccionada
        {
            get { return _tipoHerramientaSeleccionada; }
            set { SetProperty(ref _tipoHerramientaSeleccionada, value); }
        }

        public ObservableCollection<Tool> Herramientas { get; set; }

        public ObservableCollection<ToolType> TiposHerramienta { get; set; }

        private string _nombre;
        public string Nombre
        {
            get { return _nombre; }
            set { SetProperty(ref _nombre, value); }
        }

        private string _marca;
        public string Marca
        {
            get { return _marca; }
            set { SetProperty(ref _marca, value); }
        }

        public void CargarHerramientasExistente()
        {
            _systemAdministration = new SystemAdministrationLogic();
            Herramientas.Clear();
            var herramientas = _systemAdministration.GetAllTools();
            if (herramientas.Any())
            {
                foreach (var item in herramientas)
                {
                    Herramientas.Add(item);
                }
            }
        }

        private void CargarTiposHerramientaExistente()
        {
            _systemAdministration = new SystemAdministrationLogic();
            TiposHerramienta.Clear();
            var tiposHerramienta = _systemAdministration.GetAllToolTypes();
            if (tiposHerramienta.Any())
            {
                foreach (var item in tiposHerramienta)
                {
                    TiposHerramienta.Add(item);
                }
            }
        }

        public void CargarHerramientasPorNombre()
        {
            Herramientas.Clear();
            _systemAdministration = new SystemAdministrationLogic();
            var herramientas = _systemAdministration.GetAllToolsWhoseNameContains(Nombre);
            if (herramientas.Any())
            {
                foreach (var item in herramientas)
                {
                    Herramientas.Add(item);
                }
            }
        }

        public void CargarHerramientasPorMarca()
        {
            Herramientas.Clear();
            _systemAdministration = new SystemAdministrationLogic();
            var herramientas = _systemAdministration.GetAllToolsWhoseBrandContains(Marca);
            if (herramientas.Any())
            {
                foreach (var item in herramientas)
                {
                    Herramientas.Add(item);
                }
            }
        }

        public void CargarHerramientasPorTipo()
        {
            Herramientas.Clear();
            _systemAdministration = new SystemAdministrationLogic();
            var herramientas = _systemAdministration.GetAllToolsByType(TipoHerramientaSeleccionada.IdToolType);
            if (herramientas.Any())
            {
                foreach (var item in herramientas)
                {
                    Herramientas.Add(item);
                }
            }
        }
    }
}

