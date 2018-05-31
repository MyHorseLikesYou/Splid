﻿using MyApp.Core.Contracts;
using MyApp.Core.Models;
using System;

namespace Splid.Application.Handlers.Commands
{
    public abstract class CommandHandler
    {        
        protected CommandResult HandleByDefault<ICommand>(ICommand command, Action<ICommand> commandHandler)
        {
            try
            {
                commandHandler.Invoke(command);                

                return CommandResult.Success;
            }
            catch (Exception ex)
            {
                return CommandResult.Fail(ex.Message);
            }
        }
    }
}