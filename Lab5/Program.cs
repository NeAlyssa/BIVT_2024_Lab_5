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
    }
    #region Level 1
    public long Task_1_1(int n, int k)
    {
        long answer = 0;

        // code here
        if (n < k || n < 0 || k < 0) return 0;
        answer = Combinations(n, k);
        // end

        return answer;
    }
    public int Factorial(int x)
    {
        if (x < 2) return 1;
        return x * Factorial(x - 1);
    }
    public long Combinations(int n, int k)
    {
        return (long)Factorial(n) / (Factorial(k) * Factorial(n - k));
    }
    public int Task_1_2(double[] first, double[] second)
    {
        // code here
        if (first == null || second == null) return -1;
        double area1, area2;
        // create and use GeronArea(a, b, c);

        if (!isExists(first[0], first[1], first[2]) || !isExists(second[0], second[1], second[2])) return -1;
        GeronArea(first[0], first[1], first[2], out area1);
        GeronArea(second[0], second[1], second[2], out area2);

        if (area1 > area2) return 1;
        else if (area1 < area2) return 2;
        else return 0;
        // first = 1, second = 2, equal = 0, error = -1
    }
    public void GeronArea(double a, double b, double c, out double area)
    {
        double p = (a + b + c) / 2;
        area = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
    }
    public bool isExists(double a, double b, double c)
    {
        if (a < b + c && b < a + c && c < a + b) return true;
        else return false;
    }
    public int Task_1_3a(double v1, double a1, double v2, double a2, int time)
    {
        // int answer = 0;

        // code here
        double s1 = GetDistance(v1, a1, time);
        double s2 = GetDistance(v2, a2, time);

        if (s1 > s2) return 1;
        else if (s1 < s2) return 2;
        else return 0;
        // create and use GetDistance(v, a, t); t - hours

        // end

        // first = 1, second = 2, equal = 0
        
    }

    public int Task_1_3b(double v1, double a1, double v2, double a2)
    {
        int answer = 0;

        // code here
        for (int t = 1; ; t++)
        {
            if (GetDistance(v1, a1, t) <= GetDistance(v2, a2, t)) return t;
        }
        // use GetDistance(v, a, t); t - hours

        // end

        return answer;
    }
    public double GetDistance(double v, double a, int t)
    {
        return v * t + a * t * t / 2;
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
        int indexA = FindMaxIndex(A);
        int indexB = FindMaxIndex(B);

        double distanceA = A.Length - indexA - 1;
        double distanceB = B.Length - indexB - 1;

        if (distanceA > distanceB) ReplaceMaxWithAverage(A, indexA);
        else ReplaceMaxWithAverage(B, indexB);
 
        // create and use FindMaxIndex(array);
        // only 1 array has to be changed!

        // end
    }
    public int FindMaxIndex(double[] array)
    {
        int maxIndex = 0;
        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] > array[maxIndex])
            {
                maxIndex = i;
            }
        }
        return maxIndex;
    }
    static void ReplaceMaxWithAverage(double[] array, int maxIndex)
    {
        if (maxIndex == array.Length - 1) return;
        double sum = 0;
        double count = 0;

        for (int i = maxIndex + 1; i < array.Length; i++)
        {
            sum += array[i];
            count++;
        }

        double average = sum / count;
        array[maxIndex] = average;
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
        int ai = FindDiagonalMaxIndex(A);
        int bi = FindDiagonalMaxIndex(B);
        for (int i = 0; i < A.GetLength(0); i++)
        {
            (A[ai, i], B[i, bi]) = (B[i, bi], A[ai, i]);
        }
        // end
    }
    int FindDiagonalMaxIndex(int[,] matrix)
    {
        int n = matrix.GetLength(0), imax = 0;
        for (int i = 0; i < n; i++)
        {
            if (matrix[i, i] > matrix[imax, imax]) imax = i;
        }
        return imax;
    }

    static void SwapRowAndColumn(int[,] A, int[,] B, int rowA, int colB)
    {
        int size = A.GetLength(0);
        for (int i = 0; i < size; i++)
        {
            int temp = A[rowA, i];
            A[rowA, i] = B[i, colB];
            B[i, colB] = temp;
        }
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
        // code here
        int maxIndexA = FindMax(A);
        int maxIndexB = FindMax(B);

        A = DeleteElement(A, maxIndexA);
        B = DeleteElement(B, maxIndexB);

        int[] combinedArray = new int[A.Length + B.Length];

        for (int i = 0; i < A.Length; i++)
        {
            combinedArray[i] = A[i];
        }
        for (int i = 0; i < B.Length; i++)
        {
            combinedArray[A.Length + i] = B[i];
        }

        A = combinedArray; 
        // create and use FindMax(matrix, out row, out column); like in Task_2_1
        // create and use DeleteElement(array, index);

        // end
    }
    static int FindMax(int[] array)
    {
        int maxIndex = 0;
        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] > array[maxIndex]) maxIndex = i;
        }
        return maxIndex;
    }
    static int[] DeleteElement(int[] array, int index)
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
        int maxIndex = FindMax(A);
        SortArrayPart(A, maxIndex + 1);
        maxIndex = FindMax(B);
        SortArrayPart(B, maxIndex + 1);
        // create and use SortArrayPart(array, startIndex);

        // end
    }
    static void SortArrayPart(int[] array, int startIndex)
    {
        if (startIndex >= array.Length) return;

        for (int i = startIndex; i < array.Length - 1; i++)
        {
            int minIndex = i;
            for (int j = i + 1; j < array.Length; j++)
            {
                if (array[j] < array[minIndex]) minIndex = j;
            }
            int temp = array[i];
            array[i] = array[minIndex];
            array[minIndex] = temp;
        }
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
        int maxBelow = FindMaxBelowDiagonal(matrix);
        int minAbove = FindMinAboveDiagonal(matrix);
        if (maxBelow >= 0) RemoveColumn(ref matrix, maxBelow);
        if (minAbove >= 0 && minAbove != maxBelow) RemoveColumn(ref matrix, minAbove);
        // create and use RemoveColumn(matrix, columnIndex);

        // end
    }
    static void RemoveColumn(ref int[,] matrix, int columnIndex)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        int[,] newMatrix = new int[rows, cols - 1];
        int newCol;
        for (int i = 0; i < rows; i++)
        {
            newCol = 0;
            for (int j = 0; j < cols; j++)
            {
                if (j != columnIndex && newCol < newMatrix.GetLength(1))
                {
                    newMatrix[i, newCol] = matrix[i, j];
                    newCol++;
                }
            }
        }

        matrix = newMatrix;
    }
    static int FindMinAboveDiagonal(int[,] matrix)
    {
        int size = matrix.GetLength(0);
        int min = int.MaxValue;
        int minColumnIndex = -1;

        for (int i = 0; i < size; i++)
        {
            for (int j = i + 1; j < size; j++) 
            {
                if (matrix[i, j] < min)
                {
                    min = matrix[i, j];
                    minColumnIndex = j;
                }
            }
        }

        return minColumnIndex;
    }
    static int FindMaxBelowDiagonal(int[,] matrix)
    {
        int size = matrix.GetLength(0);
        int max = int.MinValue;
        int maxColumnIndex = -1;
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j <= i; j++) 
            {
                if (matrix[i, j] > max)
                {
                    max = matrix[i, j];
                    maxColumnIndex = j;
                }
            }
        }

        return maxColumnIndex;
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
        int maxColA = FindMaxColumnIndex(A);
        int maxColB = FindMaxColumnIndex(B);
        SwapColumns(ref A, ref B, maxColA, maxColB);
        // create and use FindMaxColumnIndex(matrix);

        // end
    }
    static int FindMaxColumnIndex(int[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        int max = int.MinValue;
        int maxColIndex = -1;

        for (int j = 0; j < cols; j++)
        {
            for (int i = 0; i < rows; i++)
            {
                if (matrix[i, j] > max)
                {
                    max = matrix[i, j];
                    maxColIndex = j;
                }
            }
        }

        return maxColIndex;
    }
    static void SwapColumns(ref int[,] matrixA, ref int[,] matrixB, int colA, int colB)
    {
        int rows = matrixA.GetLength(0);
        int temp;
        for (int i = 0; i < rows; i++)
        {
            temp = matrixA[i, colA];
            matrixA[i, colA] = matrixB[i, colB];
            matrixB[i, colB] = temp;
        }
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
        int rows = matrix.GetLength(0);
        for (int i = 0; i < rows; i++)
        {
            SortRow(matrix, i);
        }
        // create and use SortRow(matrix, rowIndex);

        // end
    }
    static void SortRow(int[,] matrix, int rowIndex)
    {
        int cols = matrix.GetLength(1);
        for (int i = 0; i < cols - 1; i++)
        {
            int minIndex = i;

            for (int j = i + 1; j < cols; j++)
            {
                if (matrix[rowIndex, j] < matrix[rowIndex, minIndex]) minIndex = j;
            }

            int temp = matrix[rowIndex, i];
            matrix[rowIndex, i] = matrix[rowIndex, minIndex];
            matrix[rowIndex, minIndex] = temp;
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
        SortNegative(A);
        SortNegative(B);
        // create and use SortNegative(array);

        // end
    }
    static void SortNegative(int[] array)
    {
        int negativeCount = 0;
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] < 0) negativeCount++;
        }

        int[] negatives = new int[negativeCount];
        int index = 0;
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] < 0) negatives[index++] = array[i];
        }

        for (int i = 0; i < negatives.Length - 1; i++)
        {
            for (int j = 0; j < negatives.Length - 1 - i; j++)
            {
                if (negatives[j] < negatives[j + 1]) 
                {
                    int temp = negatives[j];
                    negatives[j] = negatives[j + 1];
                    negatives[j + 1] = temp;
                }
            }
        }

        index = 0;
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] < 0) array[i] = negatives[index++];
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
        SortDiagonal(A);
        SortDiagonal(B);
        // create and use SortDiagonal(matrix);

        // end
    }
    public static void SortDiagonal(int[,] matrix)
    {
        int n = matrix.GetLength(0);
        int[] diagonal = new int[n];

        for (int i = 0; i < n; i++)
        {
            diagonal[i] = matrix[i, i];
        }

        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - 1 - i; j++)
            {
                if (diagonal[j] > diagonal[j + 1])
                {
                    int temp = diagonal[j];
                    diagonal[j] = diagonal[j + 1];
                    diagonal[j + 1] = temp;
                }
            }
        }

        for (int i = 0; i < n; i++)
        {
            matrix[i, i] = diagonal[i];
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
        RemoveColumnsWithoutZeros(ref A);
        RemoveColumnsWithoutZeros(ref B);
        // use RemoveColumn(matrix, columnIndex); from 2_10

        // end
    }

    public static void RemoveColumnsWithoutZeros(ref int[,] matrix)
    {
        int columns = matrix.GetLength(1);

        for (int col = columns - 1; col >= 0; col--) 
        {
            bool hasZero = false;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if (matrix[row, col] == 0)
                {
                    hasZero = true;
                    break;
                }
            }
            if (!hasZero) RemoveColumn(ref matrix, col);

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
        if (matrix == null) return;
        // code here
        int Rows = matrix.GetLength(0);
        rows = new int[Rows];
        for (int i = 0; i < Rows; i++)
        {
            rows[i] = CountNegativeInRow(matrix, i);
        }
        cols = FindMaxNegativePerColumn(matrix);
        // create and use CountNegativeInRow(matrix, rowIndex);
        // create and use FindMaxNegativePerColumn(matrix);

        // end
    }
    static int CountNegativeInRow(int[,] matrix, int rowIndex) 
    {
        int count = 0;
        int columns = matrix.GetLength(1);
        for (int i = 0; i < columns; i++)
        {
            if (matrix[rowIndex, i] < 0) count++;
        }
        return count;
    }
    static int[] FindMaxNegativePerColumn(int[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int columns = matrix.GetLength(1);
        int[] maxNegatives = new int[columns];

        for (int j = 0; j < columns; j++)
        {
            int maxNegative = int.MinValue;
            bool foundNegative = false;

            for (int i = 0; i < rows; i++)
            {
                if (matrix[i, j] < 0)
                {
                    foundNegative = true;
                    if (matrix[i, j] > maxNegative)
                    {
                        maxNegative = matrix[i, j];
                    }
                }
            }

            // Если в столбце нет отрицательных элементов, ставим значение по умолчанию
            if (!foundNegative)
            {
                maxNegatives[j] = int.MinValue;
            }
            else
            {
                maxNegatives[j] = maxNegative;
            }
        }

        return maxNegatives;
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
        if (A.GetLength(0) != A.GetLength(1)) return;
        if (B.GetLength(0) != B.GetLength(1)) return;
        if (B == null) return;
        if (A == null) return;
        FindMaxIndex(A, out int rowA, out int columnA);
        SwapColumnDiagonal(A, columnA);
        FindMaxIndex(B, out int rowB, out int columnB);
        SwapColumnDiagonal(B, columnB);
        // use FindMaxIndex(matrix, out row, out column); like in 2_1
        // create and use SwapColumnDiagonal(matrix, columnIndex);

        // end
    }
    static void FindMaxIndex(int[,] matrix, out int row, out int column)
    {
        int rows = matrix.GetLength(0);
        int columns = matrix.GetLength(1);

        row = 0;
        column = 0;
        int maxElement = matrix[row, column];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                if (matrix[i, j] > maxElement)
                {
                    maxElement = matrix[i, j];
                    row = i;
                    column = j;
                }
            }
        }
    }

    static void SwapColumnDiagonal(int[,] matrix, int columnIndex)
    {
        int size = matrix.GetLength(0); 

        for (int i = 0; i < size; i++)
        {
            int temp = matrix[i, i];
            matrix[i, i] = matrix[i, columnIndex];
            matrix[i, columnIndex] = temp;
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
        int MaxA = FindRowWithMaxNegativeCount(A);
        int MaxB = FindRowWithMaxNegativeCount(B);
        SwapRows(A, B, MaxA, MaxB);
        // create and use FindRowWithMaxNegativeCount(matrix); like in 2_25
        // in FindRowWithMaxNegativeCount use CountNegativeInRow(matrix, rowIndex); from 2_22

        // end
    }
    private int FindRowWithMaxNegativeCount(int[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int maxNegativeCount = 0;
        int rowIndexWithMaxNegatives = 0;

        for (int i = 0; i < rows; i++)
        {
            int negativeCount = CountNegativeInRow(matrix, i);
            if (negativeCount > maxNegativeCount)
            {
                maxNegativeCount = negativeCount;
                rowIndexWithMaxNegatives = i;
            }
        }
        return rowIndexWithMaxNegatives;
    }
    private void SwapRows(int[,] matrixA, int[,] matrixB, int rowIndexA, int rowIndexB)
    {
        int columns = matrixA.GetLength(1);

        for (int j = 0; j < columns; j++)
        {
            int temp = matrixA[rowIndexA, j];
            matrixA[rowIndexA, j] = matrixB[rowIndexB, j];
            matrixB[rowIndexB, j] = temp;
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
        int A = 0; 
        int B = first.Length - 1; 
        answerFirst = FindSequence(first, A, B);
        answerSecond = FindSequence(second, A, B);
        // create and use FindSequence(array, A, B); // 1 - increasing, 0 - no sequence,  -1 - decreasing
        // A and B - start and end indexes of elements from array for search

        // end
    }
    public int FindSequence(int[] array, int A, int B)
    {
        bool isIncreasing = true;
        bool isDecreasing = true;

        for (int i = A; i < B; i++)
        {
            if (array[i] < array[i + 1]) isDecreasing = false;
            else if (array[i] > array[i + 1]) isIncreasing = false;
        }

        if (isIncreasing) return 1;
        if (isDecreasing) return -1; 
        return 0; 
    }
    public void Task_2_28b(int[] first, int[] second, ref int[,] answerFirst, ref int[,] answerSecond)
    {
        // code here
        answerFirst = ProcessArray(first);
        answerSecond = ProcessArray(second);
        // use FindSequence(array, A, B); from Task_2_28a or entirely Task_2_28a
        // A and B - start and end indexes of elements from array for search

        // end
    }
    private int[,] ProcessArray(int[] array)
    {
        int n = 0;

        for (int i = 0; i < array.Length; i++)
        {
            for (int j = i + 1; j < array.Length; j++)
            {
                if (FindSequence(array, i, j) != 0) n++;
            }
        }

        int[,] result = new int[n, 2];
        n = 0;
        for (int i = 0; i < array.Length; i++)
        {
            for (int j = i + 1; j < array.Length; j++)
            {
                if (FindSequence(array, i, j) != 0)
                {
                    result[n, 0] = i;
                    result[n, 1] = j;
                    n++;
                }
            }
        }

        return result;
    }
    public void Task_2_28c(int[] first, int[] second, ref int[] answerFirst, ref int[] answerSecond)
    {
        // code here
        answerFirst = FindLongestSequence(first);
        answerSecond = FindLongestSequence(second);
        // use FindSequence(array, A, B); from Task_2_28a or entirely Task_2_28a or Task_2_28b
        // A and B - start and end indexes of elements from array for search

        // end
    }
    private int[] FindLongestSequence(int[] array)
    {
        int start = 0, end = 0;
        int length = array.Length;

        for (int i = 0; i < length; i++)
        {
            for (int j = i + 1; j < length; j++)
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
            sortStyle(ref matrix, i);
        }
        // create and use public delegate SortRowStyle(matrix, rowIndex);
        // create and use methods SortAscending(matrix, rowIndex) and SortDescending(matrix, rowIndex)
        // change method in variable sortStyle in the loop here and use it for row sorting

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

        // code here
        GetTriangle sortStyle = default(GetTriangle);
        if (isUpperTriangle) sortStyle = GetUpperTriange;
        else sortStyle = GetLowerTriange;

        answer = GetSum(sortStyle, matrix);
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
        SwapColumns(matrix, FindDiagonalMaxIndex, FindFirstRowMaxIndex);
        // create and use public delegate FindElementDelegate(matrix);
        // use method FindDiagonalMaxIndex(matrix) like in Task_2_3;
        // create and use method FindFirstRowMaxIndex(matrix);
        // create and use method SwapColumns(matrix, FindDiagonalMaxIndex, FindFirstRowMaxIndex);

        // end
    }
    public delegate int FindElementDelegate(int[,] matrix);
    int FindFirstRowMaxIndex(int[,] matrix)
    {
        int imax = 0;
        for (int j = 0; j < matrix.GetLength(1); j++)
            if (matrix[0, j] > matrix[0, imax]) imax = j;
        return imax;
    }
    void SwapColumns(int[,] matrix, FindElementDelegate findDiagonalMaxIndex, FindElementDelegate findFirstRowMaxIndex)
    {
        int a = findDiagonalMaxIndex(matrix);
        int b = findFirstRowMaxIndex(matrix);
        for (int i = 0; i < matrix.GetLength(0); i++)
            (matrix[i, a], matrix[i, b]) = (matrix[i, b], matrix[i, a]);
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
            (a, b) = (b, a);
        RemoveColumn(ref matrix, b);
        if (a != b)
            RemoveColumn(ref matrix, a);
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
   
    public void Task_3_22(int[,] matrix, out int[] rows, out int[] cols)
    {

        rows = null;
        cols = null;
        FindNegatives(matrix, CountNegativeInRows, FindMaxNegativePerColumn, out rows, out cols);
        // code here
        //FindNegatives(matrix, CountNegativeInRow, FindMaxNegativePerColumn, out rows, out cols);
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
        {
            ans[i] = CountNegativeInRow(matrix, i);
        }
        return ans;
    }
    void FindNegatives(int[,] matrix, GetNegativeArray searcherRows, GetNegativeArray searcherCols, out int[] rows, out int[] cols)
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
        return new int[] { start, end };
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
    public delegate void MatrixConverter(double[,] A);
    public void ToUpperTriangular(double[,] A)
    {
        for (int j = 0; j < A.GetLength(1); j++)
        {
            for (int i = j + 1; i < A.GetLength(0); i++)
            {
                double k = -(A[i, j] / A[j, j]);
                A[i, j] = 0;
                for (int z = j + 1; z < A.GetLength(1); z++) 
                { 
                    A[i, z] += A[j, z] * k; 
                }
            }
        }
    }
    public void ToLowerTriangular(double[,] A)
    {
        for (int j = A.GetLength(1) - 1; j >= 0; j--)
        {
            for (int i = j - 1; i >= 0; i--)
            {
                double k = -(A[i, j] / A[j, j]);
                A[i, j] = 0;
                for (int z = j - 1; z >= 0; z--) 
                { 
                    A[i, z] += A[j, z] * k; 
                }
            }
        }
    }
    public void ToLeftDiagonal(double[,] A)
    {
        ToUpperTriangular(A);
        ToLowerTriangular(A);
    }
    public void ToRightDiagonal(double[,] A)
    {
        ToLowerTriangular(A);
        ToUpperTriangular(A);
    }
    public double[,] Task_4(double[,] matrix, int index)
    {

        // code here
        MatrixConverter[] mc = { ToUpperTriangular, ToLowerTriangular, ToLeftDiagonal, ToRightDiagonal };
        mc[index](matrix);
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
