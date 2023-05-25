using System;
using System.Linq;

namespace TappitTechTest.Core.Utils
{
    public static class Util
    {
        public static bool IsPalindrome(string input)
        {
            var loweredInput = input.ToLower();
            var reversed = new string(loweredInput.Reverse().ToArray());

            return string.Equals(reversed, loweredInput);
        }
    }
}
