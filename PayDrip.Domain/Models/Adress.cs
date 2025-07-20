using System;

namespace PayDrip.Domain.Models
{
    public class Address
    {
        public Guid Id { get; private set; }
        public Guid CustomerId { get; private set; } // Chave estrangeira para Customer

        public string Street { get; private set; }
        public string Number { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string ZipCode { get; private set; }

        public Address(Guid customerId, string street, string number, string city, string state, string zipCode)
        {
            Id = Guid.NewGuid();
            SetCustomerId(customerId);
            SetStreet(street);
            SetNumber(number);
            SetCity(city);
            SetState(state);
            SetZipCode(zipCode);
        }

        public void SetCustomerId(Guid customerId)
        {
            if (customerId == Guid.Empty)
                throw new ArgumentException("CustomerId inválido.");
            CustomerId = customerId;
        }

        public void SetStreet(string street)
        {
            if (string.IsNullOrWhiteSpace(street))
                throw new ArgumentException("Rua obrigatória.");
            Street = street.Trim();
        }

        public void SetNumber(string number)
        {
            // Número pode ser opcional, mas valida se informado
            if (number != null && number.Trim().Length == 0)
                throw new ArgumentException("Número inválido.");
            Number = number?.Trim();
        }

        public void SetCity(string city)
        {
            if (string.IsNullOrWhiteSpace(city))
                throw new ArgumentException("Cidade obrigatória.");
            City = city.Trim();
        }

        public void SetState(string state)
        {
            if (string.IsNullOrWhiteSpace(state))
                throw new ArgumentException("Estado obrigatório.");
            State = state.Trim();
        }

        public void SetZipCode(string zipCode)
        {
            if (string.IsNullOrWhiteSpace(zipCode))
                throw new ArgumentException("CEP obrigatório.");
            ZipCode = zipCode.Trim();
        }

        public void UpdateAddress(string street, string number, string city, string state, string zipCode)
        {
            SetStreet(street);
            SetNumber(number);
            SetCity(city);
            SetState(state);
            SetZipCode(zipCode);
        }
    }
}
