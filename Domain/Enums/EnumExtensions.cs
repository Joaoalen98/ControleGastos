using System.ComponentModel;
using System.Reflection;

namespace Domain.Enums
{
    public static class EnumExtensions
    {
        public static string GetDisplayName(this Enum value)
        {
            FieldInfo field = value.GetType().GetField(value.ToString());
            DisplayNameAttribute attribute = field.GetCustomAttribute<DisplayNameAttribute>();
            return attribute != null ? attribute.DisplayName : value.ToString();
        }
    }
}