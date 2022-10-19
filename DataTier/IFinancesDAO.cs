using CoreTier.Finances;
using CoreTier.Works;

using System.Collections.Generic;

namespace DataTier
{
    public interface IFinancesDAO
    {
        IList<MoneyMovement> GetAllMoneyMovementsFromOneWork(Work work);
        void InsertMoneyMovement(MoneyMovement moneyMovement);
        void DeleteMoneyMovement(MoneyMovement moneyMovement);
        void UpdateMoneyMovement(MoneyMovement moneyMovement);

    }
}
