using System;

using Days;

namespace aoc_cs
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Day1, part1 = {Day1.Part1()}");
            Console.WriteLine($"Day1, part2 = {Day1.Part2()}");
            Console.WriteLine($"Day2, part1 = {Day2.Part(isPartTwo: false)}");
            Console.WriteLine($"Day2, part2 = {Day2.Part(isPartTwo: true)}");
        }
    }
}
