using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public abstract class Entity : IEntity
    {
        private int? _id;

        public int ID
        {
            get { return _id.Value; }
            set
            {
                if (_id.HasValue)
                    throw new InvalidOperationException("ID can not be modified");
                _id = value;
            }
        }
    }
}
