using System;
using System.Collections.Generic;

namespace Days
{
    class Day11
    {
        static string inputPath = @"C:\git\aoc2021\day11_input.txt";
        public static int Part(int part) {
            int [,] octopusEnegyLevels = Day9.generate2dArray(inputPath);
            int totalFlashes = 0;
            bool synchronised = false;
            int step = 0;
            while (!synchronised) {
                step++;
                Queue<int[]> flashingOctopi = addOneTo2dArray(octopusEnegyLevels);
                if (flashingOctopi.Count > 0) {
                    totalFlashes += adjacentFlash(flashingOctopi, octopusEnegyLevels, flashingOctopi.Count);
                    resetEnergies(octopusEnegyLevels);
                }
                synchronised = isSync(octopusEnegyLevels);
                if (part == 1 && step == 100) {
                    return totalFlashes;
                }
            }
            return step;
        }

        static bool isSync(int[,] array) {
            for (int i = 0; i < array.GetLength(0); i++) {
                for (int j = 0; j < array.GetLength(1); j++) {
                    if (array[i,j] != 0) {
                        return false;
                    }
                }
            }
            return true;
        }

        static Queue<int[]> addOneTo2dArray(int[,] array) {
            Queue<int[]> flashingOctopi = new Queue<int[]>();
            for (int i = 0; i < array.GetLength(0); i++) {
                for (int j = 0; j < array.GetLength(1); j++) {
                    array[i, j]++;
                    if (array[i, j] == 10) {
                        int[] coords = {i, j};
                        flashingOctopi.Enqueue(coords);
                    }
                }
            }
            return flashingOctopi;
        }

        static void resetEnergies(int[,] array) {
            for (int i = 0; i < array.GetLength(0); i++) {
                for (int j = 0; j < array.GetLength(1); j++) {
                    if (array[i, j] == 10) {
                        array[i, j] = 0;
                    }
                }
            }
        }

        static int adjacentFlash(Queue<int[]> flashingOctopi, int[,] energyLevels, int totalFlashes) {
            int[] currentOctopus = flashingOctopi.Dequeue();
            int rowNum = currentOctopus[0];
            int colNum = currentOctopus[1];
            for (int i = rowNum - 1; i <= rowNum + 1; i++) {
                for (int j = colNum - 1; j <= colNum + 1; j++) {
                    int affectedOctopusEnergy;
                    try {
                        affectedOctopusEnergy = energyLevels[i, j];
                    } catch (System.IndexOutOfRangeException) {
                        continue;
                    }
                    if (affectedOctopusEnergy == 10 || (i == rowNum && j == colNum)) {
                        continue;
                    }
                    energyLevels[i, j]++;
                    if (energyLevels[i, j] == 10) {
                        int[] coords = {i, j};
                        totalFlashes++;
                        flashingOctopi.Enqueue(coords);
                    } 
                }
            }
            if (flashingOctopi.Count > 0) {
                return adjacentFlash(flashingOctopi, energyLevels, totalFlashes);
            }
            return totalFlashes;
        }

        static void print2dArray(int[,] array) {
            for (int i = 0; i < array.GetLength(0); i++) {
                for (int j = 0; j < array.GetLength(1); j++) {
                    Console.Write($"{array[i, j]},");
                }
                Console.Write("\n");
            }
        }
    }
}
