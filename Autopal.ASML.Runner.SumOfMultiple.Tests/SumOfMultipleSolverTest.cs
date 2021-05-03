using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Autopal.ASML.Runner.SumOfMultiple.Tests
{
    [TestClass]
    public class SumOfMultipleSolverTest
    {
        [DataTestMethod]
        [DataRow(10, (ulong)23)]
        [DataRow(100, (ulong)2318)]
        public void SumOfMultiple_Succeed(int limit, ulong expectedResult)
        {
            var solver = new SumOfMultipleSolver();
            Assert.AreEqual(expectedResult, solver.Solve(limit));
        }

        [DataTestMethod]
        [DataRow(9, (ulong)14)]
        [DataRow(102, (ulong)2418)]
        [DataRow(105, (ulong)2520)]
        public void SumOfMultiple_LimitDividable(int limit, ulong expectedResult)
        {
            var solver = new SumOfMultipleSolver();
            Assert.AreEqual(expectedResult, solver.Solve(limit));
        }

        [DataTestMethod]
        [DataRow(1, (ulong)0)]
        [DataRow(2, (ulong)0)]
        [DataRow(3, (ulong)0)]
        [DataRow(5, (ulong)3)]
        [DataRow(15, (ulong)45)]
        public void SumOfMultiple_LimitTooLow(int limit, ulong expectedResult)
        {
            var solver = new SumOfMultipleSolver();
            Assert.AreEqual(expectedResult, solver.Solve(limit));
        }

        [DataTestMethod]
        [DataRow(-15)]
        [DataRow(int.MinValue)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void SumOfMultiple_LimitNonPositive(int limit)
        {
            var solver = new SumOfMultipleSolver();
            solver.Solve(limit);
        }

        [DataTestMethod]
        [DataRow(int.MaxValue / 2, (ulong)269015016274150470)]
        [DataRow(int.MaxValue, (ulong)1076060070465310994)]
        public void SumOfMultiple_LimitTooBig(int limit, ulong expectedResult)
        {
            var solver = new SumOfMultipleSolver();
            Assert.AreEqual(expectedResult, solver.Solve(limit));
        }

        private string[] GetSolverParameter(int limit)
        {
            return new[] { limit.ToString() };
        }
    }
}
