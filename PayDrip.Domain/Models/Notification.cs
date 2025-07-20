namespace PayDrip.Domain.Models
{
    public class Notification
    {
        public Guid Id { get; private set; }
        public NotificationType Type { get; private set; }
        public string Content { get; private set; }
        public NotificationStatus Status { get; private set; }

        // Pode referenciar Invoice, Subscription ou qualquer entidade relacionada
        public Guid RelatedEntityId { get; private set; }
        public string RelatedEntityType { get; private set; } // ex: "Invoice", "Subscription"

        public DateTime CreatedAt { get; private set; }
        public DateTime? SentAt { get; private set; }

        public Notification(NotificationType type, string content, Guid relatedEntityId, string relatedEntityType)
        {
            if (string.IsNullOrWhiteSpace(content))
                throw new ArgumentException("Conteúdo da notificação não pode ser vazio.");
            if (relatedEntityId == Guid.Empty)
                throw new ArgumentException("Entidade relacionada inválida.");
            if (string.IsNullOrWhiteSpace(relatedEntityType))
                throw new ArgumentException("Tipo da entidade relacionada é obrigatório.");

            Id = Guid.NewGuid();
            Type = type;
            Content = content;
            RelatedEntityId = relatedEntityId;
            RelatedEntityType = relatedEntityType;
            Status = NotificationStatus.Pending;
            CreatedAt = DateTime.UtcNow;
        }

        public void MarkAsSent()
        {
            if (Status != NotificationStatus.Pending)
                throw new InvalidOperationException("A notificação já foi processada.");

            Status = NotificationStatus.Sent;
            SentAt = DateTime.UtcNow;
        }

        public void MarkAsFailed()
        {
            if (Status != NotificationStatus.Pending)
                throw new InvalidOperationException("A notificação já foi processada.");

            Status = NotificationStatus.Failed;
        }

        public bool IsPending() => Status == NotificationStatus.Pending;
    }
}
