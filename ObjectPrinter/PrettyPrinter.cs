using System;
using System.ComponentModel;
using System.Text;

namespace Siver.Jeff.ObjectPrinter
{
    public class PrettyPrinter
    {
        public string Print(object o)
        {
            var result = new StringBuilder();
            var properties = TypeDescriptor.GetProperties(o);
            foreach (PropertyDescriptor descriptor in properties)
            {
                if (result.Length > 0)
                    result.Append("; ");
                result.Append($"{descriptor.Name}: {PrintValue(o, descriptor)}");
            }
            return result.ToString();
        }

        private string PrintValue(object o, PropertyDescriptor descriptor)
        {
            if (descriptor.PropertyType.IsValueType)
                return PrintValueType(o, descriptor);

            var value = descriptor.GetValue(o);
            if (descriptor.PropertyType == typeof(string))
                return (string) value;
            return value.ToString();
        }

        private string PrintValueType(object o, PropertyDescriptor descriptor)
        {
            var value = descriptor.GetValue(o);
            if (descriptor.PropertyType == typeof(int))
                return ((int) value).ToString("#,###");
            if (descriptor.PropertyType == typeof(double))
                return ((double) value).ToString("N");
            if (descriptor.PropertyType == typeof(DateTime))
                return ((DateTime)value).ToString("o");
            return value.ToString();
        }
    }
}
