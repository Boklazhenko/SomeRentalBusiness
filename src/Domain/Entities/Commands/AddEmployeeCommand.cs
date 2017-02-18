using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.Commands.CommandsContexts;
using Domain.Objects;
using Domain.Services;

namespace Domain.Entities.Commands
{
    public class AddEmployeeCommand : ICommand<AddEmployeeCommandContext>
    {
        private readonly IEmployeeService _employeeService;

        public AddEmployeeCommand(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public void Execute(AddEmployeeCommandContext commandContex)
        {
            _employeeService.AddEmployee(commandContex.Surname, commandContex.Name, commandContex.Patronymic);
        }
    }
}
