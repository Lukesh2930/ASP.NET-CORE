using System.Collections.Generic;
using System.Linq;

namespace Asp_core_practice.model
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _employeeList;

        public MockEmployeeRepository()
        {
            _employeeList = new List<Employee>()
    {
        new Employee() { Id = 1, Name = "Mary", Department = "HR", Email = "mary@pragimtech.com" },
        new Employee() { Id = 2, Name = "John", Department = "IT", Email = "john@pragimtech.com" },
        new Employee() { Id = 3, Name = "Sam", Department = "IT", Email = "sam@pragimtech.com" },
    };
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employeeList;
        }

        public Employee GetEmployee(int Id)
        {
            return this._employeeList.FirstOrDefault(e => e.Id == Id);
        }
    }
}
