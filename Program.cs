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
        if (n < k || n < 0 || k < 0) return 0;

        long answer = Combination(n, k);

        return answer;
    }
    public long Combination(int n, int k)
    {
        if (n == 0 || k == 0) { return 0; }
        long res = (long)Factorial(n) / (Factorial(k) * Factorial(n - k));
        return res;
    }
    public int Factorial(int n)
    {
        if (n == 0) { return 0; }
        int per = 1;
        for (int i = 1; i <= n; i++)
        {
            per *= i;
        }
        return per;
    }

    public int Task_1_2(double[] first, double[] second)
    {
        int answer = 0;
        // create and use GeronArea(a, b, c);
        double tri1 = GeronArea(first[0], first[1], first[2]);
        double tri2 = GeronArea(second[0], second[1], second[2]);

        if (!CheckTriangle(first[0], first[1], first[2]) || !CheckTriangle(second[0], second[1], second[2]))
        {
            return -1;
        }
        if (tri1 > tri2) { answer = 1; } 
        else if (tri1 < tri2) { answer = 2; } 
        else { answer = 0; }

        // first = 1, second = 2, equal = 0, error = -1
        return answer;
    }
    public double GeronArea(double a, double b, double c)
    {
        double p = (a + b + c) / 2;
        return (double)Math.Sqrt(p * (p - a) * (p - b) * (p - c));
    }
    public bool CheckTriangle(double a, double b, double c)
    {
        if (a + b > c && a + c > b && b + c > a)
        {
            return true;
        }
        else { return false; }
    }

    public int Task_1_3a(double v1, double a1, double v2, double a2, int time)
    {
        int answer = 0;
        // create and use GetDistance(v, a, t); t - hours
        double r1 = GetDistance(v1, a1, time);
        double r2 = GetDistance(v2, a2, time);
        if (r1 > r2) { answer = 1; } 
        else if (r1 < r2) { answer = 2; } 
        else { answer = 0; }



        // first = 1, second = 2, equal = 0
        return answer;
    }
    public double GetDistance(double v, double a, int hours)
    {
        return (v * hours + ((a * hours * hours) / 2));
    }
    public int Task_1_3b(double v1, double a1, double v2, double a2)
    {
        int answer = 0;

        // use GetDistance(v, a, t); t - hours
        for (int i = 1; i < int.MaxValue; i++)
        {
            if (GetDistance(v1, a1, i) <= GetDistance(v2, a2, i))
            {
                answer = i; break;
            }
        }
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
    public int FindMaxIndex(double[] array)
    {
        double maxx = -1000000; int ind = -1;
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] > maxx)
            {
                maxx = array[i]; ind = i;
            }
        }
        return ind;
    }

    public void Task_2_2(double[] A, double[] B)
    {

        int indA = FindMaxIndex(A), indB = FindMaxIndex(B);
        double[] answerbas; int max;

        if (A.Length - indA > B.Length - indB)
        {
            answerbas = A; max = indA;
        }
        else
        {
            answerbas = B; max = indB;
        }
        double md = 0, n = 0;
        for (int i = max + 1; i < answerbas.Length; i++, n++)
        {
            md += answerbas[i];
        }
        md /= n;
        double maximum = answerbas[max];
        for (int i = 0; i < answerbas.Length; i++)
        {
            if (answerbas[i] == maximum) { answerbas[i] = md; }
        }
    }

    public void Task_2_3(ref int[,] B, ref int[,] C)
    {
        // code here

        //  create and use method FindDiagonalMaxIndex(matrix);

        // end
    }

    public int FindDiagonalMaxIndex(int[,] matrix)
    {
        int str = matrix.GetLength(0);
        int colon = matrix.GetLength(1);
        int n = Math.Min(str, colon);
        int maxind = 0;
        for (int i = 1; i < n; i++)
        {
            if (matrix[maxind, maxind] < matrix[i, i])
            {
                maxind = i;
            }
        }
        return maxind;
    }

    public void Task_2_4(int[,] A, int[,] B)
    {
        int iA = FindDiagonalMaxIndex(A);
        int iB = FindDiagonalMaxIndex(B);
        for (int i = 0; i < 5; i++)
        {
            (A[iA, i], B[i, iB]) = (B[i, iB], A[iA, i]);
        }
    }


    public void Task_2_5(int[,] A, int[,] B)
    {
        // code here

        // create and use FindMaxInColumn(matrix, columnIndex, out rowIndex);

        // end
    }
    public int FindMax(int[] massive)
    {
        int maxx = -10000000; int ind = -1;
        for (int i = 0; i < massive.Length; i++)
        {
            if (massive[i] > maxx)
            {
                maxx = massive[i]; ind = i;
            }
        }
        return ind;
    }
    public int[] DeleteElement(int[] massive, int index)
    {
        int[] result = new int[massive.Length - 1];

        for (int i = 0; i < massive.Length; i++)
        {
            if (i < index)
            {
                result[i] = massive[i];
            }
            else if (i > index)
            {
                result[i - 1] = massive[i];
            }
        }
        return result;
    }
    public void Task_2_6(ref int[] A, int[] B)
    {

        int maxA = FindMax(A);
        int maxB = FindMax(B);
        A = DeleteElement(A, maxA);
        B = DeleteElement(B, maxB);
        int[] mas = A;
        int lenA = A.Length;
        A = new int[lenA + B.Length];
        for (int i = 0; i < A.Length; i++)
        {
            if (i < mas.Length)
            {
                A[i] = mas[i];
            }
            else
            {
                A[i] = B[i - mas.Length];
            }
        }
   
    }


    public void Task_2_7(ref int[,] B, int[,] C)
    {
        // code here

        // create and use CountRowPositive(matrix, rowIndex);
        // create and use CountColumnPositive(matrix, colIndex);

        // end
    }

    public int[] SortArrayPart(int[] array, int startIndex)
    {
        for (int i = startIndex + 2, j = startIndex + 3; i < array.Length;)
        {
            if (i == startIndex + 1 || array[i] >= array[i - 1])
            {
                i = j;
                j++;
            }
            else
            {
                (array[i], array[i - 1]) = (array[i - 1], array[i]);
                i--;
            }
        }
        return array;
    }

    public void Task_2_8(int[] A, int[] B)
    {

        int maxA = FindMax(A);
        int maxB = FindMax(B);
        A = SortArrayPart(A, maxA);
        B = SortArrayPart(B, maxB);

   
    }

    public int[] Task_2_9(int[,] A, int[,] C)
    {
        int[] answer = default(int[]);

        // code here

        // create and use SumPositiveElementsInColumns(matrix);

        // end

        return answer;
    }
    public void RemoveColumn(ref int[,] matrix, int columnIndex)
    {
        int[,] temp = new int[matrix.GetLength(0), matrix.GetLength(1) - 1];
        int i1 = matrix.GetLength(0);
        int j1 = temp.GetLength(1);
        for (int j = 0; j < columnIndex; j++)
        {
            for (int i = 0; i < i1; i++)
            {
                temp[i, j] = matrix[i, j];
            }
        }
        for (int j = columnIndex; j < j1; j++)
        {
            for (int i = 0; i < i1; i++) 
            {
                temp[i, j] = matrix[i, j + 1];
        } 
        }
        matrix = temp;
    }
    public void Task_2_10(ref int[,] matrix)
    {
        int maxX = 0, minX = 0; int maxY = 0, minY = 1;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (i >= j && (matrix[i, j] > matrix[maxX, maxY]))
                {
                    maxX = i;
                    maxY = j;
                }
                if (i < j && (matrix[i, j] < matrix[minX, minY]))
                {
                    minX = i;
                    minY = j;
                }
            }
        }
        int elmaximum = Math.Max(maxY, minY);
        int elmini = Math.Min(maxY, minY);
        RemoveColumn(ref matrix, elmaximum);
        if (elmaximum != elmini)
        {
            RemoveColumn(ref matrix, elmini);
        }
    }

    public void Task_2_11(int[,] A, int[,] B)
    {
        // code here

        // use FindMaxIndex(matrix, out row, out column); from Task_2_1

        // end
    }

    public int FindMaxColumnIndex(int[,] matrix)
    {
        int maxx = -1000000; int ind = -1;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] > maxx)
                {
                    maxx = matrix[i, j]; ind = j;
                }
            }
        }
        return ind;
    }
    public void Task_2_12(int[,] A, int[,] B)
    {

        int A1 = FindMaxColumnIndex(A);
        int B1 = FindMaxColumnIndex(B);
        int l1 = 1;
        while (l1 < 2)
        {
            for (int i = 0; i < A.GetLength(0); i++)
            {
                (A[i, A1], B[i, B1]) = (B[i, B1], A[i, A1]);
            }
            l1++;
        }
    }

    public void Task_2_13(ref int[,] matrix)
    {
        // code here

        // create and use RemoveRow(matrix, rowIndex);

        // end
    }
    public void SortRow(int[,] matrix, int rI)
    {
        for (int i = 0; i < matrix.GetLength(1); i++)
        {
            for (int j = 0; j < matrix.GetLength(1) - i - 1; j++)
            {
                if (matrix[rI, j] > matrix[rI, j + 1])
                {
                    (matrix[rI, j], matrix[rI, j + 1]) = (matrix[rI, j + 1], matrix[rI, j]);
                }
            }
        }
    }
    public void Task_2_14(int[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            SortRow(matrix, i);
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
    public void SortNegative(int[] array)
    {
        int minel = 0; int xz = 0;

        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] < 0) { minel++; }
        }

        int[] massive = new int[minel];

        for (int l = 0; l < array.Length; l++)
        {
            if (array[l] < 0) { massive[xz++] = array[l]; }
        }
        for (int r = 0; r < xz; r++)
        {
            for (int j = 0; j < xz - r - 1; j++)
            {
                if (massive[j] < massive[j + 1])
                {
                    (massive[j], massive[j + 1]) = (massive[j + 1], massive[j]);
                }
            }
        }
        xz = 0;
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] < 0)
            {
                array[i] = massive[xz++];
            }
        }
    }
    public void Task_2_16(int[] A, int[] B)
    {
        SortNegative(A);
        SortNegative(B);
    }


    public void Task_2_17(int[,] A, int[,] B)
    {
        // code here

        // create and use SortRowsByMaxElement(matrix);

        // end
    }
    public void SortDiagonal(int[,] matrix)
    {
        int n = matrix.GetLength(0);
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (matrix[j, j] > matrix[j + 1, j + 1])
                {
                    (matrix[j, j], matrix[j + 1, j + 1]) = (matrix[j + 1, j + 1], matrix[j, j]);
                }
            }
        }

    }
    public void Task_2_18(int[,] A, int[,] B)
    {
        SortDiagonal(A);
        SortDiagonal(B);
    }


    public void Task_2_19(ref int[,] matrix)
    {
        // code here

        // use RemoveRow(matrix, rowIndex); from 2_13

        // end
    }

    public int[,] DeletingOfColumnMatrx(int[,] matrix)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            int check = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, j] == 0) { check++; break; }
            }
            if (check == 0)
            {
                RemoveColumn(ref matrix, j);
                j--;
            }
        }
        return matrix;
    }

    public void Task_2_20(ref int[,] A, ref int[,] B)
    {
        A = DeletingOfColumnMatrx(A);
        B = DeletingOfColumnMatrx(B);
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
        rows = null; cols = null;
        rows = new int[matrix.GetLength(0)];

        for (int i = 0; i < rows.Length; i++)
        {
            rows[i] = CountNegativeInRow(matrix, i);
        }
        cols = FindMaxNegativePerColumn(matrix);
    }
    public int CountNegativeInRow(int[,] matrix, int rI)
    {
        int minus = 0;
        for (int j = 0; j < matrix.GetLength(1); j++) 
        {
            if (matrix[rI, j] < 0) { minus++; } 
        }
        return minus;
    }
    public int[] FindMaxNegativePerColumn(int[,] matrix)
    {
        int[] newmass = new int[matrix.GetLength(1)];

        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            int max = -1000000;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if ((matrix[i, j] > max) && (matrix[i, j] < 0)) { max = matrix[i, j]; }
            }
            newmass[j] = max;
        }
        return newmass;
    }
        public void Task_2_23(double[,] A, double[,] B)
    {
        // code here

        // create and use MatrixValuesChange(matrix);

        // end
    }
    public void FindMaxIndex(int[,] matrix, out int row, out int col)
    {
        row = 0; col = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] > matrix[row, col])
                {
                    row = i; col = j;
                }
            }
        }
    }
    public void SwapColumnDiagonal(int[,] matrix, int columnIndex)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            (matrix[i, i], matrix[i, columnIndex]) = (matrix[i, columnIndex], matrix[i, i]);
        }
    }
    public void Task_2_24(int[,] A, int[,] B)
    {
        int row = 0, col = 0;
        FindMaxIndex(A, out row, out col);
        FindMaxIndex(B, out row, out col);
        SwapColumnDiagonal(A, col);
        SwapColumnDiagonal(B, col);
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
    public int FindRowWithMaxNegativeCount(int[,] matrix)
    {
        int ind = 0, counting = -1;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            int negelem = CountNegativeInRow(matrix, i);
            if (counting < negelem)
            {
                counting = negelem;
                ind = i;
            }
        }
        return ind;
    }
    public void Task_2_26(int[,] A, int[,] B)
    {
        int elA = FindRowWithMaxNegativeCount(A);
        int elB = FindRowWithMaxNegativeCount(B);
        for (int j = 0; j < A.GetLength(1); j++)
        {
            (A[elA, j], B[elB, j]) = (B[elB, j], A[elA, j]);
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
        answerFirst = FindSequence(first, 0, first.Length - 1);
        answerSecond = FindSequence(second, 0, second.Length - 1);
    }
    public int FindSequence(int[] array, int A, int B)
    {
        if (A >= B) { return 0; }
        bool flag = array[A] < array[A + 1];
        for (int i = A; i < B; i++)
        {
            if (flag && (array[i] > array[i + 1])) { return 0; }
            if (!flag && (array[i] < array[i + 1])) { return 0; }
        }
        if (flag)
        {
            return 1;
        } else { return -1; }
    }

    public int[,] ChangingOfMass(int[] array, int fir, int sec)
    {
        int n = 0; int l = 0;
        for (int i = fir; i < sec; i++)
        {
            for (int j = i + 1; j <= sec; j++)
            {
                if (FindSequence(array, i, j) != 0) { n++; }
            }
        }

        int[,] answerFirst = new int[n, 2]; 

        for (int i = fir; i < sec; i++)
        {
            for (int j = i + 1; j <= sec; j++)
            {
                if (FindSequence(array, i, j) != 0)
                {
                    answerFirst[l, 0] = i;
                    answerFirst[l, 1] = j;
                    l++;
                }
            }
        }
        return answerFirst;
    } 

    public void Task_2_28b(int[] first, int[] second, ref int[,] answerFirst, ref int[,] answerSecond)
    {
        answerFirst = ChangingOfMass(first,0,first.Length-1);
        answerSecond = ChangingOfMass(second,0,second.Length-1);
    }


    public int[] Swaps(int[,] matrix)
    {
        int[] result = new int[2];
        int fir1 = matrix[0, 1], fir2 = matrix[0, 0];
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            if (matrix[i, 1] - matrix[i, 0] > fir1 - fir2)
            {
                (fir1, fir2) = (matrix[i,1], matrix[i,0]);
                (result[0],result[1]) = (matrix[i, 0], matrix[i, 1]);
            }
        }
        return result;
    }

    public void Task_2_28c(int[] first, int[] second, ref int[] answerFirst, ref int[] answerSecond)
    {
        answerFirst = Swaps(ChangingOfMass(first, 0, first.Length - 1));
        answerSecond = Swaps(ChangingOfMass(second, 0, second.Length - 1));
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
        SortRowStyle sortStyle = default(SortRowStyle);
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            if (i % 2 == 0) { sortStyle = SortAscending; }
            else { sortStyle = SortDescending; }
            sortStyle(matrix, i);
        }
    }

    public delegate void SortRowStyle(int[,] matrix, int rowIndex);

    void SortDescending(int[,] matrix, int rowIndex)
    {
        for (int i = 0; i < matrix.GetLength(1); i++)
        {
            for (int j = 0; j < matrix.GetLength(1) - 1 - i; j++)
            {
                if (matrix[rowIndex, j] < matrix[rowIndex, j + 1])
                {
                    (matrix[rowIndex, j], matrix[rowIndex, j + 1]) = (matrix[rowIndex, j + 1], matrix[rowIndex, j]);
                }
            }
        }
    }
    void SortAscending(int[,] matrix, int rowIndex)
    {

        for (int i = 0; i < matrix.GetLength(1); i++)
        {
            for (int j = 0; j < matrix.GetLength(1) - 1 - i; j++)
            {
                if (matrix[rowIndex, j] > matrix[rowIndex, j + 1])
                {
                    (matrix[rowIndex, j], matrix[rowIndex, j + 1]) = (matrix[rowIndex, j + 1], matrix[rowIndex, j]);
                }
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

        if (isUpperTriangle)
        {
            answer = GetSum(GetUpperTriangle, matrix);
        }
        else
        {
            answer = GetSum(GetLowerTriangle, matrix);
        }
        return answer;
    }
    public delegate int[] GetTriangle(int[,] matrix);
    int[] GetUpperTriangle(int[,] matrix)
    {
        int[] result = new int[(matrix.GetLength(0) * (matrix.GetLength(0) + 1)) / 2];
        int kre = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = i; j < matrix.GetLength(1); j++)
            {
                result[kre] = matrix[i, j];
                kre++;
            }
        }
        return result;
    }
    int[] GetLowerTriangle(int[,] matrix)
    {
        int[] anresult = new int[(matrix.GetLength(0) * (matrix.GetLength(0) + 1)) / 2];
        int kre1 = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j <= i; j++)
            {
                anresult[kre1] = matrix[i, j];
                kre1++;
            }
        }
        return anresult;
    }
    int GetSum(GetTriangle getTriangle, int[,] matrix)
    {
        int[] result = getTriangle(matrix);
        int l = 0;
        for (int i = 0; i < result.Length; i++) {
            l += result[i] * result[i]; 
        }
        return l;
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
        SwapColumns(matrix, FindDiagonalMaxIndex, FindFirstRowMaxIndex);
    }
    public delegate int FindElementDelegate(int[,] matrix);
    int FindFirstRowMaxIndex(int[,] matrix)
    {
        int maxx = 0;
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (matrix[0, j] > matrix[0, maxx]) { maxx = j; }
        }
        return maxx;
    }
    void SwapColumns(int[,] matrix, FindElementDelegate findDiagonalMaxIndex, FindElementDelegate findFirstRowMaxIndex)
    {
        int elem1 = findDiagonalMaxIndex(matrix), elem2 = findFirstRowMaxIndex(matrix);
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            (matrix[i, elem1], matrix[i, elem2]) = (matrix[i, elem2], matrix[i, elem1]);
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
        RemoveColumns(ref matrix, FindMaxBelowDiagonalIndex, FindMinAboveDiagonalIndex);
    }
    public delegate int FindIndex(int[,] matrix);
    int FindMaxBelowDiagonalIndex(int[,] matrix)
    {
        int maxi = 0, maxj = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j <= i; j++)
            {
                if (matrix[i, j] > matrix[maxi, maxj])
                {
                    maxi = i; maxj = j;
                }
            }
        }
        return maxj;
    }
    int FindMinAboveDiagonalIndex(int[,] matrix)
    {
        int mini = 0, minj = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = i + 1; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] < matrix[mini, minj])
                {
                    mini = i;minj = j;
                }
            }
        }
        return minj;
    }
    void RemoveColumns(ref int[,] matrix, FindIndex findMaxBelowDiagonalIndex, FindIndex findMinAboveDiagonalIndex)
    {
        int elem1 = findMaxBelowDiagonalIndex(matrix);
        int elem2 = findMinAboveDiagonalIndex(matrix);
        if (elem1 > elem2)
        {
            (elem1, elem2) = (elem2, elem1);
        }
        RemoveColumn(ref matrix, elem2);
        if (elem1 != elem2)
        {
            RemoveColumn(ref matrix, elem1);
        }
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
        rows = null;
        cols = null;
        FindNegatives(matrix, CountNegativeInRows, FindMaxNegativePerColumn, out rows, out cols);
    }
    public delegate int[] GetNegativeArray(int[,] matrix);
    int[] CountNegativeInRows(int[,] matrix)
    {
        int[] result = new int[matrix.GetLength(0)];
        for (int i = 0; i < matrix.GetLength(0); i++)
            result[i] = CountNegativeInRow(matrix, i);
        return result;
    }
    void FindNegatives(int[,] matrix, GetNegativeArray searcherRows, GetNegativeArray searcherCols, out int[] rows, out int[] cols)
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
        answerFirst = DefineSequence(first, FindIncreasingSequence, FindDecreasingSequence);
        answerSecond = DefineSequence(second, FindIncreasingSequence, FindDecreasingSequence);
    }
    public delegate bool IsSequence(int[] array, int left, int right);
    bool FindIncreasingSequence(int[] array, int A, int B)
    {
        return (FindSequence(array, A, B) == 1);
    }
    bool FindDecreasingSequence(int[] array, int A, int B)
    {
        return (FindSequence(array, A, B) == -1);
    }
    int DefineSequence(int[] array, IsSequence findIncreasingSequence, IsSequence findDecreasingSequence)
    {
        if (findIncreasingSequence(array, 0, array.Length - 1))
        { 
            return 1; 
        }
        else if (findDecreasingSequence(array, 0, array.Length - 1)) 
        { 
            return -1;
        }
        else { 
            return 0; 
        }
    }

    public void Task_3_28c(int[] first, int[] second, ref int[] answerFirstIncrease, ref int[] answerFirstDecrease, ref int[] answerSecondIncrease, ref int[] answerSecondDecrease)
    {
        answerFirstIncrease = FindLongestSequence(first, FindIncreasingSequence);
        answerFirstDecrease = FindLongestSequence(first, FindDecreasingSequence);
        //////////////////////////////////////////////////////////////////////////
        answerSecondIncrease = FindLongestSequence(second, FindIncreasingSequence);
        answerSecondDecrease = FindLongestSequence(second, FindDecreasingSequence);
    }
    int[] FindLongestSequence(int[] array, IsSequence sequence)
    {
        int tyagelo = 0, perem = 0;
        for (int i = 0; i < array.Length; i++)
        {
            for (int j = i + 1; j < array.Length; j++) 
            {
                if (sequence(array, i, j) && ((perem - tyagelo) < (j - i)))
                {
                    tyagelo = i; perem = j;
                }
        } 
        }
        return [tyagelo, perem];
    }
    #endregion
    #region bonus part
    public double[,] Task_4(double[,] matrix, int index)
    {
        MatrixConverter[] mc = new MatrixConverter[4];

        mc[0] = ToUpperTriangular;
        mc[1] = ToLowerTriangular;
        mc[2] = ToLeftDiagonal;
        mc[3] = ToRightDiagonal;

        double[,] result = new double[matrix.GetLength(0), matrix.GetLength(1)];
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                result[i, j] = matrix[i, j];
            }
        }

        mc[index](result);
        return result;
    }

    void AddRowToRow(double[,] matrix, int r1, int r2, double a)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            double temp = a * matrix[r1, j];
            matrix[r2, j] += temp;
        }
    }

    delegate void MatrixConverter(double[,] matrix);
    void ToUpperTriangular(double[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = i + 1; j < matrix.GetLength(0); j++)
            {
                double k = (-1 * matrix[j, i]) / matrix[i, i];
                AddRowToRow(matrix, i, j, k);
            }
        }
    }
    void ToLowerTriangular(double[,] matrix)
    {
        for (int i = matrix.GetLength(0) - 1; i >= 0; i--)
        {
            for (int j = i - 1; j >= 0; j--)
            {
                double k = (-1 * matrix[j, i]) / matrix[i, i];
                AddRowToRow(matrix, i, j, k);
            }
        }
    }
    void ToLeftDiagonal(double[,] matrix)
    {
        ToUpperTriangular(matrix);
        for (int i = matrix.GetLength(0) - 1; i >= 0; i -= 1)
        {
            for (int j = i - 1; j >= 0; j -= 1)
            {
                double k = (-1 * matrix[j, i]) / matrix[i, i];
                AddRowToRow(matrix, i, j, k);
            }
        }
    }
    void ToRightDiagonal(double[,] matrix)
    {
        ToLowerTriangular(matrix);
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = i + 1; j < matrix.GetLength(0); j++)
            {
                double k = (-1 * matrix[j, i]) / matrix[i, i];
                AddRowToRow(matrix, i, j, k);
            }
        }
    }
    #endregion
}
