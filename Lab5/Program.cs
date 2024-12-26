using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public int Factorial(int n)
    {
        if (n == 1) return 1;
        return n * Factorial(n - 1);
    }
    public int Combinations(int n, int k)
    {
        return Factorial(n) / (Factorial(k) * Factorial(n - k));
    }
    public long Task_1_1(int n, int k)
    {
        long answer = 0;

        // code here
        if (n < 0 || k < 0 || k>n) return 0;
        answer = Combinations(n, k);
       
        // create and use Combinations(n, k);
        // create and use Factorial(n);

        // end

        return answer;
    }
    double GeronArea(double a, double b, double c)
    {
        double p = (a + b + c) / 2;
        double s = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        return s;
    }
    public int Task_1_2(double[] first, double[] second)
    {
        int answer = 0;

        // code here
        int n=first.Length; int m=second.Length;
        if (n != 3 || m != 3) return -1;
        double a1 = first[0], b1 = first[1], c1 = first[2], a2 = second[0], b2 = second[1], c2 = second[2];
        if (a1 >= b1 + c1 || b1 >= a1 + c1 || c1 >= a1 + b1 || a2 >= b2 + c2 || b2 >= a2 + c2 || c2 >= a2 + b2) return -1;
        double S1 = GeronArea(a1, b1, c1);
        double S2 = GeronArea(a2, b2, c2);
        if (S2 < S1)
        {
            answer = 1;
        }
        else if (S1 < S2)
        {
            answer = 2;
        }
        
        // create and use GeronArea(a, b, c);

        // end

        // first = 1, second = 2, equal = 0, error = -1
        return answer;
    }
    double GetDistance(double v, double a, int t)
    {
        double s;
        s = v * t + a * t * t / 2;
        return s;
    }
    public int Task_1_3a(double v1, double a1, double v2, double a2, int time)
    {
        int answer = 0;

        // code here
        double s1, s2, k = 0;
        if (time <= 0 || v1 <= 0 || v2 <= 0 || a1 <= 0 || a2 <= 0) return -1;
        s1 = GetDistance(v1, a1, time);
        s2 = GetDistance(v2, a2, time);
        if (s1 > s2) answer = 1;
        else if (s1 < s2) answer = 2;
        // create and use GetDistance(v, a, t); t - hours
        // end

        // first = 1, second = 2, equal = 0
        return answer;
    }

    public int Task_1_3b(double v1, double a1, double v2, double a2)
    {
        int answer = 1;

        // code here
        for (int t = 1; ; t++)
        {
            double s1 = GetDistance(v1, a1, t);
            double s2 = GetDistance(v2, a2, t);

            if (s1 <= s2)
            {
                return t;
            }
        }
        // use GetDistance(v, a, t); t - hours

        // end

        //return answer;
    }
    #endregion
    public void FindMaxIndex(int[,] matrix, out int row, out int column)
    {
        int max = int.MinValue;
        row = -1; column = -1;
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
    #region Level 2
    public void Task_2_1(int[,] A, int[,] B)
    {
        // code here
        int row, column;
        int arow, brow, acolumn, bcolumn;
        FindMaxIndex(A, out arow, out acolumn);
        //arow = row;
        //acolumn = column;
        FindMaxIndex(B, out brow, out bcolumn);
        //brow = row;
        //bcolumn = column;
        int temp;
        temp = A[arow, acolumn];
        A[arow, acolumn] = B[brow, bcolumn];
        B[brow, bcolumn] = temp;
        // create and use FindMaxIndex(matrix, out row, out column);

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
        int max = int.MinValue, row = -1, col = -1, ans = -1;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (max < matrix[i, j])
                {
                    max = matrix[i, j];
                    row = i; col = j;
                }
            }
            if (row == col) ans = row;
        }
        return row;
    }
    public void remove(ref int[,] matrix, int index)
{
    int[,] matrix2 = new int[matrix.GetLength(0) - 1, matrix.GetLength(1)];
    for (int i = 0; i < matrix2.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (i < index)
                matrix2[i, j] = matrix[i, j];
            else
            {
                matrix2[i, j] = matrix[i + 1, j];
            }
        }
    }
    matrix = matrix2;
}
    public void Task_2_3(ref int[,] B, ref int[,] C)
    {
        // code here
        //int[,] newB = new int[B.GetLength(0) - 1, B.GetLength(1)];
//int[,] newC = new int[C.GetLength(0) - 1, C.GetLength(1)];
int brow, crow;
brow = FindDiagonalMaxIndex(B);
crow = FindDiagonalMaxIndex(C);
//for (int i = 0; i < 4; i++)
//{
//    for (int j = 0; j < 5; j++)
//    {
//        if (i < brow) newB[i, j] = B[i, j];
//        else newB[i, j] = B[i + 1, j];
//    }
//}
//for (int i = 0; i < 5; i++)
//{
//    for (int j = 0; j < 6; j++)
//    {
//        if (i < crow) newC[i, j] = C[i, j];
//        else newC[i, j] = C[i + 1, j];
//    }
//}
remove(ref B, brow);
remove(ref C, crow);

//B = newB;
//C = newC;
        //  create and use method FindDiagonalMaxIndex(matrix);

        // end
    }

    public void Task_2_4(int[,] A, int[,] B)
    {
        // code here

        //  create and use method FindDiagonalMaxIndex(matrix); like in Task_2_3

        // end
    }
    int FindMaxInColumn(int[,] matrix, int columnIndex, out int rowIndex)
    {
        int maxValue = matrix[0, columnIndex];
        rowIndex = 0;

        for (int i = 1; i < matrix.GetLength(0); i++)
        {
            if (matrix[i, columnIndex] > maxValue)
            {
                maxValue = matrix[i, columnIndex];
                rowIndex = i;
            }
        }

        return maxValue;
    }
    public void Task_2_5(int[,] A, int[,] B)
    {
        // code here
        int rowA, rowB, f=0;
        int maxA = FindMaxInColumn(A, f, out rowA);
        int maxB = FindMaxInColumn(B, f, out rowB);
        int m = A.GetLength(1);
        for (int j = 0; j < m; j++)
        {
            int temp = A[rowA, j];
            A[rowA, j] = B[rowB, j];
            B[rowB, j] = temp;
        }
        // create and use FindMaxInColumn(matrix, columnIndex, out rowIndex);

        // end
    }

    public void Task_2_6(ref int[] A, int[] B)
    {
        // code here

        // create and use FindMax(matrix, out row, out column); like in Task_2_1
        // create and use DeleteElement(array, index);

        // end
    }
    int CountRowPositive(int[,] matrix, int rowIndex)
    {
        int result = 0;
        int m = matrix.GetLength(1);
        for (int j = 0; j < m; j++)
        {
            if (matrix[rowIndex, j] > 0) result++;
        }
        return result;
    }

    int CountColumnPositive(int[,] matrix, int colIndex)
    {
        int result = 0;
        int n = matrix.GetLength(0);
        for (int i = 0; i < n; i++)
        {
            if (matrix[i, colIndex] > 0) result++;
        }
        return result;
    }
    public void Task_2_7(ref int[,] B, int[,] C)
    {
        // code here
        int maxBValue = -1;
        int maxBIndex = -1;
        for (int i = 0; i < 4; i++)
        {
            if (CountRowPositive(B, i) > maxBValue)
            {
                maxBValue = CountRowPositive(B, i);
                maxBIndex = i;
            }
        }
        int maxCValue = -1;
        int maxCIndex = -1;
        for (int j = 0; j < 6; j++)
        {
            if (CountColumnPositive(C, j) > maxCValue)
            {
                maxCValue = CountColumnPositive(C, j);
                maxCIndex = j;
            }
        }
        int[,] resultB = new int[5, 5];
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (i <= maxBIndex) resultB[i, j] = B[i, j];
                else if (i == maxBIndex + 1) resultB[i, j] = C[j, maxCIndex];
                else resultB[i, j] = B[i - 1, j];
            }
        }
        B = resultB;
        // create and use CountRowPositive(matrix, rowIndex);
        // create and use CountColumnPositive(matrix, colIndex);

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
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            int summa = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, j] > 0)
                {
                    summa += matrix[i, j];
                }
            }
            answer[j] = summa;
        }
        return answer;
    }
    public int[] Task_2_9(int[,] A, int[,] C)
    {
        int[] answer = default(int[]);

        // code here
       
        // Create a result array with the combined length
        answer = new int[A.GetLength(1) + C.GetLength(1)];
        // create and use SumPositiveElementsInColumns(matrix);
        int[] array1 = SumPositiveElementsInColumns(A);
        int[] array2 = SumPositiveElementsInColumns(C);

        for (int i = 0; i < array1.Length; i++)
            answer[i] = array1[i];
        for (int i = 0; i < array2.Length; i++)
            answer[i + array1.Length] = array2[i];

        // create and use SumPositiveElementsInColumns(matrix);

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
        int maxRowA, maxColA, maxRowB, maxColB;
        FindMaxIndex(A, out maxRowA, out maxColA);
        FindMaxIndex(B, out maxRowB, out maxColB);
        int maxA, maxB;
        maxA = A[maxRowA, maxColA];
        maxB = B[maxRowB, maxColB];
        A[maxRowA, maxColA] = maxB;
        B[maxRowB, maxColB] = maxA;
        // use FindMaxIndex(matrix, out row, out column); from Task_2_1
//        В двух заданных матрицах найти максимальные элементы и поменять их местами.
//Поиск максимального элемента матрицы оформить в виде метода.
        // end
    }
    public void Task_2_12(int[,] A, int[,] B)
    {
        // code here

        // create and use FindMaxColumnIndex(matrix);

        // end
    }
    void RemoveRow(ref int[,] matrix, int rowIndex)
    {
        int n = matrix.GetLength(0);
        int m = matrix.GetLength(1);
        int[,] newMatrix = new int[n - 1, m];
        int k = 0;
        for (int i = 0; i < n; i++)
        {
            if (i == rowIndex) continue;
            for (int j = 0; j < m; j++)
            {
                newMatrix[k, j] = matrix[i, j];
            }
            k++;
        }

        matrix = newMatrix;
    }
    public void Task_2_13(ref int[,] matrix)
    {
        // code here
        int maxRow = 0, minRow = 0;
        int max = matrix[0, 0], min = matrix[0, 0];
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] > max)
                {
                    max = matrix[i, j];
                    maxRow = i;
                }
                if (matrix[i, j] < min)
                {
                    min = matrix[i, j];
                    minRow = i;
                }
            }
        }
        if (maxRow == minRow) RemoveRow(ref matrix, maxRow);
        else
        {
            if (maxRow > minRow)
            {
                RemoveRow(ref matrix, maxRow);
                RemoveRow(ref matrix, minRow);
            }
            else
            {
                RemoveRow(ref matrix, minRow);
                RemoveRow(ref matrix, maxRow);
            }
        }
        // create and use RemoveRow(matrix, rowIndex);

        // end
    }

    public void Task_2_14(int[,] matrix)
    {
        // code here

        // create and use SortRow(matrix, rowIndex);

        // end
    }
    double GetAverageWithoutMinMax(int[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        int totalElements = rows * cols;
        if (totalElements <= 2) return 0;
        int min = int.MaxValue, max = int.MinValue, sum = 0;
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                int value = matrix[i, j];
                sum += value;
                if (value < min) min = value;
                if (value > max) max = value;
            }
        }
        sum -= (min + max);
        int answer= sum / (totalElements - 2);
        return answer;
    }
    public int Task_2_15(int[,] A, int[,] B, int[,] C)
    {
        int answer = 0;

        // code here
        double avgA = GetAverageWithoutMinMax(A);
        double avgB = GetAverageWithoutMinMax(B);
        double avgC = GetAverageWithoutMinMax(C);
        // Determine the sequence: 1 - increasing, -1 - decreasing, 0 - no sequence
        if (avgA < avgB && avgB < avgC) answer = 1; 
        else if (avgA > avgB && avgB > avgC) answer = -1;
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
    void SortRowsByMaxElement(int[,] matrix)
    {
        int n = matrix.GetLength(0);
        int m = matrix.GetLength(1);
        int maxRowJ;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                int maxRowI = matrix[i, 0];
                for (int col = 1; col < m; col++)
                {
                    if (matrix[i, col] > maxRowI) maxRowI = matrix[i, col];
                }
                maxRowJ = matrix[j, 0];
                for (int col = 1; col < m; col++)
                {
                    if (matrix[j, col] > maxRowJ) maxRowJ = matrix[j, col];
                }
                if (maxRowI < maxRowJ)
                {
                    for (int col = 0; col < m; col++)
                    {
                        int temp = matrix[i, col];
                        matrix[i, col] = matrix[j, col];
                        matrix[j, col] = temp;
                    }
                }
            }
        }
    }
    public void Task_2_17(int[,] A, int[,] B)
    {
        // code here
        SortRowsByMaxElement(A);
        SortRowsByMaxElement(B);
        // create and use SortRowsByMaxElement(matrix);

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
        if (matrix == null || matrix.GetLength(0) == 0) return;
        for (int i = matrix.GetLength(0) - 1; i >= 0; i--)
        {
            int f = 0; 
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] == 0)
                {
                    f = 1; 
                    break;
                }
            }
            if (f==1)
            {
                RemoveRow(ref matrix, i);
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
    int[] CreateArrayFromMins(int[,] matrix)
    {
        int n = matrix.GetLength(0);
        int m = matrix.GetLength(1);
        int[] result = new int[n];
        int min = int.MaxValue;
        for (int i = 0; i < n; i++)
        {
            min = int.MaxValue;
            for (int j = i; j < m; j++)
            {
                if (matrix[i, j] < min) min = matrix[i, j];
            }
            result[i] = min;
        }

        return result;
    }
    public void Task_2_21(int[,] A, int[,] B, out int[] answerA, out int[] answerB)
    {
        answerA = null;
        answerB = null;

        // code here
        answerA = CreateArrayFromMins(A);
        answerB = CreateArrayFromMins(B);
        // create and use CreateArrayFromMins(matrix);

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
    void MatrixValuesChange(double[,] matrix)
    {
        double[] top5 = new double[5];
        double t=0;
        int n=matrix.GetLength(0);
        int m=matrix.GetLength(1);
        for (int i = 0; i < 5; i++)
        {
            top5[i] = double.MinValue;
        }
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                t = matrix[i, j];
                for (int q = 0; q < top5.Length; q++)
                {
                    if (t > top5[q])
                    {
                        for (int k = 4; k > q; k--) top5[k] = top5[k - 1];
                        top5[q] = t;
                        break;
                    }
                }
            }
        }
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                 int f = 0;
                for (int k = 0; k < top5.Length; k++)
                {
                    if (matrix[i, j] == top5[k])
                    {
                        f = 1;
                        break;
                    }
                }

                if (f==1 && matrix[i, j]>0) matrix[i, j] *= 2;
                else if (f == 1 && matrix[i, j] < 0) matrix[i, j] /= 2;
                else if (f == 0 && matrix[i, j] > 0) matrix[i, j] /= 2;
                else if (f == 0 && matrix[i, j] < 0) matrix[i, j] *= 2;
            }
        }
    }

    public void Task_2_23(double[,] A, double[,] B)
    {
        // code here
        MatrixValuesChange(A);
        MatrixValuesChange(B);
        // create and use MatrixValuesChange(matrix);
        //        В двух заданных матрицах по пять наибольших элементов увеличить вдвое,
        //остальные вдвое уменьшить. Преобразование матрицы оформить в виде метода.

        // end
    }

    public void Task_2_24(int[,] A, int[,] B)
    {
        // code here

        // use FindMaxIndex(matrix, out row, out column); like in 2_1
        // create and use SwapColumnDiagonal(matrix, columnIndex);

        // end
    }
    int CountRowNegative(int[,] matrix, int rowIndex)
    {
        int result = 0, m = matrix.GetLength(1);
        for (int j = 0; j < m; j++)
        {
            if (matrix[rowIndex, j] < 0)
            {
                result++;
            }
        }
        return result;
    }

    int FindMaxNegativeRow(int[,] matrix)
    {
        int n = matrix.GetLength(0);

        int max = -1, row = -1;

        for (int i = 0; i < n; i++)
        {
            if (CountRowNegative(matrix, i) > max)
            {
                max = CountRowNegative(matrix, i);
                row = i;
            }
        }

        return row;
    }
    public void Task_2_25(int[,] A, int[,] B, out int maxA, out int maxB)
    {
        maxA = 0;
        maxB = 0;

        // code here
        maxA = FindMaxNegativeRow(A);
        maxB = FindMaxNegativeRow(B);
        // create and use FindRowWithMaxNegativeCount(matrix);
        // in FindRowWithMaxNegativeCount create and use CountNegativeInRow(matrix, rowIndex); like in 2_22

        // end
    }

    public void Task_2_26(int[,] A, int[,] B)
    {
        // code here

        // create and use FindRowWithMaxNegativeCount(matrix); like in 2_25
        // in FindRowWithMaxNegativeCount use CountNegativeInRow(matrix, rowIndex); from 2_22

        // end
    }
    public int FindRowMaxIndex(int[,] matrix, int rowIndex)
    {
        int m = matrix.GetLength(1);

        int max = int.MinValue;
        int maxi = -1;

        for (int j = 0; j < m; j++)
        {
            if (matrix[rowIndex, j] > max)
            {
                max = matrix[rowIndex, j];
                maxi = j;
            }
        }
        return maxi;
    }

    public void ReplaceMaxElementEven(int[,] matrix)
    {
        int n = matrix.GetLength(0);
        int m = matrix.GetLength(1);
        int row = -1;
        for (int i = 1; i < n; i += 2)
        {
            row = FindRowMaxIndex(matrix, i);
            for (int j = 0; j < m; j++)
            {
                if (matrix[i, j] == matrix[i, row])
                {
                    matrix[i, j] = 0;
                }
            }
        }
    }
    public void ReplaceMaxElementOdd(int[,] matrix)
    {
        int n = matrix.GetLength(0);
        int m = matrix.GetLength(1);
        int row = -1;
        for (int i = 0; i < n; i += 2)
        {
            row = FindRowMaxIndex(matrix, i);

            for (int j = 0; j < m; j++)
            {
                if (matrix[i, j] == matrix[i, row])
                    matrix[i, j] *= j + 1;
            }
        }

    }
    public void Task_2_27(int[,] A, int[,] B)
    {
        // code here
        ReplaceMaxElementEven(A);
        ReplaceMaxElementOdd(A);

        ReplaceMaxElementEven(B);
        ReplaceMaxElementOdd(B);
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
    public delegate double YFunction(double x, double a, double b, double h);
    public double FirstYFunction(double x, double a, double b, double h)
    {
        return Math.Exp(Math.Cos(x)) * Math.Cos(Math.Sin(x));
    }
    public double SecondYFunction(double x, double a, double b, double h)
    {
        return (x * x - Math.PI * Math.PI / 3) / 4;
    }
    public delegate double SumFunction(double x, double a, double b, double h);
    public double FirstSumTerm(double x, double a, double b, double h)
    {
        double sum = 1;
        double element = Math.Cos(x);
        for (int i = 2; Math.Abs(element) > 0.0001; i++)
        {
            sum += element;
            element = Math.Cos(x * i) / Factorial(i);
        }
        return sum;
    }
    public double SecondSumTerm(double x, double a, double b, double h)
    {
        double sum = 0;
        int k = -1;
        double element = k * Math.Cos(x);
        for (int i = 2; Math.Abs(element) > 0.0001; i++)
        {
            sum += element;
            k = -1*k;
            element = k * Math.Cos(x * i) / (i * i);
        }
        return sum;
    }
    public double[,] GetSumAndY(SumFunction sFunction, YFunction yFunction, double a, double b, double h)
    {
        double[,] answer = new double[(int)((b - a) / h) + 1, 2];
        int k = 0;
        for (double x = a; Math.Round(x, 2) <= b; x += h)
        {
            double sum = sFunction(x, a, b, h);
            double y = yFunction(x, a, b, h);
            answer[k, 0] = sum;
            answer[k, 1] = y;
            k++;
        }
        return answer;
    }
    #region Level 3
    public void Task_3_1(ref double[,] firstSumAndY, ref double[,] secondSumAndY)
    {
        // code here
        double a1 = 0.1, b1 = 1, h1 = 0.1;
        firstSumAndY = GetSumAndY(FirstSumTerm, FirstYFunction, a1, b1, h1);

        double a2 = Math.PI / 5, b2 = Math.PI, h2 = Math.PI / 25;
        secondSumAndY = GetSumAndY(SecondSumTerm, SecondYFunction, a2, b2, h2);

       
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
        foreach (int n in array)
        {
            sum += n;
        }
        return sum / array.Length;
    }
    public void SwapLeft(double[] array)
    {
        for (int i = 0; i < array.Length - 1; i += 2)
        {
            double temp = array[i];
            array[i] = array[i + 1];
            array[i + 1] = temp;
        }
    }
    public void SwapRight(double[] array)
    {
        for (int i = array.Length - 1; i > 0; i -= 2)
        {
            double temp = array[i];
            array[i] = array[i - 1];
            array[i - 1] = temp;
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
        double answer = 0;
        SwapDirection swapper = default(SwapDirection);

        // code here
        if (array == null || array.Length == 0) return 0;

        double average = CalculateAverage(array);
        if (array[0] > average) swapper = SwapLeft;  
        else swapper = SwapRight; 
        swapper(array);
        answer = GetSum(array);

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
    public double ur1(double x, double a, double b, double h)
    {
        double answer = x *x - Math.Sin(x);
        return answer;
    }
    public double ur2(double x, double a, double b, double h)
    {
        double answer = Math.Exp(x) - 1;
        return answer;
    }
    public int CountSignFlips(YFunction y, double a, double b, double h)
    {
        int count = 1;
        double y2 = y(a, a, b, h),k;
        for (double x = a + h; x <= b; x += h)
        {
            if (y(a, a, b, h) == 0) continue;
            k = y(x, a, b, h);
            if (y2 > 0 && k < 0 || y2 < 0 && k > 0) count++;
            y2 = k;
        }
        return count;
    }

    public void Task_3_5(out int func1, out int func2)
    {
        func1 = 0;
        func2 = 0;

        // code here
        func1 = CountSignFlips(ur1, 0, 2, 0.1);
        func2 = CountSignFlips(ur2, -1, 1, 0.2);
       
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
    public void Task_3_7(ref int[,] B, int[,] C)
    {
        // code here
        CountPositive countPositive = CountRowPositive;
        int max = -1, maxin = -1, max2 = -1, maxin2 = -1;
        for (int i = 0; i < 4; i++)
        {
            if (countPositive(B, i) > max)
            {
                max = countPositive(B, i);
                maxin = i;
            }
        }
        countPositive = CountColumnPositive;
        
        for (int j = 0; j < 6; j++)
        {
            if (countPositive(C, j) > max2)
            {
                max2 = countPositive(C, j);
                maxin2 = j;
            }
        }
        int[,] resultB = new int[5, 5];

        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (i <= maxin)
                {
                    resultB[i, j] = B[i, j];
                }
                else if (i == maxin + 1)
                {
                    resultB[i, j] = C[j, maxin2];
                }
                else
                {
                    resultB[i, j] = B[i - 1, j];
                }
            }
        }

        B = resultB;
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
    public delegate void FindElementDelegate(int[,] matrix, out int foundI, out int foundJ);

    public void RemoveRows(ref int[,] matrix, FindElementDelegate findElementDelegate1, FindElementDelegate findElementDelegate2)
    {
        int row1, col1, row2, col2;
        findElementDelegate1(matrix, out row1, out col1);
        findElementDelegate2(matrix, out row2, out col2);

        RemoveRow(ref matrix, row1);

        if (row2 < row1)
        {
            RemoveRow(ref matrix, row2);
        }
        else if (row2 > row1)
        {
            RemoveRow(ref matrix, row2 - 1);
        }
    }
    public void FindMax(int[,] matrix, out int row, out int column)
    {
        int max = int.MinValue;
        row = -1; column = -1;
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
    public void FindMin(int[,] matrix, out int row, out int column)
    {
        int min = int.MaxValue;
        row = -1; column = -1;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] < min)
                {
                    min = matrix[i, j];
                    row = i;
                    column = j;
                }
            }
        }
    }
    public void Task_3_13(ref int[,] matrix)
    {
        // code here
        RemoveRows(ref matrix, FindMax, FindMin);
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
    public delegate void ReplaceMaxElement(int[,] matrix);

    public void EvenOddRowsTransform(int[,] matrix, ReplaceMaxElement replaceMaxElement1, ReplaceMaxElement replaceMaxElement2)
    {
        replaceMaxElement1(matrix);
        replaceMaxElement2(matrix);
    }
    //void ReplaceMaxElementEven1(int[,] matrix, int row, int column)
    //{
    //    matrix[row, column] = 0;
    //}
    //void ReplaceMaxElementOdd1(int[,] matrix, int row, int column)
    //{
    //    matrix[row, column] *= column;
    //}
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
