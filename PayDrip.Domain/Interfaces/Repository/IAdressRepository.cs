using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PayDrip.Domain.Models;

namespace PayDrip.Domain.Interfaces.Repository
{
    /// <summary>
    /// Interface responsável pelas operações de acesso a dados relacionadas à entidade Address.
    /// </summary>
    public interface IAddressRepository
    {
        /// <summary>
        /// Obtém um endereço pelo identificador único.
        /// </summary>
        /// <param name="id">Identificador do endereço.</param>
        /// <returns>O endereço correspondente ou null, se não encontrado.</returns>
        Task<Address> GetByIdAsync(Guid id);

        /// <summary>
        /// Retorna todos os endereços vinculados a um determinado cliente.
        /// </summary>
        /// <param name="customerId">Identificador do cliente.</param>
        /// <returns>Lista de endereços associados ao cliente.</returns>
        Task<IEnumerable<Address>> GetByCustomerIdAsync(Guid customerId);

        /// <summary>
        /// Adiciona um novo endereço ao repositório.
        /// </summary>
        /// <param name="address">Objeto Address a ser persistido.</param>
        Task AddAsync(Address address);

        /// <summary>
        /// Atualiza os dados de um endereço existente.
        /// </summary>
        /// <param name="address">Objeto Address atualizado.</param>
        Task UpdateAsync(Address address);

        /// <summary>
        /// Remove um endereço com base no seu identificador.
        /// </summary>
        /// <param name="id">Identificador do endereço a ser excluído.</param>
        Task DeleteAsync(Guid id);

        /// <summary>
        /// Verifica se um endereço existe no repositório.
        /// </summary>
        /// <param name="id">Identificador do endereço.</param>
        /// <returns>True se o endereço existir; caso contrário, false.</returns>
        Task<bool> ExistsAsync(Guid id);
    }
}
