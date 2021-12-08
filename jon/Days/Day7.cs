using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Days
{
    class Day7
    {
        static string inputPath = @"C:\git\aoc2021\day7_input.txt";
        static string[] lines = File.ReadAllLines(inputPath);
        static IEnumerable<int> crabPositions = lines[0].Split(",").Select(int.Parse);
        public static double Part1() {
            double median = calculateMedian(crabPositions);
            return calculateTotalDistanceFrom(median, crabPositions, "linear");
        }

        public static double Part2() {
            double mean = calculateMean(crabPositions);
            return calculateTotalDistanceFrom(mean, crabPositions, "triangular");
        }

        static double calculateTotalDistanceFrom(double value, IEnumerable<int> numbers, string method) {
            double optimalDistance = 0;
            foreach (int number in numbers) {
                double distanceFromValue = Math.Abs(number - value);
                if (method == "triangular") {
                    double triangular = (distanceFromValue * (distanceFromValue + 1)) / 2;
                    optimalDistance += triangular;
                } else {
                    optimalDistance += distanceFromValue;
                }
            }
            return optimalDistance;
        }

        static double calculateMedian(IEnumerable<int> numbers) {
            int halfIndex = numbers.Count() / 2;
            var sortedNumbers = numbers.OrderBy(n=>n);
            if ((numbers.Count() % 2) == 0) {
                return (sortedNumbers.ElementAt(halfIndex) + sortedNumbers.ElementAt(halfIndex - 1)) / 2;
            }
            return sortedNumbers.ElementAt(halfIndex);
        }

        static double calculateMean(IEnumerable<int> numbers) {
            double mean = Convert.ToDouble(numbers.Sum()) / numbers.Count();
            return Math.Floor(mean);
        }
    }
}