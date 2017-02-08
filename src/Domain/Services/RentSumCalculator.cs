using System;

namespace Domain.Services
{
    public class RentSumCalculator : IRentSumCalculator
    {
        private decimal _hourCost;
        private int _hoursCount;

        public decimal HourCost
        {
            get { return _hourCost; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("The cost of an hour cannot be less than zero");
                _hourCost = value;
            }
        }

        public int HoursCount
        {
            get { return _hoursCount; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("The count of hours cannot be less than zero");
                _hoursCount = value;
            }
        }

        public RentSumCalculator(decimal hourCost, int hoursCount)
            : base()
        {
            HourCost = hourCost;
            HoursCount = hoursCount;
        }

        public RentSumCalculator() { }

        public decimal Calculate()
            => HoursCount < 3
                ? HoursCount * HourCost
                : 2 * HourCost + (HoursCount - 2) * 0.8m * HourCost;

        public decimal Calcultate(Func<decimal, int, decimal> calculationFunc)
            => calculationFunc(HourCost, HoursCount);
    }
}