namespace odec.Validation.Framework.Rules
{
    /// <summary>
    /// Важность правила
    /// </summary>
    public enum RuleSeverities
    {
        /// <summary>
        /// Ошибка (критическая важность)
        /// </summary>
        Error,
        /// <summary>
        /// Предупреждение
        /// </summary>
        Warning,
        /// <summary>
        /// Рекомендация
        /// </summary>
        Informational,
        /// <summary>
        /// Отсутствует
        /// </summary>
        None
    }
}
