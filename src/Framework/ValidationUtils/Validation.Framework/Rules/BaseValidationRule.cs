using System;
using odec.Validation.Framework.Interop;

namespace odec.Validation.Framework.Rules
{
    public abstract class BaseValidationRule
    {
        #region Props ...
        /// <summary>
        /// Property name of the validated property.
        /// </summary>
        public string PropertyName { get; set; }
        /// <summary>
        /// Validation error
        /// </summary>
        public string ErrorMessage { get; set; }
        /// <summary>
        /// Severity.
        /// </summary>
        public RuleSeverities Severity { get; set; }
        #endregion

        #region Ctors ...
        /// <summary>
        /// Constructing the validation rule by the property name and error message.
        /// </summary>
        /// <param name="propertyName">Property name</param>
        /// <param name="errorMessage">Error message to be populated on rule falure.</param>
        protected BaseValidationRule(string propertyName, string errorMessage)
        {
            PropertyName = propertyName;
            ErrorMessage = errorMessage;
            //По умолчанию важность критическая
            Severity = RuleSeverities.Error;
        }
        #endregion

        #region Methods ...
        /// <summary>
        /// Validate an object to be compliant with the rules. 
        /// </summary>
        /// <param name="entity">Entity(object) to be validated. The Entity should implement <see cref="IValidationEntity"/> interface</param>
        /// <returns><c>True</c>, если объект соответствует правилу,<c>False</c>, если не соответствует</returns>
        public abstract bool Validate(IValidationEntity entity);
        #endregion
    }
}
