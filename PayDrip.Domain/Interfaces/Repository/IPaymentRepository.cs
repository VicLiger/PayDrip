using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PayDrip.Domain.Models;

namespace PayDrip.Domain.Interfaces.Repository
{
    /// <summary>
    /// Interface para operações relacionadas a pagamentos.
    /// </summary>
    public interface IPaymentRepository
    {
        /// <summary>
        /// Obtém um pagamento pelo seu Id.
        /// </summary>
        Task<Payment> GetByIdAsync(Guid id);

        /// <summary>
        /// Obtém todos os pagamentos de uma fatura específica.
        /// </summary>
        Task<IEnumerable<Payment>> GetByInvoiceIdAsync(Guid invoiceId);

        /// <summary>
        /// Adiciona um novo pagamento.
        /// </summary>
        Task AddAsync(Payment payment);

        /// <summary>
        /// Atualiza os dados do pagamento (ex: status).
        /// </summary>
        Task UpdateAsync(Payment payment);

        /// <summary>
        /// Remove um pagamento pelo Id.
        /// </summary>
        Task DeleteAsync(Guid id);

        /// <summary>
        /// Verifica se o pagamento existe.
        /// </summary>
        Task<bool> ExistsAsync(Guid id);
    }
}
