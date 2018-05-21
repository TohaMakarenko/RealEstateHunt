using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateHunt.Infrastructure
{
    class EntityNotFoundException : Exception
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
