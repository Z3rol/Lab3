namespace Lab3.Denis
{
    public class Block1
    {
        public static (int T, int K) GetRequiredData()
        {
            int T = Functions.GetValidInt("Enter the amount of elements to delete");
            int K = Functions.GetValidInt("Enter the starting position");

            return (T, K);
        }

        /// <summary>
        /// Delete T elements starting from K-1 index in the passed array.
        /// </summary>
        public static bool TryDeleteArrayElements(ref int[] arr, int T, int K)
        {
            int startIndex = K - 1;

            if (startIndex < 0 || startIndex >= arr.Length)
            {
                Console.WriteLine("Error: starting position is outside the array.");
                return false;
            }

            if (startIndex + T > arr.Length)
                T = arr.Length - startIndex;

            for (int i = startIndex; i < arr.Length - T; i++)
                arr[i] = arr[i + T];

            Array.Resize(ref arr, arr.Length - T);

            return true;
        }

        public static void Run(ref int[] arr)
        {
            if(arr.Length == 0)
            {
                Console.WriteLine("Cannot work with empty arrays");
                return;
            }

            bool isRunning = true;
            while (isRunning)
            {
                (int T, int K) = GetRequiredData();

                bool success = TryDeleteArrayElements(ref arr, T, K);

                if (success)
                {
                    Console.WriteLine("Elements deleted successfully");
                    isRunning = false;
                }
                else
                {
                    bool retryChoice = Functions.GetConfirmation("Try again");

                    if (retryChoice)
                        continue;
                    else
                        isRunning = false;
                }
            }
        }
    }
}