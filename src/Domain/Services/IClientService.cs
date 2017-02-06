using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Services
{
    public interface IClientService
    {
        void AddClient(string surname, string firstName, string patronymic);

        IEnumerable<Client> GetAllClients();
    }
}
