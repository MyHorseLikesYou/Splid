using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Core.Contracts
{
    public interface IDomainOperationBuilder
    {
        IEnumerable<string> Errors { get; }

        IDomainOperation BuildOperation();
    }
}
