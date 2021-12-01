using NUnit.Framework;
using System.Text;
using System;
using Moq;


namespace ServiceCloud.Logger
{
    [TestFixture]
    abstract public class ITextFileLoggerTests
    {
        protected abstract ITextFileLogger CreateTestObject();

        [Test]
        public void ITextFileLogger_Encoding_DefaultValue_Test()
        {
            ITextFileLogger target = CreateTestObject();
            string res = target.Encoding.ToString();

            Assert.IsFalse(string.IsNullOrEmpty(res));
        }

        [Test]
        public void ITextFileLogger_FilePath_DefaultValue_Test()
        {
            ITextFileLogger target = CreateTestObject();

            Assert.IsFalse(string.IsNullOrEmpty(target.FilePath));
        }

        [Test]
        public void ITextFileLogger_MessageDelimiter_DefaultValue_Test()
        {
            ITextFileLogger target = CreateTestObject();

            Assert.IsFalse(string.IsNullOrEmpty(target.MessageDelimiter));
        }
        
        [Test]
        public void ITextFileLogger_MessageFormatter_DefaultValue_Test()
        {
            ITextFileLogger target = CreateTestObject();

            Assert.IsNotNull(target.MessageFormatter);
        }
        

        [Test]
        public void ITextFileLogger_MessageFormatter_SetCorrectValue_Test()
        {
            ITextFileLogger target = CreateTestObject();
            var expected = Mock.Of<IMessageFormatter>();

            target.MessageFormatter = expected;

            Assert.AreEqual(expected, target.MessageFormatter);
        }

        [Test]
        public void ITextFileLogger_MessageFormatter_SetIncorrectValueTryCatch_Test()
        {
            ITextFileLogger target = CreateTestObject();
            bool res = false;
            target.MessageFormatter = null;

            try
            {                
                if (target.MessageFormatter == null)
                {
                    throw new ArgumentNullException();
                }
            }
            catch (ArgumentNullException)
            {
                res = true;               
            }

            Assert.IsTrue(res);
        }
    }
}