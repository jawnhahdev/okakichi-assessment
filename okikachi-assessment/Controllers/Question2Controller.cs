using Microsoft.AspNetCore.Mvc;

namespace okakichi_assessment.Controllers
{
    [ApiController]
    [Route("api/question2")]
    public class Question2Controller : Controller
    {
        [HttpPost("BubbleSort")]
        public IActionResult BubbleSort([FromBody] int[] arr)
        {
            int n = arr.Length;

            /**
             * i represents the number of passes through the array.
             * The array will be traversed n - 1 times because after n-1 passes, all elements are sorted.
             * Each pass places the largest unsorted element at the end.
             */
            for (int i = 0; i < n - 1; i++)
            {
                /**
                 * j is used to compare adjacent elements.
                 * n - i - 1 ensures that we don't compare elements that are already sorted at the end.
                 * During each pass, it bubbles up the largest element to its correct position.
                 */
                for (int j = 0; j < n - i - 1; j++)
                {
                    /**
                     * If arr[j] (current element) is greater than arr[j + 1] (next element), they are swapped.
                     * This ensures that the largest element moves to the right in each iteration.
                     */
                    if (arr[j] > arr[j + 1])
                    {
                        // Swap arr[j] and arr[j+1]
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }

            /**
             * Example with [5, 3, 8, 4, 2]
             
             * Pass 1 (i = 0)
                Compare 5 and 3 → Swap → {3, 5, 8, 4, 2}
                Compare 5 and 8 → No swap
                Compare 8 and 4 → Swap → {3, 5, 4, 8, 2}
                Compare 8 and 2 → Swap → {3, 5, 4, 2, 8} ✅ (largest number 8 is in place)

             * Pass 2 (i = 1)
                Compare 3 and 5 → No swap
                Compare 5 and 4 → Swap → {3, 4, 5, 2, 8}
                Compare 5 and 2 → Swap → {3, 4, 2, 5, 8} ✅

             * Pass 3 (i = 2)
                Compare 3 and 4 → No swap
                Compare 4 and 2 → Swap → {3, 2, 4, 5, 8} ✅

             * Pass 4 (i = 3)
                Compare 3 and 2 → Swap → {2, 3, 4, 5, 8} ✅ (Sorted)
             */

            return Ok(new { Message = "Sorted Array: " + string.Join(", ", arr) });
        }
    }
}
