using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using ConsoleApplication2.Models.Mapping;

namespace ConsoleApplication2.Models
{
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
        public DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AddressMap());
            modelBuilder.Configurations.Add(new PersonMap());
            modelBuilder.Configurations.Add(new PhoneMap());
            modelBuilder.Configurations.Add(new PhoneTypeMap());
            modelBuilder.Configurations.Add(new sysdiagramMap());
        }
    }
}
