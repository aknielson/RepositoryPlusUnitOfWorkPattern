using System;
using System.Collections.Generic;

namespace RepositoryPlusUnitOfWorkPattern.Domain.Models
{
    public partial class Phone
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public int PersonId { get; set; }
      

        public int PhoneTypeId { get; set; }
        public virtual PhoneType PhoneType { get; set; }
    }
}
