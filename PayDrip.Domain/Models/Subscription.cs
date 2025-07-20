using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayDrip.Domain.Models
{
    public class Subscription
    {
        public Guid Id { get; private set; }
        public Guid CustomerId { get; private set; }
        public Guid PlanId { get; private set; }

        public DateTime StartDate { get; private set; }
        public DateTime? EndDate { get; private set; }
        public SubscriptionStatus Status { get; private set; }

        private PaymentMethod _paymentMethod;

        public Subscription(Guid customerId, Guid planId, DateTime startDate, PaymentMethod paymentMethod)
        {
            Id = Guid.NewGuid();
            SetCustomerId(customerId);
            SetPlanId(planId);
            SetStartDate(startDate);
            SetPaymentMethod(paymentMethod);
            Status = SubscriptionStatus.Active;
        }

        public void SetCustomerId(Guid customerId)
        {
            if (customerId == Guid.Empty)
                throw new ArgumentException("CustomerId inválido.");
            CustomerId = customerId;
        }

        public void SetPlanId(Guid planId)
        {
            if (planId == Guid.Empty)
                throw new ArgumentException("PlanId inválido.");
            PlanId = planId;
        }

        public void SetStartDate(DateTime startDate)
        {
            if (startDate == DateTime.MinValue)
                throw new ArgumentException("Data de início inválida.");
            StartDate = startDate;
        }

        public void SetEndDate(DateTime? endDate)
        {
            if (endDate.HasValue && endDate <= StartDate)
                throw new ArgumentException("Data de término deve ser depois da data de início.");
            EndDate = endDate;
        }

        public void SetPaymentMethod(PaymentMethod paymentMethod)
        {
            _paymentMethod = paymentMethod ?? throw new ArgumentException("Método de pagamento é obrigatório.");
        }

        public PaymentMethod GetPaymentMethod() => _paymentMethod;

        // Controle de status
        public void Activate() => Status = SubscriptionStatus.Active;
        public void Cancel() => Status = SubscriptionStatus.Canceled;
        public void Suspend() => Status = SubscriptionStatus.Suspended;
    }
}
