using CoreTier.SystemAdministration;
using LogicTier.SystemAdministrationLogic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.ViewModels.Certificates
{
    public class AdmMeasurementUnitViewModel: ViewModelBase
    {
        private ISystemAdministrationLogic _systemAdministration { get; set; }
        public AdmMeasurementUnitViewModel()
        {
            ListaUnidadesMedida = new ObservableCollection<MeasurementUnit>();
            CargarUnidadesMedida();
        }
        private int _idMeasurementUnit;
        public int IdMeasurementUnit
        {
            get { return _idMeasurementUnit; }
            set { SetProperty(ref _idMeasurementUnit,value); }
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

        private string _simbolo;
        public string Simbolo
        {
            get { return _simbolo; }
            set { SetProperty(ref _simbolo, value); }
        }

        public ObservableCollection<MeasurementUnit> ListaUnidadesMedida { get; set; }

        private MeasurementUnit MapearModelo()
        {
            var unidadMedida = new MeasurementUnit();
            if (!string.IsNullOrEmpty(Nombre))
            {
                unidadMedida.IdMeasurementUnit = IdMeasurementUnit;
                unidadMedida.Name = Nombre;
                unidadMedida.Description = Descripcion;
                unidadMedida.Simbol = Simbolo;   
                return unidadMedida;
            }
            return null;
        }

        private void CargarUnidadesMedida()
        {
            _systemAdministration = new SystemAdministrationLogic();
            ListaUnidadesMedida.Clear();
            var UnidadesMedida = _systemAdministration.GetAllMeasurementUnit();
            if (UnidadesMedida.Any())
            {
                foreach (var item in UnidadesMedida)
                {
                    ListaUnidadesMedida.Add(item);
                }
            }

        }

        public void GuardarUnidadMedida()
        {
             _systemAdministration = new SystemAdministrationLogic();
            var unidadMedida = MapearModelo();

            if (IdMeasurementUnit == 0)
            {
                _systemAdministration.InsertMeasurementUnit(unidadMedida);
                ListaUnidadesMedida.Add(unidadMedida);
            }
            else if (IdMeasurementUnit > 0)
            {
                _systemAdministration.UpdateMeasurementUnit(unidadMedida);
                CargarUnidadesMedida();
            }
        }

        public void LimpiarViewModel()
        {
            IdMeasurementUnit = 0;
            Nombre = string.Empty;
            Descripcion = string.Empty;
        }
    }
}
