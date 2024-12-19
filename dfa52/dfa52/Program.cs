using System;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. Сортировка по возрастанию элементов последней строки массива 3x4
            int[,] array1 = { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 8, 7, 6 } };
            SortLastRow(array1);
            Console.WriteLine("Задача 1:");
            PrintMatrix(array1);

            // 2. Сумма модулей отрицательных нечетных элементов в массиве 7x7
            int[,] array2 = GenerateMatrix(7, 7, -10, 10);
            int sumNegOdd = SumNegativeOdd(array2);
            Console.WriteLine("Задача 2: " + sumNegOdd);

            // 3. Среднее арифметическое положительных элементов каждого столбца массива 5x6
            int[,] array3 = GenerateMatrix(5, 6, -10, 10);
            Console.WriteLine("Задача 3:");
            AveragePositiveEachColumn(array3);

            // 4. Наименьший элемент побочной диагонали квадратной матрицы 5x5
            double[,] array4 = GenerateMatrixDouble(5, 5, -10, 10);
            double minSecondary = MinSecondaryDiagonal(array4);
            Console.WriteLine("Задача 4: " + minSecondary);

            // 5. Сортировка по убыванию элементов последнего столбца массива 5x4
            int[,] array5 = GenerateMatrix(5, 4, 0, 20);
            SortLastColumnDescending(array5);
            Console.WriteLine("Задача 5:");
            PrintMatrix(array5);

            // 6. Поменять местами наибольшие элементы в первом и третьем столбцах матрицы 4x3
            int[,] array6 = GenerateMatrix(4, 3, 0, 20);
            SwapMaxInColumns(array6, 0, 2);
            Console.WriteLine("Задача 6:");
            PrintMatrix(array6);

            // 7. Поменять местами наименьшие элементы в первой и третьей строках матрицы 3x4
            int[,] array7 = GenerateMatrix(3, 4, 0, 20);
            SwapMinInRows(array7, 0, 2);
            Console.WriteLine("Задача 7:");
            PrintMatrix(array7);

            // 8. Произведение наименьших элементов каждого столбца квадратной матрицы NxN
            int[,] array8 = GenerateMatrix(4, 4, -10, 10); // N <= 10
            int productMinColumns = ProductMinInColumns(array8);
            Console.WriteLine("Задача 8: " + productMinColumns);

            // 9. Среднее арифметическое каждого столбца, максимум и минимум каждой строки 5x6
            int[,] array9 = GenerateMatrix(5, 6, 0, 20);
            AverageMaxMin(array9);

            // 10. Количество нечетных элементов каждого столбца в массиве 7x8
            int[,] array10 = GenerateMatrix(7, 8, 0, 20);
            CountOddEachColumn(array10);

            // 11. Количество четных и нечетных чисел в массиве NxM
            int[,] array11 = GenerateMatrix(5, 5, -10, 10);
            CountEvenOdd(array11);

            // 12. Количество числа 7 в массиве NxM
            int[,] array12 = GenerateMatrix(5, 5, 0, 10);
            int countSevens = CountNumber(array12, 7);
            Console.WriteLine("Задача 12: " + countSevens);

            // 13. Наибольший элемент в каждом столбце массива NxM
            int[,] array13 = GenerateMatrix(5, 5, 0, 20);
            MaxInColumns(array13);

            // 14. Индексы первого наименьшего элемента массива NxM
            int[,] array14 = GenerateMatrix(5, 5, 0, 20);
            (int row, int col) = FindFirstMinIndex(array14);
            Console.WriteLine($"Задача 14: Индекс первого наименьшего элемента: ({row}, {col})");

            // 15. Сумма элементов последнего столбца квадратного массива NxN
            int[,] array15 = GenerateMatrix(4, 4, 0, 20);
            int sumLastColumn = SumColumn(array15, array15.GetLength(1) - 1);
            Console.WriteLine("Задача 15: " + sumLastColumn);

            // 16. Произведение элементов первой строки квадратного массива NxN
            int[,] array16 = GenerateMatrix(4, 4, 1, 10);
            int productFirstRow = ProductRow(array16, 0);
            Console.WriteLine("Задача 16: " + productFirstRow);
            // 17. Сумма элементов каждой строки в массиве 10x10
            int[,] array17 = GenerateMatrix(10, 10, 0, 20);
            Console.WriteLine("Задача 17: Сумма строк:");
            SumEachRow(array17);

            // 18. Нахождение строки с наименьшей суммой элементов в массиве 4x4
            int[,] array18 = GenerateMatrix(4, 4, 0, 20);
            int minSumRowIndex = FindMinSumRow(array18);
            Console.WriteLine($"Задача 18: Индекс строки с наименьшей суммой: {minSumRowIndex}");
        }

        
        static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

        static void PrintMatrix(double[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

        
        static int[,] GenerateMatrix(int rows, int cols, int minValue, int maxValue)
        {
            Random rand = new Random();
            int[,] matrix = new int[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = rand.Next(minValue, maxValue);
                }
            }
            return matrix;
        }

        
        static double[,] GenerateMatrixDouble(int rows, int cols, int minValue, int maxValue)
        {
            Random rand = new Random();
            double[,] matrix = new double[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = rand.NextDouble() * (maxValue - minValue) + minValue;
                }
            }
            return matrix;
        }

        
        static void SortLastRow(int[,] array)
        {
            int[] lastRow = new int[array.GetLength(1)];
            for (int i = 0; i < array.GetLength(1); i++)
            {
                lastRow[i] = array[2, i];
            }
            Array.Sort(lastRow);
            for (int i = 0; i < lastRow.Length; i++)
            {
                array[2, i] = lastRow[i];
            }
        }

        
        static int SumNegativeOdd(int[,] array)
        {
            int sum = 0;
            foreach (var item in array)
            {
                if (item < 0 && item % 2 != 0)
                    sum += Math.Abs(item);
            }
            return sum;
        }

        
        static void AveragePositiveEachColumn(int[,] array)
        {
            for (int col = 0; col < array.GetLength(1); col++)
            {
                int sumCol = 0, count = 0;
                for (int row = 0; row < array.GetLength(0); row++)
                {
                    if (array[row, col] > 0)
                    {
                        sumCol += array[row, col];
                        count++;
                    }
                }
                double avg = count > 0 ? (double)sumCol / count : 0;
                Console.WriteLine($"Столбец {col + 1}: {avg:F2}");
            }
        }

        
        static double MinSecondaryDiagonal(double[,] array)
        {
            double minSecondaryDiagonal = array[0, array.GetLength(1) - 1];
            for (int i = 0; i < array.GetLength(0); i++)
            {
                if (array[i, array.GetLength(1) - 1 - i] < minSecondaryDiagonal)
                    minSecondaryDiagonal = array[i, array.GetLength(1) - 1 - i];
            }
            return minSecondaryDiagonal;
        }

        
        static void SortLastColumnDescending(int[,] array)
        {
            int[] lastColumn = new int[array.GetLength(0)];
            for (int i = 0; i < array.GetLength(0); i++)
            {
                lastColumn[i] = array[i, array.GetLength(1) - 1];
            }
            Array.Sort(lastColumn);
            Array.Reverse(lastColumn);
            for (int i = 0; i < array.GetLength(0); i++)
            {
                array[i, array.GetLength(1) - 1] = lastColumn[i];
            }
        }

        
        static void SwapMaxInColumns(int[,] array, int col1, int col2)
        {
            int max1 = array[0, col1], max2 = array[0, col2];
            int max1Index = 0, max2Index = 0;

            for (int i = 0; i < array.GetLength(0); i++)
            {
                if (array[i, col1] > max1)
                {
                    max1 = array[i, col1];
                    max1Index = i;
                }
                if (array[i, col2] > max2)
                {
                    max2 = array[i, col2];
                    max2Index = i;
                }
            }

            
            int temp = array[max1Index, col1];
            array[max1Index, col1] = array[max2Index, col2];
            array[max2Index, col2] = temp;
        }

        
        static void SwapMinInRows(int[,] array, int row1, int row2)
        {
            int min1 = array[row1, 0], min2 = array[row2, 0];
            int min1Index = 0, min2Index = 0;

            for (int i = 0; i < array.GetLength(1); i++)
            {
                if (array[row1, i] < min1)
                {
                    min1 = array[row1, i];
                    min1Index = i;
                }
                if (array[row2, i] < min2)
                {
                    min2 = array[row2, i];
                    min2Index = i;
                }
            }

            int temp = array[row1, min1Index];
            array[row1, min1Index] = array[row2, min2Index];
            array[row2, min2Index] = temp;
        }

      
        static int ProductMinInColumns(int[,] array)
        {
            int product = 1;
            for (int col = 0; col < array.GetLength(1); col++)
            {
                int min = array[0, col];
                for (int row = 1; row < array.GetLength(0); row++)
                {
                    if (array[row, col] < min)
                        min = array[row, col];
                }
                product *= min;
            }
            return product;
        }

        
        static void AverageMaxMin(int[,] array)
        {
            for (int col = 0; col < array.GetLength(1); col++)
            {
                int sumCol = 0, count = 0, max = int.MinValue, min = int.MaxValue;
                for (int row = 0; row < array.GetLength(0); row++)
                {
                    sumCol += array[row, col];
                    count++;

                    if (array[row, col] > max)
                        max = array[row, col];
                    if (array[row, col] < min)
                        min = array[row, col];
                }
                double avg = (double)sumCol / count;
                Console.WriteLine($"Столбец {col + 1}: Среднее = {avg}, Мин = {min}, Макс = {max}");
            }
        }

        
        static void CountOddEachColumn(int[,] array)
        {
            for (int col = 0; col < array.GetLength(1); col++)
            {
                int countOdd = 0;
                for (int row = 0; row < array.GetLength(0); row++)
                {
                    if (array[row, col] % 2 != 0)
                        countOdd++;
                }
                Console.WriteLine($"Столбец {col + 1}: Количество нечетных элементов = {countOdd}");
            }
        }

        
        static void CountEvenOdd(int[,] array)
        {
            int evenCount = 0, oddCount = 0;
            foreach (var item in array)
            {
                if (item % 2 == 0)
                    evenCount++;
                else
                    oddCount++;
            }
            Console.WriteLine($"Количество четных = {evenCount}, нечетных = {oddCount}");
        }

        
        static int CountNumber(int[,] array, int number)
        {
            int count = 0;
            foreach (var item in array)
            {
                if (item == number)
                    count++;
            }
            return count;
        }

        
        static void MaxInColumns(int[,] array)
        {
            for (int col = 0; col < array.GetLength(1); col++)
            {
                int max = array[0, col];
                for (int row = 1; row < array.GetLength(0); row++)
                {
                    if (array[row, col] > max)
                        max = array[row, col];
                }
                Console.WriteLine($"Столбец {col + 1}: Макс = {max}");
            }
        }

        
        static (int, int) FindFirstMinIndex(int[,] array)
        {
            int min = array[0, 0];
            int rowIndex = 0, colIndex = 0;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] < min)
                    {
                        min = array[i, j];
                        rowIndex = i;
                        colIndex = j;
                    }
                }
            }
            return (rowIndex, colIndex);
        }

        
        static int SumColumn(int[,] array, int colIndex)
        {
            int sum = 0;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                sum += array[i, colIndex];
            }
            return sum;
        }

        
        static int ProductRow(int[,] array, int rowIndex)
        {
            int product = 1;
            for (int i = 0; i < array.GetLength(1); i++)
            {
                product *= array[rowIndex, i];
            }
            return product;
        }

        
        static void SumEachRow(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                int sum = 0;
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    sum += array[i, j];
                }
                Console.WriteLine($"Строка {i + 1}: Сумма = {sum}");
            }
        }
        
        static int FindMinSumRow(int[,] array)
        {
            int minSum = int.MaxValue;
            int minIndex = -1;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                int sum = 0;
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    sum += array[i, j];
                }

                if (sum < minSum)
                {
                    minSum = sum;
                    minIndex = i;
                }
            }
            return minIndex;
        }
    }
}
