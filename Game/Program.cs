using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                StartSequence(); // Call the method to start the game sequence
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}"); // Display any exception that occurred
            }
            finally
            {
                Console.WriteLine("Program complete."); // Display a message indicating program completion
            }
            Console.ReadLine();
        }

        static void StartSequence()
        {
            Console.WriteLine("Welcome to my game! Let's do some math!"); // Display a welcome message
            Console.WriteLine("Enter a number greater than zero:"); // Prompt the user to enter a number

            int size = Convert.ToInt32(Console.ReadLine()); // Read the user's input and convert it to an integer

            if (size <= 0)
                throw new Exception("Number must be greater than zero."); // Throw an exception if the number is not greater than zero

            int[] numbers = new int[size]; // Create an integer array of the specified size
            numbers = Populate(numbers); // Call the method to populate the array with user input
            int sum = GetSum(numbers); // Calculate the sum of the numbers in the array
            int index = GetRandomIndex(); // Get a random index within the array bounds
            int product = GetProduct(numbers, sum, index); // Calculate the product of the sum and the number at the random index
            decimal quotient = GetQuotient(product); // Get the quotient of the product divided by a user-provided number

            // Display the results to the user
            Console.WriteLine($"Your array is size: {size}");
            Console.WriteLine($"The numbers in the array are: {string.Join(",", numbers)}");
            Console.WriteLine($"The sum of the array is: {sum}");
            Console.WriteLine($"{sum} * {numbers[index]} = {product}");
            Console.WriteLine($"{product} / {quotient} = {product / quotient}");
        }

        static int[] Populate(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine($"Please enter number: {i + 1} of {numbers.Length}"); // Prompt the user to enter a number at each position in the array
                string input = Console.ReadLine(); // Read the user's input
                numbers[i] = Convert.ToInt32(input); // Convert the input to an integer and store it in the array
            }

            return numbers; // Return the populated array
        }

        static int GetSum(int[] numbers)
        {
            int sum = 0;
            foreach (int num in numbers)
            {
                sum += num; // Sum up all the numbers in the array
            }

            if (sum < 20)
                throw new Exception($"Value of {sum} is too low."); // Throw an exception if the sum is less than 20

            return sum; // Return the calculated sum
        }

        static int GetRandomIndex()
        {
            Console.WriteLine("Please select a random number between 1 and 6:"); // Prompt the user to select a random number
            int index = Convert.ToInt32(Console.ReadLine()) - 1; // Read the user's input and subtract 1 to get the zero-based index

            return index; // Return the selected index
        }

        static int GetProduct(int[] numbers, int sum, int index)
        {
            if (index < 0 || index >= numbers.Length)
                throw new IndexOutOfRangeException("Invalid index."); // Throw an exception if the index is out of range

            int product = sum * numbers[index]; // Calculate the product of the sum and the number at the specified index
            return product; // Return the calculated product
        }


        static decimal GetQuotient(int product)
        {
            Console.WriteLine($"Please enter a number to divide your product {product} by"); // Prompt the user to enter a number to divide the product by
            decimal dividend = Convert.ToDecimal(Console.ReadLine()); // Read the user's input and convert it to a decimal

            try
            {
                decimal quotient = decimal.Divide(product, dividend); // Divide the product by the user-provided number
                return quotient; // Return the calculated quotient
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Error: Cannot divide by zero."); // Handle the case where the user tries to divide by zero
                return 0; // Return 0 as the quotient
            }
        }
    }
}
