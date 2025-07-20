using PayDrip.Domain.Interfaces.Models;

namespace PayDrip.Domain.Models
{
    public class Invoice : IChargeable
    {
        public Guid Id { get; private set; }
        public Guid SubscriptionId { get; private set; }
        public Guid CustomerId { get; private set; }

        public decimal TotalAmount { get; private set; }
        public DateTime IssuedDate { get; private set; }
        public DateTime DueDate { get; private set; }
        public InvoiceStatus Status { get; private set; }

        private readonly List<IChargeable> _items;
        public IReadOnlyCollection<IChargeable> Items => _items.AsReadOnly();

        public Invoice(Guid subscriptionId, Guid customerId, DateTime issuedDate, DateTime dueDate, IEnumerable<IChargeable> items)
        {
            if (subscriptionId == Guid.Empty) throw new ArgumentException("Assinatura inválida.");
            if (customerId == Guid.Empty) throw new ArgumentException("Cliente inválido.");
            if (dueDate <= issuedDate) throw new ArgumentException("Data de vencimento deve ser após a emissão.");
            if (items == null || !items.Any()) throw new ArgumentException("Fatura deve conter ao menos um item.");

            Id = Guid.NewGuid();
            SubscriptionId = subscriptionId;
            CustomerId = customerId;
            IssuedDate = issuedDate;
            DueDate = dueDate;
            Status = InvoiceStatus.Pending;

            _items = new List<IChargeable>(items);
            RecalculateTotal();
        }

        private void RecalculateTotal()
        {
            TotalAmount = _items.Sum(item => item.GetAmount());
        }

        // Métodos de status
        public void MarkAsPaid()
        {
            if (Status == InvoiceStatus.Canceled)
                throw new InvalidOperationException("Fatura cancelada não pode ser paga.");

            Status = InvoiceStatus.Paid;
        }

        public void Cancel()
        {
            if (Status == InvoiceStatus.Paid)
                throw new InvalidOperationException("Fatura já paga não pode ser cancelada.");

            Status = InvoiceStatus.Canceled;
        }

        public void MarkAsOverdue()
        {
            if (Status == InvoiceStatus.Pending && DateTime.UtcNow > DueDate)
                Status = InvoiceStatus.Overdue;
        }

        public void AddItem(IChargeable item)
        {
            if (Status != InvoiceStatus.Pending)
                throw new InvalidOperationException("Não é possível adicionar itens após fechamento.");

            _items.Add(item ?? throw new ArgumentNullException(nameof(item)));
            RecalculateTotal();
        }

        // Implementação da interface IChargeable
        public decimal GetAmount() => TotalAmount;

        public string GetDescription() => $"Fatura #{Id} - {Status}";
    }
}
