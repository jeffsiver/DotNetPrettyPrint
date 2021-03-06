﻿using System.Collections.Generic;

namespace JeffSiver.ObjectPrinter.Tests.Objects
{
    public class WithEnumerable
    {
        public IEnumerable<string> StringList { get; set; }

        public static WithEnumerable Build()
        {
            return new WithEnumerable
            {
                StringList = new[] {"first", "second", "third", null}
            };
        }
    }
}
