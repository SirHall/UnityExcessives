using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Excessives
{

    static class ConsolE
    {
        //Queue of stuff to print
        static List<string> queue = new List<string>();
        #region Public Interface
        public static void Write(string message)
        {
            queue.Add(message);

            Run();
        }

        public static void WriteLine(string message)
        {
            queue.Add(message + "\n");

            Run();
        }
        #endregion

        static void Run()
        {
            if (printThread != null)
                return;

            printThread = new Thread(PrintAll);
            printThread.Start();
        }

        static Thread printThread;

        static void PrintAll()
        {
            //queue.ForEach(n => Console.Write(n));

            for (int i = 0; i < queue.Count; i++)
            {
                Console.Write(queue[0]);
                queue.RemoveAt(0);
            }
        }
    }
}
