using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace caUnit_12
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }
        static int LinearSearch(int value, int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                var current = array[i];

                if (current == value)
                    return i;
            }

            return -1;
        }
        static int BinarySearch(int value, int[] array, int left, int right)
        {
            while (left <= right)
            {
                var middle = (left + right) / 2;

                var midElement = array[middle];

                if (midElement == value)
                {
                    return middle;
                }
                else if (value < midElement)
                {
                    right = middle - 1;
                }
                else
                {
                    left = middle + 1;
                }
            }

            return -1;
        }
        static int BinarySearchRec(int value, int[] array, int left, int right)
        {

            var middle = (left + right) / 2;

            var midElement = array[middle];

            if (midElement == value)
            {
                return middle;
            }
            else if (left < right)
            {
                if (value < midElement)
                {
                    return BinarySearch(value, array, left, middle - 1);
                }
                else
                {
                    return BinarySearch(value, array, middle + 1, right);
                }
            }
            else
            {
                return -1;
            }
        }
        static void BubbleSort(int[] array)
        {
            int temp;
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] > array[j])
                    {
                        temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }
        }
    }
}
