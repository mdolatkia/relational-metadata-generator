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
    
    public partial class ColumnKeyValue
    {
        public ColumnKeyValue()
        {
            this.ColumnKeyValueRange = new HashSet<ColumnKeyValueRange>();
        }
    
        public int ColumnID { get; set; }
        public bool ValueFromKeyOrValue { get; set; }
    
        public virtual Column Column { get; set; }
        public virtual ICollection<ColumnKeyValueRange> ColumnKeyValueRange { get; set; }
    }
}
