using System;
using System.Collections.Generic;
using System.Text;

namespace Keshi.Commands
{
    class ExitCommand : ICommand
    {
        public bool Execute()
        {
            Console.WriteLine("Will exit");
            return false;
        }
    }
}
