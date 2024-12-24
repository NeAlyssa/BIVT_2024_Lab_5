using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Numerics;
using System.Reflection;
using System.Reflection.Metadata;
using System.Runtime.ExceptionServices;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class Program
{
    public static void Main()
    {
        Program program = new Program();

        

    }
    #region Level 1
    public long Task_1_1(int n, int k)
    {
        long answer = 0;

        // code here

        // create and use Combinations(n, k);
        // create and use Factorial(n);

        static int Combinations(int n, int k)
        {
            if (n < 0 || k < 0) return 0;
            return (Factorial(n) / (Factorial(k) * Factorial(n - k)));
        }


        answer = Combinations(n, k);
        // end

        return answer;
    }
    static int Factorial(int n)
    {
        if (n == 1) return 1;
        return Factorial(n - 1) * n;
    }
    public int Task_1_2(double[] first, double[] second)
    {
        int answer = 0;

        // code here

        // create and use GeronArea(a, b, c);

        static double GeronArea(double[] sides)
        {
            //проверка
            foreach (double i in sides)
            {
                if (i <= 0) return -1;
            }

            double mx = 0;
            foreach (double i in sides)
            {
                if (i > mx) mx = i;
            }
            if (mx >= sides[0] + sides[1] + sides[2] - mx) return -1;

            double p = (sides[0] + sides[1] + sides[2]) / 2;
            return Math.Pow(p * (p - sides[0]) * (p - sides[1]) * (p - sides[2]), 0.5);
        }

        static int Comparison(double[] first, double[] second)
        {
            double res1 = GeronArea(first);
            double res2 = GeronArea(second);


            if (res1 == -1 || res2 == -1) return -1;
            if (res1 > res2) return 1;
            if (res2 > res1) return 2;
            return 0;

        }
        answer = Comparison(first, second);

        // end
        // first = 1, second = 2, equal = 0, error = -1
        return answer;
    }

    public int Task_1_3a(double v1, double a1, double v2, double a2, int time)
    {
        int answer = 0;

        // code here

        // create and use GetDistance(v, a, t); t - hours
        if (v1 < 0 || v2 < 0 || time < 0) return 0;

        double first = GetDistance(v1, a1, time);
        double second = GetDistance(v2, a2, time);

        if (first > second) answer = 1;
        else
        {
            if (second > first) answer = 2;
        }
        // end

        // first = 1, second = 2, equal = 0
        return answer;
    }

    public double GetDistance(double v, double a, double t)
    {
        double res = v * t + a * t * t / 2;
        return res;
    }

    public int Task_1_3b(double v1, double a1, double v2, double a2)
    {
        int answer = 0;

        // code here

        if (v1 <= 0 || v2 <= 0) return 0;

        //use GetDistance(v, a, t); t - hours
        for (int i = 1; ; i++)
        {
            if (GetDistance(v1, a1, i) <= GetDistance(v2, a2, i))
            {
                answer = i;
                break;
            }
        }
        Console.WriteLine(answer);
        // end

        return answer;
    }
    #endregion

    #region Level 2
    public void Task_2_1(int[,] A, int[,] B)
    {
        // code here


        // create and use FindMaxIndex(matrix, out row, out column);

        // end
    }

    public void Task_2_2(double[] A, double[] B)
    {
        // code here
        int fl = 0;
        foreach (double i in A)
        {
            if (i != 0)
            {
                fl = 1;
            }
        }
        foreach (double i in B)
        {
            if (i != 0)
            {
                fl = 1;
            }
        }
        if (A == null || B == null || fl == 0) return;

        // create and use FindMaxIndex(array);
        // only 1 array has to be changed!


        if (FindMaxIndex(A) < FindMaxIndex(B))
        {
            int n = FindMaxIndex(A);
            double average = 0;
            for (int i = n + 1; i < A.Length; i++)
                average += A[i];
            average /= (A.Length - n - 1);
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] == A[n])
                {

                    A[i] = average;
                }
            }
        }
        else
        {
            if (FindMaxIndex(A) == FindMaxIndex(B)) return;
            else
            {
                int n = FindMaxIndex(B);
                double average = 0;
                for (int i = n + 1; i < B.Length; i++)
                    average += B[i];
                average /= (B.Length - n - 1);
                for (int i = 0; i < B.Length; i++)
                {
                    if (B[i] == B[n]) B[i] = average;
                }
            }
        }

        // end
    }

    public int FindMaxIndex(double[] array)
    {
        int index = 0;
        double max = Double.MinValue;
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] > max)
            {
                max = array[i];
                index = i;
            }
        }

        return index;

    }

    public void Task_2_3(ref int[,] B, ref int[,] C)
    {
        // code here

        //  create and use method FindDiagonalMaxIndex(matrix);

        // end
    }

    public void Task_2_4(int[,] A, int[,] B)
    {
        // code here

        //  create and use method FindDiagonalMaxIndex(matrix); like in Task_2_3
        int fl = 0;
        foreach (double i in A)
        {
            if (i != 0)
            {
                fl = 1;
            }
        }
        foreach (double i in B)
        {
            if (i != 0)
            {
                fl = 1;
            }
        }

        if (A.GetLength(1) != B.GetLength(0) || A == null || B == null || fl == 0) return;

        int row = FindDiagonalIndex(A);
        int col = FindDiagonalIndex(B);

        for (int i = 0; i < A.GetLength(1); i++)
        {
            int save = B[i, col];
            B[i, col] = A[row, i];
            A[row, i] = save;
        }


        // end
    }
    public int FindDiagonalIndex(int[,] matrix)
    {
        int answer = 0;
        int mx = int.MinValue;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            if (matrix[i, i] > mx)
            {
                mx = matrix[i, i];
                answer = i;
            }
        }
        return answer;
    }

    public void Task_2_5(int[,] A, int[,] B)
    {
        // code here

        // create and use FindMaxInColumn(matrix, columnIndex, out rowIndex);

        // end
    }

    public void Task_2_6(ref int[] A, int[] B)
    {
        // code here

        // create and use FindMax(matrix, out row, out column); like in Task_2_1
        // create and use DeleteElement(array, index);

        int fl = 0;
        foreach (double i in A)
        {
            if (i != 0)
            {
                fl = 1;
            }
        }
        foreach (double i in B)
        {
            if (i != 0)
            {
                fl = 1;
            }
        }

        if (A == null || B == null || fl == 0) return;


        DeleteElement(ref A, FindMax(A));
        DeleteElement(ref B, FindMax(B));


        int[] need = new int[A.Length + B.Length];
        int count = 0;
        for (int i = 0; i < A.Length; i++)
        {
            need[i] = A[i];
            if (i == A.Length - 1) count = i + 1;

        }
        for (int i = 0; i < B.Length; i++)
        {
            need[count] = B[i];
            count++;

        }
        A = need;

    }

    public int FindMax(int[] matrix)
    {
        int index = 0;
        int mx = int.MinValue;
        for (int i = 0; i < matrix.Length; i++)
        {
            if (matrix[i] > mx)
            {
                mx = matrix[i];
                index = i;
            }
        }
        return index;
    }

    static void DeleteElement(ref int[] array, int index)
    {
        int[] need = new int[array.Length - 1];
        for (int i = 0; i < index; i++)
            need[i] = array[i];
        for (int i = index + 1; i < array.Length; i++)
            need[i - 1] = array[i];

        array = need;

    }


    public void Task_2_7(ref int[,] B, int[,] C)
    {
        // code here

        // create and use CountRowPositive(matrix, rowIndex);
        // create and use CountColumnPositive(matrix, colIndex);

        // end
    }

    public void Task_2_8(int[] A, int[] B)
    {
        // code here
        int fl = 0;
        foreach (double i in A)
        {
            if (i != 0)
            {
                fl = 1;
            }
        }
        foreach (double i in B)
        {
            if (i != 0)
            {
                fl = 1;
            }
        }

        if (A == null || B == null || fl == 0) return;
        // create and use SortArrayPart(array, startIndex);

        SortArrayPart(A, FindMax(A) + 1);
        SortArrayPart(B, FindMax(B) + 1);
        // end
    }

    static int[] SortArrayPart(int[] array, int startIndex)
    {

        for (int i = 0; i < array.Length - startIndex; i++)
        {
            for (int j = startIndex; j < array.Length - 1 - i; j++)
            {
                if (array[j + 1] < array[j])
                {
                    int save = array[j + 1];
                    array[j + 1] = array[j];
                    array[j] = save;

                }
            }


        }

        return array;
    }


    public int[] Task_2_9(int[,] A, int[,] C)
    {
        int[] answer = default(int[]);

        // code here

        // create and use SumPositiveElementsInColumns(matrix);

        // end

        return answer;
    }

    public void Task_2_10(ref int[,] matrix)
    {
        // code here

        // create and use RemoveColumn(matrix, columnIndex);
        int fl = 0;
        foreach (int i in matrix)
        {
            if (i != 0)
            {
                fl = 1;
            }
        }

        if (matrix == null || fl == 0 || matrix.GetLength(0) != matrix.GetLength(1)) return;

        int col1 = FindColIndexMaxUnder(matrix);
        int col2 = FindColIndexMinUpper(matrix);

        if (col1 == col2)
        {
            RemoveColumn(ref matrix, col1);
        }

        else
        {

            RemoveColumn(ref matrix, col1);

            RemoveColumn(ref matrix, col2 - 1);

        }


        // end
    }
    public int FindColIndexMaxUnder(int[,] matrix)
    {
        int mx = int.MinValue;
        int indexCol = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < i + 1; j++)
            {
                if (matrix[i, j] > mx)
                {
                    mx = matrix[i, j];
                    indexCol = j;
                }
            }
        }
        return indexCol;
    }

    public int FindColIndexMinUpper(int[,] matrix)
    {
        int min = int.MaxValue;
        int indexCol = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = i + 1; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] < min)
                {
                    min = matrix[i, j];
                    indexCol = j;
                }
            }
        }
        return indexCol;
    }

    static void RemoveColumn(ref int[,] matrix, int columnIndex)
    {
        int[,] need = new int[matrix.GetLength(0), matrix.GetLength(1) - 1];
        for (int i = 0; i < columnIndex; i++)
        {
            for (int j = 0; j < matrix.GetLength(0); j++)
            {
                need[j, i] = matrix[j, i];
            }

        }
        for (int i = columnIndex + 1; i < matrix.GetLength(1); i++)
        {
            for (int j = 0; j < matrix.GetLength(0); j++)
            {
                need[j, i - 1] = matrix[j, i];
            }
        }
        matrix = need;
    }

    public void Task_2_11(int[,] A, int[,] B)
    {
        // code here

        // use FindMaxIndex(matrix, out row, out column); from Task_2_1

        // end
    }
    public void Task_2_12(int[,] A, int[,] B)
    {
        // code here

        // create and use FindMaxColumnIndex(matrix);
        int fl = 0;
        foreach (double i in A)
        {
            if (i != 0)
            {
                fl = 1;
            }
        }
        foreach (double i in B)
        {
            if (i != 0)
            {
                fl = 1;
            }
        }

        if (A == null || B == null || fl == 0 || A.GetLength(0) != B.GetLength(0) || B.GetLength(1) != A.GetLength(1)) return;

        int col1 = FindMaxColumnIndex(A);
        int col2 = FindMaxColumnIndex(B);

        for (int i = 0; i < A.GetLength(0); i++)
        {
            int save = B[i, col2];
            B[i, col2] = A[i, col1];
            A[i, col1] = save;
        }

        // end
    }

    public int FindMaxColumnIndex(int[,] matrix)
    {
        int index = 0;
        int max = int.MinValue;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] > max)
                {
                    max = matrix[i, j];
                    index = j;
                }
            }
        }
        return index;
    }

    public void Task_2_13(ref int[,] matrix)
    {
        // code here

        // create and use RemoveRow(matrix, rowIndex);

        // end
    }

    public void Task_2_14(int[,] matrix)
    {
        // code here

        // create and use SortRow(matrix, rowIndex);
        int fl = 0;
        foreach (int i in matrix)
        {
            if (i != 0)
            {
                fl = 1;
            }
        }

        if (matrix == null || fl == 0) return;

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            SortRow(matrix, i);
        }
        // end
    }
    public void SortRow(int[,] matrix, int rowIndex)
    {
        for (int i = 0; i < matrix.GetLength(1); i++)
        {
            for (int j = 0; j < matrix.GetLength(1) - i - 1; j++)
            {
                if (matrix[rowIndex, j] > matrix[rowIndex, j + 1])
                {
                    int save = matrix[rowIndex, j + 1];
                    matrix[rowIndex, j + 1] = matrix[rowIndex, j];
                    matrix[rowIndex, j] = save;
                }
            }
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

    public void Task_2_16(int[] A, int[] B)
    {
        // code here

        // create and use SortNegative(array);

        int fl = 0;
        foreach (double i in A)
        {
            if (i != 0)
            {
                fl = 1;
            }
        }
        foreach (double i in B)
        {
            if (i != 0)
            {
                fl = 1;
            }
        }

        if (A == null || B == null || fl == 0) return;

        SortNegative(A);
        SortNegative(B);
        // end
    }
    public void SortNegative(int[] array)
    {
        int count = 0;
        foreach (int i in array)
        {
            if (i < 0) count++;
        }
        int[] negative = new int[count];


        count = 0;
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] < 0)
            {
                negative[count] = array[i];
                count++;
            }
        }

        for (int i = 0; i < negative.Length; i++)
        {
            for (int j = 0; j < negative.Length - i - 1; j++)
            {
                if (negative[j + 1] > negative[j])
                {
                    int save = negative[j + 1];
                    negative[j + 1] = negative[j];
                    negative[j] = save;
                }
            }
        }

        count = 0;
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] < 0)
            {
                array[i] = negative[count];
                count++;
            }
        }

    }

    public void Task_2_17(int[,] A, int[,] B)
    {
        // code here

        // create and use SortRowsByMaxElement(matrix);

        // end
    }

    public void Task_2_18(int[,] A, int[,] B)
    {
        // code here

        // create and use SortDiagonal(matrix);
        int fl = 0;
        foreach (double i in A)
        {
            if (i != 0)
            {
                fl = 1;
            }
        }
        foreach (double i in B)
        {
            if (i != 0)
            {
                fl = 1;
            }
        }

        if (A == null || B == null || fl == 0 || A.GetLength(0) != A.GetLength(1) || B.GetLength(0) != B.GetLength(1)) return;

        SortDiagonal(A);
        SortDiagonal(B);
        // end
    }

    public void SortDiagonal(int[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(0) - i - 1; j++)
            {
                if (matrix[j + 1, j + 1] < matrix[j, j])
                {
                    int save = matrix[j + 1, j + 1];
                    matrix[j + 1, j + 1] = matrix[j, j];
                    matrix[j, j] = save;
                }
            }
        }
    }
    public void Task_2_19(ref int[,] matrix)
    {
        // code here

        // use RemoveRow(matrix, rowIndex); from 2_13

        // end
    }
    public void Task_2_20(ref int[,] A, ref int[,] B)
    {
        // code here

        // use RemoveColumn(matrix, columnIndex); from 2_10
        int fl = 0;
        foreach (double i in A)
        {
            if (i != 0)
            {
                fl = 1;
            }
        }
        foreach (double i in B)
        {
            if (i != 0)
            {
                fl = 1;
            }
        }

        if (A == null || B == null || fl == 0) return;


        RomoveAllColumn(ref A);
        RomoveAllColumn(ref B);


        // end
    }

    public void RomoveAllColumn(ref int[,] matrix)
    {

        int count = 0;
        for (int i = 0; i < matrix.GetLength(1); i++)
        {
            int fl = 0;
            for (int j = 0; j < matrix.GetLength(0); j++)
            {
                if (matrix[j, i] == 0)
                {
                    fl = 1;
                    break;
                }
            }

            if (fl == 0) count++;
        }
        int[] colRemove = new int[count];
        count = 0;

        for (int i = 0; i < matrix.GetLength(1); i++)
        {
            int fl = 0;
            for (int j = 0; j < matrix.GetLength(0); j++)
            {
                if (matrix[j, i] == 0)
                {
                    fl = 1;
                    break;
                }
            }
            if (fl == 0)
            {
                colRemove[count] = i;
                count++;
            }

        }

        foreach (int i in colRemove)
        {

        }
        for (int i = 0; i < colRemove.Length; i++)
        {
            RemoveColumn(ref matrix, colRemove[i] - i);
        }
    }

    public void Task_2_21(int[,] A, int[,] B, out int[] answerA, out int[] answerB)
    {
        answerA = null;
        answerB = null;

        // code here

        // create and use CreateArrayFromMins(matrix);

        // end
    }

    public void Task_2_22(int[,] matrix, out int[] rows, out int[] cols)
    {
        rows = null;
        cols = null;

        // code here

        // create and use CountNegativeInRow(matrix, rowIndex);
        // create and use FindMaxNegativePerColumn(matrix);
        int fl = 0;
        foreach (double i in matrix)
        {
            if (i != 0)
            {
                fl = 1;
            }
        }

        if (matrix == null || fl == 0) return;

        rows = new int[matrix.GetLength(0)];
        cols = FindMaxNegativePerColumn(matrix);
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            rows[i] = CountNegativeInRow(matrix, i);
        }

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

    public int[] FindMaxNegativePerColumn(int[,] matrix)
    {
        int[] answer = new int[matrix.GetLength(1)];
        int count = 0;
        for (int i = 0; i < matrix.GetLength(1); i++)
        {
            int mx = int.MinValue;
            for (int j = 0; j < matrix.GetLength(0); j++)
            {
                if (matrix[j, i] < 0 && matrix[j, i] > mx) mx = matrix[j, i];
            }
            answer[count] = mx;
            count++;
        }
        return answer;
    }


    public void Task_2_23(double[,] A, double[,] B)
    {
        // code here

        // create and use MatrixValuesChange(matrix);

        // end
    }

    public void Task_2_24(int[,] A, int[,] B)
    {
        // code here

        // use FindMaxIndex(matrix, out row, out column); like in 2_1
        // create and use SwapColumnDiagonal(matrix, columnIndex);
        int fl = 0;
        foreach (double i in A)
        {
            if (i != 0)
            {
                fl = 1;
            }
        }
        foreach (double i in B)
        {
            if (i != 0)
            {
                fl = 1;
            }
        }

        if (A == null || B == null || fl == 0) return;

        int row1, row2, col1, col2;
        FindMaxIndex(A, out row1, out col1);
        FindMaxIndex(B, out row2, out col2);

        SwapColumnDiagonal(A, col1);
        SwapColumnDiagonal(B, col2);

        // end
    }
    public void FindMaxIndex(int[,] matrix, out int row, out int column)
    {
        row = 0; column = 0;
        int mx = int.MinValue;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] > mx)
                {
                    mx = matrix[i, j];
                    row = i;
                    column = j;
                }
            }
        }
    }
    public void SwapColumnDiagonal(int[,] matrix, int columnIndex)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            int save = matrix[i, i];
            matrix[i, i] = matrix[i, columnIndex];
            matrix[i, columnIndex] = save;
        }
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

        // create and use FindRowWithMaxNegativeCount(matrix); like in 2_25
        // in FindRowWithMaxNegativeCount use CountNegativeInRow(matrix, rowIndex); from 2_22
        int fl = 0;
        foreach (double i in A)
        {
            if (i != 0)
            {
                fl = 1;
            }
        }
        foreach (double i in B)
        {
            if (i != 0)
            {
                fl = 1;
            }
        }

        if (A == null || B == null || fl == 0 || A.GetLength(0) != B.GetLength(0) || A.GetLength(1) != B.GetLength(1)) return;

        SwapRows(A, B, FindRowWithMaxNegativeCount(A), FindRowWithMaxNegativeCount(B));

        // end
    }


    public int FindRowWithMaxNegativeCount(int[,] matrix)
    {
        int row = 0, max = int.MinValue;
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

    public void SwapRows(int[,] A, int[,] B, int rowA, int rowB)
    {
        for (int i = 0; i < A.GetLength(1); i++)
        {
            int save = B[rowB, i];
            B[rowB, i] = A[rowA, i];
            A[rowA, i] = save;
        }
    }
    public void Task_2_27(int[,] A, int[,] B)
    {
        // code here

        // create and use FindRowMaxIndex(matrix, rowIndex, out columnIndex);
        // create and use ReplaceMaxElementOdd(matrix, row, column);
        // create and use ReplaceMaxElementEven(matrix, row, column);

        // end
    }

    public void Task_2_28a(int[] first, int[] second, ref int answerFirst, ref int answerSecond)
    {
        // code here

        // create and use FindSequence(array, A, B); // 1 - increasing, 0 - no sequence,  -1 - decreasing
        // A and B - start and end indexes of elements from array for search
        int fl = 0;
        foreach (double i in first)
        {
            if (i != 0)
            {
                fl = 1;
            }
        }
        foreach (double i in second)
        {
            if (i != 0)
            {
                fl = 1;
            }
        }

        if (first == null || second == null || fl == 0) return;

        answerFirst = FindSequence(first, 0, first.Length - 1);
        answerSecond = FindSequence(second, 0, second.Length - 1);
        //Console.WriteLine(answerFirst);
        //Console.WriteLine(answerSecond);

        // end
    }
    public int FindSequence(int[] array, int A, int B)
    {
        int fl1 = 0; //возрастающая
        for (int i = A; i < B; i++)
        {
            if (array[i] >= array[i + 1])
            {
                fl1 = 1;
                break;
            }

        }
        int fl2 = 0;//убывающая
        for (int i = A; i < B; i++)
        {
            if (array[i] <= array[i + 1])
            {
                fl2 = 1;
                break;
            }
        }

        if (fl1 == 0) return 1;
        else
        {
            if (fl2 == 0) return -1;
            else return 0;
        }
    }

    public void Task_2_28b(int[] first, int[] second, ref int[,] answerFirst, ref int[,] answerSecond)
    {
        // code here

        // use FindSequence(array, A, B); from Task_2_28a or entirely Task_2_28a
        // A and B - start and end indexes of elements from array for search
        int fl = 0;
        foreach (double i in first)
        {
            if (i != 0)
            {
                fl = 1;
            }
        }
        foreach (double i in second)
        {
            if (i != 0)
            {
                fl = 1;
            }
        }

        if (first == null || second == null || fl == 0) return;

        answerFirst = FindAllIntervals(first);
        answerSecond = FindAllIntervals(second);

        // end
    }
    public int FindSequence1(int[] array, int A, int B)
    {
        int fl1 = 0; //не убывает 
        for (int i = A; i < B; i++)
        {
            if (array[i] > array[i + 1])
            {
                fl1 = 1;
                break;
            }

        }
        int fl2 = 0;//не возрастает 
        for (int i = A; i < B; i++)
        {
            if (array[i] < array[i + 1])
            {
                fl2 = 1;
                break;
            }
        }

        if (fl1 == 0) return 1;
        else
        {
            if (fl2 == 0) return -1;
            else return 0;
        }
    }
    public int[,] FindAllIntervals(int[] array)
    {
        //Console.WriteLine("===");
        int count = 0;
        for (int i = 0; i < array.Length - 1; i++)
        {
            for (int j = i + 1; j < array.Length; j++)
            {
                if (FindSequence1(array, i, j) == 1 || FindSequence1(array, i, j) == -1) count++;
            }
        }

        int[,] answer = new int[count, 2];
        count = 0;
        for (int i = 0; i < array.Length - 1; i++)
        {
            for (int j = i + 1; j < array.Length; j++)
            {
                if (FindSequence1(array, i, j) == 1 || FindSequence1(array, i, j) == -1)
                {
                    //Console.WriteLine("{0},{1},{2}",array[i],array[j], FindSequence(array, i, j));
                    answer[count, 0] = i;
                    answer[count, 1] = j;
                    count++;
                }
            }
        }
        return answer;
    }

    public void Task_2_28c(int[] first, int[] second, ref int[] answerFirst, ref int[] answerSecond)
    {
        // code here

        // use FindSequence(array, A, B); from Task_2_28a or entirely Task_2_28a or Task_2_28b
        // A and B - start and end indexes of elements from array for search
        int fl = 0;
        foreach (double i in first)
        {
            if (i != 0)
            {
                fl = 1;
            }
        }
        foreach (double i in second)
        {
            if (i != 0)
            {
                fl = 1;
            }
        }

        if (first == null || second == null || fl == 0) return;

        answerFirst = FindMaxInterval(first);
        answerSecond = FindMaxInterval(second);

        // end
    }
    public int[] FindMaxInterval(int[] array)
    {
        int[] mx = new int[2]; ;
        int[,] allInter = FindAllIntervals(array);
        for (int i = 0; i < allInter.GetLength(0); i++)
        {
            if ((allInter[i, 1] - allInter[i, 0]) > mx[1] - mx[0])
            {
                mx[0] = allInter[i, 0];
                mx[1] = allInter[i, 1];

            }

        }
        return mx;
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

    public void Task_3_2(int[,] matrix)
    {
        // SortRowStyle sortStyle = default(SortRowStyle); - uncomment me

        // code here

        // create and use public delegate SortRowStyle(matrix, rowIndex);
        // create and use methods SortAscending(matrix, rowIndex) and SortDescending(matrix, rowIndex)
        // change method in variable sortStyle in the loop here and use it for row sorting

        int fl = 0;
        foreach (double i in matrix)
        {
            if (i != 0)
            {
                fl = 1;
            }
        }

        if (matrix == null || fl == 0) return;

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            SortRowStyle Sort = (i % 2 == 0) ? SortAscending : SortDescending; //тернарный оператор 
            Sort(matrix, i);
        }

        // end
    }
    public delegate void SortRowStyle(int[,] matrix, int rowIndex);

    public void SortAscending(int[,] matrix, int rowIndex)
    {
        for (int i = 0; i < matrix.GetLength(1); i++)
        {
            for (int j = 0; j < matrix.GetLength(1) - i - 1; j++)
            {
                if (matrix[rowIndex, j + 1] < matrix[rowIndex, j])
                {
                    int save = matrix[rowIndex, j + 1];
                    matrix[rowIndex, j + 1] = matrix[rowIndex, j];
                    matrix[rowIndex, j] = save;

                }
            }
        }
    }
    public void SortDescending(int[,] matrix, int rowIndex)
    {
        for (int i = 0; i < matrix.GetLength(1); i++)
        {
            for (int j = 0; j < matrix.GetLength(1) - i - 1; j++)
            {
                if (matrix[rowIndex, j + 1] > matrix[rowIndex, j])
                {
                    int save = matrix[rowIndex, j + 1];
                    matrix[rowIndex, j + 1] = matrix[rowIndex, j];
                    matrix[rowIndex, j] = save;

                }
            }
        }
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

    public int Task_3_4(int[,] matrix, bool isUpperTriangle)
    {
        int answer = 0;

        // code here

        // create and use public delegate GetTriangle(matrix);
        // create and use methods GetUpperTriange(array) and GetLowerTriange(array)
        // create and use GetSum(GetTriangle, matrix)


        int fl = 0;
        foreach (double i in matrix)
        {
            if (i != 0)
            {
                fl = 1;
            }
        }

        if (matrix == null || fl == 0 || matrix.GetLength(0) != matrix.GetLength(1) || (isUpperTriangle != true) && (isUpperTriangle != false)) return 0;

        GetTriangle GetTriangle = (isUpperTriangle == true) ? GetUpperTriange : GetLowerTriange;
        answer = GetSum(GetTriangle, matrix);
        // end

        return answer;
    }
    public delegate int[] GetTriangle(int[,] matrix);

    public int[] GetUpperTriange(int[,] array)
    {
        int[] answer = new int[Factorial(array.GetLength(0))];
        int count = 0;
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = i; j < array.GetLength(1); j++)
            {
                answer[count] = array[i, j];
                count++;
            }
        }
        return answer;
    }

    public int[] GetLowerTriange(int[,] array)
    {
        int[] answer = new int[Factorial(array.GetLength(0))];
        int count = 0;
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < i + 1; j++)
            {
                answer[count] = array[i, j];
                count++;
            }
        }
        return answer;
    }

    public int GetSum(GetTriangle GetTriangle, int[,] matrix)
    {
        int[] array = GetTriangle(matrix);
        int sum = 0;
        foreach (int i in array)
        {
            sum += i * i;
        }
        return sum;
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

    public void Task_3_6(int[,] matrix)
    {
        // code here

        // create and use public delegate FindElementDelegate(matrix);
        // use method FindDiagonalMaxIndex(matrix) like in Task_2_3;
        // create and use method FindFirstRowMaxIndex(matrix);
        // create and use method SwapColumns(matrix, FindDiagonalMaxIndex, FindFirstRowMaxIndex);
        int fl = 0;
        foreach (double i in matrix)
        {
            if (i != 0)
            {
                fl = 1;
            }
        }

        if (matrix == null || fl == 0 || matrix.GetLength(0) != matrix.GetLength(1)) return;

        FindElementDelegate findElementDelegate = FindDiagonalMaxIndex;
        int col1 = findElementDelegate(matrix);
        findElementDelegate = FindFirstRowMaxIndex;
        int col2 = findElementDelegate(matrix);

        SwapColumns(matrix, col1, col2);
        // end
    }
    public delegate int FindElementDelegate(int[,] matrix);

    public int FindDiagonalMaxIndex(int[,] matrix)
    {
        int mx = int.MinValue, index = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            if (matrix[i, i] > mx)
            {
                mx = matrix[i, i];
                index = i;
            }
        }
        return index;
    }
    public int FindFirstRowMaxIndex(int[,] matrix)
    {
        int mx = int.MinValue, index = 0;
        for (int i = 0; i < matrix.GetLength(1); i++)
        {
            if (matrix[0, i] > mx)
            {
                mx = matrix[0, i];
                index = i;
            }
        }
        return index;
    }
    public void SwapColumns(int[,] matrix, int col1, int col2)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            int save = matrix[i, col2];
            matrix[i, col2] = matrix[i, col1];
            matrix[i, col1] = save;
        }
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

    public void Task_3_10(ref int[,] matrix)
    {
        // FindIndex searchArea = default(FindIndex); - uncomment me

        // code here

        // create and use public delegate FindIndex(matrix);
        // create and use method FindMaxBelowDiagonalIndex(matrix);
        // create and use method FindMinAboveDiagonalIndex(matrix);
        // use RemoveColumn(matrix, columnIndex) from Task_2_10
        // create and use method RemoveColumns(matrix, findMaxBelowDiagonalIndex, findMinAboveDiagonalIndex)
        int fl = 0;
        foreach (double i in matrix)
        {
            if (i != 0)
            {
                fl = 1;
            }
        }

        if (matrix == null || fl == 0 || matrix.GetLength(0) != matrix.GetLength(1) || matrix.GetLength(1)<2) return ;
        
        FindIndex Delegate = FindMaxBelowDiagonalIndex;
        int findMaxBelowDiagonalIndex = Delegate(matrix);

        Delegate =  FindMinAboveDiagonalIndex;
        int findMinAboveDiagonalIndex=Delegate(matrix);

        RemoveColums(ref matrix, findMaxBelowDiagonalIndex, findMinAboveDiagonalIndex);

        // end
    }
    public delegate int FindIndex(int[,] matrix);

    public int FindMaxBelowDiagonalIndex(int[,] matrix)
    {
        int mx = int.MinValue;
        int indexCol = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < i + 1; j++)
            {
                if (matrix[i, j] > mx)
                {
                    mx = matrix[i, j];
                    indexCol = j;
                }
            }
        }
        return indexCol;
    }

    public int FindMinAboveDiagonalIndex(int[,] matrix)
    {
        int min = int.MaxValue;
        int indexCol = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = i + 1; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] < min)
                {
                    min = matrix[i, j];
                    indexCol = j;
                }
            }
        }
        return indexCol;
    }

    public void RemoveColums(ref int[,] matrix, int findMaxBelowDiagonalIndex, int findMinAboveDiagonalIndex)
    {
        if (findMaxBelowDiagonalIndex != findMinAboveDiagonalIndex)
        {
            RemoveColumn(ref matrix, findMaxBelowDiagonalIndex);
            RemoveColumn(ref matrix, findMinAboveDiagonalIndex - 1);
        }
        else 
            RemoveColumn(ref matrix, findMaxBelowDiagonalIndex);

    }


    public void Task_3_13(ref int[,] matrix)
    {
        // code here

        // use public delegate FindElementDelegate(matrix) from Task_3_6
        // create and use method RemoveRows(matrix, findMax, findMin)

        // end
    }

    public void Task_3_22(int[,] matrix, out int[] rows, out int[] cols)
    {

        rows = null;
        cols = null;

        // code here

        // create and use public delegate GetNegativeArray(matrix);
        // use GetNegativeCountPerRow(matrix) from Task_2_22
        // use GetMaxNegativePerColumn(matrix) from Task_2_22
        // create and use method FindNegatives(matrix, searcherRows, searcherCols, out rows, out cols);

        int fl = 0;
        foreach (double i in matrix)
        {
            if (i != 0)
            {
                fl = 1;
            }
        }

        if (matrix == null || fl == 0 ) return;

     
        GetNegativeArray searcherRows = GetNegativeCountPerRow;

        GetNegativeArray searcherCols = FindMaxNegativePerColumn;

        FindNegatives(matrix, searcherRows, searcherCols, out rows, out cols);


            // end
    }

    public delegate int[] GetNegativeArray(int[,] matrix);
    public int[] GetNegativeCountPerRow(int[,] matrix)
    {
        int[] answer = new int[matrix.GetLength(0)];
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            int count = 0;
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] < 0) count++;
            }
            answer[i] = count;
        }
        return answer;
    }

    public void FindNegatives(int[,] matrix, GetNegativeArray searcherRows, GetNegativeArray searcherCols, out int[] rows, out int[] cols)
    {
        rows = searcherRows(matrix);
        cols = searcherCols(matrix);


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

    public void Task_3_28a(int[] first, int[] second, ref int answerFirst, ref int answerSecond)
    {
        // code here

        // create public delegate IsSequence(array, left, right);
        // create and use method FindIncreasingSequence(array, A, B); similar to FindSequence(array, A, B) in Task_2_28a
        // create and use method FindDecreasingSequence(array, A, B); similar to FindSequence(array, A, B) in Task_2_28a
        // create and use method DefineSequence(array, findIncreasingSequence, findDecreasingSequence);
        int fl = 0;
        foreach (double i in first)
        {
            if (i != 0)
            {
                fl = 1;
            }
        }
        foreach (double i in second)
        {
            if (i != 0)
            {
                fl = 1;
            }
        }

        if (first == null || second == null || fl == 0) return;

        IsSequence findIncreasingSequence = FindIncreasingSequence;
        IsSequence findDecreasingSequence = FindDecreasingSequence;

        answerFirst = DefineSequence(first, findIncreasingSequence, findDecreasingSequence);
        answerSecond = DefineSequence(second, findIncreasingSequence, findDecreasingSequence);


        // end
    }
    public delegate int IsSequence(int[] array, int left, int right);

    public int FindIncreasingSequence(int[] array, int A, int B)
    {
        int fl1 = 0; //возрастающая
        for (int i = A; i < B; i++)
        {
            if (array[i] >= array[i + 1])
            {
                fl1 = 1;
                break;
            }

        }
      
        if (fl1 == 0) return 1;
        else return 0;
    }
    public int FindDecreasingSequence(int[] array, int A, int B)
    {
        int fl1 = 0; //
        for (int i = A; i < B; i++)
        {
            if (array[i] <= array[i + 1])
            {
                fl1 = 1;
                break;
            }

        }

        if (fl1 == 0) return 1;
        else return 0;
    }
    public int DefineSequence(int[] array, IsSequence findIncreasingSequence, IsSequence findDecreasingSequence)
    {
        if (findIncreasingSequence(array, 0, array.Length - 1) == 1) return 1;
        else
        {
            if (findDecreasingSequence(array, 0, array.Length - 1) == 1) return -1;
            else return 0;
        }

    }
    public void Task_3_28c(int[] first, int[] second, ref int[] answerFirstIncrease, ref int[] answerFirstDecrease, ref int[] answerSecondIncrease, ref int[] answerSecondDecrease)
    {
        // code here

        // create public delegate IsSequence(array, left, right);
        // use method FindIncreasingSequence(array, A, B); from Task_3_28a
        // use method FindDecreasingSequence(array, A, B); from Task_3_28a
        // create and use method FindLongestSequence(array, sequence);
        int fl = 0;
        foreach (double i in first)
        {
            if (i != 0)
            {
                fl = 1;
            }
        }
        foreach (double i in second)
        {
            if (i != 0)
            {
                fl = 1;
            }
        }

        if (first == null || second == null || fl == 0) return;

        IsSequence sequence = FindIncreasingSequence;
        answerFirstIncrease = FindLongestSequence(first, sequence);
        answerSecondIncrease= FindLongestSequence(second, sequence);

        sequence = FindDecreasingSequence;
        answerFirstDecrease = FindLongestSequence(first, sequence);
        answerSecondDecrease = FindLongestSequence(second, sequence);

        // end
    }

    public int[] FindLongestSequence(int[] array, IsSequence sequence)
    {
        int[] answer = new int[] { 0, 0 };
        for (int i = 0; i < array.Length - 1; i++)
        {
            for (int j = i + 1; j < array.Length; j++)
            {
                if (sequence(array, i, j) == 1 && (answer[1] - answer[0]) < (j - i))
                {
                    answer[1] = j;
                    answer[0] = i;
                }
            }
        }
        return answer;
    }

    #endregion
    #region bonus part
    public double[,] Task_4(double[,] matrix, int index)//  
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
