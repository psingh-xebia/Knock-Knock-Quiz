using Knock_Knock_Quiz.App.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace Knock_Knock_Quiz.Test
{
    public class ReverseWordTest
    {
        [Fact]
        public void TestReverseWord()
        {
            var controller = new ReverseWordController();

            // Act
            IActionResult actionResult =  controller.Get("Hello How");

            // Assert
            Assert.NotNull(actionResult);

            OkObjectResult result = actionResult as OkObjectResult;

            Assert.NotNull(result);

            string  sentence = result.Value as string;

            Assert.Equal("olleH woH", sentence);
        }
    }
}
