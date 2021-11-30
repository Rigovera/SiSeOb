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
    public class NewToolViewModel : ViewModelBase
    {
        private ISystemAdministrationLogic _systemAdministration { get; set; }
        public NewToolViewModel()
        {
            TiposHerramienta = new ObservableCollection<ToolType>();
            Ingreso = DateTime.Now;
            CargarTiposHerramientaExistente();
        }

        private int _idHerramienta;
        public int IdHerramienta
        {
            get { return _idHerramienta; }
            set { SetProperty(ref _idHerramienta, value); }
        }

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

        private string _modelo;
        public string Modelo
        {
            get { return _modelo; }
            set { SetProperty(ref _modelo, value); }
        }

        private string _nroSerie;
        public string NroSerie
        {
            get { return _nroSerie; }
            set { SetProperty(ref _nroSerie, value); }
        }

        private string _descripcion;
        public string Descripcion
        {
            get { return _descripcion; }
            set { SetProperty(ref _descripcion, value); }
        }

        private DateTime _ingreso;
        public DateTime Ingreso
        {
            get { return _ingreso; }
            set { SetProperty(ref _ingreso, value); }
        }

        public ToolType _tipoHerramientaSeleccionada;
        public ToolType TipoHerramientaSeleccionada
        {
            get { return _tipoHerramientaSeleccionada; }
            set { SetProperty(ref _tipoHerramientaSeleccionada, value); }
        }

        public ObservableCollection<ToolType> TiposHerramienta { get; set; }

        public void GuardarHerramienta()
        {
            _systemAdministration = new SystemAdministrationLogic();
            var herramienta = MapearModelo();
            _systemAdministration.InsertTool(herramienta);
            LimpiarViewModel();
        }

        private Tool MapearModelo()
        {
            var herramienta = new Tool();
            if (!string.IsNullOrEmpty(Nombre))
            {
                herramienta.Name = Nombre;
                herramienta.Model = Modelo;
                herramienta.Brand = Marca;
                herramienta.SerialNumber = NroSerie;
                herramienta.AdmissionDate = Ingreso;
                herramienta.Description = Descripcion;
                herramienta.ToolType = TipoHerramientaSeleccionada;
                return herramienta;
            }
            return null;
        }

        public void CargarTiposHerramientaExistente()
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
                TipoHerramientaSeleccionada = TiposHerramienta.First();
            }
        }

        public void LimpiarViewModel()
        {
            Nombre = string.Empty;
            Marca = string.Empty;
            Modelo = string.Empty;
            NroSerie = string.Empty;
            Ingreso = DateTime.Now;
            Descripcion = string.Empty;
            TipoHerramientaSeleccionada = TiposHerramienta.First();
        }
    }
}
