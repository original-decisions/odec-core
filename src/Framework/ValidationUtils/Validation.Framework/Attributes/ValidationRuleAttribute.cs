using System;
using odec.Validation.Framework.Rules;

namespace odec.Validation.Framework.Attributes
{
    /// <summary>
    /// TODO: Documentation and example for it.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public sealed class ValidationRuleAttribute : Attribute
    {
        #region Props ...
        /// <summary>
        /// Rule Specified in the attribute.
        /// </summary>
        public BaseValidationRule Rule { get; set; }
        #endregion

        #region Constructors ...
        /// <summary>
        /// Constructing the attribute based on the rule type, severity type and additional arguments.
        /// </summary>
        /// <param name="ruleType">Rule type. Should be derivered from <see cref="BaseValidationRule"/></param>
        /// <param name="severity">Severity of the rule. More info: <see cref="RuleSeverities"/></param>
        /// <param name="args">Additional arguments list</param>
        /// <exception cref="ArgumentNullException"> Throws argument null exception if the rule type is null.</exception>
        public ValidationRuleAttribute(Type ruleType, RuleSeverities severity, params object[] args)
        {
            //Contract.Requires<ArgumentNullException>(ruleType != null);
            if (ruleType == null)
                throw new ArgumentNullException($"{nameof(ruleType)} shouldn't be null.");

            Rule = Activator.CreateInstance(ruleType, args) as BaseValidationRule;
            if (Rule != null)
                Rule.Severity = severity;
        }
        #endregion
    }
}
