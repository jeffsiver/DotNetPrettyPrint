using System;

namespace Siver.Jeff.ObjectPrinter.Tests.Objects
{
    public class SimpleWithNull
    {
        public string AString { get; set; }
        public int? ANullableInt { get; set; }
        public DateTime? ANullableDateTime { get; set; }
        public MyEnum? ANullableEnum { get; set; }
        public double? ANullableDouble { get; set; }

        public static SimpleWithNull BuildWithNulls()
        {
            return new SimpleWithNull();
        }

        public static SimpleWithNull BuildWithData()
        {
            return new SimpleWithNull
            {
                ANullableInt = 1012,
                AString = "string",
                ANullableDateTime = new DateTime(2016, 4, 12, 14, 15, 16, DateTimeKind.Utc),
                ANullableDouble = 1025.52,
                ANullableEnum = MyEnum.Value1
            };

        }
    }
}
