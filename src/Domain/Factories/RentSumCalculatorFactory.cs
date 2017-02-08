using Domain.Services;

namespace Domain.Factories
{
    public class RentSumCalculatorFactory : IRentSumCalculatorFactory
    {
        public RentSumCalculator CreateRentSumCalculator(decimal hourCost, int hoursCount)
            => new RentSumCalculator(hourCost, hoursCount);
    }
}