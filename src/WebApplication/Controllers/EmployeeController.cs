using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Entities.Commands.CommandsContexts;
using Domain.Entities.Queries.QueriesCriterions;
using Domain.Objects;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IQueryBuilder _queryBuilder;
        private readonly ICommandBuilder _commandBuilder;

        public EmployeeController(IQueryBuilder queryBuilder,
            ICommandBuilder commandBuilder)
        {
            _queryBuilder = queryBuilder;
            _commandBuilder = commandBuilder;
        }

        [HttpGet]
        public IActionResult List()
        {
            IEnumerable<Employee> emps = _queryBuilder
                .For<IEnumerable<Employee>>()
                .With(new AllEntitiesCriterion());
            return View(emps);
        }

        public IActionResult Add(string name, string surname, string patronymic)
        {
            _commandBuilder.Execute(new AddEmployeeCommandContext
            {
                Name = name,
                Surname = surname,
                Patronymic = patronymic
            });

            IEnumerable<Employee> emps = _queryBuilder
                .For<IEnumerable<Employee>>()
                .With(new AllEntitiesCriterion());

            return View("List", emps);
        }
    }
}
