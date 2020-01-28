using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities{
    public partial class Address{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Address(){
            this.Country = new HashSet<Country>();
        }
        public int Id { get; set; }
        public string StreetName { get; set; }
        public string Number { get; set; }
        public string PostCode { get; set; }
        public string IdCountry { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Country> Country { get; set; }
        public virtual Person Person { get; set; }
    }
}
