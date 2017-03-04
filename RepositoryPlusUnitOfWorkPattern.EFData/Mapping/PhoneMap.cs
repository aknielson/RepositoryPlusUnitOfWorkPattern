using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using RepositoryPlusUnitOfWorkPattern.Domain.Models;

namespace RepositoryPlusUnitOfWorkPattern.EFData.Mapping
{
    public class PhoneMap : EntityTypeConfiguration<Phone>
    {
        public PhoneMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.PhoneNumber)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Phone");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.PhoneNumber).HasColumnName("PhoneNumber");
            this.Property(t => t.PhoneTypeId).HasColumnName("PhoneTypeId");
            this.Property(t => t.PersonId).HasColumnName("PersonId");

            //// Relationships
           
            this.HasRequired(t => t.PhoneType)
                .WithMany()
                .HasForeignKey(d => d.PhoneTypeId);

        }
    }
}
