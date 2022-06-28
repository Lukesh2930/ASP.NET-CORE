using Intercom.Core;
using System.Collections.Generic;

namespace Asp_core_practice.model
{
    public interface IEmployeeRepository
    {
        Employee GetEmployee(int Id);
        IEnumerable<Employee> GetAllEmployees();
    }
}
