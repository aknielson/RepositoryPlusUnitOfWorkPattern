using System;
using System.Collections.Generic;

namespace ConsoleApplication2.Models
{
    public partial class PhoneType
    {
        public PhoneType()
        {
            this.Phones = new List<Phone>();
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Phone> Phones { get; set; }
    }
}
