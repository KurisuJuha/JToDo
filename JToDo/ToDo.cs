namespace JToDo
{
    public static class ToDo
    {
        public static Dictionary<Title, List<Data>> Table = new Dictionary<Title, List<Data>>();

        public static void Main(string[] args)
        {
            Table[new Title("testtitle")] = new List<Data>()
            {
                new Data("testdata"),
            };
            Table[new Title("testtitle2")] = new List<Data>()
            {
                new Data("testdata2.0"),
                new Data("testdata2.1")
            };

            foreach (var title in Table.Keys)
            {
                Console.WriteLine(title.title);
                foreach (var data in Table[title])
                {
                    Console.Write("    ");
                    Console.WriteLine(data.content);
                }
                Console.Write('\n');
            }
        }
    }
}