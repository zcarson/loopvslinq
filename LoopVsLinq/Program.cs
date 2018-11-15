using System;
using System.Collections.Generic;
using System.Diagnostics;
using BusinessObjects;

namespace LoopVsLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Creating FooCollection");
            FooCollection fooCollection = new FooCollection();
            Console.WriteLine($"Done. FooCollection contains {fooCollection.Collection.Count} Foos.");

            List<Foo> foosToFind = CreateSearchList(50);
            Console.WriteLine($"Going to find {foosToFind.Count} random combos");
            Console.WriteLine();

            int iterations = 100000;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            SearchWithLinq(fooCollection, foosToFind, iterations);
            sw.Stop();
            TimeSpan linqTime = sw.Elapsed;

            sw.Restart();
            SearchWithLoop(fooCollection, foosToFind, iterations);
            sw.Stop();
            TimeSpan loopTime = sw.Elapsed;

            Console.WriteLine("-----");
            Console.WriteLine($"Searched through the collection for each item {iterations} times.");
            Console.WriteLine($"Linq time: {linqTime.Seconds} seconds");
            Console.WriteLine($"Loop time: {loopTime.Seconds} seconds");
            Console.WriteLine("-----");

            Console.ReadLine();
        }

        static List<Foo> CreateSearchList(int numberToLookFor)
        {
            List<Foo> searchList = new List<Foo>();

            Array colorValues = Enum.GetValues(typeof(ColorType));
            Array flavorValues = Enum.GetValues(typeof(FlavorType));
            Random random = new Random();

            for (int i = 0; i < numberToLookFor; i++)
            {
                ColorType color = (ColorType)colorValues.GetValue(random.Next(colorValues.Length));
                FlavorType flavor = (FlavorType)flavorValues.GetValue(random.Next(flavorValues.Length));
                searchList.Add(new Foo(color, flavor));
            }

            return searchList;
        }

        static void SearchWithLoop(FooCollection fullCollection, List<Foo> searchList, int iterations)
        {
            for (int i = 0; i < iterations; i++)
            {
                foreach (Foo item in searchList)
                {
                    fullCollection.GetFooByFlavorAndColorLoop(item.Color, item.Flavor);
                }
            }
        }

        static void SearchWithLinq(FooCollection fullCollection, List<Foo> searchList, int iterations)
        {
            for (int i = 0; i < iterations; i++)
            {
                foreach (Foo item in searchList)
                {
                    fullCollection.GetFooByFlavorAndColorLinq(item.Color, item.Flavor);
                }
            }
        }
    }
}
