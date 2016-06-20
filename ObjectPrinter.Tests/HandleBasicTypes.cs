using FluentAssertions;
using Xunit;

namespace Siver.Jeff.ObjectPrinter.Tests
{
    public class HandleBasicTypes
    {
        [Fact]
        public void ShouldHandlePrettyPrintingString()
        {
            new PrettyPrinter().Print("string").Should().Be("string");
        }

        [Fact]
        public void ShouldHandlePrettyPrintingInt()
        {
            new PrettyPrinter().Print(-1202).Should().Be("-1,202");
        }

        [Fact]
        public void ShouldHandlePrettyPrintingLong()
        {
            new PrettyPrinter().Print(-1202L).Should().Be("-1,202");
        }

        [Fact]
        public void ShouldHandlePrettyPrintingDecimal()
        {
            new PrettyPrinter().Print(-1202.5282M).Should().Be("-1,202.5282");
        }

        [Fact]
        public void ShouldHandlePrettyPrintingFloat()
        {
            new PrettyPrinter().Print(-12.5F).Should().Be("-12.5");
        }

        [Fact]
        public void ShouldHandlePrettyPrintingDouble()
        {
            new PrettyPrinter().Print(-12.5D).Should().Be("-12.5");
        }

        [Fact]
        public void ShouldHandlePrettyPrintingNull()
        {
            new PrettyPrinter().Print(null).Should().Be(null);
        }
    }
}
