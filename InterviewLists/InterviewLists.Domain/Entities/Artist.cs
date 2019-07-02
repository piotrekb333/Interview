using System;
using System.Collections.Generic;
using System.Text;

namespace InterviewLists.Domain.Entities
{
    public class Artist : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public string Country { get; set; }
        public string UserId { get; set; }

    }
}
