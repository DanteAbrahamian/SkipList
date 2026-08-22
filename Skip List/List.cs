using System.ComponentModel.Design;

namespace Skip_List
{
    public class List<T> where T : IComparable<T>
    {
        int count = 0;
        Node<T> head = new Node<T>(default(T));
        Random random = new Random(5);

        int GetRandomHeight()
        {
            int height = 1;

            while (random.Next(0, 2) == 0 && height < head.Height + 1)
            {
                height++;
            }

            return height;
        }
        public void search(T value)
        {
            Search(value, head);
        }
        public Node<T> Search(T value, Node<T> currNode)
        {
            if (value.CompareTo(currNode.Next.Value) < 0)
            {
                return Search(value, currNode.Down);
            }
            else if (value.CompareTo(currNode.Next.Value) > 0)
            {
                return Search(value, currNode.Next);
            }
            else
            { 
                return currNode.Next;
            }
        }
        public void Insert(T value)
        {   
            Node<T> newNode = new Node<T>(value);
            
            newNode.Height = GetRandomHeight();
            Node<T> newHead = new Node<T>(default);
            newHead.Height = newNode.Height;
            if (newNode.Height > head.Height)
            {
                
                newHead.Down = head;
                head = newHead;
                
            }
            Node<T> tempNode = newNode;
            for (int index = 1; index < newNode.Height; index++)
            {
                
                newNode.Down = new Node<T>(value);
                newNode.Down.Height = newNode.Height - 1;
                newNode = newNode.Down;
            }
            newNode = tempNode;
            Insert(newNode, head);
        }
        public Node<T> Insert(Node<T> newNode, Node<T> currNode)
        {
            if (currNode.Next is not null)
            {
                if (newNode.Value.CompareTo(currNode.Next.Value) < 0)
                {
                    return Insert(newNode, currNode.Down);
                }
                else if (newNode.Value.CompareTo(currNode.Next.Value) > 0)
                {
                    return Insert(newNode, currNode.Next);
                }
                if (newNode.Value.CompareTo(currNode.Next.Value) < 0 && newNode.Value.CompareTo(currNode.Next.Value) > 0)
                {
                    if (newNode.Height == currNode.Height)
                    {
                        newNode.Next = currNode.Next;
                        currNode.Next = newNode;
                        return Insert(newNode.Down, currNode.Down);
                    }
                    else
                    {
                        return Insert(newNode, currNode.Down);
                    }
                }
            }
            else
            {
                currNode.Next = newNode;
                currNode = currNode.Down;
                newNode = newNode.Down;
                if (newNode != null || currNode != null)
                {
                    Insert(newNode, currNode);
                }
            }
            return currNode;
        }





        
        public void Remove(T value)
        {
            Node<T> currnode = head;
            Remove(value, currnode);
       
        }
        public Node<T> Remove(T value, Node<T> currNode)
        {
            if (currNode.Next.Value.CompareTo(value) > 0)
            {
                currNode = currNode.Next;
            }
            else if (currNode.Next.Value.CompareTo(value) < 0)
            {
                currNode = currNode.Down;
            }
            else if (currNode.Next.Value.Equals(value))
            {
                currNode.Next = currNode.Next.Next;
                if (currNode.Down.Value != null)
                {
                    Remove(value, currNode);
                }
            }
            return currNode;
        }

    }
}
