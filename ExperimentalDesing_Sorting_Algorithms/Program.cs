using System;

namespace ExperimentalDesing_Sorting_Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("------------ EXPERIMENTAL DESING USING SORTING ALGORITHMS ------------");
            Console.WriteLine("");
            Console.WriteLine("Array to be sorted");

            int[] array = generateRandomArray(20); // Enter the number of elementes of the array
            print(array);

            Console.WriteLine("");
            Console.WriteLine("Sorted array using counting sort");
            int[] sortedArrayCountingSort = countingSort(array);
            print(sortedArrayCountingSort);

            Console.WriteLine("");
            Console.WriteLine("Sorted array using bubble sort");
            int[] sortedArrayBubbleSort = bubbleSort(array);
            print(sortedArrayBubbleSort);

        }

        public static int[] generateRandomArray(int size)
        {

            int[] array = new int[size];

            Random rnd = new Random();

            for (int i = 0; i < size; i++)
            {
                int current = rnd.Next(1, size);
                array[i] = current;

            }

            return array;

        }

        public static void print(int[] array)
        {

            string toPrint = "[ ";

            foreach (int v in array)
            {
                toPrint += " " + v + ",";
            }

            toPrint += "]";

            Console.WriteLine(toPrint);

        }

        public static int[] countingSort(int[] array) {

            int size = array.Length;
            int[] output  = new int[size +1 ];

           
            int max = array[0];
            for (int i = 1; i < size; i++)
            {
                if (array[i] > max)
                    max = array[i];
            }
            int[] count = new int[max + 1];
            for (int i = 0; i < max; ++i)
            {
                count[i] = 0;
            }
            for (int i = 0; i < size; i++)
            {
                count[array[i]]++;
            }
            for (int i = 1; i <= max; i++)
            {
                count[i] += count[i - 1];
            }
            for (int i = size - 1; i >= 0; i--)
            {
                output[count[array[i]] - 1] = array[i];
                count[array[i]]--;
            }
            for (int i = 0; i < size; i++)
            {
                array[i] = output[i];
            }

            return output;

        }

        public static int[] bubbleSort(int[] arr) {
            int n,i, j, temp;
            bool swapped;
            n = arr.Length;

            for (i = 0; i < n - 1; i++)
            {
                swapped = false;
                for (j = 0; j < n - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        // swap arr[j] and arr[j+1] 
                        temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                        swapped = true;
                    }
                }

                // IF no two elements were  
                // swapped by inner loop, then break 
                if (swapped == false)
                    break;
            }

            return arr;
        }
    }
    }

