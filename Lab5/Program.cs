using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Numerics;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class Program
{
    public static void Main()
    {
        Program program = new Program();

        int[] arr1 = new int[7] { 1, 2,100,  4, -5, 6, 7,  };
        int[] arr2 = new int[8] { 1, -3, 5, 5, 1, 0, 11, 4 };
        int[,] arr = new int[6, 6] {
            { 1,    2,  3,  4,  5,  -1 },
            { 6,    7,  8,  9,  10, -2 },
            { 11,   12, 13, 14, 15, -3 },
            { -1,   -2, -3, -4, -5, -1 },
            { 6,    7,  8,  9,  20, -2 },
            { 1,    3,  3,  1,  5, 5 }};
        program.Task_3_6(arr);
        
    }

    public void PrintPrintArr(int[] arr)
    {
        for (int j = 0; j < arr.GetLength(0); j++)
        {
            Console.Write("{0} ", arr[j]);
        }
        Console.WriteLine();
    }

    
    public void PrintArr(int[,] arr)
    {
        for (int i = 0; i < arr.GetLength(0); i++)
        {
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                Console.Write("{0} ", arr[i, j]);
            }
            Console.WriteLine();
        }   
        Console.WriteLine();
    }
    
    #region Level 1
    
    public int Factorial(int n)
    {
        if (n == 0) return 0;
        int result = 1;
        for (int i = 1; i <= n; i++)
        {
            result *= i;
        }
        
        return result;
    }
    public long Task_1_1(int n, int k)
    {
        long answer = 0;

        // code here

        // create and use Factorial(n);
        if ((Factorial(k) * Factorial(n - k) == 0)) return 0;
        answer = Factorial(n) / (Factorial(k) * Factorial(n - k));
        // end

        return answer;
    }

    public double GeronArea(double a, double b, double c)
    {
        double p = (a + b + c) / 2;
        return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
    }

    public bool checkFigure(double foo, double bar, double baz)
    {
        return foo + bar > baz && foo + baz > bar && bar + baz > foo;
    }
    
    public int Task_1_2(double[] first, double[] second)
    {
        int answer = 0;

        // code here

        // create and use GeronArea(a, b, c);
        // first = 1, second = 2, equal = 0, error = -1
        if (!checkFigure(first[0], first[1], first[2]) || !checkFigure(second[0], second[1], second[2])) return -1;
        double foo1 = GeronArea(first[0], first[1], first[2]);
        double foo2 = GeronArea(second[0], second[1], second[2]);
        if (foo1 > foo2) return 1;
        else if (foo1 < foo2) return 2;
        else return 0;
        
        // end

        return answer;
    }


    public double GetDistance(double v, double a, double t)
    {
        return v * t + a * t * t / 2;
    }
    public int Task_1_3a(double v1, double a1, double v2, double a2, int time)
    {
        int answer = 0;

        // code here
        
        // create and use GetDistance(v, a, t); t - hours
        // first = 1, second = 2, equal = 0
        double foo1 = GetDistance(v1, a1, (double) time);
        double foo2 = GetDistance(v2, a2, (double) time);
        if (foo1 > foo2) return 1;
        else if (foo1 < foo2) return 2;
        else return 0;
        
        // end

        return answer;
    }

    public int Task_1_3b(double v1, double a1, double v2, double a2)
    {
        int answer = 0;

        // code here

        // create and use GetDistance(v, a, t); t - hours
        int time = 1;
        while (GetDistance(v1, a1, time) > GetDistance(v2, a2, time))
        {
            time++;
        }

        answer = time;
        // end

        return answer;
    }
    #endregion

    #region Level 2
    public void Task_2_1(int[,] A, int[,] B)
    {
        // code here

        // create and use FindMax(matrix);

        // end
    }

    public int FindMaxMax(double[] arr)
    {
        int fooIndex = 0;
        double maxFoo = arr[0];
        for (int i = 0; i < arr.GetLength(0); i++)
        {

            if (arr[i] > maxFoo)
            {
                maxFoo = arr[i];
                fooIndex = i;
            }
        }
        
        return fooIndex;
    }

    public void ChangeArray(double[] array, int maxIndex)
    {
        double summa = 0;
        double fooCount = 0;

        for (int i = maxIndex + 1; i < array.Length; i++)
        {
            summa += array[i];
            fooCount++;
        }

        array[maxIndex] = summa / fooCount;
    }
    public void Task_2_2(double[] A, double[] B)
    {
        // code here

        // create and use FindMax(array);
        int index1 = FindMaxMax(A);
        int index2 = FindMaxMax(B);

        if (A.Length - index1 > B.Length - index2) ChangeArray(A, index1);
        else ChangeArray(B, index2);
        // end
    }

    public void Task_2_3(ref int[,] B, ref int[,] C)
    {
        // code here

        // create and use FindDiagonalMax(matrix);

        // end
    }

    public int FindDiagonalMaxIndex(int[,] arr)
    {
        int maxElement = arr[0, 0];
        int diagonal = 0;
        for (int i = 0; i < arr.GetLength(0); i++)
        {
            if (arr[i, i] > maxElement)
            {
                maxElement = arr[i, i];
                diagonal = i;
            }
        }

        return diagonal;
    }
    
    public void Task_2_4(int[,] A, int[,] B)
    {
        // code here

        // use method FindDiagonalMax(matrix); from Task_2_3
        // use method FindDiagonalMaxIndex(matrix); from Task_2_3
        int row = FindDiagonalMaxIndex(A);
        int column = FindDiagonalMaxIndex(B);

        int[] arr1 = new int[A.GetLength(0)];
        int[] arr2 = new int[B.GetLength(1)];


        for (int i = 0; i < A.GetLength(0); i++)
        {
            arr1[i] = A[row, i];
        }
        for (int i = 0; i < B.GetLength(1); i++)
        {
            arr2[i] = A[i, column];
        }

        for (int i = 0; i < A.GetLength(0); i++)
        {
            A[row, i] = arr2[i];
        }
        for (int i = 0; i < B.GetLength(1); i++)
        {
            B[i, column] = arr1[i];
        }

        PrintArr(A);
        PrintArr(B);
        // end
    }

    public void Task_2_5(int[,] A, int[,] B)
    {
        // code here

        // create and use FindColumnMax(matrix, columnIndex);

        // end
    }

    public void DeleteElement(ref int[] arr, int index)
    {
        int[] newArr = new int[arr.Length - 1];
        for (int i = 0; i < index; i++)
        {
            newArr[i] = arr[i];
        }
        for (int i = index; i < arr.Length - 1; i++)
        {
            newArr[i] = arr[i + 1];
        }

        arr = newArr;
    }
    public void Task_2_6(ref int[] A, int[] B)
    {
        // code here

        // create and use DeleteElement(array, index);

        int maxFoo = A[0];
        int index = 0;
        for (int i = 0; i < A.GetLength(0); i++)
        {
            index = maxFoo < A[i] ? i : index;
            maxFoo = Math.Max(maxFoo, A[i]);
        }
        
        int maxFoo2 = B[0];
        int index2 = 0;
        for (int i = 0; i < A.GetLength(0); i++)
        {
            index2 = maxFoo2 < B[i] ? i : index2;
            maxFoo2 = Math.Max(maxFoo2, B[i]);
        }
        
        DeleteElement(ref A, index);
        DeleteElement(ref B, index2);

        int[] arr = new int[A.Length + B.Length];
        int k = 0;
        for (int j = 0; j < A.GetLength(0); j++)
        {
            arr[k] = A[j];
            k++;
        }
        for (int j = 0; j < B.GetLength(0); j++)
        {
            arr[k] = B[j];
            k++;
        }

        A = arr;
        // for (int j = 0; j < A.Length; j++)
        // {
        //     Console.Write("{0} ", A[j]);
        // }
            // end
    }

    public void Task_2_7(ref int[,] B, int[,] C)
    {
        // code here

        // create and use CountRowPositive(matrix, rowIndex);
        // create and use CountColumnPositive(matrix, colIndex);

        // end
    }

    public int[] SortArrayPart(int[] array, int startIndex)
    {
        for (int i = startIndex; i < array.Length; i++)
        {
            int index = i;
            while (index > startIndex && array[index - 1] > array[index])
            {
                int temp = array[index - 1];
                array[index - 1] = array[index];
                array[index] = temp;
                index--;
            }
        }

        return array;
    }

    public void SortSortArrayPart(int[] A)
    {
        int fooMax = A[0];
        int fooIndex = 0;
        for (int i = 0; i < A.GetLength(0); i++)
        {
            if (A[i] > fooMax)
            {
                fooMax = A[i];
                fooIndex = i;
            }
        }

        A = SortArrayPart(A, fooIndex + 1);
        PrintPrintArr(A);
    }
    public void Task_2_8(int[] A, int[] B)
    {
        // code here

        // create and use SortArrayPart(array, startIndex);
        SortSortArrayPart(A);
        SortSortArrayPart(B);
        // int fooMax2 = B[0];
        // int fooIndex2 = 0;
        // for (int i = 0; i < B.GetLength(0); i++)
        // {
        //     if (B[i] > fooMax2)
        //     {
        //         fooMax2 = B[i];
        //         fooIndex2 = i;
        //     }
        // }
        //
        // B = SortArrayPart(B, fooIndex2 + 1);

        // end
    }

    public int[] Task_2_9(int[,] A, int[,] C)
    {
        int[] answer = default(int[]);

        // code here

        // create and use SumPositiveElementsInColumns(matrix);

        // end

        return answer;
    }

    delegate void ChangeColumnDelegate(ref int[,] matrix, int columnIndex);
    public void RemoveColumn(ref int[,] matrix, int columnIndex)
    {
        int[,] arr = new int[matrix.GetLength(0),matrix.GetLength(1) - 1];
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (columnIndex == j) continue;
                if (j > columnIndex) arr[i, j - 1] = matrix[i, j];
                else arr[i, j] = matrix[i, j];
            }
        }

        matrix = arr;
    }

    public int FindMaxBelowDiagonalIndex(int[,] matrix)
    {
        int maxFoo1 = Int32.MinValue;
        int index1 = -1;
        
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (i >= j)
                {
                    if (matrix[i, j] > maxFoo1)
                    {
                        maxFoo1 = matrix[i, j];
                        index1 = j;
                    }
                }
            }
        }

        return index1;
    }

    public int FindMinAboveDiagonalIndex(int[,] matrix)
    {
        int minFoo2 = Int32.MaxValue;
        int index2 = -1;

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (i < j)
                {
                    if (matrix[i, j] < minFoo2)
                    {
                        minFoo2 = matrix[i, j];
                        index2 = j;
                    }
                }
            }
        }

        return index2;
    }
    
    public void Task_2_10(ref int[,] matrix)
    {
        // code here
        int index1 = FindMaxBelowDiagonalIndex(matrix);
        int index2 = FindMinAboveDiagonalIndex(matrix);
        if (index1 != -1) RemoveColumn(ref matrix, index1);
        
        if (index1 != index2 && index2 != -1)
        {
            RemoveColumn(ref matrix, index1 < index2 ? index2 - 1 : index2);
        }

        // end
    }

    public void Task_2_11(int[,] A, int[,] B)
    {
        // code here

        // use FindMax(matrix); from Task_2_1

        // end
    }

    public int FindMaxColumnIndex(int[,] matrix)
    {
        int maxFoo = matrix[0, 0];
        int maxIndex = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (maxFoo < matrix[i, j])
                {
                    maxFoo = matrix[i, j];
                    maxIndex = j;
                }
            }
        }

        return maxIndex;
    }
    public void Task_2_12(int[,] A, int[,] B)
    {
        // code here
        int firstIndex = FindMaxColumnIndex(A);
        int secondIndex = FindMaxColumnIndex(B);
        for (int i = 0; i < A.GetLength(1); i++)
        {
            int temp = A[i, firstIndex];
            A[i, firstIndex] = B[i, secondIndex];
            B[i, secondIndex] = temp;
        }
        
        // end
    }

    public void Task_2_13(ref int[,] matrix)
    {
        // code here

        // create and use RemoveRow(matrix, rowIndex);

        // end
    }

    // сортировка Шелла
    public void SortRow(int[,] matrix, int rowIndex)
    {
        int lenght = matrix.GetLength(1);
        for (int interval = lenght / 2; interval > 0; interval /= 2)
        {
            for (int i = interval; i < lenght; i++)
            {
                int temp = matrix[rowIndex, i];
                int j = i;
                while (j >= interval && matrix[rowIndex, j - interval] > temp)
                {
                    matrix[rowIndex, j] = matrix[rowIndex, j - interval];
                    j -= interval;
                }

                matrix[rowIndex, j] = temp;
            }
        }
    }
    public void Task_2_14(int[,] matrix)
    {
        // code here
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            SortRow(matrix, i);
        }
        // create and use SortRow(matrix, rowIndex);

        // end
    }
    
    public int Task_2_15(int[,] A, int[,] B, int[,] C)
    {
        int answer = 0; // 1 - increasing   0 - no sequence   -1 - decreasing

        // code here

        // create and use GetAverageWithoutMinMax(matrix);

        // end

        return answer;
    }

    public void SortNegative(int[] arr)
    {
        int count = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] < 0) count++;
        }
        
        int[] arr2 = new int[count];
        int j = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] < 0)
            {
                arr2[j] = arr[i];
                j++;
            }
        }
        
        // сортировка гномов
        int index = 1;
        while (index < arr2.Length)
        {
            if (arr2[index - 1] >= arr2[index]) index++;
            else
            {
                int temp = arr2[index];
                arr2[index] = arr2[index - 1];
                arr2[index - 1] = temp;
                if (index > 1) index--;
            }
        }

        int foo = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] >= 0) continue;
            arr[i] = arr2[foo];
            foo++;
        }
    }
    public void Task_2_16(int[] A, int[] B)
    {
        // code here

        SortNegative(A);
        SortNegative(B);

        // end
    }

    public void Task_2_17(int[,] A, int[,] B)
    {
        // code here

        // create and use SortRowsByMaxElement(matrix);

        // end
    }

    public void SortDiagonal(int[,] matrix)
    {
        // перешешки сорт

        bool isFoo = true;
        int left = 1;
        int right = matrix.GetLength(0) - 1;

        do
        {
            isFoo = true;
            for (int i = left; i <= right; i++)
            {
                if (matrix[i - 1, i - 1] > matrix[i, i])
                {
                    int temp = matrix[i - 1, i - 1];
                    matrix[i - 1, i - 1] = matrix[i, i];
                    matrix[i, i] = temp;
                    isFoo = false;
                }
            }
            right--;
            for (int i = right; i >= left; i--)
            {
                if (matrix[i - 1, i - 1] > matrix[i, i])
                {
                    int temp = matrix[i - 1, i - 1];
                    matrix[i - 1, i - 1] = matrix[i, i];
                    matrix[i, i] = temp;
                    isFoo = false;
                }
            }

            left++;
        } while (!isFoo);
    }
    public void Task_2_18(int[,] A, int[,] B)
    {
        // code here

        SortDiagonal(A);
        SortDiagonal(B);
        // end
    }

    public void Task_2_19(ref int[,] matrix)
    {
        // code here

        // use RemoveRow(matrix, rowIndex); from 2_13

        // end
    }

    public void RemoveRemoveColumn(ref int[,] matrix)
    {
        ChangeColumnDelegate removeColumn = RemoveColumn;
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            bool isTrue = false;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, j] == 0) isTrue = true;
            }

            if (!isTrue)
            {
                removeColumn(ref matrix, j);
                RemoveRemoveColumn(ref matrix);
            }
        }
    }
    public void Task_2_20(ref int[,] A, ref int[,] B)
    {
        // code here

        RemoveRemoveColumn(ref A);
        RemoveRemoveColumn(ref B);

        // end
    }    

    public void Task_2_21(int[,] A, int[,] B, out int[] answerA, out int[] answerB)
    {
        answerA = null;
        answerB = null;

        // code here

        // create and use CreateArrayFromMins(matrix);

        // end
    }

    public int GetNegativeCountPerRow(int[,] matrix, int rowIndex)
    { 
        int count = 0;
        for (int j = 0; j < matrix.GetLength(1); j++) 
        { 
            if (matrix[rowIndex, j] < 0) count++;
        }
        
        return count;
    }
    
    public int[] GetMaxNegativePerColumn(int[,] matrix)
    {
        int[] arr = new int[matrix.GetLength(1)];
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            int maxFoo = Int32.MinValue;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, j] < 0 && matrix[i, j] > maxFoo) maxFoo = matrix[i, j];
            }

            arr[j] = maxFoo;
        }
        
        return arr;
    }
    public void Task_2_22(int[,] matrix, out int[] rows, out int[] cols)
    {
        rows = null;
        cols = null;

        // code here
        rows = new int[matrix.GetLength(0)];
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            rows[i] = GetNegativeCountPerRow(matrix, i);
        }        
        cols = GetMaxNegativePerColumn(matrix);

        // end
    }

    public void Task_2_23(double[,] A, double[,] B)
    {
        // code here

        // create and use MatrixValuesChange(matrix);

        // end
    }

    public int FindMax(int[,] matrix)
    {
        int fooIndex = 0;
        int maxFoo = matrix[0, 0];
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] > maxFoo)
                {
                    maxFoo = matrix[i, j];
                    fooIndex = j;
                }
            }
        }
        
        return fooIndex;
    }

    public void ChangeMatrix(int[,] matrix, int fooIndex)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            int temp = matrix[i, fooIndex];
            matrix[i, fooIndex] = matrix[i, i];
            matrix[i, i] = temp;
        }
    }
    public void Task_2_24(int[,] A, int[,] B)
    {
        // code here
        ChangeMatrix(A, FindMax(A));
        ChangeMatrix(B, FindMax(B));

        // end
    }

    public void Task_2_25(int[,] A, int[,] B, out int maxA, out int maxB)
    {
        maxA = 0;
        maxB = 0;

        // code here

        // create and use FindMaxNegativeRow(int);
        // use GetNegativeCountPerRow(matrix); from 2_22

        // end
    }

    public int GetNegativeCountPerRow(int[,] matrix)
    {
        int rowFoo = 0;
        int maxCount = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            int count = 0;
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] < 0) count++;
            }

            if (maxCount < count)
            {
                maxCount = count;
                rowFoo = i;
            }
        }

        return rowFoo;
    }

    public void swapRows(int[,] A, int[,] B, int rowA, int rowB)
    {
        for (int j = 0; j < A.GetLength(1); j++)
        {
            int temp = A[rowA, j];
            A[rowA, j] = B[rowB, j];
            B[rowB, j] = temp;
        }
    }
    public void Task_2_26(int[,] A, int[,] B)
    {
        // code here
        swapRows(A, B, GetNegativeCountPerRow(A), GetNegativeCountPerRow(B));
        // end
    }

    public void Task_2_27(int[,] A, int[,] B)
    {
        // code here
        // create and use FindRowMaxIndex(matrix)
        // create and use ReplaceMaxElementOdd(matrix, row, column);
        // create and use ReplaceMaxElementEven(matrix, row, column);

        // end
    }

    delegate int FindSequenceDelegate(int[] array, int A, int B);
    public int FindSequence(int[] array, int A, int B)
    {
        bool isUp = true;
        bool isDown = true;

        for (int i = A; i < B; i++)
        {
            if (array[i] < array[i + 1]) isDown = false;
            else if (array[i] > array[i + 1]) isUp = false;
        }

        if (isUp) return 1;
        if (isDown) return -1;
        return 0;
    }
    
    public void Task_2_28a(int[] first, int[] second, ref int answerFirst, ref int answerSecond)
    {
        // code here
        FindSequenceDelegate findSequenceDelegate = FindSequence;
        answerFirst = findSequenceDelegate(first, 0, first.Length - 1);
        answerSecond = findSequenceDelegate(second, 0, second.Length - 1);
        
        // end
    }

    public void FindIntervals(int[] array, ref int[,] answer)
    {
        FindSequenceDelegate findSequenceDelegate = FindSequence;

        int fooCount = 0;
        for (int i = 0; i < array.Length; i++)
        {
            for (int j = i + 1; j < array.Length; j++)
            {
                if (findSequenceDelegate(array, i, j) != 0) fooCount++;
            }
        }
        answer = new int[fooCount, 2];
        int index = 0;
        for (int i = 0; i < array.Length; i++)
        {
            for (int j = i + 1; j < array.Length; j++)
            {
                if (findSequenceDelegate(array, i, j) != 0)
                {
                    answer[index, 0] = i;
                    answer[index, 1] = j;
                    index++;
                }
            }
        }
    }
    public void Task_2_28b(int[] first, int[] second, ref int[,] answerFirst, ref int[,] answerSecond)
    {
        // code here
        FindIntervals(first, ref answerFirst);
        FindIntervals(second, ref answerSecond);

        // end
    }

    public void findMaxInterval(int[] array, ref int[] answer)
    {
        FindSequenceDelegate findSequenceDelegate = FindSequence;

        int start = 0;
        int finish = 0;
        for (int i = 0; i < array.Length; i++)
        {
            for (int j = i + 1; j < array.Length; j++)
            {
                if (finish - start < j - i && findSequenceDelegate(array, i, j) != 0)
                {
                    start = i;
                    finish = j;
                }
            }
        }
        
        answer = new int[]{start, finish};
    }
    public void Task_2_28c(int[] first, int[] second, ref int[] answerFirst, ref int[] answerSecond)
    {
        // code here
        findMaxInterval(first, ref answerFirst);
        findMaxInterval(second, ref answerSecond);
        // end
    }
    #endregion

    #region Level 3
    public void Task_3_1(ref double[,] firstSumAndY, ref double[,] secondSumAndY)
    {
        // code here

        // create and use public delegate SumFunction(x, a, b, h) and public delegate YFunction(x, a, b, h)
        // create and use method GetSumAndY(sFunction, yFunction, a, b, h);
        // create and use 2 methods for both functions

        // end
    }
    
    delegate void SortRowStyle(int[,] matrix, int rowIndex);
    public void SortAscending(int[,] matrix, int rowIndex)
    {
        for (int i = 0; i < matrix.GetLength(1); i++)
        {
            int j = i;
            while (j > 0 && matrix[rowIndex, j] < matrix[rowIndex, j - 1])
            {
                int temp = matrix[rowIndex, j - 1];
                matrix[rowIndex, j - 1] = matrix[rowIndex, j];
                matrix[rowIndex, j] = temp;
                j--;
            }
        }
    }
    public void SortDescending(int[,] matrix, int rowIndex)
    {
        for (int i = 0; i < matrix.GetLength(1); i++)
        {
            int j = i;
            while (j > 0 && matrix[rowIndex, j] > matrix[rowIndex, j - 1])
            {
                int temp = matrix[rowIndex, j - 1];
                matrix[rowIndex, j - 1] = matrix[rowIndex, j];
                matrix[rowIndex, j] = temp;
                j--;
            }
        }
    }
    public void Task_3_2(int[,] matrix)
    { 
        SortRowStyle sortStyle = default(SortRowStyle);

        // code here
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            if (i % 2 == 0) sortStyle = SortAscending;
            else sortStyle = SortDescending;

            sortStyle(matrix, i);
            PrintArr(matrix);
        }
        
        // create and use public delegate SortRowStyle(matrix, rowIndex);
        // create and use methods SortAscending(matrix, rowIndex) and SortDescending(matrix, rowIndex)
        // change method in variable sortStyle in the loop here and use it for row sorting

        // end
    }

    public double Task_3_3(double[] array)
    {
        double answer = 0;
        // SwapDirection swapper = default(SwapDirection); - uncomment me

        // code here

        // create and use public delegate SwapDirection(array);
        // create and use methods SwapRight(array) and SwapLeft(array) and GetSum(array)
        // change method in variable swapper in the loop here and use it for array swapping

        // end

        return answer;
    }

    public delegate int[] GetTriangle(int[,] matrix);

    public int[] GetUpperTriangle(int[,] array)
    {
        int[] upperFoo = new int[array.GetLength(0) * (array.GetLength(1) + 1) / 2];
        int count = 0;
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                if (i <= j)
                {
                    upperFoo[count] = array[i, j];
                    count++;
                }
            }
        }
        return upperFoo;
    }

    public int[] GetLowerTriangle(int[,] array)
    {
        int[] lowFoo = new int[array.GetLength(0) * (array.GetLength(1) + 1) / 2];
        int count = 0;
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                if (i >= j) {
                    lowFoo[count] = array[i, j];
                    count++;
                }
            }
        }
        return lowFoo;
    }

    public int GetSum(GetTriangle getTriangle, int[,] matrix)
    {
        int[] arr = getTriangle(matrix);
        int summa = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            summa += arr[i] * arr[i];
        }
        return summa;
    }
    public int Task_3_4(int[,] matrix, bool isUpperTriangle)
    {
        int answer = 0;

        // code here
        answer = GetSum(isUpperTriangle ? GetUpperTriangle : GetLowerTriangle, matrix);
        // create and use public delegate GetTriangle(matrix);
        // create and use methods GetUpperTriange(array) and GetLowerTriange(array)
        // and GetSum(GetTriangle, matrix)
        // create and use method GetSum(array) similar to GetSum in Task_3_3

        // end

        return answer;
    }

    public void Task_3_5(out int func1, out int func2)
    {
        func1 = 0;
        func2 = 0;

        // code here

        // use public delegate YFunction(x, a, b, h) from Task_3_1
        // create and use method CountSignFlips(YFunction, a, b, h);
        // create and use 2 methods for both functions

        // end
    }

    public delegate int FindElementDelegate(int[,] matrix);
    public int FindFirstRowMaxIndex(int[,] matrix)
    {
        int index = 0;
        int maxFoo = matrix[0, 0];
        for (int i = 0; i < matrix.GetLength(1); i++)
        {
            if (maxFoo < matrix[0, i])
            {
                maxFoo = matrix[0, i];
                index = i;
            }
        }

        return maxFoo;
    }

    public void SwapColumns(int[,] matrix, FindElementDelegate findDiagonalMaxIndex, FindElementDelegate findFirstRowMaxIndex)
    {
        int index1 = findDiagonalMaxIndex(matrix);
        int index2 = findFirstRowMaxIndex(matrix) - 1;

        for (int i = 0; i < matrix.GetLength(1); i++)
        {
            int temp = matrix[i, index1];
            matrix[i, index1] = matrix[i, index2];
            matrix[i, index2] = temp;

        }
        
    }
    public void Task_3_6(int[,] matrix)
    {
        // code here
        
        SwapColumns(matrix, FindDiagonalMaxIndex, FindFirstRowMaxIndex);
        // end
    }

    public void Task_3_7(ref int[,] B, int[,] C)
    {
        // code here

        // create and use public delegate CountPositive(matrix, index);
        // use CountRowPositive(matrix, rowIndex) from Task_2_7
        // use CountColumnPositive(matrix, colIndex) from Task_2_7

        // end
    }

    public void RemoveColumns(ref int[,] matrix, FindIndex findMaxBelowDiagonalIndex, FindIndex findMinAboveDiagonalIndex)
    {
        int index1 = findMaxBelowDiagonalIndex(matrix);
        int index2 = findMinAboveDiagonalIndex(matrix);
        if (index1 != -1) RemoveColumn(ref matrix, index1);
        
        if (index1 != index2 && index2 != -1)
        {
            RemoveColumn(ref matrix, index1 < index2 ? index2 - 1 : index2);
        }
    }
    public delegate int FindIndex(int[,] matrix);
    public void Task_3_10(ref int[,] matrix)
    { 
        FindIndex searchArea = default(FindIndex);
        
        // code here
        RemoveColumns(ref matrix, FindMaxBelowDiagonalIndex, FindMinAboveDiagonalIndex);

        // create and use public delegate FindIndex(matrix);
        // create and use method FindMaxBelowDiagonalIndex(matrix);
        // create and use method FindMinAboveDiagonalIndex(matrix);
        // use RemoveColumn(matrix, columnIndex) from Task_2_10
        // create and use method RemoveColumns(matrix, findMaxBelowDiagonalIndex, findMinAboveDiagonalIndex)

        // end
    }

    public void Task_3_13(ref int[,] matrix)
    {
        // code here

        // use public delegate FindElementDelegate(matrix) from Task_3_6
        // create and use method RemoveRows(matrix, findMax, findMin)

        // end
    }

    public delegate int[] GetNegativeArray(int[,] matrix);
    
    public void FindNegatives(int[,] matrix, GetNegativeArray searcherRows, GetNegativeArray searcherCols, out int[] rows, out int[] cols)
    {
        rows = searcherRows(matrix);
        cols = searcherCols(matrix);
    }

    public int[] FindCountNegativeInRows(int[,] matrix)
    {
        int[] arr = new int[matrix.GetLength(0)];
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            arr[i] = GetNegativeCountPerRow(matrix, i);
        }
        return arr;
    }
    public void Task_3_22(int[,] matrix, out int[] rows, out int[] cols)
    {

        rows = null;
        cols = null;
        
        // code here
        FindNegatives(matrix, FindCountNegativeInRows, GetMaxNegativePerColumn, out rows, out cols);
        // create and use public delegate GetNegativeArray(matrix);
        // use GetNegativeCountPerRow(matrix) from Task_2_22
        // use GetMaxNegativePerColumn(matrix) from Task_2_22
        // create and use method FindNegatives(matrix, searcherRows, searcherCols, out rows, out cols);

        // end
    }

    public void Task_3_27(int[,] A, int[,] B)
    {
        // code here

        // create and use public delegate ReplaceMaxElement(matrix, rowIndex, max);
        // use ReplaceMaxElementOdd(matrix) from Task_2_27
        // use ReplaceMaxElementEven(matrix) from Task_2_27
        // create and use method EvenOddRowsTransform(matrix, replaceMaxElementOdd, replaceMaxElementEven);

        // end
    }

    public delegate bool IsSequence(int[] array, int left, int right);
    public bool FindIncreasingSequence(int[] array, int A, int B)
    {
        return FindSequence(array, A, B) == 1;
    }
    public bool FindDecreasingSequence(int[] array, int A, int B)
    {
        return FindSequence(array, A, B) == -1;
    }
    public int DefineSequence(int[] array, IsSequence findIncrease, IsSequence findDecrease)
    {
        bool isUp = findIncrease(array, 0, array.Length - 1);
        bool isDown = findDecrease(array, 0, array.Length - 1);
        
        if (isUp) return 1;
        if (isDown) return -1;
        return 0;
    }
    public void Task_3_28a(int[] first, int[] second, ref int answerFirst, ref int answerSecond)
    {
        // code here
        answerFirst = DefineSequence(first, FindIncreasingSequence, FindDecreasingSequence);
        answerSecond = DefineSequence(second, FindIncreasingSequence, FindDecreasingSequence);
        // create public delegate IsSequence(array, left, right);
        // create and use method FindIncreasingSequence(array, A, B); similar to FindSequence(array, A, B) in Task_2_28a
        // create and use method FindDecreasingSequence(array, A, B); similar to FindSequence(array, A, B) in Task_2_28a
        // create and use method DefineSequence(array, findIncreasingSequence, findDecreasingSequence);

        // end
    }

    public int[] FindLongestSequence(int[] array, IsSequence isSequence)
    {
        int start = 0;
        int finish = 0;
        for (int i = 0; i < array.Length; i++)
        {
            for (int j = i + 1; j < array.Length; j++)
            {
                if (j - i > finish - start && isSequence(array, i, j))
                {
                    start = i;
                    finish = j;
                }
            }
        }
        return new int[] { start, finish };
    }
    public void Task_3_28c(int[] first, int[] second, ref int[] answerFirstIncrease, ref int[] answerFirstDecrease, ref int[] answerSecondIncrease, ref int[] answerSecondDecrease)
    {
        // code here
        answerFirstIncrease = FindLongestSequence(first, FindIncreasingSequence);
        answerFirstDecrease = FindLongestSequence(first, FindDecreasingSequence);
        answerSecondIncrease = FindLongestSequence(second, FindIncreasingSequence);
        answerSecondDecrease = FindLongestSequence(second, FindDecreasingSequence);
        // create public delegate IsSequence(array, left, right);
        // use method FindIncreasingSequence(array, A, B); from Task_3_28a
        // use method FindDecreasingSequence(array, A, B); from Task_3_28a
        // create and use method FindLongestSequence(array, sequence);

        // end
    }
    #endregion
    #region bonus part
    public double[,] Task_4(double[,] matrix, int index)
    {
        // MatrixConverter[] mc = new MatrixConverter[4]; - uncomment me

        // code here

        // create public delegate MatrixConverter(matrix);
        // create and use method ToUpperTriangular(matrix);
        // create and use method ToLowerTriangular(matrix);
        // create and use method ToLeftDiagonal(matrix); - start from the left top angle
        // create and use method ToRightDiagonal(matrix); - start from the right bottom angle

        // end

        return matrix;
    }
    #endregion
}
