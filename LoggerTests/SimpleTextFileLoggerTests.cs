using NUnit.Framework;
using System.Text;
using System;
using System.IO;

namespace ServiceCloud.Logger {
    [TestFixture]
    public class SimpleTextFileLoggerTests : ITextFileLoggerTests {
        protected override ITextFileLogger CreateTestObject() {
            return new SimpleTextFileLogger(Encoding.Unicode, @"C:\Logs\1.txt", "\n-----------\nконец записи\n\n");
        }

        private ITextFileLogger TestObject;
        private SimpleTextFileLoggerTestsContext context;

        [SetUp]
        public void Setup() {
            TestObject = (SimpleTextFileLogger)CreateTestObject();
            context = new SimpleTextFileLoggerTestsContext();
        }

        [Test]
        public void TextFileLogger_FilePath_Test() {
            Assert.AreEqual(TestObject.FilePath, @"C:\Logs\1.txt");
        }

        [Test]
        public void TextFileLogger_Encoding_Test() {
            Assert.AreEqual(TestObject.Encoding, Encoding.Unicode);
        }

        [Test]
        public void TextFileLogger_MessageDelimiter_Test() {
            Assert.AreEqual(TestObject.MessageDelimiter, "\n-----------\nконец записи\n\n");
        }

        [Test]
        public void TextFileLogger_FilePath_ValidDirectory_Test() {
            context.CreateJournal(TestObject.FilePath);
            string directoryName = Path.GetDirectoryName(TestObject.FilePath);
            bool result = Directory.Exists(directoryName);
            context.DeleteJournals(TestObject.FilePath);

            Assert.IsTrue(result);
        }

        [Test]
        public void TextFileLogger_FilePath_ValidFile_Test() {

            string path = Path.GetDirectoryName(TestObject.FilePath);
            context.CreateDirectory(path);
            bool result = Directory.Exists(path);
            context.DeleteAllJournals(path);

            Assert.IsTrue(result);
        }

        [Test]
        public void TextFileLogger_MessageDelimiter_IsInvalidDelimiter_Test() {
            Assert.IsTrue(!string.IsNullOrEmpty(TestObject.MessageDelimiter));
        }

        [TestCase(1, "message")]
        public void TextFileLogger_Log_JournalExist_Test(int level, string message) {
            context.CreateJournal(TestObject.FilePath);
            string lines = TestObject.MessageFormatter.Format(level, message);
            TestObject.Log(lines);
            string line = context.GetLastLines(TestObject.FilePath);
            context.DeleteJournals(TestObject.FilePath);

            Assert.AreEqual(line, TestObject.MessageFormatter.Format(level, message));
        }

        [TestCase(1, "message")]
        public void TextFileLogger_Log_JournalNotExist_Test(int level, string message) {
            bool JournalCreated = false;

            string lines = TestObject.MessageFormatter.Format(level, message);
            TestObject.Log(lines);
            JournalCreated = context.thisJournalExists(TestObject.FilePath);
            context.DeleteJournals(TestObject.FilePath);

            Assert.IsTrue(JournalCreated);
        }
    }
}