using System;
using System.Text.RegularExpressions;
namespace RulesEngine.Rules
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class EmailFieldAttribute : ValidationAttribute
    {
        const string expr = "[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+(?:[A-Z]{2}|com|org|net|gov|mil|biz|info|mobi|name|aero|jobs|museum)";
        public EmailFieldAttribute() : base()
        {

        }
        public EmailFieldAttribute(string name, string message) : base(name, message)
        {

        }
        public override BrokenRule Validate(dynamic value, ValidationContext context)
        {
            BrokenRule rule = new BrokenRule();

            if (null != value || !string.IsNullOrWhiteSpace(value.ToString()))
            {
                if (!Regex.IsMatch(value,expr))
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
