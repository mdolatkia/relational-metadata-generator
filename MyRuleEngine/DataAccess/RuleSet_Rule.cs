//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class RuleSet_Rule
    {
        public string RuleSetName { get; set; }
        public string RuleName { get; set; }
        public Nullable<short> Priority { get; set; }
    
        public virtual Rule Rule { get; set; }
        public virtual RuleSet RuleSet { get; set; }
    }
}
