using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceCloud.Logger
{
    /// <summary>
    /// Интерфейс описывает стратегию форматирования сообщений, записываемых в журнал
    /// </summary>
    public interface IMessageFormatter
    {
        /// <summary>
        /// Форматировать сообщение
        /// </summary>
        /// <param name="level">Уровень важности сообщения</param>
        /// <param name="message">Текст сообщения</param>
        /// <returns>Отформатированное сообщение</returns>
        string Format(int level, string message);
    }
}
