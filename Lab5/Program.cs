using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Numerics;
using System.Reflection;
using System.Reflection.Metadata;
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

    public static int Factorial(int n)
    {

        int res = 1;
        for (int i = 2; i <= n; i++)
            res *= i;
        return res;
    }

    public long Task_1_1(int n, int k)
    {
        long answer = 0;

        // code here

        if (n < 0 || k < 0 || k > n)
        {
            return 0;
        }
        answer = Factorial(n) / Factorial(k) / Factorial(n - k);

        // create and use Factorial(n);

        // end

        return answer;
    }

    public static double GeronArea(double a, double b, double c)
    {
        double p = (a + b + c) / 2;
        return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
    }

    public static bool ValidateTriangle(double[] sides)
    {
        if (sides.Length != 3)
            return false;

        for (int i = 0; i < 3; i++)
            if (sides[i] <= 0)
                return false;

        if (sides[0] >= sides[1] + sides[2])
            return false;

        if (sides[1] >= sides[0] + sides[2])
            return false;

        if (sides[2] >= sides[1] + sides[0])
            return false;

        return true;
    }

    public int Task_1_2(double[] first, double[] second)
    {
        int answer = 0;

        // code here

        // create and use GeronArea(a, b, c);
        // first = 1, second = 2, equal = 0, error = -1

        if (!ValidateTriangle(first) || !ValidateTriangle(second))
            return -1;

        double area1 = GeronArea(first[0], first[1], first[2]), 
            area2 = GeronArea(second[0], second[1], second[2]);

        if (area1 > area2)
            answer = 1;
        else if (area2 > area1)
            answer = 2;

        // end

        return answer;
    }

    public static double GetDistance(double v, double a, double t)
    {
        return v * t + a * t * t / 2;
    }

    public int Task_1_3a(double v1, double a1, double v2, double a2, int time)
    {
        int answer = 0;

        // code here

        // create and use GetDistance(v, a, t); t - hours
        // first = 1, second = 2, equal = 0

        double dist1 = GetDistance(v1, a1, time), dist2 = GetDistance(v2, a2, time);
        if (dist1 > dist2)
            answer = 1;
        else if (dist2 > dist1)
            answer = 2;

        // end

        return answer;
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

    public static (int, int, int) FindMax(int [,] matrix)
    {
        int maxVal = int.MinValue, rowIdx = -1, colIdx = -1;
        int rows = matrix.GetLength(0), cols = matrix.GetLength(1); 

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (matrix[i, j] > maxVal)
                {
                    maxVal = matrix[i, j];
                    rowIdx = i; 
                    colIdx = j;
                }
            }
        }

        return (maxVal, rowIdx, colIdx);
    }

    public void Task_2_1(int[,] A, int[,] B)
    {
        // code here

        // create and use FindMax(matrix);

        (int, int, int) ans1 = FindMax(A), ans2 = FindMax(B);

        int temp = A[ans1.Item2, ans1.Item3];
        A[ans1.Item2, ans1.Item3] = B[ans2.Item2, ans2.Item3];
        B[ans2.Item2, ans2.Item3] = temp;
        // end
    }

    public void Task_2_2(double[] A, double[] B)
    {
        // code here

        // create and use FindMax(array);

        // end
    }

    public static (int, int) FindDiagonalMax(int[,] matrix)
    {
        int n = matrix.GetLength(0);
        int maxVal = int.MinValue, index = -1;
        for (int i = 0; i < n; i++)
        {
            if (matrix[i, i] > maxVal) {
                maxVal = matrix[i, i];
                index = i;
            }
        }
        return (maxVal, index);
    }

    public static void RemoveRow(ref int[,] matrix, int index)
    {

        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1); 
        int[,] newMat = new int[rows - 1, cols];
        int iter = 0;
        for (int i = 0; i < rows; i++)
        {
            if (i == index)
                continue;
            for (int j = 0; j < cols; j++)
            {
                newMat[iter, j] = matrix[i, j];
            }
            iter++;
        }
        matrix = newMat;
    }

    public void Task_2_3(ref int[,] B, ref int[,] C)
    {
        // code here

        // create and use FindDiagonalMax(matrix);

        (int, int) ans1 = FindDiagonalMax(B), ans2 = FindDiagonalMax(C);

        RemoveRow(ref B, ans1.Item2);
        RemoveRow(ref C, ans2.Item2);

        // end
    }

    public void Task_2_4(int[,] A, int[,] B)
    {
        // code here

        // use method FindDiagonalMax(matrix); from Task_2_3
        // use method FindDiagonalMaxIndex(matrix); from Task_2_3

        // end
    }

    public static (int, int) FindColumnMax(int[,] matrix, int columnIndex)
    {
        int rows = matrix.GetLength(0);
        int maxVal = int.MinValue, index = -1;
        for (int i = 0; i < rows; i++)
        {
            if (matrix[i, columnIndex] > maxVal)
            {
                maxVal = matrix[i, columnIndex];
                index = i;
            }
        }
        return (maxVal, index);
    }

    public static void SwapRows(int[,] A, int[,] B, int row1, int row2)
    {
        int cols = A.GetLength(1);
        int maxVal = int.MinValue, index = -1;
        for (int i = 0; i < cols; i++)
        {
            int temp = A[row1, i];
            A[row1, i] = B[row2, i];
            B[row2, i] = temp;
        }
    }

    public void Task_2_5(int[,] A, int[,] B)
    {
        // code here

        // create and use FindColumnMax(matrix, columnIndex);

        (int, int) ans1 = FindColumnMax(A, 0), ans2 = FindColumnMax(B, 0);

        SwapRows(A, B, ans1.Item2, ans2.Item2 );

        // end
    }

    public void Task_2_6(ref int[] A, int[] B)
    {
        // code here

        // create and use DeleteElement(array, index);

        // end
    }

    public static int CountRowPositive(int[,] matrix, int rowIndex)
    {
        int cnt = 0;
        int cols = matrix.GetLength(1);
        for (int i = 0; i < cols; i++)
        {
            if (matrix[rowIndex, i] > 0)
                cnt++;
        }
        return cnt;
    }

    public static int CountColumnPositive(int[,] matrix, int colIndex)
    {
        int cnt = 0;
        int rows = matrix.GetLength(0);
        for (int i = 0; i < rows; i++)
        {
            if (matrix[i, colIndex] > 0)
                cnt++;
        }
        return cnt;
    }

    public delegate int CountPositive(int[,] matrix, int index);

    public void Task_2_7(ref int[,] B, int[,] C)
    {
        // code here

        // create and use CountRowPositive(matrix, rowIndex);
        // create and use CountColumnPositive(matrix, colIndex);

        int maxCnt1 = -1, maxRow = -1;
        for (int i = 0; i < 4; i++)
        {
            CountPositive countDel = CountRowPositive;
            int res = countDel(B, i);
            if (res > maxCnt1)
            {
                maxCnt1 = res; maxRow = i;
            }
        }

        int maxCnt2 = -1, maxCol = -1;
        for (int i = 0; i < 6; i++)
        {
            CountPositive countDel = CountColumnPositive;
            int res = countDel(C, i);
            if (res > maxCnt2)
            {
                maxCnt2 = res; maxCol = i;
            }
        }

        int[,] newMat = new int[5, 5];
        int iter = 0;
        for (int i = 0; i < 5; i++)
        {
            if (i == maxRow + 1)
            {
                for (int j = 0; j < 5; j++)
                {
                    newMat[iter, j] = C[j, maxCol];
                }
            }
            else
            {
                for (int j = 0; j < 5; j++)
                {
                    newMat[i, j] = B[iter, j];
                }
                iter++;
            }
        }
        B = newMat;

        // end
    }

    public void Task_2_8(int[] A, int[] B)
    {
        // code here

        // create and use SortArrayPart(array, startIndex);

        // end
    }

    public static int[] SumPositiveElementsInColumns(int[,] matrix)
    {
        int rows = matrix.GetLength(0), cols = matrix.GetLength(1); 
        int[] answer = new int[cols];

        for (int i = 0; i < cols; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                if (matrix[j, i] > 0)
                    answer[i] += matrix[j, i];
            }
        }

        return answer;
    }

    public int[] Task_2_9(int[,] A, int[,] C)
    {
        int[] answer = default(int[]);

        // code here

        // create and use SumPositiveElementsInColumns(matrix);

        int[] res1 = SumPositiveElementsInColumns(A);
        int[] res2 = SumPositiveElementsInColumns(C);

        int iter = 0;
        answer = new int[res1.Length + res2.Length];
        for (int i = 0; i < res1.Length; i++)
            answer[iter++] = res1[i];

        for (int i = 0; i < res2.Length; i++)
            answer[iter++] = res2[i];

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

        // use FindMax(matrix); from Task_2_1

        (int, int, int) ans1 = FindMax(A), ans2 = FindMax(B);

        int temp = A[ans1.Item2, ans1.Item3];
        A[ans1.Item2, ans1.Item3] = B[ans2.Item2, ans2.Item3];
        B[ans2.Item2, ans2.Item3] = temp;

        // end
    }
    public void Task_2_12(int[,] A, int[,] B)
    {
        // code here

        // create and use FindMaxColumnIndex(matrix);

        // end
    }

    public static (int, int, int) FindMin(int[,] matrix)
    {
        int minVal = int.MaxValue, rowIdx = -1, colIdx = -1;
        int rows = matrix.GetLength(0), cols = matrix.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (matrix[i, j] < minVal)
                {
                    minVal = matrix[i, j];
                    rowIdx = i;
                    colIdx = j;
                }
            }
        }

        return (minVal, rowIdx, colIdx);
    }

    public delegate (int, int, int) FindMinMax(int[,] matrix);

    public void Task_2_13(ref int[,] matrix)
    {
        // code here

        // create and use RemoveRow(matrix, rowIndex);

        FindMinMax findMin = FindMin, findMax = FindMax;

        (int, int, int) ans1 = findMin(matrix), ans2 = findMax(matrix);

        if (ans1.Item2 == ans2.Item2)
        {
            RemoveRow(ref matrix, ans1.Item2);
        }
        else if (ans1.Item2 > ans2.Item2)
        {
            RemoveRow(ref matrix, ans1.Item2);
            RemoveRow(ref matrix, ans2.Item2);
        } else
        {
            RemoveRow(ref matrix, ans2.Item2);
            RemoveRow(ref matrix, ans1.Item2);
        }


        // end
    }
    
    public void Task_2_14(int[,] matrix)
    {
        // code here

        // create and use SortRow(matrix, rowIndex);

        // end
    }

    public static double GetAverageWithoutMinMax(int[,] matrix)
    {
        FindMinMax findMin = FindMin, findMax = FindMax;

        (int, int, int) ans1 = findMin(matrix), ans2 = findMax(matrix);

        int rows = matrix.GetLength(0), cols = matrix.GetLength(1);

        double elSum = 0.0, cnt = rows * cols - 2;

        for (int i = 0; i < rows; i++) {
            for (int j = 0; j < cols; j++)
            {
                if (matrix[i, j] == ans1.Item1 || matrix[i, j] == ans2.Item1)
                    continue;
                elSum += (double)matrix[i, j];
            }
        }
        if (cnt > 0)
            elSum /= cnt;

        return elSum;
    }

    public int Task_2_15(int[,] A, int[,] B, int[,] C)
    {
        int answer = 0; // 1 - increasing   0 - no sequence   -1 - decreasing

        // code here

        // create and use GetAverageWithoutMinMax(matrix);

        double r1 = GetAverageWithoutMinMax(A), r2 = GetAverageWithoutMinMax(B),
            r3 = GetAverageWithoutMinMax(C);
        if (r1 > r2 && r2 > r3)
            answer = -1;
        else if (r1 < r2 && r2 < r3)
            answer = 1;

        // end

        return answer;
    }    

    public void Task_2_16(int[] A, int[] B)
    {
        // code here

        // create and use SortNegative(array);

        // end
    }

    public static void SortRowsByMaxElement(int[,] matrix)
    {
        int rows = matrix.GetLength(0), cols = matrix.GetLength(1);

        int[] maxElems = new int[rows];
        int[] rowIdxs = new int[rows];

        for (int i = 0; i < rows; i++)
        {
            maxElems[i] = matrix[i, 0];
            rowIdxs[i] = i;
            for (int j = 1; j < cols; j++)
            {
                if (matrix[i, j] > maxElems[i])
                {
                    maxElems[i] = matrix[i, j];
                }
            }
        }

        for (int i = 0; i < rows - 1; i++)
        {
            for (int j = i + 1; j < rows; j++)
            {
                if (maxElems[i] < maxElems[j])
                {
                    int tempMin = maxElems[i];
                    maxElems[i] = maxElems[j];
                    maxElems[j] = tempMin;

                    int tempIndex = rowIdxs[i];
                    rowIdxs[i] = rowIdxs[j];
                    rowIdxs[j] = tempIndex;
                }
            }
        }

        int[,] sortedMatrix = new int[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                sortedMatrix[i, j] = matrix[rowIdxs[i], j];
            }
        }

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                matrix[i, j] = sortedMatrix[i, j];
            }
        }
    }

    public static void PrintMatrix(int[,] matrix)
    {
        int rows = matrix.GetLength(0); 
        int cols = matrix.GetLength(1); 

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write(matrix[i, j] + "\t"); 
            }
            Console.WriteLine(); 
        }
    }

    public void Task_2_17(int[,] A, int[,] B)
    {
        // code here

        // create and use SortRowsByMaxElement(matrix);

        SortRowsByMaxElement(A);
        SortRowsByMaxElement(B);

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

        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        int rowCnt = 0;
        for (int i = rows - 1; i >= 0; i--)
        {   
            bool flag = false;
            for (int j = 0; j < cols; j++)
            {
                if (matrix[i, j] == 0)
                {
                    flag = true;
                    break;
                }
            }
            if (flag)
                RemoveRow(ref matrix, i);
        }

        // end
    }
    public void Task_2_20(ref int[,] A, ref int[,] B)
    {
        // code here

        // use RemoveColumn(matrix, columnIndex); from 2_10

        // end
    }    

    public static int[] CreateArrayFromMins(int[,] matrix)
    {
        int n = matrix.GetLength(0);
        int[] answer = new int[n];
        for (int i = 0; i < n; i++)
        {
            int minVal = int.MaxValue;
            for (int j = i; j < n; j++)
            {
                if (matrix[i, j] < minVal)
                    minVal = matrix[i, j];
            }
            answer[i] = minVal;
        }

        return answer;
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

        // create and use GetNegativeCountPerRow(matrix);
        // create and use GetMaxNegativePerColumn(matrix);

        // end
    }

    static void SortArray(double[] array)
    {
        int n = array.Length;
        for (int i = 0; i < n - i; i++)
        {
            bool swapped = false;
            for (int j = i, k = n - i - 1; j < n - i - 1; j++, k--)
            {
                if (array[j] < array[j + 1])
                {
                    double temp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = temp;
                    swapped = true;
                }
                if (array[k] > array[k - 1])
                {
                    double temp = array[k];
                    array[k] = array[k - 1];
                    array[k - 1] = temp;
                    swapped = true;
                }
            }
            if (!swapped) return;
        }
    }

    public void MatrixValuesChange(double[,] matrix)
    {
        double[] array = new double[matrix.GetLength(0) * matrix.GetLength(1)];

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                array[i * matrix.GetLength(0) + j] = matrix[i, j];
            }
        }

        SortArray(array);

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                bool flag = false;

                for (int k = 0; k < 5; k++)
                {
                    if (matrix[i, j] == array[k])
                    {
                        flag = true;
                        matrix[i, j] = (matrix[i, j] > 0) ? matrix[i, j] * 2 : matrix[i, j] / 2;
                        break;
                    }
                }

                if (flag) continue;

                matrix[i, j] = (matrix[i, j] > 0) ? matrix[i, j] / 2 : matrix[i, j] * 2;
            }
        }
    }

    public void Task_2_23(double[,] A, double[,] B)
    {
        // code here

        // create and use MatrixValuesChange(matrix);
        MatrixValuesChange(A);
        MatrixValuesChange(B);
        // end
    }

    public void Task_2_24(int[,] A, int[,] B)
    {
        // code here

        // use FindMax(matrix); from 2_1

        // end
    }

    public static int[] GetNegativeCountPerRow(int[,] matrix)
    {
        int rows = matrix.GetLength(0), cols = matrix.GetLength(1);
        int[] answer = new int[rows];

        for (int i = 0; i < rows; i++)
            for (int j = 0; j < cols; j++)
                if (matrix[i, j] < 0)
                    answer[i]++;

        return answer;
    }

    public static int FindMaxNegativeRow(int[,] matrix)
    {
        int[] arr = GetNegativeCountPerRow(matrix);
        int maxVal = int.MinValue, maxIdx = -1;
        for (int i = 0; i < arr.Length; i++)
            if (arr[i] > maxVal)
            {
                maxVal = arr[i];
                maxIdx = i;
            }

        return maxIdx;
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

    public void Task_2_26(int[,] A, int[,] B)
    {
        // code here

        // use GetNegativeCountPerRow(matrix); from 2_22
        // create and use FindMaxIndex(array);

        // end
    }

    public static int FindRowMaxIndex(int[,] matrix, int rowIndex)
    {
        int cols = matrix.GetLength(1);
        int maxVal = int.MinValue, maxIdx = -1;

        for (int i = 0; i < cols; i++)
        {
            if (matrix[rowIndex, i] > maxVal)
            {
                maxVal = matrix[rowIndex, i];
                maxIdx = i;
            }
        }
        return maxIdx;
    }

    public static void ReplaceMaxElementOdd(int[,] matrix, int row, int column)
    {
        matrix[row, column] *= (column + 1);
    }

    public static void ReplaceMaxElementEven(int[,] matrix, int row, int column)
    {
        matrix[row, column] = 0;
    }

    public delegate void ReplaceMaxElement(int[,] matrix, int row, int column);

    public void Task_2_27(int[,] A, int[,] B)
    {
        // code here
        // create and use FindRowMaxIndex(matrix)
        // create and use ReplaceMaxElementOdd(matrix, row, column);
        // create and use ReplaceMaxElementEven(matrix, row, column);

        int rowsA = A.GetLength(0);

        ReplaceMaxElement replaceOdd = ReplaceMaxElementOdd,
            replaceEven = ReplaceMaxElementEven;

        for (int i = 0; i < rowsA; i++)
        {
            int idx = FindRowMaxIndex(A, i);
            if (i % 2 != 0)
                replaceEven(A, i, idx);
            else
                replaceOdd(A, i, idx);
        }

        int rowsB = B.GetLength(0);

        for (int i = 0; i < rowsB; i++)
        {
            int idx = FindRowMaxIndex(B, i);
            if (i % 2 != 0)
                replaceEven(B, i, idx);
            else
                replaceOdd(B, i, idx);
        }

        PrintMatrix(A);
        Console.WriteLine();
        PrintMatrix(B);

        // end
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

    public delegate double SumFunction(int i, double x, ref int ch);
    public delegate double YFunction(double x);
    public double s1(int i, double x, ref int iFactorial)
    {
        if (i > 0)
            iFactorial *= i;

        return Math.Cos(i * x) / iFactorial;
    }
    public double s2(int i, double x, ref int sign)
    {
        sign *= -1;
        return sign * Math.Cos(i * x) / (i * i);
    }
    public double y1(double x) { 
        return Math.Exp(Math.Cos(x)) * Math.Cos(Math.Sin(x)); 
    }
    public double y2(double x) { 
        return ((x * x) - Math.PI * Math.PI / 3) / 4; 
    }
    public double CalculateSum(SumFunction sumFunction, double x, int i)
    {
        double eps = 0.0001, s = 0;
        int ch = 1;
        double cur = sumFunction(i, x, ref ch);

        while (Math.Abs(cur) > eps)
        {
            s += cur;
            cur = sumFunction(++i, x, ref ch);
        }
        return s;
    }
    public void GetSumAndY(SumFunction sFunction, YFunction yFunction, double a, double b, double h, double[,] SumAndY, int startI = 0)
    {
        for (int i = 0; i < (b - a) / h + 1; i++)
        {
            double x = a + i * h;

            double sum = CalculateSum(sFunction, x, startI);
            double y = yFunction(x);

            SumAndY[i, 0] = sum;
            SumAndY[i, 1] = y;
        }
    }
    public void Task_3_1(ref double[,] firstSumAndY, ref double[,] secondSumAndY)
    {
        // code here

        // create and use public delegate SumFunction(x) and public delegate YFunction(x)
        // create and use method GetSumAndY(sFunction, yFunction, a, b, h);
        // create and use 2 methods for both functions calculating at specific x

        double a1 = 0.1, b1 = 1, h1 = 0.1;
        firstSumAndY = new double[(int)((b1 - a1) / h1) + 1, 2];
        GetSumAndY(s1, y1, a1, b1, h1, firstSumAndY);

        double a2 = Math.PI / 5, b2 = Math.PI, h2 = Math.PI / 25;
        secondSumAndY = new double[(int)((b2 - a2) / h2) + 1, 2];
        GetSumAndY(s2, y2, a2, b2, h2, secondSumAndY, 1);

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

    public delegate void SwapDirection(double[] arr);
    public void SwapRight(double[] arr)
    {
        for (int i = 0; i < arr.Length - 1; i += 2)
        {
            (arr[i], arr[i + 1]) = (arr[i + 1], arr[i]);
        }
    }
    public void SwapLeft(double[] arr)
    {
        for (int i = arr.Length - 1; i > 0; i -= 2)
        {
            (arr[i], arr[i - 1]) = (arr[i - 1], arr[i]);
        }
    }
    public double GetSum(double[] arr)
    {
        double s = 0;
        for (int i = 1; i < arr.Length; i += 2)
        {
            s += arr[i];
        }
        return s;
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

        double s = 0;
        int n = array.Length;
        SwapDirection swapper;

        for (int i = 0; i < n; i++)
        {
            s += array[i];
        }
        double average = s / n;

        if (array[0] > average) swapper = SwapRight;
        else swapper = SwapLeft;
        swapper(array);
        answer = GetSum(array);

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
    public int CountSignFlips(YFunction yFunction, double a, double b, double h)
    {
        int cnt = 0;
        for (double x = a + h; x <= b; x += h)
        {
            double prev = yFunction(x - h), cur = yFunction(x);
            if ((prev >= 0 && cur < 0) || (prev <= 0 && cur > 0) || (x == b && cur == 0))
                cnt++;
        }

        return cnt;
    }

    public double y5_1(double x) { 
        return x * x - Math.Sin(x); 
    }

    public double y5_2(double x) { 
        return Math.Exp(x) - 1; 
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
        func1 = CountSignFlips(y5_1, a1, b1, h1);
        double a2 = -1, b2 = 1, h2 = 0.2;
        func2 = CountSignFlips(y5_2, a2, b2, h2);

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

    static void InsertColumn(ref int[,] matrixB, CountPositive CountRow, ref int[,] matrixC, CountPositive CountColumn)
    {
        int maxCnt1 = -1, maxRow = -1;
        for (int i = 0; i < 4; i++)
        {
            int res = CountRow(matrixB, i);
            if (res > maxCnt1)
            {
                maxCnt1 = res; maxRow = i;
            }
        }

        int maxCnt2 = -1, maxCol = -1;
        for (int i = 0; i < 6; i++)
        {
            int res = CountColumn(matrixC, i);
            if (res > maxCnt2)
            {
                maxCnt2 = res; maxCol = i;
            }
        }

        int[,] newMat = new int[5, 5];
        int iter = 0;
        for (int i = 0; i < 5; i++)
        {
            if (i == maxRow + 1)
            {
                for (int j = 0; j < 5; j++)
                {
                    newMat[iter, j] = matrixC[j, maxCol];
                }
            }
            else
            {
                for (int j = 0; j < 5; j++)
                {
                    newMat[i, j] = matrixB[iter, j];
                }
                iter++;
            }
        }
        matrixB = newMat;
    }

    public void Task_3_7(ref int[,] B, int[,] C)
    {
        // code here

        // create and use public delegate CountPositive(matrix, index);
        // use CountRowPositive(matrix, rowIndex) from Task_2_7
        // use CountColumnPositive(matrix, colIndex) from Task_2_7
        // create and use method InsertColumn(matrixB, CountRow, matrixC, CountColumn);

        InsertColumn(ref B, CountRowPositive, ref C, CountColumnPositive);

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

    static void RemoveRows(ref int[,] matrix, FindMinMax findMax, FindMinMax findMin)
    {
        (int, int, int) ans1 = findMin(matrix), ans2 = findMax(matrix);

        if (ans1.Item2 == ans2.Item2)
        {
            RemoveRow(ref matrix, ans1.Item2);
        }
        else if (ans1.Item2 > ans2.Item2)
        {
            RemoveRow(ref matrix, ans1.Item2);
            RemoveRow(ref matrix, ans2.Item2);
        }
        else
        {
            RemoveRow(ref matrix, ans2.Item2);
            RemoveRow(ref matrix, ans1.Item2);
        }
    }

    public void Task_3_13(ref int[,] matrix)
    {
        // code here

        // use public delegate FindElementDelegate(matrix) from Task_3_6
        // create and use method RemoveRows(matrix, findMax, findMin)
        RemoveRows(ref matrix, FindMax, FindMin);

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

    static void EvenOddRowsTransform(int[,] matrix, ReplaceMaxElement replaceMaxElementOdd, ReplaceMaxElement replaceMaxElementEven)
    {
        int rows = matrix.GetLength(0);
        for (int i = 0; i < rows; i++)
        {
            int idx = FindRowMaxIndex(matrix, i);
            if (i % 2 != 0)
                replaceMaxElementEven(matrix, i, idx);
            else
                replaceMaxElementOdd(matrix, i, idx);
        }
    }

    public void Task_3_27(int[,] A, int[,] B)
    {
        // code here

        // create and use public delegate ReplaceMaxElement(matrix, rowIndex, max);
        // use ReplaceMaxElementOdd(matrix) from Task_2_27
        // use ReplaceMaxElementEven(matrix) from Task_2_27
        // create and use method EvenOddRowsTransform(matrix, replaceMaxElementOdd, replaceMaxElementEven);

        EvenOddRowsTransform(A, ReplaceMaxElementOdd, ReplaceMaxElementEven);
        EvenOddRowsTransform(B, ReplaceMaxElementOdd, ReplaceMaxElementEven);

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
