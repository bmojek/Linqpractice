using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp13
{
    public class Program
    {
        private static int Count(string s)
        {
            return s.Split(",").ToList().Count();
        }

        private static void LapTimes(string s)
        {
            List<TimeSpan> list = new List<TimeSpan>();
            var q = s.Split(',').ToList();
            var a = q.Select(x => "00:" + x).Select(TimeSpan.Parse).ToList();

            list.Add(a[0]);
            for (int i = 1; i < a.Count; i++)
                list.Add(a[i].Subtract(a[i - 1]));

            foreach (var z in list)
            {
                Console.Write(z.ToString(@"mm\:ss") + " ");
            }
        }

        private static void FastestLap(string s)
        {
            List<TimeSpan> list = new List<TimeSpan>();
            var q = s.Split(',').ToList();
            var a = q.Select(x => "00:" + x).Select(TimeSpan.Parse).ToList();
            list.Add(a[0]);
            for (int i = 1; i < a.Count; i++)
                list.Add(a[i].Subtract(a[i - 1]));
            List<int> index = new List<int>();
            for (int i = 0; i < list.Count; i++)
                if (list[i] == list.Min())
                    index.Add(i + 1);

            Console.Write(list.Min().ToString(@"mm\:ss"));
            foreach (var x in index)
            {
                Console.Write(" " + x);
            }
        }

        private static void SlowestLap(string s)
        {
            List<TimeSpan> list = new List<TimeSpan>();
            var q = s.Split(',').ToList();
            var a = q.Select(x => "00:" + x).Select(TimeSpan.Parse).ToList();
            list.Add(a[0]);
            for (int i = 1; i < a.Count; i++)
                list.Add(a[i].Subtract(a[i - 1]));
            List<int> index = new List<int>();
            for (int i = 0; i < list.Count; i++)
                if (list[i] == list.Max())
                    index.Add(i + 1);

            Console.Write(list.Max().ToString(@"mm\:ss"));
            foreach (var x in index)
            {
                Console.Write(" " + x);
            }
        }

        private static void AvgLap(string s)
        {
            List<TimeSpan> list = new List<TimeSpan>();
            var q = s.Split(',').ToList();
            var a = q.Select(x => "00:" + x).Select(TimeSpan.Parse).ToList();
            list.Add(a[0]);
            for (int i = 1; i < a.Count; i++)
                list.Add(a[i].Subtract(a[i - 1]));
            var avg = list.Average(x => x.TotalMinutes);
            var avgt = TimeSpan.FromMinutes(avg);
            if (avgt.Milliseconds != 0)
                avgt += new TimeSpan(0, 0, 1);
            Console.WriteLine($"{avgt:mm\\:ss}");
        }

        private static void Main(string[] args)
        {
            string testCase = Console.ReadLine();
            string s = Console.ReadLine();

            switch (testCase)
            {
                case "test1":
                    Console.WriteLine(Count(s));
                    break;

                case "test2":
                    LapTimes(s);
                    break;

                case "test3":
                    FastestLap(s);
                    break;

                case "test4":
                    SlowestLap(s);
                    break;

                case "test5":
                    AvgLap(s);
                    break;
            }
        }
    }
}