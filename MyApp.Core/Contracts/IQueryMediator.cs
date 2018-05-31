using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Core.Contracts
{
    public interface IQueryMediator
    {
        TResult GetResult<TQuery, TResult>(TQuery query) where TQuery : IQuery;
        Task<TResult> GetResultAsync<TQuery, TResult>(TQuery query) where TQuery : IQuery;
    }
}
