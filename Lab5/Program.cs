using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Numerics;
using System.Reflection;
using System.Reflection.Metadata;
using System.Runtime.InteropServices.Marshalling;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class Program
{
    public static void Main()
    {
        int[,] matrix5x5 = new int[,] {
            { 1, 2, 3, 4, 5 },
            { 6, 7, 8, 9, 10 },
            { 11, 12, 13, 14, 15 },
            { -1, -2, -3, -4, -5 },
            { 6, 7, 8, 9, 0 }};
        int[] arr9 = new int[] { 1, -12, -3, 4, -5, -6, 7, 0, 9 };
        Program program = new Program();
        //int [] sorte = program.SortNegative(arr9);
        //foreach(int x in sorte) Console.Write($"{x} ");
        program.SortDiagonal(matrix5x5);
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                Console.Write($"{matrix5x5[i, j]} ");
            }
            Console.WriteLine();
        }
        // Assert
        //  for (int i = 0; i < len * len * len; i++)
        //      Console.WriteLine($"{expected[i]}, {actual[i]}, {i}");
    }
    #region Level 1
    public int Factorial(int n)
    {
        int result = 1;
        for (int i = 1; i <= n; i++) result *= i;
        return result;
    }
    public int Combinations(int n, int k)
    {
        return Factorial(n) / Factorial(k) / Factorial(n - k);
    }

    public long Task_1_1(int n, int k)
    {
        long answer = 0;

        // code here

        // create and use Combinations(n, k);
        // create and use Factorial(n);

        // end

        return Combinations(n, k);
    }

    public double GeronArea(double a, double b, double c)
    {
        if (a >= (b + c) || b >= (a + c) || c >= (a + b)) return -1;
        double p = (a + b + c) / 2.0;
        return Math.Sqrt(p * (p - a) * (p - b) * (p - c));

    }
    public int Task_1_2(double[] first, double[] second)
    {
        // code here
        int answer;
        double firstArea = GeronArea(first[0], first[1], first[2]);
        double secondArea = GeronArea(second[0], second[1], second[2]);
        if ((firstArea == -1) || (secondArea < 0)) answer = -1;
        else if (firstArea > secondArea) answer = 1;
        else if (secondArea > firstArea) answer = 2;
        else answer = 0;

        // end
        return answer;
        // first = 1, second = 2, equal = 0, error = -1
    }
    public double GetDistance(double v, double a, double t)
    {
        return v * t + (a * t * t) / 2;
    }

    public int Task_1_3a(double v1, double a1, double v2, double a2, int time)
    {
        int answer = 0;

        // code here
        double S1 = GetDistance(v1, a1, time), S2 = GetDistance(v2, a2, time);

        // create and use GetDistance(v, a, t); t - hours
        if (GetDistance(v1, a1, time) < GetDistance(v2, a2, time)) answer = 2;
        else if (GetDistance(v1, a1, time) == GetDistance(v2, a2, time)) answer = 0;
        else answer = 1;
        // end

        // first = 1, second = 2, equal = 0
        return answer;
    }

    public int Task_1_3b(double v1, double a1, double v2, double a2)
    {
        int answer = 0;
        int t = 1;
        // code here
        while (answer == 0)
        {
            if (GetDistance(v1, a1, t) <= GetDistance(v2, a2, t)) answer = t;
            t++;
        }
        // use GetDistance(v, a, t); t - hours

        // end

        return answer;
    }
    #endregion
    // public void FindMaxIndex(int[,] matrix, out int row, out int column)
    // {
    //     row = 0; column = 0;
    //     for (int i = 0; i < matrix.GetLength(0); i++) 
    //     {
    //         for (int j = 0; j  < matrix.GetLength(1); j++)
    //         {
    //             if (matrix[i, j]> matrix[row, column])
    //             {
    //                 row = i;
    //                 column = j;
    //             }
    //         }
    //     }
    //     return;

    // }
    #region Level 2
    public void Task_2_1(int[,] A, int[,] B)
    {
        // // code here
        // int rowA, rowB, columnA, columnB;
        // FindMaxIndex(A, out rowA, out columnA);
        // FindMaxIndex(B, out rowB, out columnB);
        // // create and use FindMaxIndex(matrix, out row, out column);
        // int temp = A[rowA, columnA];
        // A[rowA, columnA] = B[rowB, columnB];
        // B[rowB, columnB] = temp;
        // // end
    }

    public int FindMaxIndex(double[] array)
    {
        int index = 0;
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] > array[index]) index = i;
        }
        return index;
    }
    public void Task_2_2(double[] A, double[] B)
    {
        // code here
        int AMaxIndex = FindMaxIndex(A), BMaxIndex = FindMaxIndex(B);
        double s = 0, cnt = 0;
        // create and use FindMaxIndex(array);
        // only 1 array has to be changed!
        if (A.Length - AMaxIndex < B.Length - BMaxIndex)
        {

            for (int i = BMaxIndex + 1; i < B.Length; i++)
            {
                s += B[i]; cnt++;
            }
            double sr = s / cnt;
            B[BMaxIndex] = sr;
        }
        else
        {

            for (int i = AMaxIndex + 1; i < A.Length; i++)
            {
                s += A[i]; cnt++;
            }
            double sr = s / cnt;
            A[AMaxIndex] = sr;
        }
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
        int maxi = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            if (matrix[i, i] > matrix[maxi, maxi])
            {
                maxi = i;
            }
        }
        return maxi;
    }
    public void Task_2_4(int[,] A, int[,] B)
    {
        // code here
        int indexA = FindDiagonalMaxIndex(A), indexB = FindDiagonalMaxIndex(B);
        for (int i = 0; i < A.GetLength(0); i++)
        {
            int temp = A[indexA, i];
            A[indexA, i] = B[i, indexB];
            B[i, indexB] = temp;
        }
        // end
    }

    public void Task_2_5(int[,] A, int[,] B)
    {
        // code here

        // create and use FindMaxInColumn(matrix, columnIndex, out rowIndex);

        // end
    }
    public void FindMax(int[] array, out int index)
    {
        index = 0;
        for (int i = 0; i < array.Length; i++)
        {
            if (array[index] < array[i]) index = i;
        }
    }
    public int[] DeleteElement(int[] array, int index)
    {
        int[] A = new int[array.Length - 1];
        for (int i = 0; i < index; i++)
        {
            A[i] = array[i];
        }
        for (int i = index; i < A.Length; i++)
        {
            A[i] = array[i + 1];
        }
        return A;
    }
    public void Task_2_6(ref int[] A, int[] B)
    {
        // code here
        int index;
        int MaxIndexA, MaxIndexB;
        FindMax(A, out MaxIndexA); FindMax(B, out MaxIndexB);
        A = DeleteElement(A, MaxIndexA); B = DeleteElement(B, MaxIndexB);
        int[] Aa = new int[A.Length];
        for (int i = 0; i < A.Length; i++) Aa[i] = A[i];
        A = new int[A.Length + B.Length];
        for (int i = 0; i < A.Length; i++)
        {
            if (i < Aa.Length) A[i] = Aa[i];
            else A[i] = B[i - Aa.Length];
        }
        // create and use FindMax(matrix, out row, out column); like in Task_2_1
        // create and use DeleteElement(array, index);

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
        for (int i = 0; i < array.Length - 1; i++)
        {
            for (int j = startIndex; j < array.Length - i - 1; j++)
            {
                if (array[j + 1] < array[j])
                {
                    int temp = array[j + 1];
                    array[j + 1] = array[j];
                    array[j] = temp;
                }
            }
        }
        return array;
    }
    public void Task_2_8(int[] A, int[] B)
    {
        // code here
        int maxIndexA, maxIndexB;
        FindMax(A, out maxIndexA); FindMax(B, out maxIndexB);
        // create and use SortArrayPart(array, startIndex);
        SortArrayPart(A, maxIndexA + 1); SortArrayPart(B, maxIndexB + 1);

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
    public int[,] RemoveColumn(int[,] matrix, int columnIndex)
    {
        int[,] A = new int[matrix.GetLength(0), matrix.GetLength(1) - 1];
        for (int i = 0; i < A.GetLength(0); i++)
        {
            for (int j = 0; j < A.GetLength(1); j++)
            {
                if (j >= columnIndex)
                {
                    A[i, j] = matrix[i, j + 1];
                }
                else A[i, j] = matrix[i, j];
            }
        }
        matrix = A;
        return A;
    }
    public void Task_2_10(ref int[,] matrix)
    {
        // code here
        int maxUpperColumn = 0, maxUpperRow = 0, maxLowerColumn = 0, maxLowerRow = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (i >= j)
                {
                    if (matrix[i, j] > matrix[maxLowerRow, maxLowerColumn])
                    {
                        maxLowerColumn = j; maxLowerRow = i;
                    }
                }
                else
                {
                    if (matrix[i, j] > matrix[maxUpperRow, maxUpperColumn])
                    {
                        maxUpperColumn = j; maxUpperRow = i;
                    }
                }
            }
        }
        if (maxUpperColumn == maxLowerColumn)
        {
            matrix = RemoveColumn(matrix, maxUpperColumn);
        }
        else
        {
            matrix = RemoveColumn(matrix, maxUpperColumn);
            matrix = RemoveColumn(matrix, maxLowerColumn);
        }
        // end
    }

    public void Task_2_11(int[,] A, int[,] B)
    {
        // code here

        // use FindMaxIndex(matrix, out row, out column); from Task_2_1

        // end
    }

    public int FindMaxColumnIndex(int[,] matrix)
    {
        int c = 0, r = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[r, c] < matrix[i, j]) { c = j; r = i; }
            }
        }
        return c;
    }
    public void Task_2_12(int[,] A, int[,] B)
    {
        // code here
        int ColumnA = FindMaxColumnIndex(A), columnB = FindMaxColumnIndex(B);
        for (int i = 0; i < A.GetLength(0); i++)
        {
            int temp = A[i, ColumnA];
            A[i, ColumnA] = B[i, columnB];
            B[i, columnB] = temp;
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
    public int[,] SortRow(int[,] matrix, int rowIndex)
    {
        for (int i = 0; i < matrix.GetLength(1) - 1; i++)
        {
            for (int j = 0; j < matrix.GetLength(1) - i - 1; j++)
            {
                if (matrix[rowIndex, j + 1] < matrix[rowIndex, j])
                {
                    var temp = matrix[rowIndex, j + 1];
                    matrix[rowIndex, j + 1] = matrix[rowIndex, j];
                    matrix[rowIndex, j] = temp;
                }
            }
        }
        return matrix;
    }
    public void Task_2_14(int[,] matrix)
    {
        // code here

        for (int i = 0; i < matrix.GetLength(0); i++) SortRow(matrix, i);

        // end
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
    public int[] SortNegative(int[] array)
    {
        int n = 0;
        foreach (int x in array) if (x < 0) n++;
        int[] Negatives = new int[n];
        int j = 0;
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] < 0)
            {
                Negatives[j++] = array[i];
            }
        }
        for (int i = 0; i < Negatives.Length - 1; i++)
        {
            for (int x = 0; x < Negatives.Length - i - 1; x++)
            {
                if (Negatives[x] < Negatives[x + 1])
                {
                    var temp = Negatives[x];
                    Negatives[x] = Negatives[x + 1];
                    Negatives[x + 1] = temp;
                }
            }
        }
        j = 0;
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] < 0) array[i] = Negatives[j++];
        }
        return array;
    }
    public void Task_2_16(int[] A, int[] B)
    {
        // code here

        SortNegative(A); SortNegative(B);

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
        var n = matrix.GetLength(0);
        int[] Diagonal = new int[n];
        for (int i = 0; i < n; i++)
        {
            Diagonal[i] = matrix[i, i];
        }
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - 1; j++)
            {
                if (Diagonal[j] > Diagonal[j + 1])
                {
                    var temp = Diagonal[j];
                    Diagonal[j] = Diagonal[j + 1];
                    Diagonal[j + 1] = temp;
                }
            }
        }
        for (int i = 0; i < n; i++)
        {
            matrix[i, i] = Diagonal[i];
        }
    }
    public void Task_2_18(int[,] A, int[,] B)
    {
        // code here
        SortDiagonal(A); SortDiagonal(B);
        // create and use SortDiagonal(matrix);

        // end
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
        for (int j = 0; j < A.GetLength(1); j++)
        {
            bool has0 = false;
            for (int i = 0; i < A.GetLength(0); i++)
            {
                if (A[i, j] == 0) has0 = true;
            }
            if (!has0) { A = RemoveColumn(A, j); j--; }
        }
        for (int j = 0; j < B.GetLength(1); j++)
        {
            bool has0 = false;
            for (int i = 0; i < B.GetLength(0); i++)
            {
                if (B[i, j] == 0) has0 = true;
            }
            if (!has0) { B = RemoveColumn(B, j); j--; }
        }
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
    public int CountNegativeInRow(int[,] matrix, int rowIndex)
    {
        int count = 0;
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (matrix[rowIndex, j] < 0) count++;
        }
        return count;
    }
    public int[] FindMaxNegativePerColumn(int[,] matrix)
    {
        int[] A = new int[matrix.GetLength(1)];
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            int max = int.MinValue;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, j] < 0 && matrix[i, j] > max)
                {
                    max = matrix[i, j];
                }
            }
            A[j] = max;
        }
        return A;
    }
    public void Task_2_22(int[,] matrix, out int[] rows, out int[] cols)
    {
        rows = new int[matrix.GetLength(0)];

        // code here
        for (int i = 0; i < matrix.GetLength(0); i++) rows[i] = CountNegativeInRow(matrix, i);
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
        row = 0; column = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] > matrix[row, column])
                {
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
        var temp = matrix[i, columnIndex];
        matrix[i, columnIndex] = matrix[i,i];
        matrix[i, i] = temp;
        }
    }

    public void Task_2_24(int[,] A, int[,] B)
    {
        // code here
        int rowA, columnA, rowB, columnB;
        FindMaxIndex(A, out rowA, out columnA);
        FindMaxIndex(B, out rowB, out columnB);
        SwapColumnDiagonal(A, columnA);
        SwapColumnDiagonal(B, columnB);
        // use FindMaxIndex(matrix, out row, out column); like in 2_1
        // create and use SwapColumnDiagonal(matrix, columnIndex);

        // end
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
    public int FindRowWithMaxNegativeCount(int [,] matrix)
    {
        int iMax = -1, maxNegativeCount = int.MinValue;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            int count = CountNegativeInRow(matrix, i);
            if (count > maxNegativeCount)
            {
                maxNegativeCount = count;
                iMax = i;
            }
        }
        return iMax;
    }
    public void Task_2_26(int[,] A, int[,] B)
    {
        // code here
        int Arow = FindRowWithMaxNegativeCount(A), Brow = FindRowWithMaxNegativeCount(B);
        for(int i = 0; i < A.GetLength(1); i++)
        {
            var temp = A[Arow, i];
            A[Arow, i] = B[Brow, i];
            B[Brow, i] = temp;
        }

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
        bool flag = array[A] < array[A + 1];
        for (int i = A; i < B; i++)
        {
            if (flag && array[i] > array[i + 1]) return 0;
            if (!flag && array[i] < array[i + 1]) return 0;
        }
        if (flag) return 1; else return -1;
    }
    public void Task_2_28a(int[] first, int[] second, ref int answerFirst, ref int answerSecond)
    {
        // code here
        answerFirst = FindSequence(first, 0, first.Length - 1);
        answerSecond = FindSequence(second, 0,second.Length - 1);
        // create and use FindSequence(array, A, B); // 1 - increasing, 0 - no sequence,  -1 - decreasing
        // A and B - start and end indexes of elements from array for search

        // end
    }
    public void Intervals(ref int[,] answer, int[] function)
    {
        int n = 0;
        for (int A = 0; A < function.Length; A++)
        {
            for (int B = A + 1; B < function.Length; B++)
            {
                if (FindSequence(function, A, B) != 0) n++;
            }
        }
        answer = new int[n, 2];
        n = 0;
        for (int A = 0; A < function.Length; A++)
        {
            for (int B = A + 1; B < function.Length; B++)
            {
                if (FindSequence(function, A, B) != 0)
                {
                    answer[n, 0] = A;
                    answer[n, 1] = B;
                    n++;
                }
            }
        }
    }
    public void Task_2_28b(int[] first, int[] second, ref int[,] answerFirst, ref int[,] answerSecond)
    {
        // code here
        Intervals(ref answerFirst, first);
        Intervals(ref answerSecond, second);
        // use FindSequence(array, A, B); from Task_2_28a or entirely Task_2_28a
        // A and B - start and end indexes of elements from array for search

        // end
    }
    public int[] FindLengthOfSequence(int[] function)
    {
        int[] answer;
        int A = 0, B = 0;
        for (int i = 0; i < function.Length; i++)
        {
            for (int j = i + 1; j < function.Length; j++)
            {
                if (FindSequence(function, i, j) != 0 && B - A < j - i)
                {
                    A = i;
                    B = j;
                }
            }
        }
        answer = new int[] { A, B };
        return answer;
    }
    public void Task_2_28c(int[] first, int[] second, ref int[] answerFirst, ref int[] answerSecond)
    {
        // code here
        answerFirst = FindLengthOfSequence(first);     
        answerSecond = FindLengthOfSequence(second);
        // end
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
    public delegate void SortRowStyle(int[,] matrix, int rowIndex);
    void SortAscending(int[,] matrix, int rowIndex)
    {
        int n = matrix.GetLength(1);
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n - 1 - i; j++)
            {
                if (matrix[rowIndex, j] > matrix[rowIndex, j + 1])
                {
                    var temp = matrix[rowIndex, j];
                    matrix[rowIndex, j] = matrix[rowIndex, j + 1];
                    matrix[rowIndex, j + 1] = temp;
                }
            }
        }
    }
    void SortDescending(int[,] matrix, int rowIndex)
    {
        int n = matrix.GetLength(1);
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n - 1 - i; j++)
            {
                if (matrix[rowIndex, j] < matrix[rowIndex, j + 1])
                {
                    var temp = matrix[rowIndex, j];
                    matrix[rowIndex, j] = matrix[rowIndex, j + 1];
                    matrix[rowIndex, j + 1] = temp;
                }
            }
        }
    }
    public void Task_3_2(int[,] matrix)
    {
        SortRowStyle sortStyle; 

        // code here
        for (int i = 0; i < matrix.GetLength(0);i++)
        {
            if (i % 2 == 0) sortStyle = SortAscending;
            else sortStyle = SortDescending;
            sortStyle(matrix, i);
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
    public int[] GetUpperTriangle(int[,] matrix)
    {
        int n = matrix.GetLength(0);
        int[] triangle = new int[n * (n + 1) / 2];
        int k = 0;
        for (int i =0; i < n; i++)
        {
            for(int j = i; j<n; j++ )
            {
                triangle[k++] = matrix[i, j];
            }
        }
        return triangle;
    }
    public int[] GetLowerTriangle(int[,] matrix)
    {
        int n = matrix.GetLength(0);
        int[] triangle = new int[n * (n + 1) / 2];
        int k = 0;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j <= i; j++)
            {
                triangle[k++] = matrix[i, j];
            }
        }
        return triangle;
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
        GetTriangle Get;
        if (isUpperTriangle) Get = GetUpperTriangle;
        else Get = GetLowerTriangle;
        answer = GetSum(Get, matrix);
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
        int  c = 0;
        for (int i = 0; i < matrix.GetLength(1); i++)
        {
            if (matrix[0, i] > matrix[0, c])c = i;
            
        }
        return c;
    }
    public void SwapColumns(int[,] matrix, FindElementDelegate Diagonal, FindElementDelegate Row)
    {
        int a = Diagonal (matrix);
        int b = Row (matrix);
        for(int i = 0; i < matrix.GetLength(0);i++)
        {
            (matrix[i, a], matrix[i, b]) = (matrix[i, b], matrix[i, a]);
        }
    }
    public void Task_3_6(int[,] matrix)
    {
        // code here
        SwapColumns(matrix, FindDiagonalMaxIndex, FindFirstRowMaxIndex);
        // create and use public delegate FindElementDelegate(matrix);
        // use method FindDiagonalMaxIndex(matrix) like in Task_2_3;
        // create and use method FindFirstRowMaxIndex(matrix);
        // create and use method SwapColumns(matrix, FindDiagonalMaxIndex, FindFirstRowMaxIndex);

        // end
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
    public int FindMaxBelowDiagonalIndex(int[,] matrix)
    {
        int r = 0, c = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for ( int j = 0; j <= i; j++)
            {
                if (matrix[i, j] > matrix[r, c])
                {
                    r = i;
                    c = j;
                } 
            }
        }
        return c;
    }
    public int FindMinAboveDiagonalIndex(int[,] matrix)
    {
        int r = 0, c = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = i + 1; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] < matrix[r, c])
                {
                    r = i;
                    c = j;
                }
            }
        }
        return c;
    }
    public int[,] RemoveColumns(int[,] matrix, FindIndex findMaxBelowDiagonalIndex, FindIndex findMinAboveDiagonalIndex)
    {
        int a = findMaxBelowDiagonalIndex(matrix);
        int b = findMinAboveDiagonalIndex(matrix);
        if (a != b) matrix = RemoveColumn(matrix, a);
        matrix = RemoveColumn(matrix, b);
        return matrix;
    }
    public void Task_3_10(ref int[,] matrix)
    {
        FindIndex searchArea = default(FindIndex);

        // code here
        matrix = RemoveColumns(matrix, FindMaxBelowDiagonalIndex, FindMinAboveDiagonalIndex);
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
    public void FindNegatives(int[,] matrix, GetNegativeArray searcherRows, GetNegativeArray SearcherCols, out int[] rows, out int[] cols)
    {
        rows = searcherRows(matrix);
        cols = SearcherCols(matrix);
    }
    public int[] GetNegativeCountPerRow(int[,] matrix)
    {
        int[] A = new int[matrix.GetLength(0)];
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            A[i] = CountNegativeInRow(matrix, i);
        }
        return A;
    }

    public void Task_3_22(int[,] matrix, out int[] rows, out int[] cols)
    {

        rows = null;
        cols = null;

        // code here

        FindNegatives(matrix, GetNegativeCountPerRow, FindMaxNegativePerColumn, out rows, out cols);
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
        return (FindSequence(array, A, B) == 1);
    }
    public bool FindDecreasingSequence(int[] array, int A, int B)
    {
        return (FindSequence(array, A, B) == -1);
    }
    public int DefineSequence(int[] array, IsSequence Increase, IsSequence Decrease)
    {
        bool increasing = Increase(array, 0, array.Length - 1);
        bool decreasing = Decrease(array, 0, array.Length - 1);
        if (increasing) return 1;
        if (decreasing) return -1;
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
                    start = i; end = j;
                }
            }
        }
        return new int[] { start, end };
    }
    public void Task_3_28c(int[] first, int[] second, ref int[] answerFirstIncrease, ref int[] answerFirstDecrease, ref int[] answerSecondIncrease, ref int[] answerSecondDecrease)
    {
        // code here
        answerFirstIncrease = FindLongestSequence(first, FindIncreasingSequence);
        answerFirstDecrease = FindLongestSequence(first, FindDecreasingSequence);
        answerSecondDecrease = FindLongestSequence(second, FindDecreasingSequence);
        answerSecondIncrease = FindLongestSequence(second, FindIncreasingSequence);
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
