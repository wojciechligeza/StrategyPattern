using System;
using System.Collections.Generic;
using King.Collections;

namespace Strategy
{
    // ENTRYPOINT APLIKACJI
    class Client
    {
        static void Main()
        {
            SortedList studentRecord = new SortedList();

            studentRecord.Add("Brian");
            studentRecord.Add("Jessica");
            studentRecord.Add("Bożydar");
            studentRecord.Add("ALfred");

            studentRecord.SetSortStrategy(new QuickSort());
            studentRecord.Sort();

            studentRecord.SetSortStrategy(new ShellSort());
            studentRecord.Sort();

            studentRecord.SetSortStrategy(new BubbleSort());
            studentRecord.Sort();

            Console.ReadKey();
        }
    }

    // STRATEGIA
    abstract class SortStrategy
    {
        public abstract void Sort(List<string> list);
    }

    // KONKRETNA STRATEGIA 1
    class QuickSort : SortStrategy
    {
        public override void Sort(List<string> list)
        {
            list.Sort();
            Console.WriteLine("QuickSorted list :");
        }
    }

    // KONKRETNA STRATEGIA 2
    class ShellSort : SortStrategy
    {
        public override void Sort(List<string> list)
        {
            list.ShellSort();
            Console.WriteLine("ShellSorted list :");
        }
    }

    // KONKRETNA STRATEGIA 3
    class BubbleSort : SortStrategy
    {
        public override void Sort(List<string> list)
        {
            list.BubbleSort();
            Console.WriteLine("BubbleSorted list :");
        }
    }

    // CONTEXT
    class SortedList
    {
        private readonly List<string> _list = new List<string>();
        private SortStrategy _sortstrategy;

        public void SetSortStrategy(SortStrategy sortstrategy)
        {
            _sortstrategy = sortstrategy;
        }

        public void Add(string name)
        {
            _list.Add(name);
        }

        public void Sort()
        {
            _sortstrategy.Sort(_list);

            foreach (string name in _list)
            {
                Console.WriteLine(" " + name);
            }
            Console.WriteLine();
        }
    }
}
