using System.Threading;
using static System.Console;

namespace ConAppSingleInstance
{
    class MyApp
    {
        /// <summary>
        /// BCIT COMP 3618 Week 7 Lab 4 - Krzysztof Szczurowski
        /// Use a Mutex to Create a Single-Instance Application
        /// Repo: https://github.com/kriss3/BCIT_COMP3618_Week7_Lab4.git
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Mutex oneMutex = null;
            const string MutexName = "RUNMEONLYONCE";
            try 
            {
                oneMutex = Mutex.OpenExisting(MutexName);
            }
            catch (WaitHandleCannotBeOpenedException mutextEx)
            {
                // Cannot open the mutex because it doesn't exist
                throw new WaitHandleCannotBeOpenedException($"Issue with opening wait handle. Error: {mutextEx.Message}");
                throw;
            }
            // Create new instance of mutex class if it doesn't exist (kind of singleton style)
            if (oneMutex == null)
            {
                oneMutex = new Mutex(true, MutexName);
            }
            else
            {
                // Close the mutex and exit the application => only one instance of mutex can exist;
                oneMutex.Close();
                return;
            }
            WriteLine("Our Application");
            Read();
        }
    }
}
