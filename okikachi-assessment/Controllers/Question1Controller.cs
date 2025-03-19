using Microsoft.AspNetCore.Mvc;

namespace okakichi_assessment.Controllers
{
    [ApiController]
    [Route("api/question1")]
    public class Question1Controller : Controller
    {
        [HttpPost("SumEvenNumbers")]
        public IActionResult SumEvenNumbers([FromBody] int[] numbers)
        {
            if (numbers == null || numbers.Length == 0)
            {
                return BadRequest(new { message = "Input array cannot be empty." });
            }
            
            // n % 2 == 0 will check if the number is even number
            int sum = numbers.Where(n => n % 2 == 0).Sum();
            return Ok(new { Sum = sum });
        }
    }
}
