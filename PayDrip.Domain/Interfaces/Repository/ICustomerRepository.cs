using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayDrip.Domain.Models;

namespace PayDrip.Domain.Interfaces.Repository
{
    public interface ICustomerRepository
    {
        /// <summary>
        /// Obtém um cliente pelo seu identificador único.
        /// </summary>
        Task<Customer> GetByIdAsync(Guid id);

        /// <summary>
        /// Obtém um cliente pelo seu e-mail.
        /// </summary>
        Task<Customer> GetByEmailAsync(string email);

        /// <summary>
        /// Retorna todos os clientes cadastrados.
        /// </summary>
        Task<IEnumerable<Customer>> GetAllAsync();

        /// <summary>
        /// Adiciona um novo cliente.
        /// </summary>
        Task AddAsync(Customer customer);

        /// <summary>
        /// Atualiza os dados de um cliente existente.
        /// </summary>
        Task UpdateAsync(Customer customer);

        /// <summary>
        /// Exclui um cliente pelo seu identificador.
        /// </summary>
        Task DeleteAsync(Guid id);

        /// <summary>
        /// Verifica se um cliente existe pelo seu identificador.
        /// </summary>
        Task<bool> ExistsAsync(Guid id);
    }
}
