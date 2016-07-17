using FluentAssertions;
using Siver.Jeff.ObjectPrinter.Tests.Objects;
using Xunit;

namespace Siver.Jeff.ObjectPrinter.Tests
{
    public class CycleTest
    {
        [Fact]
        public void ShouldDetectCycle()
        {
            var o = ObjectContainer.Builder();
            var printer = new PrettyPrinter();
            var result = printer.Print(o);
            result.Should().Be("Id: 1; Description: parent object; Children: [ { Id: 2; Description: child 1; Parent: **Cycle** }, { Id: 3; Description: child 2; Parent: **Cycle** } ]");
        }
    }
}
