namespace Lab3.Misha
{
    public class Block2
    {
        /// <summary>
        /// Знаходить індекс рядка з мінімальним елементом.
        /// Якщо таких рядків кілька — береться останній.
        /// </summary>
        // повертає і індекс рядка і саме мінімальне значення
        private static (int lastMinRow, int minVal) FindLastMinRowIndex(int[][] arr)
        {
            int minVal = arr[0][0];

            for (int i = 0; i < arr.Length; i++)
                for (int j = 0; j < arr[i].Length; j++)
                    if (arr[i][j] < minVal)
                        minVal = arr[i][j];

            int lastMinRow = -1;
            for (int i = 0; i < arr.Length; i++)
                for (int j = 0; j < arr[i].Length; j++)
                    if (arr[i][j] == minVal)
                        lastMinRow = i;

            return (lastMinRow, minVal);
        }

        public static bool TryInsertRowAfterMinRow(ref int[][] arr)
        {
            if (arr == null || arr.Length == 0)
            {
                Console.WriteLine("Помилка: масив порожній.");
                return false;
            }

            (int minRowIndex, int minVal) = FindLastMinRowIndex(arr);

            // Виводимо інформацію про знайдений мінімум
            Console.WriteLine($"Мінімальний елемент: {minVal}, знайдено в рядку з індексом: {minRowIndex}.");

            Array.Resize(ref arr, arr.Length + 1);

            for (int i = arr.Length - 1; i > minRowIndex + 1; i--)
                arr[i] = arr[i - 1];

            arr[minRowIndex + 1] = new int[0];

            return true;
        }

        public static void Run(ref int[][] arr)
        {
            if (arr == null || arr.Length == 0)
            {
                Console.WriteLine("Неможливо працювати з порожнім масивом.");
                return;
            }

            bool success = TryInsertRowAfterMinRow(ref arr);

            if (success)
            {
                Console.WriteLine("\nУспішно додано рядок після рядка з мінімальним елементом.");
                Console.WriteLine("Оновлений масив: ");
                Functions.PrintJagIntArr(arr);
            }
        }
    }
}