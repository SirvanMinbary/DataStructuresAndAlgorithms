using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStructuresAndAlgorithms
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var numbers = new[] { 8, 7, 2, 5, 3, 1 };
            var target = 10;
            FindPairSumInArray(numbers, target);

            var numbers2 = new[] { 3, 4, -7, 3, 1, 3, 1, -4, -2, -2 };
            SubArrayWithZeroExists(numbers2);

            var bools = new List<bool> { false, false, true, false, true, true, false, true, false, false };
            SortBinaryArray(bools);

            var numbers3 = new List<int> { 5, 6, -5, 5, 3, 5, 3, -2, 0 };
            FindMaximumSubarrayForSum(numbers3, 8);
        }

        private static void FindPairSumInArray(int[] numbers, int target)
        {
            var checkedPairs = new List<Tuple<int, int>>();
            var pairs = new List<Tuple<int, int>>();
            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = 0; j < numbers.Length; j++)
                {
                    if (j == i)
                    {
                        continue;
                    }

                    var pair = new Tuple<int, int>(numbers[i], numbers[j]);
                    var reversed = new Tuple<int, int>(pair.Item2, pair.Item1);
                    if (pairs.Contains(reversed) || checkedPairs.Contains(reversed))
                    {
                        continue;
                    }

                    var sum = numbers[i] + numbers[j];
                    if (sum == target)
                    {
                        pairs.Add(pair);
                    }
                    else
                    {
                        checkedPairs.Add(pair);
                    }
                }
            }

            if (pairs.Count > 0)
            {
                foreach (var item in pairs)
                {
                    Console.WriteLine($"Pair found: {item.Item1} {item.Item2}");
                }
            }
            else
            {
                Console.WriteLine("No pairs found");
            }
        }

        private static void SubArrayWithZeroExists(int[] numbers)
        {
            var subArrays = new List<List<int>>();

            for (int i = 0; i < numbers.Length; i++)
            {
                var subArray = new List<int> { numbers[i] };

                for (int j = i + 1; j < numbers.Length; j++)
                {
                    subArray.Add(numbers[j]);
                    if (subArray.Sum() == 0)
                    {
                        subArrays.Add(subArray.ToList());
                        subArray.Clear();
                        break;
                    }
                }
            }

            Console.WriteLine(string.Join("\n", subArrays.Select(s => string.Join(", ", s))));
        }

        private static void SortBinaryArray(List<bool> bools)
        {
            var zeros = 0;
            for (int i = 0; i < bools.Count; i++)
            {
                if (!bools[i])
                {
                    zeros++;
                }
            }

            for (int i = 0; i < zeros; i++)
            {
                bools[i] = false;
            }

            for (int i = 0; i < bools.Count - zeros; i++)
            {
                bools[zeros + i] = true;
            }

            Console.WriteLine(string.Join(',', bools.Select(b => b ? "1" : "0")));
        }

        private static void FindMaximumSubarrayForSum(List<int> numbers, int target)
        {
            var index = -1;
            var length = -1;
            for (int i = 0; i < numbers.Count; i++)
            {
                for (int n = i + 1; n < numbers.Count; n++)
                {
                    var subarray = numbers[i..n];
                    if (subarray.Sum() == target && (n - i) > length)
                    {
                        index = i;
                        length = n - i;
                    }
                }
            }

            Console.WriteLine(string.Join(',', numbers[index..(index + length)]));
        }
    }
}