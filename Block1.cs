namespace Lab3
{
    public class Block1
    {
        // Get tuple of valid numbers requrired for TryDeleteArrayElemenets
        public static (int T, int K) GetRequiredData()
        {
            // Fill data with valid numbers
            int T = Functions.GetValidInt("Enter the amount of elements to delete");
            int K = Functions.GetValidInt("Enter the starting position");

            return (T, K);
        }

        /// <summary>
        /// Deletes T elements starting from K-1 index in the passed array.
        /// </summary>
        /// <param name="arr">Array to delete elemenets from</param>
        /// <param name="T">Number of elements to delete</param>
        /// <param name="K">Starting position</param>
        /// <returns>Determines whether the task was completed</returns>
        public static bool TryDeleteArrayElements(ref int[] arr, int T, int K)
        {
            // Transform starting position to 0-based
            int startIndex = K - 1;

            // Handle starting position being outside the array
            if (startIndex < 0 || startIndex >= arr.Length)
            {
                Console.WriteLine("Error: starting position is outside the array.");
                return false;
            }

            // Shrink number of elements to delete, to avoid getting out of the array
            if (startIndex + T > arr.Length)
                T = arr.Length - startIndex;

            // Move all non-deleted elements to the left to fill deleted ones
            for (int i = startIndex; i < arr.Length - T; i++)
                arr[i] = arr[i + T];

            // Shrink the array, deleting all removed elements
            Array.Resize(ref arr, arr.Length - T);

            return true;
        }

        /// <summary>
        /// Loops until success or user quits. Gets required data and tries to remove elements
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

            // Loop utntil success, or user quits
            bool isRunning = true;
            while (isRunning)
            {
                // Try get tuple of required numbers
                (int T, int K) = GetRequiredData();

                // Delete elements, if both values are valid
                bool success = TryDeleteArrayElements(ref arr, T, K);

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