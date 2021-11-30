using CoreTier.SystemAdministration;
using LogicTier.SystemAdministrationLogic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.ViewModels.Finances
{
    public class AdmMoneyMovementTypeViewModel : ViewModelBase
    {
        private ISystemAdministrationLogic _systemAdministration { get; set; }
        public AdmMoneyMovementTypeViewModel()
        {
            TiposMovimientoContable = new ObservableCollection<MoneyMovementType>();
            CargarTiposMovimientoExistente();
        }

        private int _idTipoMovimientoDinero;
        public int IdTipoMovimientoDinero
        {
            get { return _idTipoMovimientoDinero; }
            set { SetProperty(ref _idTipoMovimientoDinero, value); }
        }

        private string _nombre;
        public string Nombre
        {
            get { return _nombre; }
            set { SetProperty(ref _nombre, value); }
        }

        private string _descipcion;
        public string Descripcion
        {
            get { return _descipcion; }
            set { SetProperty(ref _descipcion, value); }
        }

        private MovementSign _signo;
        public MovementSign Signo
        {
            get { return _signo; }
            set { SetProperty(ref _signo, value); }
        }

        public ObservableCollection<MoneyMovementType> TiposMovimientoContable { get; set; }

        private MoneyMovementType MapearModelo()
        {
            var tipoMovimiento = new MoneyMovementType();
            if (!string.IsNullOrEmpty(Nombre))
            {
                tipoMovimiento.IdMoneyMovementType = IdTipoMovimientoDinero;
                tipoMovimiento.Name = Nombre;
                tipoMovimiento.Description = Descripcion;
                tipoMovimiento.Sign = Signo;
                return tipoMovimiento;
            }
            return null;
        }

        public void GuardarTipoMovimiento()
        {
            _systemAdministration = new SystemAdministrationLogic();
            var tipoMovimientoDinero = MapearModelo();
            if (tipoMovimientoDinero.IdMoneyMovementType == 0)
            {
                _systemAdministration.InsertMoneyMovementType(tipoMovimientoDinero);
                TiposMovimientoContable.Add(tipoMovimientoDinero);
            }
            else if (tipoMovimientoDinero.IdMoneyMovementType > 0)
            {
                _systemAdministration.UpdateMoneyMovementType(tipoMovimientoDinero);
                CargarTiposMovimientoExistente();
            }
            LimpiarViewModel();
        }

        private void CargarTiposMovimientoExistente()
        {
            _systemAdministration = new SystemAdministrationLogic();
            TiposMovimientoContable.Clear();
            var tiposMovimientoDinero = _systemAdministration.GetAllMoneyMovementType();
            if (tiposMovimientoDinero.Any())
            {
                foreach (var item in tiposMovimientoDinero)
                {
                    TiposMovimientoContable.Add(item);
                }
            }
        }

        public void LimpiarViewModel()
        {
            IdTipoMovimientoDinero = 0;
            Nombre = string.Empty;
            Descripcion = string.Empty;
        }
    }
}
