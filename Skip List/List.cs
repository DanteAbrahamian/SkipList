using System;
using System.Collections.Generic;
using System.Text;

namespace Skip_List
{
    public class List<T> where T : IComparable<T>
    {
        int count = 0;
        int maxHeight = 0;
        Node<T> head = new Node<T>(default(T));
        Random random = new Random(5);
        int ChooseRandomHeight()
        {
            while (true)
            {
                int height = 1;
                while (random.Next(0, 2) == 0 && height < head.Height + 1)
                {
                    height++;
                }
                return height;
            }
        }
        public void Insert(T value)
        {

            Node<T> temp = head.Next;
            Node<T> down;
            Node<T> tTemp = head;
            if (count == 0)
            {
                temp = new Node<T>(value);
                temp.Height = ChooseRandomHeight();
                if (temp.Height > maxHeight)
                {
                    maxHeight = temp.Height;
                    head.Height = maxHeight;
                }
                
                head.Next = temp;
                head.Height = temp.Height;
                head.Down = tTemp;
                for (int index = 0; index < temp.Height; index++)
                {
                    temp.Down = new Node<T>(value);
                    temp.Down.Height = temp.Height - 1;
                    temp = temp.Down;

                    tTemp.Down = new Node<T>(default);
                    tTemp.Down.Height = tTemp.Height - 1;
                    tTemp = tTemp.Down;
                    tTemp.Next = temp;
                }
                temp.Down = null;
                
                count++;
            }
            else
            {

                while (temp.Next != null)
                {
                    temp = temp.Next;
                }
                temp.Next = new Node<T>(value);
                temp.Next.Height = ChooseRandomHeight();
                temp = temp.Next;
                for (int index = 0; index < temp.Height; index++)
                {
                    temp.Down = new Node<T>(value);
                    temp.Down.Height = temp.Height - 1;
                    temp = temp.Down;
                }
                temp.Down = null;
                if (temp.Height > maxHeight)
                {
                    maxHeight = temp.Height;
                }
                head.Height = maxHeight;
                count++;
                return;
            }


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
