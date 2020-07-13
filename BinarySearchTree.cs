using System;
using System.Collections.Generic;

namespace BinaryTrees
{
  enum TraversalOrder { PreOrder, InOrder, PostOrder }
  class Node
  {
    public int Data;
    public Node Left;
    public Node Right;
    public Node(int v) => Data = v;

    public void PrintPreOrder(string indent, bool last)
    {
      Console.Write(indent);
      if (last)
      {
        Console.Write("└─");
        indent += "  ";
      }
      else
      {
        Console.Write("├─");
        indent += "| ";
      }
      Console.WriteLine(Data);

      var children = new List<Node>();
      if (this.Left != null)
        children.Add(this.Left);
      if (this.Right != null)
        children.Add(this.Right);

      for (int i = 0; i < children.Count; i++)
        children[i].PrintPreOrder(indent, i == children.Count - 1);
    }

    public void PrintInOrder(string indent, bool last)
    {
      Console.Write(indent);
      if (last)
      {
        Console.Write("└─");
        indent += "  ";
      }
      else
      {
        Console.Write("├─");
        indent += "| ";
      }

      var children = new List<Node>();
      if (this.Left != null)
        children.Add(this.Left);

      Console.WriteLine(Data);

      if (this.Right != null)
        children.Add(this.Right);

      for (int i = 0; i < children.Count; i++)
        children[i].PrintInOrder(indent, i == children.Count - 1);
    }

    public void PrintPostOrder(string indent, bool last)
    {
      Console.Write(indent);
      if (last)
      {
        Console.Write("└─");
        indent += "  ";
      }
      else
      {
        Console.Write("├─");
        indent += "| ";
      }

      var children = new List<Node>();
      if (this.Left != null)
        children.Add(this.Left);

      if (this.Right != null)
        children.Add(this.Right);

      Console.WriteLine(Data);

      for (int i = 0; i < children.Count; i++)
        children[i].PrintPostOrder(indent, i == children.Count - 1);
    }
  }

  class BinaryTree
  {
    Node root;

    public BinaryTree( int[] values )
    {
      root = new Node(values[0]);
      for ( int i = 1; i < values.Length; i ++ )
        Add(root, values[i]);
    }

    public BinaryTree(Node r) => root = r;
    public void Print(TraversalOrder order )
    {
      if ( order == TraversalOrder.InOrder)
        root.PrintInOrder("", true);
      else if(order == TraversalOrder.PreOrder)
        root.PrintPreOrder("", true);
      else if(order == TraversalOrder.PostOrder)
        root.PrintPostOrder("", true);
    }
    //trasverse recursevily from top to bottom and find location
    private void Add( Node n, int v )
    {
      if ( v < n.Data )
      {
        if (n.Left == null)
          n.Left = new Node(v);
        else
          Add(n.Left, v);
      }
      else
      {
        if (n.Right == null)
          n.Right = new Node(v);
        else
          Add(n.Right, v);
      }
    }

    public int[] ToOrderedArray()
    {
      List<int> v = new List<int>();
      ToOrderedArray(root, v);
      return v.ToArray();
    }

    public void ToOrderedArray(Node node, List<int> v)
    {
      if (node.Left != null)
        ToOrderedArray(node.Left, v);
      v.Add(node.Data);
      if (node.Right != null)
        ToOrderedArray(node.Right, v);
    }

    public bool Contains(int v)
    {
      return Contains(root, v);
    }

    public bool Contains(Node n, int v)
    {
      if (n != null)
      {
        if (n.Data == v) return true;
        if (v < n.Data)
          return Contains(n.Left, v);
        else
          return Contains(n.Right, v);
      }

      return false;
    }

    public void Swap(int v, int target)
    {
      Node t = null;
      FindRef(this.root, target, ref t);
      if (t != null )
      {
        t.Data = v;
      }
    }

    public Node Find(int v)
    {
      return Find(root, v);
    }

    public Node Find(Node n, int v)
    {
      if (n != null)
      {
        if (n.Data == v ) return n;
        if (v < n.Data)
          return Find(n.Left, v);
        else
          return Find(n.Right, v);
      }

      return null;
    }

    public Node FindRef(Node n, int v, ref Node nodeRef)
    {
      if (n != null)
      {
        if (n.Data == v)
        {
          nodeRef = n;
        }
        if (v < n.Data)
          FindRef(n.Left, v, ref nodeRef);
        else
          FindRef(n.Right, v, ref nodeRef);
      }

      return null;
    }

    public void Insert(int v)
    {
      var inserted = Insert(this.root, v);
    }

    public Node Insert(Node root, int v)
    {
      // if the root is null, create a new node and return it
      if (root == null)
      {
        return new Node(v);
      }

      // if given key is less than the root node, recur for left subtree
      if (v < root.Data)
      {
        root.Left = Insert(root.Left, v);
      }

      // if given key is more than the root node, recur for right subtree
      else
      {
        root.Right = Insert(root.Right, v);
      }

      return root;
    }

    public void Delete( int v )
    {
      Node rightout = FindDeepestRighteous();
      Node todeleteRef = null;
      Node rightoutRef = null;
      FindRef(this.root, rightout.Data, ref rightoutRef);
      FindRef(this.root, v, ref todeleteRef);
      if ( (rightoutRef != null ) && (todeleteRef != null ) )
      {
        todeleteRef = rightout;
        rightoutRef = null;
      }
    }

    public Node FindDeepestRighteous()
    {
      Node n = new Node(0);
      int currentNodeLevel = 0;
      FindDeepestRighteous(this.root, 0, ref n, ref currentNodeLevel);
      return n;
    }

    private void FindDeepestRighteous( Node root, int currentLevel, ref Node currentNode, ref int currenNodeLevel )
    {
      if (root.Left != null)
        FindDeepestRighteous(root.Left, currentLevel + 1, ref currentNode, ref currenNodeLevel);
      if (root.Right != null)
      {
        if ( currentLevel > currenNodeLevel)
        {
          currentNode = root.Right;
          currenNodeLevel = currentLevel;
        }
        FindDeepestRighteous(root.Right, currentLevel + 1, ref currentNode, ref currenNodeLevel);
      }
    }

    public bool IsBinarySearchTree()
    {
      bool valid = true; 
      IsBinarySearchTree(root, ref valid );
      return valid;
    }
    public void IsBinarySearchTree(Node n, ref bool valid )
    {
      if ( ( valid ) && ( n != null ) )
      {
        if ((n.Left != null) && (n.Left.Data > n.Data))
          valid = false;
        if ((n.Right != null) && (n.Right.Data < n.Data))
          valid = false;

        if ( valid )
        {
          IsBinarySearchTree(n.Left, ref valid);
          IsBinarySearchTree(n.Right, ref valid);
        }
      }
    }
    public int Count()
    {
      int t = 1; //starting element
      CountRecursive(root, ref t);
      return t;
    }

    public void CountRecursive(Node root, ref int t)
    {
      if (root.Left != null)
      {
        t++;
        CountRecursive(root.Left, ref t);
      }
      if (root.Right != null)
      {
        t++;
        CountRecursive(root.Right, ref t);
      }
    }

    public bool IsBalanced()
    {
      int leftHeight = 0;
      int rightHeight = 0;
      if (root.Left != null)
        IsBalanced(root.Left, ref leftHeight);
      if (root.Right != null)
        IsBalanced(root.Right, ref rightHeight);
      return ( Math.Abs(rightHeight - leftHeight) <= 1 );
    }
    public void IsBalanced(Node n, ref int h)
    {
      if ( ( n.Left != null ) || ( n.Right != null ) )
      {
        h++;
        if (n.Left != null)
          IsBalanced(n.Left, ref h);
        if (n.Right != null)
          IsBalanced(n.Right, ref h);
      }
    }
  }
  class Program
  {
    static void Main(string[] args)
    {
      int[] treeValues = { 10, 5, 15, 7, 2, 9, 31 };
      BinaryTree tree = new BinaryTree(treeValues);
      tree.Print(TraversalOrder.InOrder);
      tree.Insert(1);
      tree.Print(TraversalOrder.InOrder);
      tree.Swap(19, 9);
      tree.Print(TraversalOrder.InOrder);
      Node rightout = tree.FindDeepestRighteous();
      Console.WriteLine("Right out" + rightout.Data);
      Node node = tree.Find(151);
      if ( node != null )
        Console.WriteLine("found! data: " + node.Data );
      else
        Console.WriteLine("not found!");
      bool contains = tree.Contains(151);
      Console.WriteLine(contains);
      bool valid = tree.IsBinarySearchTree();
      Console.WriteLine("Is Valid " + valid);
      Console.WriteLine("Total nodes " + tree.Count());
      Console.WriteLine("Ordered array " + tree.ToOrderedArray());
      Console.WriteLine("Is Balanced " + tree.IsBalanced());
      //invalid tree
      Node root = new Node(5);
      root.Left = new Node(2);
      root.Right = new Node(7);
      root.Right.Left = new Node(9);
      root.Right.Right = new Node(1);
      BinaryTree otherTree = new BinaryTree(root);
      otherTree.Print(TraversalOrder.InOrder);
      bool otherValid = otherTree.IsBinarySearchTree();
      Console.WriteLine("Is Valid " + otherValid);
      Console.WriteLine("Total nodes " + otherTree.Count());
      Console.WriteLine("Ordered array " + otherTree.ToOrderedArray());
      Console.WriteLine("Is Balanced " + otherTree.IsBalanced());
      Console.ReadLine();
    }
  }
}
