using lab2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject1
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void CopyConstructor()
        {
            MyMatrix m = new MyMatrix(new double[,] { { 1, 3, 4 }, { 5, 8, 3 } });
            MyMatrix m1 = new MyMatrix(m);
            string expected = m.ToString();
            string actual = m1.ToString();
            Assert.AreEqual(expected, actual, $"Copy constructor is wrong");
        }
        [TestMethod]
        public void ArrayConstructor()
        {
            MyMatrix m = new MyMatrix(new double[][] { new double[] { 1, 2, 3 }, new double[] { 4, 5, 7 }, new double[] { 3, 3, 1 }, new double[] { 3, 3, 1 } });
            string expected = new MyMatrix(new double[,] { { 1, 2, 3 }, { 4, 5, 7 }, { 3, 3, 1 }, { 3, 3, 1 } }).ToString();
            string actual = m.ToString();
            Assert.AreEqual(expected, actual, $"Конструктор працює неправильно");
        }
        [TestMethod]
        public void StringConstructor()
        {
            string str = "5 7\t4 33 9\n3 2 4 5 7\n11 4\t6 4 3\n";
            MyMatrix m = new MyMatrix(str);
            string expected = "5\t7\t4\t33\t9\n3\t2\t4\t5\t7\n11\t4\t6\t4\t3\n";
            string actual = m.ToString();
            Assert.AreEqual(expected, actual, $"Конструктор працює неправильно");
        }
    }
}
