using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Core.Contracts
{
    public interface IQueryHandlerAsync<in TQuery, TResult> where TQuery : IQuery
    {
        Task<TResult> RetrieveAsync(TQuery query);
    }
}
