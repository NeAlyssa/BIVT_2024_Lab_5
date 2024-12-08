using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Drawing;
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
        double[,] matrix = {
            {2, 1, -1},
            {1, -1, 1},
            {-1, 1, 2}};

        program.ToLowerTriangular(matrix);

        Console.WriteLine($"{3.0159289474462025 + 0.12566}");


    }
    public void PrintMatrix(double[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++) Console.Write(matrix[i,j] + " ");
            Console.WriteLine();
        }
        
    }
    #region Level 1
    public long Task_1_1(int n, int k)
    {
        long answer = 0;

        // code here

        // create and use Factorial(n);
        Console.WriteLine(n);
        Console.WriteLine(k);
        if (n < k || n < 0 || k < 0) return 0;
        answer = (long)Factorial(n) / (Factorial(k) * Factorial(n - k));
        Console.WriteLine(answer);
        // end

        return answer;
    }

    public int Factorial(int x)
    {
        if (x < 2) return 1;
        return x * Factorial(x - 1);
    }


    public int Task_1_2(double[] first, double[] second)
    {
        int answer = 0;

        // code here

        // create and use GeronArea(a, b, c);
        // first = 1, second = 2, equal = 0, error = -1

        if (!TriangleExists(first[0], first[1], first[2]) || !TriangleExists(second[0], second[1], second[2])) return -1;

        double area1, area2;

        GeronArea(first[0], first[1], first[2], out area1);
        GeronArea(second[0], second[1], second[2], out area2);

        if (area1 > area2) return 1;
        else if (area1 < area2) return 2;
        else return 0;
        // end

        return answer;
    }

    public void GeronArea(double a, double b, double c, out double area)
    {
        double p = (a + b + c) / 2;
        area = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
    }

    public bool TriangleExists(double a, double b, double c)
    {
        if (a < b + c && b < a + c && c < a + b) return true;
        return false;
    }

    public int Task_1_3a(double v1, double a1, double v2, double a2, int time)
    {
        int answer = 0;

        // code here

        // create and use GetDistance(v, a, t); t - hours
        // first = 1, second = 2, equal = 0

        double s1 = GetDistance(v1, a1, time);
        double s2 = GetDistance(v2, a2, time);

        if (s1 > s2) return 1;
        else if (s1 < s2) return 2;
        else return 0;

        // end

        return answer;
    }

    public double GetDistance(double v, double a, int t)
    {
        return v * t + a * t * t / 2;
    }

    public int Task_1_3b(double v1, double a1, double v2, double a2)
    {
        int answer = 0;

        // code here

        // create and use GetDistance(v, a, t); t - hours

        for (int t = 1; ; t++)
        {
            Console.Write(GetDistance(v1, a1, t) + " "); Console.Write(GetDistance(v2, a2, t));
            Console.WriteLine();
            if (GetDistance(v1, a1, t) <= GetDistance(v2, a2, t)) return t;
        }

        // end

        return answer;
    }
    #endregion

    #region Level 2
    public void Task_2_1(int[,] A, int[,] B)
    {
        // code here

        // create and use FindMax(matrix);

        int[] max1 = FindMax(A);
        int[] max2 = FindMax(B);

        int temp = A[max1[0], max1[1]];
        A[max1[0], max1[1]] = B[max2[0], max2[1]];
        B[max2[0], max2[1]] = temp;

        // end
    }

    public int[] FindMax(int[,] array)
    {
        int[] MaxElem = new int[] { 0, 0 };
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++) if (array[i, j] > array[MaxElem[0], MaxElem[1]])
                {
                    MaxElem[0] = i;
                    MaxElem[1] = j;
                }
        }
        return MaxElem;
    }


    public void Task_2_2(double[] A, double[] B)
    {
        // code here

        // create and use FindMax(array);

        // end
    }

    public void Task_2_3(ref int[,] B, ref int[,] C)
    {
        // code here

        // create and use FindDiagonalMax(matrix);
        int rowsB = B.GetLength(0), colsB = B.GetLength(1), rowsC = C.GetLength(0), colsC = C.GetLength(1);
        int[,] B1 = new int[rowsB - 1, colsB], C1 = new int[rowsC - 1, colsC];
        int[] maxB = FindDiagonalMax(B), maxC = FindDiagonalMax(C);

        for (int i = 0; i < rowsB - 1; i++)
        {
            for (int j = 0; j < colsB; j++)
            {
                if (i < maxB[0]) B1[i, j] = B[i, j];
                else B1[i, j] = B[i + 1, j];
            }
        }
        for (int i = 0; i < rowsC - 1; i++)
        {
            for (int j = 0; j < colsC; j++)
            {
                if (i < maxC[0]) C1[i, j] = C[i, j];
                else C1[i, j] = C[i + 1, j];
            }
        }
        B = B1; C = C1;
        // end
    }

    public int[] FindDiagonalMax(int[,] array)
    {
        int[] MaxElem = new int[] { 0, 0 };
        for (int i = 0; i < array.GetLength(0); i++)
        {
            if (array[i, i] > array[MaxElem[0], MaxElem[1]])
            {
                MaxElem[0] = i;
                MaxElem[1] = i;
            }
        }
        return MaxElem;
    }

    public void Task_2_4(int[,] A, int[,] B)
    {
        // code here

        // use method FindDiagonalMax(matrix); from Task_2_3
        // use method FindDiagonalMaxIndex(matrix); from Task_2_3

        // end
    }

    public void Task_2_5(int[,] A, int[,] B)
    {
        // code here

        // create and use FindColumnMax(matrix, columnIndex);

        int MaxRowA = FindColumnMax(A)[0];
        int MaxRowB = FindColumnMax(B)[0];

        for (int j = 0; j < A.GetLength(1); j++)
        {
            int temp = A[MaxRowA, j];
            A[MaxRowA, j] = B[MaxRowB, j];
            B[MaxRowB, j] = temp;
        }

        // end
    }

    public int[] FindColumnMax(int[,] array)
    {
        int[] MaxElem = new int[] { 0, 0 };
        for (int i = 0; i < array.GetLength(0); i++)
        {
            if (array[i, 0] > array[MaxElem[0], MaxElem[1]])
            {
                MaxElem[0] = i;
                MaxElem[1] = 0;
            }
        }
        return MaxElem;
    }

    public void Task_2_6(ref int[] A, int[] B)
    {
        // code here

        // create and use DeleteElement(array, index);

        // end
    }

    public void Task_2_7(ref int[,] B, int[,] C)
    {
        // code here

        // create and use CountRowPositive(matrix, rowIndex);
        // create and use CountColumnPositive(matrix, colIndex);
        int rowsB = B.GetLength(0), colsB = B.GetLength(1), rowsC = C.GetLength(0), colsC = C.GetLength(1);
        int MaxRowB = -1, MaxColC = -1;
        int MaxCountB = 0, MaxCountC = 0;
        int[,] B1 = new int[rowsB + 1, colsB];

        for (int i = 0; i < rowsB; i++)
        {
            if (CountRowPositive(B, i) > MaxCountB)
            {
                MaxCountB = CountRowPositive(B, i);
                MaxRowB = i;
            }
        }
        for (int j = 0; j < colsC; j++)
        {
            if (CountColumnPositive(C, j) > MaxCountC)
            {
                MaxCountC = CountColumnPositive(C, j);
                MaxColC = j;
            }
        }

        for (int i = 0; i < rowsB + 1; ++i)
        {
            for (int j = 0; j < colsB; ++j)
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
        // end
    }

    public int CountRowPositive(int[,] matrix, int rowIndex)
    {
        int count = 0;
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (matrix[rowIndex, j] > 0) count++;
        }
        return count;
    }
    public int CountColumnPositive(int[,] matrix, int colIndex)
    {
        int count = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            if (matrix[i, colIndex] > 0) count++;
        }
        return count;
    }

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
        int[] result = new int[A.GetLength(1) + C.GetLength(1)];
        int[] countA = SumPositiveElementsInColumns(A), countC = SumPositiveElementsInColumns(C);
        for (int i = 0, j = 0; i < result.Length; i++)
        {
            if (i < A.GetLength(1)) result[i] = countA[i];
            else result[i] = countC[j++];
        }
        answer = result;
        // end

        return answer;
    }

    public int[] SumPositiveElementsInColumns(int[,] matrix)
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

    public void Task_2_10(ref int[,] matrix)
    {
        // code here

        // create and use RemoveColumn(matrix, columnIndex);

        // end
    }

    public void Task_2_11(int[,] A, int[,] B)
    {
        // code here

        // use FindMax(matrix); from Task_2_1
        int[] indexesA = FindMax(A), indexesB = FindMax(B);
        int rowIndexA = indexesA[0], colIndexA = indexesA[1], rowIndexB = indexesB[0], colIndexB = indexesB[1];

        int temp = A[rowIndexA, colIndexA];
        A[rowIndexA, colIndexA] = B[rowIndexB, colIndexB];
        B[rowIndexB, colIndexB] = temp;
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
        int[] indexesMax = FindMax(matrix), indexesMin = FindMin(matrix);
        int rowIndexMax = indexesMax[0], rowIndexMin = indexesMin[0];

        matrix = RemoveRow(matrix, Math.Max(rowIndexMax, rowIndexMin));
        if (rowIndexMax != rowIndexMin)
            matrix = RemoveRow(matrix, Math.Min(rowIndexMax, rowIndexMin));
        // end
    }

    public int[,] RemoveRow(int[,] matrix, int rowIndex)
    {
        int[,] new_matrix = new int[matrix.GetLength(0) - 1, matrix.GetLength(1)];

        for (int i = 0; i < new_matrix.GetLength(0); ++i)
        {
            for (int j = 0; j < new_matrix.GetLength(1); ++j)
            {
                if (i < rowIndex) new_matrix[i, j] = matrix[i, j];
                else new_matrix[i, j] = matrix[i + 1, j];
            }
        }
        return new_matrix;
    }

    public int[] FindMin(int[,] array)
    {
        int[] MinElem = new int[] { 0, 0 };
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++) if (array[i, j] < array[MinElem[0], MinElem[1]])
                {
                    MinElem[0] = i;
                    MinElem[1] = j;
                }
        }
        return MinElem;
    }

    public void Task_2_14(int[,] matrix)
    {
        // code here

        // create and use SortRow(matrix, rowIndex);

        // end
    }

    public int Task_2_15(int[,] A, int[,] B, int[,] C)
    {
        int answer = 0; // 1 - increasing   0 - no sequence   -1 - decreasing

        // code here

        // create and use GetAverageWithoutMinMax(matrix);
        double[] averages = new double[3];

        averages[0] = GetAverageWithoutMinMax(A);
        averages[1] = GetAverageWithoutMinMax(B);
        averages[2] = GetAverageWithoutMinMax(C);

        if (averages[1] > averages[0] && averages[2] > averages[1]) return 1;
        if (averages[1] < averages[0] && averages[2] < averages[1]) return -1;
        else return 0;
        // end

        return answer;
    }

    public double GetAverageWithoutMinMax(int[,] matrix)
    {
        int[] indexesMax = FindMax(matrix), indexesMin = FindMin(matrix);
        int rowIndexMax = indexesMax[0], colIndexMax = indexesMax[1], rowIndexMin = indexesMin[0], colIndexMin = indexesMin[1];
        double average = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (i == rowIndexMax || i == rowIndexMin)
                    if (j == colIndexMax || j == colIndexMin) continue;
                average += matrix[i, j];
            }
        }
        return average / (matrix.GetLength(0) * matrix.GetLength(1) - 2);
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
        SortRowsByMaxElement(ref A);
        SortRowsByMaxElement(ref B);
        // end
    }
    public void SortRowsByMaxElement(ref int[,] matrix)
    {
        int rows = matrix.GetLength(0), cols = matrix.GetLength(1);
        int[] elems = new int[rows];

        for (int i = 0; i < rows; i++)
        {
            int max_elem = 0;
            for (int j = 1; j < cols; j++)
            {
                if (matrix[i, j] > max_elem) max_elem = matrix[i, j];
            }
            elems[i] = max_elem;
        }

        for (int i = 1, j = i + 1; i < rows;)
        {
            if (i == 0 || elems[i] <= elems[i - 1])
            {
                i = j;
                j++;
            }
            else if (elems[i] > elems[i - 1])
            {
                int temp = elems[i];
                elems[i] = elems[i - 1];
                elems[i - 1] = temp;
                for (int c = 0; c < cols; c++)
                {
                    int temp_elem = matrix[i, c];
                    matrix[i, c] = matrix[i - 1, c];
                    matrix[i - 1, c] = temp_elem;
                }
                i--;
            }
        }

        //return indexes;
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
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] == 0)
                {
                    cnt++;
                    break;
                }
            }
        }
        int[] indexes = new int[cnt];
        for (int i = 0, k = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] == 0)
                {
                    indexes[k++] = i;
                    break;
                }
            }
        }
        for (int i = indexes.Length - 1; i >= 0; i--)
        {
            matrix = RemoveRow(matrix, indexes[i]);
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

    public int[] CreateArrayFromMins(int[,] matrix)
    {
        int[] mins = new int[matrix.GetLength(0)];
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            int min = int.MaxValue;
            for (int j = i; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] < min)
                {
                    mins[i] = matrix[i, j];
                    min = matrix[i, j];
                }
            }
        }
        return mins;
    }

    public void Task_2_22(int[,] matrix, out int[] rows, out int[] cols)
    {
        rows = null;
        cols = null;

        // code here

        // create and use GetNegativeCountPerRow(matrix);
        // create and use GetMaxNegativePerColumn(matrix);

        // end
    }

    public void Task_2_23(double[,] A, double[,] B)
    {
        // code here

        // create and use MatrixValuesChange(matrix);

        MatrixValuesChange(ref A);
        MatrixValuesChange(ref B);

        // end
    }
    public void MatrixValuesChange(ref double[,] matrix)
    {
        int rows = matrix.GetLength(0), cols = matrix.GetLength(1);
        double[] matrix_1 = new double[rows * cols];

        for (int i = 0, k = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++) matrix_1[k++] = matrix[i, j];
        }

        for (int i = 1, j = i + 1; i < rows * cols;)
        {
            if (i == 0 || matrix_1[i] <= matrix_1[i - 1])
            {
                i = j;
                j++;
            }
            else
            {
                double temp = matrix_1[i];
                matrix_1[i] = matrix_1[i - 1];
                matrix_1[i - 1] = temp;
                i--;
            }
        }

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                bool flag = true;
                for (int k = 0; k < 5; k++)
                {
                    if (matrix[i, j] == matrix_1[k])
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag)
                {
                    if (matrix[i, j] < 0) matrix[i, j] *= 2;
                    else matrix[i, j] /= 2;
                }
                else
                {
                    if (matrix[i, j] < 0) matrix[i, j] /= 2;
                    else matrix[i, j] *= 2;
                }
            }
        }
    }
    public int[] FindMaxDouble(double[,] array)
    {
        int[] MaxElem = new int[] { 0, 0 };
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++) if (array[i, j] > array[MaxElem[0], MaxElem[1]])
                {
                    MaxElem[0] = i;
                    MaxElem[1] = j;
                }
        }
        return MaxElem;
    }


    public void Task_2_24(int[,] A, int[,] B)
    {
        // code here

        // use FindMax(matrix); from 2_1

        // end
    }

    public void Task_2_25(int[,] A, int[,] B, out int maxA, out int maxB)
    {
        maxA = 0;
        maxB = 0;

        // code here

        // create and use FindMaxNegativeRow(int);
        // use GetNegativeCountPerRow(matrix); from 2_22
        maxA = FindMaxNegativeRow(A);
        maxB = FindMaxNegativeRow(B);
        // end
    }

    public int[] GetNegativeCountPerRow(int[,] matrix)
    {
        int[] count = new int[matrix.GetLength(0)];

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            int cnt = 0;
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] < 0) cnt++;
            }
            count[i] = cnt;
        }

        return count;
    }
    public int FindMaxNegativeRow(int[,] matrix)
    {
        int[] negatives = GetNegativeCountPerRow(matrix);
        int max_i = 0;
        for (int i = 0; i < negatives.Length; i++)
        {
            if (negatives[i] > negatives[max_i]) max_i = i;
        }
        return max_i;
    }

    public void Task_2_26(int[,] A, int[,] B)
    {
        // code here

        // use GetNegativeCountPerRow(matrix); from 2_22
        // create and use FindMaxIndex(array);

        // end
    }

    public void Task_2_27(int[,] A, int[,] B)
    {
        // code here
        // create and use FindRowMaxIndex(matrix)
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

        // end
    }

    public void Task_2_28b(int[] first, int[] second, ref int[,] answerFirst, ref int[,] answerSecond)
    {
        // code here

        // use FindSequence(array, A, B); from Task_2_28a or entirely Task_2_28a

        // end
    }

    public void Task_2_28c(int[] first, int[] second, ref int[] answerFirst, ref int[] answerSecond)
    {
        // code here

        // use FindSequence(array, A, B); from Task_2_28a or entirely Task_2_28a or Task_2_28b

        // end
    }
    #endregion

    #region Level 3
    public void Task_3_1(ref double[,] firstSumAndY, ref double[,] secondSumAndY)
    {
        // code here

        // create and use public delegate SumFunction(x, a, b, h) and public delegate YFunction(x, a, b, h)
        // create and use method GetSumAndY(sFunction, yFunction, a, b, h);
        // create and use 2 methods for both functions
        double a1 = 0.1, b1 = 1, h1 = 0.1;
        firstSumAndY = GetSumAndY(Sum1, y1, a1, b1, h1);

        double a2 = Math.PI / 5, b2 = Math.PI, h2 = Math.PI / 25;
        secondSumAndY = GetSumAndY(Sum2, y2, a2, b2, h2);
        
        // end
    }

    public delegate double YFunction(double x, double a, double b, double h);
    public double y1(double x, double a, double b, double h)
    {
        return Math.Exp(Math.Cos(x)) * Math.Cos(Math.Sin(x));
    }
    public double y2(double x, double a, double b, double h)
    {
        return (x * x - Math.PI * Math.PI / 3) / 4;
    }
    public delegate double SumFunction(double x, double a, double b, double h);
    public double Sum1(double x, double a, double b, double h)
    {
        double sum = 1;
        double elem = Math.Cos(x);
        for (int i = 2; Math.Abs(elem) > 0.0001; i++)
        {
            sum += elem;
            elem = Math.Cos(x * i) / Factorial(i);
        }
        return sum;
    }
    public double Sum2(double x, double a, double b, double h)
    {
        double sum = 0;
        int p = -1;
        double elem = p * Math.Cos(x);
        for (int i = 2; Math.Abs(elem) > 0.0001; i++)
        {
            sum += elem;
            p = -p;
            elem = p * Math.Cos(x * i) / (i * i);
        }
        return sum;
    }
    public double[,] GetSumAndY(SumFunction sFunction, YFunction yFunction, double a, double b, double h)
    {
        double[,] answer = new double[(int) ((b - a) / h) + 1, 2];
        int i = 0;
        for (double x = a; Math.Round(x,2) <= b; x += h)
        {
            double sum = sFunction(x, a, b, h);
            double y = yFunction(x, a, b, h);
            answer[i, 0] = sum;
            answer[i, 1] = y;
            i++;
        }
        return answer;
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

    public double Task_3_3(double[] array)
    {
        double answer = 0;
        SwapDirection swapper = default(SwapDirection); 

        // code here

        // create and use public delegate SwapDirection(array);
        // create and use methods SwapRight(array) and SwapLeft(array) and GetSum(array)
        // change method in variable swapper in the loop here and use it for array swapping
        double average = GetAverage(array);
        if (array[0] > average) swapper = SwapRight;
        else swapper = SwapLeft;

        array = swapper(array);
        answer = GetSum(array);
        // end

        return answer;
    }
    public delegate double[] SwapDirection(double[] array);
    public double[] SwapRight(double[] array)
    {
        for(int i = 0; i < array.Length - 1; i += 2)
        {
            double temp = array[i];
            array[i] = array[i + 1];
            array[i + 1] = temp;
        }
        return array;
    }
    public double[] SwapLeft(double[] array)
    {
        for (int i = array.Length - 1; i >= 1; i -= 2)
        {
            double temp = array[i];
            array[i] = array[i - 1];
            array[i - 1] = temp;
        }
        return array;
    }
    public double GetSum(double[] array)
    {
        double sum = 0;
        for (int i = 1;i < array.Length; i += 2)
        {
            sum += array[i];
        }
        return sum;
    }
    public double GetAverage(double[] array)
    {
        double sum = 0;
        for (int i = 0; i < array.Length; i++)
        {
            sum += array[i];
        }
        return sum / array.Length;
    }

    public int Task_3_4(int[,] matrix, bool isUpperTriangle)
    {
        int answer = 0;

        // code here

        // create and use public delegate GetTriangle(matrix);
        // create and use methods GetUpperTriange(array) and GetLowerTriange(array)
        // and GetSum(GetTriangle, matrix)
        // create and use method GetSum(array) similar to GetSum in Task_3_3

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
        double a1 = 0, b1 = 2, h1 = 0.1;
        func1 = CountSignFlips(f1, a1, b1, h1);

        double a2 = -1, b2 = 1, h2 = 0.2;
        func2 = CountSignFlips(f2, a2, b2, h2);
        // end
    }
    public double f1(double x, double a, double b, double h)
    {
        return x * x - Math.Sin(x);
    }
    public double f2(double x, double a, double b, double h)
    {
        return Math.Exp(x) - 1;
    }
    public int CountSignFlips(YFunction f, double a, double b, double h)
    {
        int count = 1;
        double last_y = f(a, a, b, h);
        for (double x = a + h; x <= b; x += h)
        {
            double y = f(x, a, b, h);
            if (y * last_y < 0) count += 1;
            last_y = y;
        }
        return count;
    }

    public void Task_3_6(int[,] matrix)
    {
        // code here

        // create and use public delegate FindElementDelegate(matrix);
        // use method FindDiagonalMaxIndex(matrix) from Task_2_3;
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
        int rowsB = B.GetLength(0), colsB = B.GetLength(1), rowsC = C.GetLength(0), colsC = C.GetLength(1);
        int MaxRowB = -1, MaxColC = -1;
        int MaxCountB = 0, MaxCountC = 0;
        int[,] B1 = new int[rowsB + 1, colsB];

        CountPositive Counter = CountRowPositive;
        for (int i = 0; i < rowsB; i++)
        {
            if (Counter(B, i) > MaxCountB)
            {
                MaxCountB = Counter(B, i);
                MaxRowB = i;
            }
        }
        Counter = CountColumnPositive;
        for (int j = 0; j < colsC; j++)
        {
            if (Counter(C, j) > MaxCountC)
            {
                MaxCountC = Counter(C, j);
                MaxColC = j;
            }
        }

        for (int i = 0; i < rowsB + 1; ++i)
        {
            for (int j = 0; j < colsB; ++j)
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
        // end
    }
    public delegate int CountPositive(int [,] matrix, int index);

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
        matrix = RemoveRows(matrix, FindMax, FindMin);
        // end
    }
    public delegate int[] FindElementDelegate(int [,] matrix);
    public int[,] RemoveRows(int[,] matrix, FindElementDelegate findMax, FindElementDelegate findMin)
    {
        int[] indexesMax = findMax(matrix), indexesMin = findMin(matrix);
        int rowIndexMax = indexesMax[0], rowIndexMin = indexesMin[0];

        matrix = RemoveRow(matrix, Math.Max(rowIndexMax, rowIndexMin));
        if (rowIndexMax != rowIndexMin)
            matrix = RemoveRow(matrix, Math.Min(rowIndexMax, rowIndexMin));
        return matrix;
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
        EvenOddRowsTransform(ref A, ReplaceMaxElementOdd, ReplaceMaxElementEven);
        EvenOddRowsTransform(ref B, ReplaceMaxElementOdd, ReplaceMaxElementEven);
        // end
    }
    public delegate void ReplaceMaxElement(ref int [,] matrix, int rowIndex, int max);

    public void EvenOddRowsTransform(ref int[,] matrix, ReplaceMaxElement replaceMaxElementOdd, ReplaceMaxElement replaceMaxElementEven)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            int max = FindRowMaxIndex(matrix, i);
            if (i % 2 != 0) replaceMaxElementEven(ref matrix, i, max);
            else replaceMaxElementOdd(ref matrix, i, max);
        }
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
        MatrixConverter[] mc = new MatrixConverter[4] { ToUpperTriangular , ToLowerTriangular , ToLeftDiagonal , ToRightDiagonal };

        // code here

        // create public delegate MatrixConverter(matrix);
        // create and use method ToUpperTriangular(matrix);
        // create and use method ToLowerTriangular(matrix);
        // create and use method ToLeftDiagonal(matrix); - start from the left top angle
        // create and use method ToRightDiagonal(matrix); - start from the right bottom angle

        // end
        mc[index](matrix);

        return matrix;
    }
    public delegate void MatrixConverter(double[,] matrix);

    public void ToUpperTriangular(double[,] matrix)
    {
        int n = matrix.GetLength(0);
        for (int j = 0; j < n; j++)
        {
            for (int k = j + 1; k < n; k++)
            {
                double p = matrix[k, j] / matrix[j,j];
                for (int m = j; m < n; m++)
                {
                    matrix[k, m] -= p * matrix[j, m];
                }
            }
        }
    }

    public void ToLowerTriangular(double[,] matrix)
    {
        int n = matrix.GetLength(0);
        for (int j = n - 1; j >= 0; j--)
        {
            for (int k = j - 1; k >= 0; k--)
            {
                double p = matrix[k, j] / matrix[j, j];
                for (int m = j; m >= 0; m--)
                {
                    matrix[k, m] -= p * matrix[j, m];
                }
            }
        }
        PrintMatrix(matrix);
    }

    public void ToLeftDiagonal(double[,] matrix)
    {
        ToUpperTriangular(matrix);
        ToLowerTriangular(matrix) ;
    }

    public void ToRightDiagonal(double[,] matrix)
    {
        ToLowerTriangular(matrix);
        ToUpperTriangular(matrix); 
    }
    #endregion
}
