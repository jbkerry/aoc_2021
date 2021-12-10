using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Days
{
    class Day10
    {
        static Dictionary<int, int> syntaxErrorScores = new Dictionary<int, int>() {
            {41, 3},
            {62, 25137},
            {93, 57},
            {125, 1197}
        };
        static Dictionary<int, int> autocompleteScores = new Dictionary<int, int>() {
            {40, 1},
            {60, 4},
            {91, 2},
            {123, 3},
        };
        static string inputPath = @"C:\git\aoc2021\day10_input.txt";
        static string[] lines = File.ReadAllLines(inputPath);
        public static Int64 Part(int part) {
            int totalSyntaxError = 0;
            List<Int64> autoCompleteScoresOfIncompleteLines = new List<Int64>();
            foreach (string line in lines) {
                bool isCorrupted = false;
                Stack<int> currentStack = new Stack<int>();
                int[] asciiCodesOfBrackets = Array.ConvertAll(line.ToCharArray(), s => Convert.ToInt32(s));
                foreach (int asciiCode in asciiCodesOfBrackets) {
                    if (autocompleteScores.Keys.Contains(asciiCode)) {
                        // this is an opening bracket, add it to the top of the stack
                        currentStack.Push(asciiCode);
                    } else {
                        // this is a reverse bracket, remove the top of the stack and check if they are a bracket pair
                        int topOfStack = currentStack.Pop();
                        if (!(asciiCode == topOfStack + 1 || asciiCode == topOfStack + 2)) {
                            totalSyntaxError += syntaxErrorScores[asciiCode];
                            isCorrupted = true;
                            break;
                        }
                    }
                }
                if (!isCorrupted) {
                    Int64 score = 0;
                    foreach (int character in currentStack) {
                        score = score * 5 + autocompleteScores[character];
                    }
                    autoCompleteScoresOfIncompleteLines.Add(score);
                }
            }

            if (part == 1) {
                return totalSyntaxError;
            } else {
                return Convert.ToInt64(Day7.calculateMedian(autoCompleteScoresOfIncompleteLines));
            }
        }
    }
}