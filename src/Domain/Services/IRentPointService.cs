using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Services
{
    public interface IRentPointService
    {
        void AddRentPoint(Employee emp, decimal money);

        IEnumerable<RentPoint> GetAllRentPoints();
    }
}
