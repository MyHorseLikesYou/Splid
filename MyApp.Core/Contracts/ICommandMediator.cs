using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Core.Contracts
{
    public interface ICommandMediator
    {       
        void SendCommand<TCommand>(TCommand command) where TCommand : ICommand;
        Task SendCommandAsync<TCommand>(TCommand command) where TCommand : ICommand;
    }
}
