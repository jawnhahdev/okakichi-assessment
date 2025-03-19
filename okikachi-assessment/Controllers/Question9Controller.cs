using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace okakichi_assessment.Controllers
{
    [ApiController]
    [Route("api/question9")]
    public class Question9Controller : Controller
    {
        [HttpGet("PrintTriangle")]
        public IActionResult PrintTriangle(int height, char symbol = '*')
        {
            if (height <= 0)
            {
                return BadRequest("Height must be a positive integer.");
            }

            StringBuilder triangle = new StringBuilder();
            triangle.Append("<pre style='font-size:20px; font-family:monospace;'>"); // Start preformatted text

            for (int i = 1; i <= height; i++)
            {
                // Create spaces for centering the triangle
                triangle.Append(new string(' ', height - i));

                // If it's the top *, make it red
                if (i == 1)
                {
                    triangle.Append("<span style='color:red;'>" + symbol + "</span>");
                }
                else
                {
                    // Append symbols (*)
                    triangle.Append(new string(symbol, 2 * i - 1));
                }

                // Move to the next line
                triangle.AppendLine();
            }

            triangle.Append("</pre>"); // Close preformatted text

            /**
             * Please use the endpoint /api/question9/PrintTriangle?height=5 to show the result
             * Eg: /api/question9/PrintTriangle?height=5&symbol=%23 for symbol '#', should use URL fragment identifier for symbol
             */

            return Content(triangle.ToString(), "text/html");
        }
    }
}
