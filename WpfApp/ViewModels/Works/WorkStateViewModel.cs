using CoreTier.Assignments;
using CoreTier.Certificates;
using CoreTier.Finances;
using CoreTier.SystemAdministration;
using CoreTier.Works;
using LogicTier.CertificatesLogic;
using LogicTier.FinancesLogic;
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
    [Serializable]
    public class WorkStateViewModel : ViewModelBase
    {
        private IFinancesLogic _finances { get; set; }
        private IWorksLogic _workLogic { get; set; }
        private ISystemAdministrationLogic _systemAdministration { get; set; }
        private ICertificasteLogic _certificateLogic { get; set; }

        public WorkStateViewModel()
        {

        }
        public WorkStateViewModel(Work obra)
        {
            ObraSeleccionada = obra;
            EmpleadosAsignados = new ObservableCollection<AssignedEmployee>();
            HerramientasAsignadas = new ObservableCollection<AssignedTool>();
            CargarEmpleadosAsignados();
            CargarHerramientasAsignadas();
            ListaMovimientosObra = new ObservableCollection<MoneyMovement>();
            CargarMovimientosContablesObra();
            ListaCertificadosObra = new ObservableCollection<Certificate>();
            CargarCertificadosObra();
            CalcularTotales();
        }

        private Work _obraSeleccionada;
        public Work ObraSeleccionada
        {
            get { return _obraSeleccionada; }
            set { SetProperty(ref _obraSeleccionada, value); }
        }

        public ObservableCollection<AssignedEmployee> EmpleadosAsignados { get; set; }
        public ObservableCollection<AssignedTool> HerramientasAsignadas { get; set; }
        public void CargarEmpleadosAsignados()
        {
            _workLogic = new WorksLogic();
            EmpleadosAsignados.Clear();
            var empleados = _workLogic.GetAllAssignedEmployeesFromOneWork(ObraSeleccionada);
            if (empleados.Any())
            {
                foreach (var item in empleados)
                {
                    if (item.AssignmentState == AssignmentState.Assigned)
                        EmpleadosAsignados.Add(item);

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

                }
            }
        }

        public ObservableCollection<MoneyMovement> ListaMovimientosObra { get; set; }
        private void CargarMovimientosContablesObra()
        {
            _finances = new FinancesLogic();
            ListaMovimientosObra.Clear();
            var listaMovimientosObra = _finances.GetAllMoneyMovementsFromOneWork(ObraSeleccionada);
            if (listaMovimientosObra.Any())
            {
                foreach (var item in listaMovimientosObra)
                {
                    ListaMovimientosObra.Add(item);
                }
            }
        }

        public ObservableCollection<Certificate> ListaCertificadosObra { get; set; }
        public void CargarCertificadosObra()
        {
            _certificateLogic = new CertificatesLogic();
            var certificadosObra = _certificateLogic.GetAllCertificates(ObraSeleccionada);
            foreach (var certificado in certificadosObra)
            {
                ListaCertificadosObra.Add(certificado);
            }
        }


        private int _totalEmpleadosAsignados;
        public int TotalEmpleadosAsignados
        {
            get { return _totalEmpleadosAsignados; }
            set { SetProperty(ref _totalEmpleadosAsignados, value); }
        }

        private int _totalHerramientasAsignados;
        public int TotalHerramientsAsignados
        {
            get { return _totalHerramientasAsignados; }
            set { SetProperty(ref _totalHerramientasAsignados, value); }
        }

        private decimal _totalDineroIngresado;
        public decimal TotalDineroIngresado
        {
            get { return _totalDineroIngresado; }
            set { SetProperty(ref _totalDineroIngresado, value); }
        }

        private decimal _totalDineroEgresado;
        public decimal TotalDineroEgresado
        {
            get { return _totalDineroEgresado; }
            set { SetProperty(ref _totalDineroEgresado, value); }
        }

        private decimal _totalDineroCertificados;
        public decimal TotalDineroCertificados
        {
            get { return _totalDineroCertificados; }
            set { SetProperty(ref _totalDineroCertificados, value); }
        }

        private decimal _avanceActual;
        public decimal AvanceActual
        {
            get { return _avanceActual; }
            set { SetProperty(ref _avanceActual, value); }
        }

        private decimal _dineroPorCobrar;
        public decimal DineroPorCobrar
        {
            get { return _dineroPorCobrar; }
            set { SetProperty(ref _dineroPorCobrar, value); }
        }


        public void CalcularTotales()
        {
            TotalEmpleadosAsignados = EmpleadosAsignados.Count();
            TotalHerramientsAsignados = HerramientasAsignadas.Count();

            TotalDineroIngresado = ListaMovimientosObra
                .Where(x => x.MoneyMovementType.Sign == MovementSign.Credito)
                .Sum(x => x.Amount);
            TotalDineroEgresado = ListaMovimientosObra
                .Where(x => x.MoneyMovementType.Sign == MovementSign.Debito)
                .Sum(x => x.Amount);

            TotalDineroCertificados = ListaCertificadosObra
                .Where(x => x.CertificateType.IdCertificateType == (int)CertificateTypeEnum.Presupuesto ||
                            x.CertificateType.IdCertificateType == (int)CertificateTypeEnum.Adicional)
                .Sum(x => x.TotalAmount);

            DineroPorCobrar = TotalDineroCertificados - TotalDineroIngresado;

            var ultimoCertificadoIngresado = ListaCertificadosObra.OrderByDescending(x => x.IdCertificate).FirstOrDefault();
            if (ultimoCertificadoIngresado != null)
                AvanceActual = ultimoCertificadoIngresado.WorkProgress;
        }

    }
}
