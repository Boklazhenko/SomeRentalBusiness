using System;
using System.Collections.Generic;
using Domain.Entities;
using Domain.Repositories;

namespace Domain.Services
{
    public class ClientService : IClientService
    {
        private readonly IRepository<Client> _repository;

        public ClientService(IRepository<Client> repository)
        {
            _repository = repository;
        }

        public void AddClient(string surname, string firstName, string patronymic)
            => _repository.Add(new Client(surname, firstName, patronymic));

        public IEnumerable<Client> GetAllClients()
            => _repository.All();
    }
}