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





        // Temporary Main functions
        public static void Start(int[]? arr, int[][]? jagArr)
        {
            Console.Clear();
            Console.WriteLine("--- Lab 3 ---");

            bool isRunning = true;
            while (isRunning)
            {

                PrintHeader();
                int choice = Functions.GetValidInt("Chose task", 0, 2);

                switch (choice)
                {
                    case 1:
                        ExecuteBlock1(ref arr, ref jagArr);
                        break;

                    case 2:
                        ExecuteBlock2(ref jagArr);
                        break;

                    case 0:
                    Console.WriteLine("Closing...");
                        isRunning = false;
                        break;
                }
            }
        }

        public static void PrintHeader()
        {
            Console.WriteLine(" 1. Delete T elements starting at index K from an array");
            Console.WriteLine(" 2. Add an empty row after every row with even index in a jagged array");
            Console.WriteLine(" 0. Close the program");
        }



        public static void ExecuteBlock1(ref int[]? arr, ref int[][]? jagArr)
        {
            int arrayChoice = Functions.GetValidInt("Would u like to work on a single array, or on a subarray of jagged", 1, 2);

            switch (arrayChoice)
            {
                case 1:
                    bool hasToGenerateArray = ShouldGenerateArr(arr);
                    if (hasToGenerateArray)
                    {
                        GenerateIntArrayByChoice(ref arr);
                    }

                    Block1.Run(ref arr);
                    Functions.PrintIntArr(arr);
                break;

                case 2:
                    bool hasToGenerateJagArray = ShouldGenerateJagArr(jagArr);
                    if (hasToGenerateJagArray)
                    {
                        GenerateJagIntArrByChoice(ref jagArr);
                    }

                    int subArrayNumber = Functions.GetValidInt("Chose which subarray to work with", 1, jagArr.Length);
                    Block1.Run(ref jagArr[subArrayNumber - 1]);
                    Functions.PrintJagIntArr(jagArr);
                break;
            }
        }

        public static void ExecuteBlock2(ref int[][]? jagArr)
        {
            bool hasToGenerateJagArray = ShouldGenerateJagArr(jagArr);
            if (hasToGenerateJagArray)
            {
                GenerateJagIntArrByChoice(ref jagArr);
            }

            Block2.Run(ref jagArr);
            Functions.PrintJagIntArr(jagArr);
        }



        public static void GenerateIntArrayByChoice(ref int[]? arr)
        {
            Console.WriteLine("Chose generation method");
            Console.WriteLine(" 1. Manually");
            Console.WriteLine(" 2. Randomly");
            int generationMethod = Functions.GetValidInt("Choice", 1, 2);

            switch (generationMethod)
            {
                case 1:
                    arr = Functions.GetValidIntArray("Enter array");
                    break;

                case 2:
                    int length = Functions.GetValidInt("Enter the length", 1, 100);
                    arr = Functions.GenerateRandomIntArr(length, 1, 10000);
                    break;
            }
        }

        public static void GenerateJagIntArrByChoice(ref int[][]? arr)
        {
            Console.WriteLine("Chose generation method");
            Console.WriteLine(" 1. Manually");
            Console.WriteLine(" 2. Randomly");
            int generationMethod = Functions.GetValidInt("Choice", 1, 2);

            switch (generationMethod)
            {
                case 1:
                    arr = Functions.GetValidJagIntArr();
                    break;

                case 2:
                    int length = Functions.GetValidInt("Enter the number of rows", 1, 100);
                    arr = Functions.GenerateRandomJagIntArr(length, 1, 10);
                    break;
            }
        }



        public static bool ShouldGenerateArr(int[]? arr)
        {
            bool hasToGenerateArray = true;
            if (arr != null)
            {
                Console.WriteLine("Current array: ");
                Functions.PrintIntArr(arr);
                hasToGenerateArray = !Functions.GetConfirmation("Would u like to continue with it");
            }

            if (hasToGenerateArray)
            {
                return true;
            }

            return false;
        }

        public static bool ShouldGenerateJagArr(int[][]? jagArr)
        {
            bool hasToGenerateArray = true;
            if (jagArr != null)
            {
                Console.WriteLine("Current jagged array: ");
                Functions.PrintJagIntArr(jagArr);
                hasToGenerateArray = !Functions.GetConfirmation("Would u like to continue with it");
            }

            if (hasToGenerateArray)
            {
                return true;
            }

            return false;
        }
    }
}