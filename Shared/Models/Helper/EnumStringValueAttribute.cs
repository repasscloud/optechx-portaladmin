namespace OptechXPortalAdmin.Shared.Helper
{
    public class EnumStringValueAttribute : Attribute
    {
        public string Value { get; }

        public EnumStringValueAttribute(string value)
        {
            Value = value;
        }
    }
}

