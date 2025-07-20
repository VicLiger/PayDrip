using PayDrip.Domain.Interfaces.Models;

namespace PayDrip.Domain.Models
{
    public class InvoiceItem : IChargeable
    {
        public string Description { get; private set; }
        public decimal Amount { get; private set; }

        public InvoiceItem(string description, decimal amount)
        {
            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentException("Descrição é obrigatória.");
            if (amount <= 0)
                throw new ArgumentException("Valor deve ser maior que zero.");

            Description = description;
            Amount = amount;
        }

        public decimal GetAmount() => Amount;
        public string GetDescription() => Description;
    }

}
