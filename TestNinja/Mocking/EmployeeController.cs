using System.Data.Entity;

namespace TestNinja.Mocking
{
    public class EmployeeController
    {
        private EmployeeContext _db;

        private IEmployeeStorage _employeeStore;

        public EmployeeController(IEmployeeStorage employeeStore)
        {
            _db = new EmployeeContext();
            _employeeStore = employeeStore;
        }

        public ActionResult DeleteEmployee(int id)
        {
            _employeeStore.GetEmployee(id);

            //  return true;

            return RedirectToAction("Employees");
        }

        private ActionResult RedirectToAction(string employees)
        {
            return new RedirectResult();
        }

    }

    public class ActionResult { }

    public class RedirectResult : ActionResult { }

    public class EmployeeContext
    {
        public DbSet<Employee> Employees { get; set; }

        public void SaveChanges()
        {
        }
    }

    public class Employee
    {
    }
}