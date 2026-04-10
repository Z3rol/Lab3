namespace Lab3
{
    public class Program
    {
        public static void PrintHeader()
        {
            Console.WriteLine(" 1. Delete T elements starting at index K from an array"); // Var 5
            Console.WriteLine(" 2. Add an empty row after every row with even index in a jagged array"); // Var 10
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

            // If arr == null, or user decides to generate a new one
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

            // If arr == null, or user decides to generate a new one
            if (hasToGenerateArray)
            {
                return true;
            }

            return false;
        }

        // Generates array if has to, does all block1 tasks and prints changed array
        // Differrent arrays are passed, because it can work on a single array or on a subarray of jagged
        public static void ExecuteBlock1(ref int[]? arr, ref int[][]? jagArr)
        {
            // Chose to work with a single array, or with a subarray of jagged
            int arrayChoice = Functions.GetValidInt("Would u like to work on a single array, or on a subarray of jagged", 1, 2);

            switch (arrayChoice)
            {
                // Single array case
                case 1:
                    // If array is null or user decides to generate a new one
                    bool hasToGenerateArray = ShouldGenerateArr(arr);
                    if (hasToGenerateArray)
                    {
                        GenerateIntArrayByChoice(ref arr);
                    }

                    Block1.Run(ref arr);
                    Functions.PrintIntArr(arr);
                break;

                // Subarray of a jagged array case
                case 2:
                    // If array is null or user decides to generate a new one
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

        // Generates array if has to, does all block2 tasks and prints changed array
        public static void ExecuteBlock2(ref int[][]? jagArr)
        {
            // If array is null or user decides to generate a new one - generate
            bool hasToGenerateJagArray = ShouldGenerateJagArr(jagArr);
            if (hasToGenerateJagArray)
            {
                GenerateJagIntArrByChoice(ref jagArr);
            }

            // Execute block2 and print changed jagArr
            Block2.Run(ref jagArr);
            Functions.PrintJagIntArr(jagArr);
        }

        public static void Main(string[] args)
        {
            int[]? arr = null;
            int[][]? jagArr = null;
            bool isRunning = true;

            Console.Clear();
            Console.WriteLine("--- Lab 3 ---");
            while (isRunning)
            {

                // Print menu and read choice
                PrintHeader();
                int choice = Functions.GetValidInt("Chose task", 1, 2);

                // Execute function based or choice
                switch (choice)
                {
                    // Execute block1
                    case 1:
                        ExecuteBlock1(ref arr, ref jagArr);
                        break;

                    // Execute block2
                    case 2:
                        ExecuteBlock2(ref jagArr);
                        break;
                }

                // Continue or stop the program, decided by user
                bool shouldContinue = Functions.GetConfirmation("Do u want to continue");
                if (shouldContinue == false)
                {
                    Console.WriteLine("Closing...");
                    isRunning = false;
                }
            }
        }
    }
}