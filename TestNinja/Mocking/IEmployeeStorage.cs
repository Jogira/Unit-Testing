namespace TestNinja.Mocking
{
    public interface IEmployeeStorage
    {
        void GetEmployee(int id);
        void DeleteEmployee(int id);
    }
}