using System;
using Splid.Domain.Main.Interfaces.Repositories;

namespace Splid.Domain.Main.Tests.Builders.Repositories
{
    public class GroupRepositoryBuilder : IBuilder<IGroupRepository>
    {
        public IGroupRepository Please()
        {
            throw new NotImplementedException();
        }

        public GroupRepositoryBuilder HaveGroupWithId(Guid groupId)
        {
            throw new NotImplementedException();
        }

        public GroupRepositoryBuilder WithGroups(params Group[] groups)
        {
            throw new NotImplementedException();
        }
    }
}