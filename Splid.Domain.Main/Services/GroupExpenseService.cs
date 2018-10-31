using System;
using MyApp.Core.Exceptions;
using Splid.Domain.Main.Entities.Groups;
using Splid.Domain.Main.Interfaces.Repositories;
using Splid.Domain.Main.Models.Groups;

namespace Splid.Domain.Main.Services
{
    public class GroupExpenseService
    {
        private IGroupRepository _groupRepository;
        private IGroupExpenseRepository _groupExpenseRepository;

        public GroupExpenseService(IGroupExpenseRepository groupExpensesRepository)
        {
            _groupExpenseRepository = groupExpensesRepository ??
                                      throw new ArgumentNullException(nameof(groupExpensesRepository));
        }

        public void Create(Guid groupExpenseId, Guid groupId, GroupExpenseInput groupExpenseInput)
        {
            var isGroupExpenseExists = _groupExpenseRepository.IsGroupExpenseExists(groupExpenseId);
            if (isGroupExpenseExists)
                throw new EntityExistsException<GroupExpense>(groupExpenseId);

            var group = _groupRepository.GetById(groupId);
            if (group == null)
                throw new InvalidDomainOperationException();

            var groupExpense = GroupExpense.Create(groupExpenseId, groupExpenseInput);

            _groupExpenseRepository.Add(groupExpense);
        }

        public void ChangeExpense(Guid groupExpenseId, GroupExpenseInput groupExpenseInput)
        {
            var groupExpense = _groupExpenseRepository.GetById(groupExpenseId);
            if (groupExpense == null)
                throw new EntityNotFoundException<GroupExpense>(groupExpenseId);

            var group = _groupRepository.GetById(groupExpense.GroupId);

            groupExpense.Change(groupExpenseInput);

            _groupExpenseRepository.Update(groupExpense);
        }

        public void DeleteExpense(Guid groupExpenseId)
        {
            var groupExpense = _groupExpenseRepository.GetById(groupExpenseId);
            if (groupExpense == null)
                throw new EntityNotFoundException<GroupExpense>(groupExpenseId);

            _groupExpenseRepository.Delete(groupExpenseId);
        }
    }
}