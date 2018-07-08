using System;

namespace MyApp.Core.Exceptions
{
    public class EntityExistsException<TEntity> : Exception
    {
        public EntityExistsException()
        {

        }

        public EntityExistsException(Guid entityId)
        {

        }
    }
}
