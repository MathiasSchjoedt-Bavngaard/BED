using System;
namespace Hearthstone.Services
{
    public class ControllerLogger
    {
        public ControllerLogger() { }


        public void OutputLine(string output)
        {
            Console.WriteLine(output);
        }

        public async void SaveStringToFile(string saveToFile)
        {
            //await File.WriteAllLinesAsync("Logs.txt",saveToFile);
        }
    }
}
