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
        if (value != Data)
        {
            if (value < Data)
            {
                Debug.WriteLine(Data);
                // Insert to the left
                if (Left is null)
                    Left = new Node(value);
                else
                    Left.Insert(value);
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
    }

    public bool Contains(int value)
    {
        if (value != Data)
        {
            if (value < Data)
            {
                // Search to the left
                if (Left is null)
                    return false;
                else
                    return Left.Contains(value);
            }
            else
            {
                // Search to the right
                if (Right is null)
                    return false;
                else
                    return Right.Contains(value);
            }
        }
        return true;
    }

    public int GetHeight()
    {
        // TODO Start Problem 4
        int leftHeight = 0;
        int rightHeight = 0;
        
        if (Left == null && Right == null)
        {
            return 1;
        }

        if (Left != null)
        {
            leftHeight = Left.GetHeight();
        }

        if (Right != null)
        {
            rightHeight = Right.GetHeight();
        }

        return 1 + Math.Max(leftHeight, rightHeight);
    }
}