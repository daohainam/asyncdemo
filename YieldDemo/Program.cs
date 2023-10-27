namespace YieldDemo
{
    internal class Program
    {
        static void Main()
        {
            foreach (int i in OddNumbers(10))
            {
                Console.Write($"{i} ");
            }
        }

        public static IEnumerable<int> OddNumbers(int n)
        {
            for (int i = 1; i < n; i++)
            {
                if (i % 2 != 0)
                {
                    yield return i;
                }
            }
        }

        public static IEnumerable<int> OddNumbersUsingList(int n)
        {
            var list = new List<int>();
            for (int i = 1; i < n; i++)
            {
                if (i % 2 != 0)
                {
                    list.Add(i);
                }
            }

            return list;
        }

    }
}