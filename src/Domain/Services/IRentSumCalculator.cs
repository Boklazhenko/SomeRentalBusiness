using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Services
{
    public interface IRentSumCalculator
    {
        decimal Calculate();

        decimal Calcultate(Func<decimal, int, decimal> calculationFunc);
    }
}
