using FluentAssertions;
using Siver.Jeff.ObjectPrinter.Tests.Objects;
using Xunit;

namespace Siver.Jeff.ObjectPrinter.Tests
{
    public class GenericEnumerableTest
    {
        [Fact]
        public void ShouldHandleEnumerableWithSimpleType()
        {
            var withEnumerable = WithEnumerable.BuildWithData();
            var prettyPrinter = new PrettyPrinter();
            var result = prettyPrinter.Print(withEnumerable);
            result.Should().Be("StringList: [ first, second, third,  ]");
        }

        [Fact]
        public void ShouldHandleEnumerableWithComplexType()
        {
            var input = ComplexEnumerable.Build();
            var prettyPrinter = new PrettyPrinter();
            var result = prettyPrinter.Print(input);
            result.Should().Be("Id: 12; Name: the name of this is name; Values: [ first, second ]; SimpleList: [ AnInteger: 1,012; AString: string; ADateTime: 2016-04-12T14:15:16.0000000Z; ADouble: 1,015.12; MyEnum: Value2 ]");
        }

    }
}
