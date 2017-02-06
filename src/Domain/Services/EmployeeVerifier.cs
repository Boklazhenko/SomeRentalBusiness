using System;
using System.Linq;
using Domain.Entities;
using Domain.Repositories;

namespace Domain.Services
{
    public class EmployeeVerifier : IEmployeeVerifier
    {
        private readonly IRepository<Employee> _empRepository;

        public EmployeeVerifier(IRepository<Employee> empRepository)
        {
            _empRepository = empRepository;
        }

        public bool IsExist(Employee emp) 
            => _empRepository.All().All(e => e.FullName != emp.FullName);
    }
}