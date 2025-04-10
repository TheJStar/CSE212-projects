using System.Diagnostics;

public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        // TODO Start Problem 1

        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else if (value == Data) {
            return;
        }
        else
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    public bool Contains(int value)
    {
        // TODO Start Problem 2
        bool found = false;
        Debug.WriteLine("Current: " + Data);
        if (value == Data) {
            found = true;
        }
        else if (value < Data)
        {
            if (Left is null)
                return false;
            else
                Debug.WriteLine("Left: " + Left.Data);
                return Left.Contains(value);
        } 
        else
        {
            if (Right is null)
                return false;
            else
                Debug.WriteLine("Right: " + Right.Data);
                return Right.Contains(value);
        }
        Debug.WriteLine(found + ": " + Data);
        return found;
    }

    public int GetHeight()
    {
        // TODO Start Problem 4
        if (Left is null && Right is null) 
        {
            return 1; // 1 is for the current node
        }
        else if (Left is not null && Right is null) 
        {
            return 1 + Left.GetHeight();
        }
        else if (Left is null && Right is not null) 
        {
            return 1 + Right.GetHeight();
        }
        else {
            int leftHeight = Left.GetHeight();
            int rightHeight =  Right.GetHeight();
            if (leftHeight > rightHeight) {
                return 1 + leftHeight;
            } else {
                return 1 + rightHeight;
            }
        }
    }
}