namespace Lab3
{
    public class Program
    {
        static void Main()
        {
            int[]? arr = null;
            int[][]? jagArr = null;

            Start(ref arr, ref jagArr);
        }

        public static void Start(ref int[] arr, ref int[][] jagArr)
        {
            PrintHeader();

            bool isrunning = true;
            while (isrunning)
            {
                PrintMenu();
                int choice = Functions.GetValidInt("Your choice: ", 0, 6);

                switch (choice)
                {
                    case 1:
                        ExecuteDenisBlock1();
                    break;
                    
                    case 2:
                        ExecuteDenisBlock2();
                    break;

                    case 3:
                        ExecuteMishaBlock1();
                    break;

                    case 4:
                        ExecuteMishaBlock2();
                    break;

                    case 5:
                        ExecuteIllyaBlock1();
                    break;

                    case 6:
                        ExecuteIllyaBlock2();
                    break;

                    case 0:
                        isrunning = false;
                    break;
                }
            }
        }

        public static void PrintHeader()
        {
            Console.WriteLine("+---------+----------+-------+");
            Console.WriteLine("| Name    | Variants | Tasks |");
            Console.WriteLine("+---------+----------+-------+");
            Console.WriteLine($"| {"Denis",-7} | {"5, 10", -8} | {"1, 2", -5} |");
            Console.WriteLine($"| {"Misha",-7} | {"", -8} | {"3, 4", -5} |");
            Console.WriteLine($"| {"Illya",-7} | {"", -8} | {"5, 6", -5} |");
            
            Console.WriteLine("+---------+----------+-------+");
        }

        public static void PrintMenu()
        {
            Console.WriteLine(" 1. Delete T elements starting at index K from an array");
            Console.WriteLine(" 2. Add an empty row after every row with even index in a jagged array");
            Console.WriteLine(" 3. ");
            Console.WriteLine(" 4. ");
            Console.WriteLine(" 5. ");
            Console.WriteLine(" 6. ");
            Console.WriteLine(" 0. Close the program");
        }

        // Denis tasks
        public static void ExecuteDenisBlock1()
        {
            
        }

        public static void ExecuteDenisBlock2()
        {
            
        }

        // Misha tasks
        public static void ExecuteMishaBlock1()
        {
            
        }

        public static void ExecuteMishaBlock2()
        {
            
        }

        // Illya tasks
        public static void ExecuteIllyaBlock1()
        {
            
        }

        public static void ExecuteIllyaBlock2()
        {
            
        }


        public static void HandleArrayGeneration(ref int[]? arr, ref int[][]? jagArr)
        {
            
        }




        public static bool ShouldGenerateArr<T>(T? arr)
        {
            if (arr == null) return true;

            if (arr is int[] standardArr)
            {
                Console.WriteLine("\nCurrent array:");
                Functions.PrintIntArr(standardArr);
            }
            else if (arr is int[][] jaggedArr)
            {
                Console.WriteLine("\nCurrent jagged array:");
                Functions.PrintJagIntArr(jaggedArr);
            }
            else
            {
                throw new ArgumentException($"Error: type {typeof(T).Name} is not supported. You must pass int[] or int[][]");
            }

            return !Functions.GetConfirmation("Would you like to continue with it");
        }
    }
}