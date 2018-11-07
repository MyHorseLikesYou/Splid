using System;
using System.Linq;
using Splid.Domain.Main.Entities;
using Splid.Domain.Main.Interfaces.Repositories;

namespace Splid.Infrastructure.Repositories
{
    public class PaymentRepository : IGroupRepository
    {
        private readonly SplidDbContext _context;

        public PaymentRepository(SplidDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Add(Group obj)
        {
            throw new NotImplementedException();
        }

        public Group GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Group> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Group obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(Group id)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool IsGroupExists(Guid groupId)
        {
            throw new NotImplementedException();
        }
    }
}