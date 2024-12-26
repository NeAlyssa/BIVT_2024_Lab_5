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
    public long Task_1_1(int n, int k)
    {
        long answer = 0;

        // code here
        if (k == 0 || k > 0 && k == n) return 1;
        if (k < 0 || n < 0) return 0;
        answer = Combinations(n, k);
        // create and use Combinations(n, k);
        // create and use Factorial(n);

        // end

        return answer;
    }
    int Factorial(int n)
    {
        int res = 1, a = 1;
        while (a <= n)
        {
            res *= a;
            a++;
        }
        return res;
    }
    long Combinations(int n, int k)
    {
        long res = Factorial(n) / Factorial(k) / Factorial(n - k);
        return res;
    }

    public int Task_1_2(double[] first, double[] second)
    {
        int answer = 0;

        // code here
        double s1 = GeronArea(first[0], first[1], first[2]);
        double s2 = GeronArea(second[0], second[1], second[2]);
        if (s1 == 0 || s2 == 0) answer = -1;
        else if (s1 == s2) answer = 0;
        else if (s1 > s2) answer = 1;
        else answer = 2;
        {

        }
        // create and use GeronArea(a, b, c);

        // end

        // first = 1, second = 2, equal = 0, error = -1
        return answer;
    }
    double GeronArea(double a, double b, double c)
    {

        if (a + b <= c || a + c <= b || b + c <= a) return 0;
        if (a <= 0 || b <= 0 || c <= 0) return 0;
        double p = (a + b + c) / 2;
        double s = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        return s;
    }

    public int Task_1_3a(double v1, double a1, double v2, double a2, int time)
    {
        int answer = 0;

        // code here
        double res1 = GetDistance(v1, a1, time);
        double res2 = GetDistance(v2, a2, time);
        if (res1 == res2) answer = 0;
        else if (res1 > res2) answer = 1;
        else answer = 2;
        // create and use GetDistance(v, a, t); t - hours

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
        if (a1 == a2 || v1 == v2 || v2 > v1) return 1;
        double ans = (2 * (v2 - v1) / (a1 - a2));
        answer = (int)Math.Ceiling(ans);
        //Console.WriteLine($"{v1}   {a1}       {v2}  {a2}    {answer}");
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

    public void Task_2_2(double[] A, double[] B)
    {
        // code here
        int maxiA = FindMaxIndex(A);
        int maxiB = FindMaxIndex(B);
        if (maxiA < maxiB)
        {
            Change(A, maxiA);
            /*
            double sr = 0, c = 0, maxA = A[maxiA];
            for (int i = maxiA + 1; i < A.Length; i++)
            {
                sr += A[i];
                c++;
            }
            sr /= c;
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] == maxA) A[i] = sr;
            }*/
        }
        else
        {
            Change(B, maxiB);
            /*
            double sr = 0, c = 0, maxB = B[maxiB];
            for (int i = maxiB + 1; i < B.Length; i++)
            {
                sr += B[i];
                c++;
            }
            sr /= c;
            for (int i = 0; i < B.Length; i++)
            {
                if (B[i] == maxB) B[i] = sr;
            }*/
        }

        // create and use FindMaxIndex(array);
        // only 1 array has to be changed!

        // end
    }
    void Change(double[] array, int maxind)
    {
        double sr = 0, c = 0, maxA = array[maxind];
        for (int i = maxind + 1; i < array.Length; i++)
        {
            sr += array[i];
            c++;
        }
        sr /= c;
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] == maxA) array[i] = sr;
        }
    }
    int FindMaxIndex(double[] array)
    {
        int maxindex = 0;
        for (int i = 0; i< array.Length; i++)
        {
            if (array[i] > array[maxindex]) maxindex = i;

        }
        return maxindex;
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

        //  create and use method FindDiagonalMaxIndex(matrix); like in Task_2_3
        int rowA=FindDiagonalMaxIndex(A);
        int colB = FindDiagonalMaxIndex(B);
        for (int i = 0; i<A.GetLength(0); i++)
        {
            int temp = A[rowA, i];
            A[rowA, i] = B[i, colB];
            B[i, colB] = temp;
        }
        // end
    }
    int FindDiagonalMaxIndex(int[,] matrix)
    {
        int maxindex = 0;
        for (int i = 0; i<matrix.GetLength(0); i++)
        {
            if (matrix[i, i] > matrix[maxindex, maxindex]) maxindex = i;
        }
        return maxindex;
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
        int maxA = A[FindMax(A)];
        int maxB = B[FindMax(B)];
        for (int i = A.Length - 1; i >= 0; i--)
        {
            if (A[i] == maxA) A=DeleteElement(A,i);
        }
        for (int i = B.Length - 1; i >= 0; i--)
        {
            if (B[i] == maxB) B = DeleteElement(B, i);
        }
        int[] res= new int[A.Length+B.Length];
        for (int i = 0; i < res.Length; i++)
        {
            if (i<A.Length) res[i] = A[i];
            else res[i] = B[i-A.Length];
        }
        A = res;

        // create and use FindMax(matrix, out row, out column); like in Task_2_1
        // create and use DeleteElement(array, index);

        // end
    }
    int FindMax(int[] array)
    {
        int indmax = 0;
        for (int i = 0; i<array.Length; i++)
        {
            if (array[i] > array[indmax]) indmax = i;
        }
        return indmax;
    }
    int[] DeleteElement(int[] array, int index)
    {
        int[] newarray= new int[array.Length-1];
        for (int i = 0; i<newarray.Length; i++)
        {
            if (i<index) newarray[i] = array[i];
            else newarray[i] = array[i+1];
        }
        return newarray;
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
        int startA = FindMax(A) + 1;
        int startB = FindMax(B) + 1;
        SortArrayPart(A, startA);
        SortArrayPart(B, startB);

        // create and use SortArrayPart(array, startIndex);

        // end
    }
    void SortArrayPart(int[] array, int startIndex)
    {
        if (startIndex >= array.Length - 1) return;
        for (int i = startIndex+1, j= startIndex + 2; i < array.Length;)
        {
            if (i==startIndex|| array[i] > array[i - 1])
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
        int stmax = 0, stmin = 0, maxel = matrix[0, 0], minel = matrix[0, 1];
        for (int i = 0; i<matrix.GetLength(0); i++)
        {
            for (int j = 0; j<matrix.GetLength(1); j++)
            {
                if (i >= j)
                {
                    if (matrix[i, j] > maxel)
                    {
                        maxel= matrix[i, j];
                        stmax= j;
                    }
                }
                else
                {
                    if (matrix[i, j] < minel){
                        minel= matrix[i, j];
                        stmin= j;
                    }
                }
            }
        }
        if (stmax == stmin) matrix = RemoveColumn(matrix, stmax);
        else
        {
            int st1 = stmax > stmin ? stmax : stmin;
            int st2 = stmax < stmin ? stmax : stmin;
            matrix = RemoveColumn(matrix, st1);
            matrix = RemoveColumn(matrix, st2);
        }
        // create and use RemoveColumn(matrix, columnIndex);

            // end
    }
    int[,] RemoveColumn(int[,]matrix, int columnIndex)
    {
        int[,] res=new int[matrix.GetLength(0), matrix.GetLength(1)-1];
        for (int i = 0; i < res.GetLength(0); i++)
        {
            for (int j = 0;j < res.GetLength(1); j++)
            {
                if (j < columnIndex) res[i, j] = matrix[i, j];
                else res[i, j] = matrix[i, j + 1];
            }
        }
        return res;
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
        int maxcolA = FindMaxColumnIndex(A);
        int maxcolB = FindMaxColumnIndex(B);

        for (int i = 0; i< A.GetLength(0); i++)
        {
            int temp = A[i,maxcolA];
            A[i,maxcolA]=B[i,maxcolB];
            B[i,maxcolB]=temp;
        }
        // create and use FindMaxColumnIndex(matrix);

        // end
    }
    int FindMaxColumnIndex(int[,] matrix)
    {
        int res = 0, maxel=matrix[0, 0];
        for (int i = 0;i < matrix.GetLength(0); i++)
        {
            for (int j=0;j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] > maxel)
                {
                    maxel = matrix[i, j];
                    res = j;
                }
            }
        }
        return res;
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
        for (int i = 0; i< matrix.GetLength(0); i++)
        {
            SortRow(matrix, i);
        }
        // create and use SortRow(matrix, rowIndex);

        // end
    }
    void SortRow(int[,] matrix, int rowIndex)
    {
        for (int i = 1; i< matrix.GetLength(1); i++)
        {
            int j = i - 1, key=matrix[rowIndex, i];
            while(j>=0 && matrix[rowIndex, j]>key)
            {
                matrix[rowIndex, j+1]=matrix[rowIndex, j];
                j--;
            }
            matrix[rowIndex, j + 1] = key;
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

    public void Task_2_16(int[] A, int[] B)
    {
        // code here
        SortNegative(A); 
        SortNegative(B);
        // create and use SortNegative(array);

        // end
    }
    void SortNegative(int[] array)
    {
        for (int i = 1, j=2; i< array.Length; )
        {
            if (array[i] < 0)
            {
                int key = array[i], k = i - 1;
                while (k >= 0)
                {
                    if (array[k] >= 0)
                    {
                        k--;
                        continue;
                    }
                    if (array[k] > array[i])
                    {
                        break;
                    }
                    array[i] = array[k];
                    array[k] = key;
                    i = k;
                    k--;
                }
            }
            i=j;
            j++;
        }
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
        SortDiagonal(A);
        SortDiagonal(B);
        // create and use SortDiagonal(matrix);

        // end
    }
    void SortDiagonal(int[,] matrix)
    {
        int n = matrix.GetLength(0);
        for (int i = 0; i<n; i++)
        {
            for (int j = 0; j<n-i-1; j++)
            {
                if (matrix[j, j] > matrix[j+1, j + 1])
                {
                    int temp = matrix[j, j];
                    matrix[j, j]= matrix[j+1, j+1];
                    matrix[j+1, j+1]= temp;
                }
            }
        }
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
        Delete(ref A);
        Delete(ref B);
        /*
        for (int j = A.GetLength(1)-1; j>=0; j--)
        {
            int count = 0;
            for (int i = 0; i < A.GetLength(0); i++)
            {
                if (A[i, j] == 0)
                {
                    count++;
                    break;
                }
            }
            if (count == 0) A = RemoveColumn(A, j);
        }
        for (int j = B.GetLength(1) - 1; j >= 0; j--)
        {
            int count = 0;
            for (int i = 0; i < B.GetLength(0); i++)
            {
                if (B[i, j] == 0)
                {
                    count++;
                    break;
                }
            }
            if (count == 0) B = RemoveColumn(B, j);
        }*/

        // use RemoveColumn(matrix, columnIndex); from 2_10

        // end
    }
    void Delete(ref int[,] matrix)
    {
        for (int j = matrix.GetLength(1) - 1; j >= 0; j--)
        {
            int count = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, j] == 0)
                {
                    count++;
                    break;
                }
            }
            if (count == 0) matrix = RemoveColumn(matrix, j);
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

    public void Task_2_22(int[,] matrix, out int[] rows, out int[] cols)
    {
        rows = null;
        cols = null;

        // code here
        rows = new int [matrix.GetLength(0)];
        for (int i = 0; i< matrix.GetLength(0); i++)
        {
            rows[i]=CountNegativeInRow(matrix,i);
        }
        cols = FindMaxNegativePerColumn(matrix);

        // create and use CountNegativeInRow(matrix, rowIndex);
        // create and use FindMaxNegativePerColumn(matrix);

        // end
    }
    int CountNegativeInRow(int [,] matrix, int rowIndex)
    {
        int count = 0;
        for (int i = 0; i< matrix.GetLength(1); i++)
        {
            if (matrix[rowIndex, i] < 0) count++;
        }
        return count;
    }
    int[] FindMaxNegativePerColumn(int[, ] matrix)
    {
        int[] res = new int[matrix.GetLength(1)];
        for (int j = 0; j< matrix.GetLength(1); j++)
        {
            int maxotr = int.MinValue;
            for (int i = 0; i< matrix.GetLength(0); i++)
            {
                if (matrix[i,j]<0 && matrix[i, j]>maxotr) maxotr = matrix[i,j];
            }
            res[j] = maxotr;
        }
        return res;
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
        FindMaxIndex(A, out int rowA, out int colA);
        FindMaxIndex(B, out int rowB, out int colB);
        SwapColumnDiagonal(A, colA);
        SwapColumnDiagonal(B, colB);


        // use FindMaxIndex(matrix, out row, out column); like in 2_1
        // create and use SwapColumnDiagonal(matrix, columnIndex);

        // end
    }
    void FindMaxIndex(int[,] matrix, out int row, out int column)
    {
        row = 0; column = 0;
        for (int i = 0; i< matrix.GetLength(0); i++)
        {
            for (int j = 0;j< matrix.GetLength(1); j++)
            {
                if (matrix[i, j] > matrix[row, column])
                {
                    row = i;
                    column = j;
                }
            }
        }
    }
    void SwapColumnDiagonal(int[, ]matrix, int columnIndex)
    {
        for (int i = 0; i< matrix.GetLength(0); i++)
        {
            int temp = matrix[i, i];
            matrix[i, i] = matrix[i, columnIndex];
            matrix[i, columnIndex] = temp;
        }
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
        int rowA=FindRowWithMaxNegativeCount(A);
        int rowB = FindRowWithMaxNegativeCount(B);
        for (int j = 0; j < A.GetLength(1); j++)
        {
            int temp = A[rowA, j];
            A[rowA, j] = B[rowB, j];
            B[rowB, j] = temp;
        }
        // create and use FindRowWithMaxNegativeCount(matrix); like in 2_25
        // in FindRowWithMaxNegativeCount use CountNegativeInRow(matrix, rowIndex); from 2_22

        // end
    }
    int FindRowWithMaxNegativeCount(int[,] matrix)
    {
        int row = 0, maxotr=0;
        for (int i = 0; i< matrix.GetLength(0); i++)
        {
            int count = CountNegativeInRow(matrix, i);
            if (count > maxotr)
            {
                maxotr = count;
                row = i;
            }
        }
        return row;
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
    int FindSequence(int[] array, int A, int B)
    {
        if (A > B) (A, B) = (B, A);
        int countinc = 0, countdec=0;
        for (int i = A; i<B; i++)
        {
            if (array[i] <= array[i + 1]) countinc++;
            if (array[i] >= array[i + 1]) countdec++;

        }
        if (countinc == B - A) return 1;
        if (countdec == B-A) return -1;
        return 0;
    }

    public void Task_2_28b(int[] first, int[] second, ref int[,] answerFirst, ref int[,] answerSecond)
    {
        // code here
        int countfirst = CountSequence(first);
        /*
        for (int i = 0; i<first.Length; i++)
        {
            for (int j = i+1; j<first.Length; j++)
            {
                int res = FindSequence(first, i, j);
                if (res == 1 || res==-1)
                {
                    countfirst++;
                }
            }
        }*/
        answerFirst = new int[countfirst, 2];
        FindIntervals(first, answerFirst);
        /*
        for (int i = 0, k=0; i < first.Length; i++)
        {
            for (int j = i + 1; j < first.Length; j++)
            {
                int res = FindSequence(first, i, j);
                if (res == 1 || res == -1)
                {
                    answerFirst[k, 0] = i;
                    answerFirst[k, 1] = j;
                    k++;
                }
            }
        }*/
        

        int countsecond = CountSequence(second);
        answerSecond = new int[countsecond, 2];
        FindIntervals(second, answerSecond);
        /*for (int i = 0; i < second.Length; i++)
        {
            for (int j = i + 1; j < second.Length; j++)
            {
                int res = FindSequence(second, i, j);
                if (res == 1 || res == -1)
                {
                    countsecond++;
                }
            }
        }
        answerSecond = new int[countsecond, 2];
        for (int i = 0, k = 0; i < second.Length; i++)
        {
            for (int j = i + 1; j < second.Length; j++)
            {
                int res = FindSequence(second, i, j);
                if (res == 1 || res == -1)
                {
                    answerSecond[k, 0] = i;
                    answerSecond[k, 1] = j;
                    k++;
                }
            }
        }*/
        // use FindSequence(array, A, B); from Task_2_28a or entirely Task_2_28a
        // A and B - start and end indexes of elements from array for search

        // end
    }
    void FindIntervals(int[] array, int[,] answer)
    {
        for (int i = 0, k = 0; i < array.Length; i++)
        {
            for (int j = i + 1; j < array.Length; j++)
            {
                int res = FindSequence(array, i, j);
                if (res == 1 || res == -1)
                {
                    answer[k, 0] = i;
                    answer[k, 1] = j;
                    k++;
                }
            }
        }
    }
    int CountSequence(int[] array)
    {
        int count = 0;
        for (int i = 0; i < array.Length; i++)
        {
            for (int j = i + 1; j < array.Length; j++)
            {
                int res = FindSequence(array, i, j);
                if (res == 1 || res == -1)
                {
                    count++;
                }
            }
        }
        return count;
    }

    public void Task_2_28c(int[] first, int[] second, ref int[] answerFirst, ref int[] answerSecond)
    {
        // code here
        int[,] res1 = null;
        int[,] res2 = null;
        Task_2_28b(first, second, ref res1, ref res2);
        answerFirst = new int[2];
        answerSecond = new int[2];
        FindBiggestInterval(res1, ref answerFirst);
        FindBiggestInterval(res2, ref answerSecond);

        /*
        
        int maxint1 = 0;
        for (int i = 0; i<res1.GetLength(0); i++)
        {
            if (res1[i, 1]-res1[i, 0] > maxint1)
            {
                maxint1 = res1[i, 1] - res1[i, 0];
                answerFirst[0] = res1[i, 0];
                answerFirst[1] = res1[i, 1];
            }
        }

        int maxint2 = 0;
        for (int i = 0; i < res2.GetLength(0); i++)
        {
            if (res2[i, 1] - res2[i, 0] > maxint2)
            {
                maxint2 = res2[i, 1] - res2[i, 0];
                answerSecond[0] = res2[i, 0];
                answerSecond[1] = res2[i, 1];
            }
        }*/

        // use FindSequence(array, A, B); from Task_2_28a or entirely Task_2_28a or Task_2_28b
        // A and B - start and end indexes of elements from array for search

        // end
    }
    void FindBiggestInterval(int[,] intervals, ref int[] answer)
    {
        answer= new int[2];
        int maxint = 0;
        for (int i = 0; i < intervals.GetLength(0); i++)
        {
            if (intervals[i, 1] - intervals[i, 0] > maxint)
            {
                maxint =intervals[i, 1] -intervals[i, 0];
                answer[0] = intervals[i, 0];
                answer[1] = intervals[i, 1];
            }
        }
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
        // SortRowStyle sortStyle = default(SortRowStyle); - uncomment me

        // code here
        SortRowStyle sortStyle = default(SortRowStyle);
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            sortStyle = i%2==0 ? SortAscending: SortDescending;
            sortStyle(matrix, i);
        }
        // create and use public delegate SortRowStyle(matrix, rowIndex);
        // create and use methods SortAscending(matrix, rowIndex) and SortDescending(matrix, rowIndex)
        // change method in variable sortStyle in the loop here and use it for row sorting

        // end
    }
    public delegate void SortRowStyle(int [,] matrix, int rowIndex);
    void SortAscending(int [,] matrix, int rowIndex)
    {
        for (int i = 1; i< matrix.GetLength(1); i++)
        {
            int key = matrix[rowIndex, i], j = i - 1 ;
            while (j>=0 && matrix[rowIndex, j] > key)
            {
                matrix[rowIndex, j+1]=matrix[rowIndex, j];
                j--;
            }
            matrix[rowIndex, j+1] = key;
        }
    }
    void SortDescending(int[,] matrix, int rowIndex)
    {
        for (int i = 1; i < matrix.GetLength(1); i++)
        {
            int key = matrix[rowIndex, i], j = i - 1;
            while (j >= 0 && matrix[rowIndex, j] < key)
            {
                matrix[rowIndex, j + 1] = matrix[rowIndex, j];
                j--;
            }
            matrix[rowIndex, j + 1] = key;
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

        // code here
        if (isUpperTriangle) answer = GetSum(GetUpperTriange, matrix);
        else answer = GetSum(GetLowerTriange, matrix);
        // create and use public delegate GetTriangle(matrix);
        // create and use methods GetUpperTriange(array) and GetLowerTriange(array)
        // create and use GetSum(GetTriangle, matrix)

        // end

        return answer;
    }
    public delegate int[] GetTriangle(int[,] matrix);
    int GetSum(GetTriangle getTriangle, int [,] matrix)
    {
        int res = 0;
        int[] vector = getTriangle(matrix);
        foreach (int x in vector) res += x * x;
        return res;
    }
    int[] GetUpperTriange(int [,] matrix)
    {
        int length = 0, n= matrix.GetLength(0),  a =n, k=0;
        while (a > 0)
        {
            length += a;
            a--;
        }
        int[] res = new int[length];
        for (int i = 0; i < n; i++)
        {
            for (int j = i; j<n; j++, k++)
            {
                res[k]= matrix[i, j];
            }
        }
        return res;
    }

    int[] GetLowerTriange(int[,] matrix)
    {
        int length = 0, n = matrix.GetLength(0), a = n, k = 0;
        while (a > 0)
        {
            length += a;
            a--;
        }
        int[] res = new int[length];
        for (int i = 0; i < n; i++)
        {
            for (int j=0; j<=i ; j++, k++)
            {
                res[k] = matrix[i, j];
            }
        }
        return res;
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
        SwapColumns(matrix, FindDiagonalMaxIndex, FindFirstRowMaxIndex);
        // create and use public delegate FindElementDelegate(matrix);
        // use method FindDiagonalMaxIndex(matrix) like in Task_2_3;
        // create and use method FindFirstRowMaxIndex(matrix);
        // create and use method SwapColumns(matrix, FindDiagonalMaxIndex, FindFirstRowMaxIndex);

        // end
    }
    void SwapColumns(int [,] matrix, FindElementDelegate finddiagonal, FindElementDelegate findrow)
    {
        int ind1=finddiagonal(matrix);
        int ind2=findrow(matrix);
        for (int i = 0; i<matrix.GetLength(0); i++)
        {
            int temp = matrix[i, ind1];
            matrix[i, ind1] = matrix[i, ind2];
            matrix[i, ind2] = temp;
        }
    }
    public delegate int FindElementDelegate(int[,] matrix);
    int FindFirstRowMaxIndex(int [,] matrix)
    {
        int res = 0;
        for (int j = 0; j< matrix.GetLength(1); j++)
        {
            if (matrix[0, j] > matrix[0, res]) res = j;
        }
        return res;
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
        // FindIndex searchArea = default(FindIndex); - uncomment me

        // code here
        FindIndex searchArea = default(FindIndex);
        matrix = RemoveColumns(matrix, FindMaxBelowDiagonalIndex, FindMinAboveDiagonalIndex);
        
        // create and use public delegate FindIndex(matrix);
        // create and use method FindMaxBelowDiagonalIndex(matrix);
        // create and use method FindMinAboveDiagonalIndex(matrix);
        // use RemoveColumn(matrix, columnIndex) from Task_2_10
        // create and use method RemoveColumns(matrix, findMaxBelowDiagonalIndex, findMinAboveDiagonalIndex)

        // end
    }
    public delegate int FindIndex(int [,] matrix);
    int[,] RemoveColumns(int[,] matrix, FindIndex findMaxBelowDiagonalIndex, FindIndex findMinAboveDiagonalIndex)
    {
        int ind1 = findMaxBelowDiagonalIndex(matrix);
        int ind2 = findMinAboveDiagonalIndex(matrix);
        if (ind1 == ind2)
        {
            matrix=RemoveColumn(matrix, ind1);
        }
        else if (ind1>ind2)
        {
            matrix = RemoveColumn(matrix, ind1);
            matrix = RemoveColumn(matrix, ind2);
        }
        else
        {
            matrix = RemoveColumn(matrix, ind2);
            matrix = RemoveColumn(matrix, ind1);
        }
        return matrix;
    }
    int FindMaxBelowDiagonalIndex(int [,] matrix)
    {
        int row = 0, col = 0;
        for (int i = 0; i< matrix.GetLength(0); i++)
        {
            for (int j = 0; j<=i; j++)
            {
                if (matrix[i, j]> matrix[row, col]){
                    row = i; col = j;
                }
            }
        }
        return col;
    }
    int FindMinAboveDiagonalIndex(int [,] matrix)
    {
        int row = 0, col = 1;
        for (int i = 0; i< matrix.GetLength(0); i++)
        {
            for (int j = i+1; j< matrix.GetLength(1); j++)
            {
                if (matrix[i, j] < matrix[row, col])
                {
                    row = i; col = j;
                }
            }
        }
        return col;
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

        // code here
        FindNegatives(matrix, GetNegativeCountPerRow, GetMaxNegativePerColumn, out rows, out cols);
        // create and use public delegate GetNegativeArray(matrix);
        // use GetNegativeCountPerRow(matrix) from Task_2_22
        // use GetMaxNegativePerColumn(matrix) from Task_2_22
        // create and use method FindNegatives(matrix, searcherRows, searcherCols, out rows, out cols);

        // end
    }
    public delegate int[] GetNegativeArray(int[,] matrix);
    void FindNegatives(int [,] matrix, GetNegativeArray searcherRows, GetNegativeArray searcherCols, out int [] rows, out int[] cols)
    {
        rows = searcherRows(matrix);
        cols = searcherCols(matrix);
    }
    int[] GetNegativeCountPerRow(int [,] matrix)
    {
        int[] counts = new int[matrix.GetLength(0)];
        for (int i = 0;i< matrix.GetLength(0); i++)
        {
            counts[i] = CountNegativeInRow(matrix, i);
        }
        return counts;
    }
    int[] GetMaxNegativePerColumn(int [,] matrix)
    {
        return FindMaxNegativePerColumn(matrix);
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
    bool FindIncreasingSequence(int [] array, int A, int B)
    {
        if (FindSequence(array, A, B)==1) return true;
        return false;
    }
    bool FindDecreasingSequence(int[] array, int A, int B)
    {
        if ( FindSequence(array, A,B)==-1) return true;
        return false;
    }
    int DefineSequence(int [] array, IsSequence findIncreasingSequence, IsSequence findDecreasingSequence)
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
    int [] FindLongestSequence(int [] array, IsSequence sequence)
    {
        int[ ] res = new int[2];
        int maxlength = 0;
        for (int i = 0; i< array.Length; i++)
        {
            for (int j = i+1; j< array.Length; j++)
            {
                if (sequence(array, i, j) && j - i > maxlength)
                {
                    maxlength = j-i;
                    res[0] = i; res[1]=j;
                }
            }
        }
        return res;
    }
    #endregion
    #region bonus part
    public double[,] Task_4(double[,] matrix, int index)
    {
        // MatrixConverter[] mc = new MatrixConverter[4]; - uncomment me

        // code here
        MatrixConverter[] mc = new MatrixConverter[4];
        mc[0] = ToUpperTriangular;
        mc[1] = ToLowerTriangular;
        mc[2] = ToLeftDiagonal;
        mc[3] = ToRightDiagonal;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write(matrix[i, j] + "  ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
        matrix = mc[index](matrix);
        for (int i = 0; i<matrix.GetLength(0); i++)
        {
            for (int j = 0; j<matrix.GetLength(1); j++)
            {
                Console.Write(Math.Round(matrix[i, j], 8)+"  ");
            }
            Console.WriteLine();
        }
        // create public delegate MatrixConverter(matrix);
        // create and use method ToUpperTriangular(matrix);
        // create and use method ToLowerTriangular(matrix);
        // create and use method ToLeftDiagonal(matrix); - start from the left top angle
        // create and use method ToRightDiagonal(matrix); - start from the right bottom angle

        // end

        return matrix;
    }
    public delegate double[,] MatrixConverter(double [,] matrix);
    double[,] ToUpperTriangular(double [,] matrix)
    {
        for (int i = 1; i< matrix.GetLength(0); i++)
        {
            for (int j = 0; j<i; j++)
            {
                double coef = matrix[i, j] / matrix[j, j];
                for (int k = 0; k<matrix.GetLength(1); k++)
                {
                    
                    matrix[i, k] = matrix[i, k] - matrix[j, k] * coef;
                    /*for (int ii = 0; ii < matrix.GetLength(0); ii++)
                    {
                        for (int jj = 0; jj < matrix.GetLength(1); jj++)
                        {
                            Console.Write(matrix[ii, jj] + "  ");
                        }
                        Console.WriteLine();
                    }*/
                }
            }
        }
        return matrix;
    }
    double[,] ToLowerTriangular(double [,] matrix)
    {
        for (int i = matrix.GetLength(0)-2; i>=0; i--)
        {
            
            for (int j = matrix.GetLength(1)-1; j>i; j--)
            {
                double coef = matrix[i, j]/matrix[j, j];
                for (int k = 0; k<matrix.GetLength(1); k++)
                {
                    matrix[i, k] = matrix[i, k] - matrix[j, k] * coef;
                }
            }
        }
        return matrix;
    }
    double[,] ToLeftDiagonal(double [,] matrix)
    {
        matrix = ToUpperTriangular(matrix);
        matrix = ToLowerTriangular(matrix);
        return matrix;

    }
    double[,] ToRightDiagonal(double[,] matrix)
    {
        matrix = ToLowerTriangular(matrix);
        matrix = ToUpperTriangular(matrix);
        
        return matrix;

    }

    #endregion
}
