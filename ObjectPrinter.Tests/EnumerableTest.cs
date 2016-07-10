using FluentAssertions;
using Siver.Jeff.ObjectPrinter.Tests.Objects;
using Xunit;
using System.Collections;

namespace Siver.Jeff.ObjectPrinter.Tests
{
    public class EnumerableTest
    {
        [Fact]
        public void ShouldHandleEnumerableWithSimpleType()
        {
            var prettyPrinter = new PrettyPrinter();
            var result = prettyPrinter.Print(WithEnumerable.Build());
            result.Should().Be("StringList: [ first, second, third,  ]");
        }

        [Fact]
        public void ShouldHandleEnumerableWithComplexType()
        {
            var prettyPrinter = new PrettyPrinter();
            var result = prettyPrinter.Print(ComplexEnumerable.Build());
            result.Should().Be("Id: 12; Name: the name of this is name; Values: [ first, second ]; SimpleList: [ AnInteger: 1,012; AString: string; ADateTime: 2016-04-12T14:15:16.0000000Z; ADouble: 1,015.12; MyEnum: Value2 ]");
        }

        [Fact]
        public void ShouldHandleNonGenericEnumerable()
        {
            var prettyPrinter = new PrettyPrinter();
            var result = prettyPrinter.Print((IEnumerable) new [] {"one", "two", "three"});
            result.Should().Be("[ one, two, three ]");
        }
    }
}
