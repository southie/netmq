#if NETSTANDARD1_3 || WINDOWS_UWP
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace NetMQ
{
    public class Thread
    {
        public string Name;
        public bool IsBackground = false;
        Task task;
        Action action;
        public Thread(Action a)
        {
            action = a;
        }
        public void Start()
        {
            task = Task.Run(action);
            if(!IsBackground)
            {
                Join();
            }
        }

        public void Join()
        {
            task.Wait();
        }

        public static void Sleep(int millis)
        {
            Task.Delay(millis).Wait();
        }
    }
}
#endif