using NUnit.Framework;
using System;
using Moq;
using Logger;

namespace LoggerTests {
    [TestFixture]
    abstract public class ITextFileLoggerTests {
        protected abstract ITextFileLogger CreateTestObject();
        private ITextFileLogger testObject;

        [SetUp]
        public void Setup() {
            testObject = CreateTestObject();
        }

        [Test]
        public void ITextFileLogger_Encoding_DefaultValue_Test() {
            string res = testObject.Encoding.ToString();

            Assert.IsFalse(string.IsNullOrEmpty(res));
        }

        [Test]
        public void ITextFileLogger_FilePath_DefaultValue_Test() {
            Assert.IsFalse(string.IsNullOrEmpty(testObject.FilePath));
        }

        [Test]
        public void ITextFileLogger_MessageDelimiter_DefaultValue_Test() {
            Assert.IsFalse(string.IsNullOrEmpty(testObject.MessageDelimiter));
        }

        [Test]
        public void ITextFileLogger_MessageFormatter_DefaultValue_Test() {
            Assert.IsNotNull(testObject.MessageFormatter);
        }

        [Test]
        public void ITextFileLogger_MessageFormatter_SetCorrectValue_Test() {
            var expected = Mock.Of<IMessageFormatter>();

            testObject.MessageFormatter = expected;

            Assert.AreEqual(expected, testObject.MessageFormatter);
        }

        [Test]
        public void ITextFileLogger_MessageFormatter_SetIncorrectValueTryCatch_Test() {
            bool res = false;
            testObject.MessageFormatter = null;

            try {
                if(testObject.MessageFormatter == null) {
                    throw new ArgumentNullException();
                }
            } catch(ArgumentNullException) {
                res = true;
            }

            Assert.IsTrue(res);
        }
    }
}