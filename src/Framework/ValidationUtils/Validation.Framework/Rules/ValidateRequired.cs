using System;
using System.Reflection;
using odec.Validation.Framework.Interop;

namespace odec.Validation.Framework.Rules
{
    public class ValidateRequired : BaseValidationRule
    {
        #region Конструкторы ...
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="propertyName">Имя свойства</param>
        public ValidateRequired(string propertyName)
            : base(propertyName, string.Format("Необходимо заполнить поле {0}", propertyName))
        {

        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="propertyName">Имя свойства</param>
        /// <param name="errorMessage">Сообщение об ошибке</param>
        public ValidateRequired(string propertyName, string errorMessage)
            : base(propertyName, errorMessage)
        {

        }
        #endregion

        #region Методы ...
        /// <summary>
        /// Проверят сущность
        /// </summary>
        /// <param name="entity">Валидируемая сущность</param>
        /// <returns>Результат валидации, пройдена ли проверка - да или нет</returns>
        public override bool Validate(IValidationEntity entity)
        {
            //Contract.Requires<ArgumentNullException>(entity != null);
            if (entity == null)
                throw new ArgumentNullException("entity");

            return entity.GetType().GetProperty(PropertyName).GetValue(entity) != null;
        }
        #endregion
    }
}
