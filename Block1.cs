namespace Lab3
{
    internal class Block1
    {
        /// <summary>
        /// Loop: until 2 valid numbers are entered, or quit
        /// </summary>
        /// <param name="quitCommand">Stops the loop if entered</param>
        /// <returns>tuple of 2 integers. null if quit</returns>
        internal static (int T, int K)? GetRequiredData(string quitCommand = "q")
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

                // Handles any incorrect values and quit case
                // Allow user to re-enter or leave
                if (T == null || K == null)
                {
                    bool? answer = Functions.GetConfirmation("One of the numbers was not entered correctly. Try again?");

                    if (answer == null || answer == false)
                    {
                        Console.WriteLine("Returning...");
                        return null;
                    }
                    else continue;
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
        internal static bool TryDeleteArrayElements(ref int[] arr, int T, int K)
        {
            // Handle empty array
            if (arr.Length == 0)
            {
                Console.WriteLine("Error: cannot work with an empty array");
                return false;
            }
            // Transform starting position to 0-based
            int startIndex = K - 1;

            // Handle wrong starting position
            if (startIndex < 0 || startIndex >= arr.Length)
            {
                Console.WriteLine("Error: starting position is out of bounds.");
                return false;
            }

            // Shrink number of elements to delete, to avoid getting out of the array
            if (startIndex + T > arr.Length)
                T = arr.Length - startIndex;

            int[] result = new int[arr.Length - T];

            // Copy all elements before the deleted ones
            for (int i = 0; i < startIndex; i++)
                result[i] = arr[i];

            // Copy all elements after the deleted ones
            for (int i = startIndex; i < result.Length; i++)
                result[i] = arr[i + T];

            arr = result;
            return true;
        }

        /// <summary>
        /// Tries to get required values, if all succeds - deletes rows from array, otherwise - quits
        /// </summary>
        /// <param name="arr">Array from which elements will be deleted</param>
        internal static void Run(ref int[] arr)
        {
            // Try get required tuple of required integers
            var data = GetRequiredData();

            // Handle quit case
            if (data == null) return;

            // Deletes elements, if both values are good
            bool success = TryDeleteArrayElements(ref arr, data.Value.T, data.Value.K);

            // Print success message
            if (success)
                Console.WriteLine("Elements deleted successfully");
        }
    }
}