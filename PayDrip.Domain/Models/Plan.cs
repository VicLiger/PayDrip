using System;

namespace PayDrip.Domain.Models
{
    public class Plan
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public TypePlan TypePlan { get; private set; }
        public PlanBenefits Benefits { get; private set; }

        public Plan(string name, string description, decimal price, TypePlan typePlan, PlanBenefits benefits)
        {
            Id = Guid.NewGuid();
            SetName(name);
            SetDescription(description);
            SetPrice(price);
            SetTypePlan(TypePlan);
            SetBenefits(benefits);
        }

        public void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Nome do plano é obrigatório.");
            Name = name.Trim();
        }

        public void SetDescription(string description)
        {
            Description = description?.Trim() ?? string.Empty;
        }

        public void SetPrice(decimal price)
        {
            if (price < 0)
                throw new ArgumentException("Preço não pode ser negativo.");
            Price = price;
        }

        public void SetTypePlan(TypePlan typePlan)
        {
            if (!Enum.IsDefined(typeof(TypePlan), typePlan))
                throw new ArgumentException("Ciclo de cobrança inválido.");
            TypePlan = TypePlan;
        }

        public void SetBenefits(PlanBenefits benefits)
        {
            Benefits = benefits ?? throw new ArgumentException("Benefícios do plano são obrigatórios.");
        }
    }

    public class PlanBenefits
    {
        public int MaxUsers { get; private set; }
        public int StorageInMb { get; private set; }
        // Pode adicionar mais campos de benefício conforme necessidade

        public PlanBenefits(int maxUsers, int storageInMb)
        {
            if (maxUsers < 0)
                throw new ArgumentException("Número máximo de usuários inválido.");
            if (storageInMb < 0)
                throw new ArgumentException("Armazenamento inválido.");

            MaxUsers = maxUsers;
            StorageInMb = storageInMb;
        }
    }
}
