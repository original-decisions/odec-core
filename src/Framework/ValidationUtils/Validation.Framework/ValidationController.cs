using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using odec.Validation.Framework.Attributes;
using odec.Validation.Framework.Interop;
using odec.Validation.Framework.Rules;

namespace odec.Validation.Framework
{
    /// <summary>
    /// Validation controller which contains the methods allowing to validate different entities inherited the IValidationEntity interface.
    /// </summary>
    public static class ValidationController
    {
        #region Methods ...
        /// <summary>
        /// Validates the provided entity 
        /// </summary>
        /// <param name="entity">Entity to validate.</param>
        /// <returns>Validation result.</returns>
        public static IEnumerable<ValidationErrorInfo> Validate(IValidationEntity entity)
        {
            //Contract.Requires<ArgumentNullException>(entity != null);
            if (entity == null)
                throw new ArgumentNullException("entity");

            var rules = GetValidationRules(entity);

            return rules.Where(it => !it.Validate(entity)).Select(it => new ValidationErrorInfo(it)).ToList();
        }

        /// <summary>
        /// Gets the rules set for the validated entity.
        /// </summary>
        /// <param name="entity">Validated entity</param>
        /// <returns>Rule Set <see cref="{IEnumerable<BaseValidationRule>}"/></returns>
        private static IEnumerable<BaseValidationRule> GetValidationRules(IValidationEntity entity)
        {
            //Contract.Requires<ArgumentNullException>(entity != null);
            if (entity == null)
                throw new ArgumentNullException("entity");

            return entity.GetType().GetTypeInfo().GetCustomAttributes<ValidationRuleAttribute>().Select(it => it.Rule).ToList();
        }

        /// <summary>
        /// Validates the entity by the rules set.  
        /// </summary>
        /// <param name="entity">Validated entity</param>
        /// <param name="rules">Validation set</param>
        /// <returns>Errors which are the validation result. The result is  <see cref="{IEnumerable<ValidationErrorInfo>}"/></returns>
        public static IEnumerable<ValidationErrorInfo> Validate(this IValidationEntity entity, IEnumerable<BaseValidationRule> rules)
        {
            return rules.Where(it => !it.Validate(entity)).Select(it => new ValidationErrorInfo(it)).ToList();
        }

        /// <summary>
        /// Thows a validation error if any validation violations were found.
        /// </summary>
        /// <param name="errors">Set of the errors</param>
        public static void ThrowOnValidationError(this IEnumerable<ValidationErrorInfo> errors)
        {
            var validationErrors = errors as IList<ValidationErrorInfo> ?? errors.ToList();

            if (validationErrors.Count > 0)
                throw new ValidationException(validationErrors);
        }

        #endregion
    }
}
