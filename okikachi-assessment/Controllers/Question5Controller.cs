using Microsoft.AspNetCore.Mvc;
using System;

namespace okakichi_assessment.Controllers
{
    [ApiController]
    [Route("api/question5")]
    public class Question5Controller : Controller
    {
        [HttpPost("FindFirstDuplicate")]
        public IActionResult FindFirstDuplicate([FromBody] int[] nums)
        {
            HashSet<int> seenNumbers = new HashSet<int>();
            foreach (int num in nums)
            {
                if (seenNumbers.Contains(num))
                    return Ok(new { Result = "First Duplicate: " + num });
                seenNumbers.Add(num);
            }

            /**
             * The logic for this function is
             * everytime a new number if run, it will added to new HashSet
             * before each number if added to the HashSet, it will then check if the number exist in the HashSet,
             * if it is existed, it will return the duplicate number.
             */

            return Ok("No Duplicate found");
        }
    }
}
