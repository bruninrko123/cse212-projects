using System.Linq.Expressions;
using System.Security.AccessControl;

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
            {
                
                
                    Left = new Node(value);
                
            }
            else
                Left.Insert(value);
        }
        else
        {
            // Insert to the right
            if (Right is null)
            {
                if (value != this.Data)
                {
                    Right = new Node(value);
                }
            }

                else
                    Right.Insert(value);
        }
    }

    public bool Contains(int value)
    {
        
        if (value == Data)
        {
           
            return true;
        }

        else if (value < Data && Left is not null)
        {
            return Left.Contains(value);
            
        }

        else
        {
            if (Right is not null)
                return Right.Contains(value);
            
        }

      
            
         return false;
        
        

    }
    public int GetHeight()
    {
        // if (Left is null && Right is null)
        // {
        //     return; 
        // }

        // if (Left is not null)
        // {
        //     return GetHeight() + 1;
        // }

        // if (Right is not null)
        // {
        //     return GetHeight() + 1;
        // }
        return 0; // Replace this line with the correct return statement(s)
    }
}