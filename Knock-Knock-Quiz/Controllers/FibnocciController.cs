using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Knock_Knock_Quiz.App.Controllers
{
    [Produces("application/json")]
    [Route("api/Fibnocci")]
    public class FibnocciController : Controller
    {
        //[HttpGet("{number}")]
        [HttpGet]
        public IActionResult Get([FromQuery(Name = "number")]string number)
        {
            
            bool isInputValid = int.TryParse(number, out int input);
            if (isInputValid)
            {
                if (input < 0) input = input*-1;
                return Ok(GetFibonacci(input));
            }
            else
            //    return BadRequest(new { Message = "Invalid input" });
            return StatusCode(400, new { Message = "Invalid input" });

             int GetFibonacci(int n)
            {
                int a = 0;
                int b = 1;
                for (int i = 0; i < n; i++)
                {
                    int temp = a;
                    a = b;
                    b = temp + b;
                }
                return a;
            }

        }
        

    }
}