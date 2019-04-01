using System;
using System.Runtime.Serialization;
using odec.Validation.Framework.Rules;

namespace odec.Validation.Framework
{
    /// <summary>
    /// The class describest validation error info. 
    /// It is generally used to give the summary about the validation checks failures.
    /// </summary>
    [DataContract]
    public sealed class ValidationErrorInfo
    {
        #region Props ...
        /// <summary>
        /// Which object property has an error
        /// </summary>
        [DataMember]
        public string PropertyName { get; set; }
        /// <summary>
        /// Error message for the object property.
        /// </summary>
        [DataMember]
        public string ErrorMessage { get; set; }
        /// <summary>
        /// Severity Level of the error.
        /// </summary>
        [DataMember]
        public RuleSeverities Severity { get; set; }
        #endregion

        #region Ctors ...
        /// <summary>
        /// Constructing the Validation error by the <see cref="BaseValidationRule"/>.
        /// </summary>
        /// <exception cref="ArgumentNullException"> Throws exception in case the passed rule is null</exception>
        public ValidationErrorInfo(BaseValidationRule rule)
        {
            //Contract.Requires<ArgumentNullException>(rule != null);
            if (rule == null)
                throw new ArgumentNullException($"{nameof(rule)} shouln't be null.");

            PropertyName = rule.PropertyName;
            ErrorMessage = rule.ErrorMessage;
            Severity = rule.Severity;
        }

        /// <summary>
        /// Constructing the validation error by the propertyName, error message and severity
        /// </summary>
        /// <remarks> Severity is set default to <see cref="RuleSeverities.Error"/></remarks>
        /// <param name="propertyName">Property name which failed the check</param>
        /// <param name="errorMessage">Message to be populated</param>
        /// <param name="severity">Error Severity level. More info: <see cref="RuleSeverities"/></param>
        public ValidationErrorInfo(string propertyName, string errorMessage, RuleSeverities severity = RuleSeverities.Error)
        {
            PropertyName = propertyName;
            ErrorMessage = errorMessage;
        }
        #endregion
    }


}
