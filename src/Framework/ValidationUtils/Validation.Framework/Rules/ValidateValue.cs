using System;
using System.Reflection;
using odec.Validation.Framework.Interop;

namespace odec.Validation.Framework.Rules
{
    public class ValidateValue : BaseValidationRule
    {
        private readonly OperatorCompare _operatorCompare;
        private readonly decimal _value;

        public ValidateValue(string propertyName, OperatorCompare operatorCompare, decimal value)
            : base(propertyName, string.Format("Значение поля {0} не соответствует заданному условию", propertyName))
        {
            _operatorCompare = operatorCompare;
            _value = value;
        }

        public override bool Validate(IValidationEntity entity)
        {
            //Contract.Requires<ArgumentNullException>(entity != null);
            if (entity == null)
                throw new ArgumentNullException("entity");

            decimal value;
            decimal.TryParse(entity.GetType().GetProperty(PropertyName).GetValue(entity).ToString(), out value);

            if (_operatorCompare == OperatorCompare.Equals)
            {
                ErrorMessage = string.Format("Значение поля {0} должно равняться {1} символам", PropertyName, _value);
                return value == _value;
            }

            if (_operatorCompare == OperatorCompare.MoreThan)
            {
                ErrorMessage = string.Format("Значение поля {0} не должно быть менее {1} символов", PropertyName, _value);
                return value > _value;
            }

            if (_operatorCompare == OperatorCompare.LessThan)
            {
                ErrorMessage = string.Format("Значение поля {0} не должно превышать {1} символов", PropertyName, _value);
                return value < _value;
            }

            return true;
        }
    }
}
