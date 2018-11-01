using System;
using MyApp.Core.Exceptions;
using Splid.Domain.Main.Entities.Groups;
using Splid.Domain.Main.Interfaces.Repositories;
using Splid.Domain.Main.Models.Groups;

namespace Splid.Domain.Main.Services
{
    public class PaymentService
    {
        private readonly IPaymentRepository _paymentRepository;

        public PaymentService(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository ?? throw new ArgumentNullException(nameof(paymentRepository));
        }

        public void AddPayment(Guid paymentId, Guid groupId, PaymentInput paymentInput)
        {
            var isGroupExpenseExists = _paymentRepository.IsPaymentExists(paymentId);
            if (isGroupExpenseExists)
                throw new EntityExistsException<Payment>(paymentId);

            var group = _paymentRepository.GetById(groupId);
            if (group == null)
                throw new InvalidDomainOperationException();

            var payment = Payment.Create(paymentId, paymentInput);
            
            _paymentRepository.Add(payment);
        }

        public void ChangePayment(Guid paymentId, PaymentInput paymentInput)
        {
            var payment = _paymentRepository.GetById(paymentId);
            if (payment == null)
                throw new EntityNotFoundException<Payment>(paymentId);

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
    }
}