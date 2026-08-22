using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Net.Security;
using System.Security.Cryptography;

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
            for (int index = 1; index < newHead.Height; index++)
            {
                
                newNode.Down = new Node<T>(value);
                newNode.Down.Height = newNode.Height - 1;
                newNode = newNode.Down;
            }
            newNode = tempNode;
            Insert(newNode, head);
            count++;
        }
        public Node<T> Insert(Node<T> newNode, Node<T> currNode)
        {
           
                if (currNode.Next is not null)
                {
                    if (newNode.Value.CompareTo(currNode.Next.Value) < 0 && newNode.Value.CompareTo(currNode.Value) > 0)
                    {
                        if (newNode.Height == currNode.Height)
                        {
                            newNode.Next = currNode.Next;
                            currNode.Next = newNode;
                            if (currNode.Down is not null)
                            {
                                return Insert(newNode.Down, currNode.Down);
                            }
                        }
                        else
                        {
                            return Insert(newNode, currNode.Down);
                        }
                    }
                    else if (newNode.Value.CompareTo(currNode.Next.Value) < 0)
                    {
                        return Insert(newNode, currNode.Down);
                    }
                    else if (newNode.Value.CompareTo(currNode.Next.Value) > 0)
                    {
                        return Insert(newNode, currNode.Next);
                    }
                    
                }
            
            else
            {
               
                if (newNode.Height.Equals(currNode.Height))
                {
                    currNode.Next = newNode;
                    if (currNode.Down is not null)
                    {
                        Insert(newNode.Down, currNode.Down);
                    }
                }
                else if (newNode.Height.CompareTo(currNode.Height) < 0)
                {
                    Insert(newNode, currNode.Down);
                }
            }
            return currNode;
        }





        
        public void Remove(T value)
        {
            Node<T> currnode = head;
            Remove(value, currnode);
            count--;
       
        }
        public Node<T> Remove(T value, Node<T> currNode)
        {
            if (currNode.Next is not null)
            {
                if (value.CompareTo(currNode.Next.Value) > 0)
                {
                    Remove(value, currNode.Next);
                }
                else if (value.CompareTo(currNode.Next.Value) < 0)
                {
                    Remove(value, currNode.Down);
                }
                else if (value.Equals(currNode.Next.Value))
                {
                    currNode.Next = currNode.Next.Next;
                    if (currNode.Down is not null)
                    {
                        Remove(value, currNode.Down);
                    }
                }
            }
            else
            {
                Remove(value, currNode.Down);
            }
            return currNode;
        }

    }
}
