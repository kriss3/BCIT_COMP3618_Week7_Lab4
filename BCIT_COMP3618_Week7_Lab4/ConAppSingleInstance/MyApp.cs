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
                WriteLine($"Error occured during the first run of the app. \nError: {mutextEx.Message}");
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
                WriteLine("Instance of this application already exist. Hit Enter to exit !");
                Read();
                return;
            }
            WriteLine("Applicaton is running now. Keep window open and try to open another instance of this app (run .exe)");
            Read();
        }
    }
}
