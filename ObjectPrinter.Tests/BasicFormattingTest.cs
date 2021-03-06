﻿using FluentAssertions;
using JeffSiver.ObjectPrinter.Tests.Objects;
using Xunit;

namespace JeffSiver.ObjectPrinter.Tests
{
    public class BasicFormattingTest
    {
        [Fact]
        public void ShouldPrintSimpleObject()
        {
            var simple = Simple.Build();
            var prettyPrinter = new PrettyPrinter();
            var result = prettyPrinter.Print(simple);

            result.Should().Be("AnInteger: 1,012; AString: string; ADateTime: 2016-04-12T14:15:16.0000000Z; ADouble: 1,015.12; MyEnum: Value2");
        }
    }
}
