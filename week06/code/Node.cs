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
        // Problem 1: Insert Unique Values Only
        // Check if value already exists (equal to current node)
        if (value == Data)
        {
            // Don't insert duplicates - just return
            return;
        }
        else if (value < Data)
        {
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

    public bool Contains(int value)
    {
        // Problem 2: Contains
        // Base case: if value matches current node
        if (value == Data)
        {
            return true;
        }
        // If value is less than current node, search left subtree
        else if (value < Data)
        {
            // If left is null, value doesn't exist
            if (Left is null)
                return false;
            else
                return Left.Contains(value);
        }
        // If value is greater than current node, search right subtree
        else
        {
            // If right is null, value doesn't exist
            if (Right is null)
                return false;
            else
                return Right.Contains(value);
        }
    }

    public int GetHeight()
    {
        // Problem 4: Tree Height
        // Get height of left subtree (0 if null)
        int leftHeight = (Left is null) ? 0 : Left.GetHeight();
        
        // Get height of right subtree (0 if null)
        int rightHeight = (Right is null) ? 0 : Right.GetHeight();
        
        // Height is 1 plus the maximum of left and right subtree heights
        return 1 + Math.Max(leftHeight, rightHeight);
    }
}