namespace Lab3
{
    public class Block2
    {
        /// <summary>
        /// Adds an empty row after each even row, overwrites the array
        /// </summary>
        /// <param name="arr">Array, to which new rows will be added</param>
        public static bool TryAddEmptyRowAfterEveryEvenIndex(ref int[][] arr)
        {
            // Calculate the number of even indexes, to add rows of the same number
            int rowsToAdd = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (i % 2 == 0)
                    rowsToAdd++;
            }

            // If no rows should be added => return immidiately
            if (rowsToAdd == 0)
            {
                
                return false;        
            }

            // Store the old length to calculate the index and length of the resized array
            int oldLength = arr.Length;
            int newLength = arr.Length + rowsToAdd;

            Array.Resize(ref arr, newLength);

            int oldIndex = oldLength - 1;
            int newIndex = newLength - 1;

            // Loops through each row in the original array, add an empty line if the index is even
            while (oldIndex >= 0)
            {
                // Index is even => add an empty row
                if (oldIndex % 2 == 0)
                {
                    arr[newIndex] = new int[0];
                    newIndex--;
                }
            
                // Copy the previous row and move onto the next
                arr[newIndex] = arr[oldIndex];
                oldIndex--;
                newIndex--;
            }

            return true;
        }

        /// <summary>
        /// Loops until succed or user quit. Tries to add new rows into jagged array
        /// </summary>
        /// <param name="arr"></param>
        public static void Run(ref int[][] arr)
        {
            bool isRunning = true;
            while (isRunning)
            {
                // Try add new rows
                bool success = TryAddEmptyRowAfterEveryEvenIndex(ref arr);
                
                // If success print success message and quit, otherwise ask to retry
                if (success)
                {
                    Console.WriteLine("Succesfully added new rows");
                    isRunning = false;
                }
                else
                {
                    bool retryChoice = Functions.GetConfirmation("Try again");

                    // If user wants to retry => continue, otherwise quit
                    if (retryChoice)
                        continue;
                    else
                        isRunning = false;
                }
            }
        }
    }
}