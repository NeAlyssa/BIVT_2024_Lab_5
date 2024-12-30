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

        // create and use Combinations(n, k);
        // create and use Factorial(n);

        static int Combinations(int n, int k)
        {
            int c = Factorial(n) / (Factorial(k) * Factorial(n - k));
            return c;
        }

        static int Factorial(int n)
        {
            int x = 1;
            for (int i = 1; i <= n; i++)
            {
                x *= i;
            }
            return x;
        }

        answer = Combinations(n, k);

        // end

        return answer;
    }

    public int Task_1_2(double[] first, double[] second)
    {
        int answer = 0;

        // code here

        // create and use GeronArea(a, b, c);
        double s1 = 0, k1 = 0, s2 = 0, k2 = 0;
        for (int i = 0; i < 3; i++)
        {
            s1 += first[i];
            if (first[i] > k1) k1 = first[i];
        }
        for (int i = 0; i < 3; i++)
        {
            s2 += second[i];
            if (second[i] > k2) k2 = second[i];
        }
        if ((k1 >= s1 - k1) || (k2 >= s2 - k2))
        {
            answer = -1;
            return answer;
        }

        static double GeronArea(double a, double b, double c)
        {
            double p = (a + b + c) / 2;
            double s = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            return s;
        }

        if (GeronArea(first[0], first[1], first[2]) > GeronArea(second[0], second[1], second[2]))
        {
            answer = 1;
        }
        else if (GeronArea(first[0], first[1], first[2]) == GeronArea(second[0], second[1], second[2]))
        {
            answer = 0;
        }
        else if (GeronArea(first[0], first[1], first[2]) < GeronArea(second[0], second[1], second[2]))
        {
            answer = 2;
        }
        else
        {
            answer = -1;
        }
        // end

        // first = 1, second = 2, equal = 0, error = -1
        return answer;
    }

    public int Task_1_3a(double v1, double a1, double v2, double a2, int time)
    {
        int answer = 0;

        // code here

        // create and use GetDistance(v, a, t); t - hours
        double s1 = GetDistance(v1, a1, time);
        double s2 = GetDistance(v2, a2, time);
        if (s1 > s2) answer = 1;
        else if (s1 < s2) answer = 2;
        else answer = 0;

        // create and use GetDistance(v, a, t); t - hours

        static double GetDistance(double v, double a, double t)
        {
            double s = v * t + a * t * t / 2;
            return s;
        }
        // end

        // first = 1, second = 2, equal = 0
        return answer;
    }

    public int Task_1_3b(double v1, double a1, double v2, double a2)
    {
        int answer = 0;

        // code here

        // use GetDistance(v, a, t); t - hours

        int t = 1;

        while ((GetDistance(v1, a1, t)) > GetDistance(v2, a2, t)) t++;
        answer = t;

        // use GetDistance(v, a, t); t - hours

        static double GetDistance(double v, double a, double t)
        {
            double s = v * t + a * t * t / 2;
            return s;
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

        static void FindMaxIndex(int[,] matrix, out int row, out int column)
        {
            int maxElement = int.MinValue;
            row = -1;
            column = -1;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
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

        int row, column;
        FindMaxIndex(A, out row, out column);
        int row1 = row;
        int column1 = column;

        FindMaxIndex(B, out row, out column);
        int row2 = row;
        int column2 = column;

        int x = A[row1, column1];
        A[row1, column1] = B[row2, column2];
        B[row2, column2] = x;
        // end
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

        //  create and use method FindDiagonalMaxIndex(matrix);

        static void FindDiagonalMaxIndex(int[,] matrix, out int row)
        {
            int maxElement = int.MinValue;
            row = -1;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, i] > maxElement)
                {
                    maxElement = matrix[i, i];
                    row = i;
                }
            }
        }

        int raw = -1;
        FindDiagonalMaxIndex(B, out raw);
        int index = 0;
        int[,] newB = new int[4, 5];
        int[,] newC = new int[5, 6];
        for (int i = 0; i < 5; i++)
        {
            if (i == raw) continue;
            for (int j = 0; j < 5; j++)
            {
                newB[index, j] = B[i, j];
            }
            index++;
        }

        FindDiagonalMaxIndex(C, out raw);
        index = 0;
        for (int i = 0; i < 6; i++)
        {
            if (i == raw) continue;
            for (int j = 0; j < 6; j++)
            {
                newC[index, j] = C[i, j];
            }
            index++;
        }
        B = newB;
        C = newC;

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

        // create and use FindMaxInColumn(matrix, columnIndex, out rowIndex);

        static void FindMaxInColumn(int[,] matrix, int columnIndex, out int rowIndex)
        {
            rowIndex = -1;
            int maxElement = int.MinValue;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, columnIndex] > maxElement)
                {
                    maxElement = matrix[i, columnIndex];
                    rowIndex = i;
                }
            }
        }

        int[] arrayA = new int[6];
        int[] arrayB = new int[6];
        int rowIndex = -1;
        FindMaxInColumn(A, 1, out rowIndex);
        for (int j = 0; j < 6; j++)
        {
            arrayA[j] = A[rowIndex, j];
        }
        FindMaxInColumn(B, 1, out rowIndex);
        for (int j = 0; j < 6; j++)
        {
            arrayB[j] = B[rowIndex, j];
        }

        FindMaxInColumn(A, 1, out rowIndex);
        for (int j = 0; j < 6; j++)
        {
            A[rowIndex, j] = arrayB[j];
        }

        FindMaxInColumn(B, 1, out rowIndex);
        for (int j = 0; j < 6; j++)
        {
            B[rowIndex, j] = arrayA[j];
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

        // create and use CountRowPositive(matrix, rowIndex);
        // create and use CountColumnPositive(matrix, colIndex);

    static int CountRowPositive(int[,] matrix, int rowIndex)
        {
            int count = 0;
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[rowIndex, j] > 0) count++;
            }
            return count;
        }
        static int CountColumnPositive(int[,] matrix, int colIndex)
        {
            int count = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, colIndex] > 0) count++;
            }
            return count;
        }

        int rowB = B.GetLength(0);
        int colB = B.GetLength(1);
        int rowC = C.GetLength(0);
        int colC = C.GetLength(1);
        int MaxRowB = -1;
        int MaxColC = -1;
        int MaxCountB = 0;
        int MaxCountC = 0;
        int[,] B1 = new int[rowB + 1, colB];

        for (int i = 0; i < rowB; i++)
        {
            if (CountRowPositive(B, i) > MaxCountB)
            {
                MaxCountB = CountRowPositive(B, i);
                MaxRowB = i;
            }
        }
        for (int j = 0; j < colC; j++)
        {
            if (CountColumnPositive(C, j) > MaxCountC)
            {
                MaxCountC = CountColumnPositive(C, j);
                MaxColC = j;
            }
        }

        for (int i = 0; i < rowB + 1; ++i)
        {
            for (int j = 0; j < colB; ++j)
            {
                if (i <= MaxRowB) B1[i, j] = B[i, j];
                else if (i - 1 == MaxRowB)
                {
                    B1[i, j] = C[j, MaxColC];
                }
                else B1[i, j] = B[i - 1, j];
            }
        }
        B = B1;
    }

    // end


    public void Task_2_8(int[] A, int[] B)
    {
        // code here

        // create and use SortArrayPart(array, startIndex);

        // end
    }

    public int[] Task_2_9(int[,] A, int[,] C)
    {
        int[] answer = default(int[]);

        // code here

        // create and use SumPositiveElementsInColumns(matrix);

        static int[] SumPositiveElementsInColumns(int[,] matrix)
        {
            int[] sums = new int[matrix.GetLength(1)];
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    if (matrix[i, j] > 0) sums[j] += matrix[i, j];
                }
            }
            return sums;
        }

        int[] result = new int[A.GetLength(1) + C.GetLength(1)];
        int[] countA = SumPositiveElementsInColumns(A);
        int[] countC = SumPositiveElementsInColumns(C);
        for (int i = 0, j = 0; i < result.Length; i++)
        {
            if (i < A.GetLength(1)) result[i] = countA[i];
            else result[i] = countC[j++];
        }
        answer = result;

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

        static void FindMaxIndex(int[,] matrix, out int row, out int column)
        {
            int maxElement = int.MinValue;
            row = -1;
            column = -1;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
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

        int row = -1;
        int column = -1;
        FindMaxIndex(A, out row, out column);
        int rowA = row;
        int columnA = column;

        FindMaxIndex(B, out row, out column);
        int rowB = row;
        int columnB = column;

        int x = A[rowA, columnA];
        A[rowA, columnA] = B[rowB, columnB];
        B[rowB, columnB] = x;
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
        // code here

        // create and use RemoveRow(matrix, rowIndex);

        static void RemoveRow(ref int[,] matrix, int rowIndex)
        {
            int[,] newMatrix = new int[matrix.GetLength(0) - 1, matrix.GetLength(1)];
            int index = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (i == rowIndex) continue;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    newMatrix[index, j] = matrix[i, j];
                }
                index++;
            }
            matrix = newMatrix;
        }

        int indexMinI = -1;
        int indexMaxI = -1;
        int minElement = int.MaxValue;
        int maxElement = int.MinValue;

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] > maxElement)
                {
                    maxElement = matrix[i, j];
                    indexMaxI = i;
                }
                if (matrix[i, j] < minElement)
                {
                    minElement = matrix[i, j];
                    indexMinI = i;
                }
            }
        }

        RemoveRow(ref matrix, indexMaxI);
        if (indexMinI > indexMaxI)
        {
            indexMinI--;
            RemoveRow(ref matrix, indexMinI);
        }


        // end
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

        // code here

        // create and use GetAverageWithoutMinMax(matrix);

        int[] array = new int[3];
        array[0] = GetAverageWithoutMinMax(A);
        array[1] = GetAverageWithoutMinMax(B);
        array[2] = GetAverageWithoutMinMax(C);

        if (array[0] <= array[1] && array[1] <= array[2]) answer = 1;
        else if (array[0] >= array[1] && array[1] >= array[2]) answer = -1;
        else answer = 0;

        // end

        // 1 - increasing   0 - no sequence   -1 - decreasing
        return answer;
    }

    private static int GetAverageWithoutMinMax(int[,] matrix)
    {
        int sum = 0;
        int k = 0;
        int max = MaxElement(matrix);
        int min = MinElement(matrix);
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] != max && matrix[i, j] != min)
                {
                    sum += matrix[i, j];
                    k++;
                }
            }
        }
        return sum / k;
    }

    private static int MaxElement(int[,] matrix)
    {
        int maxElement = int.MinValue;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] > maxElement)
                {
                    maxElement = matrix[i, j];
                }
            }
        }
        return maxElement;
    }

    private static int MinElement(int[,] matrix)
    {
        int minElement = int.MaxValue;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] < minElement)
                {
                    minElement = matrix[i, j];
                }
            }
        }
        return minElement;
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

        // create and use SortRowsByMaxElement(matrix);


        SortRowsByMaxElement(A);
        SortRowsByMaxElement(B);
    }
    private static void SortRowsByMaxElement(int[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        for (int i = 0; i < rows - 1; ++i)
        {
            for (int j = i + 1; j < rows; ++j)
            {
                if (GetMaxElement(matrix, i) < GetMaxElement(matrix, j))
                {
                    SwapRows(matrix, i, j);
                }
            }
        }
    }

    private static int GetMaxElement(int[,] matrix, int row)
    {
        int max = int.MinValue;
        for (int col = 0; col < matrix.GetLength(1); ++col)
        {
            if (matrix[row, col] > max)
            {
                max = matrix[row, col];
            }
        }
        return max;
    }

    private static void SwapRows(int[,] matrix, int row1, int row2)
    {
        int cols = matrix.GetLength(1);
        for (int col = 0; col < cols; ++col)
        {
            int temp = matrix[row1, col];
            matrix[row1, col] = matrix[row2, col];
            matrix[row2, col] = temp;
        }
    }

    // end


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

        static void RemoveRow(ref int[,] matrix, int rowIndex)
        {
            int[,] newMatrix = new int[matrix.GetLength(0) - 1, matrix.GetLength(1)];
            int index = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (i == rowIndex) continue;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    newMatrix[index, j] = matrix[i, j];
                }
                index++;
            }
            matrix = newMatrix;
        }

        int index = 0;
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        for (int i = 0; i < rows; i++)
        {
            int flag = 0;
            for (int j = 0; j < cols; j++)
            {
                if (matrix[index, j] == 0)
                {
                    flag = 1;
                    break;
                }
            }

            if (flag == 1)
            {
                RemoveRow(ref matrix, index);
                index--;
            }
            index++;
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
        answerA = null;
        answerB = null;

        // code here

        // create and use CreateArrayFromMins(matrix);

        answerA = CreateArrayFromMins(A);
        answerB = CreateArrayFromMins(B);

        // end
    }

    private int[] CreateArrayFromMins(int[,] matrix)
    {
        int size = matrix.GetLength(0);
        int[] result = new int[size];

        for (int i = 0; i < size; i++)
        {
            int min = int.MaxValue;
            for (int j = i; j < size; j++)
            {
                if (matrix[i, j] < min)
                {
                    min = matrix[i, j];
                }
            }
            result[i] = min;
        }

        return result;
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

        // create and use MatrixValuesChange(matrix);

        MatrixValuesChange(A);
        MatrixValuesChange(B);

        // end
    }

    public void MatrixValuesChange(double[,] matrix)
    {
        double[] array = new double[matrix.GetLength(0) * matrix.GetLength(1)];
        int index = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                array[index++] = matrix[i, j];
            }
        }

        for (int i = 0; i < array.Length; i++)
        {
            for (int j = 0; j < array.Length - i - 1; j++)
            {
                if (array[j] < array[j + 1])
                {
                    double temp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = temp;
                }
            }
        }
        if (array.Length < 5)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > 0) matrix[i, j] *= 2;
                    else matrix[i, j] *= 0.5;
                }
            }
        }
        else
        {
            double[] max = new double[5];
            for (int i = 0; i < 5; i++)
            {
                max[i] = array[i];
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    bool flag = false;
                    for (int k = 0; k < max.Length; k++)
                    {
                        if (matrix[i, j] == max[k])
                        {
                            flag = true;
                            break;
                        }
                    }

                    if (flag)
                    {
                        if (matrix[i, j] > 0) matrix[i, j] *= 2;
                        else matrix[i, j] *= 0.5;
                    }
                    else
                    {
                        if (matrix[i, j] < 0) matrix[i, j] *= 2;
                        else matrix[i, j] /= 2;

                    }

                }
            }
        }
    }


    public void Task_2_24(int[,] A, int[,] B)
    {
        // code here

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
        maxA = FindRowWithMaxNegativeCount(A);
        maxB = FindRowWithMaxNegativeCount(B);
        // end
    }

    private static int FindRowWithMaxNegativeCount(int[,] matrix)
    {
        int[] arrayNegat = new int[matrix.GetLength(0)];
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            int k = 0;
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] < 0) k++;
            }
            arrayNegat[i] = k;
        }
        return MaxRowNegat(arrayNegat);
    }

    private static int MaxRowNegat(int[] array)
    {
        int maxi = -1;
        int maxElement = int.MinValue;
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] > maxElement)
            {
                maxi = i;
                maxElement = array[i];
            }
        }
        return maxi;
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
        // create and use ReplaceMaxElementOdd(matrix, row, column);
        // create and use ReplaceMaxElementEven(matrix, row, column);

        for (int i = 0; i < A.GetLength(0); i++)
        {
            int max = FindRowMaxIndex(A, i);
            if (i % 2 != 0) ReplaceMaxElementEven(ref A, i, max);
            else ReplaceMaxElementOdd(ref A, i, max);
        }

        for (int i = 0; i < B.GetLength(0); i++)
        {
            int max = FindRowMaxIndex(B, i);
            if (i % 2 != 0) ReplaceMaxElementEven(ref B, i, max);
            else ReplaceMaxElementOdd(ref B, i, max);
        }
        // end
    }
    public int FindRowMaxIndex(int[,] matrix, int row)
    {
        int index = 0;
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (matrix[row, j] > matrix[row, index]) index = j;
        }
        return index;
    }
    public void ReplaceMaxElementOdd(ref int[,] matrix, int row, int column)
    {
        matrix[row, column] *= (column + 1);
    }
    public void ReplaceMaxElementEven(ref int[,] matrix, int row, int column)
    {
        matrix[row, column] = 0;
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

    public delegate double SumFunction(int i, double x, ref int changes);
    public delegate double YFunction(double x);
    public double sum1Func(int i, double x, ref int Fact)
    {
        if (i > 0) { Fact *= i; }
        double member = Math.Cos(i * x) / Fact;
        return member;
    }
    public double sum2Func(int i, double x, ref int p)
    {
        p *= -1;
        double member = p * Math.Cos(i * x) / (i * i);
        return member;
    }
    public double Y1(double x)
    {
        double y = Math.Exp(Math.Cos(x)) * Math.Cos(Math.Sin(x));
        return y;
    }
    public double Y2(double x)
    {
        double y = ((x * x) - Math.Pow(Math.PI, 2) / 3) / 4;
        return y;
    }
    public double CountSum(SumFunction sumFunc, double x, int i)
    {
        double sum = 0;
        int changes = 1;

        double currentmem = sumFunc(i, x, ref changes);

        while (Math.Abs(currentmem) > 0.0001)
        {
            sum += currentmem;
            currentmem = sumFunc(++i, x, ref changes);
        }
        return sum;
    }
    public void GetSumAndY(SumFunction sumFunc, YFunction yFunc, double a, double b, double h, double[,] matrixSumAndY, int startI = 0)
    {
        for (int i = 0; i < (b - a) / h + 1; i++)
        {
            double x = a + i * h;
            double sum = CountSum(sumFunc, x, startI);
            double y = yFunc(x);
            matrixSumAndY[i, 0] = sum;
            matrixSumAndY[i, 1] = y;
        }
    }
    public void Task_3_1(ref double[,] firstSumAndY, ref double[,] secondSumAndY)
    {

        // code here 
        double a1 = 0.1, b1 = 1, h1 = 0.1;
        double a2 = Math.PI / 5, b2 = Math.PI, h2 = Math.PI / 25;


        firstSumAndY = new double[(int)((b1 - a1) / h1) + 1, 2];
        GetSumAndY(sum1Func, Y1, a1, b1, h1, firstSumAndY);

        secondSumAndY = new double[(int)((b2 - a2) / h2) + 1, 2];
        GetSumAndY(sum2Func, Y2, a2, b2, h2, secondSumAndY, 1);
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

    public delegate void SwapDirection(ref double[] array);

    public void SwapRight(ref double[] array)
    {
        for (int i = array.Length - 1; i > 0; i -= 2)
        {
            double temp = array[i];
            array[i] = array[i - 1];
            array[i - 1] = temp;
        }
    }

    public void SwapLeft(ref double[] array)
    {
        for (int i = 0; i < array.Length; i += 2)
        {
            double temp = array[i];
            array[i] = array[i + 1];
            array[i + 1] = temp;
        }
    }

    public double GetSum(double[] array, int start, int h)
    {
        double answer = 0;

        for (int i = start; i < array.Length; i += h)
            answer += array[i];

        return answer;
    }
    public double Task_3_3(double[] array)
    {
        double answer = 0;
        // SwapDirection swapper = default(SwapDirection); - uncomment me
        double average = 0;

        // code here
        for (int i = 0; i < array.Length; i++) average += array[i];

        // create and use public delegate SwapDirection(array);
        // create and use methods SwapRight(array) and SwapLeft(array) and GetSum(array)
        // change method in variable swapper in the loop here and use it for array swapping
        if (array.Length != 0)
            average /= array.Length;

        SwapDirection swapper = default(SwapDirection);

        // end
        if (array[0] > average)
            swapper = SwapLeft;
        else
            swapper = SwapRight;

        swapper(ref array);
        answer = GetSum(array, 1, 2); // нечетные индексы

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

    public double Func1(double x)
    {
        return x * x - Math.Sin(x);
    }

    public double Func2(double x)
    {
        return Math.Exp(x) - 1;
    }

    public int CountSignFlips(YFunction yFunc, double a, double b, double h)
    {


        int count = 0;
        double prevY = yFunc(a);

        for (double x = a + h; x <= b; x += h)
        {
            double currentY = yFunc(x);
            if (prevY * currentY < 0)
                count++;
            if (currentY != 0)
                prevY = currentY;
        }

        return count;
    }
    public void Task_3_5(out int func1, out int func2)
    {
        func1 = 0;
        func2 = 0;
        double a1 = 0, b1 = 2, h1 = 0.1;
        double a2 = -1, b2 = 1, h2 = 0.2;
        func1 = CountSignFlips(Func1, a1, b1, h1);
        func2 = CountSignFlips(Func2, a2, b2, h2);

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

    public int CountRowPositive(int[,] matrix, int rowIndex)
    {
        int cnt = 0;
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (matrix[rowIndex, j] > 0) cnt++;
        }
        return cnt;
    }
    public int CountColumnPositive(int[,] matrix, int colIndex)
    {
        int cnt = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            if (matrix[i, colIndex] > 0) cnt++;
        }
        return cnt;
    }
    public void Task_3_7(ref int[,] B, int[,] C)
    {
        if (B.GetLength(0) == 0 || B.GetLength(1) == 0 || C.GetLength(0) == 0 || C.GetLength(1) == 0) return;
        // code here

        // create and use public delegate CountPositive(matrix, index);
        // use CountRowPositive(matrix, rowIndex) from Task_2_7
        // use CountColumnPositive(matrix, colIndex) from Task_2_7

        // create and use method InsertColumn(matrixB, CountRow, matrixC, CountColumn);
        int maxPositiveCountB = -1;
        int row = -1;
        CountPositive countRowDelegate = CountRowPositive;
        CountPositive countColDelegate = CountColumnPositive;
        for (int i = 0; i < B.GetLength(0); i++)
        {
            int cnt = countRowDelegate(B, i);
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
            int cnt = countColDelegate(C, j);
            if (cnt > maxPositiveCountC)
            {
                maxPositiveCountC = cnt;
                col = j;
            }
        }
        InsertColumn(ref B, row, C, col);
        // end
    }

    public delegate int CountPositive(int[,] matrix, int index);
    public void InsertColumn(ref int[,] matrixB, int row, int[,] matrixC, int col)
    {
        int[,] newB = new int[matrixB.GetLength(0) + 1, matrixB.GetLength(1)];
        for (int i = 0; i <= row; i++)
        {
            for (int j = 0; j < matrixB.GetLength(1); j++)
            {
                newB[i, j] = matrixB[i, j];
            }
        }
        for (int j = 0; j < matrixC.GetLength(0); j++)
        {
            newB[row + 1, j] = matrixC[j, col];
        }
        for (int i = row + 1; i < matrixB.GetLength(0); i++)
        {
            for (int j = 0; j < matrixB.GetLength(1); j++)
            {
                newB[i + 1, j] = matrixB[i, j];
            }
        }
        matrixB = newB;
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

    public void RemoveRow(ref int[,] matrix, int rowIndex)
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
        matrix = newMatrix;
    }
    public void FindMaxIndex(int[,] matrix, out int row, out int col)
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
    public void Task_3_13(ref int[,] matrix)
    {
        // code here

        if (matrix.GetLength(0) == 0 || matrix.GetLength(1) == 0) return;
        RemoveRows(ref matrix, FindMaxIndex, FindMinIndex);
        // use public delegate FindElementDelegate(matrix) from Task_3_6
        // create and use method RemoveRows(matrix, findMax, findMin)

        // end
    }

    public delegate void FindElementDelegate(int[,] matrix, out int row, out int col);
    public void FindMinIndex(int[,] matrix, out int iminrow, out int imincol)
    {
        iminrow = imincol = -1;
        int min = int.MaxValue;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] < min)
                {
                    min = matrix[i, j];
                    iminrow = i;
                    imincol = j;
                }
            }
        }
    }
    public void RemoveRows(ref int[,] matrix, FindElementDelegate findmax, FindElementDelegate findmin)
    {
        int imaxrow = 0, imaxcol = 0, iminrow = 0, imincol = 0;
        findmax(matrix, out imaxrow, out imaxcol);
        findmin(matrix, out iminrow, out imincol);

        RemoveRow(ref matrix, imaxrow);

        if (iminrow < imaxrow)
        {
            RemoveRow(ref matrix, iminrow);
        }
        else if (iminrow > imaxrow)
        {
            RemoveRow(ref matrix, iminrow - 1);
        }
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

    public static void FindRowMaxIndex(int[,] matrix, int rowIndex, out int columnIndex) {
        int maxVal = int.MinValue;
        columnIndex = 0;
        for (int j = 0; j < matrix.GetLength(1); j++) {
            if (maxVal < matrix[rowIndex, j]) {
                maxVal = matrix[rowIndex, j];
                columnIndex = j;
            }
        }
    }
    public delegate void ReplaceMaxElement(ref int[,] matrix, int rowIndex, int colIndex);

    public void EvenOddRowsTransform(ref int[,] matrix, ReplaceMaxElement replaceMaxElementOdd, ReplaceMaxElement replaceMaxElementEven)
    {
        // code here
        int rows = matrix.GetLength(0);

        // create and use public delegate ReplaceMaxElement(matrix, rowIndex, max);
        // use ReplaceMaxElementOdd(matrix) from Task_2_27
        // use ReplaceMaxElementEven(matrix) from Task_2_27
        // create and use method EvenOddRowsTransform(matrix, replaceMaxElementOdd, replaceMaxElementEven);
        for (int i = 0; i < rows; i++)
        {
            int col;
            FindRowMaxIndex(matrix, i, out col);

            // end
            if (i % 2 != 0) ReplaceMaxElementEven(ref matrix, i, col); // != 0 т.к индексы идут с 0, а люди считают с 1
            else ReplaceMaxElementOdd(ref matrix, i, col);
        }
    }

    public void Task_3_27(int[,] A, int[,] B)
    {
        EvenOddRowsTransform(ref A, ReplaceMaxElementOdd, ReplaceMaxElementEven);
        EvenOddRowsTransform(ref B, ReplaceMaxElementOdd, ReplaceMaxElementEven);
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
