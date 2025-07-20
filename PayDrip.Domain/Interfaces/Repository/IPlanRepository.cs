using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PayDrip.Domain.Models;

namespace PayDrip.Domain.Interfaces.Repository
{
    /// <summary>
    /// Interface responsável pelas operações de persistência para planos de assinatura (Plan).
    /// </summary>
    public interface IPlanRepository
    {
        /// <summary>
        /// Obtém um plano pelo seu identificador único.
        /// </summary>
        /// <param name="id">Id do plano.</param>
        Task<Plan> GetByIdAsync(Guid id);

        /// <summary>
        /// Obtém todos os planos cadastrados.
        /// </summary>
        Task<IEnumerable<Plan>> GetAllAsync();

        /// <summary>
        /// Busca planos pelo nome.
        /// </summary>
        /// <param name="name">Nome parcial ou completo do plano.</param>
        Task<IEnumerable<Plan>> GetByNameAsync(string name);

        /// <summary>
        /// Adiciona um novo plano de assinatura.
        /// </summary>
        /// <param name="plan">Plano a ser criado.</param>
        Task AddAsync(Plan plan);

        /// <summary>
        /// Atualiza os dados de um plano existente.
        /// </summary>
        /// <param name="plan">Plano com dados atualizados.</param>
        Task UpdateAsync(Plan plan);

        /// <summary>
        /// Remove um plano pelo seu identificador.
        /// </summary>
        /// <param name="id">Id do plano a ser removido.</param>
        Task DeleteAsync(Guid id);

        /// <summary>
        /// Verifica se existe um plano com o identificador informado.
        /// </summary>
        /// <param name="id">Id do plano.</param>
        Task<bool> ExistsAsync(Guid id);
    }
}
