using System.Security.Cryptography;
using taskTracker.Helpers;
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Welcome to task tracker program!");

//Open file .json with our data
var orchestrator = new OrchestratorTaskList();
orchestrator.ListTask = TaskJsonFileProcess.GetTaskList();

Byte option = 255;

while (option != 0)
{
    option = Menu.ShowOptions();
    switch (option)
    {
        case 0:
            Console.Clear();
            Console.WriteLine("Press Key to continue...");
            Console.ReadLine();
            break;
        case 1:
            orchestrator.ShowTaskList();
            break;
        case 2:
            orchestrator.Add();
            break;
        case 3:
            orchestrator.Update();
            break;
        case 4:
            orchestrator.Add();
            break;
        case 5:
            orchestrator.Add();
            break;
        case 6:
            orchestrator.Add();
            break;
        case 7:
            orchestrator.Add();
            break;
        case 8:
            orchestrator.Add();
            break;
        case 9:
            orchestrator.Add();
            break;
        default:
            Menu.ShowOptions();
            break;
    }
}

TaskJsonFileProcess.SaveTaskList(orchestrator.ListTask);
