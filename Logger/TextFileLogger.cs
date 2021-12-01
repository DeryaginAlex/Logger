using System;
using System.Collections.Generic;
using System.Text;
using System.IO;


namespace ServiceCloud.Logger
{

    public class TextFileLogger : ITextFileLogger
    {
        public TextFileLogger(Encoding encoding, string filePath, string messageDelimiter)
        {
            this.Encoding = encoding;
            this.FilePath = filePath;
            this.MessageDelimiter = messageDelimiter;
        }

        public Encoding Encoding { get; private set; }
        public string FilePath { get; private set; }
        public string MessageDelimiter { get; private set; }

        private IMessageFormatter messageFormatter = new SimpleMessageFormatter();
        public IMessageFormatter MessageFormatter
        {
            get { return messageFormatter; }
            set { messageFormatter = value; }
        }

        public void Log(int level, string message)
        {
            File.AppendAllText(FilePath, MessageFormatter.Format(level, message));
        }
    }
}