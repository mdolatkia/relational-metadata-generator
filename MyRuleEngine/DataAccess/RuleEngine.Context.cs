﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyRuleEngine.DataAccess
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MyRuleEngineEntities : DbContext
    {
        public MyRuleEngineEntities()
            : base("name=MyRuleEngineEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Action> Action { get; set; }
        public virtual DbSet<AssemblyInfo> AssemblyInfo { get; set; }
        public virtual DbSet<Condition> Condition { get; set; }
        public virtual DbSet<Rule> Rule { get; set; }
        public virtual DbSet<RuleSet> RuleSet { get; set; }
        public virtual DbSet<RuleSet_Rule> RuleSet_Rule { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Vocabulary> Vocabulary { get; set; }
    }
}
