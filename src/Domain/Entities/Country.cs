using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Country
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Country()
        {
            this.Address = new HashSet<Address>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string IsoCode { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Address> Address { get; set; }
    }
}
