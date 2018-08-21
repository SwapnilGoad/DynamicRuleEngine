using Microsoft.AspNetCore.Mvc;
using RulesEngine;
using web.api.Models;

namespace web.api.Controllers
{
    [Route("api/customer/[controller]")]
    public class RegisterController : Controller
    {
        private static IRuleEngine<Customer> _ruleEngine;

        public RegisterController(IRuleEngine<Customer> ruleEngine)
        {           
            _ruleEngine = ruleEngine;
        }
        // POST api/customer/register
        [HttpPost]
        public void Post([FromBody]Customer value)
        {

        }

        // POST api/customer/register
        [HttpGet]
        public IActionResult Get()
        {
            Customer register = new Customer() {
                UserName = "",
                Password = "test123",
                Email = "test@gmail.com",
                EmailConfirm = "test",
            };
            var results = _ruleEngine.Validate(register);

            return Ok(results);
        }
    }
}
