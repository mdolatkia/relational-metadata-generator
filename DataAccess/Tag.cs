//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tag
    {
        public Tag()
        {
            this.Column_Tag = new HashSet<Column_Tag>();
            this.Entity_Tag = new HashSet<Entity_Tag>();
        }
    
        public int ID { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
    
        public virtual ICollection<Column_Tag> Column_Tag { get; set; }
        public virtual ICollection<Entity_Tag> Entity_Tag { get; set; }
    }
}
