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
        private readonly IEnumerable<string> _propertyNamesToMask;
        private ICollection<object> _printedObjects;

        public PrettyPrinter()
        {
            _propertyNamesToMask = Enumerable.Empty<string>();
        }
        public PrettyPrinter(IEnumerable<string> propertyNamesToMask )
        {
            _propertyNamesToMask = propertyNamesToMask;
        }

        public string Print(object o)
        {
            _printedObjects = new List<object>();

            return PrintObject(o);
        }

        private string PrintObject(object o)
        {
            if (o == null) return null;

            var type = o.GetType();
            if (IsSimpleType(type)) return PrintSimpleType(o, type);

            if (IsEnumerable(type)) return HandleEnumerable(o);

            return OutputProperties(o);
        }

        private string OutputProperties(object o)
        {
            if (_printedObjects.Contains(o)) return null;
            _printedObjects.Add(o);

            var result = new StringBuilder();
            var properties = TypeDescriptor.GetProperties(o);
            foreach (PropertyDescriptor descriptor in properties)
            {
                if (result.Length > 0)
                    result.Append("; ");
                OutputProperty(o, result, descriptor);
            }
            return result.ToString();
        }

        private void OutputProperty(object o, StringBuilder result, PropertyDescriptor descriptor)
        {
            result.Append(IsPropertyNameInListToMask(descriptor) ? $"{descriptor.Name}: ****" : GetPrintValue(o, descriptor));
        }

        private string GetPrintValue(object o, PropertyDescriptor descriptor)
        {
            var value = descriptor.GetValue(o);
            if (value == null) return $"{descriptor.Name}: ";
            var result = PrintObject(value);
            if (result == null) return $"{descriptor.Name}: **Cycle**";
            return $"{descriptor.Name}: {result}";
        }

        private bool IsPropertyNameInListToMask(PropertyDescriptor descriptor)
        {
            return _propertyNamesToMask.Any(nameToMask => descriptor.Name.CaseInsensitiveContains(nameToMask));
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
                    result.Append(" }, { ");
                result.Append($"{PrintObject(innerObject)}");
            }
            result.Insert(0, "[ { ");
            result.Append(" } ]");
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
