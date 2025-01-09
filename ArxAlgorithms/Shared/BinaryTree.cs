using ArxAlgorithms.Shared;

namespace MultiPathDictioanry;

public class BinaryTree
{
    public Node? Root;

    // Method to insert a new node into the binary tree
    public void Insert(int data)
    {
        Root = InsertRecursive(Root, data);
    }

    private Node InsertRecursive(Node? root, int data)
    {
        // If the tree is empty, return a new node
        if (root == null)
        {
            return new Node(data);
        }

        // Otherwise, recur down the tree
        if (data < root.Data)
        {
            root.Left = InsertRecursive(root.Left, data);
        }
        else if (data > root.Data)
        {
            root.Right = InsertRecursive(root.Right, data);
        }

        // return the (unchanged) node pointer
        return root;
    }

    // In-order traversal of the binary tree
    public void InOrderTraversal(Node? root)
    {
        if (root != null)
        {
            InOrderTraversal(root.Left);
            
            Console.Write(root.Data + " ");
            
            InOrderTraversal(root.Right);
        }
    }

    // A method to start the in-order traversal from the root
    public void InOrderTraversal()
    {
        InOrderTraversal(Root);
    }

    public bool Search(int data)
    {
        return SearchRecursive(Root, data);
    }

    private bool SearchRecursive(Node? root, int data)
    {
        // Base case: root is null or data is present at the root
        if (root == null || root.Data == data)
        {
            return root != null;
        }

        // Data is greater than the root's data
        if (data > root.Data)
        {
            return SearchRecursive(root.Right, data);
        }

        // Data is smaller than the root's data
        return SearchRecursive(root.Left, data);
    }
    
    
    public void Delete(int data)
    {
        Root = DeleteRecursive(Root, data);
    }

    private Node? DeleteRecursive(Node? root, int data)
    {
        // Base case: root is null or data is not present in the tree
        if (root == null)
        {
            return root;
        }

        // Data is greater than the root's data
        if (data > root.Data)
        {
            root.Right = DeleteRecursive(root.Right, data);
        }

        // Data is smaller than the root's data
        else if (data < root.Data)
        {
            root.Left = DeleteRecursive(root.Left, data);
        }

        // Data is equal to the root's data
        else
        {
            switch (root.Left)
            {
                // Case 1: No children
                case null when root.Right == null:
                    return null;
                // Case 2: One child
                case null:
                    return root.Right;
            }

            if (root.Right == null)
            {
                return root.Left;
            }

            // Case 3: Two children

            // Find the minimum value in the right subtree
            var minNode = root.Right;
            while (minNode.Left != null)
            {
                minNode = minNode.Left;
            }

            // Copy the minimum value to the root
            root.Data = minNode.Data;

            // Delete the minimum value from the right subtree
            root.Right = DeleteRecursive(root.Right, minNode.Data);
        }

        // Return the (possibly modified) root node
        return root;
    }
}
