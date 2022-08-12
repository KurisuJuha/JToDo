namespace JToDo
{
    public static class ToDo
    {
        public static Dictionary<Title, Data> Table = new Dictionary<Title, Data>();
        public static int NumberOfCharactersAvailable;

        static void Main(string[] args)
        {
            NumberOfCharactersAvailable = Console.WindowWidth - Table.Count - 1;

            HorizontalSeparator();
            VerticalSeparator();
            "  test  ".Write();
            VerticalSeparator();
            NewLine();
            HorizontalSeparator();
        }

        public static void NewLine()
        {
            Console.Write('\n');
        }

        public static void Write(this string str)
        {
            Console.Write(str);
        }

        public static void VerticalSeparator()
        {
            Console.Write("|");
        }

        public static void HorizontalSeparator()
        {
            int width = Console.WindowWidth;

            for (int i = 0; i < width; i++)
            {
                Console.Write("-");
            }

            NewLine();
        }

        public static int[] Split(this int value, int maxLength)
        {
            List<int> result = new List<int>();

            while (value - maxLength > 0)
            {
                result.Add(maxLength);
                value -= maxLength;
            }
            if (value > 0) result.Add(value);

            return result.ToArray();
        }

        public static int[] Split(this int value, int maxLength, int count)
        {
            List<int> result = Split(value, maxLength).ToList();

            if (result.Count > count)
            {
                result[result.Count - 2] = result[result.Count - 2] + result[result.Count - 1];
                result.RemoveAt(result.Count - 1);
            }

            return result.ToArray();
        }
    }
}