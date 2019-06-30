using AutoMapper;
using InterviewLists.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace InterviewLists.Application.Tests.Infrastructure
{
    public class TestFixtureFactory : IDisposable
    {
        public InterviewDbContext Context { get; private set; }
        public IMapper Mapper { get; private set; }

        public TestFixtureFactory()
        {
            Context = InterviewContextFactory.Create();
            Mapper = AutoMapperFactory.Create();
        }

        public void Dispose()
        {
            InterviewContextFactory.Destroy(Context);
        }
    }
}
