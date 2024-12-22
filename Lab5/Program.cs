using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.Numerics;
using System.Reflection;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;
using static Program;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class Program
{
    public static void Main()
    {
        Program program = new Program();
        //program.Task_2_8(new int[] { 1, 12, 3, 4, 5, -6, 7, 0, 9 }, new int[] { 1, 12, 13, 0, 9, 1, 5, -6, 7, 12, 14 });
        program.SortNegative(new int[] { 1, -8, -3, 5, -5, 1, 0, -4, -1, 2 });
    }
    #region Level 1
        public int Factorial(int a)
        {
            int f = 1;
            for(int i = 2; i <= a; i++)
            {
                f *= i;
            }
            return f;
        }

    public long Task_1_1(int n, int k)
    {
        long answer = 0;

        // code here
        if(n < k ||  k < 0 || n < 0) { return 0; } 
        int cnm = Factorial(n) / (Factorial(k) * Factorial(n - k));
        answer = cnm;
        // end

        return answer;
    }


    public double GeronArea(double a, double b, double c)
    {
        double p = (a + b + c) / 2;
        double s = Math.Sqrt(p * (p - a)* (p - b)* (p - c));
        return s;
    }
    public bool Exist(double a, double b, double c)
    {
        return (a < b + c) && (b < a + c) && (c < b + a);
    }
    public int Task_1_2(double[] first, double[] second)
    {
        int answer = 0;

        // code here
        double a1 = first[0], b1 = first[1], c1 = first[2];
        double a2 = second[0], b2 = second[1], c2 = second[2];
        if (!Exist(a1, b1, c1) || !Exist(a2, b2, c2)) { return -1; }

        double s1 = GeronArea(a1, b1, c1);
        double s2 = GeronArea(a2, b2, c2);
        if (s1 > s2)
        {
            answer = 1;
        }
        else if (s1 < s2)
        {
            answer = 2;
        }
        else if(s1 == s2)
        {
            answer = 0;
        }
        else 
        {
            answer = -1;        
        }
        // first = 1, second = 2, equal = 0, error = -1
        // end

        return answer;
    }


    public double GetDistance(double v, double a, double t)
    {
        double s = v*t + a*t*t/2;
        return s;
    }
    public int Task_1_3a(double v1, double a1, double v2, double a2, int time)
    {
        int answer = 0;

        // code here

        double S1 = GetDistance(v1, a1, time);
        double S2 = GetDistance(v2, a2, time);
        if (S1 > S2)
        {
            answer = 1;
        }
        else if (S1 < S2)
        {
            answer = 2;
        }
        else
        {
            answer = 0;
        }

        // end

        // first = 1, second = 2, equal = 0
        return answer;
    }

    public int Task_1_3b(double v1, double a1, double v2, double a2)
    {
        int answer = 0;

        // code here
        int time = 1;
        while (GetDistance(v1, a1, time) > GetDistance(v2, a2, time))
        {
            time += 1;
        }
        answer = time;
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


    public int FindMaxIndex(double[] array)
    {
        int answer = 0;
        int n  = array.Length;
        for(int i = 0; i < n; i++)
        {
            if(array[i] > array[answer])
            {
                answer = i;
            }
        }
        return answer;
    }
    public void Task_2_2(double[] A, double[] B)
    {
        // code here
        int imaxa = FindMaxIndex(A);
        int imaxb = FindMaxIndex(B);

        if (imaxa < imaxb)
        {
            double s1 = 0, k1 = 0;
            for (int i = imaxa + 1; i < A.Length; i++)
            {
                s1 += A[i];
                k1++;
            }
            double sr1 = s1 / k1;
            A[imaxa] = sr1;
        }
        else
        {
            double s2 = 0, k2 = 0;
            for (int i = imaxb + 1; i < B.Length; i++)
            {
                s2 += B[i];
                k2++;
            }
            double sr2 = s2 / k2;
            B[imaxb] = sr2;
        }
        // end
    }

    public void Task_2_3(ref int[,] B, ref int[,] C)
    {
        // code here

        //  create and use method FindDiagonalMaxIndex(matrix);

        // end
    }


    //public int FindDiagonalMaxIndex(int [,] matrix)
    //{
    //    int answer = 0;
    //    for( int i = 0; i < matrix.GetLength(0); i++)
    //    {

    //    }
    //    return answer;
    //}
    public int FindDiagonalMaxIndex(int[,] matrix)
    {
        int ind = 0;
        for(int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if(i == j)
                {
                    if(matrix[i, j] > matrix[ind, ind])
                    {
                        ind = i;
                    }
                }
            }
        }
        return ind;
    }

    public void Task_2_4(int[,] A, int[,] B)
    {
        // code here
        int n = A.GetLength(0);
        int ia = FindDiagonalMaxIndex(A);
        int jb = FindDiagonalMaxIndex(B);
        int[] stroka = new int [n];
        for(int j = 0; j < n; j++)
        {
            stroka[j] = A[ia, j];
        }

        for(int j = 0; j < n; j++)
        {
            A[ia, j] = B[j, jb];
        }

        for (int i = 0; i < n; i++)
        {
            B[i, jb] = stroka[i];
        }

        //  create and use method FindDiagonalMaxIndex(matrix); like in Task_2_3

        // end
    }

    public void Task_2_5(int[,] A, int[,] B)
    {
        // code here

        // create and use FindMaxInColumn(matrix, columnIndex, out rowIndex);

        // end
    }


    public int FindMax(int[] array)
    {
        int imax = 0;
        for(int i = 0; i < array.Length; i++)
        {
            if (array[i] > array[imax])
            {
                imax = i;
            }
        }
        return imax;
    }

    public int[] DeleteElement(int[] array, int index)
    {
        int[] na = new int[array.Length-1];
        for(int i = 0; i < index; i++)
        {
            na[i] = array[i];
        }
        for(int i = index; i < na.Length; i++)
        {
            na[i] = array[i + 1];
        }
        return na;
    }
    public void Task_2_6(ref int[] A, int[] B)
    {
        // code here
        int[] answer = new int[A.Length + B.Length - 2]; 
        int imaxa = FindMax(A);
        int imaxb = FindMax(B);
        int[] newA = DeleteElement(A, imaxa);
        int[] newB = DeleteElement(B, imaxb);
        int ind = 0;
        for (int i = 0; i < newA.Length; i++)
        {
            answer[ind] = newA[i];
            ind++;
        }
        for (int i = 0; i < newB.Length; i++)
        {
            answer[ind] = newB[i];
            ind++;
        }
        A = answer;
        // end
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
        for(int i = startIndex+2, j = startIndex + 2 + 1; i < array.Length;)
        {
            if(i == startIndex + 1 || array[i] >= array[i-1])
            {
                i = j;
                j++;
            }
            else
            {
                int temp = array[i];
                array[i] = array[i-1];
                array[i-1] = temp;
                i--;
            }
            
        }
        return array;
    }
    public void Task_2_8(int[] A, int[] B)
    {
        // code here
        int imaxa = 0;
        for (int i = 0; i < A.Length; i++)
        {
            if (A[i] > A[imaxa])
            {
                imaxa = i;
            }
        }

        int imaxb = 0;
        for (int j = 0; j < B.Length; j++)
        {
            if (B[j] > B[imaxb])
            {
                imaxb = j;
            }
        }

        A = SortArrayPart(A, imaxa);
        B = SortArrayPart(B, imaxb);


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

    public void RemoveColumn(ref int[,] matrix, int columnIndex)
    {
        int rows = matrix.GetLength(0), cols = matrix.GetLength(1);
        int[,] newm = new int[rows, cols - 1];
        for (int j = 0; j < cols-1; j++)
        {
            if(j < columnIndex)
            {
                for (int i = 0; i < rows; i++)
                {
                    newm[i, j] = matrix[i, j];
                }
            }
            else
            {
                for (int i = 0; i < rows; i++)
                {
                    newm[i, j] = matrix[i, j + 1];
                }
            }
        }
        matrix = newm;
    }
    public void Task_2_10(ref int[,] matrix)
    {
        // code here

        int rows = matrix.GetLength(0), cols = matrix.GetLength(1);
        //if(rows != cols) { return; }
        int jmax = 0;
        int max = matrix[0, 0];
        for(int i = 0;i < rows; i++)
        {
            for(int j = 0; j <= i; j++)
            {
                if (matrix[i, j] > max)
                {
                    jmax = j;
                    max = matrix[i, j];
                }
            }
        }
        int jmin = 1;
        int min = matrix[0, 1];
        for (int i = 1; i < rows-1; i++)
        {
            for (int j = i+1; j < cols; j++)
            {
                if (matrix[i, j] < min)
                {
                    jmin = j;
                    min = matrix[i, j];
                }
            }
        }
        if(jmax < jmin)
        {
            RemoveColumn(ref matrix, jmin);
            RemoveColumn(ref matrix, jmax);
        }
        else if(jmax > jmin)
        {
            RemoveColumn(ref matrix, jmax);
            RemoveColumn(ref matrix, jmin);
        }
        else
        {
            RemoveColumn(ref matrix, jmax);
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
        int rows = matrix.GetLength(0), cols = matrix.GetLength(1);
        int jindex = 0;
        int max = matrix[0, 0];
        for(int i = 0; i < rows; i++)
        {
            for(int j = 0; j < cols; j++)
            {
                if(matrix[i, j] > max)
                {
                    max = matrix[i, j];
                    jindex = j;
                }
            }
        }
        return jindex;
    }
    public void Task_2_12(int[,] A, int[,] B)
    {
        // code here
        int rows = A.GetLength(0), cols = A.GetLength(1);
        int jmax1 = FindMaxColumnIndex(A);
        int jmax2 = FindMaxColumnIndex(B);

        for(int i = 0; i < rows; i++)
        {
            int temp = A[i, jmax1];
            A[i, jmax1] = B[i, jmax2];
            B[i, jmax2] = temp;
        }
        // end
    }

    public void Task_2_13(ref int[,] matrix)
    {
        // code here

        // create and use RemoveRow(matrix, rowIndex);

        // end
    }

    public int[,] SortRow(int[,] matrix, int rowIndex)
    {
        for (int j = 1; j < matrix.GetLength(1); j++)
        {
            int key = matrix[rowIndex, j], k = j - 1;
            while(k >= 0 && matrix[rowIndex, k] > key)
            {
                matrix[rowIndex, k+1] = matrix[rowIndex, k];
                k--;
            }
            matrix[rowIndex, k + 1] = key;
        }
        return matrix;
    }
    public void Task_2_14(int[,] matrix)
    {
        // code here
        int rows = matrix.GetLength(0);
        for(int i = 0; i < rows; i++)
        {
            matrix = SortRow(matrix, i);
        }
        

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


    public int[] SortNegative(int[] array)
    {
        int k = 0;
        for(int i = 0; i < array.Length; i++)
        {
            if (array[i] < 0)
            {
                k++;
            }
        }
        int[] na = new int[k];
        int ind = 0;
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] < 0)
            {
                na[ind] = array[i];
                ind++;
            }
        }


        for(int i = 0; i < k; i++)
        {
            for(int j = 0; j < k -i - 1; j++)
            {
                if (na[j] < na[j+1])
                {
                    int temp = na[j];
                    na[j] = na[j+1];
                    na[j+1] = temp;
                }
            }
        }

        int p = 0;
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] < 0)
            {
                array[i] = na[p];
                p++;
            }
        }

        return na;
    }
    public void Task_2_16(int[] A, int[] B)
    {
        // code here
        A = SortNegative(A); 
        B = SortNegative(B);
        

        // end
    }

    public void Task_2_17(int[,] A, int[,] B)
    {
        // code here

        // create and use SortRowsByMaxElement(matrix);

        // end
    }

    public int[,] SortDiagonal(int[,] matrix)
    {
        int rows = matrix.GetLength(0), cols = matrix.GetLength(1);
        int[] a = new int[rows];
        int k = 0;
        for(int i = 0; i < rows; i++)
        {
            for(int j = 0; j < cols; j++)
            {
                if(i == j)
                {
                    a[k] = matrix[i, j];
                    k++;
                }
            }
        }

        for (int n = 1, m = 2; n < a.Length;)
        {
            if (n == 0 || a[n] >= a[n - 1])
            {
                n = m;
                m++;
            }
            else
            {
                int temp = a[n];
                a[n] = a[n - 1];
                a[n - 1] = temp;
                n--;
            }

        }

        int ind = 0;
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (i == j)
                {
                    matrix[i, j] = a[ind];
                    ind++;
                }
            }
        }
        return matrix;
    }
    public void Task_2_18(int[,] A, int[,] B)
    {
        // code here
        A = SortDiagonal(A);
        B = SortDiagonal(B);
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
        // code here
        int arows = A.GetLength(0), acols = A.GetLength(1);
        int brows = B.GetLength(0), bcols = B.GetLength(1);

        for (int j = acols-1; j >= 0; j--)
        {
            int k = 0;
            for(int i = 0; i < arows; i++)
            {
                if (A[i, j] == 0)
                {
                    k++;
                }
            }    
            if(k == 0)
            {
                RemoveColumn(ref A, j);
            }
        }

        for (int j = bcols-1; j >= 0; j--)
        {
            int k = 0;
            for (int i = 0; i < brows; i++)
            {
                if (B[i, j] == 0)
                {
                    k++;
                }
            }
            if (k == 0)
            {
                RemoveColumn(ref B, j);
            }
        }
        // end
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
        int kolvo = 0;
        for(int j = 0; j < matrix.GetLength(1); j++)
        {
            if (matrix[rowIndex, j]  < 0)
            {
                kolvo++;
            }
        }
        return kolvo;
    }

    public int[] FindMaxNegativePerColumn(int[,] matrix)
    {
        int rows = matrix.GetLength(0), cols = matrix.GetLength(1);
        int[] a = new int[cols];
        int ind = 0;
        int imax = 0;
        for(int j = 0; j < cols; j++)
        {
            for(int i = 0; i < rows; i++)
            {
                if(matrix[i, j] < 0)
                {
                    imax = i;
                    break;
                }
            }
            for(int i = 0; i < rows; i++)
            {
                if(matrix[i, j] < 0)
                {
                    if (matrix[i,j] > matrix[imax,j])
                    {
                        imax = i;
                    }
                }
                else
                {
                    continue;
                }
            }
            a[ind] = matrix[imax, j];
            ind++;
            
        }
        return a;
    }
    public void Task_2_22(int[,] matrix, out int[] rows, out int[] cols)
    {
        rows = null;
        cols = null;

        // code here
         
        int n = matrix.GetLength(0), m = matrix.GetLength(1);
        int[] c = new int[n];

        for (int i = 0; i < n; i++)
        {
            c[i] = CountNegativeInRow(matrix, i);
        }

        rows = c;
        cols = FindMaxNegativePerColumn(matrix);

        // end
    }

    public void Task_2_23(double[,] A, double[,] B)
    {
        // code here

        // create and use MatrixValuesChange(matrix);

        // end
    }

    public void FindMaxIndex(int[,] matrix, out int row, out int column)
    {

        row = 0;
        column = 0;
        int rows = matrix.GetLength(0), cols = matrix.GetLength(1);
        int max = matrix[0, 0];
        for(int i = 0; i < rows; i++)
        {
            for(int j = 0; j < cols; j++)
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

    public int[,] SwapColumnDiagonal(int[,] matrix, int columnIndex)
    {
        int rows = matrix.GetLength(0), cols = matrix.GetLength(1);
        for (int i = 0; i < rows; i++)
        {
            int temp = matrix[i, columnIndex];
            matrix[i, columnIndex] = matrix[i, i];
            matrix[i, i] = temp;
        }

        return matrix;
    }
    public void Task_2_24(int[,] A, int[,] B)
    {
        // code here

        int row;
        int col;
        FindMaxIndex(A, out row, out col);
        A = SwapColumnDiagonal(A, col);

        FindMaxIndex(B, out row, out col);
        B = SwapColumnDiagonal(B, col);

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

    public int FindRowWithMaxNegativeCount(int [,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        int mx = CountNegativeInRow(matrix, 0);
        int ind = 0;
        for(int i = 0; i < rows; i++)
        {
            if(CountNegativeInRow(matrix, i) > mx)
            {
                mx = CountNegativeInRow(matrix, i);
                ind = i;
            }
        }
        return ind;
    }

    public void Task_2_26(int[,] A, int[,] B)
    {
        // code here

        int i1 = FindRowWithMaxNegativeCount(A);
        int i2 = FindRowWithMaxNegativeCount(B);

        for(int j = 0; j < A.GetLength(1); j++)
        {
            int temp = A[i1, j];
            A[i1, j] = B[i2, j];
            B[i2, j] = temp;
        }
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

    static bool up(int[] array, int A, int B)
    {
        bool ok = true;
        for(int i = A; i < B; i++)
        {
            if (array[i] > array[i+1])
            {
                ok = false;
            }
        }
        return ok;
    }
    static bool down(int[] array, int A, int B)
    {
        bool ok = true;
        for (int i = A; i < B; i++)
        {
            if (array[i] < array[i + 1])
            {
                ok = false;
            }
        }
        return ok;
    }
    public int FindSequence(int[] array, int A, int B)
    {
        int ans = -2;
        if(up(array, A, B))
        {
            ans = 1;
        }
        else if(down(array, A, B))
        {
            ans = -1;
        }
        else
        {
            ans = 0;
        }
        return ans;
    }
    public void Task_2_28a(int[] first, int[] second, ref int answerFirst, ref int answerSecond)
    {
        // code here
        answerFirst = FindSequence(first, 0, first.Length - 1);
        answerSecond = FindSequence(second, 0, second.Length - 1);
        // create and use FindSequence(array, A, B); // 1 - increasing, 0 - no sequence,  -1 - decreasing
        // A and B - start and end indexes of elements from array for search

        // end
    }

    public int[,] Monointer(int[] array, int A, int B)
    {
        int k = 0;
        for (int i = A; i < B; i++)
        {
            for (int j = i + 1; j <= B; j++)
            {
                if (FindSequence(array, i, j) != 0)
                {
                    k++;
                }
            }
        }
        int[,] matrix = new int[k, 2]; 
        int ind = 0;
        for (int i = A; i < B; i++)
        {
            for (int j = i + 1; j <= B; j++)
            {
                if (FindSequence(array, i, j) != 0)
                {
                    matrix[ind, 0] = i;
                    matrix[ind, 1] = j;
                    ind++;
                }
            }
        }
        return matrix;
    }

    public void Task_2_28b(int[] first, int[] second, ref int[,] answerFirst, ref int[,] answerSecond)
    {
        // code here

        answerFirst = Monointer(first, 0, first.Length - 1);
        answerSecond = Monointer(second, 0, second.Length - 1);

        // end
    }


    public int[] MaxSeq(int[,] matrix)
    {
        int k = 0;
        int[] interval = new int[2];
        int mx = matrix[0, 1] - matrix[0, 0];
        for(int i = 0; i < matrix.GetLength(0); i++)
        {
             if(matrix[i, 1] - matrix[i, 0] > mx)
            {
                mx = matrix[i, 1] - matrix[i, 0];
                interval[0] = matrix[i, 0];
                interval[1] = matrix[i, 1];
            }
        }
        return interval;
    }
    public void Task_2_28c(int[] first, int[] second, ref int[] answerFirst, ref int[] answerSecond)
    {
        // code here
        int[,] fd = Monointer(first, 0, first.Length - 1);
        answerFirst = MaxSeq(fd);
        int[,] sd = Monointer(second, 0, second.Length - 1);
        answerSecond = MaxSeq(sd);

        // use FindSequence(array, A, B); from Task_2_28a or entirely Task_2_28a or Task_2_28b
        // A and B - start and end indexes of elements from array for search

        // end
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

    public delegate void SortRowStyle(ref int[,] matrix, int rowIndex);

    public static void SortAscending(ref int[,] matrix, int rowIndex)
    {
        for(int j = 0; j < matrix.GetLength(1) - 1; j++)
        {
            for(int j1 = j + 1; j1 < matrix.GetLength(1); j1++)
            {
                if (matrix[rowIndex, j] > matrix[rowIndex, j1])
                {
                    int temp = matrix[rowIndex, j];
                    matrix[rowIndex, j] = matrix[rowIndex, j1];
                    matrix[rowIndex, j1] = temp;
                }
            }
        }
    }

    public static void SortDescending(ref int[,] matrix, int rowIndex)
    {
        for (int j = 0; j < matrix.GetLength(1) - 1; j++)
        {
            for (int j1 = j + 1; j1 < matrix.GetLength(1); j1++)
            {
                if (matrix[rowIndex, j] < matrix[rowIndex, j1])
                {
                    int temp = matrix[rowIndex, j];
                    matrix[rowIndex, j] = matrix[rowIndex, j1];
                    matrix[rowIndex, j1] = temp;
                }
            }
        }
    }
    public void Task_3_2(int[,] matrix)
    {
         SortRowStyle sortStyle = default(SortRowStyle);

        // code here
        SortRowStyle sortingDelegate;
        for(int i = 0; i <  matrix.GetLength(0); i++)
        {
            if(i % 2 == 0)
            {
                sortStyle = SortAscending;
            }
            else
            {
                sortStyle = SortDescending;
            }
            sortStyle(ref matrix, i);
        }
        // create and use public delegate SortRowStyle(matrix, rowIndex);
        // create and use methods SortAscending(matrix, rowIndex) and SortDescending(matrix, rowIndex)
        // change method in variable sortStyle in the loop here and use it for row sorting

        // end
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

    public delegate int[] GetTriangle(int[,] matrix);
    public int[] GetUpperTriange(int[,] matrix)
    {
        int k = 0;
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        for(int i = 0; i < rows; i++)
        {
            for(int j = i; j < cols; j++)
            {
                k++;
            }
        }
        int[] up = new int[k];
        int ind = 0;
        for (int i = 0; i < rows; i++)
        {
            for (int j = i; j < cols; j++)
            {
                up[ind] = matrix[i, j];
                ind++;
            }
        }
        return up;
    }

    public int[] GetLowerTriange(int[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int k = 0;
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j <= i; j++)
            {
                k++;
            }
        }
        int[] down = new int[k];
        int ind = 0;
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j <= i; j++)
            {
                down[ind] = matrix[i, j];
                ind++;
            }
        }
        return down;
    }

    public int GetSum(GetTriangle a, int[,] matrix) 
    {
        int s = 0;
        int[] array = a(matrix);
        for(int i = 0; i < array.Length; i++)
        {
            s += array[i] * array[i];
        }
        return s;
    }

    //public int GetSum()
    public int Task_3_4(int[,] matrix, bool isUpperTriangle)
    {
        int answer = 0;

        // code here
        GetTriangle Get;
        if(isUpperTriangle)
        {
            Get = GetUpperTriange;
        }
        else
        {
            Get = GetLowerTriange;
        }
        answer = GetSum(Get, matrix);
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

        // end
    }

    public delegate int FindElementDelegate(int[,]matrix);
    public int FindFirstRowMaxIndex(int[,] matrix)
    {
        int ind = 0;
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        for(int j = 0; j < cols; j++)
        {
            if (matrix[0, j] > matrix[0, ind])
            {
                ind = j;
            }
        }
        return ind;
    }
    public int[,] SwapColumns(int[,] matrix, FindElementDelegate diagonal, FindElementDelegate firstRow)
    {
        int i_diagonal = diagonal(matrix);
        int first = firstRow(matrix);
        int rows = matrix.GetLength(0);
        for (int i = 0; i < rows; i++)
        {
            int temp = matrix[i, i_diagonal];
            matrix[i, i_diagonal] = matrix[i, first];
            matrix[i, first] = temp;
        }
        return matrix;
    }
    public void Task_3_6(int[,] matrix)
    {
        // code here
        FindElementDelegate diag;
        diag = FindDiagonalMaxIndex;
        FindElementDelegate firstrow;
        firstrow = FindFirstRowMaxIndex;
        matrix = SwapColumns(matrix, diag, firstrow);
        // create and use public delegate FindElementDelegate(matrix);
        // use method FindDiagonalMaxIndex(matrix) like in Task_2_3;
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
        // create and use method InsertColumn(matrixB, CountRow, matrixC, CountColumn);

        // end
    }
    //public delegate int FindIndex(int[,] matrix);
    //public void RemoveColumns(ref int[,] matrix, FindIndex maxi, FindIndex mini)
    //{
    //    int jmax = maxi(matrix);
    //    int jmin = mini(matrix);
    //    if(jmax == jmin)
    //    {
    //        RemoveColumn(ref matrix, jmax);
    //    }
    //    else
    //    {
    //        RemoveColumn(ref matrix, jmax);
    //        RemoveColumn(ref matrix, jmin);
    //    }
    //}
    //public int FindMaxBelowDiagonalIndex(int[,] matrix)
    //{
    //    int rows = matrix.GetLength(0), cols = matrix.GetLength(1);
    //    int max = matrix[0, 0];
    //    int jmax = 0;
    //    for (int i = 0; i < rows; i++)
    //    {
    //        for (int j = 0; j < i + 1; j++)
    //        {
    //            if (matrix[i, j] > max)
    //            {
    //                max = matrix[i, j];
    //                jmax = j;
    //            }
    //        }
    //    }
    //    return jmax;
    //}
    //public int FindMinAboveDiagonalIndex(int[,] matrix)
    //{
    //    int rows = matrix.GetLength(0), cols = matrix.GetLength(1);
    //    int min = matrix[0, 1];
    //    int jmin = 1;
    //    for (int i = 0; i < rows-1; i++)
    //    {
    //        for (int j = i+1; j < cols; j++)
    //        {
    //            if (matrix[i, j] < min)
    //            {
    //                min = matrix[i, j];
    //                jmin = j;
    //            }
    //        }
    //    }
    //    return jmin;
    //}
    public delegate int FindIndex(int[,] matrix);
    public void RemoveColumns(ref int[,] matrix, FindIndex maxi, FindIndex mini)
    {
        int indexMaxi = maxi(matrix);
        int indexMini = mini(matrix);
        if (indexMaxi == indexMini) RemoveColumn(ref matrix, indexMaxi);
        else
        {
            RemoveColumn(ref matrix, indexMaxi);
            RemoveColumn(ref matrix, indexMini);
        }
    }
    public int FindMaxBelowDiagonalIndex(int[,] matrix)
    {
        int n = matrix.GetLength(0), m = matrix.GetLength(1);
        int maxi = matrix[0, 0], indexMaxi = 0;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < i + 1; j++)
            {
                if (matrix[i, j] > maxi)
                {
                    maxi = matrix[i, j];
                    indexMaxi = j;
                }
            }
        }
        return indexMaxi;
    }
    public int FindMinAboveDiagonalIndex(int[,] matrix)
    {
        int n = matrix.GetLength(0), m = matrix.GetLength(1);
        int mini = matrix[0, 1], indexMini = 1;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = i + 1; j < m; j++)
            {
                if (matrix[i, j] < mini)
                {
                    mini = matrix[i, j];
                    indexMini = j;
                }
            }
        }
        return indexMini;
    }
    public void Task_3_10(ref int[,] matrix)
    {
        // code here
        FindIndex maxi = default(FindIndex);
        FindIndex mini = default(FindIndex);
        maxi = FindMaxBelowDiagonalIndex;
        mini = FindMinAboveDiagonalIndex;
        RemoveColumns(ref matrix, maxi, mini);
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

        // end
    }


    public delegate int GetNegativeArray(int[,] matrix, int ind);
    public void FindNegatives(int[,] matrix, GetNegativeArray r, GetNegativeArray col, out int[] rows, out int[] cols)
    {
        int n = matrix.GetLength(0), m = matrix.GetLength(1);
        rows = new int[matrix.GetLength(0)];
        cols = new int[matrix.GetLength(1)];
        for(int i = 0; i < n; i++)
        {
            rows[i] = r(matrix, i);
        }
        for(int j = 0; j < m; j++)
        {
            cols[j] = col(matrix, j);
        }
    }
    public int FindMaxNegativePerColumn(int[,] matrix, int indexcolumn)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        int max = Int32.MinValue;
        for (int i = 0; i < cols; i++)
        {
            if (matrix[i, indexcolumn] < 0 && matrix[i, indexcolumn] > max)
            {
                max = matrix[i, indexcolumn];
            }
        }
        return max;
    }
    public void Task_3_22(int[,] matrix, out int[] rows, out int[] cols)
    {

        rows = null;
        cols = null;

        // code here
        GetNegativeArray arows;
        GetNegativeArray acols;
        arows = CountNegativeInRow;
        acols = FindMaxNegativePerColumn;
        FindNegatives(matrix, arows, acols, out rows, out cols);
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

        // end
    }

    public delegate bool IsSequence(int[] array, int left, int right);
    public bool FindIncreasingSequence(int[] array, int A, int B)
    {
        bool ok = true;
        for (int i = A; i < B; i++)
        {
            if (array[i] > array[i + 1])
            {
                ok = false;
            }
        }
        return ok;
    }

    public bool FindDecreasingSequence(int[] array, int A, int B)
    {
        bool ok = true;
        for (int i = A; i < B; i++)
        {
            if (array[i] < array[i + 1])
            {
                ok = false;
            }
        }
        return ok;
    }

    public int DefineSequence(int[] array, IsSequence increase, IsSequence decrease)
    {
        int ans = -2;
        int n = array.Length;
        if(up(array, 0, n - 1))
        {
            ans = 1;
        }
        else if(down(array, 0, n - 1))
        {
            ans = -1;
        }
        else
        {
            ans = 0;
        }
        return ans;
    }
    public void Task_3_28a(int[] first, int[] second, ref int answerFirst, ref int answerSecond)
    {
        // code here
        IsSequence increase = FindIncreasingSequence;
        IsSequence decrease = FindDecreasingSequence;
        answerFirst = DefineSequence(first, increase, decrease);
        answerSecond = DefineSequence(second, increase, decrease);
        // create public delegate IsSequence(array, left, right);
        // create and use method FindIncreasingSequence(array, A, B); similar to FindSequence(array, A, B) in Task_2_28a
        // create and use method FindDecreasingSequence(array, A, B); similar to FindSequence(array, A, B) in Task_2_28a
        // create and use method DefineSequence(array, findIncreasingSequence, findDecreasingSequence);

        // end
    }
    
    public int[] FindLongestSequence(int[] array, IsSequence sequence)
    {
        int max = -1;
        int[] ans = new int[2];
        for (int i = 0; i < array.Length-1; i++)
        {
            for(int j = i+1; j < array.Length; j++)
            {
                if(sequence(array, i, j))
                {
                    if(j - i > max)
                    {
                        max = j- i;
                        ans[0] = i;
                        ans[1] = j;
                    }
                }
            }
        }
        return ans;
    }
    public void Task_3_28c(int[] first, int[] second, ref int[] answerFirstIncrease, ref int[] answerFirstDecrease, ref int[] answerSecondIncrease, ref int[] answerSecondDecrease)
    {
        // code here
        IsSequence increase = FindIncreasingSequence;
        IsSequence decrease = FindDecreasingSequence;
        answerFirstIncrease = FindLongestSequence(first, increase);
        answerFirstDecrease = FindLongestSequence(first, decrease);
        answerSecondIncrease = FindLongestSequence(second, increase);
        answerSecondDecrease = FindLongestSequence(second, decrease);
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
