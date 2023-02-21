using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    internal class CustomerControllerTests
    {
        [Test]
        public void GetCustomer_IdIsZero_ReturnNotFound()
        {
            var controller = new CustomerController();
            var result = controller.GetCustomer(0);
            // ONLY returns true if it's NotFound object.
            Assert.That(result, Is.TypeOf<NotFound>());
            // NotFoundObject or one of its derivatives.
            Assert.That(result, Is.InstanceOf<NotFound>());
        }

        [Test]
        public void GetSutomer_IdIsNotZero_ReturnOk()
        {

        }
    }
}
