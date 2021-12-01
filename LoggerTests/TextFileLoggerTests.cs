using NUnit.Framework;
using System.Text;
using System;
using System.IO;

namespace ServiceCloud.Logger
{
    [TestFixture]
    public class TextFileLoggerTests : ITextFileLoggerTests
    {
        protected override ITextFileLogger CreateTestObject()
        {
            return new TextFileLogger(Encoding.Unicode, @"C:\Logs\1.txt", "конец записи");
        }

        [Test]
        public void TextFileLogger_FilePath_Test()
        {
            TextFileLogger target = (TextFileLogger)CreateTestObject();
            Assert.AreEqual(target.FilePath, @"C:\Logs\1.txt");
        }

        [Test]
        public void TextFileLogger_Encoding_Test()
        {
            TextFileLogger target = (TextFileLogger)CreateTestObject();
            Assert.AreEqual(target.Encoding, Encoding.Unicode);
        }

        [Test]
        public void TextFileLogger_MessageDelimiter_Test()
        {
            TextFileLogger target = (TextFileLogger)CreateTestObject();
            Assert.AreEqual(target.MessageDelimiter, "конец записи");
        }

        [Test]
        public void TextFileLogger_FilePath_ValidDirectory_Test()
        {
            TextFileLoggerTestsContext context = new TextFileLoggerTestsContext();
            TextFileLogger target = (TextFileLogger)CreateTestObject();

            context.CreateJournal(target.FilePath);
            string directoryName = Path.GetDirectoryName(target.FilePath);
            bool result = Directory.Exists(directoryName);
            context.DeleteJournals(target.FilePath);

            Assert.IsTrue(result);
        }

        [Test]
        public void TextFileLogger_FilePath_ValidFile_Test()
        {
            TextFileLogger target = (TextFileLogger)CreateTestObject();
            TextFileLoggerTestsContext context = new TextFileLoggerTestsContext();

            string path = Path.GetDirectoryName(target.FilePath);
            context.CreateDirectory(path);
            bool result = Directory.Exists(path);
            context.DeleteAllJournals(path);

            Assert.IsTrue(result);
        }

        [Test]
        public void TextFileLogger_MessageDelimiter_IsInvalidDelimiter_Test()
        {
            TextFileLogger target = (TextFileLogger)CreateTestObject();

            Assert.IsTrue(!string.IsNullOrEmpty(target.MessageDelimiter));
        }

        [TestCase(1, "message")]
        public void TextFileLogger_Log_JournalExist_Test(int level, string message)
        {
            TextFileLogger target = (TextFileLogger)CreateTestObject();
            TextFileLoggerTestsContext context = new TextFileLoggerTestsContext();

            context.CreateJournal(target.FilePath);
            target.Log(level, message);
            string line = context.GetLastLines(target.FilePath);
            context.DeleteJournals(target.FilePath);

            Assert.AreEqual(line, target.MessageFormatter.Format(level, message));
        }

        [TestCase(1, "message")]
        public void TextFileLogger_Log_JournalNotExist_Test(int level, string message)
        {
            TextFileLogger target = (TextFileLogger)CreateTestObject();
            TextFileLoggerTestsContext context = new TextFileLoggerTestsContext();
            bool JournalCreated = false;

            target.Log(level, message);
            JournalCreated = context.thisJournalExists(target.FilePath);
            context.DeleteJournals(target.FilePath);

            Assert.IsTrue(JournalCreated);
        }
    }
}