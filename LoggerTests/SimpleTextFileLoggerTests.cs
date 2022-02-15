using NUnit.Framework;
using System.Text;
using System.IO;
using Logger;

namespace LoggerTests {
    [TestFixture]
    public class SimpleTextFileLoggerTests : ITextFileLoggerTests {
        protected override ITextFileLogger CreateTestObject() {
            return new SimpleTextFileLogger(Encoding.Unicode, @"C:\Logs\1.txt", "\n-----------\nend of recording\n\n");
        }

        private ITextFileLogger testObject;
        private SimpleTextFileLoggerTestsContext context;

        [SetUp]
        public void SetUp() {
            testObject = (SimpleTextFileLogger)CreateTestObject();
            context = new SimpleTextFileLoggerTestsContext();
        }

        [Test]
        public void TextFileLogger_FilePath_Test() {
            Assert.AreEqual(testObject.FilePath, @"C:\Logs\1.txt");
        }

        [Test]
        public void TextFileLogger_Encoding_Test() {
            Assert.AreEqual(testObject.Encoding, Encoding.Unicode);
        }

        [Test]
        public void TextFileLogger_MessageDelimiter_Test() {
            Assert.AreEqual(testObject.MessageDelimiter, "\n-----------\nконец записи\n\n");
        }

        [Test]
        public void TextFileLogger_FilePath_ValidDirectory_Test() {
            context.CreateJournal(testObject.FilePath);
            string directoryName = Path.GetDirectoryName(testObject.FilePath);
            bool result = Directory.Exists(directoryName);
            context.DeleteJournals(testObject.FilePath);

            Assert.IsTrue(result);
        }

        [Test]
        public void TextFileLogger_FilePath_ValidFile_Test() {

            string path = Path.GetDirectoryName(testObject.FilePath);
            context.CreateDirectory(path);
            bool result = Directory.Exists(path);
            context.DeleteAllJournals(path);

            Assert.IsTrue(result);
        }

        [Test]
        public void TextFileLogger_MessageDelimiter_IsInvalidDelimiter_Test() {
            Assert.IsTrue(!string.IsNullOrEmpty(testObject.MessageDelimiter));
        }

        [TestCase(1, "message")]
        public void TextFileLogger_Log_JournalExist_Test(int level, string message) {
            context.CreateJournal(testObject.FilePath);
            string lines = testObject.MessageFormatter.Format(level, message);
            testObject.Log(lines);
            string line = context.GetLastLines(testObject.FilePath);
            context.DeleteJournals(testObject.FilePath);

            Assert.AreEqual(line, testObject.MessageFormatter.Format(level, message));
        }

        [TestCase(1, "message")]
        public void TextFileLogger_Log_JournalNotExist_Test(int level, string message) {
            bool JournalCreated = false;

            string lines = testObject.MessageFormatter.Format(level, message);
            testObject.Log(lines);
            JournalCreated = context.thisJournalExists(testObject.FilePath);
            context.DeleteJournals(testObject.FilePath);

            Assert.IsTrue(JournalCreated);
        }
    }
}