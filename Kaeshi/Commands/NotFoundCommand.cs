using System;

namespace Keshi.Commands
{
    public class NotFoundCommand : ICommand
    {
        public bool Execute()
        {
            Console.WriteLine("No command");
            return true;
        }
    }
}
