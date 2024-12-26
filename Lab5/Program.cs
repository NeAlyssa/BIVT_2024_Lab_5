using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Data;
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
        int[]A = new int[]{1,2 ,8, -3, 14, 55, 6};
        int []B= new int[]{0, 9, 8, 14, 7, 6, 5,4};
        int[,] matrix4x4 = new int[,] {
            { 1,-22, 3, 4 },
            { 5,-5, 5,-5 },
            {62, 7, 8, 9 },
            {-6,-5,-8, 0 }};
        program.Task_2_14( matrix4x4);
        //program.Task_2_8( A, B);
    }
    public void Print(int[] array)
    {
        int n = array.Length;
        for (int i =0;i<n;i++)
        {
            Console.Write(array[i] +" ");
        }
        System.Console.WriteLine();
    }
    public void Print(int[,]matr)
    {
        int n = matr.GetLength(0);
        int m = matr.GetLength(1);
        for (int i =0;i<n;i++)
        {
            for (int j =0;j<m;j++)
            {
                Console.Write(matr[i,j] + " ");
            }
            System.Console.WriteLine();
        }
    }
    #region Level 1
    public int Factorial(int n)
    {
        int result = 1;
        for (int i = 2; i <= n; i++) {
            result *= i;
        }
        return result;
    }
    public long Combinations(int n, int k)
    {
        int a = Factorial(n);
        int b = Factorial(k) * Factorial(n-k);
        return a/b;
    }
    public long Task_1_1(int n, int k)
    {
        long answer = 0;

        // code here
        answer = Combinations(n,k);

        // create and use Combinations(n, k);
        // create and use Factorial(n);

        // end

        return answer;
    }
    public double GeronArea(double a, double b, double c)
    {
        double p = (a+b+c)/2;
        double S = Math.Sqrt(p*(p-a)*(p-b)*(p-c));
        return S;
    }
    public bool BeTriangle(double a, double b, double c)
    {
        return ((a < (b+c)) && (b < (a+c)) && (c < (a+b))) ;
    }
    public int Task_1_2(double[] first, double[] second)
    {
        int answer = 0;
        double a1 = first[0], b1 = first[1], c1 = first[2], a2 = second[0], b2 = second[1], c2 = second[2];
        if ((!BeTriangle(a1,b1,c1)) || (!BeTriangle(a2,b2,c2))) return -1;

        double S1 = GeronArea(a1,b1,c1);
        double S2 = GeronArea(a2,b2,c2);

        if (S1>S2) answer = 1;
        else if (S2>S1) answer = 2;
        else answer = 0;
        Console.WriteLine(answer);


        // code here

        // create and use GeronArea(a, b, c);

        // end

        // first = 1, second = 2, equal = 0, error = -1
        return answer;
    }
    public double GetDistance(double v, double a, int t)
    {
        return v*t + a*t*t/2;
    }

    public int Task_1_3a(double v1, double a1, double v2, double a2, int time)
    {
        int answer = 0;
        double D1 = GetDistance(v1,a1,time);
        double D2 = GetDistance(v2,a2,time);

        if (D1 > D2) answer = 1;
        else if (D2 > D1) answer = 2;
        else answer =0;
        // code here

        // create and use GetDistance(v, a, t); t - hours

        // end

        // first = 1, second = 2, equal = 0
        return answer;
    }

    public int Task_1_3b(double v1, double a1, double v2, double a2)
    {
        int answer = 1;
        for (int i =1; GetDistance(v1,a1,answer) > GetDistance(v2,a2,answer);i++)
        {
            answer = i;
        }

        // code here

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
    public int FindDMaxIndex(double []A)
    {
        int imax =0;
        double amax =-1000000000;
        for (int i = 0;i<A.Length;i++)
        {
            if (A[i] > amax)
            {
                amax = A[i];
                imax = i;
            }
        }
        return imax;
    }
    public double AveregeMax(double []A)
    {
        int ind = FindDMaxIndex(A);
        double sum = 0;
        int k =0;
        for (int i = ind +1; i < A.Length;i++)
        {
            sum+=A[i];
            k++;
        }
        return sum/k;
    }
    public void Task_2_2(double[] A, double[] B)
    {
        int indA = FindDMaxIndex(A);
        int indB = FindDMaxIndex(B);
        int lA = A.Length;
        int lB = B.Length;
        if ((lA-1-indA) > (lB-1-indB))
        {
            double sr = AveregeMax(A);
            A[indA] = sr;
        }
        else
        {
            double sr = AveregeMax(B);
            B[indB] = sr;
        }
        
        // code here

        // create and use FindMaxIndex(array);
        // only 1 array has to be changed!

        // end
    }
    
    public void Task_2_3(ref int[,] B, ref int[,] C)
    {
        
        // code here

        //  create and use method FindDiagonalMaxIndex(matrix);

        // end
    }

    public void Task_2_4(int[,] A, int[,] B)
    {
        // code here
        int indA = FindDiagonalMaxIndex(A);
        int indB = FindDiagonalMaxIndex(B);
        for (int i=0;i<5;i++)
        {
            int temp = A[indA,i];
            A[indA,i] = B[i,indB];
            B[i,indB] = temp;
        }
        //  create and use method FindDiagonalMaxIndex(matrix); like in Task_2_3

        // end
    }
    int FindDiagonalMaxIndex(int[,] A)
    {
        if (A.GetLength(0)!= A.GetLength(1)) return -1;
        int ind = -1;
        int maxd = 0;
        for (int i =0; i<A.GetLength(0);i++)
        {
            for (int j =0;j<A.GetLength(1);j++)
            {
                if (A[i,j] > maxd)
                {
                    maxd =A[i,j];
                    ind = i;
                }
            }
        }
        return ind;
    }
    public void Task_2_5(int[,] A, int[,] B)
    {
        // code here

        // create and use FindMaxInColumn(matrix, columnIndex, out rowIndex);

        // end
    }
    
    public void Task_2_6(ref int[] A, int[] B)
    {
        // code here
        int indA = FindMax(A);
        int indB = FindMax(B);
        A=DeleteElement(A,indA);
        B=DeleteElement(B,indB);
        Print(A);
        Print(B);
        int []AB = new int[13];
        int k =0;
        for (int i =0;i<6;i++)
        {
            AB[k] = A[i];
            k++;
        }
        for (int i =0;i<7;i++)
        {
            AB[k]=B[i];
            k++;
        }
        Print(AB);
        A=AB;
        // create and use FindMax(array); 
        // create and use DeleteElement(array, index);

        // end
    }
    int FindMax(int[]array)
    {
        int n = array.Length;
        int imax = 0;
        for (int i =0;i<n;i++)
        {
            if (array[i] > array[imax]) imax = i;
        }
        return imax;
    }
    int [] DeleteElement(int[]a,int ind)
    {
        int n = a.Length;
        int[]b = new int[n-1];
        int k =0;
        for (int i =0;i<ind;i++)
        {
            b[k] = a[i];
            k++;
        }
        for (int i =ind+1;i<n;i++)
        {
            b[k] = a[i];
            k++;
        }
        return b;
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
        int indA = FindMax(A) + 1;
        int indB = FindMax(B) + 1;
        if (indA < 9) A = SortArrayPart(A,indA);
        if (indB < 11) B = SortArrayPart(B,indB);
        // create and use SortArrayPart(array, startIndex);

        // end
    }
    //[1, 2, 3, 4, 5, 6, 7]
    int[] SortArrayPart(int[]A,int ind)
    {
        int n = A.Length;
        if (ind >= n-1) return A;
        else
        {
            for (int i = ind;i<n;i++)
            {
                for (int j = ind;j<n-1;j++)
                {
                    if (A[j] > A[j+1])
                    {
                        int temp = A[j];
                        A[j] = A[j+1];
                        A[j+1] = temp;
                    }
                }
            }
            return A;
        }     
    }

    public int[] Task_2_9(int[,] A, int[,] C)
    {
        int[] answer = default(int[]);

        // code here

        // create and use SumPositiveElementsInColumns(matrix);

        // end

        return answer;
    }

    public void Task_2_10(ref int[,] matrix)
    {
        // code here
        int n = matrix.GetLength(0);
        int m = matrix.GetLength(1);
        int jngl = 0;
        int mngl = -10000000;
        for (int i =0;i<n;i++)
        {
            for (int j =0;j<m;j++)
            {
                if (j <= i && matrix[i,j] > mngl)
                {
                    mngl = matrix[i,j];
                    jngl = j;
                }
            }
        }
        int jvgl = 0;
        int mvgl = 100000000;
        for (int i =0;i<n;i++)
        {
            for (int j =0;j<m;j++)
            {
                if (j > i && matrix[i,j] < mvgl)
                {
                    mvgl = matrix[i,j];
                    jvgl = j;
                }
            }
        }
        int a = Math.Min(jngl,jvgl);
        int b = Math.Max(jngl,jvgl);
        
        if (jvgl == jngl) matrix = RemoveColumn(matrix,jngl);
        else
        {
            matrix= RemoveColumn(matrix, a);
            b--;
            matrix = RemoveColumn(matrix,b);
        }
        
        // create and use RemoveColumn(matrix, columnIndex);

        // end
    }
    //[1, 2, 3, 4]
    //[2, 3, 4, 5]
    //[4, 5, 6, 2]
    //[2, 5, 7, 9]
    int[,] RemoveColumn( int[,] matr, int col)
    {
        int n = matr.GetLength(0);
        int m = matr.GetLength(1);
        int[,] asw = new int[n,m-1];
        int k =0;
        for (int j =0;j<col;j++)
        {
            for (int i =0;i<n;i++)
            {
                asw[i,k] = matr[i,j];
            }
            k++;
        }
        for (int j = col+1;j<m;j++)
        {
            for (int i =0;i<n;i++)
            {
                asw[i,k]=matr[i,j];
            }
            k++;
        }
        return asw;
    }
    public void Task_2_11(int[,] A, int[,] B)
    {
        // code here

        // use FindMaxIndex(matrix, out row, out column); from Task_2_1

        // end
    }
    public void Task_2_12(int[,] A, int[,] B)
    {
        // code here
        int jA = FindMaxColumnIndex(A);
        int jB = FindMaxColumnIndex(B);
        int n =A.GetLength(0);
        int m =A.GetLength(1);
        int [] temp = new int[A.GetLength(0)];
        for (int i =0; i < n;i++)
        {
            temp[i] = A[i,jA];
        }
        for (int i =0;i<n;i++)
        {
            A[i,jA] = B[i,jB];
            B[i,jB] = temp[i];
        }
        // create and use FindMaxColumnIndex(matrix);

        // end
    }
    int FindMaxColumnIndex(int [,]matrix)
    {
        int n = matrix.GetLength(0);
        int m = matrix.GetLength(1);
        int jmax =0;
        int amax = -10000000;
        for (int i =0;i<n;i++)
        {
            for (int j =0;j<m;j++)
            {
                if (matrix[i,j] > amax)
                {
                    amax = matrix[i,j];
                    jmax = j;
                }
            }
        }
        return jmax;
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
        int n = matrix.GetLength(0);
        for (int i =0;i<n;i++)
        {
            matrix = SortRow(matrix,i);
        }
        // create and use SortRow(matrix, rowIndex);

        // end
    }
    int [,] SortRow(int[,]matr,int row)
    {
        int m = matr.GetLength(1);
        for (int i =0;i<m;i++)
        {
            for (int j =0;j<m-1;j++)
            {
                if (matr[row,j] > matr[row,j+1])
                {
                    int temp = matr[row,j];
                    matr[row,j] = matr[row,j+1];
                    matr[row,j+1] = temp;
                }
            }
        }
        return matr;
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
        // code here
        A = SortNegative(A);
        B = SortNegative(B);
        // create and use SortNegative(array);

        // end
    }
    int [] SortNegative(int[]A)
    {
        int k =0;
        int n = A.Length;
        for (int i =0;i<n;i++)
        {
            if (A[i] < 0) k++;
        }
        int[] otr = new int[k];
        k=0;
        for (int i =0;i<n;i++)
        {
            if (A[i] < 0)
            {
                otr[k] = A[i];
                k++;
            }
        }
        for (int i = 0;i<k;i++)
        {
            for (int j = 0;j<k-1;j++)
            {
                if (otr[j] < otr[j+1])
                {
                    int temp = otr[j];
                    otr[j] = otr[j+1];
                    otr[j+1] = temp;
                }
            }
        }
        k=0;
        for (int i =0;i<n;i++)
        {
            if (A[i] < 0)
            {
                A[i] = otr[k];
                k++;
            }
        }
        return A;
    }
    public void Task_2_17(int[,] A, int[,] B)
    {
        // code here

        // create and use SortRowsByMaxElement(matrix);

        // end
    }

    public void Task_2_18(int[,] A, int[,] B)
    {
        // code here
        A = SortDiagonal(A);
        B = SortDiagonal(B);
        // create and use SortDiagonal(matrix);

        // end
    }
    int[,] SortDiagonal(int[,]matr)
    {
        int n = matr.GetLength(0);
        int []A = new int[n];
        for (int i =0;i<n;i++)
        {
            for (int j =0;j<n;j++)
            {
                if (i==j) A[i] = matr[i,j];
            }
        }
        for (int i = 0;i<n;i++)
        {
            for (int j = 0;j<n-1;j++)
            {
                if (A[j] > A[j+1])
                {
                    int temp = A[j];
                    A[j] = A[j+1];
                    A[j+1] = temp;
                }
            }
        }
        for (int i =0;i<n;i++)
        {
            for (int j =0;j<n;j++)
            {
                if (i==j) matr[i,j] = A[i];
            }
        }
        return matr;
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
        A = DeleteColumnsOut0(A);
        B = DeleteColumnsOut0(B);
        // use RemoveColumn(matrix, columnIndex); from 2_10

        // end
    }
    int[,] DeleteColumnsOut0(int[,] matr)
    {
        for (int j =0;j<matr.GetLength(1);j++)
        {
            int k =0;
            for (int i =0;i<matr.GetLength(0);i++)
            {
                if (matr[i,j] == 0) k++;
            }
            if (k ==0)
            {
                matr = RemoveColumn(matr,j);
                j--;
            }
        }
        return matr;
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
        rows = new int[matrix.GetLength(0)];
        cols = new int[matrix.GetLength(1)];
        int n = matrix.GetLength(0);
        int m = matrix.GetLength(1);
        for (int i =0;i<n;i++)
        {
            rows[i] = CountNegativeInRow(matrix,i);
        }
        cols = FindMaxNegativePerColumn(matrix);
        // code here

        // create and use CountNegativeInRow(matrix, rowIndex);
        // create and use FindMaxNegativePerColumn(matrix);

        // end
    }
    int CountNegativeInRow(int[,] matr, int row)
    {
        int m = matr.GetLength(1);
        int k =0;
        for (int j =0;j<m;j++)
        {
            if (matr[row,j] < 0) k++;
        }
        return k;
    }
    int [] FindMaxNegativePerColumn(int [,]matr)
    {
        int n = matr.GetLength(0);
        int m = matr.GetLength(1);
        int []A = new int [m];
        for (int j =0;j<m;j++)
        {
            int nmax = -100000000;
            for (int i =0;i<n;i++)
            {
                if (matr[i,j] > nmax && matr[i,j] <0) nmax = matr[i,j];
            } 
            A[j] = nmax;
        }
        return A;
    }
    public void Task_2_23(double[,] A, double[,] B)
    {
        // code here

        // create and use MatrixValuesChange(matrix);

        // end
    }

    public void Task_2_24(int[,] A, int[,] B)
    {
        // code here
        int row,col;
        FindMaxIndex(A, out row, out col);
        A = SwapColumnDiagonal(A, col);
        FindMaxIndex(B, out row, out col);
        B = SwapColumnDiagonal(B, col);
        // use FindMaxIndex(matrix, out row, out column); like in 2_1
        // create and use SwapColumnDiagonal(matrix, columnIndex);

        // end
    }
    void FindMaxIndex(int[,] matr, out int row, out int col)
    {
        row =0;
        col =0;
        int n = matr.GetLength(0);
        int m = matr.GetLength(1);
        for (int i =0;i<n;i++)
        {
            for (int j =0;j<m;j++)
            {
                if (matr[i,j] > matr[row,col])
                {
                    row = i;
                    col = j;
                }
            }
        }
    }
    int[,] SwapColumnDiagonal(int[,] matr, int col)
    {
        int n = matr.GetLength(0);
        int []A = new int[n];
        for (int i =0;i<n;i++)
        {
            A[i] = matr[i,i];
        }
        for (int i =0;i<n;i++)
        {
            for (int j =0;j<n;j++)
            {
                if (i==j)
                {
                    matr[i,j] = matr[i,col];
                }
            }
        }
        for (int i =0;i<n;i++)
        {
            matr[i,col] = A[i];
        }
        return matr;
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

    public void Task_2_26(int[,] A, int[,] B)
    {
        // code here
        int iA = FindRowWithMaxNegativeCount(A);
        int iB = FindRowWithMaxNegativeCount(B);
        int n = A.GetLength(0);
        int m = A.GetLength(1);
        int []C = new int[m];
        for (int j =0;j<m;j++)
        {
            C[j] = A[iA,j];
        }
        for (int j =0;j<m;j++)
        {
            A[iA,j] = B[iB,j];
            B[iB,j] = C[j];
        }
        // create and use FindRowWithMaxNegativeCount(matrix); like in 2_25
        // in FindRowWithMaxNegativeCount use CountNegativeInRow(matrix, rowIndex); from 2_22

        // end
    }
    int FindRowWithMaxNegativeCount(int[,] matr)
    {
        int asw = -1;
        int max = -1000;
        int n = matr.GetLength(0);
        int m = matr.GetLength(1);
        for (int i =0;i<n;i++)
        {
            int k = CountNegativeInRow(matr, i);
            if (k > max)
            {
                max = k;
                asw = i;
            }
        }
        return asw;
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
        // code here
        answerFirst = FindSequence(first, 0, first.Length - 1);
        answerSecond = FindSequence(second, 0, second.Length - 1);
        
        // create and use FindSequence(array, A, B); // 1 - increasing, 0 - no sequence,  -1 - decreasing
        // A and B - start and end indexes of elements from array for search
        // end
    }
    static int FindSequence(int[] arr, int a, int b)
    {
        int ans = -1;
        for (int i = a; i < b; i++)
        {
            if (arr[i] < arr[i + 1])
            {
                ans = 0;
                break;
            }
        }
        if (ans == -1)
            return ans;
        ans = 1;
        for (int i = a; i < b; i++)
        {
            if (arr[i] > arr[i + 1])
            {
                ans = 0;
                break;
            }
        }
        return ans;
    }
    public void Task_2_28b(int[] first, int[] second, ref int[,] answerFirst, ref int[,] answerSecond)
    {
        // code here

        // use FindSequence(array, A, B); from Task_2_28a or entirely Task_2_28a
        // A and B - start and end indexes of elements from array for search
        answerFirst = Monointer(first, 0, first.Length - 1);
        answerSecond = Monointer(second, 0, second.Length - 1);

        // end
    }
    int[,]  Monointer(int[] arr, int A, int B)
    {
        int k = 0;
        for (int i = A; i < B; i++)
        {
            for (int j = i + 1; j <= B; j++)
            {
                if (FindSequence(arr, i, j) != 0)
                {
                    k++;
                }
            }
        }
        int[,] matr = new int[k, 2]; 
        int ind = 0;
        for (int i = A; i < B; i++)
        {
            for (int j = i + 1; j <= B; j++)
            {
                if (FindSequence(arr, i, j) != 0)
                {
                    matr[ind, 0] = i;
                    matr[ind, 1] = j;
                    ind++;
                }
            }
        }
        return matr;
    }

    public void Task_2_28c(int[] first, int[] second, ref int[] answerFirst, ref int[] answerSecond)
    {
        // code here

        // use FindSequence(array, A, B); from Task_2_28a or entirely Task_2_28a or Task_2_28b
        // A and B - start and end indexes of elements from array for search
        int[,] fd = Monointer(first, 0, first.Length - 1);
        answerFirst = MaxSeq(fd);
        int[,] sd = Monointer(second, 0, second.Length - 1);
        answerSecond = MaxSeq(sd);

    }    
    #endregion
    int[] MaxSeq(int[,] matrix)
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
        int n = matrix.GetLength(0);
        for (int i =0; i<n;i++)
        {
            if (i%2==0) sortStyle = SortAscending;
            else sortStyle = SortDescending;
            sortStyle(matrix,i);
        
        }
        // code here

        // create and use public delegate SortRowStyle(matrix, rowIndex);
        // create and use methods SortAscending(matrix, rowIndex) and SortDescending(matrix, rowIndex)
        // change method in variable sortStyle in the loop here and use it for row sorting

        // end
    }
    public delegate int[,] SortRowStyle(int[,]matr, int row);
    int[,] SortAscending(int[,]matr, int row)
    {
        int m = matr.GetLength(1);
        for (int i =0;i<m;i++)
        {
            for (int j =0;j<m-1;j++)
            {
                if (matr[row,j] > matr[row,j+1])
                {
                    int temp = matr[row,j];
                    matr[row,j] = matr[row,j+1];
                    matr[row,j+1] = temp;
                }
            }
        }
        return matr;
    }
    int[,] SortDescending(int[,]matr, int row)
    {
        int m = matr.GetLength(1);
        for (int i =0;i<m;i++)
        {
            for (int j =0;j<m-1;j++)
            {
                if (matr[row,j] < matr[row,j+1])
                {
                    int temp = matr[row,j];
                    matr[row,j] = matr[row,j+1];
                    matr[row,j+1] = temp;
                }
            }
        }
        return matr;
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
        GetTriangle triangle = default(GetTriangle);
        if (isUpperTriangle) triangle = GetUpperTriangle;
        else triangle = GetLowerTriangle;
        answer = GetSum(triangle,matrix);
        // code here

        // create and use public delegate GetTriangle(matrix);
        // create and use methods GetUpperTriange(array) and GetLowerTriange(array)
        // create and use GetSum(GetTriangle, matrix)

        // end

        return answer;
    }
    public delegate int[] GetTriangle(int[,]matr);
    int[] GetUpperTriangle(int [,] matr)
    {
        int n = matr.GetLength(0);
        int m = matr.GetLength(1);
        int k =0;
        for (int i =0;i<n;i++)
        {
            for (int j =0;j<m;j++)
            {
                if (j>=i) k++;
            }
        }
        int[] A = new int[k];
        k =0 ;
        for (int i =0;i<n;i++)
        {
            for (int j=0;j<m;j++)
            {
                if (j>=i)
                {
                    A[k] = matr[i,j];
                    k++;
                }
            }
        }
        return A;
    }
    int[] GetLowerTriangle(int [,] matr)
    {
        int n = matr.GetLength(0);
        int m = matr.GetLength(1);
        int k =0;
        for (int i =0;i<n;i++)
        {
            for (int j =0;j<m;j++)
            {
                if (j<=i) k++;
            }
        }
        int[] A = new int[k];
        k =0 ;
        for (int i =0;i<n;i++)
        {
            for (int j=0;j<m;j++)
            {
                if (j<=i)
                {
                    A[k] = matr[i,j];
                    k++;
                }
            }
        }
        return A;
    }
    int GetSum(GetTriangle triangle, int[,] matr)
    {
        int []arr = triangle(matr);
        int n = arr.Length;
        int s =0;
        for (int i =0;i<n;i++)
        {
            s += arr[i] * arr[i];
        }
        return s;
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
        // code here
        FindElementDelegate diagonal = default(FindElementDelegate);
        FindElementDelegate FirstRow = default(FindElementDelegate);
        diagonal = FindDiagonalMaxIndex;
        FirstRow = FindFirstRowMaxIndex;
        matrix = SwapColumns(matrix,diagonal,FirstRow);
        // create and use public delegate FindElementDelegate(matrix);
        // use method FindDiagonalMaxIndex(matrix) like in Task_2_3;
        // create and use method FindFirstRowMaxIndex(matrix);
        // create and use method SwapColumns(matrix, FindDiagonalMaxIndex, FindFirstRowMaxIndex);

        // end
    }
    public delegate int FindElementDelegate(int[,]matr);
    int FindFirstRowMaxIndex(int[,] matr)
    {
        int n = matr.GetLength(0);
        int jmax =0;
        for (int j =0;j<n;j++)
        {
            if (matr[0,j] > matr[0,jmax]) jmax = j;
        }
        return jmax;
    }
    int[,] SwapColumns(int[,] matr, FindElementDelegate diagonal, FindElementDelegate FirstRow)
    {
        int n = matr.GetLength(0);
        int []temp = new int[n];
        int j1 = diagonal(matr);
        int j2 = FirstRow(matr);
        for (int i =0;i<n;i++)
        {
            temp[i] = matr[i,j1];
        }
        for (int i =0;i<n;i++)
        {
            matr[i,j1] = matr[i,j2];
            matr[i,j2] = temp[i];
        }
        return matr;
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
        RemoveColumns( ref matrix, FindMaxBelowDiagonalIndex, FindMinAboveDiagonalIndex);

        // code here

        // create and use public delegate FindIndex(matrix);
        // create and use method FindMaxBelowDiagonalIndex(matrix);
        // create and use method FindMinAboveDiagonalIndex(matrix);
        // use RemoveColumn(matrix, columnIndex) from Task_2_10
        // create and use method RemoveColumns(matrix, findMaxBelowDiagonalIndex, findMinAboveDiagonalIndex)

        // end
    }
    public delegate int FindIndex(int[,] matr);
    int FindMaxBelowDiagonalIndex(int[,] matr)
    {
        int n = matr.GetLength(0);
        int imax =0,jmax=0;
        for (int i =0;i<n;i++)
        {
            for (int j =0;j<n;j++)
            {
                if (j<=i && matr[i,j] > matr[imax,jmax])
                {
                    imax = i;
                    jmax = j;
                }
            }
        }
        return jmax;
    }
    int FindMinAboveDiagonalIndex(int[,] matr)
    {
        int n = matr.GetLength(0);
        int imin =0,jmin=0;
        for (int i =0;i<n;i++)
        {
            for (int j =0;j<n;j++)
            {
                if (j > i && matr[i,j] < matr[imin,jmin])
                {
                    imin = i;
                    jmin = j;
                }
            }
        }
        return jmin;
    }
    void RemoveColumns( ref int[,] matr, FindIndex Below, FindIndex Above)
    {
        int a = Below(matr);
        int b = Above(matr);
        int j1 = Math.Min(a,b);
        int j2 = Math.Max(a,b);
        matr = RemoveColumn(matr,j2);
        if (j1!=j2) matr = RemoveColumn(matr,j1);
        
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
        FindNegatives(matrix, GetNegativeCountPerRow, FindMaxNegativePerColumn, out rows, out cols);
        // code here

        // create and use public delegate GetNegativeArray(matrix);
        // use GetNegativeCountPerRow(matrix) from Task_2_22
        // use GetMaxNegativePerColumn(matrix) from Task_2_22
        // create and use method FindNegatives(matrix, searcherRows, searcherCols, out rows, out cols);

        // end
    }
    public delegate int[] GetNegativeArray(int[,] matr);
    int[] GetNegativeCountPerRow(int[,] matr)
    {
        int [] A = new int[matr.GetLength(0)];
        for (int i =0;i<matr.GetLength(0);i++)
        {
            A[i] = CountNegativeInRow(matr,i);
        }
        return A;
    }
    void FindNegatives(int[,] matr, GetNegativeArray searcherRows, GetNegativeArray searcherCols, out int[] rows, out int[] cols)
    {
        rows = searcherRows(matr);
        cols = searcherCols(matr);
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
        // code here
        answerFirst = DefineSequence(first, FindIncreasingSequence, FindDecreasingSequence);
        answerSecond = DefineSequence(second, FindIncreasingSequence, FindDecreasingSequence);
        // create public delegate IsSequence(array, left, right);
        // create and use method FindIncreasingSequence(array, A, B); similar to FindSequence(array, A, B) in Task_2_28a
        // create and use method FindDecreasingSequence(array, A, B); similar to FindSequence(array, A, B) in Task_2_28a
        // create and use method DefineSequence(array, findIncreasingSequence, findDecreasingSequence);

        // end
    }
    public delegate bool IsSequence(int[] array, int left, int right);
    bool FindIncreasingSequence(int[] array, int A, int B)
    {
        return FindSequence(array, A, B) == 1;
    }
    bool FindDecreasingSequence(int[] array, int A, int B)
    {
        return FindSequence(array, A, B) == -1;
    }
    int DefineSequence(int[] array, IsSequence findIncreasingSequence, IsSequence findDecreasingSequence)
    {
        if (findIncreasingSequence(array, 0, array.Length - 1)) return 1;
        if (findDecreasingSequence(array, 0, array.Length - 1)) return -1;
        return 0;
    }
    public void Task_3_28c(int[] first, int[] second, ref int[] answerFirstIncrease, ref int[] answerFirstDecrease, ref int[] answerSecondIncrease, ref int[] answerSecondDecrease)
    {
        // code here
        answerFirstIncrease = FindLongestSequence(first, FindIncreasingSequence);
        answerFirstDecrease = FindLongestSequence(first, FindDecreasingSequence);
        answerSecondIncrease = FindLongestSequence(second, FindIncreasingSequence);
        answerSecondDecrease = FindLongestSequence(second, FindDecreasingSequence);
        // create public delegate IsSequence(array, left, right);
        // use method FindIncreasingSequence(array, A, B); from Task_3_28a
        // use method FindDecreasingSequence(array, A, B); from Task_3_28a
        // create and use method FindLongestSequence(array, sequence);

        // end
    }
    int[] FindLongestSequence(int[] array, IsSequence sequence)
    {
        int s = 0, f = 0;
        for (int i = 0; i <  array.Length; i++)
            for (int j = i + 1; j < array.Length; j++)
                if (sequence(array, i, j) && j - i > f - s)
                {
                    s = i; f = j;
                }
        return [s, f];
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
