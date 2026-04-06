namespace Lab3
{
    public class Block2
    {
        /// <summary>
        /// Adds an empty row after each even row, overwrites the array
        /// </summary>
        /// <param name="arr">Array, to which new rows will be added</param>
        public static void AddEmptyRowAfterEveryEvenIndex(ref int[][] arr)
        {
            // Calculate the number of rows, that go after even indexes
            int rowsToAdd = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (i % 2 == 0)
                    rowsToAdd++;
            }

            // If no rows will be added => return immidiately
            if (rowsToAdd == 0)
            {
                Console.WriteLine("No rows were added.");
                return;
            }

            // Store the old length to calculate the index and calculate the length of the resized array
            int oldLength = arr.Length;
            int newLength = arr.Length + rowsToAdd;

            Array.Resize(ref arr, newLength);

            int oldIndex = oldLength - 1;
            int newIndex = newLength - 1;

            // Loops through each row, in the original array, add an empty line if the index is even
            while (oldIndex >= 0)
            {
                // Row is even => add an empty row
                if (oldIndex % 2 == 0)
                {
                    arr[newIndex] = new int[0];
                    newIndex--;
                }
            
                // Copy the previous row and move onto the next row
                arr[newIndex] = arr[oldIndex];
                oldIndex--;
                newIndex--;
            }
        }
    }
}