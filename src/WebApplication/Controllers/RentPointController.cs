using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Entities.Commands.CommandsContexts;
using Domain.Entities.Queries.QueriesCriterions;
using Domain.Objects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.DotNet.ProjectModel.FileSystemGlobbing.Internal.PathSegments;

namespace WebApplication.Controllers
{
    public class RentPointController : Controller
    {
        private readonly IQueryBuilder _queryBuilder;
        private readonly ICommandBuilder _commandBuilder;

        public RentPointController(IQueryBuilder queryBuilder, ICommandBuilder commandBuilder)
        {
            _queryBuilder = queryBuilder;
            _commandBuilder = commandBuilder;
        }

        [HttpGet]
        public IActionResult List()
        {
            IEnumerable<RentPoint> rentPoints = _queryBuilder
                .For<IEnumerable<RentPoint>>()
                .With(new AllEntitiesCriterion());
            IEnumerable<Employee> emps = _queryBuilder
                .For<IEnumerable<Employee>>()
                .With(new AllEntitiesCriterion());
            ViewBag.Employees = new SelectList(emps, "ID", "FullName");
            return View(rentPoints);
        }

        [HttpPost]
        public IActionResult Add(int ID, decimal money, string name)
        {
            Employee employee = _queryBuilder.For<Employee>().With(new IdCriterion
            {
                ID = ID
            });
            _commandBuilder.Execute(new AddRentPointCommandContext
            {
                Employee = employee,
                Money = money,
                Name = name
            });

            IEnumerable<Employee> emps = _queryBuilder
                .For<IEnumerable<Employee>>()
                .With(new AllEntitiesCriterion());
            IEnumerable<RentPoint> rentPoints = _queryBuilder
                .For<IEnumerable<RentPoint>>()
                .With(new AllEntitiesCriterion());
            ViewBag.Employees = new SelectList(emps, "ID", "FullName");
            return View("List", rentPoints);
        }

        public IActionResult Details(int ID)
        {
            RentPoint rentPoint = _queryBuilder
                .For<RentPoint>()
                .With(new IdCriterion
                {
                    ID = ID
                });
            IEnumerable<Bike> bikes = _queryBuilder
                .For<IEnumerable<Bike>>()
                .With(new FreeBikesCriterion());
            ViewBag.Bikes = new SelectList(bikes, "ID", "Name");
            return View(rentPoint);
        }

        public IActionResult MoveBike(int bikeID, int rentpointID)
        {
            Bike bike = _queryBuilder
                .For<Bike>()
                .With(new IdCriterion
                {
                    ID = bikeID
                });
            RentPoint rentPoint = _queryBuilder
                .For<RentPoint>()
                .With(new IdCriterion
                {
                    ID = rentpointID
                });
            bike.MoveTo(rentPoint);
            IEnumerable<Bike> bikes = _queryBuilder
                .For<IEnumerable<Bike>>()
                .With(new FreeBikesCriterion());
            ViewBag.Bikes = new SelectList(bikes, "ID", "Name");
            return View("Details", rentPoint);
        }
    }
}
