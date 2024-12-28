using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Numerics;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class Program
{
    public static void Main()
    {
        Program program = new Program();
    }
    public int Factorial(int n)
    {
        int result = 1;
        for (int i = 2; i <= n; i++)
        {
            result *= i;
        }
        return result;
    }
    public int Combinations(int n, int k)
    {

        int result = Factorial(n) / (Factorial(k) * Factorial(n - k));
        return result;
    }
    #region Level 1
    public long Task_1_1(int n, int k)
    {
        long answer = 0;

        if (n < k || n < 0 || k < 0)
            return 0;
        answer = Combinations(n, k);

        return answer;
    }

    public double Sger(double a, double b, double c)
    {
        double p = (a + b + c) / 2.0;
        double answer = Math.Pow(p * (p - a) * (p - b) * (p - c), 0.5);
        return answer;
    }
    public bool TriExi(double a, double b, double c)
    {
        return (a < b + c) && (b < a + c) && (c < a + b);
    }
    public int Task_1_2(double[] first, double[] second)
    {
        int answer = 0;
        double a1 = first[0];
        double b1 = first[1];
        double c1 = first[2];
        double a2 = second[0];
        double b2 = second[1];
        double c2 = second[2];

        if ((!TriExi(a1, b1, c1) || !TriExi(a2, b2, c2))) { return -1; }
        if (Sger(a1, b1, c1) > Sger(a2, b2, c2))
        {
            answer = 1;
        } else if (Sger(a1, b1, c1) < Sger(a2, b2, c2))
        {
            answer = 2;
        }


        return answer;
    }
    public double GetDistance(double v, double a, double t)
    {
        double result = v * t + (a * t * t) / 2.0;
        return result;
    }
    public int Task_1_3a(double v1, double a1, double v2, double a2, int time)
    {
        int answer = 0;
        double S1 = GetDistance(v1, a1, time);
        double S2 = GetDistance(v2, a2, time);
        if (S1 > S2)
        {
            answer = 1;
        }
        else if (S1 < S2)
        {
            answer = 2;
        }
        return answer;
    }

    public int Task_1_3b(double v1, double a1, double v2, double a2)
    {
        int answer = 1;

        while (GetDistance(v1, a1, answer) > GetDistance(v2, a2, answer))
        {
            answer++;
        }

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
    public int FindMaxIndex(double[] array)
    {
        double amax = array[0];
        int index = 0;
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] > amax)
            {
                amax = array[i];
                index = i;
            }
        }
        return index;
    }
    public void Task_2_2(double[] A, double[] B)
    {
        int imaxA = FindMaxIndex(A);
        int imaxB = FindMaxIndex(B);
        double s = 0;
        int k = 0;
        double[] arr;
        int imax;
        if ((A.Length - imaxA) > (B.Length - imaxB))
        {
            arr = A;
            imax = imaxA;
        }
        else
        {
            arr = B;
            imax = imaxB;
        }

        for (int i = imax + 1; i < arr.Length; i++)
        {
            s += arr[i];
            k++;

        }
        double sr = s / k;
        double Amax = arr[imax];
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == Amax)
            {
                arr[i] = sr;
            }
        }
    }
    public void Task_2_3(ref int[,] B, ref int[,] C)
    {
        // code here

        //  create and use method FindDiagonalMaxIndex(matrix);

        // end
    }
    public int FindDiagonalMaxIndex(int[,] matrix)
    {
        int amax = matrix[0, 0];
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        int imax = 0;
        for (int i = 1; i < Math.Min(rows, cols); i++)
            if (matrix[imax, imax] < matrix[i, i])
                imax = i;
        return imax;
    }
    public void Task_2_4(int[,] A, int[,] B)
    {

        int imaxA = FindDiagonalMaxIndex(A);
        int imaxB = FindDiagonalMaxIndex(B);
        for (int i = 0; i < 5; i++)
        {
            (A[imaxA, i], B[i, imaxB]) = (B[i, imaxB], A[imaxA, i]);
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
        int amax = array[0];
        int ind = 0;
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] > amax)
            {
                amax = array[i];
                ind = i;
            }
        }
        return ind;
    }
    public int[] DeleteElement(int[] array, int index)
    {
        int[] arr = new int[array.Length - 1];

        for (int i = 0; i < array.Length; i++)
        {
            if (i < index)
            {
                arr[i] = array[i];
            } else if (i > index)
            {
                arr[i - 1] = array[i];
            }
        }
        return arr;
    }
    public void Task_2_6(ref int[] A, int[] B)
    {
        int imaxA = FindMax(A);
        int imaxB = FindMax(B);
        A = DeleteElement(A, imaxA);
        B = DeleteElement(B, imaxB);
        int[] AB = A;
        A = new int[AB.Length + B.Length];
        for (int i = 0; i < A.Length; i++)
        {
            if (i < AB.Length)
            {
                A[i] = AB[i];

            }
            else
            {
                A[i] = B[i - AB.Length];
            }
        }
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
        for (int i = 0; i < array.Length - startIndex; i++)
        {
            for (int j = startIndex; j < array.Length - i - 1; j++)
            {
                if (array[j] > array[j + 1])
                {
                    (array[j], array[j + 1]) = (array[j + 1], array[j]);
                }
            }
        }
        return array;
    }
    public int FindMaxIndex(int[] array)
    {
        double amax = array[0];
        int index = 0;
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] > amax)
            {
                amax = array[i];
                index = i;
            }
        }
        return index;
    }
    public void Task_2_8(int[] A, int[] B)
    {
        int imaxA = FindMaxIndex(A);
        int imaxB = FindMaxIndex(B);
        A = SortArrayPart(A, imaxA + 1);
        B = SortArrayPart(B, imaxB + 1);
    }

    public int[] Task_2_9(int[,] A, int[,] C)
    {
        int[] answer = default(int[]);

        // code here

        // create and use SumPositiveElementsInColumns(matrix);

        // end

        return answer;
    }
    public void RemoveColumn(ref int[,] matrix, int columnIndex)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        int[,] A = new int[rows, cols - 1];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (j == columnIndex) continue;

                if (j > columnIndex)
                {
                    A[i, j - 1] = matrix[i, j];
                }
                else
                {
                    A[i, j] = matrix[i, j];
                }
            }
        }
        matrix = A;
    }
    public void Task_2_10(ref int[,] matrix)
    {
        int amax = -1000;
        int jmax = 0;
        int amin = 100000;
        int jmin = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (i >= j)
                {
                    if (matrix[i, j] > amax)
                    {
                        amax = matrix[i, j];
                        jmax = j;
                    }
                }
                if (i < j)
                {
                    if (matrix[i, j] < amin)
                    {
                        amin = matrix[i, j];
                        jmin = j;
                    }
                }
            }
        }
        int jmaxM = Math.Max(jmax, jmin);
        int jminM = Math.Min(jmax, jmin);
        RemoveColumn(ref matrix, jmaxM);
        if (jmaxM != jminM)
        {
            RemoveColumn(ref matrix, jminM);
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
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        int amax = 0;
        int jmax = 0;
        for (int j = 0; j < cols; j++)
        {
            for (int i = 0; i < rows; i++)
            {
                if (matrix[i, j] > amax)
                {
                    amax = matrix[i, j];
                    jmax = j;
                }
            }
        }

        return jmax;
    }
    public void Task_2_12(int[,] A, int[,] B)
    {
        int rows = A.GetLength(0);
        int cols = A.GetLength(1);
        int jmax1 = FindMaxColumnIndex(A);
        int jmax2 = FindMaxColumnIndex(B);
        for (int i = 0; i < rows; i++)
        {
            (A[i, jmax1], B[i, jmax2]) = (B[i, jmax2], A[i, jmax1]);
        }
    }

    public void Task_2_13(ref int[,] matrix)
    {
        // code here

        // create and use RemoveRow(matrix, rowIndex);

        // end
    }
    public int[,] SortRow(int[,] matrix, int rowIndex)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        for (int j = 0; j < cols; j++)
        {
            for (int i = 0; i < cols - j - 1; i++)
            {
                if (matrix[rowIndex, i] > matrix[rowIndex, i + 1])
                {
                    (matrix[rowIndex, i], matrix[rowIndex, i + 1]) = (matrix[rowIndex, i + 1], matrix[rowIndex, i]);
                }
            }
        }
        return matrix;
    }
    public void Task_2_14(int[,] matrix)
    {
        int rows = matrix.GetLength(0);
        for (int i = 0; i < rows; i++)
        {
            matrix = SortRow(matrix, i);
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
    public int[] SortNegative(int[] array)
    {
        int k = 0;
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] < 0)
            {
                k++;
            }
        }
        int[] A1 = new int[k];
        int ka = 0;
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] < 0)
            {
                A1[ka++] = array[i];
            }
        }
        for (int i = 0; i < A1.Length; i++)
        {
            for (int j = 0; j < A1.Length - i - 1; j++)
            {
                if (A1[j] < A1[j + 1])
                {
                    (A1[j], A1[j + 1]) = (A1[j + 1], A1[j]);
                }
            }
        }
        int h = 0;
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] < 0)
            {
                array[i] = A1[h++];
            }
        }
        return array;
    }
    public void Task_2_16(int[] A, int[] B)
    {

        A = SortNegative(A);
        B = SortNegative(B);
    }

    public void Task_2_17(int[,] A, int[,] B)
    {
        // code here

        // create and use SortRowsByMaxElement(matrix);

        // end
    }
    public int[,] SortDiagonal(int[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int ld = rows;
        int[] A = new int[ld];
        int k = 0;
        for (int i = 0; i < rows; i++)
        {
            A[k++] = matrix[i, i];
        }
        for (int i = 0; i < A.Length; i++)
        {
            for (int j = 0; j < A.Length - i - 1; j++)
            {
                if (A[j] > A[j + 1])
                {
                    (A[j], A[j + 1]) = (A[j + 1], A[j]);
                }
            }
        }
        int h = 0;
        for (int i = 0; i < rows; i++)
        {
            matrix[i, i] = A[h++];
        }
        return matrix;
    }
    public void Task_2_18(int[,] A, int[,] B)
    {
        A = SortDiagonal(A);
        B = SortDiagonal(B);
    }

    public void Task_2_19(ref int[,] matrix)
    {
        // code here

        // use RemoveRow(matrix, rowIndex); from 2_13

        // end
    }
    public void NulEx(ref int[,] matrix)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            bool nulest = false;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, j] == 0)
                {
                    nulest = true;
                    break;
                }
            }
            if (!nulest)
            {
                RemoveColumn(ref matrix, j);
                j--;
            }

        }
    }
    public void Task_2_20(ref int[,] A, ref int[,] B)
    {
        NulEx(ref A);
        NulEx(ref B);
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
        int ans = 0;
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (matrix[rowIndex, j] < 0)
            {
                ans++;
            }
        }
        return ans;
    }
    public int[] FindMaxNegativePerColumn(int[,] matrix)
    {
        int[] ans = new int[matrix.GetLength(1)];
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            int amax = -100000;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, j] > amax)
                {
                    if (matrix[i, j] < 0)
                    {
                        amax = matrix[i, j];
                    }
                }
            }
            ans[j] = amax;
        }
        return ans;
    }
    public void Task_2_22(int[,] matrix, out int[] rows, out int[] cols)
    {
        rows = new int[matrix.GetLength(0)];
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            rows[i] = CountNegativeInRow(matrix, i);
        }
        cols = FindMaxNegativePerColumn(matrix);

    }

    public void Task_2_23(double[,] A, double[,] B)
    {
        // code here

        // create and use MatrixValuesChange(matrix);

        // end
    }
    public int FindMaxIndex(int[,] matrix, out int row, out int column)
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
        return column;
    }

    public int[,] SwapColumnDiagonal(int[,] matrix, int columnIndex)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            (matrix[i, i], matrix[i, columnIndex]) = (matrix[i, columnIndex], matrix[i, i]);
        }
        return matrix;
    }
    public void Task_2_24(int[,] A, int[,] B)
    {
        int row;
        int column;
        int jmaxA = FindMaxIndex(A, out row, out column);
        A = SwapColumnDiagonal(A, jmaxA);
        int jmaxB = FindMaxIndex(B, out row, out column);
        B = SwapColumnDiagonal(B, jmaxB);
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
    public int FindRowWithMaxNegativeCount(int[,] matrix)
    {
        int amax = -10000;
        int imax = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            if (CountNegativeInRow(matrix, i) > amax)
            {
                amax = CountNegativeInRow(matrix, i);
                imax = i;
            }
        }
        return imax;
    }
    public void Task_2_26(int[,] A, int[,] B)
    {
        int imaxA = FindRowWithMaxNegativeCount(A);
        int imaxB = FindRowWithMaxNegativeCount(B);
        for (int i = 0; i < A.GetLength(1); i++)
        {
            (A[imaxA, i], B[imaxB, i]) = (B[imaxB, i], A[imaxA, i]);
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
    public int FindSequence(int[] array, int A, int B)
    {
        for (int i = A; i < B; i++)
        {
            if (array[A] < array[A + 1] && array[i] > array[i + 1]) return 0;
            if (array[A] >= array[A + 1] && array[i] < array[i + 1]) return 0;
        }
        return array[A] < array[A + 1] ? 1 : -1;
    }
    public void Task_2_28a(int[] first, int[] second, ref int answerFirst, ref int answerSecond)
    {
        answerFirst = FindSequence(first, 0, first.Length - 1);
        answerSecond = FindSequence(second, 0, second.Length - 1);
    }
    public int CountSq(int[] array)
    {
        int k = 0;
        int l1 = array.Length;
        for (int i = 0; i < l1; i++)
        {
            for (int j = i + 1; j < l1; j++)
            {
                int sq = FindSequence(array, i, j);
                if (sq != 0)
                {
                    k++;
                }
            }
        }
        return k;
    }
    public int[,] RepSq(int[] array,ref int[,] A)
    {
        int k = 0;
        for (int i = 0; i < array.Length; i++)
        {
            for (int j = i + 1; j < array.Length; j++)
            {
                int sq = FindSequence(array, i, j);
                if (sq != 0)
                {
                    A[k, 0] = i;
                    A[k, 1] = j;
                    k++;
                }
            }
        }
        return A;
    }
    public void Task_2_28b(int[] first, int[] second, ref int[,] answerFirst, ref int[,] answerSecond)
    {
        int k = CountSq(first);
        answerFirst = new int[k, 2];
        answerFirst = RepSq(first, ref answerFirst);
        int l = CountSq(second);
        answerSecond = new int[l, 2];
        answerSecond = RepSq(second, ref answerSecond);
    }
    public int FindSqI(int[] array)
    {
        int A = 0, B = 0;
        int l1 = array.Length;
        int sq;
        for (int i = 0; i < l1; i++)
        {
            for (int j = i + 1; j < l1; j++)
            {
                sq = FindSequence(array, i, j);
                if (sq != 0 && B - A < j - i)
                {
                    A = i;
                    B = j;
                }
            }
        }
        return A;
        
    }
    public int FindSqJ(int[] array)
    {
        int A = 0, B = 0;
        int l1 = array.Length;
        int sq;
        for (int i = 0; i < l1; i++)
        {
            for (int j = i + 1; j < l1; j++)
            {
                sq = FindSequence(array, i, j);
                if (sq != 0 && B - A < j - i)
                {
                    
                    B = j;
                }
            }
        }
        return B;
    }
    public void Task_2_28c(int[] first, int[] second, ref int[] answerFirst, ref int[] answerSecond)
    {
        int A = FindSqI(first);
        int B = FindSqJ(first);
        answerFirst = new int[] { A, B };
        A = FindSqI(second);
        B = FindSqJ(second);
        answerSecond = new int[] { A, B };
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
    public delegate void SortRowStyle(int[,] matrix, int index);
    void SortAscending(int[,] A, int index)
    {
        int n = A.GetLength(1);
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (A[index, j] > A[index, j + 1])
                {
                    (A[index, j], A[index, j + 1]) = (A[index, j + 1], A[index, j]);
                }
            }
        }
    }
    void SortDescending(int[,] A, int index)
    {
        int n = A.GetLength(1);
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (A[index, j] < A[index, j + 1])
                {
                    (A[index, j], A[index, j + 1]) = (A[index, j + 1], A[index, j]);
                }
            }
        }

    }
    public void Task_3_2(int[,] matrix)
    {
        SortRowStyle sortStyle = default(SortRowStyle);

        

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            if (i % 2 == 0)
            {
                sortStyle = SortAscending;
            }
            else
            {
                sortStyle = SortDescending;
            }

            sortStyle(matrix, i);

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
    public delegate int[] GetTringle(int[,] matrix);
    int[] GetUpperTringle(int[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        int[] A = new int[(rows * rows) / 2 + rows];
        int k = 0;
        for (int i = 0; i < rows; i++)
        {
            for (int j = i; j < cols; j++)
            {
                A[k++] = matrix[i, j];
            }
        }
        return A;
    }
    int[] GetLowerTringle(int[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        int[] A = new int[(rows * rows) / 2 + rows];
        int k = 0;
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j <= i; j++)
            {
                A[k++] = matrix[i, j];
            }
        }
        return A;
    }

    public int Task_3_4(int[,] matrix, bool isUpperTriangle)
    {
        int answer = 0;
        int GetSum(int[,] matrix)
        {
            GetTringle tringle;
            tringle = (isUpperTriangle ? GetUpperTringle : GetLowerTringle);
            int[] arr = tringle(matrix);
            int s = 0;
            foreach (int x in arr)
            {
                s += x * x;
            }
            return s;
        }
        answer = GetSum(matrix);
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
    public delegate int FindElement(int[,] m);
    
    int FindFirstRowMaxIndex(int[,] matrix)
    {
        int amax = -100000;
        int jmax = 0;
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (matrix[0, j] > amax)
            {
                amax = matrix[0, j];
                jmax = j;
            }
        }
        return jmax;
    }
    void SwapColumns(int[,] matrix, FindElement findElementDiag, FindElement findElementRow)
    {
        int n = matrix.GetLength(0);
        int j1 = findElementDiag(matrix);
        int j2 = findElementRow(matrix);
        for (int i = 0; i < n; i++)
        {
            (matrix[i, j1], matrix[i, j2]) = (matrix[i, j2], matrix[i, j1]);
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
    int FindMaxBelowDiagonalIndex(int[,] matrix)
    {
        int amax = matrix[0, 0];
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        int jmax = 0;
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j <= i; j++)
            {
                if (matrix[i, j] > amax)
                {
                    amax = matrix[i, j];
                    jmax = j;
                }
            }
        }
        return jmax;
    }
    int FindMinAboveDiagonalIndex(int[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        int amin = matrix[0, 0];
        int jmin = 0;
        for (int i = 0; i < rows; i++)
        {
            for (int j = i + 1; j < cols; j++)
            {
                if (matrix[i, j] < amin)
                {
                    amin = matrix[i, j];
                    jmin = j;

                }
            }
        }
        return jmin;
    }
    void RemoveColumns(ref int[,] matrix, FindIndex DiagMax, FindIndex DiagMin)
    {
        int el1 = DiagMax(matrix);
        int el2 = DiagMin(matrix);
        if (el1 > el2)
            (el1, el2) = (el2, el1);
        RemoveColumn(ref matrix, el2);
        if (el1 != el2)
            RemoveColumn(ref matrix, el1);

    }
    public void Task_3_10(ref int[,] matrix)
    {
        FindIndex searchArea = default(FindIndex);
        RemoveColumns(ref matrix, FindMaxBelowDiagonalIndex, FindMinAboveDiagonalIndex);
    }

    public void Task_3_13(ref int[,] matrix)
    {
        // code here

        // use public delegate FindElementDelegate(matrix) from Task_3_6
        // create and use method RemoveRows(matrix, findMax, findMin)

        // end
    }
    public delegate int[] GetNegativeArray(int[,] matrix);
    int[] CountNegativeInRows(int[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int[] arr = new int[rows];
        for (int i = 0; i < rows; i++)
        {
            arr[i] = CountNegativeInRow(matrix, i);
        }
        return arr;
    }
    void FindNegatives(int[,] matrix, GetNegativeArray searcherRows, GetNegativeArray searcherCols, out int[] rows, out int[] cols)
    {
        rows = searcherRows(matrix);
        cols = searcherCols(matrix);
    }

    public void Task_3_22(int[,] matrix, out int[] rows, out int[] cols)
    {
        FindNegatives(matrix, CountNegativeInRows, FindMaxNegativePerColumn, out rows, out cols);
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
        int l = array.Length;

        if (findIncreasingSequence(array, 0, l - 1))
        {
            return 1;
        }
        if (findDecreasingSequence(array, 0, l - 1))
        {
            return -1;
        }

        return 0;
    }
    int[] FindLongestSequence(int[] array, IsSequence sequence)
    {
        int l1 = 0;
        int l2 = 0;
        for (int i = 0; i < array.Length; i++)
        {
            for (int j = i + 1; j < array.Length; j++)
            {
                if (sequence(array, i, j) && j - i > l2 - l1)
                {
                    l1 = i;
                    l2 = j;
                }
            }

        }
        return [l1, l2];
    }
    public void Task_3_28a(int[] first, int[] second, ref int answerFirst, ref int answerSecond)
    {
        answerFirst = DefineSequence(first, FindIncreasingSequence, FindDecreasingSequence);
        answerSecond = DefineSequence(second, FindIncreasingSequence, FindDecreasingSequence);
    }
    public void Task_3_28c(int[] first, int[] second, ref int[] answerFirstIncrease, ref int[] answerFirstDecrease, ref int[] answerSecondIncrease, ref int[] answerSecondDecrease)
    {
        answerFirstIncrease = FindLongestSequence(first, FindIncreasingSequence);
        answerFirstDecrease = FindLongestSequence(first, FindDecreasingSequence);
        answerSecondIncrease = FindLongestSequence(second, FindIncreasingSequence);
        answerSecondDecrease = FindLongestSequence(second, FindDecreasingSequence);
    }
    #endregion
    #region bonus part
    public double[,] Task_4(double[,] matrix, int index)
    {
        MatrixConverter[] mat = new MatrixConverter[4];
        mat[0] = ToUpperTriangular;
        mat[1] = ToLowerTriangular;
        mat[2] = ToLeftDiagonal;
        mat[3] = ToRightDiagonal;

        mat[index](matrix);

        return matrix;
    }
    
    delegate void MatrixConverter(double[,] matrix);
    void AddRowToRow(double[,] matrix, int r1, int r2, double a)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        for (int j = 0; j < cols; j++)
        {
            matrix[r2, j] += a * matrix[r1, j];
        }
    }
    void ToUpperTriangular(double[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        double cl = 0;
        for (int i = 0; i < rows; i++)
        {
            for (int j = i + 1; j < rows; j++)
            {
                cl = -matrix[j, i] / matrix[i, i];
                AddRowToRow(matrix, i, j, cl);
            }
        }
    }
    void ToLowerTriangular(double[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        double cl = 0;
        for (int i = rows - 1; i >= 0; i--)
        {
            for (int j = i - 1; j >= 0; j--)
            {
                cl = -matrix[j, i] / matrix[i, i];
                AddRowToRow(matrix, i, j, cl);
            }
        }
    }
    void ToLeftDiagonal(double[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        double cl = 0;
        ToUpperTriangular(matrix);
        for (int i = rows - 1; i >= 0; i--)
        {
            for (int j = i - 1; j >= 0; j--)
            {
                cl = -matrix[j, i] / matrix[i, i];
                AddRowToRow(matrix, i, j, cl);
            }
        }
    }
    void ToRightDiagonal(double[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        double cl = 0;
        ToLowerTriangular(matrix);
        for (int i = 0; i < rows; i++)
        {
            for (int j = i + 1; j < rows; j++)
            {
                cl = -matrix[j, i] / matrix[i, i];
                AddRowToRow(matrix, i, j, cl);
            }
        }
    }
    #endregion
}
