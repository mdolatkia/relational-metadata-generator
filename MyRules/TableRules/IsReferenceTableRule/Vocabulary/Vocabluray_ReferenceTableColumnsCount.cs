﻿using MyRuleEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRules.TableRules.IsReferenceTableRule.Vocabulary
{
    class Vocabluray_ReferenceTableColumnsCount : IVocabulary
    {
        public object GetVocabulary(params object[] objects)
        {
            return 4;
        }
    }
}
