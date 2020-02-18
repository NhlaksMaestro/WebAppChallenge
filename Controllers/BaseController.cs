using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebAppChallenge.Helper.Exceptions;
using WebChallenge.Contracts.Repository;
using WebChallenge.DB.Model;

namespace WebAppChallenge.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BaseController : ControllerBase
    {

        protected IActionResult FormatException<T>(string message, Exception ex) where T : Exception
        {
            var exception = (T)Activator.CreateInstance(typeof(T), message, ex);
            return StatusCode((int)HttpStatusCode.InternalServerError, exception);
        }
    }
}
