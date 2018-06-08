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
            var isGroupExists = _groupsRepository.IsGroupExists(groupId);
            if (isGroupExists)
                throw new EntityExistsException(groupId);

            var group = Group.Create(groupId, groupInput);

            _groupsRepository.Add(group);            
        }

        public void ChangeGroup(Guid groupId, GroupInput groupInput)
        {
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

        public void AddPayment(Guid groupId, Guid paymentId, PaymentInput paymentInput)
        {
            var isPaymentExists = _groupsRepository.IsPaymentExists(paymentId);
            if (isPaymentExists)
                throw new EntityExistsException(paymentId);

            var group = _groupsRepository.GetById(groupId);
            if (group == null)
                throw new EntityNotFoundException(groupId);

            group.AddPayment(paymentId, paymentInput);

            _groupsRepository.Update(group);            
        }

        public void ChangePayment(Guid groupId, Guid paymentId, PaymentInput paymentInput)
        {
            var group = _groupsRepository.GetById(groupId);
            if (group == null)
                throw new EntityNotFoundException(paymentId);

            group.ChangePayment(paymentId, paymentInput);

            _groupsRepository.Update(group);            
        }

        public void DeletePayment(Guid groupId, Guid paymentId)
        {
            var group = _groupsRepository.GetById(groupId);
            if (group == null)
                throw new EntityNotFoundException(groupId);

            group.DeletePayment(paymentId);

            _groupsRepository.Update(group);            
        }

        public void AddExpense(Guid groupId, Guid expenseId, ExpenseInput expenseInput)
        {
            var isExpenseExists = _groupsRepository.IsExpenseExists(expenseId);
            if (isExpenseExists)
                throw new EntityExistsException(expenseId);

            var group = _groupsRepository.GetById(groupId);
            if (group == null)
                throw new EntityNotFoundException(groupId);

            group.AddExpense(expenseId, expenseInput);

            _groupsRepository.Update(group);            
        }

        public void ChangeExpense(Guid groupId, Guid expenseId, ExpenseInput expenseInput)
        {
            var group = _groupsRepository.GetById(groupId);
            if (group == null)
                throw new EntityNotFoundException(expenseId);

            group.ChangeExpense(expenseId, expenseInput);

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

        public void AddPerson(Guid groupId, Guid personId, PersonInput personInput)
        {
            var isPersonExists = _groupsRepository.IsPersonExists(personId);
            if (isPersonExists)
                throw new EntityExistsException(groupId);

            var group = _groupsRepository.GetById(groupId);
            if (group == null)
                throw new EntityNotFoundException(groupId);

            group.AddPerson(personId, personInput);

            _groupsRepository.Update(group);            
        }

        public void ChangePerson(Guid groupId, Guid personId, PersonInput personInput)
        {
            var group = _groupsRepository.GetById(groupId);
            if (group == null)
                throw new EntityNotFoundException(groupId);

            group.ChangePerson(personId, personInput);

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
