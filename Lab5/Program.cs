using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data.Common;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class Program
{
    public int Factorial(int n)
    {
        int result = 1;
        for (int i = 2; i <= n; i++)
        {
            result *= i;
        }
        return result;
    }
    public static void Main()
    {
        Program program = new Program();
    }
    #region Level 1
    public long Task_1_1(int n, int k)
    {
        long answer = 0;

        // code here
        if (n < k || k < 0 || n < 0)
            return 0;
        answer = Factorial(n) / (Factorial(k) * Factorial(n - k));
        // create and use Combinations(n, k);
        // create and use Factorial(n);

        // end

        return answer;
    }
    //public bool CheckTriangle(double a, double b, double c)
    //{
    //    return (a + b > c && a + c > b && b + c > a);
    //}
    double GeronArea(double a, double b, double c)
    {
        if (a <= 0 || b <= 0 || c <= 0) return -1;
        double p = (a + b + c) / 2;
        double sq = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        if (sq <= 0) return -1;
        return sq;
    }
    public int Task_1_2(double[] first, double[] second)
    {
        //int answer = 0;

        // code here
        if (first.Length != 3 || second.Length != 3)
            return -1;
        double s1 = GeronArea(first[0], first[1], first[2]);
        double s2 = GeronArea(second[0], second[1], second[2]);
        if (s1 < 0 || s2 < 0) return -1;
        if (s1 > s2) return 1;
        if (s1 < s2) return 2;
        if (s1 == s2) return 0;
        else
            return -1;
        // create and use GeronArea(a, b, c);

        // end

        // first = 1, second = 2, equal = 0, error = -1
    }
    public double GetDistance(double v, double a, int t)
    {
        return v * t + a * t * t / 2;
    }
    public int Task_1_3a(double v1, double a1, double v2, double a2, int time)
    {
        double s1 = GetDistance(v1, a1, time);
        double s2 = GetDistance(v2, a2, time);
        if (s1 > s2) return 1;
        if (s1 < s2) return 2;
        return 0;
        // code here

        // create and use GetDistance(v, a, t); t - hours

        // end

        // first = 1, second = 2, equal = 0
    }

    public int Task_1_3b(double v1, double a1, double v2, double a2)
    {
        int time = 1;
        while (GetDistance(v1, a1, time) > GetDistance(v2, a2, time)) time++;
        return time;

        // code here

        // use GetDistance(v, a, t); t - hours

        // end

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
        int maxi = 0;
        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] > array[maxi])
            {
                maxi = i;
            }
        }
        return maxi;
    }
    static void Replace(double[] array, int maxi)
    {
        if (maxi == array.Length - 1) return;
        double s = 0;
        double count = 0;
        for (int i = maxi + 1; i < array.Length; i++)
        {
            s += array[i];
            count++;
        }
        double ave = s / count;
        array[maxi] = ave;
    }
    public void Task_2_2(double[] A, double[] B)
    {
        // code here
        int maxiA = FindMaxIndex(A);
        int maxiB = FindMaxIndex(B);
        if (A.Length - maxiA - 1 > B.Length - maxiB - 1)
        {
            Replace(A, maxiA);
        }
        else
            Replace(B, maxiB);
        // create and use FindMaxIndex(array);
        // only 1 array has to be changed!

        // end
    }
 
    public void Task_2_3(ref int[,] B, ref int[,] C)
    {
        // code here

        // Для матрицы C
        //  create and use method FindDiagonalMaxIndex(matrix);

        // end
    }
    public int FindDiagonalMaxIndex(int[,] matrix)
    {
        int max = matrix[0, 0];
        int index = 0;
        for (int i = 1; i < matrix.GetLength(0); i++)
        {
            if (matrix[i, i] > max)
            {
                max = matrix[i, i];
                index = i;
            }
        }
        return index;
    }
    static void ReplaceRowadColumn(int[,] A, int[,] B, int rowA, int colB)
    {
        for (int i = 0; i < A.GetLength(0); i++)
        {
            int temp = A[rowA, i];
            A[rowA, i] = B[i, colB];
            B[i, colB] = temp;
        }
    }
    public void Task_2_4(int[,] A, int[,] B)
    {
        // code here
        int maxiA = FindDiagonalMaxIndex(A), maxiB = FindDiagonalMaxIndex(B);
        for (int i = 0; i < A.GetLength(0); i++)
        {
            (A[maxiA, i], B[i, maxiB]) = (B[i, maxiB], A[maxiA, i]);
        }
        //  create and use method FindDiagonalMaxIndex(matrix); like in Task_2_3

        // end
    }
    public void FindMaxInColumn(int[,] matrix, int columnIndex, out int rowIndex)
    {
        int max = matrix[0, 1];
        rowIndex = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            if (matrix[i, 1] > max)
            {
                max = matrix[i, 1];
                rowIndex = i;
            }
        }
    }
    public void Task_2_5(int[,] A, int[,] B)
    {
        // code here
        if (A.GetLength(0) != 4 || A.GetLength(1) != 6 || B.GetLength(0) != 6 || B.GetLength(1) != 6) return;
        FindMaxInColumn(A, 0, out int rowIndexA);
        FindMaxInColumn(B, 0, out int rowIndexB);
        for (int i = 0; i < A.GetLength(1); i++)
        {
            int temp = A[rowIndexA, i];
            A[rowIndexA, i] = B[rowIndexB, i];
            B[rowIndexB, i] = temp;
        }
        // create and use FindMaxInColumn(matrix, columnIndex, out rowIndex);

        // end
    }
    public int FindMax(int[] array)
    {
        int maxi = 0;
        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] > array[maxi])
            {
                maxi = i;
            }
        }
        return maxi;
    }
    public int[] DeleteElement(int[] array, int index)
    {
        int[] newArray = new int[array.Length - 1];
        int j = 0;
        for (int i = 0; i < array.Length; i++)
        {
            if (i != index)
            {
                newArray[j] = array[i];
                j++;
            }
        }
        return newArray;
    }
    public void Task_2_6(ref int[] A, int[] B)
    {
        // code here
        int maxiA = FindMax(A), maxiB = FindMax(B);
        A = DeleteElement(A, maxiA);
        B = DeleteElement(B, maxiB);
        int[] temp = new int[A.Length + B.Length];
        for (int i = 0; i < A.Length; i++)
        {
            temp[i] = A[i];
        }
        for (int i = 0; i < B.Length; i++)
        {
            temp[A.Length + i] = B[i];
        }
        A = temp;
        // create and use FindMax(matrix, out row, out column); like in Task_2_1
        // create and use DeleteElement(array, index);

        // end
    }
    public int CountRowPositive(int[,] matrix, int rowIndex)
    {
        int count = 0;
        for(int j = 0; j < matrix.GetLength(1); j++)
        {
            if (matrix[rowIndex, j] > 0) 
                count++;
        }
        return count;
    }
    public int CountColumnPositive(int [,]matrix, int colIndex)
    {
        int count = 0;
        for (int i = 0; i < matrix.GetLength (0); i++)
        {
            if (matrix[i, colIndex] > 0)
                count++;
        }
        return count;
    }
    public void Task_2_7(ref int[,] B, int[,] C)
    {
        // code here
        
        // create and use CountRowPositive(matrix, rowIndex);
        // create and use CountColumnPositive(matrix, colIndex);

        // end
    }
    static void SortArrayPart(int[] array, int startIndex)
    {
        int maxIndex = 0;
        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] > array[maxIndex])
            {
                maxIndex = i;
            }
        }
        SortArrayPart(array, maxIndex + 1);
    }
    public void Task_2_8(int[] A, int[] B)
    {
        // code here
        if (A.Length != 9 || B.Length != 11) return;
        int maxi = FindMax(A);
        SortArrayPart(A, maxi + 1);
        maxi = FindMax(B);
        SortArrayPart(B, maxi + 1);
        // create and use SortArrayPart(array, startIndex);

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
        int[,] newMatrix = new int[matrix.GetLength(0), matrix.GetLength(1) - 1];
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (j < columnIndex)
                {
                    newMatrix[i, j] = matrix[i, j];
                }
                else if (j > columnIndex)
                {
                    newMatrix[i, j - 1] = matrix[i, j];
                }
                else
                {
                    continue;
                }
            }
        }
        return newMatrix;
    }
    public void Task_2_10(ref int[,] matrix)
    {
        // code here
        if (matrix.GetLength(0) != matrix.GetLength(1) || matrix.GetLength(0) <= 0) return;
        int maxi1 = 0, maxj1 = 0;
        int maxi2 = 0, maxj2 = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (j <= i && matrix[i, j] > matrix[maxi1, maxj1])
                {
                    maxi1 = i;
                    maxj1 = j;
                }
                else if (j > i && matrix[i, j] > matrix[maxi2, maxj2])
                {
                    maxi2 = i;
                    maxj2 = j;
                }
            }
        }
        if (maxj1 == maxj2)
        {
            matrix = RemoveColumn(matrix, maxj1);
        }
        else
        {
            int firstColumn = Math.Max(maxj1, maxj2);
            int secondColumn = Math.Min(maxj1, maxj2);
            matrix = RemoveColumn(matrix, firstColumn);
            matrix = RemoveColumn(matrix, secondColumn);
        }
        // create and use RemoveColumn(matrix, columnIndex);

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
        int max = matrix[0,0];
        int maxColumn = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] > max)
                {
                    max = matrix[i, j];
                    maxColumn = j;
                }
            }
        }
        return maxColumn;
    }
    static void SwapColumns(int[,] matrixA, int[,] matrixB, int colA, int colB)
    {
        int rows = matrixA.GetLength(0), temp;
        for (int i = 0; i < rows; i++)
        {
            temp = matrixA[i, colA];
            matrixA[i, colA] = matrixB[i, colB];
            matrixB[i, colB] = temp;
        }
    }
    public void Task_2_12(int[,] A, int[,] B)
    {
        // code here
        if (A.GetLength(0) != B.GetLength(0) || A.GetLength(1) != B.GetLength(1) || A.GetLength(0) <= 0 || A.GetLength(1) <= 0) return;
        int maxA = FindMaxColumnIndex(A), maxB = FindMaxColumnIndex(B);
        SwapColumns(A, B, maxA, maxB);
        // create and use FindMaxColumnIndex(matrix);

        // end
    }

    public void Task_2_13(ref int[,] matrix)
    {
        // code here

        // create and use RemoveRow(matrix, rowIndex);

        // end
    }
    public void SortRow(int [,] matrix, int rowIndex)
    {
        //int[] temp = new int[matrix.GetLength(1)];
        for (int i = 0; i < matrix.GetLength(1); i++)
        {
            for (int j = 0; j < matrix.GetLength(1) - i - 1; j++)
            {
                if (matrix[rowIndex, j] > matrix[rowIndex, j + 1])
                {
                    int temp = matrix[rowIndex, j + 1];
                    matrix[rowIndex, j + 1] = matrix[rowIndex, j];
                    matrix[rowIndex, j] = temp;
                }
            }
        }
    }
    public void Task_2_14(int[,] matrix)
    {
        // code here
        int count = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for(int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] != 0)
                {
                    count = 1; 
                    break;
                }
            }
            if (count == 1) break;
        }
        for(int i = 0; i < matrix.GetLength(0); i++)
        {
            SortRow(matrix,i);
        }
        // create and use SortRow(matrix, rowIndex);

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
    public void SortNegative(int[] array)
    {
        int count = 0;
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] < 0)
            {
                count++;
            }
        }
        int[] negative = new int[count];
        int index = 0;
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] < 0)
            {
                negative[index] = array[i];
                index++;
            }
        }
        for (int i = 0; i < negative.Length; i++)
        {
            for (int j = 0; j < negative.Length - i - 1; j++)
            {
                if (negative[j] < negative[j + 1])
                {
                    int temp = negative[j + 1];
                    negative[j + 1] = negative[j];
                    negative[j] = temp;
                }
            }
        }
        index = 0;
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] < 0)
            {
                array[i] = negative[index];
                index++;
            }
        }
    }

    public int Checking(int[] array)
    {
        for (int j = 0; j < array.Length; j++)
        {
            if (array[j] != 0)
                return 1;
        }
        return 0;
    }

    public void Task_2_16(int[] A, int[] B)
    {
        // code here
        if (Checking(A) == 0 || Checking(B) == 0) return;
        SortNegative(A);
        SortNegative(B);
        // create and use SortNegative(array);

        // end
    }

    public void Task_2_17(int[,] A, int[,] B)
    {
        // code here

        // create and use SortRowsByMaxElement(matrix);

        // end
    }
    public void SortDiagonal(int[,]matrix)
    {
        int rows = matrix.GetLength(0);
        int[] diagonal = new int[rows];
        for (int i = 0; i < rows; i++)
        {
            diagonal[i] = matrix[i, i];
        }
        for (int i = 0; i < rows - 1; i++)
        {
            for (int j = 0; j < rows - i - 1; j++)
            {
                if (diagonal[j] > diagonal[j + 1])
                {
                    int temp = diagonal[j];
                    diagonal[j] = diagonal[j + 1];
                    diagonal[j + 1] = temp;
                }
            }
        }
        for(int i = 0; i < rows; i++)
        {
            matrix[i, i] = diagonal[i];
        }
    }
    public int CheckingMatrix(int[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] != 0)
                    return 1;
            }
        }
        return 0;
    }
    public void Task_2_18(int[,] A, int[,] B)
    {
        // code here
        if (CheckingMatrix(A) == 0 || CheckingMatrix(B) == 0) return;
        SortDiagonal(A);
        SortDiagonal(B);
        // create and use SortDiagonal(matrix);

        // end
    }

    public void Task_2_19(ref int[,] matrix)
    {
        // code here

        // use RemoveRow(matrix, rowIndex); from 2_13

        // end
    }
    public void Removing (ref int[,] matrix)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            bool zero = false;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, j] == 0)
                {
                    zero = true;
                    break;
                }
            }
            if (!zero)
            {
                matrix = RemoveColumn(matrix, j);
                j--;
            }
        }
    }
    public void Task_2_20(ref int[,] A, ref int[,] B)
    {
        // code here
        if (CheckingMatrix(A) == 0 || CheckingMatrix(B) == 0) return;
        Removing(ref A);
        Removing(ref B);
        
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
        int[] temp1 = new int[matrix.GetLength(0)];
        for (int i = 0; i < matrix.GetLength(0);i++)
        {
            int count = 0;
            for (int j = 0; j < matrix.GetLength(1);j++)
            {
                if (matrix[i, j] < 0)
                    count++;
            }
            temp1[i] = count;
        }
        return temp1;
    }
    public int[] FindMaxNegativePerColumn(int [,]matrix)
    {
        int[] temp2  = new int[matrix.GetLength(1)];
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            int negmax = int.MinValue;
            int count = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int cur = matrix[i, j];
                if (cur < 0)
                {
                    count++;
                    if (cur > negmax)
                        negmax = cur;
                }    
            }
            if (count > 0)
                temp2[j] = negmax;
            else
                temp2[j] = 0;
        }
        return temp2;
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
    public void FindMaxIndex(int [,]matrix, out int row, out int column)
    {
        row = 0; column = 0;
        int max = matrix[0, 0];
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] > max)
                {
                    max = matrix[i, j];
                    row = i; column = j;
                }
            }
        }
    }
    public void SwapColumnDiagonal(ref int [,]matrix, int columnIndex)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            int temp = matrix[i, i];
            matrix[i, i] = matrix[i, columnIndex];
            matrix[i, columnIndex] = temp;
        }
    }
    public void Task_2_24(int[,] A, int[,] B)
    {
        // code here
        int rowA = 0, columnA = 0;
        int rowB = 0, columnB = 0;
        FindMaxIndex(A, out rowA, out columnA);
        FindMaxIndex(B, out rowB, out columnB);
        SwapColumnDiagonal(ref A, columnA);
        SwapColumnDiagonal(ref B, columnB);
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
    public int CountNegativeInRow(int [,]matrix, int rowIndex)
    {
        int count = 0;
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (matrix[rowIndex, j] < 0)
                count++;
        }
        return count;
    }
    public int FindRowWithMaxNegativeCount(int[,] matrix)
    {
        int max = 0, row = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            int count = CountNegativeInRow(matrix, i);
            if (count > max)
            {
                max = count; row = i;
            }
        }
        return row;
    }
    public void Task_2_26(int[,] A, int[,] B)
    {
        // code here
        int rowA = FindRowWithMaxNegativeCount(A);
        int rowB = FindRowWithMaxNegativeCount(B);
        for (int j = 0; j < A.GetLength(1); j++)
        {
            int temp = A[rowA, j];
            A[rowA, j] = B[rowB, j]; 
            B[rowB, j] = temp;
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
        bool flag = array[A] < array[A + 1];
        for (int i = A; i < B; i++)
        {
            if (flag && array[i] > array[i + 1] || !flag && array[i] < array[i + 1])
                return 0;
        }
        if (flag)
            return 1;
        return -1;
    }
    public void Task_2_28a(int[] first, int[] second, ref int answerFirst, ref int answerSecond)
    {
        // code here
        answerFirst = FindSequence(first, 0, first.Length - 1);
        answerSecond = FindSequence(second, 0, second.Length - 1);
        // create and use FindSequence(array, A, B); // 1 - increasing, 0 - no sequence,  -1 - decreasing
        // A and B - start and end indexes of elements from array for search

        // end
    }
    public int[,] FindSequences(int[] array)
    {
        int count = 0;
        for (int i = 0; i < array.Length; i++)
        {
            for (int j = i + 1; j < array.Length; j++)
            {
                int sequence = FindSequence(array, i, j);
                if (sequence != 0) count++;
            }
        }
        int[,] result = new int[count, 2];
        count = 0;
        for (int i = 0; i < array.Length; i++)
        {
            for (int j = i + 1; j < array.Length; j++)
            {
                int sequence = FindSequence(array, i, j);
                if (sequence != 0)
                {
                    result[count, 0] = i;
                    result[count, 1] = j;
                    count++;
                }
            }
        }
        return result;
    }
    public void Task_2_28b(int[] first, int[] second, ref int[,] answerFirst, ref int[,] answerSecond)
    {
        // code here
        FindSequences(first);
        FindSequences(second);
       
        // use FindSequence(array, A, B); from Task_2_28a or entirely Task_2_28a
        // A and B - start and end indexes of elements from array for search

        // end
    }
    public int[] FindLongestSequence(int[] array)
    {
        {
            int start = 0;
            int end = 0;

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (FindSequence(array, i, j) != 0 && (end - start) < (j - i))
                    {
                        start = i;
                        end = j;
                    }
                }
            }

            return new int[] { start, end };
        }
    }
    public void Task_2_28c(int[] first, int[] second, ref int[] answerFirst, ref int[] answerSecond)
    {
        // code here
        FindLongestSequence(first);
        FindLongestSequence(second);
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
    public delegate void SortRowStyle(int[,] matrix, int rowIndex);
    public void SortAscending(int[,]matrix, int rowIndex)
    {
        for (int i = 0; i < matrix.GetLength(1); i++)
        {
            for (int j = 0; j < matrix.GetLength(1) - 1 - i; j++)
            {
                if (matrix[rowIndex, j + 1] < matrix[rowIndex, j])
                {
                    int temp = matrix[rowIndex, j + 1];
                    matrix[rowIndex, j + 1] = matrix[rowIndex, j];
                    matrix[rowIndex, j] = temp;
                }
            }
        }
    }
    public void SortDescending(int[,] matrix, int rowIndex)
    {
        for (int i = 0; i < matrix.GetLength(1); i++)
        {
            for (int j = 0; j < matrix.GetLength(1) - 1 - i; j++)
            {
                if (matrix[rowIndex, j + 1] > matrix[rowIndex, j])
                {
                    int temp = matrix[rowIndex, j + 1];
                    matrix[rowIndex, j + 1] = matrix[rowIndex, j];
                    matrix[rowIndex, j] = temp;
                }
            }
        }
    }

    public void Task_3_2(int[,] matrix)
    {
        SortRowStyle sortStyle = default(SortRowStyle);
        for(int i = 0; i < matrix.GetLength(0);i++)
        {
            if (i % 2 == 0)
                sortStyle = SortAscending;
            else 
                sortStyle = SortDescending;
            sortStyle(matrix, i);
        }

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
    public delegate int[] GetTriangle(int[,] matrix);
    public int[] GetUpperTriange(int[,]array)
    {
        int[] temp  = new int[array.GetLength(0) * (array.GetLength (0) + 1) / 2];
        int count = 0;
        for (int i = 0; i < array.GetLength(0);i++)
        {
            for (int j = 0; j < array.GetLength(0);j++)
            {
                if (i <= j)
                {
                    temp[count] = array[i, j];
                    count++;
                }
            }
        }
        return temp;
    }
    public int[] GetLowerTriange(int[,] array)
    {
        int[] temp = new int[Factorial(array.GetLength(0))];
        int count = 0;
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(0); j++)
            {
                if (i >= j)
                {
                    temp[count] = array[i, j];
                    count++;
                }
            }
        }
        return temp;
     }
    public int GetSum(GetTriangle getTriangle, int[,]matrix)
    {
        int[] array = getTriangle(matrix);
        int s = 0;
        for (int i = 0; i < array.Length;i++)
        {
            s += array[i] * array[i];
        }
        return s;
    }


    public int Task_3_4(int[,] matrix, bool isUpperTriangle)
    {
        int answer = 0;
        //if (matrix == null ||matrix.GetLength(0) != matrix.GetLength(1)) return 0;
        GetTriangle sortStyle = default(GetTriangle);
        if (isUpperTriangle)
            sortStyle = GetUpperTriange;
        else 
            sortStyle = GetLowerTriange;
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

    int FindFirstRowMaxIndex(int[,] matrix)
    {
        int maxi = 0;
        for (int j = 0; j < matrix.GetLength(1); j++)
            if (matrix[0, j] > matrix[0, maxi])
            {
                maxi = j;
            }
        return maxi;
    }
    void SwapColumns(int[,] matrix, FindElementDelegate findDiagonalMaxIndex, FindElementDelegate findFirstRowMaxIndex)
    {
        int MaxDiagonal = findDiagonalMaxIndex(matrix);
        int MaxRow = findFirstRowMaxIndex(matrix);
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            int temp = matrix[i, MaxDiagonal];
            matrix[i, MaxDiagonal] = matrix[i, MaxRow];
            matrix[i, MaxRow] = temp;
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

    public delegate int CountPositive(int[,] matrix, int index);

    public void InsertColumn(ref int[,] matrixB, int countRow, int[,] matrixC, int countColumn)
    {
        int[,] temp = new int[matrixB.GetLength(0) + 1, matrixC.GetLength(0)];

        for (int i = 0; i < temp.GetLength(0); i++)
            for (int j = 0; j < temp.GetLength(1); j++)
            {
                if (i < countRow)
                    temp[i, j] = matrixB[i, j];
                else if (i == countRow)
                    temp[i, j] = matrixC[j, countColumn];
                else
                    temp[i, j] = matrixB[i - 1, j];
            }
        matrixB = temp;
    }

    public void Task_3_7(ref int[,] B, int[,] C)
    {
        // code here
        CountPositive countPositive;

        int max = int.MinValue, indexColumn = -1;
        countPositive = CountRowPositive;

        for (int i = 0; i < B.GetLength(0); i++)
        {
            int count = countPositive(B, i);
            if (count > max)
            {
                max = count;
                indexColumn = i;
            }
        }
        int indexRow = -1;
        max = int.MinValue;
        countPositive = CountColumnPositive;
        for (int j = 0; j < C.GetLength(1); j++)
        {
            int count = countPositive(C, j);
            if (count > max)
            {
                max = count;
                indexRow = j;
            }
        }
        InsertColumn(ref B, indexRow + 1, C, indexColumn);
        // create and use public delegate CountPositive(matrix, index);
        // use CountRowPositive(matrix, rowIndex) from Task_2_7
        // use CountColumnPositive(matrix, colIndex) from Task_2_7
        // create and use method InsertColumn(matrixB, CountRow, matrixC, CountColumn);

        // end
    }
    public delegate int FindIndex(int[,] matrix);

    public int FindMaxBelowDiagonalIndex(int[,] matrix)
    {
        int maxi = 0;
        int max = int.MinValue;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j <= i; j++)
            {
                if (matrix[i, j] > max)
                {
                    maxi = j;
                    max = matrix[i, j];
                }
            }
        }
        return maxi;
    }

    public int FindMinAboveDiagonalIndex(int[,] matrix)
    {
        int mini = 0;
        int min = int.MaxValue;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = i + 1; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] < min)
                {
                    mini = j;
                    min = matrix[i, j];
                }
            }
        }
        return mini;
    }

    public void RemoveColumns(ref int[,] matrix, int maxBelowIndex, int minAboveIndex)
    {
        if (maxBelowIndex == minAboveIndex)
        {
            matrix = RemoveColumn(matrix, Math.Max(maxBelowIndex, minAboveIndex));
        }
        else
        {
            matrix = RemoveColumn(matrix, Math.Max(maxBelowIndex, minAboveIndex));
            matrix = RemoveColumn(matrix, Math.Min(maxBelowIndex, minAboveIndex));
        }
    }
    public void Task_3_10(ref int[,] matrix)
    {
        FindIndex searchArea = default(FindIndex);
        searchArea = FindMaxBelowDiagonalIndex;
        int maxBelowIndex = searchArea(matrix);
        searchArea = FindMinAboveDiagonalIndex;
        int minAboveIndex = searchArea(matrix);
        RemoveColumns(ref matrix, maxBelowIndex, minAboveIndex);
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

    public void Task_3_22(int[,] matrix, out int[] rows, out int[] cols)
    {

        rows = null;
        cols = null;

        // code here
        GetNegativeArray searcherRows = GetNegativeCountPerRow;
        GetNegativeArray searcherCols = FindMaxNegativePerColumn;
        FindNegatives(matrix, searcherRows, searcherCols, out rows, out cols);
        // create and use public delegate GetNegativeArray(matrix);
        // use GetNegativeCountPerRow(matrix) from Task_2_22
        // use GetMaxNegativePerColumn(matrix) from Task_2_22
        // create and use method FindNegatives(matrix, searcherRows, searcherCols, out rows, out cols);

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
    public int DefineSequence(int[] array, IsSequence findIncreasingSequence, IsSequence findDecreasingSequence)
    {
        if (findIncreasingSequence(array, 0, array.Length - 1))
        {
            return 1;
        }
        if (findDecreasingSequence(array, 0, array.Length - 1))
        {
            return -1;
        }
        return 0;
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
     int[] FindLongestSequence(int[] array, IsSequence sequence)
    {
        int start = 0, end = 0;
        for (int i = 0; i < array.Length; i++)
            for (int j = i + 1; j < array.Length; j++)
                if (sequence(array, i, j) == true && (j - i > end - start))
                {
                    start = i; end = j;
                }
        return [start, end];
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
