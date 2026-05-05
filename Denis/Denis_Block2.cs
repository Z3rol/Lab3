namespace Lab3.Denis
{
    public class Block2
    {
        public static bool TryAddEmptyRowAfterEveryEvenIndex(ref int[][] arr)
        {
            int rowsToAdd = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (i % 2 == 0)
                    rowsToAdd++;
            }

            if (rowsToAdd == 0)
            {
                Console.WriteLine("No rows can be added");
                return false;        
            }

            int oldLength = arr.Length;
            int newLength = oldLength + rowsToAdd;

            Array.Resize(ref arr, newLength);

            int oldIndex = oldLength - 1;
            int newIndex = newLength - 1;

            while (oldIndex >= 0)
            {
                if (oldIndex % 2 == 0)
                {
                    arr[newIndex] = new int[0];
                    newIndex--;
                }
            
                arr[newIndex] = arr[oldIndex];
                oldIndex--;
                newIndex--;
            }

            return true;
        }

        public static void Run(ref int[][] arr)
        {
            bool isRunning = true;
            while (isRunning)
            {
                bool success = TryAddEmptyRowAfterEveryEvenIndex(ref arr);
                
                if (success)
                {
                    Console.WriteLine("Succesfully added new rows");
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