using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Knock_Knock_Quiz.App.Controllers
{
    [Produces("application/json")]
    [Route("api/ReverseWord")]
    public class ReverseWordController : Controller
    {
        //[HttpGet("{number}")]

       [HttpGet]
        public IActionResult Get([FromQuery(Name = "sentence")]string sentence)
        {

            
            if (!string.IsNullOrEmpty(sentence))
            {
                var reversedWords = string.Join(" ", sentence.Split(' ').Select(x => new String(x.Reverse().ToArray())));
                return Ok(reversedWords);
            }
            else
                //    return BadRequest(new { Message = "Invalid input" });
                return StatusCode(400, string.Empty);

           

        }

    }
}