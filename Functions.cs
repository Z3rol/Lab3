namespace Lab3
{
    public class Functions
    {
        /// <summary>
        /// Loop: Read a number. Validate the range and numeric format.
        /// Stops if quitCommand is entered.
        /// </summary>
        /// <param name="message">Printed prompt</param>
        /// <param name="min">Minimum number</param>
        /// <param name="max">Maximum number</param>
        /// <param name="quitCommand">Stops the loop if entered</param>
        /// <returns>int. null if was quit</returns>
        public static int? GetValidInt(string message, int min = int.MinValue, int max = int.MaxValue, string quitCommand = "q")
        {
            while (true)
            {
                // Prints prompt and reads a number
                Console.Write($"{message} ({min}-{max} or {quitCommand} to go back): ");
                string input = Console.ReadLine()?.Trim().ToLower() ?? "";

                if (input == quitCommand)
                    return null;

                // Validate the range and numeric format
                if (int.TryParse(input, out int result))
                {
                    if (result >= min && result <= max)
                        return result;
                    else
                        Console.WriteLine($"Error: number must be in range {min}-{max}");
                }
                else
                    Console.WriteLine("Error: wrong input");
            }
        }

        /// <summary>
        /// Loop: Read a line of elements. Validate the length and numeric format.
        /// Stops if quitCommand is entered
        /// </summary>
        /// <param name="message">Printed prompt</param>
        /// <param name="minLength">Minimum number of elements</param>
        /// <param name="maxLength">Maximum number of elements</param>
        /// <param name="quitCommand">Stops the loop if entered</param>
        /// <returns>int[] array. null if was quit</returns>
        public static int[]? GetValidIntArray(string message, int minLength = 1, int maxLength = 100, string quitCommand = "q")
        {
            while (true)
            {
                // Print prompt and read a line
                Console.Write($"{message} ({minLength}-{maxLength} length, or {quitCommand} to go back): ");
                string? input = Console.ReadLine()?.Trim().ToLower();

                // Handle null and quitCommand input
                if (input == null)
                {
                    Console.WriteLine("Error: invalid format");
                    continue;
                }
                else if (input == quitCommand)
                {
                    Console.WriteLine("Returning to the previous task...");
                    return null;
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

                // Parses all numbers. Prints error message and restarts the loop on fail
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
        /// Loop: tries to get a jagged array.
        /// </summary>
        /// <param name="message">Printed prompt</param>
        /// <param name="quitCommand">Command to stop the loop</param>
        /// <returns>jagged array, null if user quit</returns>
        public static int[][]? ReadJaggedArray(string message, string quitCommand = "q")
        {
            while (true)
            {
                // Get valid size for the jagged array
                int? size = GetValidInt("Enter the number of arrays", 1, 10);

                // If the size wasn't entered, ask if user wants to re-enter or to stop the program
                if (size == null)
                {
                    bool? answer = GetConfirmation("Number of arrays wasn't entered. Try again?");
                    if (answer == false || answer == null)
                    {
                        Console.WriteLine("Returning...");
                        return null;
                    }
                    else
                        continue;
                }
                
                // Counter for how many valid rows were already entered
                int currentRow = 0;
                int[][] jagArr = new int[(int) size][];

                // Loops until the jagged array was filled, or user quit
                // For loop isn't valid here, because on some iterations no array will be entered
                while (currentRow < size)
                {
                    // Temporarily store the array to prevent null exception
                    int[]? temp = GetValidIntArray($"Enter the row №{currentRow}");

                    // If valid array wasn't entered, ask if the user wants to re-enter or to stop the program
                    if (temp == null)
                    {
                        bool? answer = GetConfirmation($"The row №{currentRow} wasn't entered correctly. Try again?");
                        if (answer == null || answer == false)
                        {
                            Console.WriteLine("Returning...");
                            return null;
                        }
                        else
                            continue;
                    }

                    // If valid array entered => fill
                    jagArr[currentRow] = temp;
                }

                return jagArr;
            }
        }

        /// <summary>
        /// Loop: Read input. Tries to get yes/no
        /// </summary>
        /// <param name="message">Printed Prompt</param>
        /// <param name="quitCommand">Stops the loop if entered</param>
        /// <returns>bool. null if was quit</returns>
        public static bool? GetConfirmation(string message, string quitCommand = "q")
        {
            while (true)
            {
                // Print prompt and read input
                Console.Write($"{message} (yes/no) or \"{quitCommand}\" to quit: ");
                string? input = Console.ReadLine()?.Trim().ToLower();

                // Handle invalid input and quitCommand input
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Error: invalid input");
                    continue;
                }
                if (input == quitCommand)
                {
                    Console.WriteLine("Returning to the previous task...");
                    return null;
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


    }
}