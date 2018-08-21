using System;
using System.Collections.Generic;
using System.Text;

namespace RulesEngine
{
    public interface IRuleEngine<T>
    {
        List<BrokenRule> Validate(T value);
    }
}
