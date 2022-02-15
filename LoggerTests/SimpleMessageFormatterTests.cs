using NUnit.Framework;
using Logger;

namespace LoggerTests {
    [TestFixture]
    public class SimpleMessageFormatterTests {

        [TestCase(1, "")]
        [TestCase(0, "someMessage")]
        [TestCase(-1, null)]
        public void SimpleMessageFormatter_Format_Test(int level, string mess) {
            var TestObject = new SimpleMessageFormatter();

            string result = TestObject.Format(level, mess);
            string expected = level + ": " + mess;

            Assert.AreEqual(expected, result);
        }
    }
}

