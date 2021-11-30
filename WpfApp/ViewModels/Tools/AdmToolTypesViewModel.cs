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
    public class AdmToolTypesViewModel : ViewModelBase
    {
        private ISystemAdministrationLogic _systemAdministration { get; set; }
        public AdmToolTypesViewModel()
        {
            ListaTiposHerramienta = new ObservableCollection<ToolType>();
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

        private string _descripcion;
        public string Descripcion
        {
            get { return _descripcion; }
            set { SetProperty(ref _descripcion, value); }
        }

        public ObservableCollection<ToolType> ListaTiposHerramienta { get; set; }

        public void GuardarTipoHerramienta()
        {
            _systemAdministration = new SystemAdministrationLogic();
            var tipoHerramienta = MapearModelo();
                       
            if (tipoHerramienta.IdToolType == 0)
            {
                _systemAdministration.InsertToolType(tipoHerramienta);
                ListaTiposHerramienta.Add(tipoHerramienta);
            }
            else if (tipoHerramienta.IdToolType > 0)
            {
                _systemAdministration.UpdateToolType(tipoHerramienta);
                CargarTiposHerramientaExistente();
            }
            LimpiarViewModel();
        }

        private ToolType MapearModelo()
        {
            var tipoHerramienta = new ToolType();
            if (!string.IsNullOrEmpty(Nombre))
            {
                tipoHerramienta.IdToolType = IdHerramienta;
                tipoHerramienta.Name = Nombre;
                tipoHerramienta.Description = Descripcion;
                return tipoHerramienta;
            }
            return null;
        }

        private void CargarTiposHerramientaExistente()
        {
            _systemAdministration = new SystemAdministrationLogic();
            ListaTiposHerramienta.Clear();
            var tiposHerramienta = _systemAdministration.GetAllToolTypes();
            if (tiposHerramienta.Any())
            {
                foreach (var item in tiposHerramienta)
                {
                    ListaTiposHerramienta.Add(item);
                }
            }
        }

        public void LimpiarViewModel()
        {
            IdHerramienta = 0;
            Nombre = string.Empty;
            Descripcion = string.Empty;
        }

    }
}
