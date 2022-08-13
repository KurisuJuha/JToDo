using System;
using System.IO;
using System.Linq;

namespace JToDo
{
    public static class ToDo
    {
        public static Dictionary<Title, List<Data>> Table = new Dictionary<Title, List<Data>>();
        public static string path;

        public static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Commands(new string[]
                {
                    "open",
                    "test.todo"
                });
            }
            else
            {
                Commands(args);
            }
        }

        public static void Commands(string[] args)
        {
            switch (args[0])
            {
                case "help":
                    Command_Help();
                    break;
                case "version":
                    Command_Version();
                    break;
                case "open":
                    Command_Open(args);
                    break;
                case "debug":
                    path = args[1];
                    DebugDataSet();
                    Save();
                    break;
                default:
                    break;
            }
        }

        public static bool Save()
        {
            try
            {
                DataWriter dataWriter = new DataWriter();

                // データの書き込み処理
                dataWriter.Put(Table.Count);
                foreach (var item in Table.Keys)
                {
                    item.write(dataWriter);

                    dataWriter.Put(Table[item].Count);
                    foreach (var item2 in Table[item])
                    {
                        item2.write(dataWriter);
                    }
                }
                File.WriteAllBytes(path, dataWriter.GetData());
                return true;
            }
            catch (Exception)
            {
                Console.WriteLine("データのセーブに失敗しました。");
                return false;
            }
        }

        public static bool Load()
        {
            try
            {
                DataReader dataReader = new DataReader(File.ReadAllBytes(path));
                Table = new Dictionary<Title, List<Data>>();

                // データの読み込み処理
                int tablesize = dataReader.GetInt();
                for (int i = 0; i < tablesize; i++)
                {
                    Title title = new Title(dataReader);

                    int contentsize = dataReader.GetInt();
                    List<Data> data = new List<Data>();
                    for (int j = 0; j < contentsize; j++)
                    {
                        data.Add(new Data(dataReader));
                    }

                    Table[title] = data;
                }

                return true;
            }
            catch (Exception)
            {
                Console.WriteLine("データのロードに失敗しました。");
                return false;
            }
        }

        public static void PrintData()
        {
            Separator();

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

            Separator();
        }

        public static void DebugDataSet()
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
        }

        public static void Command_Help()
        {
            Console.WriteLine("まだヘルプは作ってないです。");
        }

        public static void Command_Version()
        {
            Console.WriteLine("0.0.0");
        }

        public static void Command_Open(string[] args)
        {
            if (args.Length == 2)
            {
                path = args[1];

                Open();
            }
            else
            {
                Console.WriteLine("指定されたパスは存在しないか、開くことができるデータ形式ではありません。");
            }
        }

        public static void MainLoop()
        {
            PrintData();

            while (true)
            {
                Console.Write(">>");
                string command = Console.ReadLine();
                switch (command)
                {
                    case "quit":
                        return;
                    case "add":
                        Select(Table.Keys.Select(value => {
                            return value.title;
                        }).ToArray());
                        Title list = new Title(Question("List>>"));
                        string content = Question("content>>");

                        if (!Table.ContainsKey(list))
                        {
                            Table[list] = new List<Data>();
                        }
                        Table[list].Add(new Data(content));

                        break;
                    case "addList":
                        break;
                    case "move":
                        break;
                    case "save":
                        Save();
                        break;
                    case "load":
                        Load();
                        break;
                    default:
                        Console.WriteLine("存在しないコマンドです。");
                        break;
                }

                PrintData();
            }
        }

        public static void Open()
        {
            if (Load())
            {
                MainLoop();
            }
        }

        public static void Separator()
        {
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.Write("-");
            }

            Console.Write('\n');
        }

        public static string Question(string question = "")
        {
            Console.Write(question);
            return Console.ReadLine();
        }

        public static int Select(string[] contents)
        {
            int ret = 0;
            List<(int, int)> positions = new List<(int, int)>();

            foreach (var content in contents)
            {
                positions.Add(Console.GetCursorPosition());
                Console.WriteLine(content);
            }

            return ret;
        }
    }
}