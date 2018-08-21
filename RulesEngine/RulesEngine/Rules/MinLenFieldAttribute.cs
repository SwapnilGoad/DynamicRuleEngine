using System;
using System.Collections.Generic;
using System.Text;

namespace RulesEngine.Rules
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class MinLenFieldAttribute : ValidationAttribute
    {
        public int Min { get; set; }

        public MinLenFieldAttribute() : base()
        {

        }
        public MinLenFieldAttribute(string name, string message, int min)
            : base(name, message)
        {
            Min = min;
        }

        public override BrokenRule Validate(object value, ValidationContext context)
        {
            BrokenRule rule = new BrokenRule();

            if (null != value || !string.IsNullOrWhiteSpace(value.ToString()))
            {
                if (value.ToString().Length < Min)
                {
                    rule.IsBroken = true;
                    rule.Name = this.Name;
                    rule.ErrorMessage = this.Message;
                }
            }
            return rule;
        }
    }
}
