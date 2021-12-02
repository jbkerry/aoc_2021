using System;
using System.Collections.Generic;
using System.IO;

namespace Days
{
    class Day2
    {
        static string inputPath = @"C:\git\aoc2021\day2_input.txt";
        static string[] lines = File.ReadAllLines(inputPath); 
        public static int Part(bool isPartTwo) {
            var values = new Dictionary<string, int>() {
                {"horizontal", 0},
                {"vertical", 0},
                {"aim", 0},
            };
            foreach (var line in lines) {
                string[] lineParts = line.Split(" ");
                string action = lineParts[0];
                int amount = Convert.ToInt32(lineParts[1].Trim());
                if (action == "forward") {
                    values["horizontal"] += amount;
                    if (isPartTwo) {
                        values["vertical"] += (values["aim"] * amount);
                    }
                } else {
                    string valueToIncrease = isPartTwo ? "aim" : "vertical";
                    values[valueToIncrease] += action == "up" ? -amount : amount;
                }
            }
            return values["horizontal"] * values["vertical"];
        }
    }
}