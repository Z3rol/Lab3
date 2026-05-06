namespace Lab3.Denis
{
    public class Program
    {
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