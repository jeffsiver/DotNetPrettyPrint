using System.Collections.Generic;

namespace JeffSiver.ObjectPrinter.Tests.Objects
{
    public class ComplexEnumerable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<string> Values { get; set; }
        public IEnumerable<Simple> SimpleList { get; set; }

        public static ComplexEnumerable Build()
        {
            return new ComplexEnumerable
            {
                Id = 12,
                Name = "the name of this is name",
                Values = new List<string> { "first", "second"},
                SimpleList = new []{Simple.Build(), Simple.Build()}
            };

        }
    }
}