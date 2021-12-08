using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Days
{
    class Day6
    {
        static string inputPath = @"C:\git\aoc2021\day6_input.txt";
        static string[] lines = File.ReadAllLines(inputPath);
        public static int Part1() {
            List<int> fishNumbers = lines[0].Split(",").Select(int.Parse).ToList();
            int dayNumber = 1;
            while (dayNumber <= 80) {
                for (int i = 0; i < fishNumbers.Count; i++) {
                    if (fishNumbers[i] == 0) {
                        fishNumbers[i] = 6;
                        fishNumbers.Add(9);
                    } else {
                        fishNumbers[i]--;
                    }
                }
                dayNumber++;
            }
            return fishNumbers.Count;
        }

        public static decimal Part2() {
            List<decimal> fishAtDays = new List<decimal> {0, 0, 0, 0, 0, 0, 0, 0, 0};
            IEnumerable<int> fishNumbers = lines[0].Split(",").Select(int.Parse);
            foreach (int dayIndex in fishNumbers) {
                fishAtDays[dayIndex] += 1;
            }
            foreach (int day in Enumerable.Range(1, 256)) {
                decimal day0 = fishAtDays[0];
                fishAtDays.RemoveAt(0);
                fishAtDays[6] += day0;
                fishAtDays.Add(day0);
            }
            return fishAtDays.Sum();
        }
    }
}