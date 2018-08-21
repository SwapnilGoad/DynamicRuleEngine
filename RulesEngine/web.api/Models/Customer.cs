using RulesEngine.Rules;
using web.api.RuleEngines;

namespace web.api.Models
{
    [RuleEngineType(RuleType = typeof(DefaultRuleEngine<Customer>))]
    public class Customer
    {
        [RequiredField("UserName", "User name cannot be empty")]
        [MaxLenField("UserName", "Max 15 chars", 15)]
        public string UserName { get; set; }

        public string Password { get; set; }

        [RequiredField("Email", "Email cannot be empty")]
        [EmailField("Email","Invalid Email specified")]
        public string Email { get; set; }

        [CompareField("Email", "Email and Confirm Email values do not match")]
        public string EmailConfirm { get; set; }
    }
}
