using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Services
{
    public interface IEmployeeService
    {
        void AddEmployee(string surname, string firstName, string patronymic);

        IEnumerable<Employee> GetAllEmployees();
    }
}
