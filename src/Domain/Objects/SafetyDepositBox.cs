using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.Deposits;

namespace Domain.Objects
{
    public class SafetyDepositBox
    {
        IList<PassportDeposit> _passports = new List<PassportDeposit>();

        public void PutPassport(PassportDeposit passport)
        {
            if(passport == null)
                throw new ArgumentNullException(nameof(passport));
            _passports.Add(passport);
        }
            

        public void ReturnPassport(PassportDeposit passport)
        {
            if(passport == null)
                throw new ArgumentNullException(nameof(passport));
            if (!_passports.Contains(passport))
                throw new InvalidOperationException("Such passport is not found");
            _passports.Remove(passport);
        }

        public IEnumerable<PassportDeposit> GetAllPassports()
            => _passports.AsEnumerable();
    }
}
