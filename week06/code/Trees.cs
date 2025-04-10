using System.Diagnostics;

public static class Trees
{
    /// <summary>
    /// Given a sorted list (sorted_list), create a balanced BST.  If the values in the
    /// sortedNumbers were inserted in order from left to right into the BST, then it
    /// would resemble a linked list (unbalanced). To get a balanced BST, the
    /// InsertMiddle function is called to find the middle item in the list to add
    /// first to the BST. The InsertMiddle function takes the whole list but also takes
    /// a range (first to last) to consider.  For the first call, the full range of 0 to
    /// Length-1 used.
    /// </summary>
    public static BinarySearchTree CreateTreeFromSortedList(int[] sortedNumbers)
    {
        var bst = new BinarySearchTree(); // Create an empty BST to start with 
        InsertMiddle(sortedNumbers, 0, sortedNumbers.Length - 1, bst);
        return bst;
    }

    /// <summary>
    /// This function will attempt to insert the item in the middle of 'sortedNumbers' into
    /// the 'bst' tree. The middle is determined by using indices represented by 'first' and
    /// 'last'.
    /// For example, if the function was called on:
    ///
    /// sortedNumbers = new[]{10, 20, 30, 40, 50, 60};
    /// first = 0;
    /// last = 5;
    /// 
    /// then the value 30 (index 2 which is the middle) would be added 
    /// to the 'bst' (the insert function in the <see cref="BinarySearchTree"/> can be used
    /// to do this).   
    ///
    /// Subsequent recursive calls are made to insert the middle from the values 
    /// before 30 and the values after 30.  If done correctly, the order
    /// in which values are added (which results in a balanced bst) will be:
    /// 
    /// 30, 10, 20, 50, 40, 60
    /// 
    /// This function is intended to be called the first time by CreateTreeFromSortedList.
    ///
    /// The purpose for having the first and last parameters is so that we do 
    /// not need to create new sub-lists when we make recursive calls.  Avoid 
    /// using list slicing to create sub-lists to solve this problem.    
    /// </summary>
    /// <param name="sortedNumbers">input numbers that are already sorted</param>
    /// <param name="first">the first index in the sortedNumbers to insert</param>
    /// <param name="last">the last index in the sortedNumbers to insert</param>
    /// <param name="bst">the BinarySearchTree in which to insert the values</param>
    private static void InsertMiddle(int[] sortedNumbers, int first, int last, BinarySearchTree bst)
    {
        // TODO Start Problem 5 
        //  0   1   2   3   4   5
        // [10, 20, 30, 40, 50, 60]
        // first, middle-1 & middle+1, last
        // 0 5 => 2 : 0 - 1, 3 - 5: 30 () :height 1
        //  0 1 => Non : add both 0 and 1: 30 ((< > 20) 10 < >) :height 3
        //  3 5 => 4 : 3 - 3, 5 - 5: 30 ((< > 20) 10 < > 50) :height 3
        //      3 3: Non: add at first: 30 ((< > 20) 10 < > 50 (40 < >)) :height 3
        //      5 5: Non: add at first: 30 ((< > 20) 10 < > 50 (40 < > 60)) :height 3

        // not good
        // first, middle & middle, last
        // 0 5 => 2 : 0 - 2, 2 - 5: 30 () :height 1
        //  0 2 => 1 : 0 - 1, 1 - 2: 30 (20 < >) :height 2
        // no dups so no worry
        //      0 1: Non: add both at fist and last: 30 ((10 < >) 20 < >) :height 3
        //      1 2: Non: add both at fist and last: 30 ((10 < >) 20 < >) :height 3
        //  2 5 => 3 : 2 - 3, 3 - 5: 30 ((10 < >) 20 < > 40) :height 3
        //      2 3: Non: add both at fist and last: 30 ((10 < >) 20 < > 40) :height 3
        //      3 5: 4: 3 - 4, 4 - 5: 30 ((10 < >) 20 < > 40 (< > 50)) :height 3
        //          3 4: Non: add both at fist and last: 30 ((10 < >) 20 < > 40 (< > 50)) :height 3
        //          4 5: Non: add both at fist and last: 30 ((10 < >) 20 < > 40 (< > 50 (< > 60))) :height 4
        if (last - first > 1) {
            int middle = (first + last) / 2;
            Debug.WriteLine(middle);
            bst.Insert(sortedNumbers[middle]);
            InsertMiddle(sortedNumbers, first, middle-1, bst);
            InsertMiddle(sortedNumbers, middle+1, last, bst);
        } else {
            for (int i = first; i <= last; i++) {
                Debug.WriteLine(" "+i);
                bst.Insert(sortedNumbers[i]);
            }
        }
    }
}