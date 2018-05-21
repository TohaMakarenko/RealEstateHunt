using System;
using System.Collections.Generic;
using System.Text;
using RealEstateHunt.Core;
using System.Linq;

namespace RealEstateHunt.Infrastructure.Mappers
{
    public class UserMapper : IMapper<User, UserEntity>, IMapper<UserEntity, User>
    {
        IMapper<Contact, ContactEntity> _contactToEntityMapper;
        IMapper<ContactEntity, Contact> _entityToContactMapper;

        public UserMapper(IMapper<Contact, ContactEntity> contactToEntityMapper,
            IMapper<ContactEntity, Contact> entityToContactMapper)
        {
            _contactToEntityMapper = contactToEntityMapper;
            _entityToContactMapper = entityToContactMapper;
        }

        public UserEntity Map(User entity)
        {
            return new UserEntity() {
                Id = entity.Id,
                Name = entity.Name,
                Email = entity.Email,
                Phone = entity.Phone,
                ContactId = entity.Contact.Id,
                Contact = _contactToEntityMapper.Map(entity.Contact)
            };
        }

        public User Map(UserEntity entity)
        {
            return new User() {
                Id = entity.Id,
                Name = entity.Name,
                Email = entity.Email,
                Phone = entity.Phone,
                Contact = _entityToContactMapper.Map(entity.Contact)
            };
        }

        public IEnumerable<UserEntity> MapCollection(IEnumerable<User> entities)
        {
            if (entities != null)
                return entities.Select(i => Map(i));
            return null;
        }

        public IEnumerable<User> MapCollection(IEnumerable<UserEntity> entities)
        {
            if (entities != null)
                return entities.Select(i => Map(i));
            return null;
        }
    }
}
