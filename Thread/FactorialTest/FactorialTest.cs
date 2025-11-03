using ThreadApp;

namespace FactorialTest
{
    [TestClass]
    public sealed class FactorialTest
    {
        [TestMethod]
        [DataRow(2, 2)]
        [DataRow(3, 6)]
        [DataRow(5, 120)]
        public void GivenAnInteger_ThePrintFactorialMethodReturnTheCorrectFactorial5Times(int input, int expected)
        {
            Factorial factorial = new Factorial();

            var result = factorial.GetFactorial(input);
            Assert.AreEqual(expected, result);
        }
    }
}
