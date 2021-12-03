using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Days
{
    class Day3
    {
        static string inputPath = @"C:\git\aoc2021\day3_input.txt";
        static string[] lines = File.ReadAllLines(inputPath);

        public static int Part1() {
            int[] counts = new int[12];
            int[] gamma = new int[12];
            int[] epsilon = new int[12];
            float halfValue = Convert.ToSingle(lines.Count()) / 2;

            foreach (var line in lines) {
                foreach (int idx in Enumerable.Range(0, 12)) {
                    counts[idx] += Convert.ToInt32(line[idx].ToString());
                }
            }

            foreach (int idx in Enumerable.Range(0, 12)) {
                bool moreOnesThanZeros = counts[idx] > halfValue;
                gamma[idx] = moreOnesThanZeros ? 1 : 0;
                epsilon[idx] = moreOnesThanZeros ? 0 : 1;
            }

            return convertBinToDec(gamma) * convertBinToDec(epsilon);
        }

        public static int Part2() {
            List<int[]> allBinaries = new List<int[]>(); 
            foreach (var line in lines) {
                char[] parts = line.ToCharArray();
                allBinaries.Add(Array.ConvertAll(parts, s => int.Parse(s.ToString())));
            }

            int[] oxygenGenBinary = recurseBinaries(allBinaries, 0, wantMostCommon: true);
            int[] co2ScrubBinary = recurseBinaries(allBinaries, 0, wantMostCommon: false);
            return convertBinToDec(oxygenGenBinary) * convertBinToDec(co2ScrubBinary);
        }

        static int convertBinToDec(int[] binaryArray) {
            return Convert.ToInt32(string.Join("", binaryArray), 2);
        }

        static int[] recurseBinaries(List<int[]> binaries, int positionToCheck, bool wantMostCommon) {
            int mostCommon = mostCommonAtPosition(binaries, positionToCheck);
            List<int[]> nextBinaries = new List<int[]>();
            foreach (int[] binary in binaries) {
                if (
                    (binary[positionToCheck] == mostCommon && wantMostCommon) || 
                    (binary[positionToCheck] != mostCommon && !wantMostCommon)
                ) {
                    nextBinaries.Add(binary);
                }
            }
            if (nextBinaries.Count == 1) {
                return nextBinaries[0];
            }
            return recurseBinaries(nextBinaries, positionToCheck + 1, wantMostCommon);
        }

        static int mostCommonAtPosition(List<int[]> binaries, int positionToCheck) {
            int total = 0;
            foreach (int[] binary in binaries) {
                total += binary[positionToCheck];
            }
            int mostCommon = (total >= (Convert.ToSingle(binaries.Count) / 2)) ? 1 : 0;
            return mostCommon;
        }
    }
}