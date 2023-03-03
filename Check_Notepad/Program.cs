using System.Diagnostics;
using System.Threading;

public class Check_notepad
{
    public static bool isRunning(string name)                                   // method to see if the process is working
    {
        foreach (var item in Process.GetProcesses())                            // item is the var who get every process
        {

            if (item.ProcessName.Contains(name)) { return true; }               // testing the process to see if is the one that i need


        }
        return false;
    }

    public static void closeApp(string name)                                    // method for killing the process
    {
        foreach (var item in Process.GetProcesses())                            // testing the processes
        {
            if (item.ProcessName.Contains(name))
            {
                item.Kill();
                Console.WriteLine("5 min passed, app has been closed!");
            }
        }
    }

    public static void keybind() {                                              // method for second thread wihch is waiting for key to close
        Console.WriteLine("Press q to close");
        char key;                                               
        key =Console.ReadKey().KeyChar;
        if (key=='q' || key=='Q') System.Environment.Exit(0);
    }

    public static void Main(string[] args)
    {
        Thread mainthread = Thread.CurrentThread;
        int timp = 0;                                                           // an integer to count my time(in mins)
        Thread newThread = new Thread(keybind);
        newThread.Start();
        while (true)
        {
            Thread.Sleep(60000);                                                // suspend the thread for 1 min
                timp++;
                if (!isRunning("Notes"))                                        //cecking if the app is already closed to reset the time
                { timp = 0; }
                else
                {
                    if (timp == 5)                                              // testing if it passed 5 mins 
                    {
                        closeApp("Notes");
                        timp = 0;
                    }
                }
        } 

    }
}