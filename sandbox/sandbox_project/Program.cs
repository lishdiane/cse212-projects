using System;
using System.Reflection;
using System.Runtime;

public class Program
{
    static void Main(string[] args)
    {
        var setA = new HashSet<int> { 1, 2, 3, 4 };
        var setB = new HashSet<int> { 3, 4, 7, 9 };

        var newSet = new HashSet<int>();

        foreach (int number in setA)
        {
            if (setB.Contains(number))
            {
                newSet.Add(number);
            }
        }
        Console.WriteLine(string.Join(", ", newSet));

        var newUnion = new HashSet<int>(setA);

        foreach (int item in setB)
        {
            if (!newUnion.Contains(item))
            {
                newUnion.Add(item);
            }
        }
        Console.WriteLine(string.Join(", ", newUnion));
    }
}
