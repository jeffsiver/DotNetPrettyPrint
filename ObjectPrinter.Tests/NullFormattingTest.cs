using FluentAssertions;
using Siver.Jeff.ObjectPrinter.Tests.Objects;
using Xunit;

namespace Siver.Jeff.ObjectPrinter.Tests
{
    public class NullFormattingTest
    {
        [Fact]
        public void HandleNullOutput()
        {
            var simple = SimpleWithNull.BuildWithNulls();
            var printer = new PrettyPrinter();
            var result = printer.Print(simple);

            result.Should().Be("AString: ; ANullableInt: ; ANullableDateTime: ; ANullableEnum: ; ANullableDouble: ");
        }

        [Fact]
        public void HandleStandardOutputOnNullableTypes()
        {
            var simple = SimpleWithNull.BuildWithData();
            var printer = new PrettyPrinter();
            var result = printer.Print(simple);

            result.Should().Be("AString: string; ANullableInt: 1,012; ANullableDateTime: 2016-04-12T14:15:16.0000000Z; ANullableEnum: Value1; ANullableDouble: 1,025.52");
        }
    }
}
