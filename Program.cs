using System;
using System.Collections.Generic;

namespace Lab3
{
    class Program
    {
        //Рахує кількість цифр в n та повертає список з усіма цифрами і кількість цифр
        static void CalcNumberOfDigits(int originalN, out List<int> listOfDigits, out int digitCount)
        {
            int n = Math.Abs(originalN);
            listOfDigits = new List<int>();

            if (n > 0)
            {
                while (n > 0)
                {
                    listOfDigits.Add(n % 10);

                    n /= 10;
                }

                digitCount = listOfDigits.Count;
            }
            else
            {
                listOfDigits.Add(0);
                digitCount = 1;
            }

        }
        //Приводить всі цифри до заданого степеню та повертає суму всіх результатів
        static void CalcSumOfDigitsPowers(List<int> listOfDigits, int digitsCount, out long digitsSum)
        {
            digitsSum = 0;

            foreach (int digit in listOfDigits)
            {
                digitsSum += (long) Math.Pow(digit, digitsCount);
            }
        }
        //Викликає CalcNumberOfDigits і CalcOfDigitsPowers та повертає true якщо це число Армстронга та false якщо ні
        static bool IsArmstrongNumber(int n)
        {
            int nOriginal = n;

            CalcNumberOfDigits(n, out List<int> listOfDigits, out int number);
            CalcSumOfDigitsPowers(listOfDigits, number, out long digitsSum);

            return nOriginal == digitsSum;
        }
        //Виводить всі числа Армстронга з диапазону [2, n]
        static void PrintAllArmstrongNumbers(int n)
        {
            for (int i = 2; i <= n; i++)
            {
                bool isArmstrong = IsArmstrongNumber(i);

                if (isArmstrong)
                    Console.WriteLine(i);
            }
        }
        static void Main(string[] args)
        {
            bool isRunning = true;

            Console.Clear();

            do
            {
                Console.Write("Введіть число: ");

                if (int.TryParse(Console.ReadLine(), out int n))
                {
                    if (n >= 2)
                    {
                        Console.WriteLine($"Вивожу всі числа армстронга в диапазоні [2, {n}]");
                        PrintAllArmstrongNumbers(n);

                        isRunning = false;
                    }
                    else
                    {
                        Console.WriteLine("Число не може бути менше ніж 2");
                    }
                }
                else
                {
                    Console.WriteLine("Невірне введення.");
                }
            } while (isRunning);
        }
    }
}