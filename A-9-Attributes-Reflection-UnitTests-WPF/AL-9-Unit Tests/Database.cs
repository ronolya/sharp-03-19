using System.Collections.Generic;
using System.Linq;

namespace AL_9_Unit_Tests
{
    public class Database : IDatabase
    {
        private Dictionary<int, (string name, int account)> _users = 
            new Dictionary<int, (string, int)>
            {
                { 1, ("Olga", 1) },
                { 2, ("Vanya", 2) }
            };

        private Dictionary<int, (string accountN, int balance, int user)> _account = 
            new Dictionary<int, (string, int, int)>
            {
                { 1, ("222", 500, 1) },
                { 2, ("232", 3000, 2) },
                { 3, ("233", 300, 2) }
            };

        private Dictionary<int, (int summa, int percent, int user)> _deposit =
            new Dictionary<int, (int, int, int)>
            {
                { 1, (1000, 2, 1) },
                { 2, (5000, 7, 2) }
            };


        public IEnumerable<(int id, string name, int account)> GetUsers()
        {
            return this._users.Select(pair => (pair.Key, pair.Value.name, pair.Value.account));
        }        

        public void IncreaseBalance(int accountN, int amount)
        {
            var account = this._account[accountN];
            account.balance += amount;
        }

        public (int id, int summa, int percent) GetDeposit(int user)
        {
            return this._deposit
                .Where(x => x.Key == user)
                .Select(x => (x.Key, x.Value.summa, x.Value.percent))
                .FirstOrDefault();
        }
    }
}
