using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms_BinarySearch
{
    class Program
    {
        public static bool BinarySearchRecursive(int[] array, int x)
        {
            return BinarySearchRecursive(array, x, 0, array.Length - 1);
        }

        private static bool BinarySearchRecursive(int[] array, int x, int left, int right)
        {
            bool result = false;

            if (left > right)
                return false;

            int mid = left + ((right - left) / 2);

            if (array[mid] == x)
                return true;
            else if (array[mid] > x)
                return BinarySearchRecursive(array, x, left, mid - 1);
            else if (array[mid] < x)
                return BinarySearchRecursive(array, x, mid + 1, right);

            return result;
        }     

        private static bool BinarySearchIterative(int[] array, int x)
        {
            bool result = false;

            int left = 0;
            int right = array.Length - 1;

            while (left <= right)
            {
                int mid = left + ((right - left) / 2);

                if (array[mid] == x)
                    return true;
                else if (array[mid] > x)
                {
                    right = mid - 1;
                }
                else if (array[mid] < x)
                {
                    left = mid + 1;
                }
            }

            return result;
        }

        static void Main(string[] args)
        {
        }
    }
}
