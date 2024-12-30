using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Numerics;
using System.Reflection;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class Program
{
    public static void Main()
    {
        Program program = new Program();
        program.Task_2_16(new int[] { -100, 8, -3, 5, -1, 1, 0, -324, -2 }, new int[] { 1, -1, -3, 5, -4, 1, 0, -5, -8, 2 });
    }
    #region Level 1
    public long Task_1_1(int n, int k)
    {
        long answer = 0;

        // code here
        static void Combinations(int n, int k, out long answer)
        {
            answer = (Factorial(n)) / (Factorial(k) * Factorial(n - k));
        }
        static int Factorial(int n)
        {
            int s = 1;
            for (int i = 1; i < n + 1; i++) s *= i;
            return s;
        }
        if (n >= 0 && k >= 0 && n >= k)
        {
            Combinations(n, k, out answer);
        }

        // create and use Combinations(n, k);
        // create and use Factorial(n);

        // end

        return answer;
    }

    public int Task_1_2(double[] first, double[] second)
    {
        int answer = 0;
        if (first.Length != 3 || second.Length != 3) return -1;
        if (first[0] <= 0 || first[1] <= 0 || first[2] <= 0 || second[0] <= 0 || second[1] <= 0 || second[2] <= 0 || first[0] + first[1] <= first[2] || first[2] + first[1] <= first[0] || first[0] + first[2] <= first[1] || second[0] + second[1] <= second[2] || second[0] + second[2] <= second[1] || second[2] + second[1] <= second[0]) return -1;
        // code here

        // create and use GeronArea(a, b, c);

        // end
        double a_1 = GeronArea(first[0], first[1], first[2]);
        double a_2 = GeronArea(second[0], second[1], second[2]);
        static double GeronArea(double a, double b, double c)
        {
            double p = (a + b + c) / 2;
            return ((Math.Sqrt(p * (p - a) * (p - b) * (p - c))));
        }
        //Console.WriteLine($"{a_1} +{a_2}");
        if (a_1 > a_2) answer = 1;
        if (a_2 > a_1) answer = 2;
        if (a_1 == a_2) answer = 0;

        // first = 1, second = 2, equal = 0, error = -1
        return answer;
    }

    public int Task_1_3a(double v1, double a1, double v2, double a2, int time)
    {
        int answer = 0;

        // code here

        // create and use GetDistance(v, a, t); t - hours
        static double GetDictance(double v, double a, double t)
        {
            return (v * t + a * t * t / 2);
        }
        double s_1 = GetDictance(v1, a1, time);
        double s_2 = GetDictance(v2, a2, time);
        if (s_1 > s_2) answer = 1;
        if (s_2 > s_1) answer = 2;
        // end

        // first = 1, second = 2, equal = 0
        return answer;
    }

    public int Task_1_3b(double v1, double a1, double v2, double a2)
    {
        int answer = 0;
        int t = 1;
        // code here

        while (GetDictance(v1, a1, t) > (GetDictance(v2, a2, t)))
        {
            t += 1;
        }
        answer = t;
        // use GetDistance(v, a, t); t - hours
        static double GetDictance(double v, double a, double t)
        {
            return (v * t + a * t * t / 2);
        }

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
        if (A.Length - FindMaxIndex(A) > B.Length - FindMaxIndex(B))
        {
            double sum = 0;
            int lok = 0;
            for (int i = FindMaxIndex(A) + 1; i < A.Length; i++)
            {
                sum += A[i];
                lok += 1;
            }
            A[FindMaxIndex(A)] = sum / lok;
        }
        else
        {
            double sum = 0;
            int lok = 0;
            for (int i = FindMaxIndex(B) + 1; i < B.Length; i++)
            {
                sum += B[i];
                lok += 1;
            }
            B[FindMaxIndex(B)] = sum / lok;
        }
        // create and use FindMaxIndex(array);
        // only 1 array has to be changed!
        static int FindMaxIndex(double[] array)
        {
            int ind = 0;
            for (int i = 1; i < array.Length; i++) if (array[i] > array[ind]) ind = i;
            return ind;
        }
        // end
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
        if (A.GetLength(0) == A.GetLength(1) && A.GetLength(0) == 5 && B.GetLength(0) == B.GetLength(1) && B.GetLength(0) == 5)
        {
            for (int i = 0; i < A.GetLength(0); i++)
            {
                int temp = A[FindDiagonalMaxIndex(A), i];
                A[FindDiagonalMaxIndex(A), i] = B[i, FindDiagonalMaxIndex(B)];
                B[i, FindDiagonalMaxIndex(B)] = temp;
            }
        }

        //  create and use method FindDiagonalMaxIndex(matrix); like in Task_2_3
        static int FindDiagonalMaxIndex(int[,] matrix)
        {
            int ind = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {

                if (matrix[i, i] > matrix[ind, ind])
                {
                    ind = i;
                }

            }
            return (ind);
        }
        // end
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
        A = DeleteElement(A, FindMax(A));
        B = DeleteElement(B, FindMax(B));
        int[] muy = new int[A.Length + B.Length];
        for (int i = 0; i < A.Length; i++)
        {
            muy[i] = A[i];
        }
        for (int i = 0; i < B.Length; i++)
        {
            muy[i + A.Length] = B[i];
        }
        A = muy;

        static int[] DeleteElement(int[] array, int index)
        {
            int[] trn = new int[array.Length - 1];
            int k = 0;
            for (int i = 0; i < array.Length; i++) if (i != index)
                {
                    trn[k] = array[i];
                    k++;
                }
            return trn;
        }

        static int FindMax(int[] array)
        {
            int ind = 0;
            for (int i = 1; i < array.Length; i++) if (array[i] > array[ind]) ind = i;
            return ind;
        }
        // end
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
        int max1 = 0;
        int max2 = 0;
        for (int i = 1; i < A.Length; i++) if (A[i] > A[max1]) max1 = i;
        for (int i = 1; i < B.Length; i++) if (B[i] > B[max2]) max2 = i;
        A = SortArrayPart(A, max1);
        B = SortArrayPart(B, max2);
        // create and use SortArrayPart(array, startIndex);
        static int[] SortArrayPart(int[] array, int startIndex)
        {
            for (int i = startIndex + 2, j = startIndex + 3; i < array.Length;)
            {
                if (i == startIndex + 1 || array[i] >= array[i - 1])
                {
                    i = j;
                    j++;
                }
                else
                {
                    int temp = array[i];
                    array[i] = array[i - 1];
                    array[i - 1] = temp;
                    i--;
                }
            }
            return array;
        }
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

    public void Task_2_10(ref int[,] matrix)
    {
        // code here
        if (matrix.GetLength(0) == matrix.GetLength(1))
        {
            int max1 = 0;
            int max2 = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (i >= j && matrix[i, j] > matrix[max1, max2])
                    {
                        max1 = i;
                        max2 = j;
                    }

                }
            }
            int min1 = 0;
            int min2 = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 1; j < matrix.GetLength(1); j++)
                {
                    if (i <= j && matrix[i, j] < matrix[min1, min2])
                    {
                        min1 = i;
                        min2 = j;
                    }

                }
            }
            matrix = RemoveColumn(matrix, max2);

            int min1_ = 0;
            int min2_ = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 1; j < matrix.GetLength(1); j++)
                {
                    if (i <= j && matrix[i, j] < matrix[min1_, min2_])
                    {
                        min1_ = i;
                        min2_ = j;
                    }

                }
            }
            if (max2 != min2)
            {
                matrix = RemoveColumn(matrix, min2_);
            }
        }


        // create and use RemoveColumn(matrix, columnIndex);
        static int[,] RemoveColumn(int[,] matrix, int columnIndex)
        {
            int[,] matrix2 = new int[matrix.GetLength(0), matrix.GetLength(1) - 1];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int k = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (j != columnIndex)
                    {
                        matrix2[i, k] = matrix[i, j];
                        k++;
                    }
                }
            }
            return matrix2;
        }
        // end
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
        int max1 = FindMaxColumnIndex(A);
        int max2 = FindMaxColumnIndex(B);
        for (int i = 0; i < A.GetLength(0); i++)
        {
            int temp = B[i, max2];
            B[i, max2] = A[i, max1];
            A[i, max1] = temp;
        }
        // create and use FindMaxColumnIndex(matrix);
        static int FindMaxColumnIndex(int[,] matrix)
        {
            int max1 = 0;
            int max2 = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > matrix[max1, max2])
                    {
                        max1 = i;
                        max2 = j;
                    }

                }
            }
            return max2;
        }

        // end
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
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            matrix = SortRow(matrix, i);
        }
        // create and use SortRow(matrix, rowIndex);
        static int[,] SortRow(int[,] matrix, int rowIndex)
        {
            for (int i = 1, j = 2; i < matrix.GetLength(1);)
            {
                if (i == 0 || matrix[rowIndex, i] >= matrix[rowIndex, i - 1])
                {
                    i = j;
                    j++;
                }
                else
                {
                    int temp = matrix[rowIndex, i];
                    matrix[rowIndex, i] = matrix[rowIndex, i - 1];
                    matrix[rowIndex, i - 1] = temp;
                    i--;
                }
            }
            return matrix;
        }
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write(matrix[i, j]);
            }
            Console.WriteLine();
        }
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

    public void Task_2_16(int[] A, int[] B)
    {
        // code here
        A = SortNegative(A);
        B = SortNegative(B);
        // create and use SortNegative(array);
        static int[] SortNegative(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < 0)
                {
                    int j = i, k = i - 1;
                    while (k >= 0)
                    {
                        if (array[k] < 0 && array[k] < array[j])
                        {
                            int temp = array[k];
                            array[k] = array[j];
                            array[j] = temp;
                            j = k;
                        }
                        k--;
                    }
                }
            }

            return array;
        }
        foreach (int i in A) Console.WriteLine(i);
        // end
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
        if (A.GetLength(0) == A.GetLength(1) && B.GetLength(0) == B.GetLength(1) && A.GetLength(0) != 0 && B.GetLength(0) != 0)
        {
            A = SortDiagonal(A);
            B = SortDiagonal(B);
        }

        // create and use SortDiagonal(matrix);
        static int[,] SortDiagonal(int[,] matrix)
        {
            for (int i = 1, j = 2; i < matrix.GetLength(0);)
            {
                if (i == 0 || matrix[i, i] >= matrix[i - 1, i - 1])
                {
                    i = j;
                    j++;
                }
                else
                {
                    int temp = matrix[i, i];
                    matrix[i, i] = matrix[i - 1, i - 1];
                    matrix[i - 1, i - 1] = temp;
                    i--;
                }
            }
            return matrix;
        }
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
        for (int i = A.GetLength(1) - 1; i >= 0; i--)
        {
            int sum = 0;
            for (int j = 0; j < A.GetLength(0); j++)
            {
                if (A[j, i] == 0)
                {
                    sum = 1;
                    break;
                }
            }
            if (sum == 0)
            {
                A = RemoveColumn(A, i);
            }
        }
        for (int i = B.GetLength(1) - 1; i >= 0; i--)
        {
            int sum = 0;
            for (int j = 0; j < B.GetLength(0); j++)
            {
                if (B[j, i] == 0)
                {
                    sum = 1;
                    break;
                }
            }
            if (sum == 0)
            {
                B = RemoveColumn(B, i);
            }
        }
        // use RemoveColumn(matrix, columnIndex); from 2_10
        static int[,] RemoveColumn(int[,] matrix, int columnIndex)
        {
            int[,] matrix2 = new int[matrix.GetLength(0), matrix.GetLength(1) - 1];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int k = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (j != columnIndex)
                    {
                        matrix2[i, k] = matrix[i, j];
                        k++;
                    }
                }
            }
            return matrix2;
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

    public void Task_2_22(int[,] matrix, out int[] rows, out int[] cols)
    {
        rows = new int[matrix.GetLength(0)];
        cols = new int[matrix.GetLength(1)];
        cols = FindMaxNegativePerColumn(matrix);
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            rows[i] = CountNegativeInRow(matrix, i);
        }
        // code here

        // create and use CountNegativeInRow(matrix, rowIndex);
        static int CountNegativeInRow(int[,] matrix, int rowIndex)
        {
            int count = 0;
            for (int i = 0; i < matrix.GetLength(1); i++) if (matrix[rowIndex, i] < 0) count++;
            return count;
        }
        // create and use FindMaxNegativePerColumn(matrix);
        static int[] FindMaxNegativePerColumn(int[,] matrix)
        {
            int[] mass = new int[matrix.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                int sum = 0;
                int count = int.MinValue;
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    if (matrix[j, i] < 0 && matrix[j, i] > count)
                    {
                        count = matrix[j, i];
                        sum++;
                    }
                }
                if (sum == int.MinValue)
                {
                    mass[i] = 0;
                }
                else mass[i] = count;

            }
            return mass;
        }

        // end
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
        int row = 0;
        int column = 0;
        FindMaxIndex(A, out row, out column);
        A = SwapColumnDiagonal(A, column);
        FindMaxIndex(B, out row, out column);
        B = SwapColumnDiagonal(B, column);
        // use FindMaxIndex(matrix, out row, out column); like in 2_1
        static void FindMaxIndex(int[,] matrix, out int row, out int column)
        {
            int i1 = 0; int j1 = 0;
            int max = matrix[0, 0];
            for (int i = 1; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > max)
                    {
                        i1 = i;
                        j1 = j;
                        max = matrix[i, j];
                    }
                }
            }
            row = i1;
            column = j1;
        }
        // create and use SwapColumnDiagonal(matrix, columnIndex);
        static int[,] SwapColumnDiagonal(int[,] matrix, int columnIndex)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int temp = matrix[i, columnIndex];
                matrix[i, columnIndex] = matrix[i, i];
                matrix[i, i] = temp;
            }
            return matrix;
        }
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

    public void Task_2_26(int[,] A, int[,] B)
    {
        // code here
        for (int i = 0; i < A.GetLength(0); i++)
        {
            int temp = A[FindRowWithMaxNegativeCount(A), i];
            A[FindRowWithMaxNegativeCount(A), i] = B[FindRowWithMaxNegativeCount(B), i];
            B[FindRowWithMaxNegativeCount(B), i] = temp;
        }
        // create and use FindRowWithMaxNegativeCount(matrix); like in 2_25
        static int FindRowWithMaxNegativeCount(int[,] matrix)
        {
            int sum = 0;
            int max = 0;
            int ind = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                sum = CountNegativeInRow(matrix, i);
                if (sum > max)
                {
                    max = sum;
                    ind = i;
                }
            }
            return ind;
        }
        // in FindRowWithMaxNegativeCount use CountNegativeInRow(matrix, rowIndex); from 2_22
        static int CountNegativeInRow(int[,] matrix, int rowIndex)
        {
            int count = 0;
            for (int i = 0; i < matrix.GetLength(1); i++) if (matrix[rowIndex, i] < 0) count++;
            return count;
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

    public void Task_2_28a(int[] first, int[] second, ref int answerFirst, ref int answerSecond)
    {
        // code here
        answerFirst = FindSequence(first, 0, first.Length - 1);
        answerSecond = FindSequence(second, 0, second.Length - 1);
        static int FindSequence(int[] array, int A, int B)
        {
            int max = 1;
            int min = -1;
            for (int i = A + 1; i < B + 1; i++)
            {
                if (array[i] > array[i - 1]) min = 0;
                if (array[i] < array[i - 1]) max = 0;
            }
            if (max == 1) return 1;
            if (min == -1) return -1;
            return 0;
        }
        // create and use FindSequence(array, A, B); // 1 - increasing, 0 - no sequence,  -1 - decreasing
        // A and B - start and end indexes of elements from array for search

        // end
    }

    public void Task_2_28b(int[] first, int[] second, ref int[,] answerFirst, ref int[,] answerSecond)
    {
        // code here
        int a = 0;
        for (int i = 0; i < first.Length; i++)
        {
            for (int j = i + 1; j < first.Length; j++)
            {
                int b = FindSequence(first, i, j);
                if (b != 0) a++;
            }
        }
        answerFirst = new int[a, 2];
        a = 0;
        for (int i = 0; i < first.Length; i++)
        {
            for (int j = i + 1; j < first.Length; j++)
            {
                int b = FindSequence(first, i, j);
                if (b != 0)
                {
                    answerFirst[a, 0] = i;
                    answerFirst[a, 1] = j;
                    a++;
                }
            }
        }

        a = 0;
        for (int i = 0; i < second.Length; i++)
        {
            for (int j = i + 1; j < second.Length; j++)
            {
                int b = FindSequence(second, i, j);
                if (b != 0) a++;
            }
        }
        answerSecond = new int[a, 2];
        a = 0;
        for (int i = 0; i < second.Length; i++)
        {
            for (int j = i + 1; j < second.Length; j++)
            {
                int b = FindSequence(second, i, j);
                if (b != 0)
                {
                    answerSecond[a, 0] = i;
                    answerSecond[a, 1] = j;
                    a++;
                }
            }
        }
        // use FindSequence(array, A, B); from Task_2_28a or entirely Task_2_28a
        static int FindSequence(int[] array, int A, int B)
        {
            int max = 1;
            int min = -1;
            for (int i = A + 1; i < B + 1; i++)
            {
                if (array[i] > array[i - 1]) min = 0;
                if (array[i] < array[i - 1]) max = 0;
            }
            if (max == 1) return 1;
            if (min == -1) return -1;
            return 0;
        }
        // A and B - start and end indexes of elements from array for search

        // end
    }

    public void Task_2_28c(int[] first, int[] second, ref int[] answerFirst, ref int[] answerSecond)
    {
        // code here
        int a = 0;
        int b = 0;
        for (int i = 0; i < first.Length; i++)
        {
            for (int j = i + 1; j < first.Length; j++)
            {
                int c = FindSequence(first, i, j);
                if (c != 0 && b - a < j - i)
                {
                    a = i;
                    b = j;
                }
            }
        }
        answerFirst = new int[] { a, b };
        a = 0;
        b = 0;
        for (int i = 0; i < second.Length; i++)
        {
            for (int j = i + 1; j < second.Length; j++)
            {
                int c = FindSequence(second, i, j);
                if (c != 0 && b - a < j - i)
                {
                    a = i;
                    b = j;
                }
            }
        }
        answerSecond = new int[] { a, b };
        // use FindSequence(array, A, B); from Task_2_28a or entirely Task_2_28a or Task_2_28b
        // A and B - start and end indexes of elements from array for search
        static int FindSequence(int[] array, int A, int B)
        {
            int max = 1;
            int min = -1;
            for (int i = A + 1; i < B + 1; i++)
            {
                if (array[i] > array[i - 1]) min = 0;
                if (array[i] < array[i - 1]) max = 0;
            }
            if (max == 1) return 1;
            if (min == -1) return -1;
            return 0;
        }
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

    public void Task_3_2(int[,] matrix)
    {

        SortRowStyle sortStyle = default(SortRowStyle);

        // code here
        for (int i = 0; i < matrix.GetLength(0); i++)
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
    public delegate void SortRowStyle(int[,] matrix, int rowIndex);
    void SortAscending(int[,] matrix, int rowIndex)
    {
        for (int i = 1, j = 2; i < matrix.GetLength(1);)
        {
            if (i == 0 || matrix[rowIndex, i] >= matrix[rowIndex, i - 1])
            { 
                i = j;
                j++;
            }
            else
            {
                int temp = matrix[rowIndex, i];
                matrix[rowIndex, i] = matrix[rowIndex, i - 1];
                matrix[rowIndex, i - 1] = temp;
                i--;
            }
        }
    }
    void SortDescending(int[,] matrix, int rowIndex)
    {
        for (int i = 1, j = 2; i < matrix.GetLength(1);)
        {
            if (i == 0 || matrix[rowIndex, i] <= matrix[rowIndex, i - 1])
            {
                i = j;
                j++;
            }
            else
            {
                int temp = matrix[rowIndex, i];
                matrix[rowIndex, i] = matrix[rowIndex, i - 1];
                matrix[rowIndex, i - 1] = temp;
                i--;
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
        GetTriangle getTriangle = default(GetTriangle);
        // code here

        // create and use public delegate GetTriangle(matrix);
        // create and use methods GetUpperTriange(array) and GetLowerTriange(array)
        // create and use GetSum(GetTriangle, matrix)
        if (isUpperTriangle)
            answer = GetSum(GetUpperTriangle, matrix);
        else
            answer = GetSum(GetLowerTriangle, matrix);
        // end

        return answer;
    }
    public delegate int[] GetTriangle(int[,] matrix);
    int[] GetUpperTriangle(int[,] matrix)
    {
        int[] a = new int[matrix.GetLength(0) * (matrix.GetLength(0) + 1) / 2];
        int index = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(0); j++)
            {
                if (j >= i)
                    a[index++] = matrix[i, j];
            }
        }
        return a;
    }
    int[] GetLowerTriangle(int[,] matrix)
    {
        int[] a = new int[matrix.GetLength(0) * (matrix.GetLength(0) + 1) / 2];
        int index = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(0); j++)
            {
                if (j <= i)
                    a[index++] = matrix[i, j];
            }
        }
        return a;
    }
    int GetSum(GetTriangle getTriangle, int[,] matrix)
    {
        int[] a = getTriangle(matrix);
        int b = 0;
        foreach (int elem in a)
            b += elem * elem;
        return b;
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
        SwapColumns(matrix, FindDiagonalMaxIndex, FindFirstRowMaxIndex);
        // create and use public delegate FindElementDelegate(matrix);
        // use method FindDiagonalMaxIndex(matrix) like in Task_2_3;
        // create and use method FindFirstRowMaxIndex(matrix);
        // create and use method SwapColumns(matrix, FindDiagonalMaxIndex, FindFirstRowMaxIndex);

        // end
    }
    public delegate int FindElementDelegate(int[,] matrix);
    static int FindDiagonalMaxIndex(int[,] matrix)
    {
        int ind = 0;
        for(int i = 1; i < matrix.GetLength(0); i++)
        {
            if (matrix[i, i] > matrix[ind, ind]) ind = i;
        }
        return ind;
    }
    static int FindFirstRowMaxIndex(int[,] matrix)
    {
        int max = 0;
        for (int i = 0; i < matrix.GetLength(1); i++)
        {
            if (matrix[0, i] > matrix[0, max])
                max = i;
        }
        return max;
    }
    void SwapColumns(int[,] matrix, FindElementDelegate findDiagonalMaxIndex, FindElementDelegate findFirstRowMaxIndex)
    {
        int diagonalmax = findDiagonalMaxIndex(matrix);
        int firstmax = findFirstRowMaxIndex(matrix);
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            int temp = matrix[i, diagonalmax];
            matrix[i, diagonalmax] = matrix[i, firstmax];
            matrix[i, firstmax] = temp;
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
    public delegate int FindIndex(int[,] matrix);
    int FindMaxBelowDiagonalIndex(int[,] matrix)
    {
        int imax = 0, jmax = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
            for (int j = 0; j <= i; j++)
                if (matrix[i, j] > matrix[imax, jmax])
                {
                    imax = i;
                    jmax = j;
                }
        return jmax;
    }
    int FindMinAboveDiagonalIndex(int[,] matrix)
    {
        int imin = 0, jmin = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
            for (int j = i + 1; j < matrix.GetLength(1); j++)
                if (matrix[i, j] < matrix[imin, jmin])
                {
                    imin = i;
                    jmin = j;
                }
        return jmin;
    }
    
    void RemoveColumns(ref int[,] matrix, FindIndex findMaxBelowDiagonalIndex, FindIndex findMinAboveDiagonalIndex)
    {
        int a = findMaxBelowDiagonalIndex(matrix);
        int b = findMinAboveDiagonalIndex(matrix);
        if (a > b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
        matrix = RemoveColumn(matrix, b);
        if (a != b)
            matrix = RemoveColumn(matrix, a);
    }
    static int[,] RemoveColumn(int[,] matrix, int columnIndex)
    {
        int[,] matrix2 = new int[matrix.GetLength(0), matrix.GetLength(1) - 1];

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            int k = 0;
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (j != columnIndex)
                {
                    matrix2[i, k] = matrix[i, j];
                    k++;
                }
            }
        }
        return matrix2;
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
        FindNegatives(matrix, CountNegativeInRows, FindMaxNegativePerColumn, out rows, out cols);
        // create and use public delegate GetNegativeArray(matrix);
        // use GetNegativeCountPerRow(matrix) from Task_2_22
        // use GetMaxNegativePerColumn(matrix) from Task_2_22
        // create and use method FindNegatives(matrix, searcherRows, searcherCols, out rows, out cols);

        // end
    }
    public delegate int[] GetNegativeArray(int[,] matrix);
    int[] CountNegativeInRows(int[,] matrix)
    {
        int[] ans = new int[matrix.GetLength(0)];
        for (int i = 0; i < matrix.GetLength(0); i++)
            ans[i] = CountNegativeInRow(matrix, i);
        return ans;
    }
    void FindNegatives(int[,] matrix, GetNegativeArray searcherRows, GetNegativeArray searcherCols, out int[] rows, out int[] cols)
    {
        rows = searcherRows(matrix);
        cols = searcherCols(matrix);
    }
    static int CountNegativeInRow(int[,] matrix, int rowIndex)
    {
        int count = 0;
        for (int i = 0; i < matrix.GetLength(1); i++) if (matrix[rowIndex, i] < 0) count++;
        return count;
    }
    static int[] FindMaxNegativePerColumn(int[,] matrix)
    {
        int[] mass = new int[matrix.GetLength(1)];
        for (int i = 0; i < matrix.GetLength(1); i++)
        {
            int sum = 0;
            int count = int.MinValue;
            for (int j = 0; j < matrix.GetLength(0); j++)
            {
                if (matrix[j, i] < 0 && matrix[j, i] > count)
                {
                    count = matrix[j, i];
                    sum++;
                }
            }
            if (sum == int.MinValue)
            {
                mass[i] = 0;
            }
            else mass[i] = count;

        }
        return mass;
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
        answerFirst = DefineSequence(first, FindIncreasingSequence, FindDecreasingSequence);
        answerSecond = DefineSequence(second, FindIncreasingSequence, FindDecreasingSequence);
        // create public delegate IsSequence(array, left, right);
        // create and use method FindIncreasingSequence(array, A, B); similar to FindSequence(array, A, B) in Task_2_28a
        // create and use method FindDecreasingSequence(array, A, B); similar to FindSequence(array, A, B) in Task_2_28a
        // create and use method DefineSequence(array, findIncreasingSequence, findDecreasingSequence);

        // end
    }
    public delegate bool IsSequence(int[] array, int left, int right);
    bool FindIncreasingSequence(int[] array, int A, int B)
    {
        return FindSequence(array, A, B) == 1;
    }
    bool FindDecreasingSequence(int[] array, int A, int B)
    {
        return FindSequence(array, A, B) == -1;
    }
    int DefineSequence(int[] array, IsSequence findIncreasingSequence, IsSequence findDecreasingSequence)
    {
        if (findIncreasingSequence(array, 0, array.Length - 1)) return 1;
        if (findDecreasingSequence(array, 0, array.Length - 1)) return -1;
        return 0;
    }
    static int FindSequence(int[] array, int A, int B)
    {
        int max = 1;
        int min = -1;
        for (int i = A + 1; i < B + 1; i++)
        {
            if (array[i] > array[i - 1]) min = 0;
            if (array[i] < array[i - 1]) max = 0;
        }
        if (max == 1) return 1;
        if (min == -1) return -1;
        return 0;
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
    int[] FindLongestSequence(int[] array, IsSequence sequence)
    {
        int s = 0, f = 0;
        for (int i = 0; i < array.Length; i++)
            for (int j = i + 1; j < array.Length; j++)
                if (sequence(array, i, j) && j - i > f - s)
                {
                    s = i; f = j;
                }
        return [s, f];
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
