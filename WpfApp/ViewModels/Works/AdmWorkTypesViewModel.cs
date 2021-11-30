using CoreTier.SystemAdministration;
using LogicTier.SystemAdministrationLogic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.ViewModels.Works
{
    public class AdmWorkTypesViewModel:ViewModelBase
    {
        private ISystemAdministrationLogic _systemAdministration { get; set; }
        public AdmWorkTypesViewModel()
        {
            TiposObra = new ObservableCollection<WorkType>();
            CargarTiposObra();
        }

        private int _idTipoObra;
        public int IdTipoObra
        {
            get { return _idTipoObra; }
            set { SetProperty(ref _idTipoObra, value); }
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

        private WorkType _tipoObraSeleccionado;
        public WorkType TipoObraSeleccionado
        {
            get { return _tipoObraSeleccionado; }
            set { SetProperty(ref _tipoObraSeleccionado, value); }
        }

        public ObservableCollection<WorkType> TiposObra { get; set; }

        private WorkType MapearModelo()
        {
            var tipoObra = new WorkType();
            if (!string.IsNullOrEmpty(Nombre))
            {
                tipoObra.IdWorkType = IdTipoObra;
                tipoObra.Name = Nombre;
                tipoObra.Description = Descripcion;
                return tipoObra;
            }
            return null;
        }

        private void CargarTiposObra()
        {
            TiposObra.Clear();
            _systemAdministration = new SystemAdministrationLogic();
            var tiposObra = _systemAdministration.GetAllWorkTypes();
            if (tiposObra.Any())
            {
                foreach (var item in tiposObra)
                {
                    TiposObra.Add(item);
                }
            }
        }

        public void GuardarTipoObra()
        {
            var tipoObra = MapearModelo();
            _systemAdministration = new SystemAdministrationLogic();
            if (tipoObra.IdWorkType == 0)
            {
                _systemAdministration.InsertWorkType(tipoObra);
                TiposObra.Add(tipoObra);
            }
            else if (tipoObra.IdWorkType > 0)
            {
                _systemAdministration.UpdateWorkType(tipoObra);
                CargarTiposObra();
            }
            LimpiarViewModel();
        }

        public void BorrarTipoObra()
        {
            _systemAdministration.DeleteWorkType(TipoObraSeleccionado);
        }

        public void LimpiarViewModel()
        {
            IdTipoObra = 0;
            Nombre = string.Empty;
            Descripcion = string.Empty;
        }

    }
}
