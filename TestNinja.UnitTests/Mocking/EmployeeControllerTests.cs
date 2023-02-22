using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestNinja.Fundamentals;
using System.Threading.Tasks;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    class EmployeeControllerTests
    {
        private Mock<IEmployeeStorage> employeeStorage;
        private EmployeeController employeeController;
        [SetUp]
        public void SetUp()
        {
            employeeStorage = new Mock<IEmployeeStorage>();
            employeeController = new EmployeeController(employeeStorage.Object);
        }
        [Test]
        public void DeleteEmployee_WhenCalled_DeleteTheEmployeeFromDb()
        {
            employeeController.DeleteEmployee(1);
            employeeStorage.Verify(s => s.GetEmployee(1));
        }
    }
}