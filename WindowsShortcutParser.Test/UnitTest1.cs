using System;
using Xunit;

namespace WindowsShortcutParser.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            WindowsShortcutParser.Class1.Add(1, 2).Is(2);
        }
    }
}
