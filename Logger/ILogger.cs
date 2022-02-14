namespace Logger
{
    /// <summary>
    /// Интерфейс объектов, выполняющих журналирование сообщений
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Записать сообщение в журнал
        /// </summary>
        /// <param name="level">Уровень важности сообщения</param>
        /// <param name="message">Текст сообщения</param>
        void Log(string lines);
    }
}
