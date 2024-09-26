using TaskTracker;

namespace taskTracker.Helpers
{
    public class OrchestratorTaskList
    {
        public List<TaskAssignment> TaskList { get; set; } = new List<TaskAssignment>();
        bool exit = false;

        public bool ProcessOneParameters(string option)
        {
            switch (option)
            {
                case "list":
                    if (TaskList.Count > 0)
                    {
                        PrintTable();
                        ListTask();
                    }
                    break;
                case "help":
                    Menu.ShowHelp();
                    break;
                case "exit":
                    exit = true;
                    break;
                default:
                    OptionNoValid(option);
                    break;
            }
            return exit;
        }

        public bool ProcessTwoParameters(string[] parameters)
        {
            switch (parameters[0])
            {
                case "list":
                    ListTaskStatus(parameters[1].ToLower());
                    break;
                case "delete":
                    Delete(parameters[1]);
                    break;
                case "add":
                    Add(parameters[1]);
                    break;
                case "mark-done":
                    UpdateStatusTask(parameters[1].ToLower(), Status.done);
                    break;
                case "mark-progress":
                    UpdateStatusTask(parameters[1].ToLower(), Status.inprogress);
                    break;
                default:
                    OptionNoValid($"{parameters[0]} {parameters[1]}");
                    break;
            }
            return exit;
        }

        public bool ProcessThreeParameters(string[] parameters)
        {
            switch (parameters[0].ToLower())
            {
                case "update":
                    Update(parameters[1], parameters[2]);
                    break;
                default:
                    OptionNoValid($"{string.Join(" ", parameters)}");
                    break;
            }
            return exit;
        }
        void UpdateStatusTask(string id, Status status)
        {
            byte index = 0;
            if (byte.TryParse(id, out index) && TaskList.Count <= index)
            {
                TaskList[index].Status = status;
            }
            else
            {
                OptionNoValid(id);
            }
        }
        void ListTaskStatus(string option)
        {
            switch (option)
            {
                case "done":
                case "todo":
                case "inprogress":
                    if (TaskList.Count > 0)
                    {
                        PrintTable();
                        ListTaskWithStatus(option);
                    }
                    break;
                default:
                    OptionNoValid(option);
                    break;
            }
        }

        void ListTaskWithStatus(string status)
        {
            TaskList.ForEach(task =>
            {
                if (string.Equals(task.Status.ToString(), status))
                {
                    PrintTask(task);
                }
            });
        }

        void ListTask()
        {
            TaskList.ForEach(PrintTask);
        }

        void PrintTable()
        {
            Console.Clear();
            Console.WriteLine(new string('-', 130));
            Console.WriteLine($"| {"Id",-5} | {"Description",-45} | {"Status",-15} | {"Created",-25} | {"Updated",-25} |");
            Console.WriteLine(new string('-', 130));
        }
        static void PrintTask(TaskAssignment task)
        {
            Console.WriteLine($"| {task.Id,-5} | {task.Description,-45} | {task.Status,-15} | {task.CreatedAt,-25} | {task.UpdatedAt,-25} |");
        }

        void Add(string description)
        {
            if (TaskList.Count < byte.MaxValue)
            {
                var newTask = new TaskAssignment();
                newTask.Id += (Byte)TaskList.Count;
                newTask.CreatedAt = newTask.UpdatedAt = DateTime.Now;
                newTask.Status = Status.todo;
                newTask.Description = description;

                TaskList.Add(newTask);
            }
            else
            {
                OptionNoValid("The list task is full");
            }
        }

        void Update(string taskId, string description)
        {
            byte index;
            if (byte.TryParse(taskId, out index) && TaskList.Count <= index)
            {
                TaskList[index].Description = description;
                TaskList[index].UpdatedAt = DateTime.UtcNow;
            }
            else
            {
                OptionNoValid($"update {taskId} {description}");
            }
        }

        void Delete(string id)
        {
            byte index = 0;
            if (byte.TryParse(id, out index) && TaskList.Count <= index)
            {
                TaskList.RemoveAt(index);
            }
            else
            {
                OptionNoValid(id);
            }
        }

        static void OptionNoValid(string option)
        {
            Console.Clear();
            Console.WriteLine($"The option: {option} - is not valid.");
            Console.ReadKey();
        }
    }
}