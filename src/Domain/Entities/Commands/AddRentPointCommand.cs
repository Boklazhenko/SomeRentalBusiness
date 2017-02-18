using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.Commands.CommandsContexts;
using Domain.Objects;
using Domain.Services;

namespace Domain.Entities.Commands
{
    public class AddRentPointCommand :ICommand<AddRentPointCommandContext>
    {
        private readonly IRentPointService _rentPointService;

        public AddRentPointCommand(IRentPointService rentPointService)
        {
            _rentPointService = rentPointService;
        }

        public void Execute(AddRentPointCommandContext commandContex)
        {
            _rentPointService.AddRentPoint(commandContex.Employee, commandContex.Money);
        }
    }
}
