using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Entities.Commands.CommandsContexts;
using Domain.Entities.Queries.QueriesCriterions;
using Domain.Objects;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    public class BikeController : Controller
    {
        private readonly IQueryBuilder _queryBuilder;
        private readonly ICommandBuilder _commandBuilder;

        public BikeController(ICommandBuilder commandBuilder, IQueryBuilder queryBuilder)
        {
            _commandBuilder = commandBuilder;
            _queryBuilder = queryBuilder;
        }

        public IActionResult List()
        {
            IEnumerable<Bike> bikes = _queryBuilder.For<IEnumerable<Bike>>().With(new AllEntitiesCriterion());
            return View(bikes);
        }

        public IActionResult Add(string name, decimal hourCost)
        {
            _commandBuilder.Execute(new AddBikeCommandContext
            {
                BikeName = name,
                HourCost = hourCost
            });

            IEnumerable<Bike> bikes = _queryBuilder.For<IEnumerable<Bike>>().With(new AllEntitiesCriterion());
            return View("List", bikes);
        }
    }
}
