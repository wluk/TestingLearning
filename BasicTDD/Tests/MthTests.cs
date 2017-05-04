using NUnit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace BasicTDD.Tests
{
    [TestFixture]
    public class MathTests
    {

        [Test]
        public void TestAdd()
        {
            // Arrange
            var math = new Math();

            // Act
            var result = math.Add(2, 3);

            // Assert
            Assert.AreEqual(5, result);
        }
    }
}
