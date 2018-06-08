using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TypingUnknown
{
    class Program
    {
        static void Main(string[] args)
        {
            const double GET_READY_TIME_IN_SECS = 2.5,
                QUIZ_TIME_IN_SECS = 3.8,
                MIN_INTERVAL_IN_SECS = 1.5;

            var keySet = KeyPallet.ServeKeySet(KeyRegion.RIGHT);
            var keyCount = keySet.Length;
            char key;
            var random = new Random(3);
            var watch = new Stopwatch();
            string answer = string.Empty,
                comment = string.Empty;
            double elapsed_ms;

            Console.WriteLine("Let's begin!");
            Console.WriteLine(string.Format("Your target is {0:F2} secs, and of course, with correct answer!", QUIZ_TIME_IN_SECS));
            Console.WriteLine();

            // not sleeping ???
            Thread.Sleep(Convert.ToInt32(Math.Ceiling(MIN_INTERVAL_IN_SECS)));

            while (true)
            {
                key = keySet[random.Next(keyCount)];
                Console.WriteLine(key);
                watch.Start();

                // wrap this with time out logic
                // cannot interrupt Console.Readline()
                answer = Console.ReadLine();
                elapsed_ms = watch.Elapsed.TotalMilliseconds;

                if (answer == key.ToString())
                {
                    if (elapsed_ms < QUIZ_TIME_IN_SECS * 0.33 * 1000)
                    {
                        comment = "Perfect";
                    }
                    else if (elapsed_ms < QUIZ_TIME_IN_SECS * 0.66 * 1000)
                    {
                        comment = "Good";
                    }
                    else
                    {
                        comment = "Correct";
                    }
                }
                else
                {
                    comment = "Wrong";
                }
                Console.WriteLine(comment + (elapsed_ms > QUIZ_TIME_IN_SECS * 1000 ? string.Format(" [{0:F2} secs]", elapsed_ms / 1000) : string.Empty));
                if (elapsed_ms < QUIZ_TIME_IN_SECS * 1000)
                {
                    Thread.Sleep(Convert.ToInt32(QUIZ_TIME_IN_SECS * 1000 - elapsed_ms));
                }
                else
                {
                    Thread.Sleep(Convert.ToInt32(MIN_INTERVAL_IN_SECS * 1000));
                }
                watch.Reset();
            }
        }
    }
}
