// Write a program that sorts an array of STRINGS using the quick sort algorithm (find it in Wikipedia).

using System;

class QuickSortAlgorithmString
{
    static void Main()
    {
        //reading the input data from the console
        uint arraySize;
        do
        {
            Console.Write("Please enter the size of array: ");
        }
        while (!uint.TryParse(Console.ReadLine(), out arraySize));

        string[] array = new string[arraySize];
        for (int i = 0; i < arraySize; i++)
        {
            Console.Write("Please enter element {0} of array: ", i + 1);
            array[i] = Console.ReadLine();
        }

        // secondaryArray - help array, two times bigger size than the basic array            
        // sorted - boolean array indicating whether an item is its position 
        // startPosition - start positions in the subarray in which we check the larger and smaller elements to set element
        // finalPosition - final positions in the subarray in which we check the larger and smaller elements to set element
        string[] secondaryArray = new string[2 * arraySize];
        bool[] sorted = new bool[arraySize];
        int topPosition = 0;
        int bottomPosition = (int)arraySize - 1;
        bool result = false;

        while (true)
        {
            int counterBigger = 0;
            int counterSmaller = 0;
            secondaryArray[arraySize] = array[topPosition];
            for (int i = topPosition + 1; i <= bottomPosition; i++)
            {
                // CompareTo - function to compare strings
                if (secondaryArray[arraySize].CompareTo(array[i]) < 0)
                //if(array[i].CompareTo(secondaryArray[arraySize])<0)
                {
                    counterBigger = counterBigger + 1;
                    secondaryArray[arraySize + counterBigger] = array[i];
                }
                else
                {
                    counterSmaller = counterSmaller + 1;
                    secondaryArray[arraySize - counterSmaller] = array[i];
                }
            }

            // transfer of data from secondaryArray to array
            for (int i = 0; i <= bottomPosition - topPosition; i++)
            {
                array[topPosition + i] = secondaryArray[arraySize - counterSmaller + i];
            }
            sorted[topPosition + counterSmaller] = true;

            //Verify that all elements in the array is sorted. If you have not set the topPosition and the bottomPosition
            bool startFlag = false;
            int counter = 0;
            for (int i = 0; i < arraySize; i++)
            {
                if (sorted[i])
                {
                    counter++;
                    if (startFlag)
                    {
                        bottomPosition = i - 1;
                        break;
                    }
                }
                else if (!startFlag)
                {
                    topPosition = i;
                    startFlag = true;
                }
                else if (i == arraySize - 1)
                {
                    bottomPosition = (int)arraySize - 1;
                }

                if (counter == arraySize)
                {
                    result = true;
                }
            }
            if (result)
            {
                break;
            }
        }

        // print sorted array 
        Console.WriteLine("The sorted array of strings is:   ");
        for (int i = 0; i < arraySize; i++)
        {
            Console.Write("{0}  ", array[i]);
        }
        Console.WriteLine();
    }
}
