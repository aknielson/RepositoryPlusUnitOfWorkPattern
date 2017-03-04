using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using RepositoryPlusUnitOfWorkPattern.Domain.Models;

namespace RepositoryPlusUnitOfWorkPattern.EFData.Mapping
{
    public class PhoneTypeMap : EntityTypeConfiguration<PhoneType>
    {
        public PhoneTypeMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Description)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("PhoneType");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Description).HasColumnName("Description");
        }
    }
}
