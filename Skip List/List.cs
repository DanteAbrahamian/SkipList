using System.ComponentModel.Design;

namespace Skip_List
{
    public class List<T> where T : IComparable<T>
    {
        int count = 0;
        int maxHeight = 0;
        Node<T> head = new Node<T>(default(T));
        Random random = new Random();

        int ChooseRandomHeight()
        {
            int height = 1;

            while (random.Next(0, 2) == 0 && height < head.Height + 1)
            {
                height++;
            }

            return height;
        }

        public Node<T> Search(T value)
        {
            if(count == 0)
            {
                return null;
            }

            Node<T> curr = head;

            while (curr != null)
            {
                int comparison = value.CompareTo(curr.Next.Value);

                if (comparison < 0)
                {
                    curr = curr.Down;
                }
                else if (comparison > 0)
                {
                    curr = curr.Next;
                }
                else
                {
                    return curr.Next;
                }

            }

            return null;
        }

        public void Insert(T value)
        {

            Node<T> temp = head;
            Node<T> tTemp = new Node<T>(value);
            tTemp.Height = ChooseRandomHeight();
            // first thing to add
            if (count == 0)
            {
                maxHeight = tTemp.Height;

                if (tTemp.Height > head.Height)
                {
                    
                    temp = new Node<T>(default);
                    temp.Height = tTemp.Height;
                    temp.Next = tTemp;
                
                    temp.Down = head;
                    
                    tTemp.Down = new Node<T>(value);
                    temp.Down.Height--;
                    head.Next = tTemp.Down;
                    head = temp;
                }
                else
                {
                    head.Next = tTemp;
                }
                count++;
                return;
            }

            if (temp.Height > tTemp.Height)
            {
                int height = temp.Height;
                for (int i = 0; i < height; i++)

                {
                    if (tTemp.Height == temp.Height)
                    {
                        temp.Next = tTemp;
                        temp.Down = temp;
                        tTemp.Down = tTemp;
                        temp = temp.Down;
                        tTemp = tTemp.Down;
                        temp.Height = i;
                        tTemp.Height = i;
                    }
                    else
                    {
                        temp = temp.Down;
                    }
                }
            }
            //
            else if (temp.Height < tTemp.Height)
            {
                maxHeight = tTemp.Height;
                head.Next = tTemp;
                head.Height = tTemp.Height;
                int height = tTemp.Height;
                for (int i = 0; i < height; i++)
                {
                    if (temp.Height == tTemp.Height)
                    {
                        temp.Next = tTemp;
                        temp.Down = temp;
                        tTemp.Down = new Node<T>(tTemp.Value);
                        temp = temp.Down;
                        tTemp = tTemp.Down;
                        temp.Height--;
                        tTemp.Height--;
                    }
                    else
                    {
                        head.Next = tTemp;
                        tTemp.Down = new Node<T>(tTemp.Value);
                        tTemp.Down.Height = tTemp.Height - 1;
                        tTemp = tTemp.Down;
                    };
                }
                temp.Down = null;
                tTemp.Down = null;
            }
            
            else if (temp.Height == tTemp.Height)
            {
                int height = tTemp.Height;
                for (int i = 0; i < height; i++)
                {
                    temp.Next = tTemp.Next;
                    temp = temp.Down;
                    tTemp.Down = tTemp;
                    tTemp.Down.Height = tTemp.Height - 1;
                    tTemp = tTemp.Down;
                    
                }
            }
            count++;
            return;
        }






        public void Remove(T value)
        {
            Node<T> temp = head;
            Node<T> tTemp;
            while (!temp.Next.Value.Equals(value))
            {
                temp = temp.Next;
            }
            tTemp = temp.Next;
            tTemp = tTemp.Next;
            temp.Next = tTemp;
            count--;
        }

    }
}
