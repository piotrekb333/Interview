using System;
using System.Collections.Generic;
using System.Text;

namespace InterviewLists.Application.Exceptions
{
    public class NotAuthorizedException : Exception
    {
        public NotAuthorizedException()
            : base($"Not authorizated")
        {
        }
    }
}
