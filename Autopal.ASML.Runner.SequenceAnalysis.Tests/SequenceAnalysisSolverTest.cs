using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Autopal.ASML.Runner.SequenceAnalysis.Tests
{
    [TestClass]
    public class SequenceAnalysisSolverTest
    {
        [DataTestMethod]
        [DataRow("This IS a STRING", "GIINRSST")]
        public void SequenceAnalysisSolver_Succeeded(string input, string expectedResult)
        {
            var solver = new SequenceAnalysisSolver();
            Assert.AreEqual(expectedResult, solver.Solve(input));
        }

        [DataTestMethod]
        [DataRow("'OH, you CAN'T help THAT,' said the CAT: 'WE'RE all mad here. I'M mad. You're mad.'", "AAACCEEHHIMNORTTTTW")]
        public void SequenceAnalysisSolver_WithPunctuation(string input, string expectedResult)
        {
            var solver = new SequenceAnalysisSolver();
            Assert.AreEqual(expectedResult, solver.Solve(input));
        }

        [DataTestMethod]
        [DataRow("ÆPPLE")]
        [DataRow("İŞÇİ")]
        [ExpectedException(typeof(InvalidOperationException))]
        public void SequenceAnalysisSolver_WitNoneAsciiChars(string input)
        {
            var solver = new SequenceAnalysisSolver();
            solver.Solve(input);
        }
    }
}
