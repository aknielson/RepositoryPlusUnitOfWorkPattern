using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using RepositoryPlusUnitOfWorkPattern.Domain.Models;
using RepositoryPlusUnitOfWorkPattern.EFData.Mapping;

namespace RepositoryPlusUnitOfWorkPattern.EFData
{
    //set up a default configuration so that you don't have to include EF in every single project.
    [DbConfigurationType(typeof(SqlDefaultDbConfiguration))]
    public partial class AddressBookAlphaContext : DbContext
    {
        static AddressBookAlphaContext()
        {
            Database.SetInitializer<AddressBookAlphaContext>(null);
        }

        public AddressBookAlphaContext()
            : base("Name=AddressBookAlphaContext")
        {
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<PhoneType> PhoneTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AddressMap());
            modelBuilder.Configurations.Add(new PersonMap());
            modelBuilder.Configurations.Add(new PhoneMap());
            modelBuilder.Configurations.Add(new PhoneTypeMap());
        }
    }
}
