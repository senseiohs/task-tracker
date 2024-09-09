using TaskTracker;

namespace taskTracker.Helpers
{
    public class OrchestratorTaskList
    {
        public List<TaskAssignment> ListTask { get; set; } = new List<TaskAssignment>();

        public void Add()
        {
            var newTask = new TaskAssignment();
            Console.Clear();
            if (ListTask.Count == 255)
            {
                ListTask.Clear();
            }

            newTask.Id = (Byte)ListTask.Count;
            newTask.CreatedAt = newTask.UpdatedAt = DateTime.Now;
            newTask.Status = Status.Todo;
            Console.Write("Write task's description: ");
            newTask.Description = Console.ReadLine();

            ListTask.Add(newTask);
        }

        public void Update()
        {

            ListTask[task.Id] = task;
        }

        public void Delete(Byte id)
        {
            ListTask.RemoveAt(id);
        }

        public void ShowTaskList()
        {
            Console.Clear();
            if (ListTask.Any())
            {
                ListTask.ForEach(task =>
                {
                    Console.WriteLine($"{task.Id}-{task.Description}-{task.Status}-{task.CreatedAt.ToLongTimeString()}-{task.UpdatedAt.ToLongTimeString()}");
                });
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("The task list is empty...");
                Console.ReadKey();
            }
        }
    }
}