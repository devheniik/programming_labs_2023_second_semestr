using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

class Program {

    static void FirstTask()
    {
        List<int> numbers = new List<int> { 1, 2, 3, 2, 1, 4, 5, 4, 6 };
        Dictionary<int, int> frequency = new Dictionary<int, int>();
        
        // Counting the number of occurrences of each element 
        foreach (int number in numbers) {
            frequency.TryGetValue(number, out int value);
            value++;
            frequency[number] = value;
        }

        int pairsCount = 0;

        // Counting the number of pairs of elements equal to one to one for example: 1 occurrences 5 times it will be 2 pairs
        foreach (int value in frequency.Values) {
            pairsCount += value / 2;
        }

        Console.WriteLine($"Number of pairs of elements equal to one to one: {pairsCount}");
    }

    static void SecondTask()
    {
        Dictionary<string, int> dict = new Dictionary<string, int> {
            { "key1", 3 },
            { "key2", 2 },
            { "key3", 4 },
            { "key4", 1 }
        };

        int product = 1;
        foreach (int value in dict.Values) {
            product *= value;
        }

        dict = dict.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

        Console.WriteLine("Sorted dictionary in JSON:");
        Console.WriteLine(JsonSerializer.Serialize(dict));

        Console.WriteLine($"Product of keys: {product}");
    }
    
    static void ThirdTask()
    {
        char c = 'a';
        string[] A = { "abc", "def", "agca", "caba", "acca", "acc", "a", "aa" };

        int count = A.Where(x => x.Length > 1 && x.StartsWith(c) && x.EndsWith(c)).Count();

        Console.WriteLine($"Quantity of A elements, which contain 1+ symbol C and starts by C and ends by C: {count}");
    }
    
    static void Main(string[] args) {
        // FirstTask();
        // SecondTask();
        // ThirdTask();
    }
}