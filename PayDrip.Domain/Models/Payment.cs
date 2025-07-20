namespace PayDrip.Domain.Models
{
    public class Payment
    {
        public Guid Id { get; private set; }
        public Guid InvoiceId { get; private set; }
        public DateTime PaymentDate { get; private set; }
        public decimal Amount { get; private set; }
        public PaymentMethod Method { get; private set; }
        public PaymentStatus Status { get; private set; }

        public Payment(Guid invoiceId, decimal amount, PaymentMethod method)
        {
            if (invoiceId == Guid.Empty)
                throw new ArgumentException("Fatura inválida.");
            if (amount <= 0)
                throw new ArgumentException("Valor do pagamento deve ser maior que zero.");

            Id = Guid.NewGuid();
            InvoiceId = invoiceId;
            Amount = amount;
            Method = method;
            Status = PaymentStatus.Pending;
            PaymentDate = DateTime.UtcNow;
        }

        public void Approve()
        {
            if (Status != PaymentStatus.Pending)
                throw new InvalidOperationException("Pagamento já processado.");

            Status = PaymentStatus.Approved;
        }

        public void Reject()
        {
            if (Status != PaymentStatus.Pending)
                throw new InvalidOperationException("Pagamento já processado.");

            Status = PaymentStatus.Rejected;
        }

        public bool IsApproved() => Status == PaymentStatus.Approved;

        public bool IsPending() => Status == PaymentStatus.Pending;

        public bool IsRejected() => Status == PaymentStatus.Rejected;
    }
}
