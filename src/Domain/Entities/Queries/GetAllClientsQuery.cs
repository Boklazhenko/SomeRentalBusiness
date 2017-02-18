using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.Queries.QueriesCriterions;
using Domain.Objects;
using Domain.Services;

namespace Domain.Entities.Queries
{
    public class GetAllClientsQuery : IQuery<AllEntitiesCriterion, IEnumerable<Client>>
    {
        private readonly IClientService _clientService;

        public GetAllClientsQuery(IClientService clientService)
        {
            _clientService = clientService;
        }

        public IEnumerable<Client> Ask(AllEntitiesCriterion criterion)
            => _clientService.GetAllClients();
    }
}
