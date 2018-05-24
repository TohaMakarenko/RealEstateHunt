using System;

namespace RealEstateHunt.Infrastructure.Data
{
    public class EntityNotFoundException : Exception
    {
        public object Entity { get; set; }
        public EntityNotFoundException() : base()
        { }
        public EntityNotFoundException(string message) : base(message)
        { }
        public EntityNotFoundException(object entity) : base()
        {
            Entity = entity;
        }
        public EntityNotFoundException(object entity, string message) : base(message)
        {
            Entity = entity;
        }
    }
}
