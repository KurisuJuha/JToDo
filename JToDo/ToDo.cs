﻿using System;
using System.IO;

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
                            path = args[1];
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

        public static void Save()
        {
            try
            {
                DataWriter dataWriter = new DataWriter();

                // データの書き込み処理

                File.WriteAllBytes(path, dataWriter.GetData());
            }
            catch (Exception)
            {
                Console.WriteLine("データのセーブに失敗しました。");
            }
        }

        public static void Load()
        {
            try
            {
                DataReader dataReader = new DataReader(File.ReadAllBytes(path));

                // データの読み込み処理
            }
            catch (Exception)
            {
                Console.WriteLine("データのロードに失敗しました。");
            }
        }

        public static void PrintData()
        {
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
    }
}