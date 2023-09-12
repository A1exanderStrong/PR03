using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

/*
    ВАРИАНТ Б16
1. Ввести целое положительное трехзначное число N (N>0). Проверить истинность высказывания: 
    "Сумма всех цифр введенного числа равна произведению первой и третьей цифры введенного числа".

2. Дано вещественное число A и целое число N (N > 0). Вывести значение результата A в степени N:
    AN = A*A*...*A (число A перемножается N раз).

3. Дан целочисленный массив, состоящий из N элементов (N > 0).
    Найти максимальный и минимальный элемент в массиве и вычислить их сумму.

4. Дан целочисленный массив, состоящий из N элементов (N > 0).
    Проверить, чередуются ли в нем четные и нечетные числа. Если чередуются, то вывести 0, если нет,
    то вывести порядковый номер первого элемента, нарушающего закономерность.

5. Дан целочисленный массив, состоящий из N элементов (N > 0). 
    Найти сумму и произведение всех нечетных чисел из данного массива.
 */

namespace PR03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Задание 1
            uint number = 0;

        task1_Input:
            Console.WriteLine("Введите положительное трёхзначное число: ");
            try
            {
                number = Convert.ToUInt32(Console.ReadLine());
                if (number.ToString().Length != 3)
                {
                    Console.WriteLine("\nЧисло должно быть трёхзначным");
                    Console.WriteLine("\nНажмите любую клавишу для перезапуска задания...");
                    Console.ReadKey();
                    Console.Clear();
                    goto task1_Input;
                }
            }
            catch (OverflowException)
            {
                Console.WriteLine("\nВведено слишком большое число, либо отрицательное");
                Console.WriteLine("\nНажмите любую клавишу для перезапуска задания...");
                Console.ReadKey();
                Console.Clear();
                goto task1_Input;
            }
            catch (FormatException)
            {
                Console.WriteLine("\nНеверный формат ввода");
                Console.WriteLine("\nНажмите любую клавишу для перезапуска задания...");
                Console.ReadKey();
                Console.Clear();
                goto task1_Input;
            }

            uint[] numbersArray = new uint[3];

            for (int i = 0; i<3; i++)
            {
                numbersArray[i] = number % 10;
                number /= 10;
            }

            numbersArray.Reverse();
            uint numSumm = numbersArray[0] + numbersArray[1] + numbersArray[2];
            uint numComp = numbersArray[0] * numbersArray[2];

            if (numSumm == numComp) Console.WriteLine("\nИстина");
            else Console.WriteLine("\nЛожь");

            Console.WriteLine("\nДля продолжения нажмите любую клавишу...");
            Console.ReadKey();
            Console.Clear();
        #endregion

            #region Задание 2
            double A = 0.0f;
            int B = 0;

        task2_Input:
            Console.WriteLine("Последовательно введите 2 числа, сначала число, а затем его степень");
            try
            {
                Console.WriteLine("Введите число: ");
                A = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("\nВведите степень: ");
                B = Convert.ToInt32(Console.ReadLine());
            }
            catch (OverflowException)
            {
                Console.WriteLine("\nВведено слишком большое число, либо отрицательное");
                Console.WriteLine("\nНажмите любую клавишу для перезапуска задания...");
                Console.ReadKey();
                Console.Clear();
                goto task2_Input;
            }
            catch (FormatException)
            {
                Console.WriteLine("\nНеверный формат ввода");
                Console.WriteLine("\nНажмите любую клавишу для перезапуска задания...");
                Console.ReadKey();
                Console.Clear();
                goto task2_Input;
            }

            Console.WriteLine("\nОтвет: {0}", Math.Pow(A, B));

            Console.WriteLine("\nДля продолжения нажмите любую клавишу...");
            Console.ReadKey();
            Console.Clear();
            #endregion

            #region Задание 3
            uint elementsCount = 0;

        task3_Input:
            Console.WriteLine("Введите количество элементов массива");
            try
            {
                elementsCount = Convert.ToUInt32(Console.ReadLine());
                if (elementsCount == 0)
                {
                    Console.WriteLine("Количество элементов в массиве не может равняться нулю");
                    Console.WriteLine("\nНажмите любую клавишу для перезапуска задания...");
                    Console.ReadKey();
                    Console.Clear();
                    goto task3_Input;
                }
            }
            catch (OverflowException)
            {
                Console.WriteLine("\nВведено слишком большое число");
                Console.WriteLine("\nНажмите любую клавишу для перезапуска задания...");
                Console.ReadKey();
                Console.Clear();
                goto task3_Input;
            }
            catch (FormatException)
            {
                Console.WriteLine("\nНеверный формат ввода");
                Console.WriteLine("\nНажмите любую клавишу для перезапуска задания...");
                Console.ReadKey();
                Console.Clear();
                goto task3_Input;
            }

            int[] array = new int[elementsCount];
        task3_Input_arr:
            Console.WriteLine("Выберите способ заполнения массива: \n1. Вручную \n2. Автоматически");
            switch (Console.ReadLine())
            {
                case "1":
                    for (int i = 0; elementsCount > i; i++)
                    {
                        Console.WriteLine("Введите элемент массива #{0}", i);

                        try
                        {
                            array[i] = Convert.ToInt32(Console.ReadLine());
                        }
                        catch (OverflowException)
                        {
                            Console.WriteLine("\nВведено слишком большое число");
                            Console.WriteLine("\nНажмите любую клавишу для перезапуска задания...");
                            Console.ReadKey();
                            Console.Clear();
                            goto task3_Input_arr;

                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("\nНеверный формат ввода");
                            Console.WriteLine("\nНажмите любую клавишу для перезапуска задания...");
                            Console.ReadKey();
                            Console.Clear();
                            goto task3_Input_arr;
                        }

                    }
                    break;
                case "2":
                    Random randomNumber = new Random();
                    for (int i = 0; elementsCount > i; i++)
                    {
                        array[i] = randomNumber.Next();
                    }
                    break;
                default:
                    Console.WriteLine("Выбран некорректный вариант заполнения массива");
                    break;

            }

            int minNum = array.Min();
            int maxNum = array.Max();
            int arrSum = minNum + maxNum;

            Console.WriteLine("\nСумма максимального и минимального элементов массива = {0}", arrSum);
            Console.WriteLine("\nДля продолжения нажмите любую клавишу...");
            Console.ReadKey();
            Console.Clear();
            #endregion

            #region Задание 4
            uint elementsCount_task4 = 0;

        task4_Input:
            Console.WriteLine("Введите количество элементов массива");
            try
            {
                elementsCount_task4 = Convert.ToUInt32(Console.ReadLine());
                if (elementsCount_task4 == 0)
                {
                    Console.WriteLine("Количество элементов в массиве не может равняться нулю");
                    Console.WriteLine("\nНажмите любую клавишу для перезапуска задания...");
                    Console.ReadKey();
                    Console.Clear();
                    goto task4_Input;
                }
            }
            catch (OverflowException)
            {
                Console.WriteLine("\nВведено слишком большое, либо отрицательное число");
                Console.WriteLine("\nНажмите любую клавишу для перезапуска задания...");
                Console.ReadKey();
                Console.Clear();
                goto task4_Input;
            }
            catch (FormatException)
            {
                Console.WriteLine("\nНеверный формат ввода");
                Console.WriteLine("\nНажмите любую клавишу для перезапуска задания...");
                Console.ReadKey();
                Console.Clear();
                goto task4_Input;
            }

            int[] array_task4 = new int[elementsCount_task4];
        task4_Input_arr:
            Console.WriteLine("Выберите способ заполнения массива: \n1. Вручную \n2. Автоматически");
            switch (Console.ReadLine())
            {
                case "1":
                    for (int i = 0; elementsCount_task4 > i; i++)
                    {
                        Console.WriteLine("Введите элемент массива #{0}", i);

                        try
                        {
                            array_task4[i] = Convert.ToInt32(Console.ReadLine());
                        }
                        catch (OverflowException)
                        {
                            Console.WriteLine("\nВведено слишком большое число");
                            Console.WriteLine("\nНажмите любую клавишу для перезапуска задания...");
                            Console.ReadKey();
                            Console.Clear();
                            goto task4_Input_arr;

                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("\nНеверный формат ввода");
                            Console.WriteLine("\nНажмите любую клавишу для перезапуска задания...");
                            Console.ReadKey();
                            Console.Clear();
                            goto task4_Input_arr;
                        }

                    }
                    break;
                case "2":
                    Random randomNumber_task4 = new Random();
                    for (int i = 0; elementsCount_task4 > i; i++)
                    {
                        array_task4[i] = randomNumber_task4.Next();
                    }
                    break;
                default:
                    Console.WriteLine("Выбран некорректный вариант заполнения массива");
                    break;

            }

            bool parity = true;
            int numParityCheck = array_task4[0]%2;

            for (int i = 1; i < elementsCount_task4; i++)
            {
                if (array_task4[i] % 2 != numParityCheck) numParityCheck = array_task4[i] % 2;
                else 
                { 
                    Console.WriteLine("Чередование было нарушено на элементе под индексом = {0};", i); 
                    parity = false;
                    break; 
                }
            }

            if (parity) Console.WriteLine(0);
            Console.ReadKey();
            Console.Clear();
            #endregion

            #region Задание 5
            uint elementsCount_task5 = 0;

        task5_Input:
            Console.WriteLine("Введите количество элементов массива");
            try
            {
                elementsCount_task5 = Convert.ToUInt32(Console.ReadLine());
                if (elementsCount_task5 == 0)
                {
                    Console.WriteLine("Количество элементов в массиве не может равняться нулю");
                    Console.WriteLine("\nНажмите любую клавишу для перезапуска задания...");
                    Console.ReadKey();
                    Console.Clear();
                    goto task5_Input;
                }
            }
            catch (OverflowException)
            {
                Console.WriteLine("\nВведено слишком большое, либо отрицательное число");
                Console.WriteLine("\nНажмите любую клавишу для перезапуска задания...");
                Console.ReadKey();
                Console.Clear();
                goto task5_Input;
            }
            catch (FormatException)
            {
                Console.WriteLine("\nНеверный формат ввода");
                Console.WriteLine("\nНажмите любую клавишу для перезапуска задания...");
                Console.ReadKey();
                Console.Clear();
                goto task5_Input;
            }

            int[] array_task5 = new int[elementsCount_task5];
        task5_Input_arr:
            Console.WriteLine("Выберите способ заполнения массива: \n1. Вручную \n2. Автоматически");
            switch (Console.ReadLine())
            {
                case "1":
                    for (int i = 0; elementsCount_task5 > i; i++)
                    {
                        Console.WriteLine("Введите элемент массива #{0}", i);

                        try
                        {
                            array_task5[i] = Convert.ToInt32(Console.ReadLine());
                        }
                        catch (OverflowException)
                        {
                            Console.WriteLine("\nВведено слишком большое число");
                            Console.WriteLine("\nНажмите любую клавишу для перезапуска задания...");
                            Console.ReadKey();
                            Console.Clear();
                            goto task5_Input_arr;

                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("\nНеверный формат ввода");
                            Console.WriteLine("\nНажмите любую клавишу для перезапуска задания...");
                            Console.ReadKey();
                            Console.Clear();
                            goto task5_Input_arr;
                        }

                    }
                    break;
                case "2":
                    Random randomNumber_task5 = new Random();
                    for (int i = 0; elementsCount_task5 > i; i++)
                    {
                        array_task5[i] = randomNumber_task5.Next();
                    }
                    break;
                default:
                    Console.WriteLine("Выбран некорректный вариант заполнения массива");
                    break;

            }

            int nonParitySum = 0;
            int nonParityComp = 1;

            for (int i = 0; i < elementsCount_task5; i++)
            {
                if ((array_task5[i]%2) != 0) 
                { 
                    nonParitySum += array_task5[i];
                    nonParityComp *= array_task5[i];
                }
            }

            Console.WriteLine("Суммма всех нечётных чисел массива = {0} \nПроизведение всех нечётных чисел массива = {1}", nonParitySum, nonParityComp);
            Console.WriteLine("\nДля завершения работы нажмите любую клавишу...\n");
            Console.ReadKey();
            Console.Clear();
            #endregion

        }
    }
}
