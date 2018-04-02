using System;
using System.Linq;
using System.Text.RegularExpressions;
using Triplezerooo;

namespace Triplezerooo.XMVVM
{
    public class LambdaValidator<T> : IValidator<T>
    {
        private readonly Func<T, string[]> func;

        public LambdaValidator(Func<T, string[]> func)
        {
            this.func = func;
        }
        public LambdaValidator(Func<T, string> func)
        {
            this.func = v =>
            {
                var result = func(v);
                if (result == null)
                    return new string[0];
                else
                    return new[] { result };
            };
        }
        public string[] IsValid(T value) => func(value);
    }

    public class Required<T> : IValidator<T>
    {
        private readonly T nullValue;

        public Required(T nullValue = default(T))
        {
            this.nullValue = nullValue;
        }
        public Required(string errorTemplate, T nullValue = default(T))
        {
            this.nullValue = nullValue;
            ErrorTemplate = errorTemplate;
        }
        public string ErrorTemplate { get; set; } = "{0} is required.";
        public string[] IsValid(T value) => (value == null || value.Equals(nullValue) ) ?  ErrorTemplate.SingleToArray() : null;
    }

    public class RequiredString : IValidator<string>
    {
        public RequiredString()
        {
            
        }
        public RequiredString(string errorTemplate)
        {
            ErrorTemplate = errorTemplate;
        }
        public string ErrorTemplate { get; set; } = "{0} is required.";
        public string[] IsValid(string value) => string.IsNullOrWhiteSpace(value) ? ErrorTemplate.SingleToArray() : null;
    }

    public class DecimalRange : IValidator<decimal>
    {
        public DecimalRange(decimal min, decimal max)
        {
            Min = min;
            Max = max;
        }

        public decimal Min { get; }
        public decimal Max { get; }

        public string[] IsValid(decimal value) => value >= Min && value <= Max ? $"{0} should be between {Min} and {Max}".SingleToArray() : null;
    }

    public class RegexValidator : IValidator<string>
    {
        public RegexValidator(params string[] patterns)
        {
            Patterns = patterns;
        }
        public string ErrorTemplate { get; set; } = "{0} is required.";
        public string[] Patterns { get; }

        public string[] IsValid(string value) => Patterns.Any(pattern => Regex.IsMatch(value, pattern)) ? null : ErrorTemplate.SingleToArray();
    }

}
