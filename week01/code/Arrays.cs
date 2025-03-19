public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // Solution by : Joel
        // 1) make an array that will be as the length parameter (so it will be specified by the user)
        // 2) make a loop that will run length (the parameter) times and for each i value do number * (i + 1) 
        // and add it to the next slot in the array
        // 3) return the array

        // step 1
        double[] results = new double[length];
        // step 2
        for (int i = 0; i < length; i++) {
            results[i] = number * ( i + 1 );
        }
        // step 3
        return results;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // Solution by: Joel
        // 1) start a for loop (run the loop as amount (the parameter) times long)
        // 2) get the last element (through index count-1) and move (insert at the start & remove from end) it to the start

        // step 1
        for (int i = 0; i < amount; i++) {
            // step 2
            data.Insert(0, data[data.Count - 1]);
            data.RemoveAt(data.Count - 1);
        }
    }
}
