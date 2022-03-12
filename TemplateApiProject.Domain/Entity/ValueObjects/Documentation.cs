using TemplateApiProject.Domain.Entity.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace TemplateApiProject.Domain.Entity.ValueObjects
{
    public class Documentation : ValueObject
    {
        public string CPF { get; set; }
        public string RG { get; set; }

        public Documentation()
        {

        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return CPF.ToUpper();
            yield return RG.ToUpper();
        }
    }
}
