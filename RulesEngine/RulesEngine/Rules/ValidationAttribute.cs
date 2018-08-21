using System;
using System.Collections.Generic;
using System.Text;

namespace RulesEngine.Rules
{
    public abstract class ValidationAttribute : Attribute
    {
        public string Name { get; set; }
        public string Message { get; set; }

        public ValidationAttribute()
        {

        }

        public ValidationAttribute(string name, string message)
        {
            Name = name;
            Message = message;
        }

        public abstract BrokenRule Validate(object value, ValidationContext context);
    }
}