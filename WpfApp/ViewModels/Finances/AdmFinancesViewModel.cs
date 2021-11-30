using CoreTier.Finances;
using CoreTier.SystemAdministration;
using CoreTier.Works;
using LogicTier.FinancesLogic;
using LogicTier.SystemAdministrationLogic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.ViewModels.Finances
{
    public class AdmFinancesViewModel : ViewModelBase
    {
        private IFinancesLogic _finances { get; set; }
        private ISystemAdministrationLogic _systemAdministration { get; set; }
        public AdmFinancesViewModel(Work work)
        {
            Obra = work;
            TiposMovimientoContable = new ObservableCollection<MoneyMovementType>();
            ListaMovimientosObra = new ObservableCollection<MoneyMovement>();
            CargarMovimientosContablesObra();
            CargarTiposMovimientoExistente();
        }

        private Work _obra;
        public Work Obra
        {
            get { return _obra; }
            set { SetProperty(ref _obra, value); }
        }

        private int _idMovimiento;
        public int IdMovimiento
        {
            get { return _idMovimiento; }
            set { SetProperty(ref _idMovimiento, value); }
        }

        private decimal _monto;
        public decimal Monto
        {
            get { return _monto; }
            set { SetProperty(ref _monto, value); }
        }

        private MoneyMovementType _tipoMovimientoSeleccionado;
        public MoneyMovementType TipoMovimientoSeleccionado
        {
            get { return _tipoMovimientoSeleccionado; }
            set { SetProperty(ref _tipoMovimientoSeleccionado, value); }
        }

        public ObservableCollection<MoneyMovementType> TiposMovimientoContable { get; set; }

        public ObservableCollection<MoneyMovement> ListaMovimientosObra { get; set; }

        private MoneyMovement MapearModelo()
        {
            var movimiento = new MoneyMovement();
            if (Monto > 0)
            {
                movimiento.IdMoneyMovement = IdMovimiento;
                movimiento.Amount = Monto;
                movimiento.MoneyMovementType = TipoMovimientoSeleccionado;
                movimiento.Work = Obra;
                return movimiento;
            }
            return null;
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
                    item.Name = item.Name + " - "+item.Sign.ToString();
                    TiposMovimientoContable.Add(item);
                }
                TipoMovimientoSeleccionado = TiposMovimientoContable.FirstOrDefault();
            }
        }

        private void CargarMovimientosContablesObra()
        {
            _finances = new FinancesLogic();
            ListaMovimientosObra.Clear();
            var listaMovimientosObra = _finances.GetAllMoneyMovementsFromOneWork(Obra);
            if (listaMovimientosObra.Any())
            {
                foreach (var item in listaMovimientosObra)
                {
                    ListaMovimientosObra.Add(item);
                }
            }
        }

        public void GuardarMovimientoContable()
        {
            _finances = new FinancesLogic();
            var movimiento = MapearModelo();

            if (IdMovimiento == 0)
            {
                _finances.InsertMoneyMovement(movimiento);
                ListaMovimientosObra.Add(movimiento);
            }
            else if (IdMovimiento > 0)
            {
                _finances.UpdateMoneyMovement(movimiento);
                CargarMovimientosContablesObra();
            }
        }

        public void LimpiarViewModel()
        {
            Monto = 0;
            TipoMovimientoSeleccionado = TiposMovimientoContable.FirstOrDefault();
        }

    }
}
