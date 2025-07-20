namespace PayDrip.Domain.Models
{
    /// <summary>
    /// Representa um cliente do sistema, incluindo dados pessoais, endereço e informações de pagamento.
    /// </summary>
    public class Customer
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string DocumentNumber { get; private set; }
        public string Phone { get; private set; }
        public Address Address { get; private set; }
        public CustomerStatus Status { get; private set; }

        private Payment _paymentInfo;

        /// <summary>
        /// Cria um novo cliente, vinculando endereço e informações de pagamento.
        /// </summary>
        public Customer(string name, string email, string documentNumber, string phone, Address address, Payment paymentInfo)
        {
            Id = Guid.NewGuid();
            SetName(name);
            SetEmail(email);
            SetDocumentNumber(documentNumber);
            SetPhone(phone);
            SetAddress(address); // Vincula o endereço ao cliente
            SetPaymentInfo(paymentInfo);
            Status = CustomerStatus.Active;
        }

        /// <summary>
        /// Define o nome do cliente.
        /// </summary>
        public void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Nome não pode ser vazio.");

            Name = name.Trim();
        }

        /// <summary>
        /// Define o e-mail do cliente.
        /// </summary>
        public void SetEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email) || !email.Contains("@"))
                throw new ArgumentException("Email inválido.");

            Email = email.Trim().ToLower();
        }

        /// <summary>
        /// Define o documento do cliente.
        /// </summary>
        public void SetDocumentNumber(string documentNumber)
        {
            if (string.IsNullOrWhiteSpace(documentNumber))
                throw new ArgumentException("Documento é obrigatório.");

            DocumentNumber = documentNumber.Trim();
        }

        /// <summary>
        /// Define o telefone do cliente.
        /// </summary>
        public void SetPhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
                throw new ArgumentException("Telefone é obrigatório.");

            Phone = phone.Trim();
        }

        /// <summary>
        /// Vincula o endereço ao cliente, atualizando o CustomerId do endereço.
        /// </summary>
        public void SetAddress(Address address)
        {
            if (address == null)
                throw new ArgumentException("Endereço inválido.");

            address.SetCustomerId(this.Id);
            Address = address;
        }

        /// <summary>
        /// Define as informações de pagamento do cliente.
        /// </summary>
        public void SetPaymentInfo(Payment paymentInfo)
        {
            if (paymentInfo == null)
                throw new ArgumentException("Informações de pagamento inválidas.");

            _paymentInfo = paymentInfo;
        }

        /// <summary>
        /// Retorna as informações de pagamento do cliente.
        /// </summary>
        public Payment GetPaymentInfo()
        {
            return _paymentInfo;
        }

        /// <summary>
        /// Ativa o cliente.
        /// </summary>
        public void Activate() => Status = CustomerStatus.Active;

        /// <summary>
        /// Inativa o cliente.
        /// </summary>
        public void Deactivate() => Status = CustomerStatus.Inactive;

        /// <summary>
        /// Bloqueia o cliente.
        /// </summary>
        public void Block() => Status = CustomerStatus.Blocked;
    }
}
