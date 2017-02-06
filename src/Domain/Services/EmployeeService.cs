using System;
using Domain.Entities;
using Domain.Repositories;

namespace Domain.Services
{
    class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeVerifier _empVerifier;
        private readonly IRepository<Employee> _empRepository;

        public EmployeeService(IEmployeeVerifier empVerifier, IRepository<Employee> empRepository)
        {
            _empVerifier = empVerifier;
            _empRepository = empRepository;
        }

        public void AddEmployee(string surname, string firstName, string patronymic)
        {
            Employee employee = new Employee(surname, firstName, patronymic);
            if(_empVerifier.IsExist(employee))
                throw new InvalidOperationException("This Employee already exists");
            _empRepository.Add(employee);
        }
    }
}