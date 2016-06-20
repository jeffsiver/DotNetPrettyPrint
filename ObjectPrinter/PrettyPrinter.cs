using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Siver.Jeff.ObjectPrinter
{
    public class PrettyPrinter
    {
        public string Print(object o)
        {
            if (o == null) return null;

            var type = o.GetType();
            if (IsSimpleType(type)) return PrintSimpleType(o, type);

            if (IsEnumerable(type)) return HandleEnumerable(o);

            var result = new StringBuilder();
            var properties = TypeDescriptor.GetProperties(o);
            foreach (PropertyDescriptor descriptor in properties)
            {
                if (result.Length > 0)
                    result.Append("; ");
                result.Append($"{descriptor.Name}: {Print(descriptor.GetValue(o))}");
            }
            return result.ToString();
        }

        private bool IsSimpleType(Type type)
        {
            var simpleTypes = new[] {typeof(int), typeof(long), typeof(float), typeof(double), typeof(DateTime), typeof(string), typeof(decimal)};
            var baseType = GetBaseType(type);
            if (baseType.IsEnum) return true;
            return simpleTypes.Contains(baseType);
        }

        private static Type GetBaseType(Type type)
        {
            return type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>) ? type.GenericTypeArguments[0] : type;
        }

        private bool IsEnumerable(Type type)
        {
            var interfaces = type.GetInterfaces();
            return interfaces.Contains(typeof(IEnumerable));
        }

        private string HandleEnumerable(object value)
        {
            var result = new StringBuilder();
            foreach (var innerObject in (IEnumerable) value)
            {
                if (result.Length > 0)
                    result.Append(", ");
                result.Append($"{Print(innerObject)}");
            }
            result.Insert(0, "[ ");
            result.Append(" ]");
            return result.ToString();
        }

        private static string PrintSimpleType(object value, Type valueType)
        {
            if (value == null)
                return null;

            var type = GetBaseType(valueType);
            if (type.IsEnum)
                return value.ToString();
            if (type == typeof(int))
                return ((int) value).ToString("#,###");
            if (type == typeof(long))
                return ((long) value).ToString("#,###");
            if (type == typeof(decimal))
                return ((decimal) value).ToString("#,###.########");
            if (type == typeof(double))
                return ((double) value).ToString("##,###.########");
            if (type == typeof(float))
                return ((float) value).ToString("##,###.########");
            if (type == typeof(DateTime))
                return ((DateTime)value).ToString("o");
            return value.ToString();
        }
    }
}
