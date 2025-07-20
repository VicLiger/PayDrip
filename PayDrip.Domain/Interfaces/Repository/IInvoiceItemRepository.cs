using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PayDrip.Domain.Models;

namespace PayDrip.Domain.Interfaces.Repository
{
    /// <summary>
    /// Interface para operações de persistência de itens de fatura (InvoiceItem).
    /// </summary>
    public interface IInvoiceItemRepository
    {
        /// <summary>
        /// Retorna todos os itens de uma fatura específica.
        /// </summary>
        Task<IEnumerable<InvoiceItem>> GetByInvoiceIdAsync(Guid invoiceId);

        /// <summary>
        /// Adiciona um novo item à fatura.
        /// </summary>
        Task AddAsync(InvoiceItem item);

        /// <summary>
        /// Remove um item específico da fatura.
        /// </summary>
        Task DeleteAsync(Guid invoiceId, string description);
    }
}
