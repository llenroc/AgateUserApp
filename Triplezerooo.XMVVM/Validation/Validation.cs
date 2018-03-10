using System.Collections.Generic;
using System.Linq;


namespace Triplezerooo.XMVVM
{
    public static class Validation
    {
        public static bool Validate<T>(this Property<T> property, bool updateState)
        {
            if (property.ValidationRules == null)
            {
                return true;
            }

            var errors = new List<string>();
            foreach (var rule in property.ValidationRules)
            {
                var ruleErrors = rule.IsValid(property.Value);
                if (ruleErrors != null)
                {
                    foreach (var ruleError in ruleErrors)
                    {
                        errors.Add(string.Format(ruleError, property.Name));
                    }
                }
            }

            if (updateState)
                property.ValidationError = string.Join(", ", errors);

            return !errors.Any();
        }

        public static bool Check(params IProperty[] properties) => properties.All(p => p.Validate(false));
    }
}
