using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Services;

namespace Domain.Factories
{
    public interface IRentSumCalculatorFactory
    {
        RentSumCalculator CreateRentSumCalculator(decimal hourCost, int hoursCount);
    }
}
