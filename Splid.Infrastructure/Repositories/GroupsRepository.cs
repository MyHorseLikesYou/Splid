using System;
using System.Linq;
using System.Net.Http.Headers;
using Splid.Domain.Main.Entities.Groups;
using Splid.Domain.Main.Interfaces.Repositories;
using Splid.Domain.Main.Values;
using DbGroup = Splid.Infrastructure.Models.Group;
using DbPayment = Splid.Infrastructure.Models.Payment;
using DbGroupExpense = Splid.Infrastructure.Models.GroupExpense;
using DbPerson = Splid.Infrastructure.Models.Person;
using DbPersonMoneyOperation = Splid.Infrastructure.Models.PersonMoneyOperation;

namespace Splid.Infrastructure.Repositories
{
    public class GroupsRepository : IGroupsRepository
    {
        private readonly SplidDbContext _context;

        public GroupsRepository(SplidDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        
        public void Add(Group obj)
        {
            var dbGroup = ToDbGroup(obj);
            _context.Groups.Add(dbGroup);
        }

        public Group GetById(Guid id)
        {
            var group = _context.Groups.SingleOrDefault(g => g.Id == id);
            return ToGroupEntity(group);
        }

        public IQueryable<Group> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Group obj)
        {
            var dbGroup = ToDbGroup(obj);
            _context.Groups.Update(dbGroup);
        }

        public void Remove(Group id)
        {
            var dbGroup = ToDbGroup(id);
            _context.Groups.Remove(dbGroup);
        }

        public void Remove(Guid id)
        {
            var dbGroup = _context.Groups.SingleOrDefault(g => g.Id == id);
            _context.Groups.Remove(dbGroup);
        }

        public bool IsGroupExists(Guid groupId)
        {
            return _context.Groups.Any(g => g.Id == groupId);
        }
        
        public void Dispose()
        {
            _context.Dispose();
        }

        private static Group ToGroupEntity(DbGroup group)
        {
            if (group == null)
                return null;
            
            var expenses = group.Expenses.Select(e => 
                new GroupExpense(
                    e.Id, 
                    e.Title,
                    e.PersonPayments.Select(pp => new PersonMoneyOperation(pp.PersonId, new Money(pp.Amount))),
                    e.PersonExpenses.Select(pe => new PersonMoneyOperation(pe.PersonId, new Money(pe.Amount))),
                    e.Date,
                    e.CreatedAt)
                );
            
            var payments = group.Payments.Select(e => 
                new Payment(
                    e.Id, 
                    e.SenderId,
                    e.RecipientId,
                    new Money(e.Amount), 
                    e.Date,
                    e.CreatedAt)
            );

            var persons = group.Persons.Select(p => new Person(p.Id, p.Name));
            
            return new Group(group.Id, group.Name, persons, payments, expenses);
        }
        
        private static DbGroup ToDbGroup(Group group)
        {
            throw new NotImplementedException();            
        }
    }
}