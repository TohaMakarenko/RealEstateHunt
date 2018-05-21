using System;
using System.Collections.Generic;
using System.Text;
using RealEstateHunt.Core;
using System.Linq;

namespace RealEstateHunt.Infrastructure.Mappers
{
    public class ContactCommunicationMapper : IMapper<ContactCommunication, ContactCommunicationEntity>,
        IMapper<ContactCommunicationEntity, ContactCommunication>
    {
        IMapper<Contact, ContactEntity> _contactToEntityMapper;
        IMapper<ContactEntity, Contact> _entityToContactMapper;

        public ContactCommunicationMapper(IMapper<Contact, ContactEntity> contactToEntityMapper,
            IMapper<ContactEntity, Contact> entityContactMapper)
        {
            _contactToEntityMapper = contactToEntityMapper;
            _entityToContactMapper = entityContactMapper;
        }

        public ContactCommunicationEntity Map(ContactCommunication entity)
        {
            if (entity == null)
                return null;

            return new ContactCommunicationEntity() {
                Id = entity.Id,
                Name = entity.Name,
                Value = entity.Value,
                Contact = _contactToEntityMapper.Map(entity.Contact),
                ContactId = entity.Contact.Id
            };
        }

        public ContactCommunication Map(ContactCommunicationEntity entity)
        {
            if (entity == null)
                return null;

            return new ContactCommunication() {
                Id = entity.Id,
                Name = entity.Name,
                Value = entity.Value,
                Contact = _entityToContactMapper.Map(entity.Contact),
            };
        }

        public IEnumerable<ContactCommunicationEntity> MapCollection(IEnumerable<ContactCommunication> entities)
        {
            if (entities != null)
                return entities.Select(i => Map(i));
            return null;
        }

        public IEnumerable<ContactCommunication> MapCollection(IEnumerable<ContactCommunicationEntity> entities)
        {
            if (entities != null)
                return entities.Select(i => Map(i));
            return null;
        }
    }
}
