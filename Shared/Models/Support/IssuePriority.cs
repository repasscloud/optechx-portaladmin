using OptechXPortalAdmin.Shared.Helper;

namespace OptechXPortalAdmin.Shared.Models.Support
{
    public enum IssuePriority
    {
        [EnumStringValue("Low")]
        LOW,

        [EnumStringValue("Medium")]
        MEDIUM,

        [EnumStringValue("High")]
        HIGH,

        [EnumStringValue("Critical")]
        CRITICAL
    }
}

