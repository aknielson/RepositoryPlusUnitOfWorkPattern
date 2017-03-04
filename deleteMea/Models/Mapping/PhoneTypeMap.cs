using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace deleteMea.Models.Mapping
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
