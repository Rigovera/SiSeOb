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
    public class AdmCertificateTypeViewModel:ViewModelBase
    {
        private ISystemAdministrationLogic _systemAdministration { get; set; }
        public AdmCertificateTypeViewModel()
        {
            ListaTiposCertificado = new ObservableCollection<CertificateType>();
            TipoSeleccionado = new CertificateType();
            CargarTiposCertificado();
        }

        private int _idTipoCertificado;
        public int IdTipoCertificado
        {
            get { return _idTipoCertificado; }
            set { SetProperty(ref _idTipoCertificado, value); }
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

        private CertificateType _tipo;
        public CertificateType TipoSeleccionado
        {
            get { return _tipo; }
            set { SetProperty(ref _tipo, value); }
        }

        public ObservableCollection<CertificateType> ListaTiposCertificado { get; set; }

        private CertificateType MapearModelo()
        {
            var tipoCertificado = new CertificateType();
            if (!string.IsNullOrEmpty(Nombre))
            {
                tipoCertificado.IdCertificateType = IdTipoCertificado;
                tipoCertificado.Name = Nombre;
                tipoCertificado.Description = Descripcion;
                return tipoCertificado;
            }
            return null;
        }

        private void CargarTiposCertificado()
        {
            _systemAdministration = new SystemAdministrationLogic();
            ListaTiposCertificado.Clear();
            var tiposCertificado = _systemAdministration.GetAllCertificateTypes();
            if (tiposCertificado.Any())
            {
                foreach (var item in tiposCertificado)
                {
                    ListaTiposCertificado.Add(item);
                }
            }
        }

        public void GuardarTipoCertificado()
        {
            _systemAdministration = new SystemAdministrationLogic();
            var tipoCertificado = MapearModelo();

            if (tipoCertificado.IdCertificateType == 0)
            {
                _systemAdministration.InsertCertificateType(tipoCertificado);
                ListaTiposCertificado.Add(tipoCertificado);
            }
            else if (tipoCertificado.IdCertificateType > 0)
            {
                _systemAdministration.UpdateCertificateType(tipoCertificado);
                CargarTiposCertificado();
            }
            LimpiarViewModel();
        }

        public void LimpiarViewModel()
        {
            IdTipoCertificado = 0;
            Nombre = string.Empty;
            Descripcion = string.Empty;
        }
    }
}
