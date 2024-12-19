using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data.SqlTypes;
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
    public static long Factorial(int n)
    {
        long fact = 1;
        for (int i = 1; i <= n; i++) fact *= i;
        return fact;
    }
    public static double GeronArea(double a, double b, double c)
    {
        double p = (a + b + c) / 2;
        return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
    }
    public static double GetDistance(double v, double a, double t)
    {
        return v * t + a * t * t / 2;
    }
    public static int FindMax(int[,] matrix)
    {
        int mx = int.MinValue;
        for (int i = 0; i < matrix.GetLength(0); i++) for (int j = 0; j < matrix.GetLength(1); j++) if (matrix[i, j] > mx) mx = matrix[i, j];
        return mx;
    }
    public static int FindDiagonalMax(int[,] matrix)
    {
        int mx = int.MinValue;
        for (int i = 0; i < matrix.GetLength(0); i++) if (matrix[i, i] > mx) mx = matrix[i, i];
        return mx;
    }
    public static int FindColumnMax(int[,] matrix, int col)
    {
        int mx = int.MinValue;
        for (int i = 0; i < matrix.GetLength(0); i++) if (matrix[i, col] > mx) mx = matrix[i, col];
        return mx;
    }
    public static void ShowMatrix(double[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++) Console.Write("{0} ", matrix[i, j]);
            Console.WriteLine();
        }
        Console.WriteLine();
    }
    public static int CountRowPositive(int[,] matrix, int rowIndex)
    {
        int mx = 0;
        for (int j = 0; j < matrix.GetLength(1); j++) if (matrix[rowIndex, j] > 0) mx++;
        return mx;
    }
    public static int CountColumnPositive(int[,] matrix, int colIndex)
    {
        int mx = 0;
        for (int i = 0; i < matrix.GetLength(0); i++) if (matrix[i, colIndex] > 0) mx++;
        return mx;
    }
    public static void SumPositiveElementsInColumns(int[,] matrix, out int[] columns)
    {
        columns = new int[matrix.GetLength(1)];
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            int s = 0;
            for (int i = 0; i < matrix.GetLength(0); i++) if (matrix[i, j] > 0) s += matrix[i, j];
            columns[j] = s;
        }
    }
    public static void RemoveRow(ref int[,] matrix, int rowIndex)
    {
        int[,] matrixNew = new int[matrix.GetLength(0) - 1, matrix.GetLength(1)];
        for (int i = 0, k = 0; i < matrix.GetLength(0); i++, k++)
        {
            if (i == rowIndex) { k--; continue; }
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                matrixNew[k, j] = matrix[i, j];
            }
        }
        matrix = matrixNew;
    }
    public static double GetAverageWithoutMinMax(int[,] matrix)
    {
        double avg, sum = 0, mn = int.MaxValue, mx = int.MinValue;
        for (int i = 0; i < matrix.GetLength(0); i++) for (int j = 0; j < matrix.GetLength(1); j++)
            {
                sum += matrix[i, j];
                if (mn > matrix[i, j]) mn = matrix[i, j];
                if (matrix[i, j] > mx) mx = matrix[i, j];
            }
        avg = (sum - mn - mx) / (matrix.GetLength(0) * matrix.GetLength(1) - 2);
        return avg;
    }
    public static int [,] SortRowsByMaxElement(int[,] matrix)
    {
        int[] maxes = new int[matrix.GetLength(0)], maxdexes = new int[matrix.GetLength(0)];
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            maxdexes[i] = i;
            maxes[i] = int.MinValue;
            for (int j = 0; j < matrix.GetLength(1); j++) if (matrix[i, j] > maxes[i]) maxes[i] = matrix[i, j];
        }
        for (int i = 0; i < maxes.Length; i++)
        {
            for (int j = 0; j < maxes.Length - 1 - i; j++)
            {
                if (maxes[j] < maxes[j + 1])
                {
                    int a = maxes[j], b = maxdexes[j];
                    maxes[j] = maxes[j + 1];
                    maxdexes[j] = maxdexes[j + 1];
                    maxes[j + 1] = a;
                    maxdexes[j + 1] = b;
                }
            }
        }
        int[,] matrixNew = new int[matrix.GetLength(0), matrix.GetLength(1)];
        for (int i = 0; i < matrix.GetLength(0); i++) for (int j = 0; j < matrix.GetLength(1); j++) matrixNew[i, j] = matrix[i, j];
        for (int i = 0; i < matrix.GetLength(0); i++) for (int j = 0; j < matrix.GetLength(1); j++) matrix[i, j] = matrixNew[maxdexes[i], j];
        return matrix;
    }
    public static void CreateArrayFromMins(int[,] matrix, out int[] array)
    {
        array = new int[matrix.GetLength(0)];
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            int mn = int.MaxValue;
            for (int j = i; j < matrix.GetLength(1); j++) if (mn > matrix[i, j]) mn = matrix[i, j];
            array[i] = mn;
        }
    }
    public static void SortArray(ref double[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            for (int j = 0; j < array.Length - i - 1; j++)
            {
                if (array[j] > array[j + 1])
                {
                    double a = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = a;
                }
            }
        }
    }
    public static bool To_Multiply(double[] array, double num)
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (num == array[i]) return true;
        }
        return false;
    }
    public static void MatrixValuesChange(ref double [,] matrix)
    {
        double[] to_change = new double[5];
        for (int i = 0; i < 5; i++) to_change[i] = double.MinValue;
        for (int i = 0; i < matrix.GetLength(0); i++) for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] > to_change[0])
                {
                    to_change[0] = matrix[i, j];
                    SortArray(ref to_change);
                }
            }
        for (int i = 0; i < to_change.Length; i++) Console.Write("{0} ", to_change[i]);
        for (int i = 0; i < matrix.GetLength(0); i++) for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (To_Multiply(to_change, matrix[i, j]))
                {
                    if (matrix[i, j] > 0) matrix[i, j] *= 2;
                    if (matrix[i, j] < 0) matrix[i, j] /= 2;
                } else
                {
                    if (matrix[i, j] < 0) matrix[i, j] *= 2;
                    if (matrix[i, j] > 0) matrix[i, j] /= 2;
                }
            }
    }
    public static int FindMaxNegativeRow(int[] array)
    {
        int mxdex = 0, mx = int.MinValue;
        for (int i = 0; i < array.Length; i++) if (array[i] > mx) { mx = array[i]; mxdex = i; }
        return mxdex;
    }
    public static void GetNegativeCountPerRow(int[,] matrix, out int[] array)
    {
        array = new int[matrix.GetLength(0)];
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            int count = 0;
            for (int j = 0; j < matrix.GetLength(1); j++) if (matrix[i, j] < 0) count++;
            array[i] = count;
        }
    }
    public static int FindRowMaxIndex(int[,] matrix, int row)
    {
        int mxdex = 0, mx = int.MinValue;
        for (int j = 0; j < matrix.GetLength(1); j++) if (matrix[row, j] > mx) { mx = matrix[row, j]; mxdex = j; }
        return mxdex;
    }
    public static void ReplaceMaxElementOdd(ref int[,] matrix, int row, int column)
    {
        matrix[row, column] = 0;
    }
    public static void ReplaceMaxElementEven(ref int[,] matrix, int row, int column)
    {
        matrix[row, column] *= (column + 1);
    }

    public delegate double SumFunction(double x);

    public delegate double YFunction(double x);
    public static double firstSum(double x)
    {
        double sum = 1;
        int i = 1;
        while (true)
        {
            double s = Math.Cos(i * x) / Factorial(i);
            if (Math.Abs(s) < 0.0001) break;
            sum += s;
            i++;
        }
        return sum;
    }
    public static double secondSum(double x)
    {
        double sum = 0;
        int i = 1, a = -1;
        while (true)
        {
            double s = a * Math.Cos(i * x) / (i * i);
            if (Math.Abs(s) < 0.0001) break;
            sum += s;
            i++;
            a *= -1;
        }
        return sum;
    }
    public static double firstY(double x)
    {
        return Math.Pow(Math.E, Math.Cos(x)) * Math.Cos(Math.Sin(x));
    }
    public static double secondY(double x)
    {
        return (x * x - Math.PI * Math.PI / 3) / 4;
    }
    public static void GetSumAndY(SumFunction sumFunction, YFunction yFunction, double a, double b, double h, ref double[,] SumAndY)
    {
        int i = 0;
        for (; a <= b; a = Math.Round(a + h, 7))
        {
            SumAndY[i, 0] = sumFunction(a);
            SumAndY[i, 1] = yFunction(a);
            i++;
        }
    }

    public delegate double[] SwapDirection(double[] array);
    public static double[] SwapRight(double[] array)
    {
        for (int i = 0; i < array.Length - 1; i += 2)
        {
            double temp = array[i];
            array[i] = array[i + 1];
            array[i + 1] = temp;
        }
        return array;
    }
    public static double[] SwapLeft(double[] array)
    {
        for (int i = array.Length - 1; i > 0; i -= 2)
        {
            double temp = array[i];
            array[i] = array[i - 1];
            array[i - 1] = temp;
        }
        return array;
    }
    public static double GetSum(double[] array)
    {
        double sum = 0;
        for (int i = 1; i < array.Length; i += 2)
        {
            sum += array[i];
        }
        return sum;
    }
    public static double firstY5(double x)
    {
        return x * x - Math.Sin(x);
    }
    public static double secondY5(double x)
    {
        return Math.Pow(Math.E, x) - 1;
    }
    public static int CountSignFlips(YFunction yFunction, double a, double b, double h) {
        int i = 0, count = 0;
        double s1 = 0, s2 = double.MaxValue;
        a = Math.Round(a - h, 1);
        for (; a <= Math.Round(b + h, 1); a = Math.Round(a + h, 1))
        {
            if (s1 != 0) s2 = s1;
            s1 = yFunction(a);
            i++;
            if (s2 != double.MaxValue)
            {
                if (((s1 > 0) && (s2 < 0)) || ((s2 > 0) && (s1 < 0))) count++;
            }
        }
        return count;
    }

    public delegate int CountPositive(int[,] matrix, int index);

    public delegate int FindElementDelegate(int[,] matrix);

    public static int FindMaxIndex(int[,] matrix)
    {
        int mx = int.MinValue, index = 0;
        for (int i = 0; i < matrix.GetLength(0); i++) for (int j = 0; j < matrix.GetLength(1); j++) if (matrix[i, j] > mx) { mx = matrix[i, j]; index = i; };
        return index;
    }
    public static int FindMinIndex(int[,] matrix)
    {
        int mn = int.MaxValue, index = 0;
        for (int i = 0; i < matrix.GetLength(0); i++) for (int j = 0; j < matrix.GetLength(1); j++) if (matrix[i, j] < mn) { mn = matrix[i, j]; index = i; };
        return index;
    }
    public static void RemoveRows(ref int[,] matrix, FindElementDelegate findMax, FindElementDelegate findMin)
    {
        int mxdex = findMax(matrix), mndex = findMin(matrix);
        int[,] matrixNew;
        if (mxdex == mndex)
        {
            matrixNew = new int[matrix.GetLength(0) - 1, matrix.GetLength(1)];
            for (int i = 0, k = 0; i < matrix.GetLength(0); i++, k++)
            {
                if (i == mxdex) { k--; continue; }
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrixNew[k, j] = matrix[i, j];
                }
            }
        } 
        else
        {
            matrixNew = new int[matrix.GetLength(0) - 2, matrix.GetLength(1)];
            for (int i = 0, k = 0; i < matrix.GetLength(0); i++, k++)
            {
                if (i == mxdex) { k--; continue; } else if (i == mndex) { k--; continue; }
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrixNew[k, j] = matrix[i, j];
                }
            }
        }
        matrix = matrixNew;
    }
    
    public delegate void ReplaceMaxElement(ref int[,] matrix, int row, int column);

    public static void EvenOddRowsTransform(ref int[,] matrix, ReplaceMaxElement replaceMaxElementOdd, ReplaceMaxElement replaceMaxElementEven)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            int mx = int.MinValue, mxdex = 0;
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] > mx)
                {
                    mx = matrix[i, j];
                    mxdex = j;
                }
            }
            if (i % 2 == 0) replaceMaxElementEven(ref matrix, i, mxdex);
            if (i % 2 == 1) replaceMaxElementOdd(ref matrix, i, mxdex);
        }
    }

    public delegate void MatrixConverter(ref double[,] matrix);

    public static void ToUpperTriangular(ref double[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = i + 1; j < matrix.GetLength(0); j++)
            {
                double ratio = matrix[j, i] / matrix[i, i];
                matrix[j, i] = 0;
                for (int k = i + 1; k < matrix.GetLength(1); k++)
                {
                    matrix[j, k] -= matrix[i, k] * ratio;
                }
            }
        }
    }
    public static void ToLowerTriangular(ref double[,] matrix)
    {
        for (int i = matrix.GetLength(0) - 1; i >= 0; i--)
        {
            for (int j = i - 1; j >= 0; j--)
            {
                double ratio = matrix[j, i] / matrix[i, i];
                matrix[j, i] = 0;
                for (int k = i - 1; k >= 0; k--)
                {
                    matrix[j, k] -= matrix[i, k] * ratio;
                }
            }
        }
    }
    public static void ToLeftDiagonal(ref double[,] matrix)
    {
        ToUpperTriangular(ref matrix);
        ToLowerTriangular(ref matrix);
    }
    public static void ToRightDiagonal(ref double[,] matrix)
    {
        ToLowerTriangular(ref matrix);
        ToUpperTriangular(ref matrix);
    }

    #region Level 1
    public long Task_1_1(int n, int k)
    {
        long answer = 0;

        // code here

        // create and use Factorial(n);

        answer = Factorial(n) / Factorial(k) / Factorial(n - k);

        // end

        return answer;
    }
    public int Task_1_2(double[] first, double[] second)
    {
        int answer = 0;

        // code here

        // create and use GeronArea(a, b, c);
        // first = 1, second = 2, equal = 0, error = -1

        if (GeronArea(first[0], first[1], first[2]) > GeronArea(second[0], second[1], second[2])) {
            answer = 1;
        } else if (GeronArea(first[0], first[1], first[2]) < GeronArea(second[0], second[1], second[2])) {
            answer = 2;
        } else
        {
            answer = 0;
        }
        for (int i = 0; i < 3; i++)
        {
            if (first[i % 3] >= first[(i+1) % 3] + first[(i + 2) % 3]) answer = -1;
            if (second[i % 3] >= second[(i + 1) % 3] + second[(i + 2) % 3]) answer = -1;
        }
        // end

        return answer;
    }
    public int Task_1_3a(double v1, double a1, double v2, double a2, int time)
    {
        int answer = 0;

        // code here

        // create and use GetDistance(v, a, t); t - hours
        // first = 1, second = 2, equal = 0

        if (GetDistance(v1, a1, time) > GetDistance(v2, a2, time))
        {
            answer = 1;
        } else if (GetDistance(v1, a1, time) < GetDistance(v2, a2, time))
        {
            answer = 2;
        } else
        {
            answer = 0;
        }

        // end

        return answer;
    }
    public int Task_1_3b(double v1, double a1, double v2, double a2)
    {
        int answer = 0;

        // code here

        // create and use GetDistance(v, a, t); t - hours
        do
        {
            answer++;
        } while (GetDistance(v1, a1, answer) > GetDistance(v2, a2, answer));

        // end

        return answer;
    }
    #endregion

    #region Level 2
    public void Task_2_1(int[,] A, int[,] B)
    {
        // code here

        // create and use FindMax(matrix);

        int mxA = FindMax(A), mxB = FindMax(B);
        bool flag = false;
        for (int i = 0; i < A.GetLength(0); i++)
        {
            for (int j = 0; j < A.GetLength(1); j++) if (A[i, j] == mxA) { A[i, j] = mxB; flag = true; break; }
            if (flag) break;
        }
        flag = false;
        for (int i = 0; i < B.GetLength(0); i++)
        {
            for (int j = 0; j < B.GetLength(1); j++) if (B[i, j] == mxB) { B[i, j] = mxA; flag = true; break; }
            if (flag) break;
        }

        // end
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

        int lineB = FindDiagonalMax(B), lineC = FindDiagonalMax(C);
        int[,] newB = new int[B.GetLength(0) - 1, B.GetLength(1)], newC = new int[C.GetLength(0) - 1, C.GetLength(1)];
        for (int i = 0, k = 0; i < B.GetLength(0); i++, k++)
        {
            if (B[i, i] == lineB) { k--; continue; }
            for (int j = 0; j < B.GetLength(1); j++) newB[k, j] = B[i, j];
        }
        for (int i = 0, k = 0; i < C.GetLength(0); i++, k++)
        {
            if (C[i, i] == lineC) { k--; continue; }
            for (int j = 0; j < C.GetLength(1); j++) newC[k, j] = C[i, j];
        }
        B = newB;
        C = newC;

        // end
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

        int mxA = FindColumnMax(A, 0), mxB = FindColumnMax(B, 0), mxAdex = 0, mxBdex = 0;
        int[] lain = new int[A.GetLength(1)];
        for (int i = 0; i < A.GetLength(0); i++) if (A[i, 0] == mxA) { mxAdex = i; break; }
        for (int i = 0; i < B.GetLength(0); i++) if (B[i, 0] == mxB) { mxBdex = i; break; }
        for (int j = 0; j < A.GetLength(1); j++) { lain[j] = A[mxAdex, j]; A[mxAdex, j] = B[mxBdex, j]; }
        for (int j = 0; j < B.GetLength(1); j++) B[mxBdex, j] = lain[j];

        // end
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

        int mxB = int.MinValue, mxBdex = 0, mxC = int.MinValue, mxCdex = 0;
        for (int i = 0; i < B.GetLength(0); i++) if (CountRowPositive(B, i) > mxB) { mxB = CountRowPositive(B, i); mxBdex = i; }
        for (int j = 0; j < C.GetLength(1); j++) if (CountColumnPositive(C, j) > mxC) { mxC = CountColumnPositive(C, j); mxCdex = j; }
        int[,] newB = new int[B.GetLength(0) + 1, B.GetLength(1)];
        for (int i = 0, k = 0; i < newB.GetLength(0); i++, k++)
        {
            for (int j = 0; j < B.GetLength(1); j++) newB[i, j] = B[k, j];
            if (i == mxBdex) { i++; for (int j = 0; j < C.GetLength(0); j++) newB[i, j] = C[j, mxCdex]; }
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

    public int[] Task_2_9(int[,] A, int[,] C)
    {
        int[] answer = default(int[]);

        // code here

        // create and use SumPositiveElementsInColumns(matrix);

        int[] sumA, sumC;
        SumPositiveElementsInColumns(A, out sumA);
        SumPositiveElementsInColumns(C, out sumC);
        answer = new int[sumA.Length + sumC.Length];
        for (int i = 0; i < sumA.Length; i++) answer[i] = sumA[i];
        for (int i = 0; i < sumC.Length; i++) answer[i + sumA.Length] = sumC[i];

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

        int mxA = FindMax(A), mxB = FindMax(B);
        bool flag = false;
        for (int i = 0; i < A.GetLength(0); i++)
        {
            for (int j = 0; j < A.GetLength(1); j++) if (A[i, j] == mxA) { A[i, j] = mxB; flag = true; break; }
            if (flag) break;
        }
        flag = false;
        for (int i = 0; i < B.GetLength(0); i++)
        {
            for (int j = 0; j < B.GetLength(1); j++) if (B[i, j] == mxB) { B[i, j] = mxA; flag = true; break; }
            if (flag) break;
        }

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

        int mx = int.MinValue, mn = int.MaxValue, mxdex = 0, mndex = 0;
        for (int i = 0; i < matrix.GetLength(0); i++) for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] > mx) { mx = matrix[i, j]; mxdex = i; }
                if (matrix[i, j] < mn) { mn = matrix[i, j]; mndex = i; }
            }
        RemoveRow(ref matrix, mxdex);
        if (mxdex < mndex)
        {
            RemoveRow(ref matrix, mndex - 1);
        }
        else if (mxdex > mndex)
        {
            RemoveRow(ref matrix, mndex);
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
        int answer = 0; // 1 - increasing   0 - no sequence   -1 - decreasing

        // code here

        // create and use GetAverageWithoutMinMax(matrix);

        double[] avgs = new double[3] { GetAverageWithoutMinMax(A), GetAverageWithoutMinMax(B), GetAverageWithoutMinMax(C) };
        if ((avgs[0] < avgs[1]) && (avgs[1] < avgs[2])) answer = 1;
        if ((avgs[0] > avgs[1]) && (avgs[1] > avgs[2])) answer = -1;

        // end

        return answer;
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

        bool[] rows = new bool[matrix.GetLength(0)];
        for (int i = 0; i < matrix.GetLength(0); i++) for (int j = 0; j < matrix.GetLength(1); j++) if (matrix[i, j] == 0)
                {
                    rows[i] = true;
                    break;
                }
        for (int i = matrix.GetLength(0) - 1; i >= 0; i--) if (rows[i]) RemoveRow(ref matrix, i);

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

        CreateArrayFromMins(A, out answerA);
        CreateArrayFromMins(B, out answerB);

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

        int[] countA, countB; 
        GetNegativeCountPerRow(A, out countA);
        GetNegativeCountPerRow(B, out countB);
        maxA = FindMaxNegativeRow(countA);
        maxB = FindMaxNegativeRow(countB);

        // end
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
            int mxdex = FindRowMaxIndex(A, i);
            if (i % 2 == 1) ReplaceMaxElementOdd(ref A, i, mxdex);
            if (i % 2 == 0) ReplaceMaxElementEven(ref A, i, mxdex);
        }

        for (int i = 0; i < B.GetLength(0); i++)
        {
            int mxdex = FindRowMaxIndex(B, i);
            if (i % 2 == 1) ReplaceMaxElementOdd(ref B, i, mxdex);
            if (i % 2 == 0) ReplaceMaxElementEven(ref B, i, mxdex);
        }

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
    public void Task_3_1(ref double[,] firstSumAndY, ref double[,] secondSumAndY)
    {
        // code here

        // create and use public delegate SumFunction(x, a, b, h) and public delegate YFunction(x, a, b, h)
        // create and use method GetSumAndY(sFunction, yFunction, a, b, h);
        // create and use 2 methods for both functions

        double a1 = 0.1, b1 = 1, h1 = 0.1, a2 = Math.PI / 5, b2 = Math.PI, h2 = Math.PI / 25;
        firstSumAndY = new double[(int)((b1 - a1) / h1) + 1, 2];
        secondSumAndY = new double[(int)((b2 - a2) / h2) + 1, 2];
        GetSumAndY(firstSum, firstY, a1, b1, h1, ref firstSumAndY);
        GetSumAndY(secondSum, secondY, a2, b2, h2, ref secondSumAndY);

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

    public double Task_3_3(double[] array)
    {
        double answer = 0;
        SwapDirection swapper = default(SwapDirection);

        // code here

        // create and use public delegate SwapDirection(array);
        // create and use methods SwapRight(array) and SwapLeft(array) and GetSum(array)
        // change method in variable swapper in the loop here and use it for array swapping

        double sum = 0, avg;
        for (int i = 0; i < array.Length; i++) sum += array[i];
        avg = sum / array.Length;
        if (array[0] > avg) { swapper = SwapRight; } else { swapper = SwapLeft; }
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

        double a1 = 0, b1 = 2, h1 = 0.1, a2 = -1, b2 = 1, h2 = 0.2;
        double[] firstY = new double[(int)((b1 - a1) / h1) + 3];
        double[] secondY = new double[(int)((b2 - a2) / h2) + 3];
        func1 = CountSignFlips(firstY5, a1, b1, h1);
        func2 = CountSignFlips(secondY5, a2, b2, h2);

        // end
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

        int mxB = int.MinValue, mxBdex = 0, mxC = int.MinValue, mxCdex = 0;
        CountPositive countPositive = CountRowPositive;
        for (int i = 0; i < B.GetLength(0); i++) if (countPositive(B, i) > mxB) { mxB = countPositive(B, i); mxBdex = i; }
        countPositive = CountColumnPositive;
        for (int j = 0; j < C.GetLength(1); j++) if (countPositive(C, j) > mxC) { mxC = countPositive(C, j); mxCdex = j; }
        int[,] newB = new int[B.GetLength(0) + 1, B.GetLength(1)];
        for (int i = 0, k = 0; i < newB.GetLength(0); i++, k++)
        {
            for (int j = 0; j < B.GetLength(1); j++) newB[i, j] = B[k, j];
            if (i == mxBdex) { i++; for (int j = 0; j < C.GetLength(0); j++) newB[i, j] = C[j, mxCdex]; }
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
    public double[,] Task_4(double[,] matrix, int index)
    {
        MatrixConverter[] mc = new MatrixConverter[4];
        // code here

        // create public delegate MatrixConverter(matrix);
        // create and use method ToUpperTriangular(matrix);
        // create and use method ToLowerTriangular(matrix);
        // create and use method ToLeftDiagonal(matrix); - start from the left top angle
        // create and use method ToRightDiagonal(matrix); - start from the right bottom angle

        mc[0] = ToUpperTriangular;
        mc[1] = ToLowerTriangular;
        mc[2] = ToLeftDiagonal;
        mc[3] = ToRightDiagonal;

        mc[index](ref matrix);

        // end

        return matrix;
    }
    #endregion
}
