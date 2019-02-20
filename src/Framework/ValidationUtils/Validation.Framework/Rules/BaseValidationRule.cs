using System;
using odec.Validation.Framework.Interop;

namespace odec.Validation.Framework.Rules
{
    public abstract class BaseValidationRule
    {
        #region Свойства ...
        /// <summary>
        /// Имя проверяемого свойства
        /// </summary>
        public string PropertyName { get; set; }
        /// <summary>
        /// Сообщение об ошибке
        /// </summary>
        public string ErrorMessage { get; set; }
        /// <summary>
        /// Важность
        /// </summary>
        public RuleSeverities Severity { get; set; }
        #endregion

        #region Конструкторы ...
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="propertyName">Наименование свойства</param>
        /// <param name="errorMessage">Сообщение об ошибке</param>
        protected BaseValidationRule(string propertyName, string errorMessage)
        {
            PropertyName = propertyName;
            ErrorMessage = errorMessage;
            //По умолчанию важность критическая
            Severity = RuleSeverities.Error;
        }
        #endregion

        #region Методы ...
        /// <summary>
        /// Проверяет объект на соответствие, описанным правилам
        /// </summary>
        /// <param name="entity">Проверяемая сущность</param>
        /// <returns><c>True</c>, если объект соответствует правилу,<c>False</c>, если не соответствует</returns>
        public abstract bool Validate(IValidationEntity entity);
        #endregion
    }
}
