// Write a program that finds the most frequent number in an array. 
// Example: {4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3} -> 4 (5 times)

using System;
using System.Collections.Generic;

class MostFrequentNumber
{
    static void Main()
    {
        //read the array size from the console
        uint sizeOfArray;
        do
        {
            Console.Write("Please enter the size of array: ");
        }
        while (!uint.TryParse(Console.ReadLine(), out sizeOfArray));

        //read array elements from the console
        int[] arrayOfIntegers = new int[sizeOfArray];
        for (int i = 0; i < sizeOfArray; i++)
        {
            do
            {
                Console.Write("Please enter element {0} of array: ", i + 1);
            }
            while (!int.TryParse(Console.ReadLine(), out arrayOfIntegers[i]));
        }

        // sort array
        Array.Sort(arrayOfIntegers);

        // check for most frequent number
        List<int> mostFrequentNumber = new List<int>();
        mostFrequentNumber.Add(arrayOfIntegers[0]);
        //int mostFrequentNumber = arrayOfIntegers[0];
        int frequentNumber = arrayOfIntegers[0];
        int maxRepeat = 1;
        int repeat = 1;
        for (int i = 1; i < sizeOfArray; i++)
        {
            if (arrayOfIntegers[i] == frequentNumber)
            {
                repeat++;
            }
            else
            {
                frequentNumber = arrayOfIntegers[i];
                repeat = 1;
            }
            if (repeat > maxRepeat)
            {
                maxRepeat = repeat;
                mostFrequentNumber.Clear();
                mostFrequentNumber.Add(arrayOfIntegers[i]);
            }
            else if (repeat == maxRepeat)
            {
                mostFrequentNumber.Add(arrayOfIntegers[i]);
            }
        }

        // print result
        if (mostFrequentNumber.Count == 1)
        {
            Console.WriteLine("Most frequent number in an array is: {0} -> {1} times", mostFrequentNumber[0], maxRepeat);
        }
        else if (mostFrequentNumber.Count > 1)
        {
            Console.WriteLine("Most frequent numbers in an array are:");
            for (int i = 0; i < mostFrequentNumber.Count; i++)
            {
                if (i == mostFrequentNumber.Count - 1)
                {
                    Console.WriteLine(" and {0} -> {1} times", mostFrequentNumber[i], maxRepeat);
                    break;
                }
                Console.Write("{0}", mostFrequentNumber[i]);
                if (i < mostFrequentNumber.Count - 2)
                {
                    Console.Write(", ");
                }
            }
        }
    }
}
