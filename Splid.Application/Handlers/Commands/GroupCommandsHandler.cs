using MyApp.Core.Contracts;
using MyApp.Core.Models;
using Splid.Application.Commands.Expenses;
using Splid.Application.Commands.Groups;
using Splid.Application.Commands.Payments;
using Splid.Application.Commands.Persons;
using Splid.Application.Exceptions;
using Splid.Domain.Main.Services;
using Splid.Domain.Ownership.Services;
using System;

namespace Splid.Application.Handlers.Commands
{
    public class GroupCommandsHandler : CommandHandler,
        ICommandHandler<CreateGroupCommand>,
        ICommandHandler<ChangeGroupCommand>,
        ICommandHandler<DeleteGroupCommand>,
        ICommandHandler<CreateExpenseCommand>,
        ICommandHandler<ChangeExpenseCommand>,
        ICommandHandler<DeleteExpenseCommand>,
        ICommandHandler<CreatePaymentCommand>,
        ICommandHandler<ChangePaymentCommand>,
        ICommandHandler<DeletePaymentCommand>,
        ICommandHandler<CreatePersonCommand>,
        ICommandHandler<ChangePersonCommand>,
        ICommandHandler<DeletePersonCommand>
    {
        private GroupsService _groupsService;
        private PermisionsService _membershipsService;

        public GroupCommandsHandler(GroupsService groupsService, PermisionsService membershipsService)
        {
            _groupsService = groupsService ?? throw new ArgumentNullException(nameof(groupsService));
            _membershipsService = membershipsService ?? throw new ArgumentNullException(nameof(membershipsService));
        }

        public CommandResult Handle(CreateGroupCommand command)
        {
            return base.HandleByDefault<CreateGroupCommand>(command, CreateGroupCommandHandler);
        }

        public CommandResult Handle(ChangeGroupCommand command)
        {
            return base.HandleByDefault<ChangeGroupCommand>(command, ChangeGroupCommandHandler);
        }

        public CommandResult Handle(DeleteGroupCommand command)
        {
            return base.HandleByDefault<DeleteGroupCommand>(command, DeleteGroupCommandHandler);
        }

        public CommandResult Handle(CreateExpenseCommand command)
        {
            return this.HandleByDefault<CreateExpenseCommand>(command, CreateExpenseCommandHandler);
        }

        public CommandResult Handle(ChangeExpenseCommand command)
        {
            return this.HandleByDefault<ChangeExpenseCommand>(command, ChangeExpenseCommandHandler);
        }

        public CommandResult Handle(DeleteExpenseCommand command)
        {
            return this.HandleByDefault<DeleteExpenseCommand>(command, DeleteExpenseCommandHandler);
        }

        public CommandResult Handle(CreatePaymentCommand command)
        {
            return this.HandleByDefault<CreatePaymentCommand>(command, CreatePaymentCommandHandler);
        }

        public CommandResult Handle(ChangePaymentCommand command)
        {
            return this.HandleByDefault<ChangePaymentCommand>(command, ChangePaymentCommandHandler);
        }

        public CommandResult Handle(DeletePaymentCommand command)
        {
            return this.HandleByDefault<DeletePaymentCommand>(command, DeletePaymentCommandHandler);
        }

        public CommandResult Handle(CreatePersonCommand command)
        {
            return this.HandleByDefault<CreatePersonCommand>(command, CreatePersonCommandHandler);
        }

        public CommandResult Handle(ChangePersonCommand command)
        {
            return this.HandleByDefault<ChangePersonCommand>(command, ChangePersonCommandHandler);
        }

        public CommandResult Handle(DeletePersonCommand command)
        {
            return this.HandleByDefault<DeletePersonCommand>(command, DeletePersonCommandHandler);
        }

        private void CreateGroupCommandHandler(CreateGroupCommand createGroupCommand)
        {
            _groupsService.CreateGroup(createGroupCommand.GroupId, createGroupCommand.Group);

            foreach (var person in createGroupCommand.Persons)
                _groupsService.AddPerson(createGroupCommand.GroupId, person.Key, person.Value);

            //if (createGroupCommand.AuthorId.HasValue)
            //    _membershipsService.CreatePermission(createGroupCommand.GroupId, createGroupCommand.AuthorId.Value);
        }

        private void ChangeGroupCommandHandler(ChangeGroupCommand changeGroupCommand)
        {
            this.ValidateGroupDeleting(changeGroupCommand.GroupId, changeGroupCommand.AuthorId);
            _groupsService.ChangeGroup(changeGroupCommand.GroupId, changeGroupCommand.Group);
        }

        private void DeleteGroupCommandHandler(DeleteGroupCommand deleteGroupCommand)
        {
            this.ValidateGroupDeleting(deleteGroupCommand.GroupId, deleteGroupCommand.AuthorId);
            _groupsService.DeleteGroup(deleteGroupCommand.GroupId);
        }

        private void CreateExpenseCommandHandler(CreateExpenseCommand command)
        {
            this.ValidateGroupChanging(command.GroupId, command.AuthorId);
            _groupsService.AddExpense(command.GroupId, command.ExpenseId, command.Expense);
        }

        private void ChangeExpenseCommandHandler(ChangeExpenseCommand command)
        {
            this.ValidateGroupChanging(command.GroupId, command.AuthorId);
            _groupsService.ChangeExpense(command.GroupId, command.ExpenseId, command.Expense);
        }

        private void DeleteExpenseCommandHandler(DeleteExpenseCommand command)
        {
            this.ValidateGroupChanging(command.GroupId, command.AuthorId);
            _groupsService.DeleteExpense(command.GroupId, command.ExpenseId);
        }

        private void CreatePaymentCommandHandler(CreatePaymentCommand command)
        {
            this.ValidateGroupChanging(command.GroupId, command.AuthorId);
            _groupsService.AddPayment(command.GroupId, command.PaymentId, command.Payment);
        }

        private void ChangePaymentCommandHandler(ChangePaymentCommand command)
        {
            this.ValidateGroupChanging(command.GroupId, command.AuthorId);
            _groupsService.ChangePayment(command.GroupId, command.PaymentId, command.Payment);
        }

        private void DeletePaymentCommandHandler(DeletePaymentCommand command)
        {
            this.ValidateGroupChanging(command.GroupId, command.AuthorId);
            _groupsService.DeletePayment(command.GroupId, command.PaymentId);
        }

        private void CreatePersonCommandHandler(CreatePersonCommand command)
        {
            this.ValidateGroupChanging(command.GroupId, command.AuthorId);
            _groupsService.AddPerson(command.GroupId, command.PersonId, command.Person);
        }

        private void ChangePersonCommandHandler(ChangePersonCommand command)
        {
            this.ValidateGroupChanging(command.GroupId, command.AuthorId);
            _groupsService.ChangePerson(command.GroupId, command.PersonId, command.Person);
        }

        private void DeletePersonCommandHandler(DeletePersonCommand command)
        {
            this.ValidateGroupChanging(command.GroupId, command.AuthorId);
            _groupsService.DeletePerson(command.GroupId, command.PersonId);
        }

        private void ValidateGroupChanging(Guid groupId, Guid? authorId)
        {
            var canAuthorChangeGroup = _membershipsService.CanChangeGroup(groupId, authorId);
            if (canAuthorChangeGroup)
                return;

            throw new AccessDeniedException();
        }

        private void ValidateGroupDeleting(Guid groupId, Guid? authorId)
        {
            var canAuthorDeleteGroup = _membershipsService.CanDeleteGroup(groupId, authorId);
            if (canAuthorDeleteGroup)
                return;

            throw new AccessDeniedException();
        }
    }
}
