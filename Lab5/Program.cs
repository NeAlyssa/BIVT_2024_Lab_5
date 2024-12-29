using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Numerics;
using System.Reflection;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
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

        // code here

        // create and use Combinations(n, k);
        // create and use Factorial(n);
        answer = Combinations(n, k);
        // end

        return answer;
    }
    public int Factorial(int n)
    {
        int s = 0;
        for (int i = 0; i < n; i++)
        {
            s *= i;
        }
        return s;
    }
    public int Combinations(int n, int k)
    {
        if (n != 0 && k!= 0) { return 0; }
        return Factorial(n) / (Factorial(k) * Factorial(n - k));
    }


    public int Task_1_2(double[] first, double[] second)
    {
        if (first.Length != 3 || second.Length != 3 ||
            first[0] <= 0 || first[1] <= 0 || first[2] <= 0 ||
            second[0] <= 0 || second[1] <= 0 || second[2] <= 0)
        {
            return -1;         }

        double a1 = first[0];
        double b1 = first[1];
        double c1 = first[2];        
        double a2 = second[0];
        double b2 = second[1];
        double c2 = second[2];

        if (a1 >= b1 + c1 || b1 >= a1 + c1 || c1 >= a1 + b1 || a2 >= b2 + c2 || b2 >= a2 + c2 || c2 >= a2 + b2) { return -1; }
                
        double area1 = GeronArea(a1, b1, c1);
        double area2 = GeronArea(a2, b2, c2);

        if (area1 > area2)
        {
            return 1; 
        }
        else if (area1 == area2)
        {
            return 0; 
        }
        else
        {
            return 2; 
        }
    }

    public double GeronArea(double a, double b, double c)
    {
        double p = (a + b + c) / 2; // Полупериметр
        double s = Math.Sqrt(p * (p - a) * (p - b) * (p - c)); // Площадь по формуле Герона
        return s;
    }
      

    public int Task_1_3a(double v1, double a1, double v2, double a2, int time)
    {
        int answer = 0;

        // code here
        if (v1 == 0 || v2 == 0 || a1 == 0 || a2 == 0) {return 0;}

        // create and use GetDistance(v, a, t); t - hours
        double s1 = GetDistance(v1, a1, time);
        double s2 = GetDistance(v2, a2, time);
        if (s1 > s2)
        {
            return 1;
        }
        else if (s1 == s2) { return 0; }
        else { return 2; }
        // end

        // first = 1, second = 2, equal = 0
        return answer;
    }
    public double GetDistance(double v, double a, double t)
    {
        return (v * t + (a * Math.Pow(t,2))/ 2);
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

        // end

        return time;
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

        // create and use FindMaxIndex(array);
        // only 1 array has to be changed!

        int index_A = FindMaxIndex(A);
        int index_B = FindMaxIndex(B);

        if (A.Length - index_A < B.Length - index_B)
        {            
            B[index_B] = AverageAfterMax(B, index_B);
        }
        else
        {
            A[index_A] = AverageAfterMax(A, index_A);
        }
        // end
    }
    public static int FindMaxIndex(double[] array)
    {
        int max_i = 0;

        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] > array[max_i]) max_i = i;
        }

        return max_i;
    }
    public static double AverageAfterMax(double[] arr, int max_i)
    {
        double avr = 0;
        int amount = 0;
        for (int i = max_i + 1; i < arr.Length; i++)
        {
            avr += arr[i];
            amount++;
        }

        if (amount != 0) return avr / amount;
        else return 0;
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

        int maxA = FindDiagonalMaxIndex(A);
        int maxB = FindDiagonalMaxIndex(B);

        for (int i = 0; i < A.GetLength(0); i++)
        {
            int temp = A[maxA, i];
            A[maxA, i] = B[i, maxB];
            B[i, maxB] = temp;
        }
        //  create and use method FindDiagonalMaxIndex(matrix); like in Task_2_3
        
        // end
    }
    public int FindDiagonalMaxIndex(int[,] a)
    {
        int maxIndex = 0;
        for (int i = 1; i < a.GetLength(0); i++)
        {
            if (a[i, i] > a[maxIndex, maxIndex])
                maxIndex = i;
        }
        return maxIndex;
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
        int index_a = FindMax(A);
        int index_b = FindMax(B);
        int[] new_a = DeleteElement(A, index_a);
        int[] new_b = DeleteElement(B, index_b);

        int[] C = new int[new_a.Length + new_b.Length];
        int index = 0;
        for (int i = 0; i < new_a.Length; i++)
        {
            C[index++] = new_a[i];
        }

        for (int i = 0; i < new_b.Length; i++)
        {
            C[index++] = new_b[i];
        }
        A = C;
        
    }
    int FindMax(int[] array)
    {
        int max = 0;
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] > array[max])
                max = i;
        }
        return max;
    }
    int[] DeleteElement(int[] array, int index)
    {
        int[] new_array = new int[array.Length - 1];
        for (int i = 0; i < index; i++)
            new_array[i] = array[i];
        for (int i = index; i < new_array.Length; i++)
            new_array[i] = array[i + 1];
        return new_array;
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
        int index_a = FindMax(A);
        int index_b = FindMax(B);

        SortArrayPart(A, index_a + 1);
        SortArrayPart(B, index_b + 1);

    }
    public void SortArrayPart(int[] array, int index)
    {
        for (int i = index + 1, j = index + 2; i < array.Length;)
        {
            if (i == index || array[i - 1] < array[i])
            {
                i = j;
                j++;
            }
            else
            {
                (array[i - 1], array[i]) = (array[i], array[i - 1]);
                i--;
            }
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
        int maxValue = matrix[0, 0];
        int maxIndex = 0;
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (col <= row && maxValue < matrix[row, col])
                {
                    maxValue = matrix[row, col];
                    maxIndex = col;
                }
            }
        }
                
        int minValue = matrix[0, 0];
        int minIndex = 0;
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (col > row && minValue < matrix[row, col])
                {
                    minValue = matrix[row, col];
                    minIndex = col;
                }
            }
        }

        if (maxIndex < minIndex)
        {
            matrix = RemoveColumn(ref matrix, minIndex);
            matrix = RemoveColumn(ref matrix, maxIndex);
        }
        else if (maxIndex > minIndex)
        {
            matrix = RemoveColumn(ref matrix, maxIndex);
            matrix = RemoveColumn(ref matrix, minIndex);
        }
        else
        {
            matrix = RemoveColumn(ref matrix, maxIndex);
        }
    }

    public int[,] RemoveColumn(ref int[,] matrix, int columnToRemove)
    {
        int[,] newMatrix = new int[matrix.GetLength(0), matrix.GetLength(1) - 1];

        for (int j = 0; j < columnToRemove; j++)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                newMatrix[i, j] = matrix[i, j];
            }
        }
        for (int j = columnToRemove; j < newMatrix.GetLength(1); j++)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                newMatrix[i, j] = matrix[i, j + 1];
            }
        }

        return newMatrix; 
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
        int a_col = FindMaxColumnIndex(A);
        int b_col = FindMaxColumnIndex(B);
        for (int i = 0; i < A.GetLength(0); i++)
        {
            int temp = A[i, a_col];
            A[i, a_col] = B[i, b_col];
            B[i, b_col] = temp;
        }
        // end
    }
    int FindMaxColumnIndex(int[,] matrix)
    {
        int max = int.MinValue;
        int max_index = -1;
        for (int j = 0; j < matrix.GetLength(0); j++)
        {
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                if (matrix[j, i] > max)
                {
                    max = matrix[j, i];
                    max_index = i;
                }
            }
        }
        return max_index;
    }

    public void Task_2_13(ref int[,] matrix)
    {
        // code here

        // create and use RemoveRow(matrix, rowIndex);

        // end
    }

    public void Task_2_14(int[,] matrix)
    {        
        int rows = matrix.GetLength(0);
        int columns = matrix.GetLength(1);
               
        for (int rowIndex = 0; rowIndex < rows; rowIndex++)
        {
            SortRow(matrix, rowIndex);
        }
    }

    private void SortRow(int[,] matrix, int rowIndex)
    {
        int columns = matrix.GetLength(1);        
        int[] row = new int[columns];

        for (int i = 0; i < columns; i++)
        {
            row[i] = matrix[rowIndex, i];
        }
        BubbleSort(row);

        for (int i = 0; i < columns; i++)
        {
            matrix[rowIndex, i] = row[i];
        }
    }
    private void BubbleSort(int[] arr)
    {
        int n = arr.Length;        
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - 1 - i; j++)
            {
                if (arr[j] > arr[j + 1])
                {                    
                    int temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
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
        A = SortNegative(A);
        B = SortNegative(B);
        // create and use SortNegative(array);

        // end
    }
    public int CountNegative(int[] inputArray)
    {
        int negativeCount = 0;
        for (int i = 0; i < inputArray.Length; i++)
        {
            if (inputArray[i] < 0) negativeCount++;
        }
        return negativeCount;
        
    }
    public int[] NewArray(int[] inputArray)
    {
        int totalNegatives = CountNegative(inputArray);

        if (totalNegatives == 0) return new int[0]; 

        int[] negativeNumbers = new int[totalNegatives];

        for (int index = 0, negIndex = 0; index < inputArray.Length; index++)
        {
            if (inputArray[index] < 0) negativeNumbers[negIndex++] = inputArray[index];
        }

        return negativeNumbers;

    }
    public int[] SortNegative(int[] array)
    {
        int[] neg_array = NewArray(array);

        if (neg_array == null) { return array; }

        for (int i = 1, j = 2; i < neg_array.Length;)
        {
            if (i == 0 || neg_array[i] < neg_array[i - 1])
            {
                i = j;
                j++;
            }
            else
            {
                (neg_array[i - 1], neg_array[i]) = (neg_array[i], neg_array[i - 1]);
                i--;
            }
        }

        for (int i = 0, cout = 0; i < array.Length; i++)
        {
            if (array[i] < 0) array[i] = neg_array[cout++];
        }

        return array;
    }

    public void Task_2_17(int[,] A, int[,] B)
    {
        // code here

        // create and use SortRowsByMaxElement(matrix);

        // end
    }
    public void Task_2_18(int[,] A, int[,] B)
    {
        SortDiagonalMatrix(A);
        SortDiagonalMatrix(B);
    }
    static void SortDiagonalMatrix(int[,] matrix)
    {
        int size = matrix.GetLength(0);
        int[] diagonalElements = new int[size];
                
        for (int i = 0; i < size; i++)
        {
            diagonalElements[i] = matrix[i, i];
        }

        BubbleSort2(diagonalElements);
                
        for (int i = 0; i < size; i++)
        {
            matrix[i, i] = diagonalElements[i];
        }
    }
    static void BubbleSort2(int[] array)
    {
        int length = array.Length;
        for (int i = 0; i < length - 1; i++)
        {
            for (int j = 0; j < length - 1 - i; j++)
            {
                if (array[j] > array[j + 1])
                {
                    int temp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = temp;
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
        A = RemoveColumnsWithoutZeros(A);
        B = RemoveColumnsWithoutZeros(B);
    }
    private int[,] RemoveColumnsWithoutZeros(int[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
                
        int countColumnsToKeep = 0;

        for (int col = 0; col < cols; col++)
        {
            for (int row = 0; row < rows; row++)
            {
                if (matrix[row, col] == 0)
                {
                    countColumnsToKeep++;
                    break; 
                }
            }
        }       
        int[] columnsToKeep = new int[countColumnsToKeep];
        int index = 0;

        for (int col = 0; col < cols; col++)
        {
            for (int row = 0; row < rows; row++)
            {
                if (matrix[row, col] == 0)
                {
                    columnsToKeep[index++] = col;
                    break; 
                }
            }
        }

        int newCols = columnsToKeep.Length;
        int[,] newMatrix = new int[rows, newCols];

        for (int i = 0; i < newCols; i++)
        {
            int oldColIndex = columnsToKeep[i];
            for (int row = 0; row < rows; row++)
            {
                newMatrix[row, i] = matrix[row, oldColIndex];
            }
        }

        return newMatrix;
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

        int rowCount = matrix.GetLength(0);
        int colCount = matrix.GetLength(1);

        rows = new int[rowCount];
        cols = new int[colCount];

        for (int i = 0; i < rowCount; i++)
        {
            rows[i] = CountNegativeInRow(matrix, i);
        }

        for (int j = 0; j < colCount; j++)
        {
            cols[j] = FindMaxNegativePerColumn(matrix, j);
        }
    }
    private int CountNegativeInRow(int[,] matrix, int rowIndex)
    {
        int count = 0;

        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (matrix[rowIndex, j] < 0)
            {
                count++;
            }
        }

        return count;
    }
        
    private int FindMaxNegativePerColumn(int[,] matrix, int columnIndex)
    {
        int maxNegative = int.MinValue;
        bool hasNegative = false; 
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            if (matrix[i, columnIndex] < 0)
            {
                hasNegative = true;
                if (matrix[i, columnIndex] > maxNegative) 
                {
                    maxNegative = matrix[i, columnIndex];
                }
            }
        }

        return hasNegative ? maxNegative : 0;
    }
        public void Task_2_23(double[,] A, double[,] B)
    {
        // code here

        // create and use MatrixValuesChange(matrix);

        // end
    }

    public void Task_2_24(int[,] A, int[,] B)
    {
        int maxRowA, maxColA;
        FindMaxIndex(A, out maxRowA, out maxColA);
        SwapColumnDiagonal(A, maxColA);

        int maxRowB, maxColB;
        FindMaxIndex(B, out maxRowB, out maxColB);
        SwapColumnDiagonal(B, maxColB);
    }
        
    private void FindMaxIndex(int[,] matrix, out int row, out int column)
    {
        int maxValue = int.MinValue;
        row = -1;
        column = -1;

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] > maxValue)
                {
                    maxValue = matrix[i, j];
                    row = i;
                    column = j;
                }
            }
        }
    }
    private void SwapColumnDiagonal(int[,] matrix, int columnIndex)
    {
        int size = matrix.GetLength(0); 

        for (int i = 0; i < size; i++)
        {
            if (i < size && columnIndex < size) 
            {                
                int temp = matrix[i, columnIndex];
                matrix[i, columnIndex] = matrix[i, i];
                matrix[i, i] = temp;
            }
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
        int rowA = FindRowWithMaxNegativeCount(A);
        int rowB = FindRowWithMaxNegativeCount(B);

        if (rowA != -1 && rowB != -1)
        {            
            for (int j = 0; j < A.GetLength(1); j++)
            {                
                int temp = A[rowA, j];
                A[rowA, j] = rowB < B.GetLength(0) ? B[rowB, j] : 0; 
                B[rowB, j] = temp; 
            }
        }
    }

    private int FindRowWithMaxNegativeCount(int[,] matrix)
    {
        int maxNegCount = -1;
        int rowIdx = -1;

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            int negativeCount = CountNegativeInRow2(matrix, i);
            if (negativeCount > maxNegCount)
            {
                maxNegCount = negativeCount;
                rowIdx = i;
            }
        }
        return rowIdx;
    }
    private int CountNegativeInRow2(int[,] matrix, int row)
    {
        int count = 0;
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (matrix[row, j] < 0)
                count++;
        }
        return count;
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
        answerFirst = FindSequence(first, 0, first.Length - 1);
        answerSecond = FindSequence(second, 0, second.Length - 1);
    }
    public int FindSequence(int[] array, int start, int end)
    {
        if (start >= end) return 0; 

        bool isIncreasing = true;
        bool isDecreasing = true;

        for (int i = start; i < end; i++)
        {
            if (array[i] < array[i + 1]) 
            {
                isDecreasing = false; // Не убывающая
            }
            else if (array[i] > array[i + 1]) 
            {
                isIncreasing = false; // Не возрастающая
            }
        }

        if (isIncreasing) return 1; 
        if (isDecreasing) return -1; 
        return 0; 
    }
    public void Task_2_28b(int[] first, int[] second, ref int[,] answerFirst, ref int[,] answerSecond)
    {
        // code here
        
        answerFirst = FindAllMonotony(first);
        answerSecond = FindAllMonotony(second);
      
    }
    public int[,] FindAllMonotony(int[] array)
    {
        int k = 0;
        for (int i = 0; i < array.Length; i++)
        {
            for (int j = i + 1; j < array.Length; j++)
            {
                int ssequence = FindSequence(array, i, j);
                if (ssequence != 0) k++;
            }
        }
        int[,] answer = new int[k, 2];
        k = 0;
        for (int i = 0; i < array.Length; i++)
        {
            for (int j = i + 1; j < array.Length; j++)
            {
                int sequence = FindSequence(array, i, j);
                if (sequence != 0)
                {
                    answer[k, 0] = i;
                    answer[k, 1] = j;
                    k++;
                }
            }
        }
        return answer;
    }
    public void Task_2_28c(int[] array1, int[] array2, ref int[] resultFirst, ref int[] resultSecond)
    {        
        resultFirst = FindLogestInterval(array1);
        resultSecond = FindLogestInterval(array2);              
    }
    public int[] FindLogestInterval(int[] array)
    {
        int start1 = 0, end1 = 0;
        for (int start = 0; start < array.Length; start++)
        {
            for (int end = start + 1; end < array.Length; end++)
            {
                int sequenceValue = FindSequence(array, start, end);
                if (sequenceValue != 0 && end1 - start1 < end - start)
                {
                    start1 = start;
                    end1 = end;
                }
            }
        }
        return [start1, end1];
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

    public void Task_3_2(int[,] matrix)
    {        
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        
        for (int i = 0; i < rows; i++)
        {            
            SortRowStyle sortStyle = null;
                        
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

    // Метод сортировки по возрастанию
    private void SortAscending(int[,] matrix, int rowIndex)
    {
        int cols = matrix.GetLength(1);
        for (int j = 0; j < cols - 1; j++)
        {
            for (int k = 0; k < cols - j - 1; k++)
            {
                if (matrix[rowIndex, k] > matrix[rowIndex, k + 1])
                {                    
                    int temp = matrix[rowIndex, k];
                    matrix[rowIndex, k] = matrix[rowIndex, k + 1];
                    matrix[rowIndex, k + 1] = temp;
                }
            }
        }
    }

    // Метод сортировки по убыванию
    private void SortDescending(int[,] matrix, int rowIndex)
    {
        int cols = matrix.GetLength(1);
        for (int j = 0; j < cols - 1; j++)
        {
            for (int k = 0; k < cols - j - 1; k++)
            {
                if (matrix[rowIndex, k] < matrix[rowIndex, k + 1])
                {                    
                    int temp = matrix[rowIndex, k];
                    matrix[rowIndex, k] = matrix[rowIndex, k + 1];
                    matrix[rowIndex, k + 1] = temp;
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

    public int Task_3_4(int[,] matrix, bool isUpperTriangle)
    {
        int answer = 0;

        GetTriangle triangleMethod = isUpperTriangle ? GetUpperTriangle : GetLowerTriangle;
        int[] triangleElements = triangleMethod(matrix);
        answer = GetSum(triangleElements);
        return answer;
    }
        
    private int[] GetUpperTriangle(int[,] matrix)
    {
        int size = matrix.GetLength(0);
        int count = 0;

        for (int i = 0; i < size; i++)
        {
            for (int j = i; j < size; j++)
            {
                count++;
            }
        }

        int[] upperTriangle = new int[count];
        int index = 0;

        for (int i = 0; i < size; i++)
        {
            for (int j = i; j < size; j++)
            {
                upperTriangle[index++] = matrix[i, j];
            }
        }

        return upperTriangle;
    }

    private int[] GetLowerTriangle(int[,] matrix)
    {
        int size = matrix.GetLength(0);
        int count = 0;

        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j <= i; j++)
            {
                count++;
            }
        }

        int[] lowerTriangle = new int[count];
        int index = 0;
               
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j <= i; j++)
            {
                lowerTriangle[index++] = matrix[i, j];
            }
        }

        return lowerTriangle;
    }
        
    private int GetSum(int[] elements)
    {
        int sum = 0;
        foreach (int element in elements)
        {
            sum += element * element; 
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

    public delegate int FindElementDelegate(int[,] matrix);
        
    public void Task_3_6(int[,] matrix)
    {
        if (matrix.GetLength(0) != matrix.GetLength(1))
        {
            throw new ArgumentException("Матрица должна быть квадратной.");
        }
                
        int diagonalMaxIndex = FindDiagonalMaxIndex2(matrix);
        int firstRowMaxIndex = FindFirstRowMaxIndex(matrix);
                
        SwapColumns(matrix, diagonalMaxIndex, firstRowMaxIndex);
    }
    
    public int FindDiagonalMaxIndex2(int[,] matrix)
    {
        int maxIndex = 0;
        int maxValue = matrix[0, 0];

        for (int i = 1; i < matrix.GetLength(0); i++)
        {
            if (matrix[i, i] > maxValue)
            {
                maxValue = matrix[i, i];
                maxIndex = i;
            }
        }

        return maxIndex;
    }
        
    public int FindFirstRowMaxIndex(int[,] matrix)
    {
        int maxIndex = 0;
        int maxValue = matrix[0, 0];

        for (int j = 1; j < matrix.GetLength(1); j++)
        {
            if (matrix[0, j] > maxValue)
            {
                maxValue = matrix[0, j];
                maxIndex = j;
            }
        }

        return maxIndex;
    }

    public void SwapColumns(int[,] matrix, int col1, int col2)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {            
            int temp = matrix[i, col1];
            matrix[i, col1] = matrix[i, col2];
            matrix[i, col2] = temp;
        }
    }
        
    public void PrintMatrix(int[,] matrix)
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


public void Task_3_7(ref int[,] B, int[,] C)
    {
        // code here

        // create and use public delegate CountPositive(matrix, index);
        // use CountRowPositive(matrix, rowIndex) from Task_2_7
        // use CountColumnPositive(matrix, colIndex) from Task_2_7
        // create and use method InsertColumn(matrixB, CountRow, matrixC, CountColumn);

        // end
    }

    public delegate int FindIndexDelegate(int[,] matrix);

    // Основной метод Task_3_10
    public delegate int FindValueDelegate(int[,] matrix, int row, int col);

    public void Task_3_10(ref int[,] matrix)
    {
        if (matrix == null || matrix.GetLength(0) == 0 || matrix.GetLength(1) == 0)
        {
            throw new ArgumentException("Матрица не может быть null или пустой.");
        }

        int maxIndex = FindMaxValueIndex(matrix, (m, r, c) => c <= r);

        int minIndex = FindMinValueIndex(matrix, (m, r, c) => c > r);
                
        if (maxIndex < minIndex)
        {
            matrix = RemoveColumn(ref matrix, minIndex);
            matrix = RemoveColumn(ref matrix, maxIndex);
        }
        else if (maxIndex > minIndex)
        {
            matrix = RemoveColumn(ref matrix, maxIndex);
            matrix = RemoveColumn(ref matrix, minIndex);
        }
        else
        {
            matrix = RemoveColumn(ref matrix, maxIndex);
        }
    }

    private int FindMaxValueIndex(int[,] matrix, Func<int[,], int, int, bool> condition)
    {
        int maxValue = matrix[0, 0];
        int maxIndex = 0;

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (condition(matrix, row, col) && maxValue < matrix[row, col])
                {
                    maxValue = matrix[row, col];
                    maxIndex = col;
                }
            }
        }

        return maxIndex;
    }

    private int FindMinValueIndex(int[,] matrix, Func<int[,], int, int, bool> condition)
    {
        int minValue = matrix[0, 0];
        int minIndex = 0;

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (condition(matrix, row, col) && minValue < matrix[row, col])
                {
                    minValue = matrix[row, col];
                    minIndex = col;
                }
            }
        }

        return minIndex;
    }

    

public void Task_3_13(ref int[,] matrix)
    {
        // code here

        // use public delegate FindElementDelegate(matrix) from Task_3_6
        // create and use method RemoveRows(matrix, findMax, findMin)

        // end
    }

    public delegate int RowOperation(int[,] matrix, int index);
    public delegate int ColumnOperation(int[,] matrix, int index);

    public void Task_3_22(int[,] matrix, out int[] rows, out int[] cols)
    {
        int rowCount = matrix.GetLength(0);
        int colCount = matrix.GetLength(1);

        rows = new int[rowCount];
        cols = new int[colCount];

        // Используем делегаты для обработки строк
        RowOperation countNegativeInRow = CountNegativeInRow;
        for (int i = 0; i < rowCount; i++)
        {
            rows[i] = countNegativeInRow(matrix, i);
        }

        // Используем делегаты для обработки столбцов
        ColumnOperation findMaxNegativePerColumn = FindMaxNegativePerColumn;
        for (int j = 0; j < colCount; j++)
        {
            cols[j] = findMaxNegativePerColumn(matrix, j);
        }
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

    public delegate int SequenceCheck(int[] array, int start, int end);

    public void Task_3_28a(int[] first, int[] second, ref int answerFirst, ref int answerSecond)
    {        
        SequenceCheck checkSequence = FindSequence;
        answerFirst = checkSequence(first, 0, first.Length - 1);
        answerSecond = checkSequence(second, 0, second.Length - 1);
    }
      
    public delegate int[] SequenceFinder(int[] array);

    // public delegate int SequenceFinder(int[] array, int start, int end);

    public void Task_3_28c(int[] first, int[] second, ref int[] answerFirstIncrease, ref int[] answerFirstDecrease, ref int[] answerSecondIncrease, ref int[] answerSecondDecrease)
    {
        // code here

        // create public delegate IsSequence(array, left, right);
        // use method FindIncreasingSequence(array, A, B); from Task_3_28a
        // use method FindDecreasingSequence(array, A, B); from Task_3_28a
        // create and use method FindLongestSequence(array, sequence);

        answerFirstIncrease = FindLongestSequence(first, FindIncreasingSequence);
        answerFirstDecrease = FindLongestSequence(first, FindDecreasingSequence);
        answerSecondIncrease = FindLongestSequence(second, FindIncreasingSequence);
        answerSecondDecrease = FindLongestSequence(second, FindDecreasingSequence);

        // end
    }
    public delegate bool IsSequence(int[] array,int left,int right);
    public bool FindIncreasingSequence(int[] array, int A, int B)
    {
        return FindSequence(array, A, B) == 1;
    }
    public bool FindDecreasingSequence(int[] array, int A, int B)
    {
        return FindSequence(array, A, B) == -1;
    }

    public int[] FindLongestSequence(int[] array, IsSequence sequence)
    {
        int left = 0, right = 0;
        for (int i = 0; i < array.Length; i++)
            for (int j = i + 1; j < array.Length; j++)
                if (sequence(array, i, j) && j - i > right - left)
                {
                    left = i; right = j;
                }
        return [left, right];
    }

    #endregion
    #region bonus part
    public double[,] Task_4(double[,] matrix, int index)
    {
        return matrix;
    }
    #endregion
}



   