using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace PhotonX
{
    class _Log
    {

        private int hours, minutes, seconds;
        public static _Log l = new _Log();

        /// <summary>
        /// The logF function writes the given T parameter to the terminal.
        /// 
        /// It would be helpful to note that, when the log is critical the text color
        /// displayed on the terminal will be red. If it isn't, the text color is set to yellow.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="content"></param>
        public void logF<T>(T content, bool is_critical)
        {
            // fetch current time.
            hours = DateTime.UtcNow.Hour;
            minutes = DateTime.UtcNow.Minute;
            seconds = DateTime.UtcNow.Second;
            string timeFmt = $"{hours}:{minutes}:{seconds}";

            if(is_critical)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"\n[{timeFmt}] (CRITICAL) LOG: {content}       ~~~");
                return;
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"\n[{timeFmt}] LOG: {content} : ");
        }


    }
}
