using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Numerics;
using System.Reflection;
using System.Reflection.Metadata;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography;
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
        answer = Combinations(n, k);
        return answer;
    }
    long Combinations(int n, int k)
    {
        long answer = Factorials(n) / (Factorials(k) * Factorials(n - k));
        return answer;
    }
    int Factorials(int n)
    {
        int fk = 1;
        for (int i = 1; i <= n; i++)
            fk *= i;
        return fk;
    }



    public int Task_1_2(double[] first, double[] second)
    {
        int answer = 0;

        if (first.Length != 3 || second.Length != 3) return -1;

        if (!(first[0] < (first[1] + first[2]) && first[1] < (first[0] + first[2]) && first[2] < (first[0] + first[1]))) return -1;
        if (!(second[0] < (second[1] + second[2]) && second[1] < (second[0] + second[2]) && second[2] < (second[0] + second[1]))) return -1;

        double firstArea = GeronArea(first[0], first[1], first[2]);
        double secondArea = GeronArea(second[0], second[1], second[2]);

        if (Math.Abs(firstArea - secondArea) < 1e-5) return 0;
        if (firstArea > secondArea) return 1;
        else return 2;
    }

    double GeronArea(double a, double b, double c)
    {
        double p = (a + b + c) / 2;
        return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
    }




    public int Task_1_3a(double v1, double a1, double v2, double a2, int time)
    {
        int answer = 0;

        // code here
        double firstdist = GetDistance(v1, a1, time);
        double seconddist = GetDistance(v2, a2, time);
        if (firstdist > seconddist) return 1;
        else if (firstdist < seconddist) return 2;
        else if (firstdist == seconddist) return 0;

        // first = 1, second = 2, equal = 0
        return answer;
    }

    public int Task_1_3b(double v1, double a1, double v2, double a2)
    {
        int answer = 0;

        // code here
        int t1 = 1;
        while (GetDistance(v1, a1, t1) > GetDistance(v2, a2, t1))
        {
            t1++;
        }

        // use GetDistance(v, a, t); t - hours

        // end

        return t1;
    }
    double GetDistance(double v, double a, int t)
    {
        double s = v * t + (a * t * t / 2);
        return s;
    }
    #endregion

    #region Level 2
    public void Task_2_1(int[,] A, int[,] B)
    {
        // code here
        // create and use FindMaxIndex(matrix, out row, out column);
        FindMaxIndex(A, out int maxrowA, out int maxcolA);
        FindMaxIndex(B, out int maxrowB, out int maxcolB);
        int temp = A[maxrowA, maxcolA];
        A[maxrowA, maxcolA] = B[maxrowB, maxcolB];
        B[maxrowB, maxcolB] = temp;
        // end
    }
    static void FindMaxIndex(int[,] matrix, out int row, out int col)
    {
        int max = int.MinValue;
        row = 0;
        col = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] > max)
                {
                    max = matrix[i, j];
                    row = i;
                    col = j;
                }
            }
        }
    }
    public void Task_2_2(double[] A, double[] B)
    {
        // code here

        // create and use FindMaxIndex(array);
        // only 1 array has to be changed!

        // end
    }

    public void Task_2_3(ref int[,] B, ref int[,] C)
    {
        // code here
        RemoveRow(ref B);
        RemoveRow(ref C);
        void RemoveRow(ref int[,] matrix)
        {
            int maxrow = FindDiagonalMaxIndex(ref matrix);
            int[,] newmatrix = new int[matrix.GetLength(0) - 1, matrix.GetLength(1)];
            int newrow = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (i != maxrow)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        newmatrix[newrow, j] = matrix[i, j];
                    }
                    newrow++;
                }
            }
            matrix = newmatrix;
        }

        //  create and use method FindDiagonalMaxIndex(matrix);
        int FindDiagonalMaxIndex(ref int[,] matrix)
        {
            int max = int.MinValue;
            int row = 0;
            for (int i = 0; i < Math.Min(matrix.GetLength(0), matrix.GetLength(1)); i++)
            {
                if (matrix[i, i] > max)
                {
                    max = matrix[i, i];
                    row = i;
                }
            }
            return row;
        }
        // end
    }

    public void Task_2_4(int[,] A, int[,] B)
    {
        // code here

        //  create and use method FindDiagonalMaxIndex(matrix); like in Task_2_3

        // end
    }

    public void Task_2_5(int[,] A, int[,] B)
    {
        // code here
        FindMaxInColumn(ref A, 0, out int rowIndexA);
        FindMaxInColumn(ref B, 0, out int rowIndexB);
        for (int j = 0; j < A.GetLength(1); j++)
        {
            int temp = A[rowIndexA, j];
            A[rowIndexA, j] = B[rowIndexB, j];
            B[rowIndexB, j] = temp;
        }
        // create and use FindMaxInColumn(matrix, columnIndex, out rowIndex);
        static void FindMaxInColumn(ref int[,] matrix, int columnIndex, out int rowIndex)
        {
            rowIndex = 0;
            int max = int.MinValue;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, columnIndex] > max)
                {
                    max = matrix[i, columnIndex];
                    rowIndex = i;
                }
            }
        }
        // end
    }

    public void Task_2_6(ref int[] A, int[] B)
    {
        // code here

        // create and use FindMax(matrix, out row, out column); like in Task_2_1
        // create and use DeleteElement(array, index);

        // end
    }

    public void Task_2_7(ref int[,] B, int[,] C)
    {
        // code here
        int maxPositiveCountB = -1;
        int row = -1;
        for (int i = 0; i < B.GetLength(0); i++)
        {
            int cnt = CountRowPositive(ref B, i);
            if (cnt > maxPositiveCountB)
            {
                maxPositiveCountB = cnt;
                row = i;
            }
        }
        int maxPositiveCountC = -1;
        int col = -1;
        for (int j = 0; j < C.GetLength(1); j++)
        {
            int cnt = CountColumnPositive(ref C, j);
            if (cnt > maxPositiveCountC)
            {
                maxPositiveCountC = cnt;
                col = j;
            }
        }
        if (row != -1 && col != -1)
        {
            int[,] newB = new int[B.GetLength(0) + 1, B.GetLength(1)];
            for (int i = 0; i <= row; i++)
            {
                for (int j = 0; j < B.GetLength(1); j++)
                {
                    newB[i, j] = B[i, j];
                }
            }
            for (int j = 0; j < C.GetLength(0); j++)
            {
                newB[row + 1, j] = C[j, col];
            }
            for (int i = row + 1; i < B.GetLength(0); i++)
            {
                for (int j = 0; j < B.GetLength(1); j++)
                {
                    newB[i + 1, j] = B[i, j];
                }
            }
            B = newB;

        }
        // create and use CountRowPositive(matrix, rowIndex);
        // create and use CountColumnPositive(matrix, colIndex);
        int CountRowPositive(ref int[,] matrix, int rowIndex)
        {
            int cnt = 0;
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[rowIndex, j] > 0) cnt++;
            }
            return cnt;
        }
        int CountColumnPositive(ref int[,] matrix, int colIndex)
        {
            int cnt = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, colIndex] > 0) cnt++;
            }
            return cnt;
        }
        // end
    }

    public void Task_2_8(int[] A, int[] B)
    {
        // code here

        // create and use SortArrayPart(array, startIndex);

        // end
    }

    public int[] Task_2_9(int[,] A, int[,] C)
    {
        // code here
        int[] sumA = SumPositiveElementsInColumns(ref A);
        int[] sumC = SumPositiveElementsInColumns(ref C);
        int[] answer = new int[sumA.Length + sumC.Length];
        for (int i = 0; i < answer.Length; i++)
        {
            if (i < A.GetLength(1)) answer[i] = sumA[i];
            else answer[i] = sumC[i - sumA.Length];
        }
        // create and use SumPositiveElementsInColumns(matrix);
        int[] SumPositiveElementsInColumns(ref int[,] matrix)
        {
            int[] sum = new int[matrix.GetLength(1)];
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                int s = 0;
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    if (matrix[i, j] > 0) s += matrix[i, j];
                }
                sum[j] = s;
            }
            return sum;
        }
        // end

        return answer;
    }

    public void Task_2_10(ref int[,] matrix)
    {
        // code here

        // create and use RemoveColumn(matrix, columnIndex);

        // end
    }

    public void Task_2_11(int[,] A, int[,] B)
    {
        // code here

        // use FindMaxIndex(matrix, out row, out column); from Task_2_1
        FindMaxIndex(A, out int rowA, out int colA);
        FindMaxIndex(B, out int rowB, out int colB);
        int temp = A[rowA, colA];
        A[rowA, colA] = B[rowB, colB];
        B[rowB, colB] = temp;

        // end
    }
    public void Task_2_12(int[,] A, int[,] B)
    {
        // code here

        // create and use FindMaxColumnIndex(matrix);

        // end
    }

    public void Task_2_13(ref int[,] matrix)
    {
        int imin = -1;
        int min = int.MaxValue;
        int imax = -1;
        int max = int.MinValue;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] > max)
                {
                    max = matrix[i, j];
                    imax = i;
                }
            }
        }
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] < min)
                {
                    min = matrix[i, j];
                    imin = i;
                }
            }
        }
        matrix = RemoveRow(matrix, imin);
        if (imin < imax)
        {
            matrix = RemoveRow(matrix, imax - 1);
        }
        else if (imin > imax)
        {
            matrix = RemoveRow(matrix, imax);
        }
    }
    int[,] RemoveRow(int[,] matrix, int rowIndex)
    {
        int[,] newMatrix = new int[matrix.GetLength(0) - 1, matrix.GetLength(1)];
        int newRow = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            if (i != rowIndex)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    newMatrix[newRow, j] = matrix[i, j];
                }
                newRow++;
            }
        }
        return newMatrix;
    }

    public void Task_2_14(int[,] matrix)
    {
        // code here

        // create and use SortRow(matrix, rowIndex);

        // end
    }

    public int Task_2_15(int[,] A, int[,] B, int[,] C)
    {
        int answer = 0;
        double[] abc = new double[3];
        abc[0] = GetAverageWithoutMinMax(A);
        abc[1] = GetAverageWithoutMinMax(B);
        abc[2] = GetAverageWithoutMinMax(C);
        if (abc[0] > abc[1] && abc[1] > abc[2]) answer = -1;
        else if (abc[0] < abc[1] && abc[1] < abc[2]) answer = 1;
        else answer = 0;
        // code here

        // create and use GetAverageWithoutMinMax(matrix);
        double GetAverageWithoutMinMax(int[,] matrix)
        {
            int max = int.MinValue;
            int min = int.MaxValue;
            int sum = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    sum += matrix[i, j];
                    if (matrix[i, j] > max) max = matrix[i, j];
                    if (matrix[i, j] < min) min = matrix[i, j];
                }
            }
            double average = (sum - min - max) / (matrix.GetLength(0) * matrix.GetLength(1) - 2);
            return average;
        }
        // end

        // 1 - increasing   0 - no sequence   -1 - decreasing
        return answer;
    }

    public void Task_2_16(int[] A, int[] B)
    {
        // code here

        // create and use SortNegative(array);

        // end
    }

    public void Task_2_17(int[,] A, int[,] B)
    {
        // code here
        SortRowsByMaxElements(A);
        SortRowsByMaxElements(B);
        // create and use SortRowsByMaxElement(matrix);
        void SortRowsByMaxElements(int[,] matrix)
        {
            int[] rows = new int[matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); i++) rows[i] = i;
            for (int i = 0; i < matrix.GetLength(0) - 1; i++)
            {
                for (int j = 0; j < matrix.GetLength(0) - i - 1; j++)
                {
                    int max1 = int.MinValue;
                    for (int k = 0; k < matrix.GetLength(1); k++)
                        if (matrix[rows[j], k] > max1) max1 = matrix[rows[j], k];

                    int max2 = int.MinValue;
                    for (int k = 0; k < matrix.GetLength(1); k++)
                        if (matrix[rows[j + 1], k] > max2) max2 = matrix[rows[j + 1], k];

                    if (max2 > max1)
                    {
                        int temp = rows[j];
                        rows[j] = rows[j + 1];
                        rows[j + 1] = temp;
                    }
                }
            }

            int[,] sortedMatrix = new int[matrix.GetLength(0), matrix.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    sortedMatrix[i, j] = matrix[rows[i], j];
                }
            }
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = sortedMatrix[i, j];
                }
            }
        }
        // end
    }

    public void Task_2_18(int[,] A, int[,] B)
    {
        // code here

        // create and use SortDiagonal(matrix);

        // end
    }

    public void Task_2_19(ref int[,] matrix)
    {
        // code here
        // use RemoveRow(matrix, rowIndex); from 2_13
        int cnt = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            bool nol = false;
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] == 0)
                {
                    nol = true;
                    break;
                }
            }
            if (nol == true) cnt++;
        }
        int[] rows = new int[cnt];
        int k = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            bool nol = false;
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] == 0)
                {
                    nol = true;
                    break;
                }
            }
            if (nol == true)
            {
                rows[k] = i;
                k++;
            }
        }
        for (int i = rows.Length - 1; i >= 0; i--)
        {
            matrix = RemoveRow(matrix, rows[i]);
        }
        // end
    }
    public void Task_2_20(ref int[,] A, ref int[,] B)
    {
        // code here

        // use RemoveColumn(matrix, columnIndex); from 2_10

        // end
    }

    public void Task_2_21(int[,] A, int[,] B, out int[] answerA, out int[] answerB)
    {
        answerA = CreateArrayFromMins(A);
        answerB = CreateArrayFromMins(B);

        // code here

        // create and use CreateArrayFromMins(matrix);

        // end
    }
    int[] CreateArrayFromMins(int[,] matrix)
    {
        int[] array = new int[matrix.GetLength(0)];
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            int min = int.MaxValue;
            for (int j = i; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] < min)
                {
                    min = matrix[i, j];
                }
            }
            array[i] = min;
        }
        return array;
    }
    public void Task_2_22(int[,] matrix, out int[] rows, out int[] cols)
    {
        rows = null;
        cols = null;

        // code here

        // create and use CountNegativeInRow(matrix, rowIndex);
        // create and use FindMaxNegativePerColumn(matrix);

        // end
    }

    public void Task_2_23(double[,] A, double[,] B)
    {
        // code here
        MatrixValuesChange(A);
        MatrixValuesChange(B);
        // create and use MatrixValuesChange(matrix);
    }
    void MatrixValuesChange(double[,] matrix)
    {
        double max = double.MinValue;
        double[] all = new double[matrix.GetLength(0) * matrix.GetLength(1)];
        int k = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                all[k++] = matrix[i, j];
            }
        }
        for (int i = 0; i < all.Length - 1; i++)
        {
            for (int j = i + 1; j < all.Length; j++)
            {
                if (all[i] < all[j])
                {
                    double temp = all[i];
                    all[i] = all[j];
                    all[j] = temp;
                }
            }
        }
        double[] five = new double[5];
        int count = 0;
        for (int i = 0; i < five.Length && i < all.Length; i++)
        {
            five[i] = all[i];
        }

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                bool isfive = false;
                for (int m = 0; m < five.Length; m++)
                {
                    if (matrix[i, j] == five[m])
                    {
                        isfive = true;
                        break;
                    }
                }
                if (isfive)
                {
                    if (matrix[i, j] > 0) matrix[i, j] *= 2;
                    else matrix[i, j] /= 2;
                }
                else
                {
                    if (matrix[i, j] > 0) matrix[i, j] /= 2;
                    else matrix[i, j] *= 2;
                }

            }
        }
    }
    // end


    public void Task_2_24(int[,] A, int[,] B)
    {
        // code here

        // use FindMaxIndex(matrix, out row, out column); like in 2_1
        // create and use SwapColumnDiagonal(matrix, columnIndex);

        // end
    }

    public void Task_2_25(int[,] A, int[,] B, out int maxA, out int maxB)
    {
        maxA = FindRowWithMaxNegativeCount(A);
        maxB = FindRowWithMaxNegativeCount(B);

        // code here

        // create and use FindRowWithMaxNegativeCount(matrix);
        // in FindRowWithMaxNegativeCount create and use CountNegativeInRow(matrix, rowIndex); like in 2_22

        // end
    }
    int FindRowWithMaxNegativeCount(int[,] matrix)
    {
        int max = -1;
        int rowmax = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            if (CountNegativeInRow(matrix, i) > max)
            {
                max = CountNegativeInRow(matrix, i);
                rowmax = i;
            }
        }
        return rowmax;
    }
    int CountNegativeInRow(int[,] matrix, int rowIndex)
    {
        int cnt = 0;
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (matrix[rowIndex, j] < 0) cnt++;
        }
        return cnt;
    }

    public void Task_2_26(int[,] A, int[,] B)
    {
        // code here

        // create and use FindRowWithMaxNegativeCount(matrix); like in 2_25
        // in FindRowWithMaxNegativeCount use CountNegativeInRow(matrix, rowIndex); from 2_22

        // end
    }

    public void Task_2_27(int[,] A, int[,] B)
    {
        // code here

        // create and use FindRowMaxIndex(matrix, rowIndex, out columnIndex);
        // create and use ReplaceMaxElementOdd(matrix, row, column); нечет
        // create and use ReplaceMaxElementEven(matrix, row, column); чет
        for (int i = 0; i < A.GetLength(0); i++)
        {
            FindRowMaxIndex(A, i, out int columnIndexA);
            if ((i + 1) % 2 == 0)
            {
                ReplaceMaxElementEven(A, i, columnIndexA);
            }
            else
            {
                ReplaceMaxElementOdd(A, i, columnIndexA);
            }
        }
        for (int i = 0; i < B.GetLength(0); i++)
        {
            FindRowMaxIndex(B, i, out int columnIndexB);
            if ((i + 1) % 2 == 0)
            {
                ReplaceMaxElementEven(B, i, columnIndexB);
            }
            else
            {
                ReplaceMaxElementOdd(B, i, columnIndexB);
            }
        }
        // end
    }
    void FindRowMaxIndex(int[,] matrix, int rowIndex, out int columnIndex)
    {
        columnIndex = -1;
        int max = int.MinValue;
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (matrix[rowIndex, j] > max)
            {
                max = matrix[rowIndex, j];
                columnIndex = j;
            }
        }
    }
    void ReplaceMaxElementOdd(int[,] matrix, int row, int col)
    {
        matrix[row, col] *= (col + 1);
    }
    void ReplaceMaxElementEven(int[,] matrix, int row, int col)
    {
        matrix[row, col] = 0;
    }
    public void Task_2_28a(int[] first, int[] second, ref int answerFirst, ref int answerSecond)
    {
        // code here

        // create and use FindSequence(array, A, B); // 1 - increasing, 0 - no sequence,  -1 - decreasing
        // A and B - start and end indexes of elements from array for search

        // end
    }

    public void Task_2_28b(int[] first, int[] second, ref int[,] answerFirst, ref int[,] answerSecond)
    {
        // code here

        // use FindSequence(array, A, B); from Task_2_28a or entirely Task_2_28a
        // A and B - start and end indexes of elements from array for search

        // end
    }

    public void Task_2_28c(int[] first, int[] second, ref int[] answerFirst, ref int[] answerSecond)
    {
        // code here

        // use FindSequence(array, A, B); from Task_2_28a or entirely Task_2_28a or Task_2_28b
        // A and B - start and end indexes of elements from array for search

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
    public delegate double SumFunction(double x);
    public delegate double YFunction(double x);
    void GetSumAndY(double sFunction, double yFunction,int a, int b, int h) { }
    public void Task_3_2(int[,] matrix)
    {
        // SortRowStyle sortStyle = default(SortRowStyle); - uncomment me

        // code here

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

    public int Task_3_4(int[,] matrix, bool isUpperTriangle)
    {
        int answer = 0;

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

    public void Task_3_6(int[,] matrix)
    {
        // code here

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

    public void Task_3_10(ref int[,] matrix)
    {
        // FindIndex searchArea = default(FindIndex); - uncomment me

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

    public void Task_3_22(int[,] matrix, out int[] rows, out int[] cols)
    {

        rows = null;
        cols = null;

        // code here

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

    public void Task_3_28a(int[] first, int[] second, ref int answerFirst, ref int answerSecond)
    {
        // code here

        // create public delegate IsSequence(array, left, right);
        // create and use method FindIncreasingSequence(array, A, B); similar to FindSequence(array, A, B) in Task_2_28a
        // create and use method FindDecreasingSequence(array, A, B); similar to FindSequence(array, A, B) in Task_2_28a
        // create and use method DefineSequence(array, findIncreasingSequence, findDecreasingSequence);

        // end
    }

    public void Task_3_28c(int[] first, int[] second, ref int[] answerFirstIncrease, ref int[] answerFirstDecrease, ref int[] answerSecondIncrease, ref int[] answerSecondDecrease)
    {
        // code here

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
