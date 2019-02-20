using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using odec.Validation.Framework.Attributes;
using odec.Validation.Framework.Interop;
using odec.Validation.Framework.Rules;

namespace odec.Validation.Framework
{
    public static class ValidationController
    {
        #region Методы ...
        /// <summary>
        /// Проверяет указанную сущность
        /// </summary>
        /// <param name="entity">Валидируемая сущность</param>
        /// <returns>Результат проверки</returns>
        public static IEnumerable<ValidationErrorInfo> Validate(IValidationEntity entity)
        {
            //Contract.Requires<ArgumentNullException>(entity != null);
            if (entity == null)
                throw new ArgumentNullException("entity");

            var rules = GetValidationRules(entity);

            return rules.Where(it => !it.Validate(entity)).Select(it => new ValidationErrorInfo(it)).ToList();
        }

        /// <summary>
        /// Получает список правил валидируемой сущности
        /// </summary>
        /// <param name="entity">Валидируемая сущность</param>
        /// <returns>Список правил</returns>
        private static IEnumerable<BaseValidationRule> GetValidationRules(IValidationEntity entity)
        {
            //Contract.Requires<ArgumentNullException>(entity != null);
            if (entity == null)
                throw new ArgumentNullException("entity");

            return entity.GetType().GetTypeInfo().GetCustomAttributes<ValidationRuleAttribute>().Select(it => it.Rule).ToList();
        }

        /// <summary>
        /// Проверяет сущность по списку указанных правил
        /// </summary>
        /// <param name="entity">Сущность</param>
        /// <param name="rules">Список правил</param>
        /// <returns>Список ошибок</returns>
        public static IEnumerable<ValidationErrorInfo> Validate(this IValidationEntity entity, IEnumerable<BaseValidationRule> rules)
        {
            return rules.Where(it => !it.Validate(entity)).Select(it => new ValidationErrorInfo(it)).ToList();
        }

        /// <summary>
        /// Выбрасывает ошибку валидации, если есть ошибки
        /// </summary>
        /// <param name="errors">Список ошибок</param>
        public static void ThrowOnValidationError(this IEnumerable<ValidationErrorInfo> errors)
        {
            var validationErrors = errors as IList<ValidationErrorInfo> ?? errors.ToList();

            if (validationErrors.Count > 0)
                throw new ValidationException(validationErrors);
        }

        #endregion
    }
}
