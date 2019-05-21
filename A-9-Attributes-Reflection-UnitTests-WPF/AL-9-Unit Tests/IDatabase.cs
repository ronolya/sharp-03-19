namespace AL_9_Unit_Tests
{
    public interface IDatabase
    {
        (int id, int summa, int percent) GetDeposit(int user);
        System.Collections.Generic.IEnumerable<(int id, string name, int account)> GetUsers();
        void IncreaseBalance(int accountN, int amount);
    }
}