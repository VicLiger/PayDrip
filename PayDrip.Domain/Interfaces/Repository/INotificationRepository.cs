using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PayDrip.Domain.Models;

namespace PayDrip.Domain.Interfaces.Repository
{
    /// <summary>
    /// Interface responsável pelas operações de persistência de notificações.
    /// </summary>
    public interface INotificationRepository
    {
        /// <summary>
        /// Obtém uma notificação por seu Id.
        /// </summary>
        Task<Notification> GetByIdAsync(Guid id);

        /// <summary>
        /// Retorna todas as notificações pendentes.
        /// </summary>
        Task<IEnumerable<Notification>> GetPendingAsync();

        /// <summary>
        /// Retorna todas as notificações de uma entidade (ex: fatura, assinatura).
        /// </summary>
        Task<IEnumerable<Notification>> GetByRelatedEntityAsync(Guid relatedEntityId, string relatedEntityType);

        /// <summary>
        /// Adiciona uma nova notificação.
        /// </summary>
        Task AddAsync(Notification notification);

        /// <summary>
        /// Atualiza o status da notificação (enviada, falhou, etc).
        /// </summary>
        Task UpdateAsync(Notification notification);

        /// <summary>
        /// Remove uma notificação.
        /// </summary>
        Task DeleteAsync(Guid id);
    }
}
