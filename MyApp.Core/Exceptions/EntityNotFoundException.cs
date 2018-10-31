using System;

namespace MyApp.Core.Exceptions
{
    public class EntityNotFoundException<TEntity> : InvalidDomainOperationException
    {
        public EntityNotFoundException()
        {

        }

        public EntityNotFoundException(Guid entityId)
        {

        }
    }
}
