using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.Queries.QueriesCriterions;
using Domain.Objects;
using Domain.Services;

namespace Domain.Entities.Queries
{
    public class GetAllEmployeesQuery : IQuery<AllEntitiesCriterion, IEnumerable<Employee>>
    {
        private readonly IEmployeeService _employeeService;

        public GetAllEmployeesQuery(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public IEnumerable<Employee> Ask(AllEntitiesCriterion criterion)
            => _employeeService.GetAllEmployees();
    }
}
