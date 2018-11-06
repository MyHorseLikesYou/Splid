using System;
using System.Collections.Generic;
using System.Linq;
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

        public GroupExpenseService(IGroupExpenseRepository groupExpensesRepository, IGroupRepository groupRepository)
        {
            _groupExpenseRepository = groupExpensesRepository ??
                                      throw new ArgumentNullException(nameof(groupExpensesRepository));
            _groupRepository = groupRepository ?? throw new ArgumentNullException(nameof(groupRepository));
        }

        public void CreateGroupExpense(Guid groupExpenseId, Guid groupId, GroupExpenseInput groupExpenseInput)
        {
            var isGroupExpenseExists = _groupExpenseRepository.IsGroupExpenseExists(groupExpenseId);
            if (isGroupExpenseExists)
                throw new EntityExistsException<GroupExpense>(groupExpenseId);

            var group = _groupRepository.GetById(groupId);
            if (group == null)
                throw new InvalidDomainOperationException();

            ValidateGroupHavePersons(group, GetGroupExpenseInputPersons(groupExpenseInput));

            var groupExpense = GroupExpense.Create(groupExpenseId, groupExpenseInput);

            _groupExpenseRepository.Add(groupExpense);
        }

        public void ChangeGroupExpense(Guid groupExpenseId, GroupExpenseInput groupExpenseInput)
        {
            var groupExpense = _groupExpenseRepository.GetById(groupExpenseId);
            if (groupExpense == null)
                throw new EntityNotFoundException<GroupExpense>(groupExpenseId);

            var group = _groupRepository.GetById(groupExpense.GroupId);

            ValidateGroupHavePersons(group, GetGroupExpenseInputPersons(groupExpenseInput));

            groupExpense.Change(groupExpenseInput);

            _groupExpenseRepository.Update(groupExpense);
        }

        public void DeleteGroupExpense(Guid groupExpenseId)
        {
            var groupExpense = _groupExpenseRepository.GetById(groupExpenseId);
            if (groupExpense == null)
                throw new EntityNotFoundException<GroupExpense>(groupExpenseId);

            _groupExpenseRepository.Delete(groupExpenseId);
        }

        private static IEnumerable<Guid> GetGroupExpenseInputPersons(GroupExpenseInput groupExpenseInput)
        {
            var expensesByPersonsIds = groupExpenseInput.Payments.Select(e => e.PersonId);
            var expensesForPersonsIds = groupExpenseInput.Expenses.Select(e => e.PersonId);
            return Enumerable.Concat(expensesByPersonsIds, expensesForPersonsIds).ToList();
        }

        private static void ValidateGroupHavePersons(Group group, IEnumerable<Guid> personsIds)
        {
            var unknownPersonsIds = personsIds
                .Where(personId => !group.HasPersonWithSameId(personId))
                .ToArray();

            if (unknownPersonsIds.Any())
                throw new InvalidDomainOperationException(
                    $"Участник(и) c Id {String.Join(", ", unknownPersonsIds)} не привязан(ы) к группе.");
        }
    }
}