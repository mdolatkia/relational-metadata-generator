﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MyProjectEntities : DbContext
    {
        public MyProjectEntities()
            : base("name=MyProjectEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ArcRelationshipGroup> ArcRelationshipGroup { get; set; }
        public virtual DbSet<ArcRelationshipGroup_Relationship> ArcRelationshipGroup_Relationship { get; set; }
        public virtual DbSet<Column> Column { get; set; }
        public virtual DbSet<Column_Tag> Column_Tag { get; set; }
        public virtual DbSet<ColumnKeyValue> ColumnKeyValue { get; set; }
        public virtual DbSet<ColumnKeyValueRange> ColumnKeyValueRange { get; set; }
        public virtual DbSet<DatabaseInformation> DatabaseInformation { get; set; }
        public virtual DbSet<DateColumnType> DateColumnType { get; set; }
        public virtual DbSet<Entity_Tag> Entity_Tag { get; set; }
        public virtual DbSet<ExplicitOneToOneRelationshipType> ExplicitOneToOneRelationshipType { get; set; }
        public virtual DbSet<ImplicitOneToOneRelationshipType> ImplicitOneToOneRelationshipType { get; set; }
        public virtual DbSet<ISARelationship> ISARelationship { get; set; }
        public virtual DbSet<ManyToManyRelationshipType> ManyToManyRelationshipType { get; set; }
        public virtual DbSet<ManyToOneRelationshipType> ManyToOneRelationshipType { get; set; }
        public virtual DbSet<NumericColumnType> NumericColumnType { get; set; }
        public virtual DbSet<OneToManyRelationshipType> OneToManyRelationshipType { get; set; }
        public virtual DbSet<Relationship> Relationship { get; set; }
        public virtual DbSet<RelationshipColumns> RelationshipColumns { get; set; }
        public virtual DbSet<RelationshipType> RelationshipType { get; set; }
        public virtual DbSet<RuleOnValue> RuleOnValue { get; set; }
        public virtual DbSet<RuleOnValue_Column> RuleOnValue_Column { get; set; }
        public virtual DbSet<RuleOnValue_Relationship> RuleOnValue_Relationship { get; set; }
        public virtual DbSet<StringColumnType> StringColumnType { get; set; }
        public virtual DbSet<SubToSuperRelationshipType> SubToSuperRelationshipType { get; set; }
        public virtual DbSet<SubUnionToUnionRelationshipType> SubUnionToUnionRelationshipType { get; set; }
        public virtual DbSet<SuperToSubRelationshipType> SuperToSubRelationshipType { get; set; }
        public virtual DbSet<Table> Table { get; set; }
        public virtual DbSet<TableDrivedEntity> TableDrivedEntity { get; set; }
        public virtual DbSet<Tag> Tag { get; set; }
        public virtual DbSet<UnionRelationshipType> UnionRelationshipType { get; set; }
        public virtual DbSet<UnionToSubUnionRelationshipType> UnionToSubUnionRelationshipType { get; set; }
        public virtual DbSet<UniqueConstraint> UniqueConstraint { get; set; }
    }
}
