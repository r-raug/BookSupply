//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BookSupply.BLL
{
    using System;
    using System.Collections.Generic;
    
    public partial class AuthorsBook
    {
        public decimal AuthorId { get; set; }
        public decimal ISBN { get; set; }
        public decimal YearPublished { get; set; }
        public decimal Edition { get; set; }
    
        public virtual Book Book { get; set; }
        public virtual Author Author { get; set; }
    }
}
