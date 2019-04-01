using System;
using System.Collections.Generic;

namespace odec.Validation.Framework
{
    /// <summary>
    /// The validation exception class
    /// </summary>
    public class ValidationException : Exception
    {
        private readonly IEnumerable<ValidationErrorInfo> _validationErrors;
        /// <summary>
        /// Validation errors collection which populated only once when the exception is being created.
        /// </summary>
        public IEnumerable<ValidationErrorInfo> ValidationErrors { get { return _validationErrors; } }

        /// <summary>
        /// Constructing the exception based on the validation errors collection.
        /// </summary>
        /// <param name="validationErrors">Validation errors collection. </param>
        public ValidationException(IEnumerable<ValidationErrorInfo> validationErrors)
        {
            _validationErrors = validationErrors;
        }
    }
}
