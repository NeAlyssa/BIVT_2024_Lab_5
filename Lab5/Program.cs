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



       // int[,] matrix = { };
    }
    #region Level 1

    public static int Factorial(int n)
    {
        if (n <= 1) return 1;
        return n * Factorial(n - 1);
    }
    public long Combinations(int n, int k)
    {
        if (k > n || n < 0 || k < 0)
        {
            return 0;
        }
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
        if (a <= 0 || b <= 0 || c <= 0) { return -1; }
        if (a + b <= c || a + c <= b || b + c <= a) { return -1; }

        double p = (a + b + c) / 2;

        return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
    }

    public int Task_1_2(double[] first, double[] second)
    {
        int answer = 0;

        double s1 = GeronArea(first[0], first[1], first[2]);
        double s2 = GeronArea(second[0], second[1], second[2]);

        if (s1 == -1 || s2 == -1) { answer = -1; }
        else if (s1 > s2) { answer = 1; }
        else if (s1 < s2) { answer = 2; }
        else { answer = 0;  }

        return answer;
    }





    public double GetDistance(double v, double a, int t)
    {
        if (v < 0 || a < 0 || t < 0) { return -1; }
        return v * t + (a * t * t / 2);
    }

    public int Task_1_3a(double v1, double a1, double v2, double a2, int time)
    {
        int answer = 0;

        double s1 = GetDistance(v1, a1, time);
        double s2 = GetDistance(v2, a2, time);
        
        if (s1 == -1 || s2 == -1) { answer = -1; }
        else if (s1 > s2) { answer = 1; }
        else if (s1 < s2) { answer = 2; }
        else { answer = 0; }

        return answer;
    }

    public int Task_1_3b(double v1, double a1, double v2, double a2)
    {
        int answer = 0;
        int time = 1;

        while (true)
        {
            double s1 = GetDistance(v1, a1, time);
            double s2 = GetDistance(v2, a2, time);

            if (s2 >= s1)
            {
                answer = time;
                break;
            }
            else time++;
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
        int indexMax = 0;
        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] > array[indexMax]) { indexMax = i; }
        }

        return indexMax;
    }

    public double avgAfterMax(double[] numbers, int maxIndex)
    {
        double sum = 0;
        int count = 0;

        for (int index = maxIndex + 1; index < numbers.Length; index++)
        {
            sum += numbers[index];
            count++;
        }

        if (count != 0) return sum / count;
        else return 0;
    }


    public void Task_2_2(double[] A, double[] B)
    {
        int indexMaxA = FindMaxIndex(A);
        int indexMaxB = FindMaxIndex(B);

        if (A.Length - indexMaxA > B.Length - indexMaxB)
        {
            A[indexMaxA] = avgAfterMax(A, indexMaxA);
        }
        else
        {
            B[indexMaxB] = avgAfterMax(B, indexMaxB);
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
        int indexMax = 0;

        for (int i = 1; i < matrix.GetLength(0); i++)
        {
            if (matrix[i, i] > matrix[indexMax, indexMax]) { indexMax = i; }
        }
        return indexMax;
    }




    public void Task_2_4(int[,] A, int[,] B)
    {
        int indexMaxA = FindDiagonalMaxIndex(A);
        int indexMaxB = FindDiagonalMaxIndex(B);

        for (int i = 0; i < 5; i++)
        {
            int temp = A[indexMaxA, i];
            A[indexMaxA, i] = B[i, indexMaxB];
            B[i, indexMaxB] = temp;
        }

    }

    public void Task_2_5(int[,] A, int[,] B)
    {
        // code here

        // create and use FindMaxInColumn(matrix, columnIndex, out rowIndex);

        // end
    }




    public int FindMax(int[] arr) // такой метод есть, но он работает только с double[]
    {
        int indexMax = 0;

        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i] > arr[indexMax]) { indexMax = i; }
        }

        return indexMax;
    }

    public int[] DeleteElement(int[] array, int index)
    {
        int[] temp = new int[array.Length - 1];

        for (int i = 0, k = 0; i < array.Length; i++)
        {
            if (i == index) continue;
            temp[k++] = array[i];
        }

        return temp;
    }

    public void Task_2_6(ref int[] A, int[] B)
    {
        A = DeleteElement(A, FindMax(A));
        B = DeleteElement(B, FindMax(B));
        int[] C = new int[A.Length + B.Length];

        for (int i = 0, j = 0, k = 0; i < C.Length; i++)
        {
            if (j < A.Length) C[i] = A[j++];
            else C[i] = B[k++];
        }

        A = C;
    }


    public void Task_2_7(ref int[,] B, int[,] C)
    {
        // code here

        // create and use CountRowPositive(matrix, rowIndex);
        // create and use CountColumnPositive(matrix, colIndex);

        // end
    }






    public void SortArrayPart(int[] array, int startIndex)
    {
        for (int i = startIndex + 1, j = startIndex + 2; i < array.Length;)
        {
            if (i == startIndex || array[i - 1] < array[i])
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


    public void Task_2_8(int[] A, int[] B)
    {
        SortArrayPart(A, FindMax(A) + 1);
        SortArrayPart(B, FindMax(B) + 1);
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
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        int[,] result = new int[rows, cols - 1];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0, newCol = 0; j < cols; j++)
            {
                if (j == columnIndex) continue;
                result[i, newCol++] = matrix[i, j];
            }
        }
        return result;
    }
    public int MaxIndexBelowDiag(int[,] matrix)
    {
        int maxRow = 1, maxCol = 0;
        for (int i = 1; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j <= i; j++)
            {
                if (matrix[i, j] > matrix[maxRow, maxCol])
                {
                    (maxRow, maxCol) = (i, j);
                }
            }
        }
        return maxCol;
    }
    public int MinIndexAboveDiag(int[,] matrix)
    {
        int minRow = 0, minCol = 1;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = i + 1; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] < matrix[minRow, minCol])
                {
                    (minRow, minCol) = (i, j);
                }
            }
        }
        return minCol;
    }


    public void Task_2_10(ref int[,] matrix)
    {
        int maxBelowIndex = MaxIndexBelowDiag(matrix);
        int minAboveIndex = MinIndexAboveDiag(matrix);

        if (maxBelowIndex == minAboveIndex)
        {
            matrix = RemoveColumn(matrix, maxBelowIndex);
        }
        else if (minAboveIndex > maxBelowIndex)
        {
            matrix = RemoveColumn(matrix, minAboveIndex);
            matrix = RemoveColumn(matrix, maxBelowIndex);
        }
        else
        {
            matrix = RemoveColumn(matrix, maxBelowIndex);
            matrix = RemoveColumn(matrix, minAboveIndex);
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
        int indexMaxCol = 0, iMaxRow = 0;

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] > matrix[iMaxRow, indexMaxCol]) { 
                    (iMaxRow, indexMaxCol) = (i, j);
                    //Console.WriteLine(i);
                }
            }
        }

        return indexMaxCol;
    }
    public void Task_2_12(int[,] A, int[,] B)
    {
        int indexMaxColA = FindMaxColumnIndex(A);
        int indexMaxColB = FindMaxColumnIndex(B);

        for (int i = 0; i < A.GetLength(0); i++)
        {
            (A[i, indexMaxColA], B[i, indexMaxColB]) = (B[i, indexMaxColB], A[i, indexMaxColA]);
        }
    }

    public void Task_2_13(ref int[,] matrix)
    {
        // code here

        // create and use RemoveRow(matrix, rowIndex);

        // end
    }



    public void SortRow(int[,] matrix, int rowIndex)
    {
        for (int i = 1, j = 2; i < matrix.GetLength(1);)
        {
            if (i == 0 || matrix[rowIndex, i - 1] < matrix[rowIndex, i])
            {
                i = j;
                j++;
            }
            else
            {
                int temp = matrix[rowIndex, i - 1];
                matrix[rowIndex, i - 1] = matrix[rowIndex, i];
                matrix[rowIndex, i] = temp;
                i--;
            }
        }
    }

    public void Task_2_14(int[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            SortRow(matrix, i);
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
        int count = 0;

        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] < 0)
            {
                count++;
            }
        }

        int[] negatives = new int[count];
        int index = 0;

        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] < 0)
            {
                negatives[index++] = array[i];
            }
        }

        for (int i = 0; i < negatives.Length;)
        {
            if (i == 0 || negatives[i - 1] >= negatives[i])
            {
                i++;
            }
            else
            {
                int temp = negatives[i - 1];
                negatives[i - 1] = negatives[i];
                negatives[i] = temp;
                i--;
            }
        }

        index = 0;
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] < 0)
            {
                array[i] = negatives[index++];
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



        if (matrix == null) return null;

        for (int i = 1, j = 2; i < matrix.GetLength(0);)
        {
            if (i == 0 || matrix[i - 1, i - 1] < matrix[i, i])
            {
                i = j;
                j++;
            }
            else
            {
                int temp = matrix[i - 1, i - 1];
                matrix[i - 1, i - 1] = matrix[i, i];
                matrix[i, i] = temp;
                i--;
            }
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



    public int[,] RemoveColumns(int[,] matrix)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            int counterZero = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, j] == 0) counterZero++;
            }

            if (counterZero == 0)
            {
                matrix = RemoveColumn(matrix, j);
                j--;
            }
        }

        return matrix;
    }

    public void Task_2_20(ref int[,] A, ref int[,] B)
    {
        A = RemoveColumns(A);
        B = RemoveColumns(B);
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

    public int FindMaxNegativePerColumn(int[,] matrix, int colIndex)
    {
        int rowIndex = -1;

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            if (matrix[i, colIndex] < 0)
            {
                if (rowIndex == -1 || matrix[i, colIndex] > matrix[rowIndex, colIndex])
                {
                    rowIndex = i;
                }
            }
        }
        if (rowIndex == -1)
        {
            return 0;
        }

        return matrix[rowIndex, colIndex];
    }

    public void Task_2_22(int[,] matrix, out int[] rows, out int[] cols)
    {
        rows = new int[matrix.GetLength(0)];
        cols = new int[matrix.GetLength(1)];

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            rows[i] = CountNegativeInRow(matrix, i);
        }

        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            cols[j] = FindMaxNegativePerColumn(matrix, j);
        }
    }

    public void Task_2_23(double[,] A, double[,] B)
    {
        // code here

        // create and use MatrixValuesChange(matrix);

        // end
    }



    public void SwapColumnDiagonal(int[,] matrix, int columnIndex)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            int temp = matrix[i, columnIndex];
            matrix[i, columnIndex] = matrix[i, i];
            matrix[i, i] = temp;
        }
    }

    public void Task_2_24(int[,] A, int[,] B)
    {

        SwapColumnDiagonal(A, FindMaxColumnIndex(A));
        SwapColumnDiagonal(B, FindMaxColumnIndex(B));
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
        int[] count = new int[matrix.GetLength(0)];
        int indexMaxNegRow = 0;

        for (int i = 0; i < count.Length; i++)
        {
            count[i] = CountNegativeInRow(matrix, i);
        }

        for (int i = 1; i < count.Length; i++)
        {
            if (count[i] > count[indexMaxNegRow])
            {
                indexMaxNegRow = i;
            }
        }

        return indexMaxNegRow;
    }

    public void SwapRows(int[,] A, int rowA, int[,] B, int rowB)
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
        int maxNegRowA = FindRowWithMaxNegativeCount(A);
        int maxNegRowB = FindRowWithMaxNegativeCount(B);

        SwapRows(A, maxNegRowA, B, maxNegRowB);
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
        int dec = 0;
        int inc = 0;

        for (int i = A; i < B; i++)
        {
            if (array[i + 1] > array[i])
            {
                inc++;
            }
            else if (array[i] > array[i + 1])
            {
                dec++;
            }
        }

        if (dec > 0 && inc > 0) return 0;
        if (inc > 0) return 1;
        return -1;
    }

    public void Task_2_28a(int[] first, int[] second, ref int answerFirst, ref int answerSecond)
    {
        answerFirst = FindSequence(first, 0, first.Length - 1);
        answerSecond = FindSequence(second, 0, second.Length - 1);
    }


    public int[,] FindAllIntervals(int[] array)
    {
        int count = 0;

        for (int i = 0; i < array.Length; i++)
        {
            for (int j = i + 1; j < array.Length; j++)
            {
                if (FindSequence(array, i, j) != 0) count++;
            }
        }

        int[,] intervals = new int[count, 2];
        int index = 0;

        for (int i = 0; i < array.Length; i++)
        {
            for (int j = i + 1; j < array.Length; j++)
            {
                if (FindSequence(array, i, j) != 0)
                {
                    intervals[index, 0] = i;
                    intervals[index, 1] = j;
                    index++;
                }
            }
        }

        return intervals;
    }

    public void Task_2_28b(int[] first, int[] second, ref int[,] answerFirst, ref int[,] answerSecond)
    {
        answerFirst = FindAllIntervals(first);
        answerSecond = FindAllIntervals(second);
    }





    public int[] FindTheLongestInterval(int[] array)
    {
        int[] result = new int[] { 0, 1 };

        for (int i = 0; i < array.Length; i++)
        {
            for (int j = i + 1; j < array.Length; j++)
            {
                if (FindSequence(array, i, j) != 0)
                {
                    if (j - i > result[1] - result[0])
                    {
                        result[0] = i;
                        result[1] = j;
                    }
                }
            }
        }

        return result;
    }

    public void Task_2_28c(int[] first, int[] second, ref int[] answerFirst, ref int[] answerSecond)
    {
        answerFirst = FindTheLongestInterval(first);
        answerSecond = FindTheLongestInterval(second);
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

    void SortAscending(int[,] matrix, int row)
    {
        int m = matrix.GetLength(1);
        for (int i = 0; i < m - 1; i++)
        {
            for (int j = 0; j < m - 1 - i; j++)
            {
                if (matrix[row, j] > matrix[row, j + 1])
                {
                    int temp = matrix[row, j];
                    matrix[row, j] = matrix[row, j + 1];
                    matrix[row, j + 1] = temp;
                }
            }
        }
    }

    void SortDescending(int[,] matrix, int row)
    {
        int m = matrix.GetLength(1);
        for (int i = 0; i < m - 1; i++)
        {
            for (int j = 0; j < m - 1 - i; j++)
            {
                if (matrix[row, j] < matrix[row, j + 1])
                {
                    int temp = matrix[row, j];
                    matrix[row, j] = matrix[row, j + 1];
                    matrix[row, j + 1] = temp;
                }
            }
        }
    }

    public void Task_3_2(int[,] matrix)
    {
        SortRowStyle sortStyle;
        int n = matrix.GetLength(0);
        for (int i = 0; i < n; i++)
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




    public delegate int[] GetTriangle(int[,] matrix);
    int[] GetUpperTriangle(int[,] matrix)
    {
        int n = matrix.GetLength(0);
        int k = 0;

        for (int i = 0; i < n; i++)
        {
            k += (n - i);
        }

        int[] A = new int[k];
        k = 0;

        for (int i = 0; i < n; i++)
        {
            for (int j = i; j < n; j++)
            {
                A[k++] = matrix[i, j];
            }
        }

        return A;
    }

    int[] GetLowerTriangle(int[,] matrix)
    {
        int n = matrix.GetLength(0);
        int k = 0;

        for (int i = 0; i < n; i++)
        {
            k += (i + 1);
        }

        int[] A = new int[k];
        k = 0;

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j <= i; j++)
            {
                A[k++] = matrix[i, j];
            }
        }

        return A;
    }


    int GetSum(GetTriangle triangle, int[,] matrix)
    {
        int[] arr = triangle(matrix);
        int sum = 0;

        for (int i = 0; i < arr.Length; i++)
        {
            sum += arr[i] * arr[i];
        }

        return sum;
    }


    public int Task_3_4(int[,] matrix, bool isUpperTriangle)
    {
        int answer = 0;

        GetTriangle triangle = default(GetTriangle);
        if (isUpperTriangle) triangle = GetUpperTriangle;
        else triangle = GetLowerTriangle;
        answer = GetSum(triangle, matrix);

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
        int n = matrix.GetLength(1);
        int jmax = 0;

        for (int j = 1; j < n; j++)
        {
            if (matrix[0, j] > matrix[0, jmax])
            {
                jmax = j;
            }
        }

        return jmax;
    }
    int[,] SwapColumns(int[,] matrix, FindElementDelegate diagonal, FindElementDelegate firstRow)
    {
        int n = matrix.GetLength(0);
        int[] temp = new int[n];
        int j1 = diagonal(matrix);
        int j2 = firstRow(matrix);

        for (int i = 0; i < n; i++)
        {
            temp[i] = matrix[i, j1];
        }

        for (int i = 0; i < n; i++)
        {
            matrix[i, j1] = matrix[i, j2];
            matrix[i, j2] = temp[i];
        }

        return matrix;
    }


    public void Task_3_6(int[,] matrix)
    {
        FindElementDelegate diagonal = default(FindElementDelegate);
        FindElementDelegate FirstRow = default(FindElementDelegate);
        diagonal = FindDiagonalMaxIndex;
        FirstRow = FindFirstRowMaxIndex;
        matrix = SwapColumns(matrix, diagonal, FirstRow);

    }



    public delegate int CountPositive(int[,] matrix, int index);
    public void InsertColumn(ref int[,] matrixB, int countRow, int[,] matrixC, int countColumn)
    {
        int rowsB = matrixB.GetLength(0), colsB = matrixB.GetLength(1);
        int[,] newB = new int[rowsB + 1, colsB];

        for (int j = 0; j < colsB; j++)
        {
            newB[countRow + 1, j] = matrixC[j, countColumn];
        }

        for (int i = 0; i < rowsB; i++)
        {
            for (int j = 0; j < colsB; j++)
            {
                newB[i <= countRow ? i : i + 1, j] = matrixB[i, j];
            }
        }

        matrixB = newB;
    }

    public void Task_3_7(ref int[,] B, int[,] C)
    {

    }
    



    public delegate int FindIndex(int[,] matr);
    int FindMaxBelowDiagonalIndex(int[,] matrix)
    {
        int n = matrix.GetLength(0);
        int imax = 0, jmax = 0;

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j <= i; j++)
            {
                if (matrix[i, j] > matrix[imax, jmax])
                {
                    imax = i;
                    jmax = j;
                }
            }
        }

        return jmax;
    }

    int FindMinAboveDiagonalIndex(int[,] matrix)
    {
        int n = matrix.GetLength(0);
        int imin = 0, jmin = 1;

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (j > i && (i == 0 && j == 1 || matrix[i, j] < matrix[imin, jmin]))
                {
                    imin = i;
                    jmin = j;
                }
            }
        }

        return jmin;
    }
    void RemoveColumns(ref int[,] matrix, FindIndex below, FindIndex above)
    {
        int a = below(matrix);
        int b = above(matrix);
        int j1 = Math.Min(a, b);
        int j2 = Math.Max(a, b);

        matrix = RemoveColumn(matrix, j2);
        if (j1 != j2)
        {
            matrix = RemoveColumn(matrix, j1);
        }
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


    public delegate int[] GetNegativeArray(int[,] matr);
    int[] GetNegativeCountPerRow(int[,] matrix)
    {
        int[] counts = new int[matrix.GetLength(0)];

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            counts[i] = CountNegativeInRow(matrix, i);
        }

        return counts;
    }
    int[] FindMaxNegativePerColumn(int[,] matrix)
    {
        int n = matrix.GetLength(0);
        int m = matrix.GetLength(1);
        int[] maxNegatives = new int[m];

        for (int j = 0; j < m; j++)
        {
            int nmax = int.MinValue;
            bool hasNegative = false; 

            for (int i = 0; i < n; i++)
            {
                if (matrix[i, j] < 0)
                {
                    hasNegative = true;
                    if (matrix[i, j] > nmax)
                    {
                        nmax = matrix[i, j];
                    }
                }
            }

            maxNegatives[j] = hasNegative ? nmax : 0; 
        }

        return maxNegatives;
    }

    void FindNegatives(int[,] matrix, GetNegativeArray searcherRows, GetNegativeArray searcherCols, out int[] rows, out int[] cols)
    {
        rows = searcherRows(matrix);
        cols = searcherCols(matrix);
    }

    public void Task_3_22(int[,] matrix, out int[] rows, out int[] cols)
    {

        rows = null;
        cols = null;
        FindNegatives(matrix, GetNegativeCountPerRow, FindMaxNegativePerColumn, out rows, out cols);
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

    public void Task_3_28a(int[] first, int[] second, ref int answerFirst, ref int answerSecond)
    {
        answerFirst = DefineSequence(first, FindIncreasingSequence, FindDecreasingSequence);
        answerSecond = DefineSequence(second, FindIncreasingSequence, FindDecreasingSequence);
    }
    int[] FindLongestSequence(int[] array, IsSequence sequence)
    {
        int start = 0, end = 0;

        for (int i = 0; i < array.Length; i++)
        {
            for (int j = i + 1; j < array.Length; j++)
            {
                if (sequence(array, i, j) && (j - i > end - start))
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
        answerFirstIncrease = FindLongestSequence(first, FindIncreasingSequence);
        answerFirstDecrease = FindLongestSequence(first, FindDecreasingSequence);
        answerSecondIncrease = FindLongestSequence(second, FindIncreasingSequence);
        answerSecondDecrease = FindLongestSequence(second, FindDecreasingSequence);
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
