using System;
using System.Collections.Generic;

namespace RepositoryPlusUnitOfWorkPattern.Domain.Models
{
    public partial class PhoneType
    {
        public int Id { get; set; }
        public string Description { get; set; }
       
    }

    public enum PhoneTypeEnum
    {
        Home = 1,
        Cell = 2,
        Office = 3
    }
}
