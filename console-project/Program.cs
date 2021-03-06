﻿using System;
using System.Threading;

namespace console_project
{
    internal static class Program
    {
        private static void Main()
        {
            var sixth = new CountdownThread(() =>
            {
                Console.WriteLine("6!");
            });
            sixth.Start();
            
            var fifth = new CountdownThread(() =>
            {
                Console.WriteLine("5!");
            });
            fifth.Start();

            var second = new CountdownThread(() =>
            {
                Console.WriteLine("2!");
                Thread.Sleep(1000);
                fifth.Signal();
                sixth.Signal();
            }, 2);
            second.Start();

            var third = new CountdownThread(() =>
            {
                Console.WriteLine("3!");
                Thread.Sleep(1000);
                second.Signal();
            });
            third.Start();
            
            var first = new Thread(() =>
            {
                Console.WriteLine("1!");
                Thread.Sleep(1000);
                second.Signal();
                third.Signal();
            });
            first.Start();
        }
    }
}
