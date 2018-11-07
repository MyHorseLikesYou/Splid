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
    public class GroupsRepository : IGroupRepository
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

        public void Delete(Group id)
        {
            var dbGroup = ToDbGroup(id);
            _context.Groups.Remove(dbGroup);
        }

        public void Delete(Guid id)
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

        private static Group ToGroupEntity(DbGroup dbGroup)
        {
            if (dbGroup == null)
                return null;

            var dbGroupPersons = dbGroup.Persons
                .Select(p => new Person(p.Id, p.Name))
                .ToList();

            return new Group(dbGroup.Id, dbGroup.Name, dbGroupPersons);
        }

        private static DbGroup ToDbGroup(Group group)
        {
            if (group == null)
                return null;

            var persons = group.Persons
                .Select(p => new DbPerson {Id = p.Id, Name = p.Name})
                .ToList();

            return new DbGroup
            {
                Id = group.Id,
                Name = group.Name,
                Persons = persons
            };
        }
    }
}