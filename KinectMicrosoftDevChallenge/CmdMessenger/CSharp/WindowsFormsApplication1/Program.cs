using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Receive
{
    class Program
    {
        static void Main()
        {
            // mimics Arduino calling structure
            var receive = new Receive { RunLoop = true };
            receive.Setup();
            while (receive.RunLoop) receive.Loop();
            receive.Exit();
        }

    }
}
