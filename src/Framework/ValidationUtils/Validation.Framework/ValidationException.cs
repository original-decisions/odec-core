using System;
using System.Collections.Generic;

namespace odec.Validation.Framework
{
    /// <summary>
    /// Ошибка проверки данных
    /// </summary>
    public class ValidationException : Exception
    {
        private readonly IEnumerable<ValidationErrorInfo> _validationErrors;
        public IEnumerable<ValidationErrorInfo> ValidationErrors { get { return _validationErrors; } }

        public ValidationException(IEnumerable<ValidationErrorInfo> validationErrors)
        {
            _validationErrors = validationErrors;
        }
    }
}
