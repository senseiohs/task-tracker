namespace taskTracker.Helpers
{
    public static class Menu
    {
        public static string[] ShowOptions()
        {
            string[] parameters = null;
            bool isCorrect = false;
            string command;

            while (!isCorrect)
            {
                Console.Clear();
                Console.WriteLine("task-cli => [help]");
                command = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(command))
                {
                    parameters = command.Split(" ");
                    isCorrect = parameters.Length > 0 && parameters.Length <= 2;
                }
            }

            return parameters;
        }

        public static void ShowHelp()
        {
            Console.Clear();
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("Type any below options:");
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("- update <id_task> <Description>");
            Console.WriteLine("- delete <id_task>");
            Console.WriteLine("- mark-in-progress <id_task>");
            Console.WriteLine("- mark-done <id_task>");
            Console.WriteLine("- add <Description>");
            Console.WriteLine("- list");
            Console.WriteLine("- list done");
            Console.WriteLine("- list todo");
            Console.WriteLine("- list inprogress");
            Console.WriteLine("- help");
            Console.WriteLine("- exit");
            Console.WriteLine("------------------------------------------");
        }
    }
}