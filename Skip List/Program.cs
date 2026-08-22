namespace Skip_List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            list.Insert(5);
            list.Insert(10);
            list.Insert(14);
            list.Insert(12);
            list.Insert(15);
            list.Insert(54);
            list.Insert(560);
            list.Insert(97584);
            list.Insert(1345);
            list.Insert(56798);
            list.Remove(5);
            list.Remove(12);
            list.Remove(15);
            ;
        }
    }
}