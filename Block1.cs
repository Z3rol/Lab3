namespace Lab3
{
    public class Block1
    {
        /// <summary>
        /// Loop: until 2 valid numbers are entered, or quit
        /// </summary>
        /// <param name="quitCommand">Stops the loop if entered</param>
        /// <returns>tulip of 2 integers. null if quit</returns>
        public static (int T, int K)? GetRequiredData(string quitCommand = "q")
        {
            int? T = null;
            int? K = null;

            while (true)
            {
                // Get 2 integers
                if (T == null)
                    T = Functions.GetValidInt("Enter the amount of elements to delete");
                if (K == null)
                    K = Functions.GetValidInt("Enter the starting position");

                // Handles any incorrect values and quitCommand input
                if (T == null || K == null)
                {
                    bool? answer = Functions.GetConfirmation("One of the numbers was not entered correctly. Try again?");

                    if (answer == null || answer == false)
                    {
                        Console.WriteLine("Returning to the previous task...");
                        return null;
                    }
                    else continue;
                }

                return (T.Value, K.Value);
            }
        }

        /// <summary>
        /// Deletes T elements starting from K-1 index.
        /// </summary>
        /// <param name="arr">Array to delete elemenets from</param>
        /// <param name="T">Number of elements to delete</param>
        /// <param name="K">Starting position</param>
        /// <returns>New array with deleted elements. null if any indexes were wrong</returns>
        public static int[]? DeleteArrayElements(int[] arr, int T, int K)
        {
            // Transform starting position to 0-based
            int startIndex = K - 1;

            // Handle wrong starting position
            if (startIndex < 0 || startIndex >= arr.Length)
            {
                Console.WriteLine("Error: deletion range is out of bounds.");
                return null;
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

            return result;
        }
    }
}