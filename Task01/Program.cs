using System;
using System.IO;

/*
 * По массиву A целых чисел со значениями из диапазона [-10;10] создать массив булевских значений L.
 * Количество элементов в массивах совпадает.
 * На местах неотрицательных элементов в массиве A
 * в массиве L стоят значения true, на месте отрицательных – false.
 * Если хотя бы один из элементов массива А находится вне заданного диапазона - выводить Incorrect Input
 * в консоль. Гарантируется, что на вход подается N целых чисел.
 *
 * Пример входных данных:
 * 0 -1
 *
 * Пример выходных данных:
 * true false
 */

namespace _01_07_Files
{
    class Program
    {
        private const string inputPath = "input.txt";
        private const string outputPath = "output.txt";
        
        static int[] ReadFile(string path)
        {
            // TODO: implement this method
            string text = File.ReadAllText(path);
            string[] array = text.Split();
            int[] result = new int[array.Length];

            for (int elem = 0; elem < array.Length; ++elem)
                int.TryParse(array[elem], out result[elem]);

            return result;
        }

        static bool CheckArray(int[] array)
        {
            // TODO: implement this method
            for (int elem = 0; elem < array.Length; ++elem)
                if (array[elem] < -10 || array[elem] > 10)
                    return false;

            return true;
        }
        
        static bool[] IntToBoolArray(int[] array)
        {
            // TODO: implement this method
            bool[] result = new bool[array.Length];
            for (int elem = 0; elem < array.Length; ++elem)
            {
                if (array[elem] >= 0)
                    result[elem] = true;
                else result[elem] = false;
            }

            return result;
        }
        
        static void WriteFile(string path, bool[] array)
        {
            // TODO: implement this method
            string text = null;
            for (int elem = 0; elem < array.Length; ++elem)
            {
                if (array[elem]) text += "true ";
                else text += "false ";
            }
            File.WriteAllText(path, text);
        }

        // you do not need to fill your file, you can work with console input
        static void Main(string[] args)
        {
            // do not touch
            FillFile();
            
            int[] A;
            bool[] L;
            
            try
            {
                A = ReadFile(inputPath);
                
                if (!CheckArray(A))
                // TODO: implement this case
                {
                    Console.WriteLine("Incorrect Input");
                    Environment.Exit(0);
                }
                
                L = IntToBoolArray(A);
                WriteFile(outputPath, L);
            }
            // TODO: catch with meaningful message
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            
            // do not touch
            ConsoleOutput();
        }

        #region Testing methods for Github Classroom, do not touch!

        static void FillFile()
        {
            try
            {
                File.WriteAllText(inputPath, Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void ConsoleOutput()
        {
            try
            {
                Console.WriteLine(File.ReadAllText(outputPath));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        #endregion
    }
}