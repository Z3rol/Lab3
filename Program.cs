using System.Text;


namespace Lab3
{
    public class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            
            int[][] jagArr = [];

            Start(ref jagArr);
        }

        static void Start(ref int[][] jagArr)
        {
            Console.Clear();
            PrintHeader();

            jagArr = GenerateArr();

            bool isrunning = true;
            while (isrunning)
            {

                PrintMenu();
                int choice = Functions.GetValidInt("Ваш вибір: ", 0, 3);

                switch (choice)
                {
                    case 1:
                        ExecuteDenisBlock2(ref jagArr);
                    break;
                    
                    case 2:
                        ExecuteMishaBlock2(ref jagArr);
                    break;

                    case 3:
                        jagArr = GenerateArr();
                    break;

                    case 0:
                        isrunning = false;
                    break;
                }
            }
        }

        

        static void ExecuteDenisBlock2(ref int[][] jagArr)
        {
            Denis.Block2.Run(ref jagArr);
        }

        static void ExecuteMishaBlock2(ref int[][] jagArr)
        {
            Misha.Block2.Run(ref jagArr);
        }



        // UI
        static void PrintHeader()
        {
            Console.WriteLine("--- Лабораторна №3 ---", -8);
            Console.WriteLine("+---------+---------+");
            Console.WriteLine("| Ім'я    | Варіант |");
            Console.WriteLine("+---------+---------+");
            Console.WriteLine($"| {"Денис",-7} | {"10", -8} |");
            Console.WriteLine($"| {"Михайло",-7} | {"14", -8} |");
            Console.WriteLine("+---------+---------+\n");
        }

        static void PrintMenu()
        {
            Console.WriteLine(" 1. Додати по одному порожньому рядку після кожного парного рядка зубчастого масиву (тобто, кожного рядка, що y початковій матриці мав парний номер)");
            Console.WriteLine(" 2. Додати рядок після рядка, що містить мінімальний елемент (якщо y різних місцях є кілька елементів з однаковим мінімальним значенням, то брати останній з них)");
            Console.WriteLine(" 3. Згенерувати новий масив");
            Console.WriteLine(" 0. Закрити");
        }



        static int[][] GenerateArr()
        {
            Console.WriteLine("\nОберіть спосіб створення масиву");
            Console.WriteLine(" 1. Вручну");
            Console.WriteLine(" 2. Випадково");

            int choice = Functions.GetValidInt("Ваш вибір", 1, 2);

            int[][] arr = [];

            switch (choice)
            {
                case 1: 
                    arr = Functions.GetValidJagIntArr();
                break;

                case 2:
                    arr = Functions.GenerateRandomJagIntArr(Functions.GetValidInt("Введіть кількість рядків"));
                    Console.WriteLine("\n Створений масив");
                    Functions.PrintJagIntArr(arr);
                break;
            }

            return arr;
        }
    }
}