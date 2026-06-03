namespace Lab3.Denis
{
    public class Block2
    {
        public static bool TryAddEmptyRowAfterEveryEvenIndex(ref int[][] arr)
        {
            if (arr.Length == 0)
            {
                Console.WriteLine("Помилка: масив пустий");
                return false;
            }

            int rowsToAdd = (arr.Length + 1) / 2;
            int[][] newArr = new int[arr.Length + rowsToAdd][];

            int newIndex = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                newArr[newIndex] = arr[i];
                newIndex++;

                if (i % 2 == 0)
                {
                    newArr[newIndex] = [];
                    newIndex++;
                }
            }

            arr = newArr;
            return true;
        }

        public static void Run(ref int[][] arr)
        {
            bool success = TryAddEmptyRowAfterEveryEvenIndex(ref arr);
            
            if (success)
            {
                Console.WriteLine("\nУспішно додано нові рядки");
                Console.WriteLine("Оновлений масив: ");
                Functions.PrintJagIntArr(arr);
            }
        }
    }
}