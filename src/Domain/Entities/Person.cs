using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    using System;
    using System.Collections.Generic;

    public partial class Person
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Person()
        {
            this.Address = new HashSet<Address>();
            this.Email = new HashSet<Email>();
            this.Gender = new HashSet<Gender>();
        }

        public int Id { get; set; }
        public string LastName { get; set; }
        public string Rut { get; set; }
        public string IdGender { get; set; }
        public string IdAddress { get; set; }
        public string IdEmail { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Address> Address { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Email> Email { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Gender> Gender { get; set; }
    }
}
