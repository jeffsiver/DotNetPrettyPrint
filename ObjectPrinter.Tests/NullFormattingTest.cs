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
    }
}
