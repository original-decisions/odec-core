using System;
using System.Reflection;
using odec.Validation.Framework.Interop;

namespace odec.Validation.Framework.Rules
{
    /// <summary>
    /// Validate that the object is not null.
    /// </summary>
    public class ValidateRequired : BaseValidationRule
    {
        #region Ctors ...
        /// <summary>
        /// Constructs the required validation rule by the property Name
        /// </summary>
        /// <param name="propertyName">Имя свойства</param>
        public ValidateRequired(string propertyName)
            : base(propertyName, string.Format("The field {0} is required.", propertyName))
        {

        }

        /// <summary>
        ///  Constructs the required validation rule by the property name and error message.
        /// </summary>
        /// <param name="propertyName">Validated property name</param>
        /// <param name="errorMessage">Error message to be displaied.</param>
        public ValidateRequired(string propertyName, string errorMessage)
            : base(propertyName, errorMessage)
        {

        }
        #endregion

        #region Methods ...
        /// <summary>
        /// Validates the entity for the specified rule above.
        /// </summary>
        /// <param name="entity">Validated entity. Should Implement interface <see cref="IValidationEntity"/></param>
        /// <returns>Validation result. If yes it gives the True, false if not.</returns>
        public override bool Validate(IValidationEntity entity)
        {
            //Contract.Requires<ArgumentNullException>(entity != null);
            if (entity == null)
                throw new ArgumentNullException("entity");

            return entity.GetType().GetProperty(PropertyName).GetValue(entity) != null;
        }
        #endregion
    }
}
