using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Strings.BLL;
using Strings.Controllers;

namespace StringTests
{
    [TestClass]
    public class ControllerTests
    {
        [TestMethod]
		public void Process_Calls_StringManager_Process()
		{
			// Given I have mocked my manager
			var moqStringsManager = new Mock<IStringsManager>();
			var strings = new List<string>() { "aaa", "bbb", "ccc" };

			// And I have instantiated my controller
			var controller = new StringsController(moqStringsManager.Object);

			// When I call the controller
			var result = controller.Process(strings);

			// Then I expect that the manager was called once with the correct parameter
			moqStringsManager.Verify(m => m.Process(strings), Times.Once);
		}
    }
}
