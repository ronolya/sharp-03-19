using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AL_9_Unit_Tests
{
    public static partial class Lesson
    { 
        public class DepositService
        {
            private readonly Database _database = new Database();

            public void CalculateDeposits()
            {
                var users = _database.GetUsers();

                foreach (var user in users)
                {
                    var accountN = user.account;
                    var deposit = _database.GetDeposit(user.id);

                    var amount = deposit.summa / 12 * deposit.percent / 100;
                    _database.IncreaseBalance(accountN, amount);
                }
            }
        }

        public class DepositService2
        {
            private readonly IDatabase _database;

            public DepositService2(IDatabase database)
            {
                this._database = database;
            }

            public void CalculateDeposits()
            {
                var users = _database.GetUsers();

                foreach (var user in users)
                {
                    var accountN = user.account;
                    var deposit = _database.GetDeposit(user.id);

                    var amount = deposit.summa / 12 * deposit.percent / 100;
                    _database.IncreaseBalance(accountN, amount);
                }
            }
        }
    }
}
