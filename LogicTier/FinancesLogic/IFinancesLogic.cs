using CoreTier.Finances;
using CoreTier.Works;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicTier.FinancesLogic
{
    public interface IFinancesLogic
    {
        IList<MoneyMovement> GetAllMoneyMovementsFromOneWork(Work work);
        void InsertMoneyMovement(MoneyMovement moneyMovement);
        void DeleteMoneyMovement(MoneyMovement moneyMovement);
        void UpdateMoneyMovement(MoneyMovement moneyMovement);
    }
}
