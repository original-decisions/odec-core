using System;
using odec.Validation.Framework.Rules;

namespace odec.Validation.Framework.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public sealed class ValidationRuleAttribute : Attribute
    {
        #region Свойства ...
        /// <summary>
        /// Правило
        /// </summary>
        public BaseValidationRule Rule { get; set; }
        #endregion

        #region Конструкторы ...
        /// <summary>
        /// Конструкторы
        /// </summary>
        /// <param name="ruleType">Тип правила</param>
        /// <param name="severity">Важность правила</param>
        /// <param name="args">Список аргументов</param>
        public ValidationRuleAttribute(Type ruleType, RuleSeverities severity, params object[] args)
        {
            //Contract.Requires<ArgumentNullException>(ruleType != null);
            if (ruleType == null)
                throw new ArgumentNullException("ruleType");

            Rule = Activator.CreateInstance(ruleType, args) as BaseValidationRule;
            if (Rule != null)
                Rule.Severity = severity;
        }
        #endregion
    }
}
