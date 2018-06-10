using Splid.Domain.Main.Entities.Groups;
using Splid.Domain.Models.Groups;
using System;
using System.Collections.Generic;
using System.Text;

namespace Splid.Domain.Tests.Builders.Groups.Inputs
{
    public class PaymentInputBuilder : IBuilder<PaymentInput>
    {
        private PaymentInput _paymentInput;

        public PaymentInput Build()
        {
            throw new NotImplementedException();
        }

        public static PaymentInputBuilder New()
        {
            return new PaymentInputBuilder();
        }

        internal PaymentInputBuilder Set(Guid unknownPaymentByPersonId, Guid paymentForPersonId, int v)
        {
            throw new NotImplementedException();
        }
    }
}
