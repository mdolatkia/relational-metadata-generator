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
    
    public partial class Rule
    {
        public Rule()
        {
            this.RuleSet_Rule = new HashSet<RuleSet_Rule>();
        }
    
        public string Name { get; set; }
        public string Description { get; set; }
        public int CinditionID { get; set; }
        public int ActionID { get; set; }
    
        public virtual Action Action { get; set; }
        public virtual Condition Condition { get; set; }
        public virtual ICollection<RuleSet_Rule> RuleSet_Rule { get; set; }
    }
}
