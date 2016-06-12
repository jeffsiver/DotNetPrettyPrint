using System;

namespace Siver.Jeff.ObjectPrinter.Tests.Objects
{
    internal class Simple
    {
        public int AnInteger { get; set; }
        public string AString { get; set; }
        public DateTime ADateTime { get; set; }
        public double ADouble { get; set; }
        public MyEnum MyEnum { get; set; }

        public static Simple Build()
        {
            return new Simple
            {
                AnInteger = 1012,
                AString = "string",
                ADateTime = new DateTime(2016, 4, 12, 14, 15, 16, DateTimeKind.Utc),
                ADouble = 1015.12,
                MyEnum = MyEnum.Value2
            };
        }
    }
}
