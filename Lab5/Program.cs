using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
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
        int[,] B = new int[,] {
            { 1, 2, 3, 4, 5 },
            { 6, 7, 8, 9, 10 },
            { 11, 12, 13, 14, 15 },
            { -1, -2, -3, -4, -5 },
            { 6, 7, 8, 9, 0 }};
        int[,] C = new int[,] {
            { 1,    2,  3,  4,  5,  -1 },
            { 6,    7,  8,  9,  10, -2 },
            { 11,   12, 13, 14, 15, -3 },
            { -1,   -2, -3, -4, -5, -1 },
            { 6,    7,  8,  9,  20, -2 },
            { 1,    3,  3,  1,  5, 5 }};

        program.Task_2_17(B, C);
    }
    #region Level 1

    int Factorial(int n)
    {

        int answer = 1;
        for (int i = 1; i <= n; i++)
        {
            answer *= i;
        }

        return answer;
    }
    int Combination(int n, int k)
    {

        int answer = Factorial(n) / (Factorial(k) * Factorial(n - k));
        return answer;
    }
    public long Task_1_1(int n, int k)
    {
        long answer = 0;

        // code here
        answer = Combination(n, k);
        // end

        return answer;
    }
    public double GeronArea(double a, double b, double c)
    {

        // end
        if (a < b + c && b < a + c && c < a + b)
        {
            double p = (a + b + c) / 2;
            double s = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            return s;
        }
        else
        {
            return -1;
        }
    }
    public int Task_1_2(double[] first, double[] second)
    {
        int answer = 0;

        // code here
        double s1, s2;

        s1= GeronArea(first[0], first[1],first[2]);
        s2 = GeronArea(second[0], second[1], second[2]);
        if (s1 == -1 || s2 == -1) answer = -1;
        else if(s1 > s2) answer = 1;
        else if (s1 < s2) answer = 2;
        else if (s1 == s2) answer = 0;
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
        int answer=0;
        double s1,s2;
        s1 = GetDistance(v1, a1, time);
        s2 = GetDistance(v2, a2, time);
        if (s1 > s2)
        {
            answer = 1;
        }
        else if (s1 < s2)
        {
            answer = 2;
        }
        else if (s2 == s1)
        {
            answer = 0;
        }
        // code here

        // create and use GetDistance(v, a, t); t - hours

        // end

        // first = 1, second = 2, equal = 0
        return answer;
    }

    public int Task_1_3b(double v1, double a1, double v2, double a2)
    {
        int answer = 0;
        int time = 0;
        // code here
        double s1, s2;
        do
        {
            time++;
            s1 = GetDistance(v1, a1, time);
            s2 = GetDistance(v2, a2, time);
        } while (s1>s2);
        answer = time;
        // end

        return answer;
    }
    #endregion

    #region Level 2
    public void FindMaxIndex(int[,] matrix, out int row, out int col)
    {
        int max = int.MinValue;
        row = 0; col = 0;
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
    public void Task_2_1(int[,] A, int[,] B)
    {
        // code here
        int rowA, rowB, colA, colB, t;

        FindMaxIndex(A, out rowA, out colA);
        FindMaxIndex(B, out rowB, out colB);
        t = A[rowA, colA];
        A[rowA, colA] = B[rowB, colB];
        B[rowB, colB] = t;
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
        int ind = 0;
        int max = int.MinValue;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            if (max < matrix[i, i])
            {
                max = matrix[i, i];
                ind = i;
            }
        }
        return ind;
    }
    public void DeleteRow (ref int[,] A,int indA)
    {
        int[,] newA = new int[A.GetLength(0)-1, A.GetLength(1)];
        int n = 0;

        for (int i = 0; i < A.GetLength(0); i++)
        {
            if (indA != i)
            {
                for (int j = 0; j < A.GetLength(1); j++)
                {
                    newA[n, j] = A[i, j];

                }
                n++;
            }
        }
        A = newA;
    }

    public void Task_2_3(ref int[,] B, ref int[,] C)
    {
        // code here

        int indB = FindDiagonalMaxIndex(B);
        int indC = FindDiagonalMaxIndex(C);
        DeleteRow(ref B, indB);
        DeleteRow(ref C, indC);
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
        rowIndex = 0;
        int max = int.MinValue;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            if (matrix[i, columnIndex] > max)
            {
                max = matrix[i, columnIndex];
                rowIndex = i;
            }
        }
    }
    public void Task_2_5(int[,] A, int[,] B)
    {
        // code here
        int rowIndexA = 0, rowIndexB = 0,t;
        FindMaxInColumn(A, 0, out rowIndexA);
        FindMaxInColumn(B, 0, out rowIndexB);
        for (int i = 0; i < A.GetLength(1); i++)
        {
            t = A[rowIndexA, i];
            A[rowIndexA, i] = B[rowIndexB, i];
            B[rowIndexB, i] = t;
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
    public int CountColumnPositive(int[,] matrix, int colIndex)
    {
        int cnt = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            if (matrix[i, colIndex] > 0) cnt++;
        }
        return cnt;
    }
    public int CountRowPositive(int[,] matrix, int rowIndex)
    {
        int cnt = 0;
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if(matrix[rowIndex, j] > 0) cnt++;
        }
        return cnt;
    }
    public void Task_2_7(ref int[,] B, int[,] C)
    {
        // code here
        int rowIndex = 0, colIndex = 0, rowMax = 0, colMax = 0;
        int max = 0, cnt=0;
        for (int i = 0; i < B.GetLength(0); i++)
        {
            cnt = CountRowPositive(B, i);
            if (cnt > max)
            {
                max = cnt;
                rowMax = i;
            }
        }
        max = 0;
        for (int i = 0; i < C.GetLength(1); i++)
        {
            cnt = CountColumnPositive(C, i);
            if (cnt > max)
            {
                max = cnt;
                colMax = colIndex;
            }
        }

        int B0 = B.GetLength(0), B1 = B.GetLength(1),k=0;
        int[,] newB = new int[B0 + 1, B1];
        for (int i = 0; i < B0 + 1; i++)
        {
            if (i != rowMax + 1)
            {
                for (int j = 0; j < B1; j++)
                {
                    newB[i, j] = B[k, j];
                }
                k++;
            }
            else
            {
                for (int j = 0; j < B1; j++)
                {
                    newB[i, j] = C[j, colMax];
                }
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
        int[] a = new int[matrix.GetLength(1)];
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            int sum = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, j] > 0) sum += matrix[i, j];
            }
            a[j] = sum;
        }
        return a;

    }
    public int[] Task_2_9(int[,] A, int[,] C)
    {
        int[] answer = default(int[]);

        // code here
        answer = new int[A.GetLength(1) + C.GetLength(1)];
        int[] sumA = default(int[]), sumC = default(int[]);

        sumA = SumPositiveElementsInColumns(A);
        sumC = SumPositiveElementsInColumns(C);

        for (int i = 0; i < answer.Length; i++)
        {
            if (i < sumA.Length)
            {
                answer[i] += sumA[i];
            }
            else
            {
                answer[i] += sumC[i - sumA.Length];
            }
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
        int rowA = 0, rowB = 0, colA = 0, colB = 0,t;
        FindMaxIndex(A, out rowA, out colA);
        FindMaxIndex(B, out rowB, out colB);

        t = A[rowA, colA];
        A[rowA, colA] = B[rowB, colB];
        B[rowB, colB] = t;
        // end
    }
    public void Task_2_12(int[,] A, int[,] B)
    {
        // code here

        // create and use FindMaxColumnIndex(matrix);

        // end
    }

    public void FindMinIndex(int[,] matrix, out int row, out int col)
    {
        int min = int.MaxValue;
        row = 0; col = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] < min)
                {
                    min = matrix[i, j];
                    row = i;
                    col = j;
                }
            }
        }
    }
    public void RemoveRow(ref int[,] matrix, int row)
    {
        int m0 = matrix.GetLength(0), m1 = matrix.GetLength(1);
        int[,] t = new int[m0 - 1, m1];
        for (int i = 0; i < m0 - 1; i++)
        {
            if (i < row)
            {
                for (int j = 0; j < m1; j++)
                {
                    t[i, j] = matrix[i, j];
                }
            }
            else
            {
                for (int j = 0; j < m1; j++)
                {
                    t[i, j] = matrix[i + 1, j];
                }
            }
        }
        matrix = t;
    }
    public void Task_2_13(ref int[,] matrix)
    {
        // code here
        int rowMax = 0, colMax = 0, rowMin = 0, colMin = 0;
        FindMaxIndex(matrix, out rowMax, out colMax);
        FindMinIndex(matrix, out rowMin, out colMin);

        // end
        RemoveRow(ref matrix, rowMax);
        if (rowMax != rowMin)
        {
            if (rowMax < rowMin) rowMin--;
            RemoveRow(ref matrix, rowMin);
        }
        // end
    }

    public void Task_2_14(int[,] matrix)
    {
        // code here

        // create and use SortRow(matrix, rowIndex);

        // end
    }
    public int GetAverageWithoutMinMax(int[,] matrix)
    {
        int min = int.MaxValue, max = int.MinValue, sum = 0;
        int m0 = matrix.GetLength(0), m1 = matrix.GetLength(1);
        for (int i = 0; i < m0; i++)
        {
            for (int j = 0; j < m1; j++)
            {
                sum += matrix[i, j];
                if (max > matrix[i, j]) max = matrix[i, j];
                if (min < matrix[i, j]) min = matrix[i, j];
            }
        }
        return (sum - max - min) / (m0 * m1 - 2);
    }

    public int Task_2_15(int[,] A, int[,] B, int[,] C)
    {
        int answer = 0;

        // code here
        int[] average = new int[3];
        average[0] = GetAverageWithoutMinMax(A);
        average[1] = GetAverageWithoutMinMax(B);
        average[2] = GetAverageWithoutMinMax(C);
        if (average[0] > average[1] && average[1] > average[2]) answer = -1;
        else if (average[0] < average[1] && average[1] < average[2]) answer = 1;
        else answer = 0;

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

    public void SortRowsByMaxElement(ref int[,] A)
    {

        int a0= A.GetLength(0), a1= A.GetLength(1),t;
        int[] max = new int[a0];
        for (int i = 0; i < a0; i++)
        {
            max[i] = int.MinValue;
            for (int j = 0; j < a1; j++)
            {
                if (max[i]<A[i, j])
                {
                    max[i] = A[i, j];
                }
            }
            Console.WriteLine(max[i]);
        }

        for (int i = 0; i < a0-1; i++)
        {
            for (int j = 0; j < a0-1; j++)
            {
                if (max[j] < max[j + 1])
                {
                    t = max[j + 1];
                    max[j + 1] = max[j];
                    max[j] = t;
                    for (int k = 0; k < a1; k++)
                    {
                        t = A[j + 1, k];
                        A[j + 1, k] = A[j, k];
                        A[j, k] = t;
                    }
                }
            }
        }
        for (int i = 0; i < a0; i++)
        {
            
            for (int j = 0; j < a1; j++)
            {
                Console.Write(A[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
    public void Task_2_17(int[,] A, int[,] B)
    {
        // code here
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
        int cnt = matrix.GetLength(0);
        int[] nul = new int[cnt];
        bool flag = true;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            flag = true;
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] == 0)
                {
                    cnt--;
                    flag = false;
                    break;
                }
            }
            if (flag)
            {
                nul[i] = 1;
            }
        }
        for (int i = 0; i < nul.Length; i++)
        {
            if (nul[i] == 0)
            {
                RemoveRow(ref matrix, i);
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
    public int[] CreateArrayFromMins(int[,] A, int[] arr)
    {
        int a0 = A.GetLength(0),min;
        arr = new int[a0];
        for (int i = 0; i < a0; i++)
        {
            min = int.MaxValue;
            for (int j = i; j < a0; j++)
            {
                if (min > A[i, j]) min = A[i, j];
            }
            arr[i] = min;
        }
        return arr;
    }
    public void Task_2_21(int[,] A, int[,] B, out int[] answerA, out int[] answerB)
    {
        answerA = null;
        answerB = null;

        // code here
        answerA = CreateArrayFromMins(A, answerA);
        answerB = CreateArrayFromMins(B, answerB);
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

    public double[,] MatrixValuesChange(double[,] A)
    {
        int a0= A.GetLength(0), a1 = A.GetLength(1),t;
        double[] arr = new double[a0 * a1];
        int[][] ind = new int[a0 * a1][];
        for (int i = 0; i < a0; i++)
        {
            for (int j = 0; j < a1; j++)
            {
                arr[i * a1 + j] = A[i, j];
                ind[i * a1 + j] = new int[] { i, j };
            }
        }

        for (int i = 0; i < a0 * a1; i++)
        {
            for (int j = 0; j < (a0 * a1) - i - 1; j++)
            {
                if (arr[j] < arr[j + 1])
                {
                    (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
                    (ind[j], ind[j + 1]) = (ind[j + 1], ind[j]);
                }
            }
        }

        for (int i = 0; i < a0 * a1; i++)
        {
            int row = ind[i][0], col = ind[i][1];
            if (i < 5)
            {
                if (A[row,col] < 0) A[row,col] /= 2;
                else A[row, col] *= 2;
            }
            else
            {
                if (A[row, col] < 0) A[row, col] *= 2;
                else A[row, col] /= 2;
            }
        }
        return A;
    }

    public void Task_2_23(double[,] A, double[,] B)
    {
        // code here
        A = MatrixValuesChange(A);
        B = MatrixValuesChange(B);

        // end
    }

    public void Task_2_24(int[,] A, int[,] B)
    {
        // code here

        // use FindMaxIndex(matrix, out row, out column); like in 2_1
        // create and use SwapColumnDiagonal(matrix, columnIndex);

        // end
    }

    public int CountNegativeInRow(int[,] A, int row)
    {
        int answer = 0;
        for (int j = 0; j < A.GetLength(1); j++)
        {
            if (A[row, j] < 0) answer++;
        }
        return answer;
    }
    public int FindRowWithMaxNegativeCount(int[,] A)
    {
        int max = 0, t, answer = 0;
        for (int i = 0; i < A.GetLength(0); i++)
        {
            t = CountNegativeInRow(A, i);
            if (max < t)
            {
                max = t;
                answer = i;
            };
        }
        return answer;
    }

    public void Task_2_25(int[,] A, int[,] B, out int maxA, out int maxB)
    {
        maxA = 0;
        maxB = 0;

        // code here

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
    void FindRowMaxIndex(int[,] matrix, int rowIndex, out int columnIndex)
    {
        int max = matrix[rowIndex, 0];
        columnIndex = 0;
        for (int i = 0; i < matrix.GetLength(1); i++)
        {
            if (matrix[rowIndex, i] > max)
            {
                max = matrix[rowIndex, i];
                columnIndex = i;
            }
        }
    }
    int[,] ReplaceMaxElementOdd(int[,] matrix)
    {
        int j = 0;
        for (int i = 1; i < matrix.GetLength(0); i += 2)
        {
            FindRowMaxIndex(matrix, i, out j);
            matrix[i, j] = 0;
        }
        return matrix;
    }
    int[,] ReplaceMaxElementEven(int[,] matrix)
    {
        int j = 0;
        for (int i = 0; i < matrix.GetLength(0); i += 2)
        {
            FindRowMaxIndex(matrix, i, out j);
            matrix[i, j] *= (j + 1);
        }
        return matrix;
    }
    public void Task_2_27(int[,] A, int[,] B)
    {
        // code here
        int colInd = 0;
        A = ReplaceMaxElementOdd(A);
        A = ReplaceMaxElementEven(A);
        B = ReplaceMaxElementOdd(B);
        B = ReplaceMaxElementEven(B);
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

    public delegate double SumFunction(double x);
    public delegate double YFunction(double x);

    // Делегат для вычисления члена суммы
    public double[,] GetSumAndY(SumFunction sFunction, YFunction yFunction, double a, double b, double h)
    {
        double[,] A = new double[(int)((b - a) / h) + 1, 2];
        int ind = 0;
        for (double x = a; x <= b + h / 10; x += h)
        {
            double sum = sFunction(x);
            double y = yFunction(x);
            A[ind, 0] = sum;
            A[ind, 1] = y;
            ind++;
        }
        return A;
    }
    public double FirstSum(double x)
    {
        double sum = 1;
        int i = 1;
        double val;
        while (true)
        {
            val = Math.Cos(i * x) / (double)Factorial(i);
            if (Math.Abs(val) <= 0.0001)
            {
                break;
            }
            sum += val;
            i++;
        }
        return sum;
    }

    public double FirstY(double x)
    {
        return Math.Exp(Math.Cos(x)) * Math.Cos(Math.Sin(x));
    }

    public double SecondSum(double x)
    {
        double sum = 0;
        int i = 1;
        double val;
        while (true)
        {
            val = Math.Pow(-1, i) * Math.Cos(i * x) / (i * i);
            if (Math.Abs(val) <= 0.0001)
            {
                break;
            }
            sum += val;
            i++;
        }
        return sum;
    }
    public double SecondY(double x)
    {
        return (x * x - Math.PI * Math.PI / 3) / 4;
    }

    public void Task_3_1(ref double[,] firstSumAndY, ref double[,] secondSumAndY)
    {
        // code here
        double a1 = 0.1, b1 = 1, h1 = 0.1;
        double a2 = Math.PI / 5, b2 = Math.PI, h2 = Math.PI / 25;
        firstSumAndY = GetSumAndY(FirstSum, FirstY, a1, b1, h1);
        secondSumAndY = GetSumAndY(SecondSum, SecondY, a2, b2, h2);
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

        // end
    }
    public delegate void SwapDirection(double[] array);
    public double CalculateAverage(double[] array)
    {
        double sum = 0;
        foreach (int x in array)
        {
            sum += x;
        }
        return sum / array.Length;
    }
    public void SwapRight(double[] array)
    {
        for (int i = 0; i < array.Length - 1; i += 2)
        {
            double t = array[i];
            array[i] = array[i + 1];
            array[i + 1] = t;
        }
    }
    public void SwapLeft(double[] array)
    {
        for (int i = array.Length - 1; i > 0; i -= 2)
        {
            double t = array[i];
            array[i] = array[i - 1];
            array[i - 1] = t;
        }
    }
    public double GetSum(double[] array)
    {
        double sum = 0;
        for (int i = 1; i < array.Length; i += 2)
        {
            sum += array[i];
        }
        return sum;
    }
    public double Task_3_3(double[] array)
    {

        // code here
        if (array.Length == 0 || array == null) return 0;
        double average = CalculateAverage(array);
        SwapDirection swapMethod = array[0] > average ? SwapRight : SwapLeft;
        swapMethod(array);
        double answer = GetSum(array);
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
    public delegate double FunctionDelegate(double x);
    public double Func1(double x)
    {
        return x * x - Math.Sin(x);
    }

    public double Func2(double x)
    {
        return Math.Exp(x) - 1;
    }

    public int CountSignFlips(YFunction yfunction, double a, double b, double h)
    {
        int count =0;
        double last = yfunction(a);
        for (double x = a + h; x <= b; x += h)
        {
            double now = yfunction(x);
            if (last * now < 0)
            {
                count++;
            }
            if(now!=0)last = now;
           
        }
        return count;
    }
    public void Task_3_5(out int func1, out int func2)
    {
        // code here
        func1 = 0;
        func2 = 0;
        double a1 = 0, b1 = 2, h1 = 0.1;
        double a2 = -1, b2 = 1, h2 = 0.2;
        func1 = CountSignFlips(Func1, a1, b1, h1);
        func2 = CountSignFlips(Func2, a2, b2, h2);
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
    public delegate int CountPositive(int[,] matrix, int index);
    public int[,] InsertColumn(int[,] matrixB, CountPositive CountRow, int[,] matrixC, CountPositive CountColumn)
    {
        int count1 = 0;
        int imax = 0;
        int maxvalue = -1;
        for (int i = 0; i < matrixB.GetLength(0); i++)
        {
            count1 = CountRow(matrixB, i);
            if (count1 > maxvalue)
            {
                maxvalue = count1;
                imax = i;
            }
        }
        int count2 = 0;
        int jmax = 0;
        int maxvalueC = -1;
        for (int i = 0; i < matrixC.GetLength(1); i++)
        {
            count2 = CountColumn(matrixC, i);
            if (count1 > maxvalue)
            {
                maxvalueC = count2;
                jmax = i;
            }
        }
        int[,] matrixA = new int[matrixB.GetLength(0) + 1, matrixB.GetLength(1)];
        for (int i = 0; i < matrixB.GetLength(1); i++)
        {
            matrixA[imax + 1, i] = matrixC[i, jmax];
        }
        for (int i = 0; i <= imax; i++)
        {
            for (int j = 0; j < matrixA.GetLength(1); j++)
            {
                matrixA[i, j] = matrixB[i, j];
            }
        }
        for (int i = imax + 2; i < matrixA.GetLength(0); i++)
        {
            for (int j = 0; j < matrixA.GetLength(1); j++)
            {
                matrixA[i, j] = matrixB[i - 1, j];
            }
        }
        return matrixA;
    }
    public void Task_3_7(ref int[,] B, int[,] C)
    {
        // code here
        B = InsertColumn(B, CountRowPositive, C, CountColumnPositive);
        //B = InsertColumn(B, count1, C, count2);
        // create and use public delegate CountPositive(matrix, index);
        // use CountRowPositive(matrix, rowIndex) from Task_2_7
        // use CountColumnPositive(matrix, colIndex) from Task_2_7
        // create and use method InsertColumn(matrixB, CountRow, matrixC, CountColumn);
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

    public delegate int FindElementDelegate(int[,] matrix);
    public int FindMax(int[,] matrix)
    {
        int max = matrix[0, 0];
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] > max)
                {
                    max = matrix[i, j];
                }
            }
        }
        return max;
    }
    public int FindMin(int[,] matrix)
    {
        int min = matrix[0, 0];
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] < min)
                {
                    min = matrix[i, j];
                }
            }
        }
        return min;
    }
    public int[,] RemoveRows(int[,] matrix, FindElementDelegate findMax, FindElementDelegate findMin)
    {
        int max = findMax(matrix);
        int min = findMin(matrix);
        int count = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] == max || matrix[i, j] == min)
                {
                    count++;
                    break;
                }
            }
        }
        int[] rows = new int[count];
        count = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] == max || matrix[i, j] == min)
                {
                    rows[count] = i;
                    count++;
                    break;
                }
            }
        }
        int[,] A = new int[matrix.GetLength(0) - count, matrix.GetLength(1)];
        count = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            if (count < rows.Length && i == rows[count])
            {
                count++;
                continue;
            }
            else
            {
                for (int j = 0; j < A.GetLength(1); j++)
                {
                    A[i - count, j] = matrix[i, j];
                }
            }
        }
        return A;
    }

    public void Task_3_13(ref int[,] matrix)
    {
        // code here
        matrix = RemoveRows(matrix, FindMax, FindMin);
        // use public delegate FindElementDelegate(matrix) from Task_3_6
        // create and use method RemoveRows(matrix, findMax, findMin)
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
    public delegate int[,] ReplaceMaxElement(int[,] matrix);
    public void EvenOddRowsTransform(int[,] matrix, ReplaceMaxElement ReplaceMaxElementOdd, ReplaceMaxElement ReplaceMaxElementEven)
    {
        ReplaceMaxElementEven(matrix);
        ReplaceMaxElementOdd(matrix);
    }
    public void Task_3_27(int[,] A, int[,] B)
    {
        // code here

        EvenOddRowsTransform(A, ReplaceMaxElementOdd, ReplaceMaxElementEven);
        EvenOddRowsTransform(B, ReplaceMaxElementOdd, ReplaceMaxElementEven);
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
