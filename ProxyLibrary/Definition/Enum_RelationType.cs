using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyLibrary
{
    public enum Enum_RelationshipType
    {
        None,
        ManyToOne,
        OneToMany,
        ExplicitOneToOne,
        ImplicitOneToOne,
         SubToSuper,
        SuperToSub,
         SubUnionToUnion_UnionHoldsKeys,
         UnionToSubUnion_UnionHoldsKeys,
         SubUnionToUnion_SubUnionHoldsKeys,
         UnionToSubUnion_SubUnionHoldsKeys
    }
}
