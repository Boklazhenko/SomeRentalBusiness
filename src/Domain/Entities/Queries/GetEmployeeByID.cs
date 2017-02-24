using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.Queries.QueriesCriterions;
using Domain.Objects;
using Domain.Services;

namespace Domain.Entities.Queries
{
    public class GetEmployeeByID : IQuery<IdCriterion, Employee>
    {
        private readonly IEmployeeService _employeeService;

        public GetEmployeeByID(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public Employee Ask(IdCriterion criterion)
        {
            return _employeeService.GetAllEmployees().FirstOrDefault(e => e.ID == criterion.ID);
        }
    }
}
