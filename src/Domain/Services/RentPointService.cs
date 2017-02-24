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

        public void AddRentPoint(Employee emp, decimal money, string name)
            => _repository.Add(new RentPoint(emp, money, name));

        public IEnumerable<RentPoint> GetAllRentPoints()
            => _repository.All();

        public RentPoint GetRentPoint(int ID)
        {
            return _repository.Get(ID);
        }
    }
}