using System;
using System.Reflection;
using System.Text.RegularExpressions;
using odec.Validation.Framework.Interop;

namespace odec.Validation.Framework.Rules
{
    public class ValidateValueByRegex : BaseValidationRule
    {
        private readonly string _pattern;

        public ValidateValueByRegex(string propertyName, string pattern, string error)
            : base(propertyName, error)
        {
            _pattern = pattern;
        }

        public override bool Validate(IValidationEntity entity)
        {
            //Contract.Requires<ArgumentNullException>(entity != null);
            if (entity == null)
                throw new ArgumentNullException("entity");

            return Regex.IsMatch(entity.GetType().GetProperty(PropertyName).GetValue(entity).ToString(), _pattern);
        }
    }
}
