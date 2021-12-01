using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Days
{
    class Day1
    {
        static string inputPath = @"C:\git\aoc2021\day1_input.txt";
        static string[] lines = File.ReadAllLines(inputPath); 
        public static int Part1()
        {
            int? previousNumber = null;
            int numberOfIncreases = 0;
            foreach (var line in lines) {
                var currentNumber = Convert.ToInt32(line.Trim());
                if (previousNumber is not null && currentNumber > previousNumber) {
                    numberOfIncreases++;
                }
                previousNumber = currentNumber;
            }
            return numberOfIncreases;
        }

        public static int Part2()
        {
            Queue<List<int>> depthWindows = new Queue<List<int>>();
            List<int> completeWindow = null;
            int numberOfIncreases = 0;
            foreach (var line in lines) {
                int currentDepth = Convert.ToInt32(line.Trim());
                if (depthWindows.Count <= 3) {
                    if (depthWindows.Count == 3) {
                        completeWindow = depthWindows.Dequeue();
                    }
                    depthWindows.Enqueue(new List<int>());
                    foreach (var window in depthWindows) {
                        window.Add(currentDepth);
                    }
                }
                if (completeWindow is not null && depthWindows.ElementAt(0).Sum() > completeWindow.Sum()) {
                    numberOfIncreases++;
                }
            }
            return numberOfIncreases;
        }
    }
}