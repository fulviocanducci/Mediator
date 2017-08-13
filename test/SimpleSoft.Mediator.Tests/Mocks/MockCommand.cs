using System;

namespace SimpleSoft.Mediator.Tests.Mocks
{
    public class MockCommand : Command
    {
        public MockCommand()
        {

        }

        public MockCommand(Guid id, DateTimeOffset createdOn, string createdBy)
            : base(id, createdOn, createdBy)
        {

        }
    }
}