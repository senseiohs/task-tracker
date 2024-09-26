using System.Security.Cryptography;
using taskTracker.Helpers;
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Welcome to task tracker program!");

//Open file .json with our data
var orchestrator = new OrchestratorTaskList();
orchestrator.TaskList = TaskJsonFileProcess.GetTaskList();

string[] parameters;
bool continueProcess = false;

while (!continueProcess)
{
    parameters = Menu.ShowOptions();
    switch (parameters.Length)
    {
        case 1:
            continueProcess = orchestrator.ProcessOneParameters(parameters[0].ToLower());
            break;
        case 2:
            continueProcess = orchestrator.ProcessTwoParameters(parameters);
            break;
        case 3:
            continueProcess = orchestrator.ProcessThreeParameters(parameters);
            break;
        default:
            Menu.ShowOptions();
            break;
    }
    Console.WriteLine("Press any key to continue...");
    Console.ReadKey();
}

TaskJsonFileProcess.SaveTaskList(orchestrator.TaskList);
