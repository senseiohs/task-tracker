using System.Text.Json;
using TaskTracker;

namespace taskTracker.Helpers
{
    public static class TaskJsonFileProcess
    {
        public static List<TaskAssignment> GetTaskList()
        {
            List<TaskAssignment> dataTask = new List<TaskAssignment>();
            var currentDirectory = Directory.GetCurrentDirectory();
            var storeDirectory = Path.Combine(currentDirectory, "taskList");
            var pathTaskListFile = Path.Combine(storeDirectory, "taskList.json");

            if (Directory.Exists(storeDirectory) && File.Exists(pathTaskListFile))
            {
                var dataFile = File.ReadAllText(pathTaskListFile) ?? string.Empty;
                dataTask = !string.IsNullOrWhiteSpace(dataFile) ? JsonSerializer.Deserialize<List<TaskAssignment>>(dataFile) : dataTask;
            }
            else
            {
                Directory.CreateDirectory(storeDirectory);
                File.WriteAllText(pathTaskListFile, string.Empty);
            }

            return dataTask;
        }

        public static bool SaveTaskList(IEnumerable<TaskAssignment> taskList)
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var storeDirectory = Path.Combine(currentDirectory, "taskList");
            Directory.CreateDirectory(storeDirectory);

            var dataTaskList = JsonSerializer.Serialize(taskList);
            try
            {
                File.WriteAllText(Path.Combine(storeDirectory, "taskList.json"), dataTaskList);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return true;
        }
    }
}