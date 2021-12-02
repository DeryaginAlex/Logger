using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceCloud.Logger
{
    /// <summary>
    /// Класс форматирует сообщения, по принципу (level: message)
    /// </summary>
    public class SimpleMessageFormatter : IMessageFormatter
    {
        /// <inheritdoc cref="ServiceCloud.Logger.IMessageFormatter">
        public string Format(int level, string message)
        {
            //такое метод формирования строк считается не комильфо. нужно использовать string.Format или StringBuilder
            //подробнее как и когда их используют ищи в итнернетах string.Format vs StringBuilder
            return level + ": " + message;
        }
    }
}
