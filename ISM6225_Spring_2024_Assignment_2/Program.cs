using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml.XPath;

namespace Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Question 1: Find Missing Numbers in Array
            Console.WriteLine("Question 1:");
            int[] nums1 = { 3, 1, 5, 3, 1 };
            IList<int> missingNumbers = FindMissingNumbers(nums1);
            Console.WriteLine(string.Join(",", missingNumbers));

            // Question 2: Sort Array by Parity
            Console.WriteLine("Question 2:");
            int[] nums2 = { 3, 1, 2, 4 };
            int[] sortedArray = SortArrayByParity(nums2);
            Console.WriteLine(string.Join(",", sortedArray));

            // Question 3: Two Sum
            Console.WriteLine("Question 3:");
            int[] nums3 = { 2, 7, 11, 15 };
            int target = 9;
            int[] indices = TwoSum(nums3, target);
            Console.WriteLine(string.Join(",", indices));

            // Question 4: Find Maximum Product of Three Numbers
            Console.WriteLine("Question 4:");
            int[] nums4 = { 1, 2, 3, 4 };
            int maxProduct = MaximumProduct(nums4);
            Console.WriteLine(maxProduct);

            // Question 5: Decimal to Binary Conversion
            Console.WriteLine("Question 5:");
            int decimalNumber = 10;
            string binary = DecimalToBinary(decimalNumber);
            Console.WriteLine(binary);

            // Question 6: Find Minimum in Rotated Sorted Array
            Console.WriteLine("Question 6:");
            int[] nums5 = { 3, 4, 5, 1, 2 };
            int minElement = FindMin(nums5);
            Console.WriteLine(minElement);

            // Question 7: Palindrome Number
            Console.WriteLine("Question 7:");
            int palindromeNumber = 123;
            bool isPalindrome = IsPalindrome(palindromeNumber);
            Console.WriteLine(isPalindrome);

            // Question 8: Fibonacci Number
            Console.WriteLine("Question 8:");
            int n = 51;
            int fibonacciNumber = Fibonacci(n);
            Console.WriteLine(fibonacciNumber);
        }

        // Question 1: Find Missing Numbers in Array
        public static IList<int> FindMissingNumbers(int[] nums)
        {
            try
            {
                int length = nums.Length;
                List<int> missingNumbers = new List<int>();
                for (int i = 1; i <= length; i++)
                {
                    if (!nums.Contains(i)) //using inbuilt function 'Contains' to check if the element exists.
                    {
                        missingNumbers.Add(i); //add the missing elements to a list
                    }
                    else
                    continue;
                }
                return missingNumbers; 
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 2: Sort Array by Parity
        public static int[] SortArrayByParity(int[] nums)
        {
            try
            {
                int length = nums.Length;
                List<int> result1 = new List<int>();
                List<int> result2 = new List<int>();
                for (int i = 0; i < length; i++)
                {
                    if(nums[i]%2 == 0) //checking if the number is even or odd
                    {
                        result1.Add(nums[i]); //adding even number to result1 list
                    }
                    else
                    {
                        result2.Add(nums[i]); //adding odd number to result2 list
                    }
                }
                result1.AddRange(result2); //concatenating both lists
                return result1.ToArray(); 
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 3: Two Sum
        public static int[] TwoSum(int[] nums, int target)
        {
            try
            {
                int length = nums.Length;
                List<int> result = new List<int>();
                for (int i = 0; i < length-1; i++) //iterating the list with first pointer.
                {
                    for (int j = i+1; j < length; j++) //iterating the list with second pointer.
                    {
                        if (nums[i] + nums [j] == target) //checking if the sum of the number from first pointer and second pointer add up to target
                        {
                            result.Add(i);
                            result.Add(j);
                        }
                    }
                }
                return result.ToArray(); 
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 4: Find Maximum Product of Three Numbers
        public static int MaximumProduct(int[] nums)
        {
            try
            {
                int length = nums.Length;
                int result1 = 1;
                int result2 = 1;
                Array.Sort(nums); //Sorting arranges in ascending order starting with negative numbers(if there are any)
                result1 *= nums[length-1] * nums[length-2] * nums[length-3]; //Product of last 3 numbers in the array
                result2 *= nums[0] * nums[1] * nums[length-1]; //product of first two numbers (in case of negative numbers case) and highest positive number.
                return Math.Max(result1, result2); 
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 5: Decimal to Binary Conversion
        public static string DecimalToBinary(int decimalNumber)
        {
            try
            {
                string result = "";
                if (decimalNumber == 0)
                {
                    result = "0";
                }
                while (decimalNumber > 0) //iterate until decimal number is greater than 0
                {
                    int remain = decimalNumber % 2; //check for the remainder of the decimal number
                    result = remain + result; //add the remainder to result string
                    decimalNumber = decimalNumber / 2; //divide decimal number by 2
                }
                return result; 
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 6: Find Minimum in Rotated Sorted Array
        public static int FindMin(int[] nums)
        {
            try
            {
                int left = 0;
                int right = nums.Length - 1;
                while (left < right) // perform binary search
                {
                    int mid = left + (right - left) / 2; 
                    if (nums[mid] > nums[right]) // if the mid element is greater than the right element, then the smallest element is in the right half
                    {
                        left = mid + 1;
                    }
                    else // otherwise, the smallest element is in the left half (including mid)
                    {
                        right = mid;
                    }
                }
                return nums[left];
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 7: Palindrome Number
        public static bool IsPalindrome(int x)
        {
            try
            {
                string y = Convert.ToString(x);
                string rev = new string(y.Reverse().ToArray()); //Reversing the string and converting it to array
                return y == rev; // checking if the reversed string is same as original string.
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 8: Fibonacci Number
        public static int Fibonacci(int n)
        {
            try
            {
                if (n >= 0 && n<= 30)
                {
                    if (n < 2) //if the n values is less than 2, F(n) = n
                    {  
                        return n;
                    }
                    else
                    {
                        return Fibonacci(n-1) + Fibonacci(n-2); //using recursive method to call Fibonacci method
                    }
                }
                else
                {
                    // Handle invalid input outside the range [0, 30]
                    throw new ArgumentOutOfRangeException("n", "Input must be between 0 and 30.");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
