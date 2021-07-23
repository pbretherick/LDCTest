using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Strings.BLL;

namespace StringTests
{
    [TestClass]
    public class ManagerTests
    {
		[DataTestMethod]
        [DynamicData(nameof(GetProcessTestData), DynamicDataSourceType.Method)]
		public void Process_ReturnCorrectValues(List<string> strings, List<string> expectedResult)
		{
			// Given I have created my processor
			var moqStringsManager = new StringsManager();

			// When I call Process
			var result = moqStringsManager.Process(strings);

            // Then I expect the result is not null
            Assert.IsNotNull(result);

            // And there should not be any null or empty strings
            Assert.IsTrue(result.Where(s => string.IsNullOrEmpty(s)).Count() == 0);

			// And I expect that the expected values were returned
			Assert.IsTrue(Enumerable.SequenceEqual(expectedResult, result));
		}

        private static IEnumerable<object[]> GetProcessTestData()
        {
            yield return new object[] { new List<string>() {"aabbcc", null, "AaBbCc"}, new List<string>() {"abc", "AaBbCc"} };
            yield return new object[] { new List<string>() {"££$$%%", "", "11223344"}, new List<string>() {"££££%%", "112233"} };
            yield return new object[] { null, new List<string>() };
            yield return new object[] { new List<string>() {"££__%%", "4", "12345678901234567890"}, new List<string>() {"££%%", "123567890123567"} };
            yield return new object[] { new List<string>() {"AAAc91%cWwWkLq$1ci3_848v3d__K"}, new List<string>() {"Ac91%cWwWkLq£1c"} };
        }
    }
}