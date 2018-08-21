using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using web.api.RuleEngines;

namespace RulesEngine
{
    public class RuleEngineFactory<T> where T : class
    {
        private IConfiguration _configuration;

        public RuleEngineFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IRuleEngine<T> GetEngine()
        {
            IRuleEngine<T> ruleEngine;

            string configurationString = _configuration["RuleEngineType"];

            if (configurationString.ToLower() == "xmlruleengine")
            {
                ruleEngine = new XMLRuleEngine<T>();
            }
            else
            {
                ruleEngine = new DefaultRuleEngine<T>();
            }

            return ruleEngine;  
        }
    }
}
