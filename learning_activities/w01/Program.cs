using System;
using System.Collections.Generic;
using System.Diagnostics;

class Program {
    static void Main() {
        List<int> numbers = new List<int>();
        
        Console.WriteLine("--- Capacity Test ---");
        for (int i = 0; i < 10; i++) {
            numbers.Add(i);
            Console.WriteLine($"Size: {numbers.Count}, Capacity: {numbers.Capacity}");
        }

        Stopwatch sw = new Stopwatch();
        
        sw.Start();
        numbers.Insert(0, 99);
        sw.Stop();
        Console.WriteLine($"\nInsert at index 0 took: {sw.ElapsedTicks} ticks");

        sw.Restart();
        numbers.Add(100);
        sw.Stop();
        Console.WriteLine($"Append to end took: {sw.ElapsedTicks} ticks");
    }
}