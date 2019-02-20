using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Reflection;
using odec.Validation.Framework.Interop;

namespace odec.Validation.Framework.Rules
{
    public class ValidateLengthByRegex : BaseValidationRule
    {
        private readonly string _pattern;

        public ValidateLengthByRegex(string propertyName, string pattern, string errorMessage)
            : base(propertyName, errorMessage)
        {
            _pattern = pattern;
        }

        public override bool Validate(IValidationEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            var value = entity.GetType().GetProperty(PropertyName).GetValue(entity) as string;
            if (value == null)
                throw new InvalidCastException("Поле имеет тип отличный от строкового");

            return Regex.IsMatch(value.Length.ToString(CultureInfo.InvariantCulture), _pattern);
        }
    }
}
