using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Strings.BLL;

namespace Strings.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StringsController : ControllerBase
    {
        private readonly IStringsManager _stringsManager;

        public StringsController(IStringsManager stringsManager)
        {
            _stringsManager = stringsManager;
        }

		/// <summary>
		/// Processes strings
		/// </summary>
		/// <param name="strings">A List of strings to be processed.</param>
		[HttpPost()]
		[ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(List<string>))]
		[ProducesResponseType((int)HttpStatusCode.BadRequest)]
		public IActionResult Process(List<string> strings)
		{
			try
			{
				return Ok(_stringsManager.Process(strings));
			}
			catch (Exception exception)
			{
				return BadRequest(exception);
			}
		}
    }
}
