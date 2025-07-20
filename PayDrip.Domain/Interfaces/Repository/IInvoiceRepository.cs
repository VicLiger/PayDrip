using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayDrip.Domain.Models;

namespace PayDrip.Domain.Interfaces.Repository
{
    public interface IInvoiceRepository
    {
        /// <summary>
        /// Obtém uma fatura pelo seu identificador único.
        /// </summary>
        Task<Invoice> GetByIdAsync(Guid id);

        /// <summary>
        /// Retorna todas as faturas de um determinado cliente.
        /// </summary>
        Task<IEnumerable<Invoice>> GetByCustomerIdAsync(Guid customerId);

        /// <summary>
        /// Retorna todas as faturas vinculadas a uma assinatura.
        /// </summary>
        Task<IEnumerable<Invoice>> GetBySubscriptionIdAsync(Guid subscriptionId);

        /// <summary>
        /// Adiciona uma nova fatura.
        /// </summary>
        Task AddAsync(Invoice invoice);

        /// <summary>
        /// Atualiza os dados de uma fatura existente.
        /// </summary>
        Task UpdateAsync(Invoice invoice);

        /// <summary>
        /// Exclui uma fatura pelo seu identificador.
        /// </summary>
        Task DeleteAsync(Guid id);

        /// <summary>
        /// Verifica se uma fatura existe pelo seu identificador.
        /// </summary>
        Task<bool> ExistsAsync(Guid id);
    }
}
