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
    public int Factorial(int n)
    {
        int fakt = 1;
        for (int i = 1; i <= n; i++)
        {
            fakt *= i;
        }

        return fakt;
    }
    #region Level 1
    public long Task_1_1(int n, int k)
    {
        long answer = 0;
        if (k == 0 || k > 0 && k == n) return 1;
        else if (k < 0 || k > n) return 0;
        // code here
        answer = (long)Factorial(n) / (Factorial(k) * Factorial(n - k));
        // create and use Combinations(n, k);
        // create and use Factorial(n);

        // end

        return answer;
    }
    public bool CheckTriangle(double a, double b, double c)
    {
        return (a < b + c) && (b < a + c) && (c < a + b);
    }
    public double GeronArea(double a, double b, double c)
    {
        double p = (a + b + c) / 2.0;
        double ploshad = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        return ploshad;
    }
    public int Task_1_2(double[] first, double[] second)
    {
        int answer = 0;

        // code here
        double a1 = first[0], b1 = first[1], c1 = first[2];
        double a2 = second[0], b2 = second[1], c2 = second[2];
        // create and use GeronArea(a, b, c);
        if (CheckTriangle(a1, b1, c1) == false || CheckTriangle(a2, b2, c2) == false)
            answer = -1;
        else
        {
            if (GeronArea(a1, b1, c1) == GeronArea(a2, b2, c2)) 
                answer = 0;
            else if (GeronArea(a1, b1, c1) < GeronArea(a2, b2, c2)) 
                answer = 2;
            else if (GeronArea(a1, b1, c1) > GeronArea(a2, b2, c2))
                answer = 1;
        }
        // end

        // first = 1, second = 2, equal = 0, error = -1
        return answer;
    }
    public double GetDistance(double v, double a, int t)
    {
        double rast = v * t + a * t * t / 2;
        return rast;
    }
    public int Task_1_3a(double v1, double a1, double v2, double a2, int time)
    {
        int answer = 0;
        if (GetDistance(v1, a1, time) == GetDistance(v2, a2, time))
            answer = 0;
        else if (GetDistance(v1, a1, time) < GetDistance(v2, a2, time)) 
            answer = 2;
        else if (GetDistance(v1, a1, time) > GetDistance(v2, a2, time)) 
            answer = 1;
        // create and use GetDistance(v, a, t); t - hours

        // end

        // first = 1, second = 2, equal = 0
        return answer;
    }

    public int Task_1_3b(double v1, double a1, double v2, double a2)
    {
        int answer = 0;

        // code here
        int vr = 1;
        while (GetDistance(v1, a1, vr) > GetDistance(v2, a2, vr))
            vr++;
        answer = vr;
        // use GetDistance(v, a, t); t - hours

        // end

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
    int FindMaxIndex(double[] array)
    {
        int max_ind = 0;
        for (int i = 1; i < array.Length; i++)
            if (array[i] > array[max_ind])
                max_ind = i;
        return 
            max_ind;
    }
    public void Task_2_2(double[] A, double[] B)
    {
        // code here
        int max_indA = FindMaxIndex(A);
        int max_indB = FindMaxIndex(B);
        double[] ar;
        int imax;

        // create and use FindMaxIndex(array);

        // only 1 array has to be changed!
        if (A.Length - max_indA > B.Length - max_indB)
        {
            ar = A;
            imax = max_indA;
        }
        else
        {
            ar = B;
            imax = max_indB;
        }
        double sredn = 0, k = 0;
        for (int i = imax + 1; i < ar.Length; i++)
        {
            sredn += ar[i];
            k++;
        }
        sredn /= k;
        double max = ar[imax];
        for (int i = 0; i < ar.Length; i++)
        {
            if (ar[i] == max) 
                ar[i] = sredn;
        }
        // end

    }

    public void Task_2_3(ref int[,] B, ref int[,] C)
    {
        // code here

        //  create and use method FindDiagonalMaxIndex(matrix);

        // end
    }
    public int FindDiagonalMaxIndex(int[,] matrix)
    {
        int imax = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            if (matrix[imax, imax] < matrix[i, i])
                imax = i;
        }
        return imax;
    }

    public void Task_2_4(int[,] A, int[,] B)
    {
        int max_indexA = FindDiagonalMaxIndex(A);
        int max_indexB = FindDiagonalMaxIndex(B);

        int[] str = new int[5];
        for (int i = 0; i < A.GetLength(0); i++)
        {
            str[i] = A[max_indexA, i];
            A[max_indexA, i] = B[i, max_indexB];
            B[i, max_indexB] = str[i];
        }
    }

    public void Task_2_5(int[,] A, int[,] B)
    {
        // code here

        // create and use FindMaxInColumn(matrix, columnIndex, out rowIndex);

        // end
    }
    public int[] DeleteElement(ref int[] arr, int index)
    {
        int[] str = new int[arr.Length - 1];
        for (int i = 0; i < arr.Length; i++)
        {
            if (i < index)
                str[i] = arr[i];
            else if (i > index)
                str[i - 1] = arr[i];
        }
        arr = str;
        return arr;
    }
    public int FindMax(int[] arr)
    {
        int imax = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[imax] < arr[i])
                imax = i;
        }
        return imax;
    }
    public void Task_2_6(ref int[] A, int[] B)
    {
        int imaxA = FindMax(A);
        int imaxB = FindMax(B);
        DeleteElement(ref A, imaxA);
        DeleteElement(ref B, imaxB);

        int[] stroka = new int[A.Length + B.Length];
        for (int i = 0; i < A.Length + B.Length; i++)
        {
            if (i < A.Length)
                stroka[i] = A[i];
            else
                stroka[i] = B[i - A.Length];
        }
        A = stroka;
    }
    public int[] SortArrayPart(ref int[] arr, int ind)
    {
        
        for (int i = ind + 2, j = ind + 3; i < arr.Length;)
        {
            if (i == ind + 1 || arr[i] >= arr[i - 1])
            {
                i = j;
                j++;
            }
            else
            {
                int temp = arr[i];
                arr[i] = arr[i - 1];
                arr[i - 1] = temp;
                i--;
            }
        }
        return arr;
    }
    public void Task_2_7(ref int[,] B, int[,] C)
    {
        // code here

        // create and use CountRowPositive(matrix, rowIndex);
        // create and use CountColumnPositive(matrix, colIndex);

        // end
    }

    public void Task_2_8(int[] A, int[] B)
    {
        // code here
        int imaxA = FindMax(A);
        int imaxB = FindMax(B);
        SortArrayPart(ref A, imaxA);
        SortArrayPart(ref B, imaxB);
        // create and use SortArrayPart(array, startIndex);

        // end
    }

    public int[] Task_2_9(int[,] A, int[,] C)
    {
        int[] answer = default(int[]);

        // code here

        // create and use SumPositiveElementsInColumns(matrix);

        // end

        return answer;
    }
    public int[,] RemoveColumn(int[,] matrix, int ind)
    {
        int[,] B = new int[matrix.GetLength(0), matrix.GetLength(1) - 1];
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (j < ind)
                {
                    B[i, j] = matrix[i, j];
                }
                else if (j > ind)
                {
                    B[i, j - 1] = matrix[i, j];
                }
                else
                {
                    continue;
                }
            }
        }
        return B;
    }
        public void Task_2_10(ref int[,] matrix)
    {
        // code here
        if (matrix.GetLength(0) != matrix.GetLength(1) || matrix.GetLength(0) < 1)
        {
            return;
        }
        int imax = 0; int jmax = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j <= i; j++)
            {
                if (matrix[i, j] > matrix[imax, jmax])
                {
                    imax = i;
                    jmax = j;
                }
            }
        }
        int imax2 = 0; int jmax2 = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = i + 1; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] > matrix[imax2, jmax2])
                {
                    imax2 = i;
                    jmax2 = j;
                }
            }
        }
        if (jmax == jmax2)
        {
            matrix = RemoveColumn(matrix, jmax);
        }

        else if (jmax > jmax2)
        {
            matrix = RemoveColumn(matrix, jmax);
            matrix = RemoveColumn(matrix, jmax2);
        }
        else
        {
            matrix = RemoveColumn(matrix, jmax2);
            matrix = RemoveColumn(matrix, jmax);
        }

        // end
    }

    public void Task_2_11(int[,] A, int[,] B)
    {
        // code here

        // use FindMaxIndex(matrix, out row, out column); from Task_2_1

        // end
    }
    public int FindMaxColumnIndex(int[,] matrix)
    {
        int imax = 0; int max = matrix[0, 0];
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] > max)
                {
                    max = matrix[i, j];
                    imax = j;
                }
            }
        }
        return imax;
    }
    public void Task_2_12(int[,] A, int[,] B)
    {
        // code here
        int imaxA = FindMaxColumnIndex(A);
        int imaxB = FindMaxColumnIndex(B);
        for (int i = 0; i < A.GetLength(0); i++)
        {
            int temp = A[i, imaxA];
            A[i, imaxA] = B[i, imaxB];
            B[i, imaxB] = temp;
        }

        // end
    }
    public int[,] SortRow(ref int[,] matrix, int index)
    {
        for (int i = 1, j = 2; i < matrix.GetLength(1);)
        {
            if (i == 0 || matrix[index, i] > matrix[index, i - 1])
            {
                i = j;
                j++;
            }
            else
            {
                int vrenm = matrix[index, i];
                matrix[index, i] = matrix[index, i - 1];
                matrix[index, i - 1] = vrenm;
                i--;
            }
        }
        return matrix;
    }
    public void Task_2_13(ref int[,] matrix)
    {
        // code here

        // create and use RemoveRow(matrix, rowIndex);

        // end
    }

    public void Task_2_14(int[,] matrix)
    {
        // code here

        for (int i = 0; i < matrix.GetLength(0); i++)
            SortRow(ref matrix, i);

        // end
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

    public void Task_2_16(int[] A, int[] B)
   
    {
        SortNegative(A);
        SortNegative(B);
    }
    void SortNegative(int[] array)
    {
        int k = 0;
        for (int i = 0; i < array.Length; i++)
            if (array[i] < 0) k++;
        int[] vrem = new int[k];
        int ind = 0;
        for (int i = 0; i < array.Length; i++)
            if (array[i] < 0) vrem[ind++] = array[i];
        for (int i = 0; i < k; i++)
            for (int j = 0; j < k - i - 1; j++)
                if (vrem[j] < vrem[j + 1])
                    (vrem[j], vrem[j + 1]) = (vrem[j + 1], vrem[j]);
        ind = 0;
        for (int i = 0; i < array.Length; i++)
            if (array[i] < 0)
                array[i] = vrem[ind++];
    }

    public void Task_2_17(int[,] A, int[,] B)
    {
        // code here

        // create and use SortRowsByMaxElement(matrix);

        // end
    }
    public int[,] SortDiagonal(ref int[,] matrix)
    {
        
        for (int i = 1, j = 2; i < matrix.GetLength(0);)
        {
            if (i == 0 || matrix[i, i] >= matrix[i - 1, i - 1])
            {
                i = j;
                j++;
            }
            else
            {
                int vrem = matrix[i, i];
                matrix[i, i] = matrix[i - 1, i - 1];
                matrix[i - 1, i - 1] = vrem;
                i--;
            }
        }
        return matrix;
    }
    public void Task_2_18(int[,] A, int[,] B)
    {
        // code here

        SortDiagonal(ref A);
        SortDiagonal(ref B);

        // end
    }

    public void Task_2_19(ref int[,] matrix)
    {
        // code here

        // use RemoveRow(matrix, rowIndex); from 2_13

        // end
    }
    public void Task_2_20(ref int[,] A, ref int[,] B)
    {
        dvestidvat(ref A);
        dvestidvat(ref B);
    }
    public void dvestidvat(ref int[,] matrix)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            bool prov = false;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, j] == 0)
                {
                    prov = true;
                    break;
                }
            }
            if (!prov)
            {
                matrix = RemoveColumn(matrix, j);
                j--;
            }
        }
    }

    public void Task_2_21(int[,] A, int[,] B, out int[] answerA, out int[] answerB)
    {
        answerA = null;
        answerB = null;

        // code here

        // create and use CreateArrayFromMins(matrix);

        // end
    }
    public int CountNegativeInRow(int[,] matrix, int rowIndex)
    {
        int cnt = 0;
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (matrix[rowIndex, j] < 0)
            {
                cnt++;
            }
        }
        return cnt;
    }
    public int FindMaxNegativePerColumn(int[,] matrix, int columnIndex)
    {
        int maxn = int.MinValue;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            if (matrix[i, columnIndex] > maxn && matrix[i, columnIndex] < 0)
            {
                maxn = matrix[i, columnIndex];
            }
        }
        return maxn;
    }
    public void Task_2_22(int[,] matrix, out int[] rows, out int[] cols)
    {
        rows = null;
        cols = null;

        // code here
        rows = new int[matrix.GetLength(0)];
        cols = new int[matrix.GetLength(1)];
        // code here
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            rows[i] = CountNegativeInRow(matrix, i);
        }
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            cols[j] = FindMaxNegativePerColumn(matrix, j);
        }

        // end
    }

    public void Task_2_23(double[,] A, double[,] B)
    {
        // code here

        // create and use MatrixValuesChange(matrix);

        // end
    }
    public int FindMax(int[,] matrix)
    {
        int imax = 0; 
        int max = matrix[0, 0];
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] > max)
                {
                    max = matrix[i, j];
                    imax = j;
                }
            }
        }
        return imax;
    }
    public int[,] ChangeDiagonalAndMaxColumn(ref int[,] matrix, int index)
    {
        int[] A = new int[matrix.GetLength(1)];
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            A[i] = matrix[i, i];
            matrix[i, i] = matrix[i, index];
            matrix[i, index] = A[i];
        }
        return matrix;
    }
    public void Task_2_24(int[,] A, int[,] B)
    {
        // code here
        int imaxA = FindMax(A);
        int imaxB = FindMax(B);
        ChangeDiagonalAndMaxColumn(ref A, imaxA);
        ChangeDiagonalAndMaxColumn(ref B, imaxB);
        // end
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
        int k = 0; 
        int cnt; 
        int row = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {

            cnt = CountNegativeInRow(matrix, i);
            if (cnt > k)
            {
                k = cnt;
                row = i;
            }
        }
        return row;
    }
    public void Task_2_26(int[,] A, int[,] B)
    {
        // code here
        int str1 = FindRowWithMaxNegativeCount(A);
        int str2 = FindRowWithMaxNegativeCount(B);
        int[] array1 = new int[A.GetLength(1)];
        int[] array2 = new int[B.GetLength(1)];
        for (int j = 0; j < A.GetLength(1); j++)
        {
            array1[j] = A[str1, j];
            array2[j] = B[str2, j];
        }

        for (int j = 0; j < A.GetLength(1); j++)
        {
            A[str1, j] = array2[j];
            B[str2, j] = array1[j];
        }
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

        // end
    }
    public int FindSequence(int[] arr, int A, int B)
    {
        if (A >= B) 
            return 0;
        bool flag = arr[A] < arr[A + 1];
        for (int i = A; i < B; i++)
        {
            if (flag && arr[i] > arr[i + 1]) 
                return 0;
            if (!flag && arr[i] < arr[i + 1]) 
                return 0;
        }
        return (flag ? 1 : -1);
    }
    public void Task_2_28a(int[] first, int[] second, ref int answerFirst, ref int answerSecond)
    {
        // code here
        answerFirst = FindSequence(first, 0, first.Length - 1);
        answerSecond = FindSequence(second, 0, second.Length - 1);
        // end
    }

    public void Task_2_28b(int[] first, int[] second, ref int[,] answerFirst, ref int[,] answerSecond)
    {
        // code here
        answerFirst = FindSequence1(first, 0, first.Length - 1);
        answerSecond = FindSequence1(second, 0, second.Length - 1);

        // use FindSequence(array, A, B); from Task_2_28a or entirely Task_2_28a
        // A and B - start and end indexes of elements from array for search

        // end
    }
    public int[,] FindSequence1(int[] array, int A, int B)
    {
        int cnt = 0;
        for (int i = A; i < B; i++)
        {
            for (int j = i + 1; j <= B; j++)
            {
                if (FindSequence(array, i, j) != 0)
                    cnt++;
            }
        }
        int[,] C = new int[cnt, 2];
        int indx = 0;
        for (int i = A; i < B; i++)
        {
            for (int j = i + 1; j <= B; j++)
            {
                if (FindSequence(array, i, j) != 0)
                {
                    C[indx, 0] = i;
                    C[indx, 1] = j;
                    indx++;
                }
            }
        }
        return C;
    }


    public void Task_2_28c(int[] first, int[] second, ref int[] answerFirst, ref int[] answerSecond)
    {
        int[,] F = FindSequence1(first, 0, first.Length - 1);
        answerFirst = FindMaxSequence(F);
        int[,] S = FindSequence1(second, 0, second.Length - 1);
        answerSecond = FindMaxSequence(S);
    }
    public int[] FindMaxSequence(int[,] array)
    {
        int imax = int.MinValue;
        int[] G = new int[2];
        for (int i = 0; i < array.GetLength(0); i++)
        {
            if (array[i, 1] - array[i, 0] > imax)
            {
                imax = array[i, 1] - array[i, 0];
                G[0] = array[i, 0];
                G[1] = array[i, 1];
            }
        }
        return G;
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
    public delegate void SortRowStyle(ref int[,] arr, int i);
    public void SortAscending(ref int[,] arr, int i)
    {
        for (int j = 1; j < arr.GetLength(1); j++)
        {
            int a = arr[i, j]; 
            int j2 = j - 1;
            while (j2 >= 0 && arr[i, j2] > a)
            {
                arr[i, j2 + 1] = arr[i, j2];
                j2--;
            }
            arr[i, j2 + 1] = a;
        }
    }
    public void SortDescending(ref int[,] arr, int i)
    {
        for (int j = 1; j < arr.GetLength(1); j++)
        {
            int a = arr[i, j]; 
            int j2 = j - 1;
            while (j2 >= 0 && arr[i, j2] < a)
            {
                arr[i, j2 + 1] = arr[i, j2];
                j2--;
            }
            arr[i, j2 + 1] = a;
        }
    }
    public void Task_3_2(int[,] matrix)
    {
        SortRowStyle sortStyle = default(SortRowStyle);
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            sortStyle = (i % 2 == 0) ? SortAscending : SortDescending;
            sortStyle(ref matrix, i);
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
    public delegate int[] GetTriangle(int[,] arr);
    public int[] GetUpperTriange(int[,] arr)
    {
        int n = arr.GetLength(0);
        int[] trey = new int[n * (n + 1) / 2];
        int a = 0;
        for (int i = 0; i < n; i++)
        {
            for (int j = i; j < n; j++)
            {
                trey[a] = arr[i, j];
                a++;
            }
        }
        return trey;
    }
    public int[] GetLowerTriange(int[,] arr)
    {
        int n = arr.GetLength(0);
        int[] trey = new int[n * (n + 1) / 2];
        int a = 0;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j <= i; j++)
            {
                trey[a] = arr[i, j];
                a++;
            }
        }
        return trey;
    }

    public int GetSum(GetTriangle getTriangle, int[,] arr)
    {
        int summ = 0;
        int[] arr1 = getTriangle(arr);
        for (int i = 0; i < arr1.Length; i++)
            summ += arr1[i] * arr1[i];
        return summ;
    }
    public int Task_3_4(int[,] matrix, bool isUpperTriangle)
    {
        int answer = 0;

        GetTriangle getTriangle = default(GetTriangle);
        getTriangle = (isUpperTriangle) ? GetUpperTriange : GetLowerTriange;
        answer = GetSum(getTriangle, matrix);
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

        // end
    }
    public delegate int FindElementDelegate(int[,] arr);
    public int FindFirstRowMaxIndex(int[,] arr)
    {
        
        int imax = 0;
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            if (arr[0, j] > arr[0, imax])
                imax = j;
        }
        return imax;
    }
    public void SwapColumns(ref int[,] arr, FindElementDelegate findDiagonalMaxIndex, FindElementDelegate findFirstRowMaxIndex)
    {
        int[] str = new int[arr.GetLength(1)];
        int a1 = FindDiagonalMaxIndex(arr);
        int a2 = findFirstRowMaxIndex(arr);
        if (a1 == a2) return;
        for (int i = 0; i < arr.GetLength(0); i++)
        {
            str[i] = arr[i, a1];
            arr[i, a1] = arr[i, a2];
            arr[i, a2] = str[i];
        }
    }
    public void Task_3_6(int[,] matrix)
    {
        // code here

        SwapColumns(ref matrix, FindDiagonalMaxIndex, FindFirstRowMaxIndex);

        // end
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
    public delegate int FindIndex(int[,] matrix);
    public int FindMaxBelowDiagonalIndex(int[,] matrix)
    {
        int imax = 0;
        int jmax = 0;
        int max = int.MinValue;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j <= i; j++)
            {
                if (matrix[i, j] > max)
                {
                    imax = i;
                    jmax = j;
                    max = matrix[i, j];
                }
            }
        }
        return jmax;
    }
    public int FindMinAboveDiagonalIndex(int[,] matrix)
    {
        int imin = 0;
        int jmin = 0;
        int min = int.MaxValue;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = i + 1; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] < min)
                {
                    imin = i;
                    jmin = j;
                    min = matrix[i, j];
                }
            }
        }
        return jmin;
    }
    public void RemoveColumns(ref int[,] matrix, int maxBelowIndex, int minAboveIndex)
    {
        if (maxBelowIndex == minAboveIndex)
        {
            matrix = RemoveColumn(matrix, Math.Max(maxBelowIndex, minAboveIndex));
        }
        else
        {
            matrix = RemoveColumn(matrix, Math.Max(maxBelowIndex, minAboveIndex));
            matrix = RemoveColumn(matrix, Math.Min(maxBelowIndex, minAboveIndex));
        }
    }
    public void Task_3_10(ref int[,] matrix)
    {
        FindIndex a = default(FindIndex);

        // code here
        a = FindMaxBelowDiagonalIndex;
        int maxBelowIndex = a(matrix);
        a = FindMinAboveDiagonalIndex;
        int minAboveIndex = a(matrix);
        RemoveColumns(ref matrix, maxBelowIndex, minAboveIndex);

    }

    public void Task_3_13(ref int[,] matrix)
    {
        // code here

        // use public delegate FindElementDelegate(matrix) from Task_3_6
        // create and use method RemoveRows(matrix, findMax, findMin)

        // end
    }
    
    public delegate int GetNegativeArray(int[,] matrix, int rowIndex);
    public void FindNegatives(int[,] matrix, out int[] rows, out int[] cols)
    {
        rows = new int[matrix.GetLength(0)];
        cols = new int[matrix.GetLength(1)];
        GetNegativeArray pou = CountNegativeInRow;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            rows[i] = pou(matrix, i);
        }
        pou = FindMaxNegativePerColumn;
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            cols[j] = pou(matrix, j);
        }
    }
    public void Task_3_22(int[,] matrix, out int[] rows, out int[] cols)
    {

        rows = null;
        cols = null;

        // code here

        FindNegatives(matrix, out rows, out cols);

        // end
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
    public delegate bool IsSequence(int[] arr, int left, int right);

    public bool findIncreasingSequence(int[] arr, int a, int b)
    {
        int a1 = FindSequence(arr, a, b);
        return (a1 == 1);
    }
    public bool findDecreasingSequence(int[] arr, int a, int b)
    {
        int a1 = FindSequence(arr, a, b);
        return (a1 == -1);
    }
    public int DefineSequence(int[] arr, IsSequence findIncreasingSequence, IsSequence findDecreasingSequence)
    {
        if (findIncreasingSequence(arr, 0, arr.Length - 1))
            return 1;
        else if (findDecreasingSequence(arr, 0, arr.Length - 1))
            return -1;
        else
            return 0;
    }
    public void Task_3_28a(int[] first, int[] second, ref int answerFirst, ref int answerSecond)
    {
        // code here

        answerFirst = DefineSequence(first, findIncreasingSequence, findDecreasingSequence);
        answerSecond = DefineSequence(second, findIncreasingSequence, findDecreasingSequence);

        // end
    }
    public int[] FindLongestSequence(int[] arr, IsSequence sequence)
    {
        int a1 = 0, a2 = 0;
        for (int i = 0; i < arr.Length; i++)
            for (int j = i + 1; j < arr.Length; j++)
                if (sequence(arr, i, j) && j - i > a2 - a1)
                {
                    a1 = i;
                    a2 = j;
                }
        return [a1, a2];
    }
    public void Task_3_28c(int[] first, int[] second, ref int[] answerFirstIncrease, ref int[] answerFirstDecrease, ref int[] answerSecondIncrease, ref int[] answerSecondDecrease)
    {
        // code here

        answerFirstDecrease = FindLongestSequence(first, findDecreasingSequence);
        answerFirstIncrease = FindLongestSequence(first, findIncreasingSequence);
        answerSecondDecrease = FindLongestSequence(second, findDecreasingSequence);
        answerSecondIncrease = FindLongestSequence(second, findIncreasingSequence);

        // end
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
        matrix = mc[index](matrix);
        
        return matrix;
    }
 
    public delegate double[,] MatrixConverter(double[,] matrix);
    public double[,] ToUpperTriangular(double[,] matrix)
    {
        int n = matrix.GetLength(0);
        for (int j = 0; j <= n - 2; j++)
        {
            for (int k = j + 1; k <= n - 1; k++)
            {
                double a = matrix[k, j] / matrix[j, j];
                for (int l = j; l <= n - 1; l++)
                {
                    matrix[k, l] = matrix[k, l] - (matrix[j, l] * a);
                }
            }
        }
        return matrix;
    }
    public double[,] ToLowerTriangular(double[,] matrix)
    {
        int n = matrix.GetLength(0);
        for (int j = n - 1; j >= 0; j--)
        {
            for (int k = j - 1; k >= 0; k--)
            {
                double a = matrix[k, j] / matrix[j, j];
                for (int l = 0; l <= n - 1; l++)
                {
                    matrix[k, l] = matrix[k, l] - (matrix[j, l] * a);
                }
            }
        }
        return matrix;
    }
    public double[,] ToLeftDiagonal(double[,] matrix)
    {
        return ToLowerTriangular(ToUpperTriangular(matrix));
    }
    public double[,] ToRightDiagonal(double[,] matrix)
    {
        return ToUpperTriangular(ToLowerTriangular(matrix));
    }

    #endregion
}
