using OptechXPortalAdmin.Shared.Helper;

namespace OptechXPortalAdmin.Shared.Models.Support
{
    public enum IssueType
    {
        [EnumStringValue("General Support")]
        SUPPORT,

        [EnumStringValue("Account Enquiry")]
        ACCOUNT,

        [EnumStringValue("Billing Question")]
        BILLING
    }
}

