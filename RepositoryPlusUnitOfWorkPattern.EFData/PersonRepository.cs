using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryPlusUnitOfWorkPattern.Domain.Models;

using RepositoryPlusUnitOfWorkPattern.Domain;
using RepositoryPlusUnitOfWorkPattern.Domain.RepositoryInterface;

namespace RepositoryPlusUnitOfWorkPattern.EFData
{
    public class PersonRepository : Repository<Person>, IPersonRepository
    {
        public PersonRepository(AddressBookAlphaContext context)
            : base(context)
        {
        }

        public void RemoveHydrated(Person entity)
        {
            if (entity.Phones.Any())
                Context.Set<Phone>().RemoveRange(entity.Phones);
            Context.Set<Person>().Remove(entity);


        }
    }
}
