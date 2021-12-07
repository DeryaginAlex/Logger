using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceCloud.Logger {
    /// <summary>
    /// Класс форматирует сообщения, по принципу (level: message)
    /// </summary>
    public class SimpleMessageFormatter : IMessageFormatter {
        /// <inheritdoc cref="ServiceCloud.Logger.IMessageFormatter">
        public string Format(int level, string message) {                      
            return new StringBuilder($"{level}: {message}").ToString();
        }
    }
}