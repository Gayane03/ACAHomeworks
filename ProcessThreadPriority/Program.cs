﻿using System.Diagnostics;

object lockingObj=new object();

ThreadPriority[] threadPriority = { ThreadPriority.Lowest, ThreadPriority.BelowNormal,
    ThreadPriority.Normal, ThreadPriority.AboveNormal, ThreadPriority.Highest };

ProcessPriorityClass[] processPriority = {ProcessPriorityClass.Normal, ProcessPriorityClass.Idle,
ProcessPriorityClass.High,ProcessPriorityClass.RealTime,ProcessPriorityClass.BelowNormal,ProcessPriorityClass.AboveNormal};

List<Priority> listPriorities = new();
Process pr = Process.GetCurrentProcess();
Console.WriteLine($"Process name : {pr.ProcessName}\n");

for (int i = 0; i < processPriority.Length; i++)
{
    for (int j = 0; j < threadPriority.Length; j++)
    {
        pr.PriorityClass = processPriority[i];
        Thread th = new Thread(CPUBoundProcess);
        th.Priority = threadPriority[j];
        th.Start();
        Thread.Sleep(10);
   
        listPriorities.Add(new Priority { ThreadPri = th.Priority, ProcessPri = pr.PriorityClass, Time = pr.TotalProcessorTime.TotalSeconds});
    }
}
var sortListPriorities = listPriorities.OrderBy(e=> e.Time);
int prcCount = 0;
foreach (var item in sortListPriorities)
{
    Console.WriteLine($"Time process : {item.Time}");
    Console.WriteLine($"Thread priority : {item.ThreadPri}");
    Console.WriteLine($"Thread priority : {item.ProcessPri}");
    Console.WriteLine( "--------------------------\n");
    ++prcCount;
}
Console.WriteLine(prcCount);

void CPUBoundProcess()
{
    try
    {
        Monitor.Enter(lockingObj);
        int count=0;
        for (int i = 0; i < 100000000000; i++)
        {
            count += 10*70-60+45/3;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
    finally
    {
        Monitor.Exit(lockingObj);
    }

}
class Priority
{
    public ThreadPriority ThreadPri { get; set; }
    public ProcessPriorityClass ProcessPri { get; set; }    
    public double Time { get; set; }   
}

