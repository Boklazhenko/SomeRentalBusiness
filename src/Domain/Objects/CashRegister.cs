using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Objects
{
    public class CashRegister
    {
        private decimal _money;

        public decimal Money
        {
            get { return _money; }
            protected set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value));
                _money = value;
            }
        }

        public CashRegister(decimal money)
            : this()
        {
            Money = money;
        }

        public CashRegister()
        {
        }

        public void PutMoney(decimal money)
        {
            Money += money;
        }

        public void TakeMoney(decimal money)
        {
            if (money > Money)
                throw new InvalidOperationException("Not enough money");
            Money -= money;
        }
    }
}
