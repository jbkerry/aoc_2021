using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Days
{
    class Day12
    {
        static Dictionary<string, List<string>> connections = createConnections();
        public static int Part(int part) {   
            Queue<List<string>> paths = new Queue<List<string>>();
            List<string> startPostision = new List<string>() {"start"};
            paths.Enqueue(startPostision);
            int totalCompletePaths = 0;
            Func<string, List<string>, bool> smallCaveSkipCondition = part == 1 ? alreadyVisited : alreadyVisitedASmallCaveTwiceAndThisOne;
            while (paths.Count > 0) {
                totalCompletePaths += explorePaths(paths, connections, smallCaveSkipCondition);
            }
            return totalCompletePaths;
        }

        static int explorePaths(
            Queue<List<string>> paths,
            Dictionary<string, List<string>> connections,
            Func<string, List<string>, bool> smallCaveSkipCondition
        ) {
            int completePaths = 0;
            List<string> currentPath = paths.Dequeue();
            string currentCave = currentPath[currentPath.Count - 1];

            foreach (string connectedCave in connections[currentCave]) {
                if (connectedCave == "start" || connectedCave.All(Char.IsLower) && smallCaveSkipCondition(connectedCave, currentPath)) continue;
                if (connectedCave == "end") {
                    completePaths++;
                    continue;
                }
                List<string> extendedPath = new List<string>(currentPath);
                extendedPath.Add(connectedCave);
                paths.Enqueue(extendedPath);
            }
            return completePaths;
        }

        static bool alreadyVisitedASmallCaveTwiceAndThisOne(string cave, List<string> path) {
            List<string> smallCaves = path.FindAll(s => s.All(Char.IsLower));
            HashSet<string> uniqueCaves = smallCaves.ToHashSet();
            if (uniqueCaves.Count != smallCaves.Count && path.Contains(cave)) {
                return true;
            }
            return false;
        }

        static bool alreadyVisited(string cave, List<string> path) {
            if (cave.All(Char.IsLower) && path.Contains(cave)) {
                return true;
            }
            return false;
        }

        static Dictionary<string, List<string>> createConnections() {
            string inputPath = @"C:\git\aoc2021\day12_input.txt";
            string[] lines = File.ReadAllLines(inputPath);
            Dictionary<string, List<string>> connections = new Dictionary<string, List<string>>();
            foreach (string line in lines) {
                string[] caves = line.Split("-").ToArray();
                if (connections.ContainsKey(caves[0])) {
                    connections[caves[0]].Add(caves[1]);
                } else {
                    connections[caves[0]] = new List<string>() {caves[1]};
                }

                if (connections.ContainsKey(caves[1])) {
                    connections[caves[1]].Add(caves[0]);
                } else {
                    connections[caves[1]] = new List<string>() {caves[0]};
                }
            }

            return connections;
        }
    }
}