using System;
using Xunit;

namespace test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            program a = new program();
            Assert.Equal(9,a.FindDigit("42*47=1?74"));
        }
    }
}
