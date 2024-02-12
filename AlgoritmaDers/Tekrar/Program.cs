
public class Node
{
    public Node Left;
    public Node Right;
    public int Value;

    public Node(int value)
    {
        Left = null;
        Right = null;
        Value = value;
    }
}

public class Tree
{
    private Node root;
    private int[] nodes;

    public Tree(int[] nodes)
    {
        root = null;
        this.nodes = nodes;
    }

    public void BuildTree()
    {
        for (int i = 0; i < nodes.Length; i++)
        {
            InsertNode(nodes[i]);
        }
    }

    private void InsertNode(int value)
    {
        Node newNode = new Node(value);

        if (root == null)
        {
            root = newNode;
            return;
        }

        Node current = root;
        Node parent;

        while (true)
        {
            parent = current;

            if (value < current.Value)
            {
                current = current.Left;

                if (current == null)
                {
                    parent.Left = newNode;
                    return;
                }
            }
            else
            {
                current = current.Right;

                if (current == null)
                {
                    parent.Right = newNode;
                    return;
                }
            }
        }
    }

    public int FindFarthermostNode(out int distance)
    {
        int farthestNode = 0;
        distance = 0;

        if (root != null)
        {
            DeepFirstSearch(root, 0, ref farthestNode, ref distance);
        }

        return farthestNode;
    }

    private void DeepFirstSearch(Node node, int currentDistance, ref int farthestNode, ref int distance)
    {
        if (node == null)
            return;

        if (currentDistance > distance)
        {
            distance = currentDistance;
            farthestNode = node.Value;
        }

        DeepFirstSearch(node.Left, currentDistance + 1, ref farthestNode, ref distance);
        DeepFirstSearch(node.Right, currentDistance + 1, ref farthestNode, ref distance);
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        int[] nodes = { 1, 2, 3, 4, 5, 6, 7 };

        Tree tree = new Tree(nodes);
        tree.BuildTree();

        int farthestNode = tree.FindFarthermostNode(out int distance);

        Console.WriteLine("Uzaklik: " + distance);
        Console.WriteLine("En uzak dugum: " + farthestNode);
    }
}
