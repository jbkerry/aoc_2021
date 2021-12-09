using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Days
{
    class Day9
    {
        
        static int[,] caveHeights = generate2dArray();
        static List<int[]> lowPoints = findLowPoints(caveHeights);

        public static int Part1() {
            int totalRiskLevel = 0;
            foreach (int[] lowPoint in lowPoints) {
                totalRiskLevel += caveHeights[lowPoint[0], lowPoint[1]] + 1;
            }
            return totalRiskLevel;
        }

        public static int Part2() {
            List<int> basinSizes = new List<int>();
            foreach (int[] lowPoint in lowPoints) {
                int basinSize = 0;
                List<int[]> positionsToCheck = new List<int[]>() {lowPoint};
                List<int[]> checkedPositions = new List<int[]>() {lowPoint};

                bool basinStillRemaining = true;
                while (basinStillRemaining) {
                    List<int[]> nextPositions = new List<int[]>();
                    foreach (int[] position in positionsToCheck) {
                        basinSize++;
                        foreach (int[] neighbourPosition in generateNeighbouringPositions(position)) {
                            if (coordAlreadyInList(neighbourPosition, checkedPositions)) {
                                continue;
                            }
                            int neighbourHeight;
                            try {
                                neighbourHeight = caveHeights[neighbourPosition[0], neighbourPosition[1]];
                            } catch (System.IndexOutOfRangeException) {
                                continue;
                            }
                            
                            if (neighbourHeight > caveHeights[position[0], position[1]] && neighbourHeight != 9) {
                                nextPositions.Add(neighbourPosition);
                                checkedPositions.Add(neighbourPosition);
                            }
                        }
                    }
                    if (nextPositions.Count() == 0) {
                        basinStillRemaining = false;
                    } else {
                        positionsToCheck = nextPositions;
                    }
                }

                basinSizes.Add(basinSize); 
            }
            basinSizes.Sort((a, b) => b.CompareTo(a));
            return basinSizes.Take(3).Aggregate((a, x) => a * x);
        }

        static int[,] generate2dArray() {
            string inputPath = @"C:\git\aoc2021\day9_input.txt";
            string[] lines = File.ReadAllLines(inputPath);
            int[,] caveHeights = new int[lines.Count(),lines[0].Length];
            int rowIdx = 0;
            foreach (string line in lines) {
                foreach (int colIdx in Enumerable.Range(0, line.Length)) {
                    int value = Convert.ToInt32(line[colIdx].ToString());
                    caveHeights[rowIdx, colIdx] = Convert.ToInt32(line[colIdx].ToString());
                }
                rowIdx++;
            }
            return caveHeights;
        }

        static List<int[]> findLowPoints(int[,] caveHeights) {
            List<int[]> lowPoints = new List<int[]>();
            for (int i = 0; i < caveHeights.GetLength(0); i++) {
                for (int j = 0; j < caveHeights.GetLength(1); j++) {
                    int[] currentPosition = {i, j};
                    bool smallest = true;
                    foreach (int[] position in generateNeighbouringPositions(currentPosition)) {
                        try {
                            if (caveHeights[i, j] >= caveHeights[position[0], position[1]]) {
                                smallest = false;
                                break;
                            }
                        } catch (System.IndexOutOfRangeException) {
                            continue;
                        }
                    }
                    if (smallest) {
                        int[] lowPointCoord = {i, j};
                        lowPoints.Add(lowPointCoord);
                    }
                }
            }
            return lowPoints;
        }

        static int[][] generateNeighbouringPositions(int[] position) {
            int i = position[0];
            int j = position[1];
            int[] left = {i, j-1};
            int[] above = {i-1, j};
            int[] right = {i, j+1};
            int[] below = {i+1, j};
            int[][] neighbouringPositions = new int[][] {left, above, right, below};
            return neighbouringPositions;
        }

        static bool coordAlreadyInList(int[] coord, List<int[]> listToCheck) {
            bool alreadyChecked = false;
            foreach (int[] checkPos in listToCheck) {
                if (checkPos[0] == coord[0] && checkPos[1] == coord[1]) {
                    alreadyChecked = true;
                    break;
                }
            }
            return alreadyChecked;
        }

    }
}