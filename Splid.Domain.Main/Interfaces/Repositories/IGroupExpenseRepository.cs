using System;
using MyApp.Core.Contracts;
using Splid.Domain.Main.Entities;

namespace Splid.Domain.Main.Interfaces.Repositories
{
    public interface IGroupExpenseRepository : IRepository<GroupExpense>
    {
        bool IsGroupExpenseExists(Guid groupExpenseId);
    }
}