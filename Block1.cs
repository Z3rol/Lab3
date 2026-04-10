namespace Lab3
{
    public class Block1
    {
        /// <summary>
        /// Loop: until 2 valid numbers are entered
        /// </summary>
        /// <returns>tuple of 2 integers</returns>
        public static (int T, int K) GetRequiredData()
        {
            int? T = null;
            int? K = null;

            while (true)
            {
                // Try to fill T and K with integres
                if (T == null)
                    T = Functions.GetValidInt("Enter the amount of elements to delete");
                if (K == null)
                    K = Functions.GetValidInt("Enter the starting position");

                // Handles any incorrect values and asks to re-enter
                if (T == null || K == null)
                {
                    Console.WriteLine("Error: one of the numbers wasn't entered corecctly. Try again");
                    continue;
                }

                return (T.Value, K.Value);
            }
        }

        /// <summary>
        /// Deletes T elements starting from K-1 index in the passed array Directly.
        /// </summary>
        /// <param name="arr">Array to delete elemenets from</param>
        /// <param name="T">Number of elements to delete</param>
        /// <param name="K">Starting position</param>
        /// <returns>Bool based on whether the task was completed</returns>
        public static bool TryDeleteArrayElements(ref int[] arr, int T, int K)
        {
            // Handle empty array
            if (arr.Length == 0)
            {
                Console.WriteLine("Error: cannot delete elements from an empty array");
                return false;
            }

            // Transform starting position to 0-based
            int startIndex = K - 1;

            // Handle starting position being ouside the array
            if (startIndex < 0 || startIndex >= arr.Length)
            {
                Console.WriteLine("Error: starting position is out of bounds.");
                return false;
            }

            // Shrink number of elements to delete, to avoid getting out of the array
            if (startIndex + T > arr.Length)
                T = arr.Length - startIndex;

            int[] result = new int[arr.Length - T];

            // Copy all elements before the deleted ones if any
            for (int i = 0; i < startIndex; i++)
                result[i] = arr[i];

            // Copy all elements after the deleted ones if any
            for (int i = startIndex; i < result.Length; i++)
                result[i] = arr[i + T];

            arr = result;
            return true;
        }

        /// <summary>
        /// Loops until succed or user quit. Gets required data and tries to remove elements
        /// </summary>
        /// <param name="arr">Array from which elements will be deleted</param>
        public static void Run(ref int[] arr)
        {
            // Handle empty array
            if(arr.Length == 0)
            {
                Console.WriteLine("Cannot work with empty arrays");
                return;
            }

            bool isRunning = true;
            while (isRunning)
            {
                // Try get tuple of required integers
                var data = GetRequiredData();

                // Deletes elements, if both values are valid
                bool success = TryDeleteArrayElements(ref arr, data.T, data.K);

                // If success print success message and quit, otherwise ask to retry
                if (success)
                {
                    Console.WriteLine("Elements deleted successfully");
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