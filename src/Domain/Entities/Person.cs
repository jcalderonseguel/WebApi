using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Person
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Person()
        {
            this.Email = new HashSet<Email>();
            this.Address = new HashSet<Address>();
        }

        public int Id { get; set; }
        public string LastName { get; set; }
        public short Rut { get; set; }
        public Nullable<long> IdGender { get; set; }
        public Nullable<long> IdAddress { get; set; }
        public Nullable<long> IdEmail { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Email> Email { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Address> Address { get; set; }
        public virtual Gender Gender { get; set; }
    }
}
