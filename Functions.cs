namespace Lab3
{
    public class Functions
    {
        // Input helper methods
        public static int GetValidInt(string message, int min = int.MinValue, int max = int.MaxValue)
        {
            while (true)
            {
                if (min == int.MinValue && max == int.MaxValue)
                    Console.Write($"{message}: ");
                else
                    Console.Write($"{message} ({min}-{max}): ");

                string? input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Error: invalid format");
                    continue;
                }

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

        public static int[] GetValidIntArray(string message, int minLength = 1, int maxLength = 100)
        {
            while (true)
            {
                Console.Write($"{message} (length: {minLength}-{maxLength}): ");
                string? input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Error: invalid format");
                    continue;
                }

                string[] splitInput = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (splitInput.Length < minLength || splitInput.Length > maxLength)
                {
                    Console.WriteLine("Error: invalid number of elements");
                    continue;
                }

                int[] arr = new int[splitInput.Length];
                bool allNumbersParsed = true;

                for (int i = 0; i < splitInput.Length; i++)
                {
                    if (!int.TryParse(splitInput[i], out arr[i]))
                    {
                        Console.WriteLine($"Error: {splitInput[i]} is not a valid number");
                        allNumbersParsed = false;
                        break;
                    }
                }

                if (allNumbersParsed)
                    return arr;
            }
        }

        public static int[][] GetValidJagIntArr()
        {
            int size = GetValidInt("Enter the number of rows", 1, 10);
            
            int[][] jagArr = new int[size][];

            for (int i = 0; i < size; i++)
                jagArr[i] = GetValidIntArray($"Enter row №{i}");

            return jagArr;
        }

        public static bool GetConfirmation(string message)
        {
            while (true)
            {
                Console.Write($"{message} (yes/no): ");
                string? input = Console.ReadLine()?.Trim().ToLower();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Error: invalid input");
                    continue;
                }

                if (input == "yes")
                    return true;
                else if (input == "no")
                    return false;
                else
                    Console.WriteLine($"Error: {input} is not a valid choice");
            }
        }


        // Array generation methods
        public static int[] GenerateRandomIntArr(int length, int minValue = int.MinValue, int maxValue = int.MaxValue)
        {
            int[] arr = new int[length];
            for (int i = 0; i < length; i++)
                arr[i] = Random.Shared.Next(minValue, maxValue + 1);

            return arr;
        }

        public static int[][] GenerateRandomJagIntArr(int numberOfRows, int minNumberOfElements, int maxNumberOfelements, int minValue = int.MinValue, int maxValue = int.MaxValue)
        {
            int[][] arr = new int[numberOfRows][];

            for (int i = 0; i < numberOfRows; i++)
                arr[i] = GenerateRandomIntArr(Random.Shared.Next(minNumberOfElements, maxNumberOfelements + 1), minValue, maxValue) ?? [];

            return arr;
        }


        // Print methods
        public static void PrintIntArr(int[] arr)
        {
            Console.WriteLine(string.Join(' ', arr));
        }

        public static void PrintJagIntArr(int[][] jagArr)
        {
            for (int i = 0; i < jagArr.Length; i++)
                Console.WriteLine(string.Join(' ', jagArr[i]));
        }
    }
}