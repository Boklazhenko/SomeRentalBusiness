using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using Domain.Repositories;

namespace Domain.Services
{
    public class RentPointService : IRentPointService
    {
        private readonly IRepository<RentPoint> _repository;

        public RentPointService(IRepository<RentPoint> repository)
        {
            _repository = repository;
        }

        public void AddRentPoint(Employee emp, decimal money)
            => _repository.Add(new RentPoint(emp, money));

        public IEnumerable<RentPoint> GetAllRentPoints()
            => _repository.All();
    }
}