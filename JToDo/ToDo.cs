namespace JToDo
{
    public static class ToDo
    {
        public static Dictionary<Title, List<Data>> Table = new Dictionary<Title, List<Data>>();

        public static void Main(string[] args)
        {
            if (args.Length == 0)
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
            else
            {
                switch (args[0])
                {
                    case "help":
                        Console.WriteLine("まだヘルプは作ってないです。");
                        break;
                    case "version":
                        Console.WriteLine("0.0.0");
                        break;
                    case "open":
                        if (args.Length == 2)
                        {
                            string path = args[1];


                        }
                        else
                        {
                            Console.WriteLine("指定されたパスは存在しないか、開くことができるデータ形式ではありません。");
                        }
                        break;
                    default:
                        break;
                }
            }
        }
    }
}