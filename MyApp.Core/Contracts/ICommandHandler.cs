using MyApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Core.Contracts
{
    public interface ICommandHandler<TCommand>
        where TCommand : ICommand
    {        
        CommandResult Handle(TCommand command);        
    }

    public interface ICommandHandlerAsync<TCommand>
    where TCommand : ICommand
    {        
        Task<CommandResult> HandleAsync(TCommand command);
    }
}
