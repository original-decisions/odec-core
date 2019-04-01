using System;
using System.Reflection;
using odec.Validation.Framework.Interop;

namespace odec.Validation.Framework.Rules
{
    /// <summary>
    /// Validates the string length to be 
    /// </summary>
    public class ValidateLength : BaseValidationRule
    {
        private readonly OperatorCompare _operatorCompare;
        private readonly int _value;


        /// <summary>
        /// Create a rule to validate the string length based on the property name compare operator and value to be validated.
        /// </summary>
        /// <param name="propertyName">validated property name</param>
        /// <param name="operatorCompare">Compare operator <see cref="OperatorCompare"/></param>
        /// <param name="value">Value to be compared with</param>
        public ValidateLength(string propertyName, OperatorCompare operatorCompare, int value)
            : base(propertyName, string.Format("Field {0} string length is failed the validation check", propertyName))
        {
            _operatorCompare = operatorCompare;
            _value = value;
        }

        /// <summary>
        /// Validates that entity passes the length validation check
        /// </summary>
        /// <param name="entity">entity to be validated</param>
        /// <returns>Yes if all checks are successfull false or exception in other cases</returns>
        /// <exception cref="ArgumentNullException">Throws if the entity passed to the method is null</exception>
        /// <exception cref="InvalidCastException">Throws if the value is not of string type</exception>
        public override bool Validate(IValidationEntity entity)
        {
            //Contract.Requires<ArgumentNullException>(entity != null);
            if (entity == null)
                throw new ArgumentNullException($"{nameof(entity)} shouldn't be null.");

            var value = entity.GetType().GetProperty(PropertyName).GetValue(entity) as string;
            if (value == null)
                throw new InvalidCastException("Field is not of a string type.");

            if (_operatorCompare == OperatorCompare.Equals)
            {
                ErrorMessage = string.Format("{0} field length  should be equal to {1} symbols", PropertyName, _value);
                return value.Length == _value;
            }

            if (_operatorCompare == OperatorCompare.MoreThan)
            {
                ErrorMessage = string.Format("{0} field length shouldn't be less than {1} symbols", PropertyName, _value);
                return value.Length > _value;
            }

            if (_operatorCompare == OperatorCompare.LessThan)
            {
                ErrorMessage = string.Format("{0} field length shouldn't be greater than {1} symbols", PropertyName, _value);
                return value.Length < _value;
            }

            return true;
        }
    }
}
