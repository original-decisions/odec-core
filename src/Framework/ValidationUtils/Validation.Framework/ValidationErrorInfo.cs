using System;
using System.Runtime.Serialization;
using odec.Validation.Framework.Rules;

namespace odec.Validation.Framework
{
    [DataContract]
    public sealed class ValidationErrorInfo
    {
        #region Свойства ...
        /// <summary>
        /// Имя свойства
        /// </summary>
        [DataMember]
        public string PropertyName { get; set; }
        /// <summary>
        /// Сообщение об ошибке
        /// </summary>
        [DataMember]
        public string ErrorMessage { get; set; }
        /// <summary>
        /// Важность
        /// </summary>
        [DataMember]
        public RuleSeverities Severity { get; set; }
        #endregion

        #region Конструкторы ...
        /// <summary>
        /// Конструктор
        /// </summary>
        public ValidationErrorInfo(BaseValidationRule rule)
        {
            //Contract.Requires<ArgumentNullException>(rule != null);
            if (rule == null)
                throw new ArgumentNullException("rule");

            PropertyName = rule.PropertyName;
            ErrorMessage = rule.ErrorMessage;
            Severity = rule.Severity;
        }

        public ValidationErrorInfo(string propertyName, string errorMessage, RuleSeverities severity = RuleSeverities.Error)
        {
            PropertyName = propertyName;
            ErrorMessage = errorMessage;
        }
        #endregion
    }


}
