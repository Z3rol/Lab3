namespace Lab3
{
    public class Functions
    {
        /// <summary>
        /// Loop: Read a number. Validate the range and numeric format.
        /// </summary>
        /// <param name="message">Printed prompt</param>
        /// <param name="min">Min value a number can have</param>
        /// <param name="max">Max valu a number can have</param>
        /// <returns>Formatted number</returns>
        public static int GetValidInt(string message, int min = int.MinValue, int max = int.MaxValue)
        {
            // Loop until valid int in range is entered
            while (true)
            {
                // Print prompt, hide range if wasnt changed
                if (min == int.MinValue && max == int.MaxValue)
                    Console.Write($"{message}: ");
                else
                    Console.Write($"{message} ({min}-{max}): ");

                // Read input, null safe
                string? input = Console.ReadLine();

                // Handle invalid input
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Error: invalid format");
                    continue;
                }

                // Validate the range and numeric format
                if (int.TryParse(input, out int result))
                {
                    if (result >= min && result <= max)
                        return result;
                    else
                        Console.WriteLine($"Error: number must be in range ({min}-{max})");
                }
                else
                    Console.WriteLine("Error: input is not a valid number");                
            }
        }

        /// <summary>
        /// Loop: Read a line of elements. Validate the length and numeric format.
        /// </summary>
        /// <param name="message">Printed prompt</param>
        /// <param name="minLength">Minimum number of elements</param>
        /// <param name="maxLength">Maximum number of elements</param>
        /// <returns>Valid int[]</returns>
        public static int[] GetValidIntArray(string message, int minLength = 1, int maxLength = 100)
        {
            while (true)
            {
                // Print prompt and read a line
                Console.Write($"{message} (length: {minLength}-{maxLength}): ");
                string? input = Console.ReadLine();

                // Handle invalid input
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Error: invalid format");
                    continue;
                }

                // Split input
                string[] splitInput = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                // Handle invalid length
                if (splitInput.Length < minLength || splitInput.Length > maxLength)
                {
                    Console.WriteLine("Error: invalid number of elements");
                    continue;
                }

                // Final array
                int[] arr = new int[splitInput.Length];
                bool allNumbersParsed = true;

                // Parses all numbers. Prints error message and restarts if fail
                for (int i = 0; i < splitInput.Length; i++)
                {
                    if (!int.TryParse(splitInput[i], out arr[i]))
                    {
                        Console.WriteLine($"Error: {splitInput[i]} is not a valid number");
                        allNumbersParsed = false;
                        break;
                    }
                }

                // If no error was found
                if (allNumbersParsed)
                    return arr;
            }
        }

        /// <summary>
        /// Read jagged array.
        /// </summary>
        /// <returns>jagged int array</returns>
        public static int[][] GetValidJagIntArr()
        {
            // Get valid size for the jagged array (1-10)
            int size = GetValidInt("Enter the number of rows", 1, 10);
            
            int[][] jagArr = new int[size][];

            // Loops until the jagged array was filled
            for (int i = 0; i < size; i++)
                jagArr[i] = GetValidIntArray($"Enter row №{i}");

            return jagArr;
        }

        /// <summary>
        /// Loop: Read input until yes/no is entered
        /// </summary>
        /// <param name="message">Printed Prompt</param>
        /// <returns>Bool</returns>
        public static bool GetConfirmation(string message)
        {
            while (true)
            {
                // Print prompt and read input
                Console.Write($"{message} (yes/no): ");
                string? input = Console.ReadLine()?.Trim().ToLower();

                // Handle invalid input and quitCommand input
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Error: invalid input");
                    continue;
                }

                // Check input, return bool if input == yes or no, otherwise continue
                if (input == "yes")
                    return true;
                else if (input == "no")
                    return false;
                else
                    Console.WriteLine($"Error: {input} is not a valid choice");
            }
        }

        /// <summary>
        /// Generates a random integer array of "length" elements
        /// </summary>
        /// <param name="length">The number of elements</param>
        /// <param name="minValue">Minimum value an element can have</param>
        /// <param name="maxValue">Maximum value an element can have</param>
        /// <returns>int[] array of "length" elements</returns>
        public static int[] GenerateRandomIntArr(int length, int minValue = int.MinValue, int maxValue = int.MaxValue)
        {
            int[] arr = new int[length];
            for (int i = 0; i < length; i++)
                arr[i] = Random.Shared.Next(minValue, maxValue + 1);

            return arr;
        }

        /// <summary>
        /// Generetes a random jagged array of chosen size
        /// </summary>
        /// <param name="numberOfRows">The number of subarrays for jagged array to be generated</param>
        /// <param name="minNumberOfElements">Minimum number of elements each subarray can have</param>
        /// <param name="maxNumberOfelements">Maximum number of elements each subarray can have</param>
        /// <param name="minValue">Minimum value each number can have</param>
        /// <param name="maxValue">Maximum value each number can have</param>
        /// <returns>Randomly generated jagged array of {numberOfRows} size</returns>
        public static int[][] GenerateRandomJagIntArr(int numberOfRows, int minNumberOfElements, int maxNumberOfelements, int minValue = int.MinValue, int maxValue = int.MaxValue)
        {
            int[][] arr = new int[numberOfRows][];

            for (int i = 0; i < numberOfRows; i++)
                arr[i] = GenerateRandomIntArr(Random.Shared.Next(minNumberOfElements, maxNumberOfelements + 1), minValue, maxValue) ?? [];

            return arr;
        }

        /// <summary>
        /// Prints all numbers of arr space-split
        /// </summary>
        /// <param name="arr"></param>
        public static void PrintIntArr(int[] arr)
        {
            Console.WriteLine(string.Join(' ', arr));
        }

        /// <summary>
        /// Prints all elements of each row of jagArr space-split
        /// </summary>
        /// <param name="jagArr"></param>
        public static void PrintJagIntArr(int[][] jagArr)
        {
            for (int i = 0; i < jagArr.Length; i++)
                Console.WriteLine(string.Join(' ', jagArr[i]));
        }
    }
}