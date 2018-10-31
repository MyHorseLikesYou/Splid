using System;

namespace MyApp.Core.Exceptions
{
    public class EntityExistsException<TEntity> : InvalidDomainOperationException
    {
        public EntityExistsException()
        {

        }

        public EntityExistsException(Guid entityId)
        {

        }
    }
}
