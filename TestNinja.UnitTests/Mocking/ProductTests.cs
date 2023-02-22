using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Fundamentals;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    internal class ProductTests
    {
        [Test]
        public void GetPrice_GoldCustomer_Apply30PercentDiscount()
        {
            var product = new Product { ListPrice = 100 };
            var result = product.GetPrice(new Customer { IsGold = true });
            Assert.That(result, Is.EqualTo(70));
        }
        //EXAMPLE OF MOCK ABUSE INTERFACE
        //Making mocks of every object can get messy and bulky for no reason with 0 benefit.
        [Test]
        public void GetPrice_GoldCustomer_Apply30PercentDiscountBAD()
        {

            //Setting up Mock Object
            var customer = new Mock<ICustomer>();
            customer.Setup(c => c.IsGold).Returns(true);

            var product = new Product { ListPrice = 100 };
            var result = product.GetPrice(customer.Object);
            Assert.That(result, Is.EqualTo(70));
        }
    }
}
