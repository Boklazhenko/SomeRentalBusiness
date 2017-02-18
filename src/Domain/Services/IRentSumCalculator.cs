using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Services
{
    public interface IRentSumCalculator
    {
        decimal Calculate();

        decimal Calculate(decimal hoursCost, int hoursCount);

        decimal Calculate(Func<decimal, int, decimal> calculationFunc);
    }
}
