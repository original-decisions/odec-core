using System;
using System.Reflection;
using odec.Validation.Framework.Interop;

namespace odec.Validation.Framework.Rules
{
    public class ValidateLength : BaseValidationRule
    {
        private readonly OperatorCompare _operatorCompare;
        private readonly int _value;

        public ValidateLength(string propertyName, OperatorCompare operatorCompare, int value)
            : base(propertyName, string.Format("Длина поля {0} не соответствует заданному условию", propertyName))
        {
            _operatorCompare = operatorCompare;
            _value = value;
        }

        public override bool Validate(IValidationEntity entity)
        {
            //Contract.Requires<ArgumentNullException>(entity != null);
            if (entity == null)
                throw new ArgumentNullException("entity");

            var value = entity.GetType().GetProperty(PropertyName).GetValue(entity) as string;
            if (value == null)
                throw new InvalidCastException("Поле имеет тип отличный от строкового");

            if (_operatorCompare == OperatorCompare.Equals)
            {
                ErrorMessage = string.Format("Длина поля {0} должна равняться {1} символам", PropertyName, _value);
                return value.Length == _value;
            }

            if (_operatorCompare == OperatorCompare.MoreThan)
            {
                ErrorMessage = string.Format("Длина поля {0} не должна быть менее {1} символов", PropertyName, _value);
                return value.Length > _value;
            }

            if (_operatorCompare == OperatorCompare.LessThan)
            {
                ErrorMessage = string.Format("Длина поля {0} не должна превышать {1} символов", PropertyName, _value);
                return value.Length < _value;
            }

            return true;
        }
    }
}
