using System;
using System.Collections.Generic;
using System.Text;

namespace Skip_List
{
    public class List<T> where T : IComparable<T>
    {
        int count = 0;
        Node<T> head = new Node<T>(default(T));
        int ChooseRandomHeight()
        {
            Random random = new Random(5);
            while (true)
            {
                int height = 1;
                while (random.Next(0, 2) == 0)
                {
                    height++;
                }
                return height;
            }
        }
        public void Insert(T value)
        {

            Node<T> temp = head;
            Node<T> down;
            if (count == 0)
            {
                temp = head.Next;
                temp = new Node<T>(value);temp.Height = ChooseRandomHeight();
                for (int index = 0; index < temp.Height; index++)
                {
                    temp.Down.Value = temp.Value;
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
                    temp.Down.Value = temp.Value;
                    temp.Down.Height = temp.Height - 1;
                    temp = temp.Down;
                }
                temp.Down = null;
                count++;
                return;
            }

            
        }
        public void Remove(T value)
        {

            Node<T> temp;
            Node<T> down;
            if (value.Equals(head.Value))
            {
                temp = head;
                head = temp.Next;
                temp = head;
                down = null;
                count--;
                return;
            }
            temp = head;
            while (!temp.Value.Equals(value))
            {
                temp = temp.Next;
            }
            down = temp.Down;
            down.Next = temp.Next;
            temp = temp.Next;
            temp.Down = down;
            count--;
        }

    }
}
