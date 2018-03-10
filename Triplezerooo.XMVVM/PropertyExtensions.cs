using System;


namespace Triplezerooo.XMVVM
{
    public static class PropertyExtensions
    {
        public static Property<T> Required<T>(this Property<T> property, string errorMessage)
        {
            property.ValidationRules.Add(new Required<T>(errorMessage));
            return property;
        }
        public static Property<string> RequiredString(this Property<string> property, string errorMessage)
        {
            property.ValidationRules.Add(new RequiredString(errorMessage));
            return property;
        }
        public static Property<string> RequiredFormat(this Property<string> property, string pattern, string errorMessage)
        {
            property.ValidationRules.Add(new RegexValidator(pattern) { ErrorTemplate = errorMessage });
            return property;
        }
        public static Property<T> Check<T>(this Property<T> property, Func<T, string> checkFunc)
        {
            property.ValidationRules.Add(new LambdaValidator<T>(checkFunc));
            return property;
        }
        public static Property<T> Check<T>(this Property<T> property, Func<T, string[]> checkFunc)
        {
            property.ValidationRules.Add(new LambdaValidator<T>(checkFunc));
            return property;
        }
        public static Property<T> Check<T>(this Property<T> property, Func<T, bool> checkFunc, string error)
        {
            property.ValidationRules.Add(new LambdaValidator<T>(v => checkFunc(v) ? null : error));
            return property;
        }
    }
}
