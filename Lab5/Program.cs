using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.Numerics;
using System.Reflection;
using System.Reflection.Metadata;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Transactions;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class Program
{
    public static void Main()
    {
        Program program = new Program();
    }
    #region Level 1
    static int Factorial(int n)
        {
        if (n < 2) return 1;

        return n*Factorial(n-1);
        }
    static void Combinations (int n, int k, out long combinations)
    {
        combinations = Factorial(n)/(Factorial(k)*Factorial(n-k));
    }
    public long Task_1_1(int n, int k)
    {
        long answer = 0;
        if (n < k || n < 0 || k < 0) return 0;
        Combinations(n, k, out answer);
        
        // code here
        
        // create and use Combinations(n, k);

        // create an d use Factorial(n);

        // end

        return answer;
    }
    static void GeronArea(double a,double b,double c, ref double Area)
    {
        double p = (a+b+c)/2;
        Area = Math.Sqrt(p*(p - a) * (p - b) * (p - c));
        
    }
    public int Task_1_2(double[] first, double[] second)
    {
        int answer = 0;
        double Area1 = 1,Area2=1;
        double a1 = first[0], b1 = first[1], c1= first[2];
        double a2 = second[0], b2 = second[1], c2= second[2];
        GeronArea(a1, b1, c1, ref Area1);
        GeronArea(a2,b2,c2, ref Area2);
        if (a1+b1 <= c1 || a1+c1 <= b1 || b1+c1 <= a1 || a2 + b2 <= c2 || a2 + c2 <= b2 || b2 + c2 <= a2)
        {
            answer = -1;
            return answer;
        } 
        if (Area1 >Area2)
        {
            answer = 1;
        }
        else if (Area2 >Area1)
        {
            answer = 2;
        }
        else if (Area1 == Area2)
        {
            answer = 0;
        }
        // code here
        
        // create and use GeronArea(a, b, c);

        // end

        // first = 1, second = 2, equal = 0, error = -1
        return answer;
    }
    static double GetDistance(double v, double a, int t)
    {
        double S = v * t + (a * t * t) /2.0;
        return S;
    }
    public int Task_1_3a(double v1, double a1, double v2, double a2, int time)
    {
        int answer = 0;

        // code here
        double S1 = GetDistance(v1, a1, time);
        double S2 = GetDistance(v2, a2, time);
        
        ;
        // create and use GetDistance(v, a, t); t - hours
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
        while (GetDistance(v1, a1, time) > GetDistance(v2, a2, time)) time++;
        answer = time;
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
    int FindMaxIndex(double[] A)
    {
        int max_index = 0;
        for (int i = 0; i < A.Length; i++)
        {
            if (A[i] > A[max_index])
            {
                
                max_index = i;
            }
        }
        return max_index;

    }
    //static double AVG(double[] A, double max_elem)
    //{
    //    double avg = 0;
    //    int count = 0;
    //    bool flag = false;
    //    for (int i = 0; i < A.Length; i++)
    //    {
    //        if (!flag)
    //        {
    //            if (A[i] == max_elem)
    //            {
    //                flag = true;
    //            }
    //        }
    //        else
    //        {
    //            avg += A[i];
    //            count++;
    //        }

    //    }
    //    avg /= count;
    //    return avg;
    //}
    void avg(double[] A, int finalmax, out double avg)
    {
        avg = 0;
        int cnt = 0;
        for (int i = finalmax + 1; i < A.Length; i++)
        {
            avg+= A[i]; cnt++;
        }
        avg/= cnt;
    }
    void getArray(ref double[] A, double sr, int finalmax)
    {
        for (int i = 0; i < A.Length; i++)
        {
            if (A[i] == A[finalmax])
                A[i] = sr;
        }
    }
    public void Task_2_2(double[] A, double[] B)
    {
        // code here
        double[] C;
        int finalmax;
        int max_index_A = FindMaxIndex(A);
        int max_index_B = FindMaxIndex(B);
        double sr = 0;
        int cnt = 0;
        if (A.Length - max_index_A > B.Length - max_index_B)
        {
            
            finalmax = max_index_A;
            //for (int i = finalmax + 1; i < A.Length; i++)
            //{
            //    sr += A[i];
            //    cnt++;
            //}
            //sr /= cnt;
            avg(A,finalmax,out sr);
            //for (int i = 0; i < A.Length; i++)
            //{
            //    if (A[i] == A[finalmax])
            //        A[i] = sr;
            //}
            getArray(ref A, sr, finalmax);

        }
        else
        {
            finalmax = max_index_B;
            //for (int i = finalmax + 1; i < B.Length; i++)
            //{
            //    sr += B[i];
            //    cnt++;
            //}
            //sr /= cnt;
            avg(B, finalmax, out sr);
            //for (int i = 0; i < B.Length; i++)
            //{
            //    if (B[i] == B[finalmax])
            //        B[i] = sr;
            //}
            getArray(ref B, sr, finalmax);


        }
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
    int FindDiagonalMaxIndex(int[,] matrix)
    {
        int maxi = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {


            if (matrix[i, i] > matrix[maxi, maxi])
            {
                maxi = i;

            }

        }
        return (maxi);
    }
    public void Task_2_4(int[,] A, int[,] B)
    {
        // code here
        int row_index = FindDiagonalMaxIndex(A);
        int col_index = FindDiagonalMaxIndex(B);
        if (A.GetLength(0) != A.GetLength(1) || B.GetLength(0) != B.GetLength(1) || A.GetLength(0) != B.GetLength(0))
            return;
        int[] temp_A = new int[5];
        int[] temp_B = new int[5];
        for (int i = 0;i< A.GetLength(0); i++)
        {
            temp_A[i] = A[row_index,i];
            temp_B[i] = B[i,col_index];
        }
        for (int i = 0; i < A.GetLength(0); i++)
        {
            A[row_index, i] = temp_B[i];
            B[i, col_index] = temp_A[i];
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
    void FindMax(int[] A, out int index) 
    {
        index = 0;
        int max = int.MinValue;
        for (int i = 0; i < A.Length; i++)
        {
            if (A[i] > max)
            {
                index = i;
                max = A[i];
            }
        }
    }
    int[] DeleteElement(int[] array, int index)
    {
        int[] n = new int[array.Length-1];
        for (int i = 0; i < n.Length; i++)
        {
            if (i < index)
            {
                n[i] = array[i];
            }
            else
            {
                n[i] = array[i + 1];
            }
        }
        
        return n;
    }
    public void Task_2_6(ref int[] A, int[] B)
    {
        // code here
        int max_index_A = 0, max_index_B = 0;
        FindMax(A, out max_index_A);
        FindMax(B, out max_index_B);
        int[] new_A = DeleteElement(A, max_index_A);
        int[] new_B = DeleteElement(B, max_index_B);

        int[] C = new int[new_A.Length + new_B.Length];
        int index = 0;
        foreach (int x in new_A) C[index++] = x;
        foreach (int x in new_B) C[index++] = x;
        A = C;
        // create and use FindMax(matrix, out row, out column); like in Task_2_1
        // create and use DeleteElement(array, index);

        // end
    }

    public void Task_2_7(ref int[,] B, int[,] C)
    {
        // code here

        // create and use CountRowPositive(matrix, rowIndex);
        // create and use CountColumnPositive(matrix, colIndex);

        // end
    }
    int[] SortArrayPart(int[] array,int startIndex)
    {
        
        int[] n = new int[array.Length-startIndex-1];
        int index = 0;
        for (int i = startIndex + 1; i < array.Length; i++)
        {       
            n[index++] = array[i];   
        }
        for (int i = 0; i < n.Length; i++)
        {
            for (int j = 0; j < n.Length - i - 1; j++)
            {
                if (n[j] > n[j + 1])
                {
                    int temp = n[j];
                    n[j] = n[j + 1];
                    n[j + 1] = temp;
                }
            }
        }
        index = 0;
        for (int i = startIndex + 1; i < array.Length; i++)
        {
            array[i] = n[index++];
        }

            return array;
    }
    public void Task_2_8(int[] A, int[] B)
    {
        // code here
        int max_index_A = 0, max_index_B;
        FindMax(A, out max_index_A);
        FindMax(B, out max_index_B);
        A = SortArrayPart(A, max_index_A);
        B = SortArrayPart(B, max_index_B);
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
    void FindMaxElem(int[,] matrix, bool flag, out int col)
    {
        col = 0;
        int rowx = matrix.GetLength(0);
        int colx = matrix.GetLength(1);
        int max = int.MinValue;
        if (flag)
        {
            for (int i = 0;i<rowx;i++)
            {
                for (int j = 0; j < colx; j++)
                {
                    if (i >= j)
                    {
                        if (matrix[i,j] > max)
                        {
                            max = matrix[i,j];
                            col = j;
                        }
                    }
                }
            }
        }
        else
        {
            int min = int.MaxValue;
            for (int i = 0; i < rowx; i++)
            {
                for (int j = 0; j < colx; j++)
                {
                    if (i < j)
                    {
                        if (matrix[i, j] < min)
                        {
                            min = matrix[i, j];
                            col = j;
                        }
                    }
                }
            }
        }
    }
    int[,] RemoveColumn(int[,]matrix, int columnIndex)
    {
        int[,] new_matrix = new int[matrix.GetLength(0), matrix.GetLength(1) - 1];
        int row = new_matrix.GetLength(0);
        int col = new_matrix.GetLength(1);
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                if (j< columnIndex)
                {
                    new_matrix[i,j] = matrix[i, j];

                }
                else
                {
                    new_matrix[i, j] = matrix[i, j + 1];
                }
            }
        }
        return new_matrix;

    }
    public void Task_2_10(ref int[,] matrix)
    {
        // code here
        int down_col = 0, upper_col = 0;
        FindMaxElem(matrix, true,out down_col);
        FindMaxElem(matrix, false, out upper_col);
        if (down_col == upper_col)
        {
            matrix = RemoveColumn(matrix, upper_col);
        }
        else
        {
            matrix = RemoveColumn(matrix, upper_col);
            matrix = RemoveColumn(matrix, down_col);
        }
        // create and use RemoveColumn(matrix, columnIndex);

        // end
    }

    public void Task_2_11(int[,] A, int[,] B)
    {
        // code here

        // use FindMaxIndex(matrix, out row, out column); from Task_2_1

        // end
    }
    int FindMaxColumnIndex(int[,] matrix)
    {

        int row = matrix.GetLength(0);
        int col = matrix.GetLength(1);
        int max_col = 0, max = int.MinValue;
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                if (matrix[i,j] > max)
                {
                    max = matrix[i,j];
                    max_col = j;
                }
            }
        }
        return max_col;

    }
    public void Task_2_12(int[,] A, int[,] B)
    {
        // code here
        int max_col_A = FindMaxColumnIndex(A), max_col_B = FindMaxColumnIndex(B);
        for (int i = 0;i< A.GetLength(0); i++)
        {
            int temp = A[i,max_col_A];
            A[i,max_col_A] = B[i,max_col_B];
            B[i,max_col_B] = temp;
        }
        // create and use FindMaxColumnIndex(matrix);

        // end
    }

    public void Task_2_13(ref int[,] matrix)
    {
        // code here

        // create and use RemoveRow(matrix, rowIndex);

        // end
    }
    void SortRow(int[,] matrix,int rowIndex)
    {
        for (int i = 0,j=1;i< matrix.GetLength(1);)
        {
            if (i==0 || matrix[rowIndex,i] >= matrix[rowIndex, i - 1])
            {
                i = j;
                j++;
            }
            else
            {
                int temp = matrix[rowIndex,i];
                matrix[rowIndex,i] = matrix[rowIndex,i-1];
                matrix[rowIndex,i-1] = temp;
                i--;
            }
        }
    }
    public void Task_2_14(int[,] matrix)
    {
        // code here
        for (int i = 0; i< matrix.GetLength(0); i++)
        {
            SortRow(matrix,i);
        }
        // create and use SortRow(matrix, rowIndex);

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
    void SortNegative(int[] array)
    {
        int n = array.Length, cnt = 0;
        for (int i = 0; i < n; i++)
        {
            if(array[i] < 0)
            {
                cnt++; 
            }
        }
        int[] neg = new int[cnt];
        int index = 0;
        for (int i = 0;i < n; i++)
        {
            if (array[i] < 0)
            {
                neg[index] = array[i];
                index++;
            }
        }
        for (int i = 0;i< cnt; i++)
        {
            for (int j = 0;j < cnt-i-1; j++)
            {
                if (neg[j] < neg[j + 1])
                {
                    int temp = neg[j];
                    neg[j] = neg[j + 1];
                    neg[j + 1] = temp;
                }
            }
        }
        index = 0;
        for (int i = 0; i < n; i++)
        {
            if (array[i] < 0)
            {
                array[i] = neg[index];
                index++;
            }
        }
    }
    public void Task_2_16(int[] A, int[] B)
    {
        // code here
        SortNegative(A);
        SortNegative(B);
        // create and use SortNegative(array);

        // end
    }

    public void Task_2_17(int[,] A, int[,] B)
    {
        // code here

        // create and use SortRowsByMaxElement(matrix);

        // end
    }
    void SortDiagonal(int[,] matrix)
    {
        int[] diagonal = new int[matrix.GetLength(0)];
        int index = 0;
        for (int i = 0;i< matrix.GetLength(0); i++)
        {
            diagonal[index++] = matrix[i,i];
        }
        int n = matrix.GetLength(0);
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j<n-i-1; j++)
            {
                if (diagonal[j] > diagonal[j + 1])
                {
                    int temp = diagonal[j];
                    diagonal[j] = diagonal[j + 1];
                    diagonal[j + 1] = temp;
                }
            }
        }
        index = 0;
        for (int i = 0; i < n; i++)
        {
            matrix[i, i] = diagonal[index++];
        }
    }
    public void Task_2_18(int[,] A, int[,] B)
    {
        // code here
        SortDiagonal(A);
        SortDiagonal(B);
        // create and use SortDiagonal(matrix);

        // end
    }

    public void Task_2_19(ref int[,] matrix)
    {
        // code here

        // use RemoveRow(matrix, rowIndex); from 2_13

        // end
    }
    void RemoveZeroColumn (int[,] matrix)
    {
        
        for (int i = 0; i < matrix.GetLength(1);i++)
        {
            int cnt = 0;
            for (int j = 0; j < matrix.GetLength(0); j++)
            {
                if (matrix[j, i] == 0)
                {
                    cnt++;
                    break;
                }
            }
            if (cnt == 0)
            {
                matrix = RemoveColumn(matrix, i);
                i--;
            }

        }
    }
    int CountZero (int[,] matrix, int col)
    {
        
            int cnt = 0;
            for (int j = 0;j < matrix.GetLength(0); j++)
            {
                if (matrix[j, col] == 0)
                {
                    cnt++;
                    return cnt;
                }
            }
        
        return 0;
    }
    public void Task_2_20(ref int[,] A, ref int[,] B)
    {
        // code here
        for (int i = 0; i < A.GetLength(1); i++)
        {
            int count = CountZero(A,i);


            //for (int j = 0; j < A.GetLength(0); j++)
            //{
            //    if (A[j, i] == 0)
            //    {
            //        count++;

            //        break;
            //    }
            //}
            if (count == 0)
            {
                A = RemoveColumn(A, i);


                i--;
            }
        }
        for (int i = 0; i < B.GetLength(1); i++)
        {
            int count = CountZero(B, i);
            //for (int j = 0; j < B.GetLength(0); j++)
            //{
            //    if (B[j, i] == 0)
            //    {
            //        count++;

            //        break;
            //    }
            //}
            if (count == 0)
            {

                B = RemoveColumn(B, i);
                i--;


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
    int CountNegativeInRow(int[,]matrix,int rowIndex)
    {
        int cnt = 0;
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (matrix[rowIndex, j] < 0) cnt++;
        }
        
        
        
        return cnt;
    }
    int[] FindMaxNegativePerColumn(int[,] matrix)
    {
        int[] array = new int[matrix.GetLength(1)];
        int max = int.MinValue;
        for (int i = 0; i<matrix.GetLength(1); i++)
        {
            max = int.MinValue;
            for (int j = 0;j < matrix.GetLength(0); j++)
            {
                if (matrix[j,i] > max && matrix[j, i] < 0)
                {
                    max = matrix[j, i];
                }
            }
            array[i] = max;
        }

        return array;
    }
    public void Task_2_22(int[,] matrix, out int[] rows, out int[] cols)
    {
        rows = new int[matrix.GetLength(0)];
        cols = null;
        for (int i = 0;i< matrix.GetLength(0); i++)
        {
            
            rows[i] = CountNegativeInRow(matrix,i);
        }
        cols = FindMaxNegativePerColumn(matrix);
        // code here

        // create and use CountNegativeInRow(matrix, rowIndex);
        // create and use FindMaxNegativePerColumn(matrix);

        // end
    }

    public void Task_2_23(double[,] A, double[,] B)
    {
        // code here

        // create and use MatrixValuesChange(matrix);

        // end
    }
    int[,] SwapColumnDiagonal(int[,]matrix, int columnIndex)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            int temp = matrix[i, i];
            matrix[i, i] = matrix[i, columnIndex];
            matrix[i, columnIndex] = temp;

        }
        return matrix;
    }
    public void Task_2_24(int[,] A, int[,] B)
    {
        // code here
        int maxA = FindMaxColumnIndex(A);
        A = SwapColumnDiagonal(A, maxA);
        int maxB = FindMaxColumnIndex(B);
        B = SwapColumnDiagonal(B, maxB);
        // use FindMaxIndex(matrix, out row, out column); like in 2_1
        // create and use SwapColumnDiagonal(matrix, columnIndex);

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
    int FindRowWithMaxNegativeCount(int[,] matrix)
    {
        int row = matrix.GetLength(0);
        int column = matrix.GetLength(1);
        int max_row = -1, max = int.MinValue;
        for (int i = 0; i < row; i++)
        {
            int cnt = CountNegativeInRow(matrix, i);
            if (cnt > max)
            {
                max = cnt;
                max_row = i;
            }
        }
        
        return max_row;
    }
    public void Task_2_26(int[,] A, int[,] B)
    {
        // code here
        int max_row_A = FindRowWithMaxNegativeCount(A);
        int max_row_B = FindRowWithMaxNegativeCount(B);
        for (int i = 0; i < A.GetLength(1); i++)
        {
            int temp = A[max_row_A, i];
            A[max_row_A, i] = B[max_row_B, i];
            B[max_row_B,i] = temp;
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
    int FindSequence(int[]array,int A,int B)
    {
        if (A >= B) 
            return 0;
        bool flag;
        if (array[A] < array[A + 1])
        {
            flag = true;
        }
        else
        {
            flag = false;
        }
            
        
        for (int i = A; i < B; i++)
        {
            if (flag && array[i] > array[i + 1]) 
                return 0;
            if (!flag && array[i] < array[i + 1]) 
                return 0;
        }
        if (flag) return 1;
        else return -1;
        
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
    int[,] FindIndexPairs(int[] array)
    {
        int cnt = 0;
        for (int i = 0; i < array.Length; i++)
        {
            for (int j = i + 1; j < array.Length; j++)
            {
                if (FindSequence(array, i, j) != 0)
                {
                    cnt++;
                }
            }
        }

        int[,] result = new int[cnt, 2];
        cnt = 0;

        for (int i = 0; i < array.Length; i++)
        {
            for (int j = i + 1; j < array.Length; j++)
            {
                if (FindSequence(array, i, j) != 0)
                {
                    result[cnt, 0] = i;
                    result[cnt, 1] = j;
                    cnt++;
                }
            }
        }

        return result;
    }

   

    void PrintResults(int[,] results)
    {
        for (int i = 0; i < results.GetLength(0); i++)
        {
            Console.WriteLine($"({results[i, 0]}, {results[i, 1]})");
        }
    }
    void method (int[] array, ref int[,] answer)
    {
        int cnt = 0;
        for (int i = 0; i < array.Length; i++)
        {
            for (int j = i + 1; j < array.Length; j++)
            {
                int seq = FindSequence(array, i, j);
                if (seq != 0) cnt++;
            }
        }
        answer = new int[cnt, 2];
        cnt = 0;
        for (int i = 0; i < array.Length; i++)
        {
            for (int j = i + 1; j < array.Length; j++)
            {
                int seq = FindSequence(array, i, j);
                if (seq != 0)
                {
                    answer[cnt, 0] = i;
                    answer[cnt, 1] = j;
                    cnt++;
                }
            }
        }
    }
public void Task_2_28b(int[] first, int[] second, ref int[,] answerFirst, ref int[,] answerSecond)
    {
        // code here
        int cnt = 0;
        //for (int i = 0; i < first.Length; i++)
        //{
        //    for (int j = i + 1; j < first.Length; j++)
        //    {
        //        int seq = FindSequence(first, i, j);
        //        if (seq != 0) cnt++;
        //    }
        //}
        //answerFirst = new int[cnt, 2];
        //cnt = 0;
        //for (int i = 0; i < first.Length; i++)
        //{
        //    for (int j = i + 1; j < first.Length; j++)
        //    {
        //        int seq = FindSequence(first, i, j);
        //        if (seq != 0)
        //        {
        //            answerFirst[cnt, 0] = i;
        //            answerFirst[cnt, 1] = j;
        //            cnt++;
        //        }
        //    }
        //}
        method(first, ref answerFirst);
        method(second, ref answerSecond);
        //cnt = 0;
        //for (int i = 0; i < second.Length; i++)
        //{
        //    for (int j = i + 1; j < second.Length; j++)
        //    {
        //        int seq = FindSequence(second, i, j);
        //        if (seq != 0) cnt++;
        //    }
        //}
        //answerSecond = new int[cnt, 2];
        //cnt = 0;
        //for (int i = 0; i < second.Length; i++)
        //{
        //    for (int j = i + 1; j < second.Length; j++)
        //    {
        //        int seq = FindSequence(second, i, j);
        //        if (seq != 0)
        //        {
        //            answerSecond[cnt, 0] = i;
        //            answerSecond[cnt, 1] = j;
        //            cnt++;
        //        }
        //    }
        //}
        // use FindSequence(array, A, B); from Task_2_28a or entirely Task_2_28a
        // A and B - start and end indexes of elements from array for search

        // end
    }
    void abc(ref int a, ref int b, int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            for (int j = i + 1; j < array.Length; j++)
            {
                int seq = FindSequence(array, i, j);
                if (seq != 0 && b - a < j - i)
                {
                    a = i;
                    b = j;
                }
            }
        }
    }
    public void Task_2_28c(int[] first, int[] second, ref int[] answerFirst, ref int[] answerSecond)
    {
        // code here
        int a = 0, b = 0;
        abc(ref a, ref b, first);
        //for (int i = 0; i < first.Length; i++)
        //{
        //    for (int j = i + 1; j < first.Length; j++)
        //    {
        //        int seq = FindSequence(first, i, j);
        //        if (seq != 0 && b - a < j - i)
        //        {
        //            a = i;
        //            b = j;
        //        }
        //    }
        //}
        answerFirst = new int[] { a, b };

        a = 0; b = 0;
        abc(ref a, ref b, second);
        //for (int i = 0; i < second.Length; i++)
        //{
        //    for (int j = i + 1; j < second.Length; j++)
        //    {
        //        int seq = FindSequence(second, i, j);
        //        if (seq != 0 && b - a < j - i)
        //        {
        //            a = i;
        //            b = j;
        //        }
        //    }
        //}
        answerSecond = new int[] { a, b };
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
    public delegate void SortRowStyle(int[,] matrix, int rowIndex);
    void SortAscending(int[,] matrix, int rowIndex)
    {
        for (int i = 1; i < matrix.GetLength(1);)
        {
            if (i == 0 || matrix[rowIndex, i] > matrix[rowIndex, i - 1])
                i++;
            else
            {
                int temp = matrix[rowIndex, i];
                matrix[rowIndex, i] = matrix[rowIndex, i - 1];
                matrix[rowIndex, i - 1] = temp;
                i--;
            }
        }


    }
    void SortDescending(int[,] matrix, int rowIndex)
    {
        for (int k = 0; k < matrix.GetLength(1); k++)
        {

            int i = k, j = k - 1;
            while (j >= 0)
            {
                if (matrix[rowIndex, j] < matrix[rowIndex, i])
                {
                    var temp = matrix[rowIndex, i];
                    matrix[rowIndex, i] = matrix[rowIndex, j];
                    matrix[rowIndex, j] = temp;
                    i = j;
                }
                j--;
            }

        }


    }
    public void Task_3_2(int[,] matrix)
    {
        SortRowStyle sortStyle = default(SortRowStyle);
        // code here
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            if (i % 2 == 0)
                sortStyle = SortAscending;
            else 
                sortStyle = SortDescending;
            sortStyle(matrix, i);
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
    int f(int[,] matrix)
    {
        int a = matrix.GetLength(0),sum=0;
        for (int i = a; i > 0; i--)
        {
            sum += i;
        }
        return sum;
    }
    int[] GetUpperTriange(int[,] matrix)
    {
        int n = f(matrix);
        int[] array = new int[n];
        int index = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (i <= j)
                {
                    array[index++] = matrix[i,j];
                }
            }
        }
        return array;
    }
    int[] GetLowerTriange(int[,] matrix)
    {
        int n = f(matrix);
        int[] array = new int[n];
        int index = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (i >= j)
                {
                    array[index++] = matrix[i, j];
                }
            }
        }
        return array;
    }
    int GetSum(GetTriangle getTriangle, int[,] matrix)
    {
        int[] arr = getTriangle(matrix);
        int ans = 0;
        foreach (int elem in arr)
            ans += elem * elem;
        return ans;
    }
    public int Task_3_4(int[,] matrix, bool isUpperTriangle)
    {
        int answer = 0;

        // code here
        GetTriangle gettriangle = default(GetTriangle);
        if (isUpperTriangle)
        {
            answer = GetSum(GetUpperTriange, matrix);
        }
        else
        {
            answer = GetSum(GetLowerTriange, matrix);
        }
        // create and use public delegate GetTriangle(matrix);
        // create and use methods GetUpperTriange(array) and GetLowerTriange(array)
        // create and use GetSum(GetTriangle, matrix)

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
    int FindFirstRowMaxIndex(int[,] matrix)
    {
        int max = int.MinValue;
        int max_col = 0;
        for (int i = 0;i< matrix.GetLength(1); i++)
        {
            if (matrix[0,i] > max)
            {
                max = matrix[0,i];
                max_col = i;
            }
        }
        return max_col;
    }
    void SwapColumns(int[,]matrix, FindElementDelegate findDiagonalMaxIndex, FindElementDelegate FindFirstRowMaxIndex)
    {
        int diagonal_max = findDiagonalMaxIndex(matrix);
        int firstrow_max = FindFirstRowMaxIndex(matrix);
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            int temp = matrix[i, diagonal_max];
            matrix[i, diagonal_max] = matrix[i, firstrow_max];
            matrix[i, firstrow_max] = temp;
        }
        
    }
    public void Task_3_6(int[,] matrix)
    {
        // code here
        
        // create and use public delegate FindElementDelegate(matrix);
        // use method FindDiagonalMaxIndex(matrix) like in Task_2_3;
        // create and use method FindFirstRowMaxIndex(matrix);
        // create and use method SwapColumns(matrix, FindDiagonalMaxIndex, FindFirstRowMaxIndex);
         SwapColumns(matrix, FindDiagonalMaxIndex, FindFirstRowMaxIndex);
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
    int FindMaxLowerTriangle(int[,] matrix)
    {
        //FindMax(GetLowerTriange(matrix), out var index_low);
        //return index_low;
        int im = 0, jm = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
            for (int j = 0; j <= i; j++)
                if (matrix[i, j] > matrix[im, jm])
                {
                    im = i;
                    jm = j;
                }
        return jm;
    }
    int FindMaxUpperTriangle(int[,] matrix)
    {
        //FindMax(GetUpperTriange(matrix), out var index_up);
        //return index_up;
        int im = 0, jm= 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
            for (int j = i + 1; j < matrix.GetLength(1); j++)
                if (matrix[i, j] < matrix[im, jm])
                {
                    im = i;
                    jm = j;
                }
        return jm;
    }
    void remove(ref int[,]matrix, FindIndex FindMaxLowerTriangle, FindIndex FindMaxUpperTriangle)
    {
        int a = FindMaxLowerTriangle(matrix);
        int b = FindMaxUpperTriangle(matrix);
        if (a > b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
        matrix = RemoveColumn(matrix, b);
        if (a != b)
            matrix = RemoveColumn(matrix, a);
    }
    public void Task_3_10(ref int[,] matrix)
    {
        FindIndex searchArea = default(FindIndex);// - uncomment me
        remove(ref matrix, FindMaxLowerTriangle, FindMaxUpperTriangle);
        
        

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

        // end
    }
    public delegate int[] GetNegativeArray(int[,] matrix);
    int[] GetNegArray(int[,] matrix)
    {
        int[] array = new int[matrix.GetLength(0)];
        for (int i = 0; i < matrix.GetLength(0); i++)
            array[i] = CountNegativeInRow(matrix, i);
        return array;
    }
    void FindNegatives(int[,]matrix, GetNegativeArray searcherRows, GetNegativeArray searcherCols, out int[] rows, out int[] cols)
    {
        rows = searcherRows(matrix);
        cols = searcherCols(matrix);
    }
    public void Task_3_22(int[,] matrix, out int[] rows, out int[] cols)
    {

        rows = null;
        cols = null;
        FindNegatives(matrix, GetNegArray, FindMaxNegativePerColumn, out rows, out cols);
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

        // end
    }
    public delegate bool IsSequence(int[]array,int left,int right);
    bool FindIncreasingSequence(int[]array,int A,int B)
    {
        return FindSequence(array,A,B) == 1;
    }
    bool FindDecreasingSequence(int[]array,int A,int B)
    {
        return FindSequence(array, A, B) == -1; 
    }
    int DefineSequence(int[]array,IsSequence findIncreasingSequence,IsSequence findDecreasingSequence)
    {
        if (findIncreasingSequence(array, 0, array.Length - 1))
        {
            return 1;
        }
        else if (findDecreasingSequence(array, 0, array.Length - 1))
        {
            return -1;
        }
        else
            return 0;
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
    int[] FindLongestSequence(int[]array,IsSequence sequence)
    {
        int a = 0;
        int b = 0;
        int n = array.Length;
        for (int i = 0; i < n; i++)
        {
            for (int j = i+1; j < n; j++)
            {
                if (sequence(array, i, j) && j - i > b - a)
                {
                    a = i;
                    b = j;
                }
            }
        }
        return [a, b];
    }
    public void Task_3_28c(int[] first, int[] second, ref int[] answerFirstIncrease, ref int[] answerFirstDecrease, ref int[] answerSecondIncrease, ref int[] answerSecondDecrease)
    {
        // code here
        answerFirstIncrease = FindLongestSequence(first, FindIncreasingSequence);
        answerSecondIncrease = FindLongestSequence(second, FindIncreasingSequence);

        answerFirstDecrease = FindLongestSequence(first,FindDecreasingSequence);
        answerSecondDecrease = FindLongestSequence(second, FindDecreasingSequence);
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
