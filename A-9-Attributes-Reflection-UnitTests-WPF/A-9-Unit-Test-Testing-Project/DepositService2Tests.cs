using System;
using System.Collections.Generic;
using AL_9_Unit_Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using static AL_9_Unit_Tests.Lesson;

namespace A_9_Unit_Test_Testing_Project
{
    [TestClass]
    public class DepositService2Tests
    {
        [TestMethod]
        public void CalculateDeposits_Tests()
        {
            var dbMock = new DatabaseMock(5000, 1200, 5);
            var service = new DepositService2(dbMock);
            service.CalculateDeposits();

            Assert.AreEqual(5, dbMock.IncreasingAmount);
        }


        [TestMethod]
        public void CalculateDeposits2_Test()
        {
            var mock = new Mock<IDatabase>();
            var checkingAmount = 0;

            mock.Setup(m => m.GetDeposit(1))
                .Returns((1, 1200, 5));

            mock.Setup(m => m.GetUsers())
                .Returns(new[] { (1, "fake", 1) });

            mock
                .Setup(m => m.IncreaseBalance(It.IsAny<int>(), It.IsAny<int>()))
                .Callback((int accountN, int amount) => checkingAmount = amount);
            
            var service = new DepositService2(mock.Object);
            service.CalculateDeposits();

            Assert.AreEqual(5, checkingAmount);
        }
    }

    public class DatabaseMock : IDatabase
    {
        private readonly int initialBalance;
        private readonly int summa;
        private readonly int percent;

        public int? IncreasingAmount { get; private set; }

        public DatabaseMock(int initialBalance, int summa, int percent)
        {
            this.initialBalance = initialBalance;
            this.percent = percent;
            this.summa = summa;
        }                

        public (int id, int summa, int percent) GetDeposit(int user)
        {
            return (1, summa, percent);
        }

        public IEnumerable<(int id, string name, int account)> GetUsers()
        {
            return new [] { (1, "fake", 1) };
        }

        public void IncreaseBalance(int accountN, int amount)
        {
            IncreasingAmount = amount;
        }
    }
}
