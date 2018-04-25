using Knock_Knock_Quiz.App.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace Knock_Knock_Quiz.Test
{
    public class FibnocciTest
    {
        [Fact]
        public void TestFibnocci()
        {
            var controller = new FibnocciController();

            // Act
            IActionResult actionResult =  controller.Get("5");

            // Assert
            Assert.NotNull(actionResult);

            OkObjectResult result = actionResult as OkObjectResult;

            Assert.NotNull(result);

            int  value =(int) result.Value ;

            Assert.Equal(5, value);
        }
    }
}
