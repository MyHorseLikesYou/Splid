using System;
using System.Linq;
using Splid.Domain.Main.Entities;
using Splid.Domain.Main.Interfaces.Repositories;
using DbGroup = Splid.Infrastructure.Models.Group;
using DbPayment = Splid.Infrastructure.Models.Payment;
using DbGroupExpense = Splid.Infrastructure.Models.GroupExpense;
using DbPerson = Splid.Infrastructure.Models.Person;
using DbPersonMoneyOperation = Splid.Infrastructure.Models.PersonMoneyOperation;

namespace Splid.Infrastructure.Repositories
{
    public class GroupsExpenseRepository : IGroupExpenseRepository
    {
        private readonly SplidDbContext _context;

        public GroupsExpenseRepository(SplidDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Add(GroupExpense obj)
        {
            throw new NotImplementedException();
        }

        public GroupExpense GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<GroupExpense> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(GroupExpense obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(GroupExpense id)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool IsGroupExpenseExists(Guid groupExpenseId)
        {
            throw new NotImplementedException();
        }
    }
}