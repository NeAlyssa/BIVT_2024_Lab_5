using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Numerics;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using static Program;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class Program
{
    public static void Main()
    {
        Program program = new Program();
        double[,] A = default(double[,]), B = default(double[,]);
        program.Task_3_1(ref A, ref B);
    }
    #region Level 1
    public long Factorial(int n)
    {
        if (n < 0)
            return 0; //error code
        if (n == 0)
            return 1;
        return n * Factorial(n - 1);
    }
    public long Combinations(int n, int k)
    {
        if (n < k || n < 0 || k < 0)
            return 0; //error code
        return Factorial(n) / (Factorial(k) * Factorial(n - k));
    }
    public long Task_1_1(int n, int k)
    {
        long answer = 0;

        // code here
        answer = Combinations(n, k);
        // create and use Combinations(n, k);
        // create and use Factorial(n);

        // end

        return answer;
    }
    public double SemiPerimetr(double a, double b, double c)
    {
        return (a + b + c) / 2;
    }
    public double GeronArea(double a, double b, double c)
    {
        if (a <= 0 || b <= 0 || c <= 0)
            return 0;
        if (a + b <= c || a + c <= b || b + c <= a)
            return -1;
        double p = SemiPerimetr(a, b, c);
        return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
    }
    public int Task_1_2(double[] first, double[] second)
    {
        int answer = 0;

        // code here
        // create and use GeronArea(a, b, c);
        double area1 = GeronArea(first[0], first[1], first[2]);
        double area2 = GeronArea(second[0], second[1], second[2]);
        if (area1 < 0 || area2 < 0)
            answer = -1;
        else if (area1 == area2)
            answer = 0;
        else if (area1 > area2)
            answer = 1;
        else
            answer = 2;
        // end
        // first = 1, second = 2, equal = 0, error = -1
        return answer;
    }
    public double GetDistance(double v, double a, int t)
    {
        return v * t + a * t * t / 2;
    }
    public int Task_1_3a(double v1, double a1, double v2, double a2, int time)
    {
        int answer = 0;

        // code here
        // create and use GetDistance(v, a, t); t - hours
        double S1 = GetDistance(v1, a1, time);
        double S2 = GetDistance(v2, a2, time);
        if (S1 == S2)
            answer = 0;
        else if (S2 < S1)
            answer = 1;
        else
            answer = 2;
        // end
        // first = 1, second = 2, equal = 0
        return answer;
    }

    public int Task_1_3b(double v1, double a1, double v2, double a2)
    {
        int answer = 0;

        // code here
        // use GetDistance(v, a, t); t - hours
        int time = 1;
        double S1 = GetDistance(v1, a1, time);
        double S2 = GetDistance(v2, a2, time);
        while ((S1 - S2) > 0.0001)
        {
            time++;
            S1 = GetDistance(v1, a1, time);
            S2 = GetDistance(v2, a2, time);
        }
        answer = time;
        // end

        return answer;
    }
    #endregion

    #region Level 2
    public void FindMaxIndex(int[,] matrix, out int row, out int column)
    {
        int max = matrix[0, 0];
        row = 0;
        column = 0;
        for (int m = 0; m < matrix.GetLength(0); m++)
        {
            for (int n = 0; n < matrix.GetLength(1); n++)
            {
                if (matrix[m, n] > max)
                {
                    max = matrix[m, n];
                    row = m;
                    column = n;
                }
            }
        }
    }
    public void Task_2_1(int[,] A, int[,] B)
    {
        // code here
        if (A.GetLength(0) != 5 || A.GetLength(1) != 6 || B.GetLength(0) != 3 || B.GetLength(1) != 5)
            return;
        // create and use FindMaxIndex(matrix, out row, out column);
        int rowA, columnA, rowB, columnB;
        FindMaxIndex(A, out rowA, out columnA);
        FindMaxIndex(B, out rowB, out columnB);
        int tmp = A[rowA, columnA];
        A[rowA, columnA] = B[rowB, columnB];
        B[rowB, columnB] = tmp;
        // end
    }

    public void Task_2_2(double[] A, double[] B)
    {
        // code here

        // create and use FindMaxIndex(array);
        // only 1 array has to be changed!

        // end
    }

    public int FindDiagonalMaxIndex(int[,] matrix)
    {
        if (matrix.GetLength(0) != matrix.GetLength(1))
            return -1;
        int max = matrix[0, 0];
        int maxindex = 0;
        for (int n = 0; n < matrix.GetLength(0); n++)
        {
            if (matrix[n, n] > max)
            {
                max = matrix[n, n];
                maxindex = n;
            }
        }
        return maxindex;
    }
    public void DeleteRow(ref int[,] matrix, int index)
    {
        if (index < 0 || index >= matrix.GetLength(0))
            return;
        int[,] answer = new int[matrix.GetLength(0) - 1, matrix.GetLength(1)];
        int k = 0;
        for (; k < index; k++)
        {
            for (int l = 0; l < matrix.GetLength(1); l++)
                answer[k, l] = matrix[k, l];
        }
        for (; k < answer.GetLength(0); k++)
        {
            for (int l = 0; l < matrix.GetLength(1); l++)
                answer[k, l] = matrix[k + 1, l];
        }
        matrix = answer;
    }
    public void Task_2_3(ref int[,] B, ref int[,] C)
    {
        // code here 
        if (C.GetLength(0) != 6 || C.GetLength(1) != 6 || B.GetLength(0) != 5 || B.GetLength(1) != 5)
            return;
        //  create and use method FindDiagonalMaxIndex(matrix);
        int indexB = FindDiagonalMaxIndex(B);
        int indexC = FindDiagonalMaxIndex(C);
        DeleteRow(ref B, indexB);
        DeleteRow(ref C, indexC);
        // end
    }

    public void Task_2_4(int[,] A, int[,] B)
    {
        // code here

        //  create and use method FindDiagonalMaxIndex(matrix); like in Task_2_3

        // end
    }

    public void FindMaxInColumn(int[,] matrix, int columnIndex, out int rowIndex)
    {
        int max = matrix[0, columnIndex];
        int maxIndex = 0;
        for (int r = 0; r < matrix.GetLength(0); r++)
        {
            if (matrix[r, columnIndex] > max)
            {
                max = matrix[r, columnIndex];
                maxIndex = r;
            }
        }
        rowIndex = maxIndex;
    }
    public void Task_2_5(int[,] A, int[,] B)
    {
        // code here
        if (A.GetLength(0) != 4 || A.GetLength(1) != 6 || B.GetLength(0) != 6 || B.GetLength(1) != 6)
            return;
        // create and use FindMaxInColumn(matrix, columnIndex, out rowIndex);
        int rowA, rowB;
        FindMaxInColumn(A, 1, out rowA);
        FindMaxInColumn(B, 1, out rowB);
        for (int k = 0; k < A.GetLength(1); k++)
        {
            int tmp = A[rowA, k];
            A[rowA, k] = B[rowB, k];
            B[rowB, k] = tmp;
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

    public int CountRowPositive(int[,] matrix, int rowIndex)
    {
        int count = 0;
        for (int n = 0; n < matrix.GetLength(1); n++)
        {
            if (matrix[rowIndex, n] > 0)
                count++;
        }
        return count;
    }
    public int CountColumnPositive(int[,] matrix, int colIndex)
    {
        int count = 0;
        for (int m = 0; m < matrix.GetLength(0); m++)
        {
            if (matrix[m, colIndex] > 0)
                count++;
        }
        return count;
    }
    public void Task_2_7(ref int[,] B, int[,] C)
    {
        // code here
        if (C.GetLength(0) != 5 || C.GetLength(1) != 6 || B.GetLength(0) != 4 || B.GetLength(1) != 5)
            return;
        // create and use CountRowPositive(matrix, rowIndex);
        // create and use CountColumnPositive(matrix, colIndex);
        int numMax = CountRowPositive(B, 0);
        int numRow = 0;
        for (int r = 0; r < B.GetLength(0); r++)
        {
            int currentNum = CountRowPositive(B, r);
            if (currentNum > numMax)
            {
                numMax = currentNum;
                numRow = r;
            }
        }
        numMax = CountColumnPositive(C, 0);
        int numCol = 0;
        for (int c = 0; c < C.GetLength(1); c++)
        {
            int currentNum = CountColumnPositive(C, c);
            if (currentNum > numMax)
            {
                numMax = currentNum;
                numCol = c;
            }
        }

        int[,] newB = new int[5, 5];
        for (int k = 0; k <= numRow; k++)
        {
            for (int l = 0; l < B.GetLength(1); l++)
            {
                newB[k, l] = B[k, l];
            }
        }
        for (int l = 0; l < B.GetLength(1); l++)
        {
            newB[numRow + 1, l] = C[l, numCol];
        }
        for (int k = numRow + 1; k < B.GetLength(0); k++)
        {
            for (int l = 0; l < B.GetLength(1); l++)
            {
                newB[k + 1, l] = B[k, l];
            }
        }

        B = newB;
        // end
    }

    public void Task_2_8(int[] A, int[] B)
    {
        // code here

        // create and use SortArrayPart(array, startIndex);

        // end
    }

    public int[] SumPositiveElementsInColumns(int[,] matrix)
    {
        int[] answer = new int[matrix.GetLength(1)];
        for (int n = 0; n < matrix.GetLength(1); n++)
        {
            int sumPositive = 0;
            for (int m = 0; m < matrix.GetLength(0); m++)
            {
                if (matrix[m, n] > 0)
                    sumPositive += matrix[m, n];
            }
            answer[n] = sumPositive;
        }
        return answer;
    }
    public int[] Task_2_9(int[,] A, int[,] C)
    {
        int[] answer = default(int[]);

        // code here
        //if (A.GetLength(0) != 6 || A.GetLength(1) != 5 || C.GetLength(0) != 7 || C.GetLength(1) != 4)
        //    return null;
        // create and use SumPositiveElementsInColumns(matrix);
        int[] arrayA = SumPositiveElementsInColumns(A);
        int[] arrayC = SumPositiveElementsInColumns(C);
        answer = new int[arrayA.Length + arrayC.Length];
        for (int a = 0; a < arrayA.Length; a++)
        {
            answer[a] = arrayA[a];
        }
        for (int c = 0; c < arrayC.Length; c++)
        {
            answer[arrayA.Length + c] = arrayC[c];
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
        int rowA, columnA, rowB, columnB;
        FindMaxIndex(A, out rowA, out columnA);
        FindMaxIndex(B, out rowB, out columnB);
        int tmp = A[rowA, columnA];
        A[rowA, columnA] = B[rowB, columnB];
        B[rowB, columnB] = tmp;

        // end
    }
    public void Task_2_12(int[,] A, int[,] B)
    {
        // code here

        // create and use FindMaxColumnIndex(matrix);

        // end
    }

    public void FindMinIndex(int[,] matrix, out int row, out int column)
    {
        int min = matrix[0, 0];
        row = 0;
        column = 0;
        for (int m = 0; m < matrix.GetLength(0); m++)
        {
            for (int n = 0; n < matrix.GetLength(1); n++)
            {
                if (matrix[m, n] < min)
                {
                    min = matrix[m, n];
                    row = m;
                    column = n;
                }
            }
        }
    }
    public void RemoveRow(ref int[,] matrix, int rowIndex)
    {
        int[,] result = new int[matrix.GetLength(0) - 1, matrix.GetLength(1)];
        for (int k = 0; k < rowIndex; k++)
        {
            for (int l = 0; l < matrix.GetLength(1); l++)
            {
                result[k, l] = matrix[k, l];
            }
        }
        for (int k = rowIndex; k < result.GetLength(0); k++)
        {
            for (int l = 0; l < matrix.GetLength(1); l++)
            {
                result[k, l] = matrix[k + 1, l];
            }
        }
        matrix = result;
    }
    public void Task_2_13(ref int[,] matrix)
    {
        // code here
        int minRow, maxRow;
        FindMaxIndex(matrix, out maxRow, out int maxCol);
        FindMinIndex(matrix, out minRow, out int minCol);
        // create and use RemoveRow(matrix, rowIndex);
        if (minRow == maxRow)
            RemoveRow(ref matrix, minRow);
        else
        {
            RemoveRow(ref matrix, minRow);
            RemoveRow(ref matrix, maxRow);
        }
        // end
    }

    public void Task_2_14(int[,] matrix)
    {
        // code here

        // create and use SortRow(matrix, rowIndex);

        // end
    }

    public double GetAverageWithoutMinMax(int[,] matrix)
    {
        int minRow, minCol, maxRow, maxCol;
        FindMinIndex(matrix, out minRow, out minCol);
        FindMaxIndex(matrix, out maxRow, out maxCol);
        int sumElem = 0;
        for (int m = 0; m < matrix.GetLength(0); m++)
        {
            for (int n = 0; n < matrix.GetLength(1); n++)
            {
                if (m != maxCol && m != minCol && n != minRow && n != maxRow)
                    sumElem += matrix[m, n];
            }
        }
        double numElem = matrix.GetLength(0) * matrix.GetLength(1) - 2;
        double average = sumElem / numElem;
        return average;
    }
    public int Task_2_15(int[,] A, int[,] B, int[,] C)
    {
        int answer = 0;

        // code here
        // create and use GetAverageWithoutMinMax(matrix);
        double[] arrayAverage = new double[3];
        arrayAverage[0] = GetAverageWithoutMinMax(A);
        arrayAverage[1] = GetAverageWithoutMinMax(B);
        arrayAverage[2] = GetAverageWithoutMinMax(C);
        if (arrayAverage[0] <= arrayAverage[1] && arrayAverage[1] <= arrayAverage[2])
            answer = 1;
        else if (arrayAverage[0] >= arrayAverage[1] && arrayAverage[1] >= arrayAverage[2])
            answer = -1;
        else
            answer = 0;
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

    public void SwapRows(ref int[,] matrix, int index1, int index2)
    {
        for (int k = 0; k < matrix.GetLength(1); k++)
        {
            int tmp = matrix[index1, k];
            matrix[index1, k] = matrix[index2, k];
            matrix[index2, k] = tmp;
        }
    }
    public int FindMaxInRow(int[,] matrix, int row)
    {
        int max = matrix[row, 0];
        int maxIndex = 0;
        for (int k = 0; k < matrix.GetLength(1); k++)
        {
            if (matrix[row, k] > max)
            {
                max = matrix[row, k];
                maxIndex = k;
            }
        }
        return max;
    }
    //убывание макс эл строк
    public void SortRowsByMaxElement(ref int[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(0) - i - 1; j++)
            {
                if (FindMaxInRow(matrix, j) < FindMaxInRow(matrix, j + 1))
                {
                    SwapRows(ref matrix, j, j + 1);
                }
            }
        }
    }
    public void Task_2_17(int[,] A, int[,] B)
    {
        // code here
        // create and use SortRowsByMaxElement(matrix);
        SortRowsByMaxElement(ref A);
        SortRowsByMaxElement(ref B);
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
        for (int m = 0; m < matrix.GetLength(0); m++)
        {
            for (int n = 0; n < matrix.GetLength(1); n++)
            {
                if (matrix[m, n] == 0)
                {
                    RemoveRow(ref matrix, m);
                    m--;
                    break;
                }
            }
        }
        // end
    }
    public void Task_2_20(ref int[,] A, ref int[,] B)
    {
        // code here

        // use RemoveColumn(matrix, columnIndex); from 2_10

        // end
    }

    public int[] CreateArrayFromMins(int[,] matrix)
    {
        int[] result = new int[matrix.GetLength(0)];
        for (int m = 0; m < matrix.GetLength(0); m++)
        {
            int min = matrix[m, m];
            for (int n = m; n < matrix.GetLength(1); n++)
            {
                if (matrix[m, n] < min)
                    min = matrix[m, n];
            }
            result[m] = min;
        }
        return result;
    }
    public void Task_2_21(int[,] A, int[,] B, out int[] answerA, out int[] answerB)
    {
        answerA = null;
        answerB = null;

        // code here
        // create and use CreateArrayFromMins(matrix);
        answerA = CreateArrayFromMins(A);
        answerB = CreateArrayFromMins(B);
        // end
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

    public void ChangeValue(ref double value, double mult)
    {
        if (mult >= 0)
        {
            if (value >= 0)
                value *= mult;
            else
                value /= mult;
        }
    }
    public void MatrixValuesChange(ref double[,] matrix)
    {
        if (matrix.GetLength(0) * matrix.GetLength(1) < 5)
        {
            for (int m = 0; m < matrix.GetLength(0); m++)
            {
                for (int n = 0; n < matrix.GetLength(1); n++)
                {
                    ChangeValue(ref matrix[m, n], 2);
                }
            }
            return;
        }
        //пять наиб жл-тов увеличить вдвое ост уменьшить вдвое
        double[,] maxElements = new double[,] {
            { matrix[0, 0], 0, 0 },
            { matrix[0, 0], 0, 0 },
            { matrix[0, 0], 0, 0 },
            { matrix[0, 0], 0, 0 },
            { matrix[0, 0], 0, 0 }
        };
        for (int k = 0; k < 5; k++)
        {
            for (int m = 0; m < matrix.GetLength(0); m++)
            {
                for (int n = 0; n < matrix.GetLength(1); n++)
                {//!!!
                    if (matrix[m, n] > maxElements[k, 0] && ((k == 0 || matrix[m, n] < maxElements[k - 1, 0])))
                    {
                        maxElements[k, 0] = matrix[m, n];
                        maxElements[k, 1] = m;
                        maxElements[k, 2] = n;
                    }
                    else if ((k != 0 && matrix[m, n] == maxElements[k - 1, 0] && !( m == maxElements[k - 1, 1] && n == maxElements[k-1, 2])))
                    {
                        maxElements[k, 0] = matrix[m, n];
                        maxElements[k, 1] = m;
                        maxElements[k, 2] = n;
                    }
                }
            }
        }
        for (int m = 0; m < matrix.GetLength(0); m++)
        {
            for (int n = 0; n < matrix.GetLength(1); n++)
            {
                bool isMax = false;
                for (int k = 0; k < 5; k++)
                {
                    if (maxElements[k, 1] == m && maxElements[k, 2] == n)
                    {
                        ChangeValue(ref matrix[m, n], 2);
                        isMax = true;
                        break;
                    }
                }
                if (!isMax)
                    ChangeValue(ref matrix[m, n], 0.5);
            }
        }

    }
    public void Task_2_23(double[,] A, double[,] B)
    {
        // code here
        // create and use MatrixValuesChange(matrix);
        MatrixValuesChange(ref A);
        MatrixValuesChange(ref B);
        // end
    }

    public void Task_2_24(int[,] A, int[,] B)
    {
        // code here

        // use FindMaxIndex(matrix, out row, out column); like in 2_1
        // create and use SwapColumnDiagonal(matrix, columnIndex);

        // end
    }

    public int CountNegativeInRow(int[,] matrix, int rowIndex)
    {
        int count = 0;
        for (int k = 0; k < matrix.GetLength(1); k++)
        {
            if (matrix[rowIndex, k] < 0)
                count++;
        }
        return count;
    }
    public int FindRowWithMaxNegativeCount(int[,] matrix)
    {
        int maxCount = CountNegativeInRow(matrix, 0);
        int maxIndex = 0;
        for (int k = 1; k < matrix.GetLength(0); k++)
        {
            int currentCount = CountNegativeInRow(matrix, k);
            if (currentCount > maxCount)
            {
                maxCount = currentCount;
                maxIndex = k;
            }
        }
        return maxIndex;
    }
    public void Task_2_25(int[,] A, int[,] B, out int maxA, out int maxB)
    {
        maxA = 0;
        maxB = 0;

        // code here
        // create and use FindRowWithMaxNegativeCount(matrix);
        // in FindRowWithMaxNegativeCount create and use CountNegativeInRow(matrix, rowIndex); like in 2_22
        maxA = FindRowWithMaxNegativeCount(A);
        maxB = FindRowWithMaxNegativeCount(B);
        // end
    }

    public void Task_2_26(int[,] A, int[,] B)
    {
        // code here

        // create and use FindRowWithMaxNegativeCount(matrix); like in 2_25
        // in FindRowWithMaxNegativeCount use CountNegativeInRow(matrix, rowIndex); from 2_22

        // end
    }

    public void FindRowMaxIndex(int[,] matrix, int rowIndex, out int columnIndex)
    {
        int maxIndex = 0;
        int max = matrix[rowIndex, 0];
        for (int k = 1; k < matrix.GetLength(1); k++)
        {
            if (matrix[rowIndex, k] > max)
            {
                max = matrix[rowIndex, k];
                maxIndex = k;
            }
        }
        columnIndex = maxIndex;
    }
    public void ReplaceMaxElementOdd(ref int[,] matrix, int row)//макс эл-т заменить 0
    {
        int column;
        FindRowMaxIndex(matrix, row, out column);
        matrix[row, column] = 0;
    }
    public void ReplaceMaxElementEven(ref int[,] matrix, int row)//макс эл-т умножить на column
    {
        int column;
        FindRowMaxIndex(matrix, row, out column);
        matrix[row, column] *= column + 1;
    }
    public void MatrixTransform(ref int[,] matrix)
    {
        for (int k = 1; k < matrix.GetLength(0); k += 2)
        {
            ReplaceMaxElementOdd(ref matrix, k);
        }
        for (int k = 0; k < matrix.GetLength(0); k += 2)
        {
            ReplaceMaxElementEven(ref matrix, k);
        }
    }
    public void Task_2_27(int[,] A, int[,] B)
    {
        // code here
        // create and use FindRowMaxIndex(matrix, rowIndex, out columnIndex);
        // create and use ReplaceMaxElementOdd(matrix, row, column);
        // create and use ReplaceMaxElementEven(matrix, row, column);
        MatrixTransform(ref A);
        MatrixTransform(ref B);
        // end
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
    public int MyFactorial(int a)
    {
        if (a < 0)
            return 0;
        if (a == 0 || a == 1)
            return 1;
        return a * MyFactorial(a - 1);
    }
    public delegate double FindElement(double x, int i);
    public delegate double SumFunction(double x, FindElement Element);
    public double Element1(double x, int i)
    {
        if (i == 0)
            return 1;
        int denom = MyFactorial(i);
        double elem = Math.Cos(i * x) / denom;

        return elem;
    }
    public double Element2(double x, int i)
    {
        if (i == 0)
            return 0;
        int sgn;
        if (i % 2 == 0)
            sgn = 1;
        else
            sgn = -1;
        double elem = sgn * Math.Cos(i * x) / (i * i);
        return elem;
    }
    public double Sum(double x, FindElement Element)
    {
        double sum = 0;
        int i = 0;
        double current = Element(x, 0);
        while (Math.Abs(current) > 0.0001 || i == 0)
        {
            sum += current;
            i++;
            current = Element(x, i);
        }
        return sum;
    }
    public delegate double YFunction(double x);
    public double Y1(double x)
    {
        double y = Math.Pow(Math.E, Math.Cos(x)) * Math.Cos(Math.Sin(x));
        return y;
    }
    public double Y2(double x)
    {
        double y = (x * x - Math.PI * Math.PI / 3) / 4;
        return y;
    }
    double[,] GetSumAndY(FindElement findElem, YFunction yFunction, double a, double b, double h)
    {
        int numRes = (int)((b - a) / h + 1);
        double[,] result= new double[numRes, 2];
        int m = 0;
        for (double x = a ; x < b+0.0001 && m < numRes ; x+=h, m++)
        {
            result[m, 0] = Sum(x, findElem);
            result[m,1] = yFunction(x);
        }
        return result;
    }
    public void Task_3_1(ref double[,] firstSumAndY, ref double[,] secondSumAndY)
    {
        // code here
        // create and use public delegate SumFunction(x) and public delegate YFunction(x)
        // create and use method GetSumAndY(sFunction, yFunction, a, b, h);
        // create and use 2 methods for both functions calculating at specific x
        firstSumAndY = GetSumAndY(Element1, Y1, 0.1, 1, 0.1);
        secondSumAndY = GetSumAndY(Element2, Y2, Math.PI / 5, Math.PI, Math.PI / 25);
        // end
    }

    public void Task_3_2(int[,] matrix)
    {
        // SortRowStyle sortStyle = default(SortRowStyle); - uncomment me

        // code here

        // create and use public delegate SortRowStyle(matrix, rowIndex);
        // create and use methods SortAscending(matrix, rowIndex) and SortDescending(matrix, rowIndex)
        // change method in variable sortStyle in the loop here and use it for row sorting

        // end
    }

    public void Swap(ref double a, ref double b)
    {
        double tmp = a;
        a = b; 
        b = tmp;
    }
    public delegate void SwapDirection(double[] array);
    public void SwapRight(double[] array)
    {
        for(int k = 1; k < array.Length;k += 2)
            Swap(ref array[k - 1], ref array[k]);
    }
    public void SwapLeft(double[] array)
    {
        for (int k = array.Length - 2; k >= 0; k -= 2)
            Swap(ref array[k + 1], ref array[k]);
    }
    public double GetSum(double[] array)
    {
        double sum = 0;
        for(int k = 1; k < array.Length; k += 2)
            sum += array[k];
        return sum;
    }
    public double GetAverage(double[] array)
    {
        double sum = 0;
        for(int k = 0;k < array.Length; k++)
            sum += array[k];
        double average = sum / array.Length;
        return average;
    }
    public double Task_3_3(double[] array)
    {
        double answer = 0;
        SwapDirection swapper = default(SwapDirection); //- uncomment me

        // code here

        // create and use public delegate SwapDirection(array);
        // create and use methods SwapRight(array) and SwapLeft(array)
        // create and use method GetSum(array, start, h) that sum elements with a negative indexes
        // change method in variable swapper in the if/else and than use swapper(matrix)
        if (array[0] > GetAverage(array))
            swapper = SwapRight;
        else 
            swapper = SwapLeft;
        swapper(array);
        answer = GetSum(array);
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

    public double Y3(double x)
    {
        double y = x * x - Math.Sin(x);
        return y;
    }
    public double Y4(double x)
    {
        double y = Math.Pow(Math.E, x) - 1;
        return y;
    }
    int CountSignFlips(YFunction Y, double a, double b, double h)
    {
        int count = 0;
        double x = a+h;
        double left = Y(a);
        double right = Y(a + h); //Y(x)
        while(x <= b)
        {
            if (left * right <= 0)
                count++;
            if (left == 0)
                count--;
            x += h;
            left = right;
            right = Y(x);
        }
        return count;
    }
    public void Task_3_5(out int func1, out int func2)
    {
        func1 = 0;
        func2 = 0;

        // code here
        // use public delegate YFunction(x) from Task_3_1
        // create and use method CountSignFlips(YFunction, a, b, h);
        // create and use 2 methods for both functions
        func1 = CountSignFlips(Y3, 0, 2, 0.1);
        func2 = CountSignFlips(Y4, -1, 1, 0.2);
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

    public delegate int CountPositive(int[,] matrix, int index);

    public int FindMaxPositiveInVector(int[,] matrix, int vector)// 0 - row; 1 - col
    {
        CountPositive counter;
        if (vector == 0)
            counter = CountRowPositive;
        else if (vector == 1)
            counter = CountColumnPositive;
        else
            return -1;

        int max = counter(matrix, 0);
        int maxIndex = 0;
        for(int k = 0; k < matrix.GetLength(vector); k++)
        {
            int currentCount = counter(matrix, k);
            if(currentCount > max)
            {
                max = currentCount;
                maxIndex = k;
            }
        }

        return maxIndex;
    }
    public void Task_3_7(ref int[,] B, int[,] C)
    {
        // code here

        // create and use public delegate CountPositive(matrix, index);
        // use CountRowPositive(matrix, rowIndex) from Task_2_7
        // use CountColumnPositive(matrix, colIndex) from Task_2_7
        // create and use method InsertColumn(matrixB, CountRow, matrixC, CountColumn);
        int MaxIndexRowInB = FindMaxPositiveInVector(B, 0);
        int MaxIndexColInC = FindMaxPositiveInVector(C, 1);
        
        int[,] newB = new int[5, 5];
        for (int k = 0; k <= MaxIndexRowInB; k++)
        {
            for (int l = 0; l < B.GetLength(1); l++)
            {
                newB[k, l] = B[k, l];
            }
        }
        for (int l = 0; l < B.GetLength(1); l++)
        {
            newB[MaxIndexRowInB + 1, l] = C[l, MaxIndexColInC];
        }
        for (int k = MaxIndexRowInB + 1; k < B.GetLength(0); k++)
        {
            for (int l = 0; l < B.GetLength(1); l++)
            {
                newB[k + 1, l] = B[k, l];
            }
        }

        B = newB;

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

    public delegate void FindElementDelegate(int[,] matrix, out int rowIndex, out int cilIndex);
    public void RemoveRows(ref int[,] matrix, FindElementDelegate findMax, FindElementDelegate findMin)
    {
        int minRow, maxRow;
        findMax(matrix, out maxRow, out int maxCol);
        findMin(matrix, out minRow, out int minCol);
        if (minRow == maxRow)
            RemoveRow(ref matrix, minRow);
        else
        {
            RemoveRow(ref matrix, minRow);
            RemoveRow(ref matrix, maxRow);
        }

    }
    public void Task_3_13(ref int[,] matrix)
    {
        // code here
        // use public delegate FindElementDelegate(matrix) from Task_3_6
        // create and use method RemoveRows(matrix, findMax, findMin)
        RemoveRows(ref matrix, FindMaxIndex, FindMinIndex);
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

    public delegate void ReplaceMaxElement(ref int[,] matrix, int rowIndex);
    public void EvenOddRowsTransform(ref int[,] matrix, ReplaceMaxElement replaceMaxElementOdd, ReplaceMaxElement replaceMaxElementEven)
    {
        for (int k = 1; k < matrix.GetLength(0); k += 2)
        {
            replaceMaxElementOdd(ref matrix, k);
        }
        for (int k = 0; k < matrix.GetLength(0); k += 2)
        {
            replaceMaxElementEven(ref matrix, k);
        }

    }
    public void Task_3_27(int[,] A, int[,] B)
    {
        // code here

        // create and use public delegate ReplaceMaxElement(matrix, rowIndex, max);
        // use ReplaceMaxElementOdd(matrix) from Task_2_27
        // use ReplaceMaxElementEven(matrix) from Task_2_27
        // create and use method EvenOddRowsTransform(matrix, replaceMaxElementOdd, replaceMaxElementEven);
        EvenOddRowsTransform(ref A, ReplaceMaxElementOdd, ReplaceMaxElementEven);
        EvenOddRowsTransform(ref B, ReplaceMaxElementOdd, ReplaceMaxElementEven);
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
    public delegate void MatrixConverter(ref double[,] matrix); 
    public void RowTransformation(ref double[,] matrix, int diminutiveIndex, int deductibleIndex, double mult)
    {
        if (diminutiveIndex < 0 || diminutiveIndex >= matrix.GetLength(0) || deductibleIndex < 0 || deductibleIndex >= matrix.GetLength(0))
            return;
        for(int k = 0; k < matrix.GetLength(1); k++)
        {
            matrix[diminutiveIndex, k] -= mult * matrix[deductibleIndex, k];
        }    
    }
    public void RowMult(ref double[,] matrix, int rowIndex, double mult)
    {
        if(rowIndex < 0  || rowIndex >= matrix.GetLength(0) )
            return;
        for(int k = 0; k < matrix.GetLength(1); k++)
        {
            matrix[rowIndex, k] *= mult;
        }
    }
    public void RowShare(ref double[,] matrix, int rowIndex, double share)
    {
        if (rowIndex < 0 || rowIndex >= matrix.GetLength(0))
            return;
        for (int k = 0; k < matrix.GetLength(1); k++)
        {
            matrix[rowIndex, k] /= share;
        }
    }
    public void ToUpperTriangular(ref double[,] matrix)
    {
        if (matrix.GetLength(0) != matrix.GetLength(1))
            return;

        for(int m = 0;  m < matrix.GetLength(0) - 1; m++)
        {
            double tmp = matrix[m, m];
            RowShare(ref matrix, m, tmp); //matrix[m,m] = 1 
            for (int n = m+1; n < matrix.GetLength(0); n++)
            {
                RowTransformation(ref matrix, n, m, matrix[n, m]);
            }
            RowMult(ref matrix, m, tmp); // return row m
        }
    }
    public void ToLowerTriangular(ref double[,] matrix)
    {
        if (matrix.GetLength(0) != matrix.GetLength(1))
            return;

        for (int m = matrix.GetLength(0) - 1; m >=0 ; m--)
        {
            double tmp = matrix[m, m];
            RowShare(ref matrix, m, tmp); //matrix[m,m] = 1 
            for (int n = m - 1; n >= 0; n--)
            {
                RowTransformation(ref matrix, n, m, matrix[n, m]);
            }
            RowMult(ref matrix, m, tmp); // return row m
        }
    }
    public void ToLeftDiagonal(ref double[,] matrix)
    {
        ToUpperTriangular(ref matrix);
        ToLowerTriangular(ref matrix);
    }
    public void ToRightDiagonal(ref double[,] matrix)
    {
        ToLowerTriangular(ref matrix);
        ToUpperTriangular(ref matrix);
    }
    public double[,] Task_4(double[,] matrix, int index)
    {
         MatrixConverter[] mc = new MatrixConverter[4]; //- uncomment me

        // code here
        mc[0] = ToUpperTriangular;
        mc[1] = ToLowerTriangular;
        mc[2] = ToLeftDiagonal;
        mc[3] = ToRightDiagonal;
        // create public delegate MatrixConverter(matrix);
        // create and use method ToUpperTriangular(matrix);
        // create and use method ToLowerTriangular(matrix);
        // create and use method ToLeftDiagonal(matrix); - start from the left top angle
        // create and use method ToRightDiagonal(matrix); - start from the right bottom angle
        MatrixConverter converter = mc[index];
        converter(ref matrix);
        // end

        return matrix;
    }
    #endregion
}
