using System;
using AL_9_Unit_Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace A_9_Unit_Test_Testing_Project
{
    [TestClass]
    public class DepCalculatorTests
    {
        private readonly DepCalculator depCalculator 
            = new DepCalculator();

        [TestMethod]
        public void Sum_Test()
        {
            var r = depCalculator.Sum(2, 5);
            Assert.AreEqual(r, 7);
        }

        [TestMethod]
        public void Multiple_Test()
        {
            var r = depCalculator.Multiple(2, 5);
            Assert.AreEqual(r, 10);
        }
    }
}
