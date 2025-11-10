using System;
using System.Collections.Generic;

namespace Lab3
{
    class Program
    {
        //Рахує кількість цифр в n та повертає список з усіма цифрами і кількість цифр
        static void CalcNumberOfDigits(int n, out List<int> listOfDigits, out int number)
        {
            n = Math.Abs(n);
            listOfDigits = new List<int>();

            if (n > 0)
            {
                while (n > 0)
                {
                    listOfDigits.Add(n % 10);

                    n /= 10;
                }

                number = listOfDigits.Count;
            }
            else
            {
                listOfDigits.Add(0);
                number = 1;
            }

        }
        //Приводить всі цифри до заданого степеню та повертає суму всіх результатів
        static void CalcOfDigitsPowers(List<int> listOfDigits, int number, out int digitsSum)
        {
            digitsSum = 0;

            if (number > 1)
            {
                foreach (int digit in listOfDigits)
                {
                    digitsSum += (int)Math.Pow(digit, number);
                }
            }
            else
            {
                foreach (int num in listOfDigits)
                {
                    digitsSum += num;
                }
            }
        }
        //Викликає CalcNumberOfDigits і CalcOfDigitsPowers та повертає true якщо це число Армстронга та false якщо ні
        static void IsArmstrongNumber(int n, out bool isArmstrong)
        {
            int nOriginal = n;

            CalcNumberOfDigits(n, out List<int> listOfDigits, out int number);
            CalcOfDigitsPowers(listOfDigits, number, out int digitsSum);

            isArmstrong = nOriginal == digitsSum;
        }
        //Виводить всі числа Армстронга з диапазону [2, n]
        static void PrintAllArmstrongNumbers(int n)
        {
            for (int i = 2; i <= n; i++)
            {
                IsArmstrongNumber(i, out bool isArmstrong);

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
                    bool validNumber = false;

                    do
                    {
                        if (n >= 2)
                        {
                            Console.WriteLine($"Вивожу всі числа армстронга в диапазоні [2, {n}]");
                            PrintAllArmstrongNumbers(n);

                            isRunning = false;
                        }
                        else
                        {
                            Console.WriteLine("Число повинне бути не меньше ніж 2");
                        }
                    } while (validNumber = false);
                }
                else
                {
                    Console.WriteLine("Невірне введення.");
                }
            } while (isRunning);
        }
    }
}