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
        //  This method inserts a new value into 
        // the binary search tree.
        //  If the value is less than the current node's data,
        //  it goes to the left subtree.

        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else if (value > Data)  // Changed from 'else' to 'else if (value > Data)'
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
        // This checks if the given value is present 
        // in the binary search tree.
        if (value == Data)
            return true;

        if (value < Data)
        {
            return Left != null && Left.Contains(value);
        }
        else
        {
            // Search the right subtree
            return Right != null && Right.Contains(value);
        }

    }
    public int GetHeight()
    {
        // TODO Start Problem 4
        // This method calculates the height of the binary search tree.
        // Base case: If this leaf node has no children, then height is 0
        // if (Left == null && Right == null)
        //  return 0;

        // Initialize heights of left and right subtrees 
        int leftHeight = 0; // Initialize left height
        int rightHeight = 0; // Initialize right height

        if (Left != null)
            leftHeight = Left.GetHeight(); // Recursively get height of left subtree

        if (Right != null)
            rightHeight = Right.GetHeight(); // Recursively get height of right subtree

        // The height of the current node is 1 plus the maximum height of its subtrees
        return Math.Max(leftHeight, rightHeight) + 1;
    }
}
