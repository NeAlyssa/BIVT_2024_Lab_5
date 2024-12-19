using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Numerics;
using System.Reflection;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class Program
{
    public static void Main()
    {
        Program program = new Program();
    }
    void PrintMatrix(int[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
    #region Level 1
    public long Task_1_1(int n, int k)
    {
        // code here
        static long Combination(int n, int k)
        {
            if (n == 0 || k == 0) return 0;
            long C = (long)Factorial(n) / ((Factorial(k) * Factorial(n - k)));
            return C;
        }
        static int Factorial(int n)
        {
            if (n == 0) return 0;
            int fact = 1;
            for (int i = 1; i <= n; i++)
            {
                fact *= i;
            }
            return fact;
        }
        if (n < k || n < 0 || k < 0) return 0;
        long C = Combination(n, k);
        // create and use Combinations(n, k);
        // create and use Factorial(n);
        // end
        return C;
    }

    public int Task_1_2(double[] first, double[] second)
    {
        int answer = 0;
        // code here
        // create and use GeronArea(a, b, c);
        double GeronArea(double a, double b, double c)
        {
            double S = Math.Sqrt(Perimetr(a, b, c) * (Perimetr(a, b, c) - a) * (Perimetr(a, b, c) - b) * (Perimetr(a, b, c) - c));
            return S;
        }
        double Perimetr(double a, double b, double c)
        {
            double p = (a + b + c) / 2;
            return p;
        }
        double a1 = first[0];
        double a2 = first[1];
        double a3 = first[2];
        double b1 = second[0];
        double b2 = second[1];
        double b3 = second[2];
        if (a1 >= a2 + a3 || a2 >= a1 + a3 || a3 >= a2 + a1 || a1 <= 0 || a2 <= 0 || a3 <= 0) return -1;
        if (b1 >= b2 + b3 || b2 >= b1 + b3 || b3 >= b2 + b1 || b1 <= 0 || b2 <= 0 || b3 <= 0) return -1;
        double S1 = GeronArea(a1, a2, a3);
        double S2 = GeronArea(b1, b2, b3);
        if (S1 > S2) answer = 1;
        else if (S2 > S1) answer = 2;
        else answer = 0;
        // end
        //first = 1, second = 2, equal = 0, error = -1
        return answer;
    }

    public int Task_1_3a(double v1, double a1, double v2, double a2, int time)
    {
        // code here
        if (v1 < 0 || v2 < 0 || a1 < 0 || a2 < 0 || time < 0) return 0;
        int answer = 0;
        double S1 = 0;
        double S2 = 0;
        S1 = GetDistance(v1, a1, time);
        S2 = GetDistance(v2, a2, time);
        // create and use GetDistance(v, a, t); t - hours
        if (S1 > S2) return 1;
        if (S2 > S1) return 2;
        // end
        // first = 1, second = 2, equal = 0
        return answer;
    }
    double GetDistance(double v, double a, int time)
    {
        double S = v * time + a * time * time / 2;
        return S;
    }
    public int Task_1_3b(double v1, double a1, double v2, double a2)
    {
        int answer = 0;
        // code here
        for (int i = 1; ; i++)
        {
            double S1 = GetDistance(v1, a1, i);
            double S2 = GetDistance(v2, a2, i);
            if (S2 >= S1)
            {
                answer = i;
                break;
            }
        }
        // use GetDistance(v, a, t); t - hours
        // end
        return answer;
    }
    #endregion

    #region Level 2
    public void Task_2_1(int[,] A, int[,] B)
    {
        // code here
        if (A.GetLength(0) != 5 || A.GetLength(1) != 6 || B.GetLength(0) != 3 || B.GetLength(1) != 5) return;
        int row1, row2, column1, column2;
        FindMaxIndex(A, out row1, out column1);
        FindMaxIndex(B, out row2, out column2);
        int temp = A[row1, column1];
        A[row1, column1] = B[row2, column2];
        B[row2, column2] = temp;
        // create and use FindMaxIndex(matrix, out row, out column);
        // end
    }
    void FindMaxIndex(int[,] matrix, out int MaxRow, out int MaxColumn)
    {
        int max = matrix[0, 0];
        int row = -1;
        int column = -1;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] > max)
                {
                    max = matrix[i, j];
                    row = i;
                    column = j;
                }
            }
        }
        MaxRow = row;
        MaxColumn = column;
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
        if (B.GetLength(0) != 5 || B.GetLength(1) != 5 || C.GetLength(0) != 6 || C.GetLength(1) != 6) return;
        int imax1 = FindDiagonalMaxIndex(B);
        int imax2 = FindDiagonalMaxIndex(C);
        //  create and use method FindDiagonalMaxIndex(matrix);
        int[,] B2 = new int[B.GetLength(0) - 1, B.GetLength(1)];
        int[,] C2 = new int[C.GetLength(0) - 1, C.GetLength(1)];
        for (int i = 0; i < imax1; i++)
        {
            for (int j = 0; j < B2.GetLength(1); j++)
            {
                B2[i, j] = B[i, j];
            }
        }
        for (int i = imax1; i < B2.GetLength(0); i++)
        {
            for (int j = 0; j < B2.GetLength(1); j++)
            {
                B2[i, j] = B[i + 1, j];
            }
        }
        for (int i = 0; i < imax2; i++)
        {
            for (int j = 0; j < C2.GetLength(1); j++)
            {
                C2[i, j] = C[i, j];
            }
        }
        for (int i = imax2; i < C2.GetLength(0); i++)
        {
            for (int j = 0; j < C2.GetLength(1); j++)
            {
                C2[i, j] = C[i + 1, j];
            }
        }
        B = B2;
        C = C2;
        // end
    }
    int FindDiagonalMaxIndex(int[,] matrix)
    {
        int[] temp = new int[matrix.GetLength(0)];
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            temp[i] = matrix[i, i];
        }
        int max = temp[0];
        int imax = -1;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            if (temp[i] > max)
            {
                max = temp[i];
                imax = i;
            }
        }
        return imax;
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
        if (A.GetLength(0) != 4 || A.GetLength(1) != 6 || B.GetLength(0) != 6 || B.GetLength(1) != 6) return;
        int rowIndex1 = -1;
        int rowIndex2 = -1;
        FindMaxInColumn(A, 0, out rowIndex1);
        FindMaxInColumn(B, 0, out rowIndex2);
        int[] temp = new int[A.GetLength(1)];
        for (int i = 0; i < A.GetLength(1); i++)
        {
            temp[i] = A[rowIndex1, i];
        }
        for (int i = 0; i < A.GetLength(1); i++)
        {
            A[rowIndex1, i] = B[rowIndex2, i];
        }
        for (int i = 0; i < A.GetLength(1); i++)
        {
            B[rowIndex2, i] = temp[i];
        }
        // create and use FindMaxInColumn(matrix, columnIndex, out rowIndex)
        // end
    }
    void FindMaxInColumn(int[,] matrix, int columnIndex, out int rowIndex)
    {
        rowIndex = -1;
        int max = matrix[0, 0];
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            if (matrix[i, columnIndex] > max)
            {
                max = matrix[i, columnIndex];
                rowIndex = i;
            }
        }
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
        if (B.GetLength(0) != 4 || B.GetLength(1) != 5 || C.GetLength(0) != 5 || C.GetLength(1) != 6) return;
        int rowIndex = -1;
        int columnIndex = -1;
        int count = 0;
        int tempIndex = -1;
        for (int i = 0; i < B.GetLength(0); i++)
        {
            tempIndex = CountRowPositive(B, i);
            if (tempIndex > count)
            {
                count = tempIndex;
                columnIndex = i;
            }
        }
        tempIndex = -1;
        count = 0;
        for (int i = 0; i < B.GetLength(1); i++)
        {
            tempIndex = CountColumnPositive(C, i);
            if (tempIndex > count)
            {
                count = tempIndex;
                rowIndex = i;
            }
        }
        int[] temp = new int[C.GetLength(0)];
        for (int i = 0; i < C.GetLength(0); i++)
        {
            temp[i] = C[i, columnIndex];
        }
        int[,] B2 = new int[B.GetLength(0) + 1, B.GetLength(1)];
        for (int i = 0; i <= rowIndex; i++)
        {
            for (int j = 0; j < B2.GetLength(1); j++)
            {
                B2[i, j] = B[i, j];
            }
        }
        for (int i = 0; i < B2.GetLength(1); i++)
        {
            B2[rowIndex + 1, i] = temp[i];
        }
        for (int i = rowIndex + 1; i < B.GetLength(0); i++)
        {
            for (int j = 0; j < B.GetLength(1); j++)
            {
                B2[i + 1, j] = B[i, j];
            }
        }
        B = B2;
        // create and use CountRowPositive(matrix, rowIndex);
        // create and use CountColumnPositive(matrix, colIndex);
        // end
    }
    int CountRowPositive(int[,] matrix, int rowIndex)
    {
        int count = 0;
        for (int i = 0; i < matrix.GetLength(1); i++)
        {
            if (matrix[rowIndex, i] > 0)
            {
                count++;
            }
        }
        return count;
    }
    int CountColumnPositive(int[,] matrix, int columnIndex)
    {
        int count = 0;
        for (int j = 0; j < matrix.GetLength(0); j++)
        {
            if (matrix[j, columnIndex] > 0)
            {
                count++;
            }
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
        // code here
        /*if (A.GetLength(0) != 6 || A.GetLength(1) != 5 || C.GetLength(0) != 7 || C.GetLength(1) != 4) return null;*/
        int[] temp1 = new int[A.GetLength(1)];
        temp1 = SumPositiveElementsInColumns(A);
        int[] temp2 = new int[C.GetLength(1)];
        temp2 = SumPositiveElementsInColumns(C);
        int[] answer = new int[temp1.Length + temp2.Length];
        for (int i = 0; i < temp1.Length; i++)
        {
            answer[i] = temp1[i];
        }
        for (int i = 0; i < temp2.Length; i++)
        {
            answer[i + temp1.Length] = temp2[i];
        }
        // create and use SumPositiveElementsInColumns(matrix);
        // end
        return answer;
    }
    int[] SumPositiveElementsInColumns(int[,] matrix)
    {
        int[] temp = new int[matrix.GetLength(1)];
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            int count = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, j] > 0)
                {
                    count += matrix[i, j];
                }
            }
            temp[j] = count;
        }
        return temp;
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
        if (A == null || B == null) return;
        int row1, row2, column1, column2;
        FindMaxIndex(A, out row1, out column1);
        FindMaxIndex(B, out row2, out column2);
        int temp = A[row1, column1];
        A[row1, column1] = B[row2, column2];
        B[row2, column2] = temp;
        // use FindMaxIndex(matrix, out row, out column); from Task_2_1
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
        int imin = -1, min = matrix[0, 0];
        int imax = -1, max = matrix[0, 0];
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] < min)
                {
                    min = matrix[i, j];
                    imin = i;
                }
            }
        }
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] > max)
                {
                    max = matrix[i, j];
                    imax = i;
                }
            }
        }
        matrix = RemoveRow(matrix, imin);
        if (imin < imax)
        {
            matrix = RemoveRow(matrix, imax - 1);
        }
        else if (imin > imax)
        {
            matrix = RemoveRow(matrix, imax);
        }
        // create and use RemoveRow(matrix, rowIndex);
        // end
    }
    int[,] RemoveRow(int[,] matrix, int rowIndex)
    {
        int[,] M = new int[matrix.GetLength(0) - 1, matrix.GetLength(1)];
        for (int i = 0; i < rowIndex; i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                M[i, j] = matrix[i, j];
            }
        }
        for (int i = rowIndex; i < M.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                M[i, j] = matrix[i + 1, j];
            }
        }
        return M;
    }
    public void Task_2_14(int[,] matrix)
    {
        // code here

        // create and use SortRow(matrix, rowIndex);

        // end
    }

    public int Task_2_15(int[,] A, int[,] B, int[,] C)
    {
        // code here
        if (A == null || B == null || C == null) return 0;
        int answer = 0;
        int[] temp = new int[3];
        temp[0] = GetAverageWithoutMinMax(A);
        temp[1] = GetAverageWithoutMinMax(B);
        temp[2] = GetAverageWithoutMinMax(C);
        if (temp[0] < temp[1] && temp[1] < temp[2]) answer = 1;
        else if (temp[0] > temp[1] && temp[1] > temp[2]) answer = -1;
        else answer = 0;
        // create and use GetAverageWithoutMinMax(matrix);
        // end
        // 1 - increasing   0 - no sequence   -1 - decreasing
        return answer;
    }
    int GetAverageWithoutMinMax(int[,] matrix)
    {
        int max = matrix[0, 0], imax = -1, jmax = -1;
        int min = matrix[0, 0], imin = -1, jmin = -1;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] > max)
                {
                    max = matrix[i, j];
                    imax = i;
                    jmax = j;
                }
            }
        }
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] < min)
                {
                    min = matrix[i, j];
                    imin = i;
                    jmin = j;
                }
            }
        }
        int count = 0;
        int sum = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (i == imax && j == jmax) continue;
                else if (i == imin && j == jmin) continue;
                else
                {
                    sum += matrix[i, j];
                    count++;
                }
            }
        }
        sum /= count;
        return sum;
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
        A = SortRowsByMaxElement(A);
        B = SortRowsByMaxElement(B);
        // create and use SortRowsByMaxElement(matrix);
        // end
    }
    int[,] SortRowsByMaxElement(int[,] matrix)
    {
        int[] temp = new int[matrix.GetLength(0)];
        int[] tempind = new int[matrix.GetLength(0)];
        int[,] M = new int[matrix.GetLength(0), matrix.GetLength(1)];
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            int max = matrix[i, 0];
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] > max)
                {
                    max = matrix[i, j];
                }
            }
            temp[i] = max;
            tempind[i] = i;
        }
        for (int i = 0; i < temp.Length; i++)
        {
            for (int j = 0; j < temp.Length - 1 - i; j++)
            {
                if (temp[j] < temp[j + 1])
                {
                    (temp[j], temp[j + 1]) = (temp[j + 1], temp[j]);
                    (tempind[j], tempind[j + 1]) = (tempind[j + 1], tempind[j]);
                }
            }
        }
        for (int j = 0; j < M.GetLength(0); j++)
        {
            for (int i = 0; i < M.GetLength(1); i++)
            {
                M[j, i] = matrix[tempind[j], i];
            }
        }
        for (int i = 0; i < M.GetLength(0); i++)
        {
            for (int j = 0; j < M.GetLength(1); j++)
            {
                matrix[i, j] = M[i, j];
            }
        }
        return matrix;
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
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] == 0)
                {
                    matrix = RemoveRow(matrix, i);
                }
            }
        }
        // use RemoveRow(matrix, rowIndex); from 2_13
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
        // code here
        answerA = CreateArrayFromMins(A);
        answerB = CreateArrayFromMins(B);
        // create and use CreateArrayFromMins(matrix);
        // end
    }
    int[] CreateArrayFromMins(int[,] matrix)
    {
        int[] temp = new int[matrix.GetLength(0)];
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            int min = matrix[i, i];
            for (int j = i; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] < min)
                {
                    min = matrix[i, j];
                }
            }
            temp[i] = min;
        }
        return temp;
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
        A = MatrixValuesChange(A);
        B = MatrixValuesChange(B);
        // create and use MatrixValuesChange(matrix);
        // end
    }
    double[,] MatrixValuesChange(double[,] matrix)
    {
        double[] temp = new double[matrix.GetLength(0) * matrix.GetLength(1)];
        int count = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                temp[count] = matrix[i, j];
                count++;
            }
        }
        for (int i = 0; i < temp.Length; i++)
        {
            for (int j = 0; j < temp.GetLength(0) - 1 - i; j++)
            {
                if (temp[j] < temp[j + 1])
                {
                    (temp[j], temp[j + 1]) = (temp[j + 1], temp[j]);
                }
            }
        }
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] == temp[0] || matrix[i, j] == temp[1] || matrix[i, j] == temp[2] || matrix[i, j] == temp[3] || matrix[i, j] == temp[4])
                {
                    if (matrix[i, j] > 0)
                    {
                        matrix[i, j] *= 2;
                    }
                    else
                    {
                        matrix[i, j] /= 2;
                    }
                }
                else
                {
                    if (matrix[i, j] > 0)
                    {
                        matrix[i, j] /= 2;
                    }
                    else
                    {
                        matrix[i, j] *= 2;
                    }
                }
            }
        }
        return matrix;
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
        // code here
        maxA = FindRowWithMaxNegativeCount(A);
        maxB = FindRowWithMaxNegativeCount(B);
        // create and use FindRowWithMaxNegativeCount(matrix);
        // in FindRowWithMaxNegativeCount create and use CountNegativeInRow(matrix, rowIndex); like in 2_22 а я нечетные решаю:)
        // end
    }
    int FindRowWithMaxNegativeCount(int[,] matrix)
    {
        int[] temp = new int[matrix.GetLength(0)];
        int[] tempind = new int[matrix.GetLength(0)];
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            int count = 0;
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] < 0)
                {
                    count++;
                }
            }
            temp[i] = count;
            tempind[i] = i;
        }
        for (int i = 0; i < temp.Length; i++)
        {
            for (int j = 0; j < temp.Length - 1 - i; j++)
            {
                if (temp[j] < temp[j + 1])
                {
                    (temp[j], temp[j + 1]) = (temp[j + 1], temp[j]);
                    (tempind[j], tempind[j + 1]) = (tempind[j + 1], tempind[j]);
                }
            }
        }
        return tempind[0];
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
        A = ReplaceMaxElementOdd(A);
        A = ReplaceMaxElementEven(A);
        B = ReplaceMaxElementOdd(B);
        B = ReplaceMaxElementEven(B);
        // create and use FindRowMaxIndex(matrix, rowIndex, out columnIndex);
        // create and use ReplaceMaxElementOdd(matrix, row, column);
        // create and use ReplaceMaxElementEven(matrix, row, column);
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
    /*public delegate double SumFunction(double x);
    public delegate double YFunction(double x);
    // Делегат для вычисления члена суммы
    public static void GetSumAndY(SumFunction sFunction, YFunction yFunction, double a, double b, double h)
    {
        for (double x = a; x <= b; x += h)
        {
            double sum = sFunction(x);
            double y = yFunction(x);
        }
    }
    // Член первой суммы: 1 + Σ cos(ix) / i!
    public static double FirstSum(double x)
    {
        double sum = 1;
        int i = 1;
        double slag;
        while(true)
        { 
            slag = Math.Cos(i * x) / Factorial(i);
            if (slag <= 0.0001)
            {
                break;
            }
            else
            {
                sum += slag;
                i++;
            }
        }
        return sum;
    }
    // Первая функция Y: y = e^(cos(x)) * cos(sin(x))
    public static double FirstY(double x)
    {
        return Math.Exp(Math.Cos(x)) * Math.Cos(Math.Sin(x));
    }
    // Член второй суммы: Σ (-1)^i * cos(ix) / i^2
    public static double SecondSum(double x)
    {
        double sum = 0;
        int i = 1;
        double slag;
        while(true)
        {
            slag = Math.Pow(-1, i) * Math.Cos(i * x) / (i * i);
            if (sum <= 0.0001)
            {
                break;
            }
            else
            {
                sum += slag;
                i++;
            }
        } 
        return sum;
    }
    // Вторая функция Y: y = (x^2 - π^2 / 3) / 4
    public static double SecondY(double x)
    {
        return (x * x - Math.PI * Math.PI / 3) / 4;
    }
    // Метод для вычисления факториала
    public static double Factorial(int n)
    {
        double result = 1;
        for (int i = 1; i <= n; i++)
        {
            result *= i;
        }
        return result;
    }*/
    public delegate double SumFunction(double x);
    public delegate double YFunction(double x);

    // Делегат для вычисления члена суммы
    public static double[,] GetSumAndY(SumFunction sFunction, YFunction yFunction, double a, double b, double h)
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
    public static double FirstSum(double x)
    {
        double sum = 1;
        int i = 1;
        double slag;
        while (true)
        {
            slag = Math.Cos(i * x) / Factorial(i);
            if (Math.Abs(slag) <= 0.0001) 
            {
                break;
            }
            sum += slag;
            i++;
        }
        return sum;
    }

    public static double FirstY(double x)
    {
        return Math.Exp(Math.Cos(x)) * Math.Cos(Math.Sin(x));
    }

    public static double SecondSum(double x)
    {
        double sum = 0;
        int i = 1;
        double slag;
        while (true)
        {
            slag = Math.Pow(-1, i) * Math.Cos(i * x) / (i * i);
            if (Math.Abs(slag) <= 0.0001) 
            {
                break;
            }
            sum += slag;
            i++;
        }
        return sum;
    }
    public static double SecondY(double x)
    {
        return (x * x - Math.PI * Math.PI / 3) / 4;
    }

    public static double Factorial(int n)
    {
        double result = 1;
        for (int i = 1; i <= n; i++)
        {
            result *= i;
        }
        return result;
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
    static double CalculateAverage(double[] array)
    {
        double sum = 0;
        foreach (int x in array)
        {
            sum += x;
        }
        return sum / array.Length;
    }
    static void SwapRight(double[] array)
    {
        for (int i = 0; i < array.Length - 1; i += 2)
        {
            double temp = array[i];
            array[i] = array[i + 1];
            array[i + 1] = temp;
        }
    }
    static void SwapLeft(double[] array)
    {
        for (int i = array.Length - 1; i > 0; i -= 2)
        {
            double temp = array[i];
            array[i] = array[i - 1];
            array[i - 1] = temp;
        }
    }
    static double GetSum(double[] array)
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
        if (array.Length == 0 || array == null) return 0;
        // SwapDirection swapper = default(SwapDirection); - uncomment me
        // code here
        double average = CalculateAverage(array);
        SwapDirection swapMethod = array[0] > average ? SwapRight : SwapLeft;
        swapMethod(array);
        double answer = GetSum(array);
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
        int count = 0;
        double timeY = yfunction(a);
        for (double x = a + h; x <= b; x += h)
        {
            double prTime = yfunction(x);
            if (timeY * prTime < 0)
            {
                count++;
            }
            if (prTime != 0)
            {
                timeY = prTime;
            }
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
    public static int FindMax(int[,] matrix)
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
    public static int FindMin(int[,] matrix)
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
    public static int[,] RemoveRows(int[,] matrix, FindElementDelegate findMax, FindElementDelegate findMin)
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
