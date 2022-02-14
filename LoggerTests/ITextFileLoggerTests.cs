using NUnit.Framework;
using System;
using Moq;
using Logger;

namespace LoggerTests {
    [TestFixture]
    abstract public class ITextFileLoggerTests {
        protected abstract ITextFileLogger CreateTestObject();
        private ITextFileLogger TestObject;

        [SetUp]
        public void Setup() {
            TestObject = CreateTestObject();
        }

        [Test]
        public void ITextFileLogger_Encoding_DefaultValue_Test() {
            string res = TestObject.Encoding.ToString();

            Assert.IsFalse(string.IsNullOrEmpty(res));
        }

        [Test]
        public void ITextFileLogger_FilePath_DefaultValue_Test() {
            Assert.IsFalse(string.IsNullOrEmpty(TestObject.FilePath));
        }

        [Test]
        public void ITextFileLogger_MessageDelimiter_DefaultValue_Test() {
            Assert.IsFalse(string.IsNullOrEmpty(TestObject.MessageDelimiter));
        }

        [Test]
        public void ITextFileLogger_MessageFormatter_DefaultValue_Test() {
            Assert.IsNotNull(TestObject.MessageFormatter);
        }

        [Test]
        public void ITextFileLogger_MessageFormatter_SetCorrectValue_Test() {
            var expected = Mock.Of<IMessageFormatter>();

            TestObject.MessageFormatter = expected;

            Assert.AreEqual(expected, TestObject.MessageFormatter);
        }

        [Test]
        public void ITextFileLogger_MessageFormatter_SetIncorrectValueTryCatch_Test() {
            bool res = false;
            TestObject.MessageFormatter = null;

            try {
                if(TestObject.MessageFormatter == null) {
                    throw new ArgumentNullException();
                }
            } catch(ArgumentNullException) {
                res = true;
            }

            Assert.IsTrue(res);
        }
    }
}