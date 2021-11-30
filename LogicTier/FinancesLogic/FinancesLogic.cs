using CoreTier.Finances;
using CoreTier.Works;
using DataTier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicTier.FinancesLogic
{
    public class FinancesLogic :IFinancesLogic
    {
        IFinancesDAO _financesDAO { get; set; }
        public FinancesLogic()
        {
            _financesDAO = new FinancesDAO();
        }

        #region MoneyMovements
        public IList<MoneyMovement> GetAllMoneyMovementsFromOneWork(Work work)
        {
            try
            {
                var result = _financesDAO.GetAllMoneyMovementsFromOneWork(work);
                return result;
            }
            catch (Exception ex)
            {
                Logger.Log.Error("GetAllMoneyMovementsFromOneWork_Logic", ex);
                throw;
            }
            
        }
        public void InsertMoneyMovement(MoneyMovement moneyMovement)
        {
            try
            {
                _financesDAO.InsertMoneyMovement(moneyMovement);
            }
            catch(Exception ex)
            {
                Logger.Log.Error("InsertMoneyMovement_Logic", ex);
                throw ex;
            }            
        }
        public void DeleteMoneyMovement(MoneyMovement moneyMovement)
        {
            try
            {
                _financesDAO.DeleteMoneyMovement(moneyMovement);
            }
            catch (Exception ex)
            {
                Logger.Log.Error("DeleteMoneyMovement_Logic", ex);
                throw ex;
            }
        }
        public void UpdateMoneyMovement(MoneyMovement moneyMovement)
        {
            try
            {
                _financesDAO.UpdateMoneyMovement(moneyMovement);
            }
            catch (Exception ex)
            {
                Logger.Log.Error("UpdateMoneyMovement_Logic", ex);
                throw ex;
            }
        }
        #endregion

    }
}
