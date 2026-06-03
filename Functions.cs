namespace Lab3
{
    public class Functions
    {
        // Input helper methods
        public static int GetValidInt(string message, int min = int.MinValue, int max = int.MaxValue)
        {
            while (true)
            {
                Console.Write(
                    (min == int.MinValue, max == int.MaxValue) switch
                    {
                        (true, true) => $"{message}: ",
                        (true, false) => $"{message} ({min}+): ",
                        (false, true)  => $"{message} ({min}+): ",
                        (false, false) => $"{message} ({min}-{max}): "
                    }
                );

                string? input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("\nПомилка: введення не може бути пустим");
                    continue;
                }

                if (!int.TryParse(input, out int num))
                {
                    Console.WriteLine("\nПомилка: Введено некоректне число");
                    continue;
                }

                if (num < min || num > max)
                {
                    Console.WriteLine($"\nПомилка: число виходить за межі ({min}-{max})");
                    continue;
                }

                return num;
            }
        }

        public static int[] GetValidIntArray(string message, int minLength = 1, int maxLength = 100)
        {
            while (true)
            {
                Console.Write($"{message}: ");
                string? input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Помилка: введення не може бути пустим");
                    continue;
                }

                string[] splitInput = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (splitInput.Length < minLength || splitInput.Length > maxLength)
                {
                    Console.WriteLine($"Помилка: довжина виходить за межі ({minLength}-{maxLength})");
                    continue;
                }

                int[] arr = new int[splitInput.Length];
                bool allNumbersParsed = true;

                for (int i = 0; i < splitInput.Length; i++)
                {
                    if (!int.TryParse(splitInput[i], out arr[i]))
                    {
                        Console.WriteLine($"Помилка: {splitInput[i]} не є числом");
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
            int size = GetValidInt("Введіть кількість рядків", 1, 10);
            
            int[][] jagArr = new int[size][];

            for (int i = 0; i < size; i++)
                jagArr[i] = GetValidIntArray($"Введіть рядок №{i}");

            return jagArr;
        }



        // Array generation methods
        public static int[] GenerateRandomIntArr(int length, int minValue = int.MinValue, int maxValue = int.MaxValue)
        {
            int[] arr = new int[length];
            for (int i = 0; i < length; i++)
                arr[i] = Random.Shared.Next(minValue, maxValue + 1);

            return arr;
        }

        public static int[][] GenerateRandomJagIntArr(int numberOfRows, int minNumberOfElements = 0, int maxNumberOfelements = 100, int minValue = int.MinValue, int maxValue = int.MaxValue)
        {
            int[][] arr = new int[numberOfRows][];

            for (int i = 0; i < numberOfRows; i++)
                arr[i] = GenerateRandomIntArr(Random.Shared.Next(minNumberOfElements, maxNumberOfelements + 1), minValue, maxValue) ?? [];

            return arr;
        }


        // Print methods
        public static void PrintJagIntArr(int[][] jagArr)
        {
            for (int i = 0; i < jagArr.Length; i++)
                Console.WriteLine(string.Join(' ', jagArr[i]));
        }
    }
}