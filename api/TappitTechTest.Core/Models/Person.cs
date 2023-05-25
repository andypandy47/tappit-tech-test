using System.Collections.Generic;
using TappitTechTest.Core.Utils;

namespace TappitTechTest.Core.Models
{
    public class Person
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool Valid { get; set; }

        public bool Enabled { get; set; }

        public bool Authorised { get; set; }

        public bool Palindrome => Util.IsPalindrome(this.FirstName);

        public List<SportDto> FavouriteSports { get; set; }
    }
}
