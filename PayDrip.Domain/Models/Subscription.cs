namespace PayDrip.Domain.Models
{
    /// <summary>
    /// Representa uma assinatura de um cliente a um plano.
    /// Conecta Customer e Plan via seus IDs.
    /// </summary>
    public class Subscription
    {
        public Guid Id { get; private set; }
        public Guid CustomerId { get; private set; }
        public Guid PlanId { get; private set; }

        public DateTime StartDate { get; private set; }
        public DateTime? EndDate { get; private set; }
        public SubscriptionStatus Status { get; private set; }

        private PaymentMethod _paymentMethod;

        /// <summary>
        /// Cria uma nova assinatura vinculada a um cliente e plano.
        /// </summary>
        public Subscription(Guid customerId, Guid planId, DateTime startDate, PaymentMethod paymentMethod)
        {
            Id = Guid.NewGuid();
            SetCustomerId(customerId);
            SetPlanId(planId);
            SetStartDate(startDate);
            SetPaymentMethod(paymentMethod);
            Status = SubscriptionStatus.Active;
        }

        /// <summary>
        /// Define o cliente da assinatura.
        /// </summary>
        public void SetCustomerId(Guid customerId)
        {
            if (customerId == Guid.Empty)
                throw new ArgumentException("CustomerId inválido.");
            CustomerId = customerId;
        }

        /// <summary>
        /// Define o plano da assinatura.
        /// </summary>
        public void SetPlanId(Guid planId)
        {
            if (planId == Guid.Empty)
                throw new ArgumentException("PlanId inválido.");
            PlanId = planId;
        }

        /// <summary>
        /// Define a data de início da assinatura.
        /// </summary>
        public void SetStartDate(DateTime startDate)
        {
            if (startDate == DateTime.MinValue)
                throw new ArgumentException("Data de início inválida.");
            StartDate = startDate;
        }

        /// <summary>
        /// Define a data de término da assinatura.
        /// </summary>
        public void SetEndDate(DateTime? endDate)
        {
            if (endDate.HasValue && endDate <= StartDate)
                throw new ArgumentException("Data de término deve ser depois da data de início.");
            EndDate = endDate;
        }

        /// <summary>
        /// Define o método de pagamento da assinatura.
        /// </summary>
        public void SetPaymentMethod(PaymentMethod paymentMethod)
        {
            _paymentMethod = paymentMethod;
        }

        /// <summary>
        /// Retorna o método de pagamento da assinatura.
        /// </summary>
        public PaymentMethod GetPaymentMethod() => _paymentMethod;

        // Controle de status

        /// <summary>
        /// Ativa a assinatura.
        /// </summary>
        public void Activate() => Status = SubscriptionStatus.Active;

        /// <summary>
        /// Cancela a assinatura.
        /// </summary>
        public void Cancel() => Status = SubscriptionStatus.Inactive;

        /// <summary>
        /// Suspende a assinatura.
        /// </summary>
        public void Suspend() => Status = SubscriptionStatus.Suspended;
    }
}
