using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PayDrip.Domain.Models;

namespace PayDrip.Domain.Interfaces.Repository
{
    /// <summary>
    /// Interface responsável pelas operações de persistência de assinaturas (Subscription).
    /// </summary>
    public interface ISubscriptionRepository
    {
        /// <summary>
        /// Obtém uma assinatura pelo seu identificador.
        /// </summary>
        Task<Subscription> GetByIdAsync(Guid id);

        /// <summary>
        /// Retorna todas as assinaturas de um cliente.
        /// </summary>
        Task<IEnumerable<Subscription>> GetByCustomerIdAsync(Guid customerId);

        /// <summary>
        /// Retorna todas as assinaturas de um plano.
        /// </summary>
        Task<IEnumerable<Subscription>> GetByPlanIdAsync(Guid planId);

        /// <summary>
        /// Retorna todas as assinaturas ativas.
        /// </summary>
        Task<IEnumerable<Subscription>> GetActiveSubscriptionsAsync();

        /// <summary>
        /// Adiciona uma nova assinatura.
        /// </summary>
        Task AddAsync(Subscription subscription);

        /// <summary>
        /// Atualiza uma assinatura existente.
        /// </summary>
        Task UpdateAsync(Subscription subscription);

        /// <summary>
        /// Remove uma assinatura pelo seu identificador.
        /// </summary>
        Task DeleteAsync(Guid id);

        /// <summary>
        /// Verifica se uma assinatura existe pelo seu identificador.
        /// </summary>
        Task<bool> ExistsAsync(Guid id);
    }
}
