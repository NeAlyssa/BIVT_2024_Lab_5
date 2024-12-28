using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    }
    #region Level 1
    public long Task_1_1(int n, int k)
    {
        long answer = 0;

        // code here

        // create and use Combinations(n, k);
        // create and use Factorial(n);
        answer = Factorial(n) / (Factorial(k) * Factorial(n - k));

        // end

        return answer;
    }
    int Factorial(int n)
    {
        if (n <= 1) return 1;
        return n * Factorial(n - 1);
    }
    public int Task_1_2(double[] first, double[] second)
    {
        int answer = 0;

        // code here

        // create and use GeronArea(a, b, c);
        
        double s1, s2;
        s1 = GeronArea(first[0], first[1], first[2]);
        s2 = GeronArea(second[0], second[1], second[2]);
        if (!exist(first[0], first[1], first[2]) || !exist(second[0], second[1], second[2]))
        {
            answer = -1;
        }
        else if (s1 > s2)
        {
            answer = 1;
        }
        else if (s2 > s1)
        {
            answer = 2;
        }
        else if (s1 == s2)
        {
            answer = 0;
        }
        // end

        // first = 1, second = 2, equal = 0, error = -1
        return answer;
    }
    double GeronArea(double a, double b, double c)
    {
        double p = (a + b + c) / 2;
        double s = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        return s;
    }
    bool exist(double a, double b, double c)
    {
        if (a + b > c && b + c > a && a + c > b)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public int Task_1_3a(double v1, double a1, double v2, double a2, int time)
    {
        int answer = 0;

        // code here

        // create and use GetDistance(v, a, t); t - hours
        
        if (v1 < 0 || a1 < 0 || v2 < 0 || a2 < 0 || time < 0) return 0;
        double s1 = 0;
        double s2 = 0;
        s1 = GetDistance(v1, a1, time);
        s2 = GetDistance(v2, a2, time);
        if (s1 > s2)
        {
            return 1;
        }
        if (s2 > s1)
        {
            return 2;
        }
        // end

        // first = 1, second = 2, equal = 0
        return answer;
    }
    double GetDistance(double v, double a, int t)
    {
        double s = v * t + a * t * t / 2;
        return s;
    }

    public int Task_1_3b(double v1, double a1, double v2, double a2)
    {
        int answer = 0;

        // code here

        // use GetDistance(v, a, t); t - hours
        
        for (int i = 1; ; i++)
        {
            double s1 = GetDistance(v1, a1, i);
            double s2 = GetDistance(v2, a2, i);
            if (s2 >= s1)
            {
                answer = i;
                break;
            }
        }
        // end

        return answer;
        }
    #endregion

    #region Level 2
    void FindMaxIndex(int[,] matrix, out int row, out int column)
    {
        int max = matrix[0, 0];
        row = 0;
        column = 0;
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
    }
    public void Task_2_1(int[,] A, int[,] B)
    {
        // code here

        // create and use FindMaxIndex(matrix, out row, out column);
        
        if (A.GetLength(0) != 5 || A.GetLength(1) != 6 || B.GetLength(0) != 3 || B.GetLength(1) != 5)
        {
           return;
        }
        int row1, column1, row2, column2;
        FindMaxIndex(A, out row1, out column1);
        FindMaxIndex(B, out row2, out column2);
        int temp = A[row1, column1];
        A[row1, column1] = B[row2, column2];
        B[row2, column2] = temp;
        // end
    }

    public void Task_2_2(double[] A, double[] B)
    {
        // code here

        // create and use FindMaxIndex(array);
        // only 1 array has to be changed!

        // end
    }
    int FindDiagonalMaxIndex(int[,] matrix)
    {
        int max = matrix[0, 0];
        int imax = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (i == j && matrix[i, j] > max)
                {
                    max = matrix[i, j];
                    imax = i;
                }
            }
        }
        return imax;
    }
    void Del(ref int[,] matrix)
    {
        int imax = FindDiagonalMaxIndex(matrix);
        int[,] newmatrix = new int[matrix.GetLength(0) - 1, matrix.GetLength(1)];
        for (int i = 0; i < imax; i++)
        {
            for (int j = 0; j < newmatrix.GetLength(1); j++)
            {
                newmatrix[i, j] = matrix[i, j];
            }
        }
        for (int i = imax; i < newmatrix.GetLength(0); i++)
        {
            for (int j = 0; j < newmatrix.GetLength(1); j++)
            {
                newmatrix[i, j] = matrix[i + 1, j];
            }
        }
        matrix = newmatrix;
    }
    public void Task_2_3(ref int[,] B, ref int[,] C)
    {
        // code here

        //  create and use method FindDiagonalMaxIndex(matrix);
        
        if (B.GetLength(0) != 5 || B.GetLength(1) != 5 || C.GetLength(0) != 6 || C.GetLength(1) != 6)
        {
            return;
        }
        Del(ref B);
        Del(ref C);
        // end
    }

    public void Task_2_4(int[,] A, int[,] B)
    {
        // code here

        //  create and use method FindDiagonalMaxIndex(matrix); like in Task_2_3

        // end
    }
    void FindMaxInColumn(int[,] matrix, int columnIndex, out int rowIndex)
    {
        rowIndex = 0;
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
    public void Task_2_5(int[,] A, int[,] B)
    {
        // code here

        // create and use FindMaxInColumn(matrix, columnIndex, out rowIndex);
        
        if (A.GetLength(0) != 4 || A.GetLength(1) != 6 || B.GetLength(0) != 6 || B.GetLength(1) != 6)
        {
            return;
        }
        int rowIndexA = 0;
        int rowIndexB = 0;
        FindMaxInColumn(A, 0, out rowIndexA);
        FindMaxInColumn(B, 0, out rowIndexB);
        int[] temp = new int[A.GetLength(1)];
        for (int j = 0; j < A.GetLength(1); j++)
        {
            temp[j] = A[rowIndexA, j];
        }
        for (int j = 0; j < A.GetLength(1); j++)
        {
            A[rowIndexA, j] = B[rowIndexB, j];
        }
        for (int j = 0; j < A.GetLength(1); j++)
        {
            B[rowIndexB, j] = temp[j];
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
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (matrix[rowIndex, j] > 0)
            {
                count++;
            }
        }
        return count;
    }
    public int CountColumnPositive(int[,] matrix, int columnIndex)
    {
        int count = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            if (matrix[i, columnIndex] > 0)
            {
                count++;
            }
        }
        return count;
    }
    public void Task_2_7(ref int[,] B, int[,] C)
    {
        // code here

        // create and use CountRowPositive(matrix, rowIndex);
        // create and use CountColumnPositive(matrix, colIndex);

        if (B.GetLength(0) != 4 || B.GetLength(1) != 5 || C.GetLength(0) != 5 || C.GetLength(1) != 6)
        {
            return;
        }
        int rowIndex = 0;
        int columnIndex = 0;
        int count = 0;
        int tempIndex = 0;
        for (int i = 0; i < B.GetLength(0); i++)
        {
            tempIndex = CountRowPositive(B, i);
            if (tempIndex > count)
            {
                count = tempIndex;
                columnIndex = i;
            }
        }
        tempIndex = 0;
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
        int[,] B1 = new int[B.GetLength(0) + 1, B.GetLength(1)];
        for (int i = 0; i <= rowIndex; i++)
        {
            for (int j = 0; j < B1.GetLength(1); j++)
            {
                B1[i, j] = B[i, j];
            }
        }
        for (int i = 0; i < B1.GetLength(1); i++)
        {
            B1[rowIndex + 1, i] = temp[i];
        }
        for (int i = rowIndex + 1; i < B.GetLength(0); i++)
        {
            for (int j = 0; j < B.GetLength(1); j++)
            {
                B1[i + 1, j] = B[i, j];
            }
        }
        B = B1;
        // end
    }

    public void Task_2_8(int[] A, int[] B)
    {
        // code here

        // create and use SortArrayPart(array, startIndex);

        // end
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
    public int[] Task_2_9(int[,] A, int[,] C)
    {
        int[] answer = default(int[]);

        // code here

        // create and use SumPositiveElementsInColumns(matrix);
        
        int[] temp1 = new int[A.GetLength(1)];
        temp1 = SumPositiveElementsInColumns(A);
        int[] temp2 = new int[C.GetLength(1)];
        temp2 = SumPositiveElementsInColumns(C);
        answer = new int[temp1.Length + temp2.Length];
        for (int i = 0; i < temp1.Length; i++)
        {
            answer[i] = temp1[i];
        }
        for (int i = 0; i < temp2.Length; i++)
        {
            answer[i + temp1.Length] = temp2[i];
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
        
        int row1, column1, row2, column2;
        FindMaxIndex(A, out row1, out column1);
        FindMaxIndex(B, out row2, out column2);
        int temp = A[row1, column1];
        A[row1, column1] = B[row2, column2];
        B[row2, column2] = temp;
        //end
    }
    public void Task_2_12(int[,] A, int[,] B)
    {
        // code here

        // create and use FindMaxColumnIndex(matrix);

        // end
    }
    int[,] RemoveRow(int[,] matrix, int rowIndex)
    {
        int[,] a = new int[matrix.GetLength(0) - 1, matrix.GetLength(1)];
        for (int i = 0; i < rowIndex; i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                a[i, j] = matrix[i, j];
            }
        }
        for (int i = rowIndex; i < a.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                a[i, j] = matrix[i + 1, j];
            }
        }
        return a;
    }
    public void Task_2_13(ref int[,] matrix)
    {
        // code here

        // create and use RemoveRow(matrix, rowIndex);
        
        int max = matrix[0, 0];
        int min = matrix[0, 0];
        int imax = 0;
        int imin = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j <  matrix.GetLength(1); j++)
            {
                if (max < matrix[i, j])
                {
                    max = matrix[i, j];
                    imax = i; 
                }
                if (min > matrix[i, j])
                {
                    min = matrix[i, j];
                    imin = i;
                }
            }
        }
        matrix = RemoveRow(matrix, imax);
        if (imin < imax)
        {
            matrix = RemoveRow(matrix, imax - 1);
        }
        else if (imin > imax)
        {
            matrix = RemoveRow(matrix, imax);
        }
        // end
    }

    public void Task_2_14(int[,] matrix)
    {
        // code here

        // create and use SortRow(matrix, rowIndex);

        // end
    }
    int GetAverageWithoutMinMax(int[,] matrix)
    {
        int max = matrix[0, 0];
        int imax = 0;
        int jmax = 0;
        int min = matrix[0, 0];
        int imin = 0;
        int jmin = 0;
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
                if (matrix[i, j] > max)
                {
                    max = matrix[i, j];
                    imax = i;
                    jmax = j;
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
    public int Task_2_15(int[,] A, int[,] B, int[,] C)
    {
        int answer = 0;

        // code here

        // create and use GetAverageWithoutMinMax(matrix);
        
        int[] temp = new int[3];
        temp[0] = GetAverageWithoutMinMax(A);
        temp[1] = GetAverageWithoutMinMax(B);
        temp[2] = GetAverageWithoutMinMax(C);
        if (temp[0] < temp[1] && temp[1] < temp[2])
        {
            answer = 1;
        }
        else if (temp[0] > temp[1] && temp[1] > temp[2])
        {
            answer = -1;
        }
        else
        {
            answer = 0;
        }
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
    int[,] SortRowsByMaxElement(int[,] matrix)
    {
        int[] temp = new int[matrix.GetLength(0)];
        int[] tempind = new int[matrix.GetLength(0)];
        int[,] C = new int[matrix.GetLength(0), matrix.GetLength(1)];
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
        for (int i = 0; i < C.GetLength(0); i++)
        {
            for (int j = 0; j < C.GetLength(1); j++)
            {
                C[i, j] = matrix[tempind[i], j];
            }
        }
        for (int i = 0; i < C.GetLength(0); i++)
        {
            for (int j = 0; j < C.GetLength(1); j++)
            {
                matrix[i, j] = C[i, j];
            }
        }
        return matrix;
    }
    public void Task_2_17(int[,] A, int[,] B)
    {
        // code here

        // create and use SortRowsByMaxElement(matrix);
        
        A = SortRowsByMaxElement(A);
        B = SortRowsByMaxElement(B);
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
        // end
    }
    public void Task_2_20(ref int[,] A, ref int[,] B)
    {
        // code here

        // use RemoveColumn(matrix, columnIndex); from 2_10

        // end
    }
    int[] CreateArrayFromMins(int[,] matrix)
    {
        int[] temp = new int[matrix.GetLength(0)];
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            int min = 100000000;
            for (int j = i; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] < min)
                {
                    min = matrix[i, j];
                    temp[i] = min;
                }
            }
        }
        return temp;
    }
    public void Task_2_21(int[,] A, int[,] B, out int[] answerA, out int[] answerB)
    {

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
            for (int j = 0; j < temp.Length - i - 1; j++)
            {
                if (temp[j] < temp[j + 1])
                {
                    double p = temp[j];
                    temp[j] = temp[j + 1];
                    temp[j + 1] = p;
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
    public void Task_2_23(double[,] A, double[,] B)
    {
        // code here

        // create and use MatrixValuesChange(matrix);
        
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
    int FindRowWithMaxNegativeCount(int[,] matrix)
    {
        int[] temp = new int[matrix.GetLength(0)];
        int[] tempindex = new int[matrix.GetLength(0)];
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
            tempindex[i] = i;
        }
        for (int i = 0; i < temp.Length; i++)
        {
            for (int j = 0; j < temp.Length - i - 1; j++)
            {
                if (temp[j] < temp[j + 1])
                {
                    int p = temp[j];
                    temp[j] = temp[j + 1];
                    temp[j + 1] = p;
                    int s = tempindex[j];
                    tempindex[j] = tempindex[j + 1];
                    tempindex[j + 1] = s;
                }
            }
        }
        return tempindex[0];
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
    void FindRowMaxIndex(int[,] matrix, int rowIndex, out int columnIndex)
    {
        int max = matrix[rowIndex, 0];
        columnIndex = 0;
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (matrix[rowIndex, j] > max)
            {
                max = matrix[rowIndex, j];
                columnIndex = j;
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

        // create and use FindRowMaxIndex(matrix, rowIndex, out columnIndex);
        // create and use ReplaceMaxElementOdd(matrix, row, column);
        // create and use ReplaceMaxElementEven(matrix, row, column);
        
        A = ReplaceMaxElementOdd(A);
        B = ReplaceMaxElementOdd(B);
        A = ReplaceMaxElementEven(A);
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
    double[,] GetSumAndY(SumFunction sFunction, YFunction yFunction, double a, double b, double h)
    {
        double[,] matrix = new double[(int)((b - a) / h) + 1, 2];
        int index = 0;
        for (double i = a; i <= b + h / 10; i += h)
        {
            double s = sFunction(i);
            double y = yFunction(i);
            matrix[index, 0] = s;
            matrix[index, 1] = y;
            index++;
        }
        return matrix;
    }
    double FirstS(double x)
    {
        double s = 1;
        int i = 1;
        double fact = 1;
        double part;
        while (true)
        {
            part = Math.Cos(i * x) / fact;
            if (Math.Abs(part) <= 0.0001)
            {
                break;
            }
            s += part;
            i++;
            fact *= i;
        }
        return s;
    }
    double FirstY(double x)
    {
        return Math.Exp(Math.Cos(x)) * Math.Cos(Math.Sin(x));
    }
    double SecondS(double x)
    {
        double s = 0;
        double i = 1;
        double p = -1;
        double part;
        while (true)
        {
            part = p * Math.Cos(i * x) / (i * i);
            if (Math.Abs(part) <= 0.0001)
            {
                break;
            }
            s += part;
            p *= -1;
            i++;
        }
        return s;
    }
    public double SecondY(double x)
    {
        return (x * x - Math.PI * Math.PI / 3) / 4;
    }
    public void Task_3_1(ref double[,] firstSumAndY, ref double[,] secondSumAndY)
    {
        // code here

        // create and use public delegate SumFunction(x) and public delegate YFunction(x)
        // create and use method GetSumAndY(sFunction, yFunction, a, b, h);
        // create and use 2 methods for both functions calculating at specific x
        double a1 = 0.1, b1 = 1, h1 = 0.1;
        double a2 = Math.PI / 5, b2 = Math.PI, h2 = Math.PI / 25;
        firstSumAndY = GetSumAndY(FirstS, FirstY, a1, b1, h1);
        secondSumAndY = GetSumAndY(SecondS, SecondY, a2, b2, h2);
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
    void SwapRight(double[] array)
    {
        for (int i = 0; i < array.Length - 1; i += 2)
        {
            double temp = array[i];
            array[i] = array[i + 1];
            array[i + 1] = temp;
        }
    }
    void SwapLeft(double[] array)
    {
        for (int i = array.Length - 1; i > 0; i -= 2)
        {
            double temp = array[i];
            array[i] = array[i - 1];
            array[i - 1] = temp;
        }
    }
    double GetSum(double[] array)
    {
        double s = 0;
        for (int i = 1; i < array.Length; i += 2)
        {
            s += array[i];
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
        double sum = 0;
        foreach (int x in array)
        {
            sum += x;
        }
        double sr =  sum / array.Length;
        SwapDirection swapMethod = array[0] > sr ? SwapRight : SwapLeft;
        swapMethod(array);
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
    double Func1(double x)
    {
        return x * x - Math.Sin(x);
    }

    double Func2(double x)
    {
        return Math.Exp(x) - 1;
    }
    int CountSignFlips(YFunction yfunction, double a, double b, double h)
    {
        int count = 0;
        double znak1 = yfunction(a);
        for (double x = a + h; x <= b; x += h)
        {
            double znak2 = yfunction(x);
            if (znak1 * znak2 < 0)
            {
                count++;
            }
            if (znak2 != 0)
            {
                znak1 = znak2;
            }
        }
        return count;
    }
    public void Task_3_5(out int func1, out int func2)
    {
        func1 = 0;
        func2 = 0;

        // code here
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
    int[,] InsertColumn(int[,] matrixB, CountPositive CountRow, int[,] matrixC, CountPositive CountColumn)
    {
        int count1 = 0;
        int imax1 = 0;
        int maxcount1 = 0;
        for (int i = 0; i < matrixB.GetLength(0); i++)
        {
            count1 = CountRow(matrixB, i);
            if (count1 > maxcount1)
            {
                maxcount1 = count1;
                imax1 = i;
            }

        }
        int count2 = 0;
        int jmax2 = 0;
        int maxcount2 = 0;
        for (int j = 0; j < matrixC.GetLength(1); j++)
        {
            count2 = CountColumn(matrixC, j);
            if (count2 > maxcount2)
            {
                maxcount2 = count2;
                jmax2 = j;
            }
        }
        int[,] matrix = new int[matrixB.GetLength(0) + 1, matrixB.GetLength(1)];
        for (int i = 0; i <= imax1; i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                matrix[i,j] = matrixB[i, j];
            }
        }
        for (int j = 0; j < matrixB.GetLength(1); j++)
        {
            matrix[imax1 + 1, j] = matrixC[j, jmax2];
        }
        for (int i = imax1 + 2; i <  matrix.GetLength(0); i++)
        {
            for (int j = 0;j < matrix.GetLength(1); j++)
            {
                matrix[i, j] = matrixB[i - 1, j];
            }
        }
        return matrix;
    }
    public void Task_3_7(ref int[,] B, int[,] C)
    {
        // code here

        // create and use public delegate CountPositive(matrix, index);
        // use CountRowPositive(matrix, rowIndex) from Task_2_7
        // use CountColumnPositive(matrix, colIndex) from Task_2_7
        // create and use method InsertColumn(matrixB, CountRow, matrixC, CountColumn);
        B = InsertColumn(B, CountRowPositive, C, CountColumnPositive);
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
    int FindMax(int[,] matrix)
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
    int FindMin(int[,] matrix)
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
    int[,] RemoveRows(int[,] matrix, FindElementDelegate findMax, FindElementDelegate findMin)
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
        int[] row = new int[count];
        count = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] == max || matrix[i, j] == min)
                {
                    row[count] = i;
                    count++;
                    break;
                }
            }
        }
        int[,] newmatrix = new int[matrix.GetLength(0) - count, matrix.GetLength(1)];
        count = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            if (count < row.Length && i == row[count])
            {
                count++;
                continue;
            }
            else
            {
                for (int j = 0; j < newmatrix.GetLength(1); j++)
                {
                    newmatrix[i - count, j] = matrix[i, j];
                }
            }
        }
        return newmatrix;
    }
    public void Task_3_13(ref int[,] matrix)
    {
        // code here

        // use public delegate FindElementDelegate(matrix) from Task_3_6
        // create and use method RemoveRows(matrix, findMax, findMin)
        matrix = RemoveRows(matrix, FindMax, FindMin);
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
    void EvenOddRowsTransform(int[,] matrix, ReplaceMaxElement replaceMaxElementOdd, ReplaceMaxElement replaceMaxElementEven)
    {
        replaceMaxElementOdd(matrix);
        replaceMaxElementEven(matrix);
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
