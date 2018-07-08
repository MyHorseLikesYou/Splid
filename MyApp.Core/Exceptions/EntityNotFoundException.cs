using System;

namespace MyApp.Core.Exceptions
{
    public class EntityNotFoundException<TEntity> : Exception
    {
        public EntityNotFoundException()
        {

        }

        public EntityNotFoundException(Guid entityId)
        {

        }
    }
}
