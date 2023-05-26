using TappitTechTest.Core.Utils;
using Xunit;

namespace TappitTechTest.Core.Tests
{
    public class UtilsTests
    {
        [Theory]
        [InlineData("Bob", true)]
        [InlineData("bOboB", true)]
        [InlineData("Hannah", true)]
        [InlineData("Test12345566", false)]
        [InlineData("Sarah", false)]
        [InlineData("Andy", false)]
        public void IsPalindrome_ReturnsExpected(string input, bool expected)
        {
            Assert.Equal(Util.IsPalindrome(input), expected);
        }
    }
}
