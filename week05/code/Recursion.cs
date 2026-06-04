using System;
using System.Collections;
using System.Collections.Generic;

public static class Recursion
{
    /// <summary>
    /// #############
    /// # Problem 1 #
    /// #############
    /// Using recursion, find the sum of 1^2 + 2^2 + 3^2 + ... + n^2
    /// and return it.  Remember to both express the solution 
    /// in terms of recursive call on a smaller problem and 
    /// to identify a base case (terminating case).  If the value of
    /// n <= 0, just return 0.   A loop should not be used.
    /// </summary>
    public static int SumSquaresRecursive(int n)
    {
        // Base Case: when n is 0 or negative, return 0
        if (n <= 0)
        {
            return 0;
        }

        // Problem Reduction: express the solution in terms of a smaller problem
        return (n * n) + SumSquaresRecursive(n - 1);
    }

    /// <summary>
    /// #############
    /// # Problem 2 #
    /// #############
    /// Using recursion, insert permutations of length
    /// 'size' from a list of 'letters' into the results list.  This function
    /// should assume that each letter is unique (i.e. the 
    /// function does not need to find unique permutations).
    ///
    /// In mathematics, we can calculate the number of permutations
    /// using the formula: len(letters)! / (len(letters) - size)!
    /// </summary>
    public static void PermutationsChoose(List<string> results, string letters, int size, string word = "")
    {
        // Base Case: when the word reaches the desired length (size)
        if (word.Length == size)
        {
            results.Add(word);
            return;
        }

        // Goes through each letter in the input string 'letters'
        for (int i = 0; i < letters.Length; i++)
        {
            // Remove the current letter from the string to create a new string for the recursive call
            string lettersLeft = letters.Remove(i, 1);

            // Calls the function recursively with the new string of letters and the current word appended with the chosen letter
            PermutationsChoose(results, lettersLeft, size, word + letters[i]);
        }
    }

    /// <summary>
    /// #############
    /// # Problem 3 #
    /// #############
    /// Count ways to climb stairs using Memoization
    /// </summary>
    public static decimal CountWaysToClimb(int s, Dictionary<int, decimal>? remember = null)
    {
        // Initializes the memoization dictionary on the first call
        if (remember == null)
        {
            remember = new Dictionary<int, decimal>();
        }

        // Base Cases: There are 0 ways to climb negative stairs, 1 way to climb 0 stairs (do nothing), 1 way to climb 1 stair, 2 ways to climb 2 stairs, and 4 ways to climb 3 stairs
        if (s == 0) return 0;
        if (s == 1) return 1;
        if (s == 2) return 2;
        if (s == 3) return 4;

        // If the result for 's' is already computed and stored in the 'remember' dictionary, return it to avoid redundant calculations
        if (remember.ContainsKey(s))
        {
            return remember[s];
        }

        // Solve the problem recursively by summing the ways to climb (s-1), (s-2), and (s-3) stairs, which represents the possible steps one can take at a time (1, 2, or 3 stairs)
        decimal ways = CountWaysToClimb(s - 1, remember) + 
                       CountWaysToClimb(s - 2, remember) + 
                       CountWaysToClimb(s - 3, remember);

        // Stores the computed result in the 'remember' dictionary before returning it, so that future calls with the same 's' can retrieve the result directly from the dictionary
        remember[s] = ways;
        return ways;
    }

    /// <summary>
    /// #############
    /// # Problem 4 #
    /// #############
    /// Wildcard Binary Patterns
    /// </summary>
    public static void WildcardBinary(string pattern, List<string> results)
    {
        // Finds the index of the first occurrence of the wildcard character '*' in the input pattern string. If there is no '*', it returns -1.
        int wildcardIndex = pattern.IndexOf('*');

        // Base Case: If there are no more wildcards in the pattern, add the fully resolved pattern to the results list and return
        if (wildcardIndex == -1)
        {
            results.Add(pattern);
            return;
        }

        // Isolates the part of the pattern before and after the wildcard character to create two new patterns for the recursive calls, one with '0' replacing the wildcard and another with '1' replacing the wildcard
        string before = pattern[..wildcardIndex];
        string after = pattern[(wildcardIndex + 1)..];

        // Explores both possibilities for the wildcard character by making two recursive calls: one with '0' replacing the wildcard and another with '1' replacing the wildcard, effectively generating all combinations of binary strings that can be formed by replacing the wildcards in the original pattern
        WildcardBinary(before + "0" + after, results);
        WildcardBinary(before + "1" + after, results);
    }

    /// <summary>
    /// #############
    /// # Problem 5 #
    /// #############
    /// Maze Solver using Recursion and Backtracking
    /// </summary>
    public static void SolveMaze(List<string> results, Maze maze, int x = 0, int y = 0, List<ValueTuple<int, int>>? currPath = null)
    {
        // Initializes the current path list on the first call to keep track of the positions visited in the current path through the maze
        if (currPath == null) 
        {
            currPath = new List<ValueTuple<int, int>>();
        }

        // 1. Validation: Check if the current position (x, y) is a valid move in the maze using the 'IsValidMove' function. If it's not valid, return immediately to backtrack and explore other paths
        if (!maze.IsValidMove(currPath, x, y))
        {
            return;
        }

        // 2. Register the current position (x, y) in the current path list to keep track of the path being explored. This is important for the 'IsValidMove' function to prevent cycles and ensure that the same position is not visited multiple times in the same path
        currPath.Add((x, y));

        // 3. Base Case: Check if the current position (x, y) is the end of the maze using the 'IsEnd' function. If it is, add the current path as a string to the results list and return to backtrack and explore other paths
        if (maze.IsEnd(x, y))
        {
            results.Add(currPath.AsString());
        }
        else
        {
            // 4. Keep Exploring: If the current position is not the end, continue exploring in all four possible directions (right, left, down, up) by making recursive calls to 'SolveMaze' with the updated coordinates for each direction. This allows the function to explore all possible paths through the maze from the current position
            SolveMaze(results, maze, x + 1, y, currPath); // Right
            SolveMaze(results, maze, x - 1, y, currPath); // Left
            SolveMaze(results, maze, x, y + 1, currPath); // Down
            SolveMaze(results, maze, x, y - 1, currPath); // Up
        }

        // 5. Backtracking: Removes the current position (x, y) from the current path list before returning to allow the function to backtrack and explore other paths without including the current position in those paths. This is essential for correctly exploring all possible paths through the maze without getting stuck in cycles or including invalid paths
        currPath.RemoveAt(currPath.Count - 1);
    }
}