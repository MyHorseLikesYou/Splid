using System;
using System.Linq;
using MyApp.Core.Exceptions;
using Splid.Domain.Main.Entities;
using Splid.Domain.Main.Interfaces.Repositories;
using Splid.Domain.Main.Models;

namespace Splid.Domain.Main.Services
{
    public class PaymentService
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IGroupRepository _groupRepository;

        public PaymentService(IPaymentRepository paymentRepository, IGroupRepository groupRepository)
        {
            _paymentRepository = paymentRepository ?? throw new ArgumentNullException(nameof(paymentRepository));
            _groupRepository = groupRepository ?? throw new ArgumentNullException(nameof(groupRepository));
        }

        public void AddPayment(Guid groupId, Guid paymentId, PaymentInput paymentInput)
        {
            var isPaymentExists = _paymentRepository.IsPaymentExists(paymentId);
            if (isPaymentExists)
                throw new EntityExistsException<Payment>(paymentId);

            var group = _groupRepository.GetById(groupId);
            if (group == null)
                throw new InvalidDomainOperationException();
            
            ValidateGroupHavePersons(group, paymentInput.SenderId, paymentInput.RecipientId);

            var payment = Payment.Create(paymentId, paymentInput);

            _paymentRepository.Add(payment);
        }

        public void ChangePayment(Guid paymentId, PaymentInput paymentInput)
        {
            var payment = _paymentRepository.GetById(paymentId);
            if (payment == null)
                throw new EntityNotFoundException<Payment>(paymentId);

            var group = _groupRepository.GetById(payment.GroupId);
            
            ValidateGroupHavePersons(group, paymentInput.SenderId, paymentInput.RecipientId);
            
            payment.Change(paymentInput);

            _paymentRepository.Update(payment);
        }

        public void DeletePayment(Guid paymentId)
        {
            var payment = _paymentRepository.GetById(paymentId);
            if (payment == null)
                throw new EntityNotFoundException<GroupExpense>(paymentId);

            _paymentRepository.Delete(payment);
        }

        private static void ValidateGroupHavePersons(Group group, params Guid[] personsIds)
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