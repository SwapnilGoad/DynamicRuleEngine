using System;
using System.Collections.Generic;
using System.Text;

namespace RulesEngine.Rules
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class CompareFieldAttribute : ValidationAttribute
    {
        public CompareFieldAttribute() : base()
        {

        }
        public CompareFieldAttribute(string name, string message)
            : base(name, message)
        {
        }

        public override BrokenRule Validate(dynamic value, ValidationContext context)
        {
            BrokenRule rule = new BrokenRule();

            var targetField = context.SourceObject.GetType().GetProperty(Name);

            if (value != targetField.GetValue(context.SourceObject))
            {
                rule.IsBroken = true;
                rule.ErrorMessage = Message;
                rule.Name = Name;
            }

            return rule;
        }
    }
}
