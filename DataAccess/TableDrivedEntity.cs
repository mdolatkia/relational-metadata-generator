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
    
    public partial class TableDrivedEntity
    {
        public TableDrivedEntity()
        {
            this.ArcRelationshipGroup = new HashSet<ArcRelationshipGroup>();
            this.Entity_Tag = new HashSet<Entity_Tag>();
            this.Relationship = new HashSet<Relationship>();
            this.Relationship1 = new HashSet<Relationship>();
            this.Column = new HashSet<Column>();
        }
    
        public int ID { get; set; }
        public int TableID { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public string Criteria { get; set; }
        public Nullable<bool> IndependentDataEntry { get; set; }
        public Nullable<bool> BatchDataEntry { get; set; }
        public Nullable<bool> IsDataReference { get; set; }
        public Nullable<bool> IsStructurReferencee { get; set; }
        public Nullable<bool> IsAssociative { get; set; }
    
        public virtual ICollection<ArcRelationshipGroup> ArcRelationshipGroup { get; set; }
        public virtual ICollection<Entity_Tag> Entity_Tag { get; set; }
        public virtual ICollection<Relationship> Relationship { get; set; }
        public virtual ICollection<Relationship> Relationship1 { get; set; }
        public virtual Table Table { get; set; }
        public virtual ICollection<Column> Column { get; set; }
    }
}