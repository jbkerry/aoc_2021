using System;

using Days;

namespace aoc_cs
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("The submarine sonar is scanning the sea floor...");
            Console.WriteLine($"Number of depth increases = {Day1.Part1()}");
            Console.WriteLine("Hmm, let's do this more accurately and use a rolling average.");
            Console.WriteLine($"Now the number of depth increases = {Day1.Part2()}");

            Console.WriteLine("\nLet's get this thing moving");
            Console.WriteLine($"If we follow the planned course we should be at = {Day2.Part(isPartTwo: false)}");
            Console.WriteLine("That can't be right!");
            Console.WriteLine($"If we consider up and down to effect our aim we're at = {Day2.Part(isPartTwo: true)}");

            Console.WriteLine("\nThe submarine is making odd creaking noises; run a diagnostic report...");
            Console.WriteLine($"Power consumption = {Day3.Part1()}");
            Console.WriteLine($"Life support rating = {Day3.Part2()}");

            Console.WriteLine("\nThe elves slept through days 4 and 5...");

            Console.WriteLine($"\nWe're suddenly surrounded by 80 days worth of lanternfish: {Day6.Part1()}");
            Console.WriteLine($"After 256 days there would be {Day6.Part2()} lanternfish!");

            Console.WriteLine($"\nOptimal crab fuel usage for linear fuel consumption = {Day7.Part1()}");
            Console.WriteLine($"Optimal crab fuel usage for triangular fuel consumption =  = {Day7.Part2()}");

            Console.WriteLine($"\nNumber of digits that appear that use a unique number of segments = {Day8.Part1()}");
            Console.WriteLine($"Total of all 4-digit output values = {Day8.Part2()}");

            Console.WriteLine($"\nSum of risk levels of lowest points = {Day9.Part1()}");
            Console.WriteLine($"Size of the largest three basins multiplied together = {Day9.Part2()}");

            Console.WriteLine($"\nDay10, part1 = {Day10.Part(1)}");
            Console.WriteLine($"Day10, part2 = {Day10.Part(2)}");

            Console.WriteLine($"\nDay11, part1 = {Day11.Part(1)}");
            Console.WriteLine($"Day11, part2 = {Day11.Part(2)}");

            Console.WriteLine($"\nDay12, part1 = {Day12.Part(1)}");
            Console.WriteLine($"Day12, part2 = {Day12.Part(2)}");
        }
    }
}
