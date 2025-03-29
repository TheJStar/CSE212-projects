using System;
using System.Collections.Generic;

public class Program
{
    static void Main(string[] args)
    {
        // This project is here for you to use as a "Sandbox" to play around
        // with any code or ideas you have that do not directly apply to
        // one of your projects.
        List<int> nums1 = new List<int>(){1, 2, 3, 4};
        List<int> nums2 = new List<int>(){1, 2, 5, 6, 7};

        Console.WriteLine("Test case 1\n");
        Console.WriteLine("Uninion-----");
        Uninion(nums1, nums2);
        Console.WriteLine("\nIntersection");
        Intersection(nums1, nums2);
        Console.WriteLine("\n");
        Console.WriteLine("\n========");
        Console.WriteLine("");
        
        List<int> nums3 = new List<int>(){1, 2, 7, 4, 5, 5};
        List<int> nums4 = new List<int>(){4, 4, 5, 5, 6, 7};

        Console.WriteLine("Test case 2\n");
        Console.WriteLine("Uninion-----");
        Uninion(nums3, nums4);
        Console.WriteLine("\nIntersection");
        Intersection(nums3, nums4);
        Console.WriteLine("\n");
        Console.WriteLine("\n========");
        Console.WriteLine("");

        List<int> nums5 = new List<int>(){1, 2, 3, 4};
        List<int> nums6 = new List<int>(){5, 6, 7};

        Console.WriteLine("Test case 3\n");
        Console.WriteLine("Uninion-----");
        Uninion(nums5, nums6);
        Console.WriteLine("\nIntersection");
        Intersection(nums5, nums6);
        Console.WriteLine("\n");
        Console.WriteLine("\n========");
        Console.WriteLine("");

        void Uninion (List<int> nums1, List<int> nums2) {
            HashSet<int> hashset = new HashSet<int>();
            foreach (int i in nums1) hashset.Add(i);
            foreach (int i in nums2) hashset.Add(i);

            Console.Write("{ ");
            foreach (int i in hashset) Console.Write(i + ", ");
            Console.Write("}");
        }

        void Intersection (List<int> nums1, List<int> nums2) {
            List<int> intersection = new List<int>();
            Dictionary<int, int> numberCounter = new Dictionary<int, int>();
            foreach (int i in nums1) {
                if (numberCounter.ContainsKey(i)) {
                    numberCounter[i]++;
                } else {
                    numberCounter[i] = 1;
                }
            }
            foreach (int i in nums2) {
                if (numberCounter.ContainsKey(i) && numberCounter[i] > 0) {
                    numberCounter[i]--;
                    intersection.Add(i);
                }
            }

            Console.Write("{ ");
            foreach (int i in intersection) Console.Write(i + ", ");
            Console.Write("}");
        }
        // Console.WriteLine("Hello Sandbox World!");
    }
}