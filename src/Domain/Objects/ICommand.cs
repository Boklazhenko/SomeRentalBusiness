using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Objects
{
    public interface ICommand<in TCommandContex> where TCommandContex : ICommandContext
    {
        void Execute(TCommandContex commandContex);
    }
}
