using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Polinom;

namespace Polinom3Test
{
    [TestClass]
    public class Polinom3Test
    {
        [TestMethod]
        public void ToStringTest()
        {
            var p1 = new Polinom3List("1 8 2 2");
            string s = "x^8y^2z^2";
            string t = p1.ToString();
            Assert.AreEqual(s, t);
        }

        [TestMethod]
        public void InsertTest()
        {
            var p1 = new Polinom3List("1 8 2 2 1 2 4 0 3 1 4 2 2 -3 1 4");
            string s = p1.ToString();
            p1.Insert(1, -6, 1, 1);
            s += " + x^-6yz";
            Assert.AreEqual(s, p1.ToString());
        }

        [TestMethod]
        public void DeleteTest()
        {
            var p1 = new Polinom3List("1 8 2 2 1 2 4 0 3 1 4 2 2 -3 1 4");
            p1.Delete(1, 1, 1);
            string s = "x^8y^2z^2 + x^2y^4 + 3xy^4z^2 + 2x^-3yz^4";
            Assert.AreEqual(s, p1.ToString());

            p1.Delete(8, 2, 2);
            s = "x^2y^4 + 3xy^4z^2 + 2x^-3yz^4";
            Assert.AreEqual(s, p1.ToString());
        }

        [TestMethod]
        public void ValueTest()
        {
            var p1 = new Polinom3List("1 1 2 2 1 2 4 0 3 1 4 2 2 -3 1 4");
            int testValue = p1.Value(1, 1, 1);
            int trueValue = 7;
            Console.WriteLine(p1.ToString());
            Assert.AreEqual(trueValue, testValue);
        }

        [TestMethod]
        public void DerivateTest()
        {
            Polinom3List p1 = new Polinom3List("2,2,2,2");
            string s = "4xy^2z^2";
            p1.Derivate(1);
            string testS = p1.ToString();
            Assert.AreEqual(s, testS);
        }

        [TestMethod]
        public void AddTest()
        {
            var p1 = new Polinom3List("1 8 2 2 1 2 4 0 3 1 4 2 2 -3 1 4");
            var p2 = new Polinom3List("1 8 2 2 1 2 4 0 3 1 4 2 2 -3 1 4");
            Console.WriteLine("p2:     " + p2);
            Console.WriteLine("p1      " + p1);
            p2.Add(p1);
            string testS = "x^8y^2z^2 + 8x^7yz^3 + 2x^3y^4z^4 + 4x^3yz + x^2y^4 + 3xy^4z^2 + 2x^-3yz^4 + 5x^-5y^5z^2";
            Assert.AreEqual(testS, p2.ToString());
        }
    }
}

