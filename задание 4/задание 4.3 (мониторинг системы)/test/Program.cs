using System;
using System.Diagnostics;

class Program
{
   


    static void Main()
    {
        PerformanceCounter cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
        PerformanceCounter ramCounter = new PerformanceCounter("Memory", "Available MBytes");
        PerformanceCounter diskCounter = new PerformanceCounter("LogicalDisk", "% Free Space", "C:");


        while (true)
        {
            float cpuUsage = cpuCounter.NextValue();
            float availableMemory = ramCounter.NextValue();
            float freeDiskSpace = diskCounter.NextValue();
            
            Console.WriteLine($"Свободное место на диске C: {freeDiskSpace}%");
            Console.WriteLine($"Доступно памяти: {availableMemory} MB");
            Console.Write($"Загрузка процессора: {cpuUsage}%");
            
            System.Threading.Thread.Sleep(1000); 
            Console.Clear();    
        }
    }

}