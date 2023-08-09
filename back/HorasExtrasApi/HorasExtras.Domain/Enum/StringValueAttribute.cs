namespace HorasExtras.Domain.Enum
{
    [AttributeUsage(AttributeTargets.All)]
    public class StringValueAttribute: Attribute
    {
        public string Value { get; set; }

        public StringValueAttribute(string value)
        {
            Value = value;
        }
    }
}
