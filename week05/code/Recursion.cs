using System.Collections;
using System.Diagnostics;
using System.Text.RegularExpressions;

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
        // TODO Start Problem 1
        if (n <= 0) {
            return 0;
        }
        // n = 0 =0
        // n * n + (n -1) ^ 2
        var res = (n*n) + SumSquaresRecursive(n-1);
        Console.WriteLine(res);
        return res;
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
    ///
    /// For example, if letters was [A,B,C] and size was 2 then
    /// the following would the contents of the results array after the function ran: AB, AC, BA, BC, CA, CB (might be in 
    /// a different order).
    ///
    /// You can assume that the size specified is always valid (between 1 
    /// and the length of the letters list).
    /// </summary>
    public static void PermutationsChoose(List<string> results, string letters, int size, string word = "")
    {
        // TODO Start Problem 2
        if (word.Length == size) {
            results.Add(word);
        } else {
            foreach (char letter in letters) {
                string newLetters = letters.Split(letter)[0] + letters.Split(letter)[1];
                PermutationsChoose(results, newLetters, size, word+letter);
            }
        }
    }

    /// <summary>
    /// #############
    /// # Problem 3 #
    /// #############
    /// Imagine that there was a staircase with 's' stairs.  
    /// We want to count how many ways there are to climb 
    /// the stairs.  If the person could only climb one 
    /// stair at a time, then the total would be just one.  
    /// However, if the person could choose to climb either 
    /// one, two, or three stairs at a time (in any order), 
    /// then the total possibilities become much more 
    /// complicated.  If there were just three stairs,
    /// the possible ways to climb would be four as follows:
    ///
    ///     1 step, 1 step, 1 step
    ///     1 step, 2 step
    ///     2 step, 1 step
    ///     3 step
    ///
    /// With just one step to go, the ways to get
    /// to the top of 's' stairs is to either:
    ///
    /// - take a single step from the second to last step, 
    /// - take a double step from the third to last step, 
    /// - take a triple step from the fourth to last step
    ///
    /// We don't need to think about scenarios like taking two 
    /// single steps from the third to last step because this
    /// is already part of the first scenario (taking a single
    /// step from the second to last step).
    ///
    /// These final leaps give us a sum:
    ///
    /// CountWaysToClimb(s) = CountWaysToClimb(s-1) + 
    ///                       CountWaysToClimb(s-2) +
    ///                       CountWaysToClimb(s-3)
    ///
    /// To run this function for larger values of 's', you will need
    /// to update this function to use memoization.  The parameter
    /// 'remember' has already been added as an input parameter to 
    /// the function for you to complete this task.
    /// </summary>
    public static decimal CountWaysToClimb(int s, Dictionary<int, decimal>? remember = null)
    {
        if (remember == null) {
            remember = new Dictionary<int,decimal>();
        }
        // Base Cases
        if (s == 0)
            return 0;
        if (s == 1)
            return 1;
        if (s == 2)
            return 2;
        if (s == 3)
            return 4;

        // TODO Start Problem 3
        if (remember.ContainsKey(s)) {
            return remember[s];
        }
        // Solve using recursion
        decimal ways = CountWaysToClimb(s - 1, remember) + CountWaysToClimb(s - 2, remember) + CountWaysToClimb(s - 3, remember);
        remember[s] = ways;
        return ways;
    }

    /// <summary>
    /// #############
    /// # Problem 4 #
    /// #############
    /// A binary string is a string consisting of just 1's and 0's.  For example, 1010111 is 
    /// a binary string.  If we introduce a wildcard symbol * into the string, we can say that 
    /// this is now a pattern for multiple binary strings.  For example, 101*1 could be used 
    /// to represent 10101 and 10111.  A pattern can have more than one * wildcard.  For example, 
    /// 1**1 would result in 4 different binary strings: 1001, 1011, 1101, and 1111.
    ///	
    /// Using recursion, insert all possible binary strings for a given pattern into the results list.  You might find 
    /// some of the string functions like IndexOf and [..X] / [X..] to be useful in solving this problem.
    /// </summary>
    public static void WildcardBinary(string pattern, List<string> results)
    {
        // TODO Start Problem 4
        if ((pattern.Length == 0 || !pattern.Contains("*")) && !results.Contains(pattern)) {
            results.Add(pattern);
        }
        foreach (char letter in pattern.ToCharArray()) {
            if (letter == '*') {
                string newPattern  = pattern.Split(letter, 2)[0] + "0" + pattern.Split(letter, 2)[1];
                string newPattern2  = pattern.Split(letter, 2)[0] + "1" + pattern.Split(letter, 2)[1];
                WildcardBinary(newPattern, results);
                WildcardBinary(newPattern2, results);
            }
        }
    }

    /// <summary>
    /// Use recursion to insert all paths that start at (0,0) and end at the
    /// 'end' square into the results list.
    /// </summary>
    public static void SolveMaze(List<string> results, Maze maze, List<ValueTuple<int, int>>? deadends = null, int x = 0, int y = 0, List<ValueTuple<int, int>>? currPath = null)
    {
        // if you want to keep track of paths
        // string branchName = "path:",

        // If this is the first time running the function, then we need
        // to initialize the currPath list.
        if (currPath == null) {
            currPath = new List<ValueTuple<int, int>>();
        }
        if (deadends == null) {
            deadends = new List<ValueTuple<int, int>>();
        }
        // currPath.Add((1,2)); // Use this syntax to add to the current path

        // TODO Start Problem 5
        // ADD CODE HERE
        if (!currPath.Contains((x, y))) {
            currPath.Add((x, y));
        }
        // Base cases
        // 1) if not the end go through other paths
        if (!maze.IsEnd(x, y)) {
            Debug.WriteLine(" : " + currPath.AsString());
            
            if (maze.IsValidMove(currPath, x-1, y) && !deadends.Contains((x-1, y))) {
                SolveMaze(results, maze, deadends, x-1, y, currPath); // branchName+"<",
                // Debug.WriteLine("moved left");
            }
            else if (maze.IsValidMove(currPath, x, y+1) && !deadends.Contains((x, y+1))) {
                SolveMaze(results, maze, deadends, x, y+1, currPath); // branchName+"v",
                // Debug.WriteLine("moved down");
            }
            else if (maze.IsValidMove(currPath, x+1, y) && !deadends.Contains((x+1, y))) {
                SolveMaze(results, maze, deadends, x+1, y, currPath); //branchName+">",
                // Debug.WriteLine("moved right");
            }
            else if (maze.IsValidMove(currPath, x, y-1) && !deadends.Contains((x, y-1))) {
                SolveMaze(results, maze, deadends, x, y-1, currPath); // branchName+"^",
                // Debug.WriteLine("moved up");
            }
            else {
                Debug.WriteLine(" : " + currPath.AsString() + " : Deadend");
                Debug.WriteLine("Dead coords : "+deadends.AsString());
                if (currPath.Count == 1) {
                    // base case
                    // 4) if there are no other squares to move to that is not a dead end or a wall at the start finish
                    return;
                }
                deadends.Add((x, y));
                currPath.Remove((x, y));
                SolveMaze(results, maze, deadends, currPath[currPath.Count-1].Item1, currPath[currPath.Count-1].Item2, currPath); // [was throwing error if the currpath was empty]=>branchName.Substring(0, branchName.Length-2),
            }
            
        }
        // 2) if the end and not a recorded path add it and start over
        else if (!results.Contains(currPath.AsString()) && maze.IsEnd(x, y)) {
            Debug.WriteLine(" : " + currPath.AsString() + " : Finished");
            results.Add(currPath.AsString());
            Debug.WriteLine("Dead coords :+: "+deadends.AsString());
            SolveMaze(results, maze); // branchName+" -new: "
        }
        // 3) if ended and it's a recorded path add to deadends to not return again through the same path
        else {
            currPath.Remove((x, y));
            deadends.Add((currPath[currPath.Count-1].Item1, currPath[currPath.Count-1].Item2));
            Debug.WriteLine(" ::: " + currPath.AsString() + " : Finished Before");
            Debug.WriteLine("Dead coords :-: "+deadends.AsString());
            currPath.Remove((currPath[currPath.Count-1].Item1, currPath[currPath.Count-1].Item2));
            SolveMaze(results, maze, deadends, currPath[currPath.Count-1].Item1, currPath[currPath.Count-1].Item2, currPath); // branchName+"^",
            return;
        }

        // print out the results
        // foreach (string path in results) {
        //     Debug.WriteLine(results.Count+"-"+path);
        // }

        return;
        // results.Add(currPath.AsString()); // Use this to add your path to the results array keeping track of complete maze solutions when you find the solution.
    }
}