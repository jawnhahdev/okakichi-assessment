using Microsoft.AspNetCore.Mvc;
using okakichi_assessment.Model;

namespace okakichi_assessment.Controllers
{
    [ApiController]
    [Route("api/question3")]
    public class Question3Controller : Controller
    {
        private static List<TodoItem> _tasks = new List<TodoItem>();

        [HttpGet]
        public IEnumerable<TodoItem> GetTasks()
        {
            return _tasks;
        }

        [HttpPost]
        public IActionResult AddTask([FromBody] TodoItem task)
        {
            _tasks.Add(task);
            return CreatedAtAction(nameof(GetTasks), new { id = task.Id }, task);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTask(int id, [FromBody] TodoItem updatedTask)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == id);
            if (task == null) return NotFound();

            task.Description = updatedTask.Description;
            task.IsCompleted = updatedTask.IsCompleted;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTask(int id)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == id);
            if (task == null) return NotFound();

            _tasks.Remove(task);
            return NoContent();
        }
    }
}
