using OptechXPortalAdmin.Shared.Helper;

namespace OptechXPortalAdmin.Shared.Models.Support
{
    public enum IssueStatus
    {
        [EnumStringValue("Open")]
        OPEN,

        [EnumStringValue("In Progress")]
        ASSIGNED,

        [EnumStringValue("Waiting for Response")]
        PENDING,

        [EnumStringValue("Closed")]
        CLOSED
    }
}

