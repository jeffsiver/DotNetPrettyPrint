using FluentAssertions;
using JeffSiver.ObjectPrinter.Tests.Objects;
using Xunit;

namespace JeffSiver.ObjectPrinter.Tests
{
    public class MaskSpecifiedPropertiesTest
    {
        [Fact]
        public void MaskSingleVariableExactWordMatchDifferentCase()
        {
            var printer = new PrettyPrinter(new [] {"password"});
            var result = printer.Print(ForMasking.Build());
            result.Should().Be("UserId: user; Password: ****; Email: email; FirstName: first; LastName: last; AnotherEmailAddress: another email; MailAddress: mailing");
        }

        [Fact]
        public void MaskMultiplePropertiesFromSingleName()
        {
            var printer = new PrettyPrinter(new [] {"email"});
            var result = printer.Print(ForMasking.Build());
            result.Should().Be("UserId: user; Password: password; Email: ****; FirstName: first; LastName: last; AnotherEmailAddress: ****; MailAddress: mailing");
        }

        [Fact]
        public void MaskMultipleNames()
        {
            var printer = new PrettyPrinter(new [] {"lastname", "PASSWORD", "email"});
            var result = printer.Print(ForMasking.Build());
            result.Should().Be("UserId: user; Password: ****; Email: ****; FirstName: first; LastName: ****; AnotherEmailAddress: ****; MailAddress: mailing");
        }
    }
}
