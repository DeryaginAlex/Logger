using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceCloud.Logger {
    /// <summary>
    ///Интерфейс объектов, выполняющих журналирование сообщений в текстовый файл
    /// </summary>
    public interface ITextFileLogger : ILogger {
        /// <summary>
        /// Кодировка символов в файле
        /// </summary>
        Encoding Encoding { get; }

        /// <summary>
        /// Путь к файлу журнала
        /// </summary>
        string FilePath { get; }

        /// <summary>
        /// Разделитель сообщений в журнале
        /// </summary>
        string MessageDelimiter { get; }

        /// <summary>
        /// Стратегия форматирования сообщений журнала
        /// </summary>
        IMessageFormatter MessageFormatter { get; set; }
    }
}