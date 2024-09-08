namespace taskTracker.Helpers
{
    public static class Menu
    {
        public static Byte ShowOptions()
        {
            Byte option = 255;
            bool isSelected = false;
            Console.Clear();
            Console.WriteLine("Enter the option: ");

            while (!isSelected)
            {
                var enterOption = Console.ReadLine();
                isSelected = Byte.TryParse(enterOption, out option);
            }

            return option;
        }

        public static void ShowHelp()
        {
            Console.Clear();
            Console.WriteLine("1. List Task");
            Console.WriteLine("2. Add Task");
            Console.WriteLine("3. Update Task");
            Console.WriteLine("4. Delete Task");
            Console.WriteLine("5. List all task");
            Console.WriteLine("6. List Task Todo");
            Console.WriteLine("7. List Task In Progress");
            Console.WriteLine("8. List Task Done");
            Console.WriteLine("-------------------------------------");
        }
    }
}