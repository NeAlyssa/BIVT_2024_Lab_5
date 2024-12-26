using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
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

        double[,] answerA = new double[5, 5] {
            { -4, 12, 3, 4, 5 },
            { 6, 0, 8, 9, 10 },
            { 0, 12, 1, 14, 15 },
            { -1, -2, -3, 7, -5 },
            { 6, 7, 8, 9, 13 }};

        int[] array = { 2, 4, 0, 5, 5, 8, 7, 7, 9, 6, 10,0, 10, 8, 12, 11, 13 };

        //program.Task_2_28b(answerA, answerA, );
    }
    public static void PrintArray(int[] arr)
    {
        for(int i = 0; i < arr.Length; i++)
        {
            Console.Write(arr[i] + " ");
        }
        Console.WriteLine();
    }
    public static void PrintMatrix(int[,] matrix)
    {
        for(int i = 0;i < matrix.GetLength(0);i++)
        {
            for(int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
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
    public static int Combinations(int n,int k)
    {
        if (k > n || n < 0 || k < 0) return 0;
        return Factorial(n) / (Factorial(k) * Factorial(n - k));
    }
    public static int Factorial(int n)
    {
        if (n <= 1) return 1;
        return n * Factorial(n - 1);
    }
    public int Task_1_2(double[] first, double[] second)
    {
        int answer = 0;
        double s_first, s_second;
        // code here

        // create and use GeronArea(a, b, c);
        if (first == null || second == null) return -1;

        s_first = GeronArea(first[0], first[1], first[2]);
        s_second = GeronArea(second[0], second[1], second[2]);

        if (s_second == -1 || s_first == -1) answer = -1;
        else if (s_first > s_second) answer = 1;
        else if (s_first == s_second) answer = 0;
        else answer = 2;
        // end

        // first = 1, second = 2, equal = 0, error = -1
        return answer;
    }
    public static double GeronArea(double a, double b, double c)
    {
        if (a <= 0 || b <= 0 || c <= 0) return -1;
        if (a + b <= c || a + c <= b || b + c <= a) return -1;
        double p = (a + b + c) / 2;
        return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
    }
    public int Task_1_3a(double v1, double a1, double v2, double a2, int time)
    {
        int answer = 0;
        double s_first, s_second;
        // code here

        // create and use GetDistance(v, a, t); t - hours

        s_first = GetDistance(v1, a1, time);
        s_second = GetDistance(v2, a2, time);


        if (s_first == -1 || s_second == -1) answer = -1;
        else if (s_first > s_second) answer = 1;
        else if (s_first < s_second) answer = 2;
        else answer = 0;
        // end

        // first = 1, second = 2, equal = 0
        return answer;
    }
    public static double GetDistance(double v,double a,int t)
    {
        if (v < 0 || a < 0 || t < 0) return -1;
        return v * t + a * t * t / 2;
    }
    public int Task_1_3b(double v1, double a1, double v2, double a2)
    {
        int answer = 0, time = 1;
        double s_first, s_second;
        // code here

        // use GetDistance(v, a, t); t - hours

        while(true)
        {
            s_first = GetDistance(v1, a1, time);
            s_second = GetDistance(v2, a2, time);

            if (s_second >= s_first)
            {
                answer = time;
                break;
            }
            else time++;
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

        // create and use FindMaxIndex(array);
        // only 1 array has to be changed!

        int indexMaxA = FindMaxIndex(A);
        int indexMaxB = FindMaxIndex(B);

        if(A.Length - indexMaxA > B.Length - indexMaxB)
        {
             A[indexMaxA] = AverageAfterMax(A, indexMaxA);
        }
        else
        {
            B[indexMaxB] = AverageAfterMax(B, indexMaxB);
        }
        // end
    }
    public static int FindMaxIndex(double[] array)
    {
        int iMax = 0;

        for(int i = 1; i < array.Length; i++)
        {
            if (array[i] > array[iMax]) iMax = i;
        }

        return iMax;
    }
    public static double AverageAfterMax(double[] arr,int iMax)
    {
        double avr = 0;
        int amount = 0;
        for(int i = iMax + 1; i < arr.Length; i++)
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

        //  create and use method FindDiagonalMaxIndex(matrix); like in Task_2_3

        int indexMaxA = FindDiagonalMaxIndex(A);
        int indexMaxB = FindDiagonalMaxIndex(B);

        for(int i = 0; i < 5; i++)
        {
            (A[indexMaxA, i], B[i, indexMaxB]) = (B[i, indexMaxB], A[indexMaxA, i]);
        }

        // end
    }
    public static int FindDiagonalMaxIndex(int[,] matrix)
    {
        int iMax = 0;

        for(int i = 1; i < matrix.GetLength(0); i++)
        {
            if (matrix[i, i] > matrix[iMax, iMax]) iMax = i;
        }
        return iMax;
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

        // create and use FindMax(array); like in Task_2_1
        // create and use DeleteElement(array, index);

        int iMaxA = FindMax(A);
        int iMaxB = FindMax(B);

        A = DeleteElement(A, iMaxA);
        B = DeleteElement(B, iMaxB);
        
        int[] C = new int[A.Length + B.Length];

        for(int i = 0, k = 0, l = 0; i < C.Length; i++)
        {
            if(k < A.Length) C[i] = A[k++];
            else C[i] = B[l++];
        }

        A = C;
        // end
    }
    public static int FindMax(int[] arr)
    {
        int iMax = 0;

        for(int i = 1; i < arr.Length; i++)
        {
            if (arr[i] > arr[iMax]) iMax = i;
        }

        return iMax;
    }
    public static int[] DeleteElement(int[] array, int index)
    {
        int[] tmp = new int[array.Length - 1]; 

        for(int i = 0, k = 0; i < array.Length; i++)
        {
            if (i == index) continue;
            tmp[k++] = array[i];
        }

        return tmp;
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

        // create and use SortArrayPart(array, startIndex);
        int indexMaxA = FindMax(A);
        int indexMaxB = FindMax(B);

        SortArrayPart(A, indexMaxA + 1);
        SortArrayPart(B, indexMaxB + 1);

        // end
    }
    public static void SortArrayPart(int[] array,int startIndex)
    {
        for(int i = startIndex + 1, j = startIndex + 2; i < array.Length; )
        {
            if(i == startIndex || array[i - 1] < array[i])
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

        // create and use RemoveColumn(matrix, columnIndex);
        
        int iMaxBelow = FindMaxIndexBelowDiagonal(matrix);
        int iMinAbove = FindMinIndexAboveDiagonal(matrix);

        if(iMaxBelow == iMinAbove)
        {
            matrix = RemoveColumn(matrix, iMaxBelow);
        }
        else if (iMinAbove > iMaxBelow)
        {
            matrix = RemoveColumn(matrix, iMinAbove);
            matrix = RemoveColumn(matrix, iMaxBelow);
        }
        else
        {
            matrix = RemoveColumn(matrix, iMaxBelow);
            matrix = RemoveColumn(matrix, iMinAbove);
        }

        // end
    }
    public static int FindMaxIndexBelowDiagonal(int[,] matrix)
    {
        int indexMaxRow = 0, indexMaxCol = 0;
        for(int i = 1; i < matrix.GetLength(0); i++)
        {
            for(int j = 0; j <= i; j++)
            {
                if (matrix[i, j] > matrix[indexMaxRow, indexMaxCol])
                {
                    (indexMaxRow, indexMaxCol) = (i, j);
                }
            }
        }
        return indexMaxCol;
    }
    public static int FindMinIndexAboveDiagonal(int[,] matrix)
    {
        int indexMinRow = 0, indexMinCol = 1;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 1 + i; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] < matrix[indexMinRow, indexMinCol])
                {
                    (indexMinRow, indexMinCol) = (i, j);
                }
            }
        }
        return indexMinCol;
    }
    public static int[,] RemoveColumn(int[,] matrix,int columnIndex)
    {
        int[,] newMatrix = new int[matrix.GetLength(0), matrix.GetLength(1) - 1];

        for(int j = 0, k = 0; j < matrix.GetLength(1); j++, k++)
        {
            for(int i = 0; i < matrix.GetLength(0); i++)
            {
                if (j == columnIndex)
                {
                    k--;
                    break;
                }
                newMatrix[i, k] = matrix[i, j];
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
        int iMaxColA = FindMaxColumnIndex(A);
        int iMaxColB = FindMaxColumnIndex(B);

        for(int i = 0; i < A.GetLength(0); i++)
        {
            (A[i, iMaxColA], B[i, iMaxColB]) = (B[i, iMaxColB], A[i, iMaxColA]);
        }

        // end
    }
    public static int FindMaxColumnIndex(int[,] matrix)
    {
        int iMaxCol = 0, iMaxRow = 0;
        
        for(int i = 0; i < matrix.GetLength(0); i++)
        {
            for(int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] > matrix[iMaxRow, iMaxCol])
                    (iMaxRow, iMaxCol) = (i, j);
            }
        }

        return iMaxCol;
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

        for(int i = 0; i < matrix.GetLength(0); i++)
        {
            SortRow(matrix, i);
        }

        // end
    }
    public static void SortRow(int[,] matrix,int rowIndex)
    {
        for(int i = 1, j = 2; i < matrix.GetLength(1); )
        {
            if(i == 0 || matrix[rowIndex, i - 1] < matrix[rowIndex, i])
            {
                i = j;
                j++;
            }
            else
            {
                (matrix[rowIndex, i - 1], matrix[rowIndex, i]) = (matrix[rowIndex, i], matrix[rowIndex, i - 1]);
                i--;
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

        A = SortNegative(A);
        B = SortNegative(B);
        
        // end
    }
    public static int CounterNegative(int[] array)
    {
        int counter = 0; ;
        foreach(int item in array)
        {
            if (item < 0) counter++;
        }
        return counter;
    } 
    public static int[] CreateNegativeArray(int[] array)
    {
        int amountNeg = CounterNegative(array);

        int[] negArray = new int[amountNeg];

        if (amountNeg == 0) return null;

        for(int i = 0, k = 0; i < array.Length; i++)
        {
            if (array[i] < 0) negArray[k++] = array[i];
        }

        return negArray;
    }
    public static int[] SortNegative(int[] array)
    {
        int[] negArray = CreateNegativeArray(array);

        if(negArray == null) return array;

        for (int i = 1, j = 2; i < negArray.Length; )
        {
            if(i == 0 || negArray[i - 1] > negArray[i])
            {
                i = j;
                j++;
            }
            else
            {
                (negArray[i - 1], negArray[i]) = (negArray[i], negArray[i - 1]);
                i--;
            }
        }

        for(int i = 0, k = 0; i < array.Length; i++)
        {
            if (array[i] < 0) array[i] = negArray[k++];
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
        // code here

        // create and use SortDiagonal(matrix);

        A = SortDiagonal(A);
        B = SortDiagonal(B);
        // end
    }
    public static int[,] SortDiagonal(int[,] matrix)
    {
        if (matrix == null) return null;

        for(int i = 1, j = 2; i < matrix.GetLength(0); )
        {
            if(i == 0 || matrix[i - 1, i - 1] < matrix[i, i])
            {
                i = j;
                j++;
            }
            else
            {
                (matrix[i - 1, i - 1], matrix[i, i]) = (matrix[i, i], matrix[i - 1, i - 1]);
                i--;
            }
        }
        return matrix;
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

       A = RemoveAllColumns(A);
       B = RemoveAllColumns(B);

        // end
    }
    public static int[,] RemoveAllColumns(int[,] matrix)
    {
        for (int j = 0, counterZero = 0; j < matrix.GetLength(1); j++, counterZero = 0)
        {
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

        // code here

        // create and use CountNegativeInRow(matrix, rowIndex);
        // create and use FindMaxNegativePerColumn(matrix, colIndex);

        for(int i = 0; i < matrix.GetLength(0); i++)
        {
                rows[i] = CountNegativeInRow(matrix, i);
        }

        for(int j = 0; j < matrix.GetLength(1); j++)
        {
            cols[j] = FindMaxNegativePerColumn(matrix, j);
        }

        // end
    }
    public static int CountNegativeInRow(int[,] matrix,int rowIndex)
    {
        int counterNeg = 0;

        for(int j = 0; j < matrix.GetLength(1); j++)
        {
            if (matrix[rowIndex, j] < 0) counterNeg++;
        }
        
        return counterNeg;
    }
    public static int FindMaxNegativePerColumn(int[,] matrix, int colIndex)
    {
        int rowIndex = -1;
             
        for(int i = 0, firstTry = 0; i < matrix.GetLength(0); i++)
        {
            if (matrix[i, colIndex] < 0 && firstTry == 0)
            {
                rowIndex = i;
                firstTry++;
            }
            if (matrix[i, colIndex] < 0 && firstTry != 0 && matrix[i, colIndex] > matrix[rowIndex, colIndex])
                rowIndex = i;
        }

        if (rowIndex == -1) return 0;
        else return matrix[rowIndex, colIndex];
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

        // use FindMaxIndex(matrix, out row, out column)
        // create and use SwapColumnDiagonal(matrix, columnIndex);

        int iMaxColA = FindMaxColumnIndex(A);
        int iMaxColB = FindMaxColumnIndex(B);

        SwapColumnDiagonal(A, iMaxColA);
        SwapColumnDiagonal(B, iMaxColB);

        // end
    }
    public static void SwapColumnDiagonal(int[,] matrix,int columnIndex)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            (matrix[i, columnIndex], matrix[i, i]) = (matrix[i, i], matrix[i, columnIndex]);
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

        int maxNegRowA = FindRowWithMaxNegativeCount(A);
        int maxNegRowB = FindRowWithMaxNegativeCount(B);

        SwapRowsMatrixs(A, maxNegRowA, B, maxNegRowB);


        // end
    }
    public static int FindRowWithMaxNegativeCount(int[,] matrix)
    {
        int[] countNeg = new int[matrix.GetLength(0)];
        int indexMaxNegRow = 0;

        for(int i = 0; i < countNeg.GetLength(0); i++)
        {
            countNeg[i] = CountNegativeInRow(matrix, i);
        }

        for(int i = 1; i < countNeg.Length; i++)
        {
            if (countNeg[i] > countNeg[indexMaxNegRow]) indexMaxNegRow = i;
        }

        return indexMaxNegRow;
    }
    public static void SwapRowsMatrixs(int[,] A, int rowA, int[,] B, int rowB)
    {
        for(int j = 0; j < A.GetLength(1); j++)
        {
            (A[rowA, j], B[rowB, j]) = (B[rowB, j], A[rowA, j]);
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

        answerFirst = FindSequence(first, 0, first.Length - 1);
        answerSecond = FindSequence(second, 0, second.Length - 1);

        // end
    }
    public static int FindSequence(int[] array, int A, int B)
    {
        int counterDec = 0, counterInc = 0;

        for (int i = A; i < B; i++)
        {
            if (array[i + 1] > array[i]) counterInc++;
            else if(array[i] > array[i + 1]) counterDec++;
        }

        if (counterDec > 0 && counterInc > 0) return 0;
        else if (counterInc > 0) return 1;
        else return -1;
    }
    public void Task_2_28b(int[] first, int[] second, ref int[,] answerFirst, ref int[,] answerSecond)
    {
        // code here

        // use FindSequence(array, A, B); from Task_2_28a or entirely Task_2_28a
        // A and B - start and end indexes of elements from array for search

        answerFirst = FindAllIntervals(first);
        answerSecond = FindAllIntervals(second);

        // end
    }
    public static int[,] FindAllIntervals(int[] array)
    {
        int length = 0;
        for (int i = 0; i < array.Length; i++)
        {
            for (int j = i + 1; j < array.Length; j++)
            {
                if (FindSequence(array, i, j) != 0) length++;
            }
        }

        int[,] intervals = new int[length, 2];
        int index = 0;

        for (int i = 0; i < array.Length; i++)
        {
            for (int j = i + 1; j < array.Length; j++)
            {
                if (FindSequence(array, i, j) != 0)
                {
                    (intervals[index, 0], intervals[index, 1]) = (i, j);
                    index++;
                };
            }
        }
        return intervals;
    }
    public void Task_2_28c(int[] first, int[] second, ref int[] answerFirst, ref int[] answerSecond)
    {
        // code here

        // use FindSequence(array, A, B); from Task_2_28a or entirely Task_2_28a or Task_2_28b
        // A and B - start and end indexes of elements from array for search

        answerFirst = FindTheLongestInterval(first);
        answerSecond = FindTheLongestInterval(second);
        
        // end
    }
    public static int[] FindTheLongestInterval(int[] array)
    {
        int[] answer = new int[] { 0, 1 };

        for (int i = 0; i < array.Length; i++)
        {
            for (int j = i + 1; j < array.Length; j++)
            {
                if (FindSequence(array, i, j) != 0)
                {
                    if (j - i > answer[1] - answer[0])
                        (answer[1], answer[0]) = (j, i);
                };
            }
        }
        return answer;
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

        SortMatrix(matrix, SortAscending, SortDescending);

        // end
    }
    public delegate void SortRowStyle(int[,] matrix, int rowIndex);
    public void SortAscending(int[,] matrix, int rowIndex)
    {
        for(int i = 1, j = 2; i < matrix.GetLength(1); )
        {
            if(i == 0 || matrix[rowIndex, i - 1] < matrix[rowIndex, i])
            {
                i = j;
                j++;
            }
            else
            {
                (matrix[rowIndex, i - 1], matrix[rowIndex, i]) = (matrix[rowIndex, i], matrix[rowIndex, i - 1]);
                i--;
            }
        }
    }
    public void SortDescending(int[,] matrix, int rowIndex)
    {
        for (int i = 1, j = 2; i < matrix.GetLength(1);)
        {
            if (i == 0 || matrix[rowIndex, i - 1] > matrix[rowIndex, i])
            {
                i = j;
                j++;
            }
            else
            {
                (matrix[rowIndex, i - 1], matrix[rowIndex, i]) = (matrix[rowIndex, i], matrix[rowIndex, i - 1]);
                i--;
            }
        }
    }
    public void SortMatrix(int[,] matrix, SortRowStyle odd_rows, SortRowStyle even_rows)
    {
        for(int i = 0;  i < matrix.GetLength(0); i++)
        {
            if(i % 2 == 0)
            {
                odd_rows(matrix, i);
            }
            else
            {
                even_rows(matrix, i);
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

        answer = (isUpperTriangle) ? GetSum(GetUpperTriange, matrix) : GetSum(GetLowerTriange, matrix);

        // end

        return answer;
    }
    public delegate int[] GetTriangle(int[,] matrix);
    public static int[] GetUpperTriange(int[,] matrix)
    {
        int length = (matrix.Length - matrix.GetLength(0)) / 2 + matrix.GetLength(0);
        int[] triangles = new int[length];

        for(int i = 0, k = 0; i < matrix.GetLength(0); i++)
        {
            for(int j = i; j < matrix.GetLength(1); j++)
            {
                triangles[k++] = matrix[i, j];
            }
        }

        return triangles;
    }
    public static int[] GetLowerTriange(int[,] matrix)
    {
        int length = (matrix.Length - matrix.GetLength(0)) / 2 + matrix.GetLength(0);
        int[] triangles = new int[length];

        for (int i = 0, k = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j <= i; j++)
            {
                triangles[k++] = matrix[i, j];
            }
        }

        return triangles;
    }
    public static int GetSum(GetTriangle triangle, int[,] matrix)
    {
        int sum = 0;

        for(int i = 0; i < triangle(matrix).Length; i++)
        {
            sum += triangle(matrix)[i] * triangle(matrix)[i];
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
        // use method FindDiagonalMaxIndex(matrix) like in Task_2_3; +
        // create and use method FindFirstRowMaxIndex(matrix); +
        // create and use method SwapColumns(matrix, FindDiagonalMaxIndex, FindFirstRowMaxIndex);

        SwapColumns(matrix, FindDiagonalMaxIndex, FindFirstRowMaxIndex);

        // end
    }
    public delegate int FindElementDelegate(int[,] matrix);
    public static int FindFirstRowMaxIndex(int[,] matrix)
    {
        int iMaxCol = 0;

        for(int j = 1; j < matrix.GetLength(1); j++)
        {
            if (matrix[0, j] > matrix[0, iMaxCol]) iMaxCol = j;
        }

        return iMaxCol;
    }
    public static void SwapColumns(int[,] matrix, FindElementDelegate firstCol, FindElementDelegate secondCol)
    {
        int col_1 = firstCol(matrix);
        int col_2 = secondCol(matrix);

        if (col_1 == col_2) return;
        for(int i = 0; i < matrix.GetLength(0); i++)
        {
            (matrix[i, col_1], matrix[i, col_2]) = (matrix[i, col_2], matrix[i, col_1]);
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
        FindIndex searchArea = default(FindIndex);

        // code here

        // create and use public delegate FindIndex(matrix);
        // create and use method FindMaxBelowDiagonalIndex(matrix);
        // create and use method FindMinAboveDiagonalIndex(matrix);
        // use RemoveColumn(matrix, columnIndex) from Task_2_10
        // create and use method RemoveColumns(matrix, findMaxBelowDiagonalIndex, findMinAboveDiagonalIndex)

        matrix = RemoveColumns(matrix, FindMaxIndexBelowDiagonal, FindMinIndexAboveDiagonal);

        // end
    }
    public delegate int FindIndex(int[,] matrix);
    public static int[,] RemoveColumns(int[,] matrix, FindIndex firstCol, FindIndex secondCol)
    {
        int col_1 = firstCol(matrix);
        int col_2 = secondCol(matrix);

        if (col_1 == col_2)
        {
            matrix = RemoveColumn(matrix, col_1);
        }
        else if (col_2 > col_1)
        {
            matrix = RemoveColumn(matrix, col_2);
            matrix = RemoveColumn(matrix, col_1);
        }
        else
        {
            matrix = RemoveColumn(matrix, col_1);
            matrix = RemoveColumn(matrix, col_2);
        }

        return matrix;
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

        // code here

        // create and use public delegate GetNegativeArray(matrix);
        // use GetNegativeCountPerRow(matrix) from Task_2_22
        // use GetMaxNegativePerColumn(matrix) from Task_2_22
        // create and use method FindNegatives(matrix, searcherRows, searcherCols, out rows, out cols);

        FindNegatives(matrix, GetNegativeCountPerRow, GetMaxNegativePerColumn, out rows, out cols);

        // end
    }

    public delegate int[] GetNegativeArray(int[,] matrix);
    public static int[] GetNegativeCountPerRow(int[,] matrix)
    {
        int[] rows = new int[matrix.GetLength(0)];
        
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            rows[i] = CountNegativeInRow(matrix, i);
        }

        return rows;
    }
    public static int[] GetMaxNegativePerColumn(int[,] matrix)
    {
        int[] cols = new int[matrix.GetLength(1)];

        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            cols[j] = FindMaxNegativePerColumn(matrix, j);
        }

        return cols;
    }
    public static void FindNegatives(int[,] matrix, GetNegativeArray searcherRows, GetNegativeArray searcherCols, out int[] rows, out int[] cols)
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

        answerFirst = DefineSequence(first, FindIncreasingSequence, FindDecreasingSequence);
        answerSecond = DefineSequence(second, FindIncreasingSequence, FindDecreasingSequence);

        // end
    }
    public delegate int IsSequence(int[] array, int left, int right);
    public static int FindIncreasingSequence(int[] array, int A, int B)
    {

        for (int i = A; i < B; i++)
        {
            if (array[i + 1] <= array[i]) return 0;
        }

        return 1;
    }
    public static int FindDecreasingSequence(int[] array, int A, int B)
    {

        for (int i = A; i < B; i++)
        {
            if (array[i + 1] >= array[i]) return 0;
        }

        return 1;
    }
    public static int DefineSequence(int[] array, IsSequence IncreasingSequence, IsSequence DecreasingSequence)
    {
        if (IncreasingSequence(array, 0, array.Length - 1) == 1) return 1;
        else if (DecreasingSequence(array, 0, array.Length - 1) == 1) return -1;
        else return 0;
    }
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
    public static int[] FindLongestSequence(int[] array, IsSequence Sequence)
    {
        int[] answer = new int[] { 0, 0 };

        for (int i = 0; i < array.Length; i++)
        {
            for (int j = i + 1; j < array.Length; j++)
            {
                if (Sequence(array, i, j) != 0 && j - i > answer[1] - answer[0])
                    (answer[1], answer[0]) = (j, i);
            }
        }
        return answer;
    }

    #endregion
    #region bonus part
    public double[,] Task_4(double[,] matrix, int index)
    {
        MatrixConverter[] mc = new MatrixConverter[] {ToUpperTriangular, ToLowerTriangular, ToLeftDiagonal, ToRightDiagonal};

        // code here

        mc[index](matrix);

        // create public delegate MatrixConverter(matrix);
        // create and use method ToUpperTriangular(matrix);
        // create and use method ToLowerTriangular(matrix);
        // create and use method ToLeftDiagonal(matrix); - start from the left top angle
        // create and use method ToRightDiagonal(matrix); - start from the right bottom angle

        // end

        return matrix;
    }
    public delegate void MatrixConverter(double[,] matrix);
    public static void ToUpperTriangular(double[,] matrix)
    {
        for (int i = matrix.GetLength(0) - 1; i > 0; i--)
        {
            for (int ii = i - 1; ii >= 0; ii--)
            {
                double k = matrix[ii, i] / matrix[i, i];

                for (int j = matrix.GetLength(1) - 1; j >= 0; j--)
                {
                    matrix[ii, j] -= k * matrix[i, j];
                }
            }
        }
    }
    public static void ToLowerTriangular(double[,] matrix)
    {
        for(int i = 0; i < matrix.GetLength(0); i++)
        {
            for(int ii = i + 1; ii < matrix.GetLength(0); ii++)
            {
                if (matrix[ii, i] == 0) continue;

                double k = matrix[ii, i] / matrix[i, i];

                for(int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[ii,j] -= k * matrix[i, j];
                }
            }
        }
    }
    public static void ToLeftDiagonal(double[,] matrix)
    {
        ToLowerTriangular(matrix);
        ToUpperTriangular(matrix);
    }
    public static void ToRightDiagonal(double[,] matrix)
    {
        ToUpperTriangular(matrix);
        ToLowerTriangular(matrix);
    }
    
    #endregion

}

