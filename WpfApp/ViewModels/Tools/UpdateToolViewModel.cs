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
    public class UpdateToolViewModel: ViewModelBase
    {
        private ISystemAdministrationLogic _systemAdministration = new SystemAdministrationLogic();
        public UpdateToolViewModel(Tool herramienta)
        {
            IdHerramienta = herramienta.IdTool;
            Nombre = herramienta.Name;
            Marca = herramienta.Brand;
            Modelo = herramienta.Model;
            NroSerie = herramienta.SerialNumber;
            Descripcion = herramienta.Description;
            Ingreso = herramienta.AdmissionDate;
            TiposHerramienta = new ObservableCollection<ToolType>();
            CargarTiposEmpleadoExistente();
            TipoHerramientaSeleccionada = TiposHerramienta
                .Single(x => x.IdToolType == herramienta.ToolType.IdToolType);
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
            var herramienta = MapearModelo();
            _systemAdministration.UpdateTool(herramienta);
        }

        private Tool MapearModelo()
        {
            var herramienta = new Tool();
            if (!string.IsNullOrEmpty(Nombre))
            {
                herramienta.IdTool = IdHerramienta;
                herramienta.Name = Nombre;
                herramienta.Brand = Marca;
                herramienta.Model = Modelo;
                herramienta.SerialNumber = NroSerie;
                herramienta.AdmissionDate = Ingreso;
                herramienta.Description = Descripcion;
                herramienta.ToolType = TipoHerramientaSeleccionada;
                return herramienta;
            }
            return null;
        }

        private void CargarTiposEmpleadoExistente()
        {
            var tiposHerramienta = _systemAdministration.GetAllToolTypes();
            if (tiposHerramienta.Any())
            {
                foreach (var item in tiposHerramienta)
                {
                    TiposHerramienta.Add(item);
                }
            }
        }

    }
}
