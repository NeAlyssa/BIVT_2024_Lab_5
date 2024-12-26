using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Net.WebSockets;
using System.Numerics;
using System.Reflection;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class Program
{
   
    public static void Main()
    {
        Program program = new Program();
    }
    #region Level 1
    public int Factorial(int n)
    {
        int res = 1;
        for (int i = 2; i <= n; i++)
        {
            res *= i;
        }
        return res;
    }
    public long Combinations(int n, int k)
    {
        return Factorial(n) / (Factorial(k) * Factorial(n - k));
    }
    public long Task_1_1(int n, int k)
    {
        long answer = 0;

        answer = Combinations(n, k);

        return answer;
    }
    public double GeronArea(double a, double b, double c)
    {
        double p = (a + b + c) / 2;
        double s = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        return s;
    }
    public bool checking(double a, double b, double c)
    {
        if (a < b + c && b < a + c && c < a + b && c > 0 && b > 0 && a > 0) 
        {
            return true;
        }
        return false;
    }
    public int Task_1_2(double[] first, double[] second)
    {
        int answer = 0;

        if (!checking(first[0], first[1], first[2]) || !checking(second[0], second[1], second[2]))
        {
            return -1;
        }
        double s1 = GeronArea(first[0], first[1], first[2]);
        double s2 = GeronArea(second[0], second[1], second[2]);
        if (s1 > s2) return 1;
        if (s1 == s2) return 0;
        else return 2;
    }
    public double GetDistance(double v, double a, double t)
    {
        double s = v * t + a * t * t / 2;
        return s;
    }
    public int Task_1_3a(double v1, double a1, double v2, double a2, int time)
    {
        int answer = 0;

        // code here
        double s1 = GetDistance(v1, a1, time);
        double s2 = GetDistance(v2, a2, time);
        if (s1 > s2) return 1;
        if (s1 == s2) return 0;
        return 2;

        // create and use GetDistance(v, a, t); t - hours

        // end

        // first = 1, second = 2, equal = 0
    }

    public int Task_1_3b(double v1, double a1, double v2, double a2)
    {
        int answer = 0;
        int n = 1;
        while (GetDistance(v1, a1, n) > GetDistance(v2, a2, n))
        {
            n += 1;
        }

        return n;
    }
    #endregion

    #region Level 2
    public void Task_2_1(int[,] A, int[,] B)
    {
        // code here

        // create and use FindMaxIndex(matrix, out row, out column);

        // end
    }
    public int FindMaxIndex(double[] array)
    {
        double max = double.MinValue;
        int maxi = 0;
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] > max)
            {
                max = array[i];
                maxi = i;
            }
        }
        return maxi;
    }
    public double sr(double[] array, int arg)
    {
        double sum = 0;
        int count = 0;
        for (int i = arg + 1; i < array.Length; i++)
        {
            sum += array[i];
            count++;
        }
        return sum / count;
    }
    public void EditArray(double[] array, int maxIndex)
    {
        double srForArray = sr(array, maxIndex);
        for (int i = maxIndex; i < array.Length; i++)
        {
            if (array[maxIndex] == array[i]) array[i] = srForArray;
        }
    }
    public void Task_2_2(double[] A, double[] B)
    {
        int maxIforA = FindMaxIndex(A);
        int maxIforB = FindMaxIndex(B);
        if (A.Length - maxIforA > B.Length - maxIforB)
        {
            EditArray(A, maxIforA);
        }
        else if (A.Length - maxIforA < B.Length - maxIforB)
        {
            EditArray(B, maxIforB);
        }
        // create and use FindMaxIndex(array);
        // only 1 array has to be changed!

        // end
    }

    public void Task_2_3(ref int[,] B, ref int[,] C)
    {
        // code here

        //  create and use method FindDiagonalMaxIndex(matrix);

        // end
    }
    public int FindDiagonalMaxIndex(int[,] matrix)
    {
        int max = matrix[0, 0];
        int maxi = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            if (matrix[i, i] > max)
            {
                max = matrix[i, i];
                maxi = i;
            }
        }
        return maxi;
    }

    public void Task_2_4(int[,] A, int[,] B)
    {
        int max_for_A = FindDiagonalMaxIndex(A);
        int max_for_B = FindDiagonalMaxIndex(B);
        for (int i = 0; i < 5; i++)
        {
            int temp = A[max_for_A, i];
            A[max_for_A, i] = B[i, max_for_B];
            B[i, max_for_B] = temp;
        }
    }

    public void Task_2_5(int[,] A, int[,] B)
    {
        // code here

        // create and use FindMaxInColumn(matrix, columnIndex, out rowIndex);

        // end
    }
    public int FindMax(int[] array)
    {
        int max = array[0];
        int maxi = 0;
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] > max)
            {
                max = array[i];
                maxi = i;
            }
        }
        return maxi;
    }
    public int[] DeleteElement(ref int[] array, int index)
    {
        int[] array1 = new int[array.Length - 1];
        for (int i = 0; i < array1.Length; i++)
        {
            if (i < index)
            {
                array1[i] = array[i];
            }
            else
            {
                array1[i] = array[i + 1];
            }
        }
        array = array1;
        return array;
    }

    public void Task_2_6(ref int[] A, int[] B)
    {
        DeleteElement(ref A, FindMax(A));
        DeleteElement(ref B, FindMax(B));
        int[] all_array = new int[A.Length + B.Length];
        for (int i = 0; i < all_array.Length; i ++)
        {
            if (i < A.Length)
            {
                all_array[i] = A[i];
            }
            else
            {
                all_array[i] = B[i - A.Length];
            }
        }
        A = all_array;
    }

    public void Task_2_7(ref int[,] B, int[,] C)
    {
        // code here

        // create and use CountRowPositive(matrix, rowIndex);
        // create and use CountColumnPositive(matrix, colIndex);

        // end
    }
    public void SortArrayPart(ref int[] array, int startIndex)
    {
        for (int i = startIndex + 1; i < array.Length - 1; i++)
        {
            for (int j = startIndex + 1; j < array.Length - (i - startIndex); j++)
            {
                if (array[j] > array[j + 1])
                {
                    (array[j], array[j + 1]) = (array[j + 1], array[j]);
                }
            }
        }
    }

    public void Task_2_8(int[] A, int[] B)
    {
        SortArrayPart(ref A, FindMax(A));
        SortArrayPart(ref B, FindMax(B));
    }

    public int[] Task_2_9(int[,] A, int[,] C)
    {
        int[] answer = default(int[]);

        // code here

        // create and use SumPositiveElementsInColumns(matrix);

        // end

        return answer;
    }
    public int Max_And_Min(int[,] matrix, bool flag)
    {
        if (flag)
        {
            int max = matrix[0, 0];
            int maxi = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > max && i >= j)
                    {
                        max = matrix[i, j];
                        maxi = j;
                    }
                }
            }
            return maxi;
        }
        else
        {
            int mini = matrix[0, 0];
            int minii = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < mini && i < j)
                    {
                        mini = matrix[i, j];
                        minii = j;
                    }
                }
            }
            return minii;
        }
    }
    public void RemoveColumn(ref int[,] matrix, int columnIndex)
    {
        int[,] matrix2 = new int[matrix.GetLength(0), matrix.GetLength(1) - 1];
        for (int i = 0; i < matrix2.GetLength(0); i++)
        {
            for (int j = 0; j < matrix2.GetLength(1); j++) { 
                if (j < columnIndex)
                {
                    matrix2[i, j] = matrix[i, j];
                }
                else
                {
                    matrix2[i, j] = matrix[i, j + 1];
                }
            }

        }
        matrix = matrix2;
    }
    public void Task_2_10(ref int[,] matrix)
    {
        int maxi = Max_And_Min(matrix, true);
        int mini = Max_And_Min(matrix, false);
        if (maxi > mini)
        {
            RemoveColumn(ref matrix, maxi);
            RemoveColumn(ref matrix, mini);
        }
        if (maxi < mini)
        {
            RemoveColumn(ref matrix, mini);
            RemoveColumn(ref matrix, maxi);
        }
        else
        {
            RemoveColumn(ref matrix, mini);
        }
    }

    public void Task_2_11(int[,] A, int[,] B)
    {
        // code here

        // use FindMaxIndex(matrix, out row, out column); from Task_2_1

        // end
    }
    public int FindMaxColumnIndex(int[,] matrix)
    {
        int max = int.MinValue;
        int maxi = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] > max)
                {
                    max = matrix[i, j];
                    maxi = j;
                }
            }
        }
        return maxi;
    }
    public void Task_2_12(int[,] A, int[,] B)
    {
        // code here
        int max_column_for_A = FindMaxColumnIndex(A);
        int max_column_for_B = FindMaxColumnIndex(B);
        for (int i = 0; i < A.GetLength(0); i++)
        {
            (A[i, max_column_for_A], B[i, max_column_for_B]) = (B[i, max_column_for_B], A[i, max_column_for_A]);
        }
        // create and use FindMaxColumnIndex(matrix);

        // end
    }

    public void Task_2_13(ref int[,] matrix)
    {
        // code here

        // create and use RemoveRow(matrix, rowIndex);

        // end
    }
    public void SortRow(ref int[,] matrix, int rowIndex)
    {
        for (int i = 0; i < matrix.GetLength(1) - 1; i++)
        {
            for (int j = 0; j < matrix.GetLength(1) - i - 1; j++)
            {
                if (matrix[rowIndex, j] > matrix[rowIndex, j + 1])
                {
                    (matrix[rowIndex, j], matrix[rowIndex, j + 1]) = (matrix[rowIndex, j + 1], matrix[rowIndex, j]);
                }
            }
        }
    }
    public void Task_2_14(int[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            SortRow(ref matrix, i);
        }
    }

    public int Task_2_15(int[,] A, int[,] B, int[,] C)
    {
        int answer = 0;

        // code here

        // create and use GetAverageWithoutMinMax(matrix);

        // end

        // 1 - increasing   0 - no sequence   -1 - decreasing
        return answer;
    }
    public void SortNegative(ref int[] array)
    {
        int count = 0;
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] < 0) count++;
        }
        int[] negative_array = new int[count];
        int count_negative = 0;
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] < 0) negative_array[count_negative++] = i;
        }
        for (int i = 0; i < negative_array.Length - 1; i++)
        {
            for (int j = 0; j < negative_array.Length - 1 - i; j++)
            {
                if (array[negative_array[j]] < array[negative_array[j + 1]])
                {
                    (array[negative_array[j]], array[negative_array[j + 1]]) = (array[negative_array[j + 1]], array[negative_array[j]]);
                }
            }
        }
    }
    public void Task_2_16(int[] A, int[] B)
    {
        SortNegative(ref A);
        SortNegative(ref B);
    }

    public void Task_2_17(int[,] A, int[,] B)
    {
        // code here

        // create and use SortRowsByMaxElement(matrix);

        // end
    }
    public void SortDiagonal(ref int[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0) - 1; i++)
        {
            for (int j = 0; j < matrix.GetLength(0) - 1 - i; j++)
            {
                if (matrix[j, j] > matrix[j + 1, j + 1])
                {
                    (matrix[j, j], matrix[j + 1, j + 1]) = (matrix[j + 1, j + 1], matrix[j, j]);
                }
            }
        }
    }

    public void Task_2_18(int[,] A, int[,] B)
    {
        SortDiagonal(ref A);
        SortDiagonal(ref B);
    }

    public void Task_2_19(ref int[,] matrix)
    {
        // code here

        // use RemoveRow(matrix, rowIndex); from 2_13

        // end
    }
    public int[] FindColumsWithoutNullElements(int[,] matrix)
    {
        int count = 0;
        for (int i = 0; i < matrix.GetLength(1); i++)
        {
            bool flag = true;
            for (int j = 0; j < matrix.GetLength(0); j++)
            {
                if (matrix[j, i] == 0) flag = false;
            }
            if (flag)
            {
                count++;
            }
        }
        int[] array_of_index = new int[count];
        int index = 0;
        for (int i = 0; i < matrix.GetLength(1); i++)
        {
            bool flag = true;
            for (int j = 0; j < matrix.GetLength(0); j++)
            {
                if (matrix[j, i] == 0) flag = false;
            }
            if (flag) array_of_index[index++] = i;
        }
        return array_of_index;
    }
    public void RemoveColums(ref int[,] array)
    {
        int[] colums_for_array = FindColumsWithoutNullElements(array);
        for (int i = colums_for_array.Length - 1; i >= 0; i--)
        {
            RemoveColumn(ref array, colums_for_array[i]);
        }

    }
    public void Task_2_20(ref int[,] A, ref int[,] B)
    {
        RemoveColums(ref A);
        RemoveColums(ref B);

        // use RemoveColumn(matrix, columnIndex); from 2_10

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
    public int[] CountNegativeInRow(int[,] matrix)
    {
        int[] array = new int[matrix.GetLength(0)];
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            int count = 0;
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] < 0)
                    count++;
            }
            array[i] = count;
        }
        return array;
    }

    public int[] FindMaxNegativePerColumn(int[,] matrix)
    {
        int[] array = new int[matrix.GetLength(1)];
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            int maxNegative = int.MinValue;
            bool hasNegative = false;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, j] < 0)
                {
                    hasNegative = true;
                    if (matrix[i, j] > maxNegative) maxNegative = matrix[i, j];
                }
            }
            array[j] = hasNegative ? maxNegative : 0;
        }
        return array;
    }

    public void Task_2_22(int[,] matrix, out int[] rows, out int[] cols)
    {
        rows = null;
        cols = null;

        // code here
        rows = CountNegativeInRow(matrix);
        cols = FindMaxNegativePerColumn(matrix);

        // create and use CountNegativeInRow(matrix, rowIndex);
        // create and use FindMaxNegativePerColumn(matrix);

        // end
    }

    public void Task_2_23(double[,] A, double[,] B)
    {
        // code here

        // create and use MatrixValuesChange(matrix);

        // end
    }
    public void FindMaxIndex(int[,] matrix, out int row, out int column)
    {
        row = 0;
        column = 0;
        int max = matrix[0, 0];
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] > max)
                {
                    max = matrix[i, j];
                    row = i;
                    column = j;
                }
            }
        }
    }
    public void SwapColumnDiagonal(ref int[,] matrix, int columnIndex)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            (matrix[i, i], matrix[i, columnIndex]) = (matrix[i, columnIndex], matrix[i, i]);
        }
    }
    public void Task_2_24(int[,] A, int[,] B)
    {
        int row_for_A = 0;
        int column_for_A = 0;
        int row_for_B = 0;
        int column_for_B = 0;
        FindMaxIndex(A, out row_for_A, out column_for_A);
        FindMaxIndex(B, out row_for_B, out column_for_B);
        SwapColumnDiagonal(ref A, column_for_A);
        SwapColumnDiagonal(ref B, column_for_B);
        // use FindMaxIndex(matrix, out row, out column); like in 2_1
        // create and use SwapColumnDiagonal(matrix, columnIndex);

        // end
    }
    public int CountNegativeInRow(int[,] matrix, int rowIndex)
    {
        int count = 0;
        for (int i = 0; i < matrix.GetLength(1); i++)
        {
            if (matrix[rowIndex, i] < 0) count++;
        }
        return count;
    }
    public int FindRowWithMaxNegativeCount(int[,] matrix)
    {
        int max = 0;
        int row = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            int count = CountNegativeInRow(matrix, i);
            if (count > max)
            {
                max = count;
                row = i;
            }
        }
        return row;
    }
    public void Task_2_25(int[,] A, int[,] B, out int maxA, out int maxB)
    {
        maxA = 0;
        maxB = 0;

        // code here

        // create and use FindRowWithMaxNegativeCount(matrix);
        // in FindRowWithMaxNegativeCount create and use CountNegativeInRow(matrix, rowIndex); like in 2_22

        // end
    }

    public void Task_2_26(int[,] A, int[,] B)
    {
        // code here
        int row_for_A = FindRowWithMaxNegativeCount(A);
        int row_for_B = FindRowWithMaxNegativeCount(B);
        for (int i = 0; i < A.GetLength(1); i++)
        {
            (A[row_for_A, i], B[row_for_B, i]) = (B[row_for_B, i], A[row_for_A, i]);
        }
        // create and use FindRowWithMaxNegativeCount(matrix); like in 2_25
        // in FindRowWithMaxNegativeCount use CountNegativeInRow(matrix, rowIndex); from 2_22

        // end
    }

    public void Task_2_27(int[,] A, int[,] B)
    {
        // code here

        // create and use FindRowMaxIndex(matrix, rowIndex, out columnIndex);
        // create and use ReplaceMaxElementOdd(matrix, row, column);
        // create and use ReplaceMaxElementEven(matrix, row, column);

        // end
    }
    public int FindSequence(int[] array, int A, int B)
    {
        bool increasing = array[A] < array[A + 1];
        for (int i = A; i < B; i++)
        {
            if ((increasing && array[i] > array[i + 1]) || (!increasing && array[i] < array[i + 1])) return 0;
        }
        if (increasing) return 1;
        return -1;
    }



    public void Task_2_28a(int[] first, int[] second, ref int answerFirst, ref int answerSecond)
    {
        // code here
        answerFirst = FindSequence(first, 0, first.Length - 1);
        answerSecond = FindSequence(second, 0, second.Length - 1);
        // end
    }
    public int[,] GetFor2_28b(int[] array)
    {
        int k = 0;
        for (int i = 0; i < array.Length; i++)
        {
            for (int j = i + 1; j < array.Length; j++)
            {
                if (FindSequence(array, i, j) != 0) k++;
            }
        }
        int[,] answerFirst = new int[k, 2];
        int n = 0;
        for (int i = 0; i < array.Length; i++)
        {
            for (int j = i + 1; j < array.Length; j++)
            {
                if (FindSequence(array, i, j) != 0)
                {
                    answerFirst[n, 0] = i;
                    answerFirst[n++, 1] = j;
                }
            }
        }
        return answerFirst;

    }

    public void Task_2_28b(int[] first, int[] second, ref int[,] answerFirst, ref int[,] answerSecond)
    {
        answerFirst = GetFor2_28b(first);
        answerSecond = GetFor2_28b(second);
    }

    public int[] GetFor2_28(int[] array)
    {
        int start_for_first = 0;
        int end_for_first = 0;
        for (int i = 0; i < array.Length; i++)
        {
            for (int j = i + 1; j < array.Length; j++)
            {
                if (FindSequence(array, i, j) != 0 && (end_for_first - start_for_first) < (j - i))
                {
                    start_for_first = i;
                    end_for_first = j;
                }
            }
        }
        int[] answerFirst = new int[2];
        answerFirst[0] = start_for_first;
        answerFirst[1] = end_for_first;
        return answerFirst;

    }


    public void Task_2_28c(int[] first, int[] second, ref int[] answerFirst, ref int[] answerSecond)
    {
        answerFirst = GetFor2_28(first);
        answerSecond = GetFor2_28(second);

    }
    #endregion

    #region Level 3
    public void Task_3_1(ref double[,] firstSumAndY, ref double[,] secondSumAndY)
    {
        // code here

        // create and use public delegate SumFunction(x) and public delegate YFunction(x)
        // create and use method GetSumAndY(sFunction, yFunction, a, b, h);
        // create and use 2 methods for both functions calculating at specific x

        // end
    }
    public delegate void SortRowStyle(ref int[,] matrix, int rowIndex);
    public void SortAscending(ref int[,] matrix, int rowIndex)
    {
        for (int i = 0; i < matrix.GetLength(1) - 1; i++)
        {
            for (int j = 0; j < matrix.GetLength(1) - 1 - i; j++)
            {
                if (matrix[rowIndex, j] > matrix[rowIndex, j + 1])
                {
                    (matrix[rowIndex, j], matrix[rowIndex, j + 1]) = (matrix[rowIndex, j + 1], matrix[rowIndex, j]);
                }
            }
        }
    }
    public void SortDescending(ref int[,] matrix, int rowIndex)
    {
        for (int i = 0; i < matrix.GetLength(1) - 1; i++)
        {
            for (int j = 0; j < matrix.GetLength(1) - 1 - i; j++)
            {
                if (matrix[rowIndex, j] < matrix[rowIndex, j + 1])
                {
                    (matrix[rowIndex, j], matrix[rowIndex, j + 1]) = (matrix[rowIndex, j + 1], matrix[rowIndex, j]);
                }
            }
        }

    }

    public void Task_3_2(int[,] matrix)
    {
        SortRowStyle sortStyle = default(SortRowStyle);

        // code here
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            if (i % 2 == 0)
            {
                sortStyle = SortAscending;
            }
            else sortStyle = SortDescending;
            sortStyle(ref matrix, i);
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
        // create and use methods SwapRight(array) and SwapLeft(array)
        // create and use method GetSum(array, start, h) that sum elements with a negative indexes
        // change method in variable swapper in the if/else and than use swapper(matrix)

        // end

        return answer;
    }
    public delegate int[] GetTriangle(int[,] matrix);
    public int[] GetUpperTriange(int[,] array)
    {
        int[] upperTriange = new int[array.GetLength(0) * (array.GetLength(0) + 1) / 2];
        int count = 0;
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(0); j++)
            {
                if (i <= j) upperTriange[count++] = array[i, j];
            }
        }
        return upperTriange;
    }
    public int[] GetLowerTriange(int[,] array)
    {
        int[] lowerTriange = new int[array.GetLength(0) * (array.GetLength(0) + 1) / 2];
        int count = 0;
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(0); j++)
            {
                if (i >= j) lowerTriange[count++] = array[i, j];
            }
        }
        return lowerTriange;
    }

    public int GetSum(GetTriangle gettriangle, int[,] matrix)
    {
        int[] array = gettriangle(matrix);
        int sum = 0;
        for (int i = 0; i < array.Length; i++)
        {
            sum += (array[i] * array[i]);
        }
        return sum;
    }

    public int Task_3_4(int[,] matrix, bool isUpperTriangle)
    {
        int answer = 0;

        GetTriangle sortStyle = default(GetTriangle);
        if (isUpperTriangle)
        {
            sortStyle = GetUpperTriange;

        }
        else
        {
            sortStyle = GetLowerTriange;
        }
        answer = GetSum(sortStyle, matrix);
        // code here

        // create and use public delegate GetTriangle(matrix);
        // create and use methods GetUpperTriange(array) and GetLowerTriange(array)
        // create and use GetSum(GetTriangle, matrix)

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
        int j = 0;
        for (int i = 1; i < matrix.GetLength(0); i++)
        {
            if (matrix[0, i] > matrix[0, j])
            {
                j = i;
            }
        }
        return j;
    }
    public void SwapColumns(int[,] matrix, FindElementDelegate findDiagonalMaxIndex, FindElementDelegate findFirstRowMaxIndex)
    {
        int diagonal_max = findDiagonalMaxIndex(matrix);
        int first_row_max = findFirstRowMaxIndex(matrix);
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            (matrix[i, first_row_max], matrix[i, diagonal_max]) = (matrix[i, diagonal_max], matrix[i, first_row_max]);
        }

    }
    public void Task_3_6(int[,] matrix)
    {
        SwapColumns(matrix, FindDiagonalMaxIndex, FindFirstRowMaxIndex);
    }

    public void Task_3_7(ref int[,] B, int[,] C)
    {
        // code here

        // create and use public delegate CountPositive(matrix, index);
        // use CountRowPositive(matrix, rowIndex) from Task_2_7
        // use CountColumnPositive(matrix, colIndex) from Task_2_7
        // create and use method InsertColumn(matrixB, CountRow, matrixC, CountColumn);

        // end
    }
    public delegate int FindIndex(int[,] matrix);


    public void RemoveColumns(ref int[,] matrix, FindIndex findMaxBelowDiagonalIndex, FindIndex findMinAboveDiagonalIndex)
    {
        int res1 = findMaxBelowDiagonalIndex(matrix);
        int res2 = findMinAboveDiagonalIndex(matrix);
        if (res1 > res2)
        {
            RemoveColumn(ref matrix, res1);
            RemoveColumn(ref matrix, res2);
        }
        if (res1 < res2)
        {
            RemoveColumn(ref matrix, res2);
            RemoveColumn(ref matrix, res1);
        }
        else
        {
            RemoveColumn(ref matrix, res1);
        }
    }
    public int FindMaxBelowDiagonalIndex(int[,] matrix)
    {
        int max = matrix[0, 0];
        int maxi = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] > max && i >= j)
                {
                    max = matrix[i, j];
                    maxi = j;
                }
            }
        }
        return maxi;
    }

    public int FindMinAboveDiagonalIndex(int[,] matrix)
    {
        int mini = matrix[0, 0];
        int minii = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] < mini && i < j)
                {
                    mini = matrix[i, j];
                    minii = j;
                }
            }
        }
        return minii;
    }
    public void Task_3_10(ref int[,] matrix)
    {
        FindIndex searchArea = default(FindIndex);
        RemoveColumns(ref matrix, FindMaxBelowDiagonalIndex, FindMinAboveDiagonalIndex);

        // code here

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
    public void Task_3_22(int[,] matrix, out int[] rows, out int[] cols)
    {

        rows = null;
        cols = null;
        // code here
        FindNegatives(matrix, CountNegativeInRow, FindMaxNegativePerColumn, out rows, out cols);
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
        if (FindSequence(array, A, B) == 1)
        {
            return true;
        }
        return false;
    }
    public bool FindDecreasingSequence(int[] array, int A, int B)
    {
        if (FindSequence(array, A, B) == -1)
        {
            return true;
        }
        return false;
    }
    public int DefineSequence(int[] array, IsSequence findIncreasingSequence, IsSequence findDecreasingSequence)
    {
        bool increasing = findIncreasingSequence(array, 0, array.Length - 1);
        bool decreasing = findDecreasingSequence(array, 0, array.Length - 1);
        if (increasing)
        {
            return 1;
        }
        if (decreasing)
        {
            return -1;
        }
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
    public int[] FindLongestSequence(int[] array, IsSequence sequence)
    {
        int start = 0, end = 0;
        for (int i = 0; i < array.Length; i++)
        {
            for (int j = i + 1; j < array.Length; j++)
            {
                if (sequence(array, i, j) && (j - i) > end - start)
                {
                    start = i;
                    end = j;
                }
            }
        }
        return new int[] { start, end};
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
    public delegate void MatrixConverter(double[,] matrix);
    public void ToUpperTriangular(double[,] matrix)
    {
        int n = matrix.GetLength(0);
        for (int j = 0; j <= n - 2; j++)
        {
            for (int k = j + 1; k <= n - 1; k ++)
            {
                double p = (double)matrix[k, j] / matrix[j, j];
                for (int m = j; m <= n - 1; m++)
                {
                    matrix[k, m] = (matrix[k, m] - matrix[j, m] * p);
                }

            }
        }
    }
    public void ToLowerTriangular(double[,] matrix)
    {
        int n = matrix.GetLength(0);
        for (int j = n - 1; j >= 1; j--)
        {
            for (int k = j - 1; k >= 0; k--)
            {
                double p = (double)matrix[k, j] / matrix[j, j];
                for (int m = n - 1; m >= 0; m--)
                {
                    matrix[k, m] = (matrix[k, m] - matrix[j, m] * p);
                }
            }
        }
    }
    public void ToLeftDiagonal(double[,] matrix)
    {
        ToUpperTriangular(matrix);
        ToLowerTriangular(matrix);
    }
    public void ToRightDiagonal(double[,] matrix)
    {
        ToUpperTriangular(matrix);
        ToLowerTriangular(matrix);
    }
    public double[,] Task_4(double[,] matrix, int index)
    {
        MatrixConverter[] mc = new MatrixConverter[4];
        mc[0] = ToUpperTriangular;
        mc[1] = ToLowerTriangular;
        mc[2] = ToLeftDiagonal;
        mc[3] = ToRightDiagonal;
        mc[index](matrix);

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
