using System.ComponentModel.DataAnnotations;

namespace OptechXPortalAdmin.Shared.Models.Support
{
    public class SupportTicket
    {
        [Key]
        public int Id { get; set; } = 0;

        public Guid UserId { get; set; }
        public IssueStatus Status { get; set; }
        public IssuePriority Priority { get; set; }
        public IssueType Type { get; set; }
        public DateTime Opened { get; set; }
        public DateTime Updated { get; set; }
        public string Subject { get; set; } = null!;
        public string Message { get; set; } = null!;
        public string? AttachmentFileName { get; set; }
    }
}

