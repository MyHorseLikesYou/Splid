using MyApp.Core.Exceptions;
using Splid.Domain.Main.Interfaces.Repositories;
using System;
using Splid.Domain.Main.Entities;
using Splid.Domain.Main.Models;

namespace Splid.Domain.Main.Services
{
    public class GroupsService
    {        
        private IGroupRepository _groupsRepository;

        public GroupsService(IGroupRepository groupsRepository)
        {
            _groupsRepository = groupsRepository ?? throw new ArgumentNullException(nameof(groupsRepository));
        }

        public void CreateGroup(Guid groupId, GroupInput groupInput)
        {
            var isGroupExists = _groupsRepository.IsGroupExists(groupId);
            if (isGroupExists)
                throw new EntityExistsException<Group>(groupId);

            var group = Group.Create(groupId, groupInput);

            _groupsRepository.Add(group);            
        }

        public void ChangeGroup(Guid groupId, GroupInput groupInput)
        {
            var group = _groupsRepository.GetById(groupId);
            if (group == null)
                throw new EntityNotFoundException<Group>(groupId);

            group.Change(groupInput);

            _groupsRepository.Update(group);            
        }

        public void DeleteGroup(Guid groupId)
        {
            if (!_groupsRepository.IsGroupExists(groupId))
                throw new EntityNotFoundException<Group>(groupId);

            _groupsRepository.Delete(groupId);            
        }

        public void AddPerson(Guid groupId, Guid personId, PersonInput personInput)
        {
            var group = _groupsRepository.GetById(groupId);
            if (group == null)
                throw new EntityNotFoundException<Group>(groupId);

            group.AddPerson(personId, personInput);

            _groupsRepository.Update(group);            
        }

        public void ChangePerson(Guid groupId, Guid personId, PersonInput personInput)
        {
            var group = _groupsRepository.GetById(groupId);
            if (group == null)
                throw new EntityNotFoundException<Group>(groupId);

            group.ChangePerson(personId, personInput);

            _groupsRepository.Update(group);            
        }

        public void DeletePerson(Guid groupId, Guid personId)
        {
            var group = _groupsRepository.GetById(groupId);
            if (group == null)
                throw new EntityNotFoundException<Group>(groupId);

            group.DeletePerson(personId);

            _groupsRepository.Update(group);            
        }
    }
}
