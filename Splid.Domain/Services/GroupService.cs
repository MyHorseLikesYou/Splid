using Splid.Application.Exceptions;
using Splid.Domain.Contracts.Repositories;
using Splid.Domain.Main.Entities.Groups;
using Splid.Domain.Models.Groups;
using System;

namespace Splid.Domain.Main.Services
{
    public class GroupsService
    {        
        private IGroupsRepository _groupsRepository;

        public GroupsService(IGroupsRepository groupsRepository)
        {
            _groupsRepository = groupsRepository ?? throw new ArgumentNullException(nameof(groupsRepository));
        }

        public void CreateGroup(Guid groupId, GroupInput groupInput)
        {
            if (groupInput == null)
                throw new ArgumentNullException(nameof(groupInput));

            var isGroupExists = _groupsRepository.IsGroupExists(groupId);
            if (isGroupExists)
                throw new EntityExistsException(groupId);

            var group = new Group(groupId, groupInput);

            _groupsRepository.Add(group);            
        }

        public void ChangeGroup(Guid groupId, GroupInput groupInput)
        {
            if (groupInput == null)
                throw new ArgumentNullException(nameof(groupInput));

            var group = _groupsRepository.GetById(groupId);
            if (group == null)
                throw new EntityNotFoundException(groupId);

            group.Change(groupInput);

            _groupsRepository.Update(group);            
        }

        public void DeleteGroup(Guid groupId)
        {
            if (!_groupsRepository.IsGroupExists(groupId))
                throw new EntityNotFoundException(groupId);

            _groupsRepository.Remove(groupId);            
        }

        public void AddPayment(Guid groupId, PaymentInput paymentInput)
        {
            if (paymentInput == null)
                throw new ArgumentNullException(nameof(paymentInput));

            var isPaymentExists = _groupsRepository.IsPaymentExists(paymentInput.Id);
            if (isPaymentExists)
                throw new EntityExistsException(paymentInput.Id);

            var group = _groupsRepository.GetById(groupId);
            if (group == null)
                throw new EntityNotFoundException(groupId);

            group.AddPayment(paymentInput);

            _groupsRepository.Update(group);            
        }

        public void ChangePayment(Guid groupId, PaymentInput paymentInput)
        {
            if (paymentInput == null)
                throw new ArgumentNullException(nameof(paymentInput));

            var group = _groupsRepository.GetById(groupId);
            if (group == null)
                throw new EntityNotFoundException(paymentInput.Id);

            group.ChangePayment(paymentInput);

            _groupsRepository.Update(group);            
        }

        public void DeletePayment(Guid groupId, Guid paymentId)
        {
            var group = _groupsRepository.GetById(groupId);
            if (group == null)
                throw new EntityNotFoundException(groupId);

            group.DelelePayment(paymentId);

            _groupsRepository.Update(group);            
        }

        public void AddExpense(Guid groupId, ExpenseInput expenseInput)
        {
            if (expenseInput == null)
                throw new ArgumentNullException(nameof(expenseInput));

            var isExpenseExists = _groupsRepository.IsExpenseExists(expenseInput.Id);
            if (isExpenseExists)
                throw new EntityExistsException(expenseInput.Id);

            var group = _groupsRepository.GetById(groupId);
            if (group == null)
                throw new EntityNotFoundException(groupId);

            group.AddExpense(expenseInput);

            _groupsRepository.Update(group);            
        }

        public void ChangeExpense(Guid groupId, ExpenseInput expenseInput)
        {
            var group = _groupsRepository.GetById(expenseInput.Id);
            if (group == null)
                throw new EntityNotFoundException(expenseInput.Id);

            group.ChangeExpense(expenseInput);

            _groupsRepository.Update(group);            
        }

        public void DeleteExpense(Guid groupId, Guid expenseId)
        {
            var group = _groupsRepository.GetById(groupId);
            if (group == null)
                throw new EntityNotFoundException(expenseId);

            group.DeleteExpense(expenseId);

            _groupsRepository.Update(group);
        }

        public void AddPerson(Guid groupId, PersonInput personInput)
        {
            if (personInput == null)
                throw new ArgumentNullException(nameof(personInput));

            var isPersonExists = _groupsRepository.IsPersonExists(personInput.PersonId);
            if (isPersonExists)
                throw new EntityExistsException(groupId);

            var group = _groupsRepository.GetById(groupId);
            if (group == null)
                throw new EntityNotFoundException(groupId);

            group.AddPerson(personInput);

            _groupsRepository.Update(group);            
        }

        public void ChangePerson(Guid groupId, PersonInput personInput)
        {
            if (personInput == null)
                throw new ArgumentNullException(nameof(personInput));

            var group = _groupsRepository.GetById(groupId);
            if (group == null)
                throw new EntityNotFoundException(groupId);

            group.ChangePerson(personInput);

            _groupsRepository.Update(group);            
        }

        public void DeletePerson(Guid groupId, Guid personId)
        {
            var group = _groupsRepository.GetById(groupId);
            if (group == null)
                throw new EntityNotFoundException(groupId);

            group.DeletePerson(personId);

            _groupsRepository.Update(group);            
        }
    }
}
