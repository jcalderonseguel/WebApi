//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataModel
{
    using System;
    using System.Collections.Generic;
    
    public  partial class Address
    {
        public int Id { get; set; }
        public string StreetName { get; set; }
        public string Number { get; set; }
        public string PostCode { get; set; }
        public long IdCountry { get; set; }
        public int PersonId { get; set; }
        public int CountryId { get; set; }
    
        public virtual Person Person { get; set; }
        public virtual Country Country { get; set; }
    }
}
