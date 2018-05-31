using System;

namespace Splid.Application.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException()
        {

        }

        public EntityNotFoundException(Guid entityId)
        {

        }
    }

    public class EntityExistsException : Exception
    {
        public EntityExistsException()
        {

        }

        public EntityExistsException(Guid entityId)
        {

        }
    }
}
