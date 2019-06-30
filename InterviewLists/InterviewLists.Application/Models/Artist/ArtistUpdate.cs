using System;
using System.Collections.Generic;
using System.Text;

namespace InterviewLists.Application.Models.Artist
{
    public class ArtistUpdate
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public string Country { get; set; }
    }
}
