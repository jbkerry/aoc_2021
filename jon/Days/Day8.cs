using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Days
{
    class Day8
    {
        static string inputPath = @"C:\git\aoc2021\day8_input.txt";
        static string[] lines = File.ReadAllLines(inputPath);
        static int[] uniqueSegmentNumbers = new int[4] {2, 3, 4, 7};
        public static int Part1() {
            int totalUnique = 0;
            foreach (string line in lines) {
                string[] parts = line.Split("|");
                string display = parts[1].Trim();
                totalUnique += display.Split(" ").Where(x => uniqueSegmentNumbers.Contains(x.Length)).Count();
            }
            return totalUnique;
        }

        public static int Part2() {
            int total = 0;
            foreach (string line in lines) {
                string[] parts = line.Split("|");
                string display = parts[1].Trim();
                string[] allDigits = parts[0].Trim().Split(" ").ToArray();
                Dictionary<string, string> digitMapping = createDigitMap(allDigits);
                string finalDigit = "";
                foreach (string digit in display.Split(" ")) {
                    finalDigit += digitMapping[String.Concat(digit.OrderBy(c => c))];
                }
                total += Convert.ToInt32(finalDigit);
            }
            return total;
        }

        static Dictionary<string, string> createDigitMap(string[] digits) {
            Dictionary<string, string> digitMapping = new Dictionary<string, string>();
            Array.Sort(digits, (x, y) => x.Length.CompareTo(y.Length));

            string rightHandSide = digits[0];
            string top = string.Join("", digits[1].Except(rightHandSide));
            string middleTopLeft = string.Join("", digits[2].Except(rightHandSide));
            string bottomLeft = string.Join("", digits[digits.Length - 1].Except(digits[2] + top));
            string[] keyPositions = new string[3] {bottomLeft, rightHandSide, middleTopLeft};

            foreach (int idx in Enumerable.Range(0, 10)) {
                string mappingKey = String.Concat(digits[idx].OrderBy(c => c));
                bool isFiveSegments = idx >= 3 && idx <= 5;
                string mappingValue = idx switch {
                    0 => "1",
                    1 => "7",
                    2 => "4",
                    9 => "8",
                    _ => whichNumber(mappingKey, isFiveSegments ? 5 : 6, keyPositions)
                };
                digitMapping.Add(mappingKey, mappingValue);
            }

            return digitMapping;
        }

        static string whichNumber(string digit, int segments, string[] knownPositions) {
            int lengthCheck = segments == 5 ? 3 : 5;
            if (digit.Except(knownPositions[0]).ToArray().Length == lengthCheck) {
                return segments == 5 ? "2" : "9";
            }
            if (digit.Except(knownPositions[1]).ToArray().Length == lengthCheck) {
                return segments == 5 ? "3" : "6";
            }
            if (digit.Except(knownPositions[2]).ToArray().Length == lengthCheck) {
                return segments == 5 ? "5" : "0";
            }
            throw new Exception("No idea which digit this is!");
        }
    }
}