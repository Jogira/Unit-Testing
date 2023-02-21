using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Fundamentals;
using Math = TestNinja.Fundamentals.Math;

namespace TestNinja.UnitTests
{
    [TestFixture]
    internal class MathTests
    {
        private Math _math;
        //SetUp
        [SetUp]
        public void SetUp()
        {
            _math = new Math();
        }
        //TearDown
        [Test]
        //[Ignore("Because I wanted to.")]
        public void Add_WhenCalled_ReturnTheSumOfArguments()
        {
            var result = _math.Add(1, 2);
            Assert.That(result, Is.EqualTo(3));
            //Assert.That(_math, Is.Not.Null);

        }

        [Test]
        ///These parameterized tests reduce the need to write redundant tests like that last 2.
        [TestCase(2, 1, 2)]
        [TestCase(1, 2, 2)]
        [TestCase(1, 1, 1)]
        public void Max_WhenCalled_ReturnTheGreaterArgument(int a, int b, int expectedResult)
        {
            var result = _math.Max(a, b);
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        //[Test]
        //public void Max_SecondArgumentIsGreater_ReturnTheSecondArgument()
        //{
        //    var result = _math.Max(1, 2);
        //    Assert.That(result, Is.EqualTo(2));
        //}


        //[Test]
        //public void Max_ArgumentsAreEqual_ReturnTheSameArgument()
        //{
        //    var result = _math.Max(1, 1);
        //    Assert.That(result, Is.EqualTo(1));
        //}
    }
}
