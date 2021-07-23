using Microsoft.VisualStudio.TestTools.UnitTesting;
using Strings.BLL.StringProcessors;

namespace StringTests
{
    [TestClass]
    public class StringProcessorTests
    {
		[DataTestMethod]
		[DataRow("aabbcc", "abc")]
        [DataRow("AaBbCc", "AaBbCc")]
        [DataRow("AABBCC", "ABC")]
        [DataRow("112233", "112233")]
        [DataRow("££$$%%", "££$$%%")]
        [DataRow("aaaaaa", "a")]
		public void DuplicateCharacterProcessor_ReturnCorrectValues(string param, string expectedResult)
		{
			// Given I have created my processor
			var processor = new DuplicateCharacterProcessor();

			// When I call Process
			var result = processor.Process(param);

			// Then I expect that the expected result was returned
			Assert.AreEqual(expectedResult, result);
		}

        [TestMethod]
        public void ReplaceCharacterProcessor_ReturnsCorrectValues()
        {
			// Given I have created my processor
			var processor = new ReplaceCharacterProcessor("a", "b");

			// When I call Process
			var result = processor.Process("abc");

			// Then I expect that the expected result was returned
			Assert.AreEqual("bbc", result);
        }

        [TestMethod]
        public void Process_ReturnsCorrectValues()
        {
			// Given I have created my processor
			var processor = new ReplaceCharacterProcessor("a", "b")
                .SetNext(new ReplaceCharacterProcessor("c", "d"));

			// When I call Process
            var result = processor.Process("abcd");

			// Then I expect that the expected result was returned
			Assert.AreEqual("bbdd", result);
        }
    }
}