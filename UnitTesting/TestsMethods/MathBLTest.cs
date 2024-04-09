using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestingExample.BL;

namespace UnitTesting.TestsMethods
{
    internal class MathBLTest
    {
        [Test]
        public void TestSum()
        {
            MathBL bl = new MathBL();
            int result = bl.Sum(2, 3);
            Assert.IsTrue(result == 5);
        }

        [SetUp] public void SetUp() 
        {
        }
    }
}
