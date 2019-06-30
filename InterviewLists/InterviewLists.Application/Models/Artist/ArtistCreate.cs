using System;
using System.Collections.Generic;
using System.Text;

namespace InterviewLists.Application.Models.Artist
{
    public class ArtistCreate
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public string Country { get; set; }
    }
}
