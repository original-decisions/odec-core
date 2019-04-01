namespace odec.Validation.Framework.Rules
{
    /// <summary>
    /// Known Rule Severity 
    /// </summary>
    public enum RuleSeverities
    {
        /// <summary>
        /// Error. (Critical importance, we cannot save entity or do any operations with it if so).
        /// </summary>
        Error,
        /// <summary>
        /// Warning. It give the warning and notifies user or a system that something went wrong but it can continue with such validation errors.
        /// </summary>
        Warning,
        /// <summary>
        /// Recommendation Validation error. Can be usefull if you are using some kind of AI to do the recomendations based on the validation rules from the set.
        /// </summary>
        Informational,
        /// <summary>
        /// Severity is not specified or not deemed critical at all.
        /// </summary>
        None
    }
}
