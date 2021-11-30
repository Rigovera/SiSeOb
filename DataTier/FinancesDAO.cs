using CoreTier.Finances;
using CoreTier.SystemAdministration;
using CoreTier.Works;
using DataTier.EntityModel;
using Omu.ValueInjecter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTier
{
    public class FinancesDAO : DataRepository, IFinancesDAO
    {
        #region MoneyMovements
        public IList<MoneyMovement> GetAllMoneyMovementsFromOneWork(Work work)
        {
            try
            {
                var result = new List<MoneyMovement>();

                foreach (var item in _siseobDB.moneymovements.Include("moneymovementtype").Include("work")
                                                .Where(x => x.IdWork == work.IdWork))
                {
                    var moneyMovement = new MoneyMovement();
                    moneyMovement.Work = new Work();
                    moneyMovement.MoneyMovementType = new MoneyMovementType();
                    moneyMovement.InjectFrom(item);
                    moneyMovement.Work.InjectFrom(item.work);
                    moneyMovement.MoneyMovementType.InjectFrom(item.moneymovementtype);
                    moneyMovement.MoneyMovementType.Sign = (MovementSign)item.moneymovementtype.Sign;
                    result.Add(moneyMovement);
                }
                return result;
            }
            catch (Exception ex)
            {
                Logger.Log.Error("GetAllMoneyMovementsFromOneWork_DAO", ex);
                throw ex;
            }           
        }
        public void InsertMoneyMovement(MoneyMovement moneyMovement)
        {
            try
            {
                var moneyMovementEntity = new moneymovement();
                moneyMovementEntity.InjectFrom(moneyMovement);
                moneyMovementEntity.IdMoneyMovementType = moneyMovement.MoneyMovementType.IdMoneyMovementType;
                moneyMovementEntity.IdWork = moneyMovement.Work.IdWork;              
                _siseobDB.moneymovements.Add(moneyMovementEntity);
                _siseobDB.SaveChanges();
            }
            catch (Exception ex)
            {
                Logger.Log.Error("InsertCertificateArticle_DAO", ex);
                throw ex;
            }
        }
        public void DeleteMoneyMovement(MoneyMovement moneyMovement)
        {
            try
            {
                var moneyMovementEntity = new moneymovement();
                moneyMovementEntity.InjectFrom(moneyMovement);
                moneyMovementEntity.IdMoneyMovementType = moneyMovement.MoneyMovementType.IdMoneyMovementType;
                moneyMovementEntity.IdWork = moneyMovement.Work.IdWork;
                _siseobDB.Entry(moneyMovementEntity).State = System.Data.Entity.EntityState.Deleted;
                _siseobDB.moneymovements.Remove(moneyMovementEntity);
                _siseobDB.SaveChanges();
            }
            catch (Exception ex)
            {
                Logger.Log.Error("InsertCertificateArticle_DAO", ex);
                throw ex;
            }
        }
        public void UpdateMoneyMovement(MoneyMovement moneyMovement)
        {
            try
            {
                var moneyMovementEntity = _siseobDB.moneymovements.Find(moneyMovement.IdMoneyMovement);
                if (moneyMovementEntity != null)
                {
                    moneyMovementEntity.InjectFrom(moneyMovement);
                    moneyMovementEntity.IdMoneyMovementType = moneyMovement.MoneyMovementType.IdMoneyMovementType;
                    _siseobDB.Entry(moneyMovementEntity).State = System.Data.Entity.EntityState.Modified;
                    _siseobDB.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logger.Log.Error("UpdateWork_DAO", ex);
                throw ex;
            }
        }
        #endregion

        #region Receipts

        #endregion

        #region ReceiptDetails

        #endregion
    }
}
