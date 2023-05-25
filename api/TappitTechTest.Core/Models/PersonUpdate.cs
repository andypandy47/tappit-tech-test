using System.Collections.Generic;

namespace TappitTechTest.Core.Models
{
    public class PersonUpdate
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool Valid { get; set; }

        public bool Enabled { get; set; }

        public bool Authorised { get; set; }

        public List<int> FavouriteSports { get; set; }
    }
}
