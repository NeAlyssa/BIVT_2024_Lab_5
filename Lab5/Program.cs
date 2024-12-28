using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Numerics;
using System.Reflection;
using System.Reflection.Metadata;
using System.Runtime.Intrinsics.X86;
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
        answer = Combinations(n, k);
        // code here

        // create and use Combinations(n, k);
        // create and use Factorial(n);

        return answer;
    }
    int Combinations(int n, int k)
    {
        return Factorial(n) / (Factorial(k) * Factorial(n - k));
    }

    int Factorial(int n)
        {
            int s = 1;
            for (int i=1; i<=n; i++)
            {
                s *= i;
            }
            return s;
        }
        // end

    public int Task_1_2(double[] first, double[] second)
    {
        
        double s1 = GeronArea(first[0], first[1], first[2]);
        double s2 = GeronArea(second[0], second[1], second[2]);

        // code here

        // create and use GeronArea(a, b, c);

        // end
        if (s1 == -1 || s2 == -1) return -1;
        if (s1 > s2) return 1;
        else if (s2 > s1) return 2;
        else return 0;
        // first = 1, second = 2, equal = 0, error = -1
        
    }
    double GeronArea(double a, double b, double c)
    {
        double p = (a + b + c) / 2;
        if (p <= a || p <= b || p <= c) return -1;
        return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
    }

    public int Task_1_3a(double v1, double a1, double v2, double a2, int time)
    {
        double s1 = GetDistance(v1, a1, time);
        double s2 = GetDistance(v2, a2, time);
        if (s1 > s2) return 1;
        else if (s2 > s1) return 2;
        else return 0;
        // code here

        // create and use GetDistance(v, a, t); t - hours

        // end

        // first = 1, second = 2, equal = 0
        
    }
    double GetDistance(double v, double a, int t)
    {
        double s = v * t + a * t * t / 2;
        return s;
    }

    public int Task_1_3b(double v1, double a1, double v2, double a2)
    {
       int t = 1;
       while (GetDistance(v1-v2, a1-a2,t)>0)
            {
                t++;
            }
        return t;
        // code here
        
        // use GetDistance(v, a, t); t - hours

        // end

    }
    #endregion

    #region Level 2
    public void Task_2_1(int[,] A, int[,] B)
    {
        // code here
        int i1 = 0;
        int i2 = 0;
        int j1 = 0;
        int j2 = 0;
        FindMaxIndex(A, out i1, out j1);
        FindMaxIndex(B, out i2, out j2);
        (A[i1, j1], B[i2, j2]) = (B[i2, j2], A[i1, j1]);
        // create and use FindMaxIndex(matrix, out row, out column);

        // end
    }
    void FindMaxIndex(int[,]A, out int row, out int column)
    {
        row = 0;
        column = 0;
        int m = A[0, 0];
        for (int i=0; i<A.GetLength(0); i++)
        {
            for (int j=0; j<A.GetLength(1); j++)
            {
                if (A[i,j]>m)
                {
                    row = i;
                    column = j;
                    m= A[i,j];
                }
            }
        }
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
        zadacha(ref B);
        //  create and use method FindDiagonalMaxIndex(matrix);
        zadacha(ref C);
        // end
    }
    void zadacha(ref int[,]B)
    {
        int i1 = FindDiagonalMaxIndex(B);
        int[,] D = new int[B.GetLength(0) - 1, B.GetLength(1)];
        for (int i = 0; i < i1; i++)
        {
            for (int j = 0; j < B.GetLength(1); j++)
            {
                D[i, j] = B[i, j];
            }
        }
        for (int i = i1 + 1; i < B.GetLength(0); i++)
        {
            for (int j = 0; j < B.GetLength(1); j++)
            {
                D[i - 1, j] = B[i, j];
            }
        }
        B = D;
    }
    int FindDiagonalMaxIndex(int [,]A)
    {
        int i1 = 0;
        int m = A[0, 0];
        for (int i=0; i<A.GetLength (0); i++)
        {
            if (A[i,i]>m)
            {
                m = A[i, i];
                i1 = i;
            }
        }
        return i1;
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
        int j0 = 1;
        int i1 = FindMaxInColumn(A, ref j0);
        // create and use FindMaxInColumn(matrix, columnIndex, out rowIndex);
        int i2= FindMaxInColumn(B,ref j0);
        for (int j=0; j< A.GetLength(1); j++)
        {
            (A[i1, j], B[i2, j]) = (B[i2, j], A[i1, j]);
        }    
        
        // end
    }
    int FindMaxInColumn(int[,] A, ref int column)
    {
        int row = 0;
        int m = A[0, column];
        for (int i=0; i<A.GetLength(0); i++)
        {
            if (A[i,column]>m)
            {
                m=A[i, column];
                row=i;
            }
        }
        return row;
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
        int m = 0;
        int i0 = 0;
        for (int i=0; i<B.GetLength(0);i++)
        {
            if (CountRowPositive(B, i)>m)
            {
                m=CountRowPositive(B,i);
                i0 = i;
            }
        }
        int n = 0;
        int j0 = 0;
        for (int j=0; j<C.GetLength(1);j++)
        {
            if (CountColumnPositive(C, j) > n)
            {
                n = CountColumnPositive(C, j);
                j0 = j;
            }
        }
        int[,] D = new int[B.GetLength(0) + 1, B.GetLength(1)];
        for (int i=0; i<B.GetLength(0);i++)
        {
            for (int j=0; j<B.GetLength(1); j++)
            {
                if (i<=i0)
                {
                    D[i, j] = B[i, j];
                }
                if (i>i0)
                {
                    D[i+1, j] = B[i, j];
                }
            }
        }
        for (int j=0; j<B.GetLength(1);j++)
        {
            D[i0 + 1, j] = C[j, j0];
        }
        B = D;
        // create and use CountRowPositive(matrix, rowIndex);
        // create and use CountColumnPositive(matrix, colIndex);

        // end
    }
    int CountColumnPositive(int[,]A, int j)
    {
        int k = 0;
        for (int i=0; i<A.GetLength(0);i++)
        {
            if (A[i, j] > 0) k++;
        }
        return k;
    }
    int CountRowPositive(int[,]A, int i)
    {
        int k = 0;
        for (int j=0; j<A.GetLength(1); j++)
        {
            if (A[i, j] > 0) k ++;
        }
        return k;
    }
    public void Task_2_8(int[] A, int[] B)
    {
        // code here

        // create and use SortArrayPart(array, startIndex);

        // end
    }

    public int[] Task_2_9(int[,] A, int[,] C)
    {
        int[] answer = new int[A.GetLength(1) + C.GetLength(1)];
        int[] S = SumPositiveElementsInColumns(A);
        int[] D = SumPositiveElementsInColumns(C);
        int Z = 0;
        for (int i=0; i<answer.Length; i++)
        {
            if (i < A.GetLength(1)) answer[i] = S[i];
            else
            {
                answer[i] = D[Z];
                Z++;
            }
        }
        
        // code here

        // create and use SumPositiveElementsInColumns(matrix);

        // end

        return answer;
    }
    int[] SumPositiveElementsInColumns(int[,]A)
    {
        int[] B = new int[A.GetLength(1)];
        int z = 0;
        for (int j=0; j<A.GetLength(1);j++)
        {
            int s = 0;
            for (int i=0; i<A.GetLength(0);i++)
            {
                if (A[i,j]>0)
                {
                    s += A[i, j];
                }
            }
            B[z] = s;
            z++;
        }
        

        return B;
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
        FindMaxIndex(A, out int i, out int j);
        FindMaxIndex(B, out int i1, out int j1);
        (A[i, j], B[i1, j1]) = (B[i1, j1], A[i, j]);
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
        FindMaxIndex(matrix, out int i, out int j);
        FindMinIndex(matrix, out int i1, out int j1);
        matrix=RemoveRow(matrix, Math.Max(i, i1));
        if (i != i1)
        {
           matrix=RemoveRow(matrix, Math.Min(i,i1));
        }
        
        // create and use RemoveRow(matrix, rowIndex);
        // end
    }
    int[,] RemoveRow(int[,] A, int index)
    {
        int[,] B = new int[A.GetLength(0) - 1, A.GetLength(1)]; 
        for (int i=0; i<B.GetLength(0);i++)
        {
            for (int j=0; j<B.GetLength(1);j++)
            {
                if (i < index)
                {
                    B[i,j]= A[i,j];
                }
                else 
                {
                    B[i,j]= A[i+1,j];
                }
            }
        }
        return B;
    }
    void FindMinIndex(int[,] A, out int row, out int column)
    {
        row = 0;
        column = 0;
        int m = A[0, 0];
        for (int i = 0; i < A.GetLength(0); i++)
        {
            for (int j = 0; j < A.GetLength(1); j++)
            {
                if (A[i, j] < m)
                {
                    row = i;
                    column = j;
                    m = A[i, j];
                }
            }
        }
    }
    public void Task_2_14(int[,] matrix)
    {
        // code here

        // create and use SortRow(matrix, rowIndex);

        // end
    }

    public int Task_2_15(int[,] A, int[,] B, int[,] C)
    {
        int answer = 0;

        // code here
        double[] D = new double[3];
        D[0] = GetAverageWithoutMinMax(A);
        D[1]= GetAverageWithoutMinMax(B);
        D[2]= GetAverageWithoutMinMax(C);
        if (D[0] < D[1] && D[1] < D[2]) return 1;
        else if (D[0] > D[1] && D[1] > D[2]) return -1;
        else return 0;
        // create and use GetAverageWithoutMinMax(matrix);

        // end

        // 1 - increasing   0 - no sequence   -1 - decreasing
        return answer;
    }
    double GetAverageWithoutMinMax(int[,] A)
    {
        double s = 0;
        FindMaxIndex(A, out int i0, out int j0);
        FindMinIndex(A, out int i1, out int j1);
        int k = 0;
        for (int i=0; i<A.GetLength(0); i++ )
        {
            for (int j=0; j<A.GetLength(1); j++ )
            {
                if (A[i, j] != A[i0,j0] && A[i,j]!= A[i1,j1])
                {
                    s += A[i, j];
                    k++;
                }
            }
        }
        if (k==0) return 0;
        else s = s / k;
        return s;
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
        SortRowsByMaxElement(ref A);
        SortRowsByMaxElement(ref B);
        // create and use SortRowsByMaxElement(matrix);

        // end
    }
    void SortRowsByMaxElement( ref int[,]A)
    {
        for (int i = 0; i < A.GetLength(0); i++)
        {
            for (int k = 0; k < A.GetLength(0) - 1 - i; k++)
            {

                int y = k + 1;
                if (FindMaxInRow(A, ref k)< FindMaxInRow(A,ref y))
                {
                    for (int j = 0; j < A.GetLength(1); j++)
                    {
                        (A[k, j], A[y, j]) = (A[y, j], A[k, j]);
                    }
                }
            }

        }
    }
    int FindMaxInRow(int[,] A, ref int row)
    {
        int column = 0;
        int m = A[row,0];
        for (int j = 0; j < A.GetLength(1); j++)
        {
            if (A[row,j] > m)
            {
                m = A[row,j];
                column=j;
            }
        }
        return m;
    }
    int FindMinInRow(int[,] A, ref int row)
    {
        int column = 0;
        int m = A[row, 0];
        for (int j = 0; j < A.GetLength(1); j++)
        {
            if (A[row, j]< m)
            {
                m = A[row, j];
                column = j;
            }
        }
        return m;
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
        int k = 0;
        for (int i=0; i<matrix.GetLength(0); i++)
        {
            for (int j=0; j<matrix.GetLength(1);j++)
            {
                if (matrix[i,j]==0)
                {
                    k++;
                    break;
                }
            }
        }
        int[] B = new int[k];
        int z = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i,j]==0)
                {
                    B[z] = i;
                    z++;
                    break;
                }
            }
        }
        for (int i = B.Length-1; i>=0; i--)
        {
            matrix=RemoveRow(matrix, B[i]);
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
        answerA = CreateArrayFromMins(A, out int[] D);
        answerB = CreateArrayFromMins(B, out int[]S);

        // code here

        // create and use CreateArrayFromMins(matrix);

        // end
    }
    int[] CreateArrayFromMins(int[,] A, out int []B)
    {
        int k = A.GetLength(0);
        B = new int[k];
        int z = 0;
        
        for (int i=0; i<A.GetLength(0); i++)
        {
            int m = A[i, i];
            for (int j=i;  j<A.GetLength(1); j++)
            {
                if (A[i,j]<m)
                {
                    m = A[i, j];

                }
            }
            B[z] = m; z++;
        }

        
        return B;
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
        MatrixValuesChange(A);
        MatrixValuesChange(B);
        // create and use MatrixValuesChange(matrix);

        // end
    }
    void MatrixValuesChange(double[,]A)
    {
        
        int[]I = new int[5];
        int[]J= new int[5];
        
        
        int i1 = 0; int j1 = 0;
        double n = int.MaxValue;
        if (A.GetLength(0) <= 2 && A.GetLength(1) <= 2)
        {
            for (int i = 0; i < A.GetLength(0); i++)
            {
                for (int j = 0; j < A.GetLength(1); j++)
                {
                    if (A[i, j] > 0) A[i, j] *= 2;
                    else A[i, j] /= 2;
                }
            }
        }
        else
        {
            for (int k = 0; k < 5; k++)
            {
                double m = int.MinValue;
                for (int i = 0; i < A.GetLength(0); i++)
                {
                    for (int j = 0; j < A.GetLength(1); j++)
                    {
                        if (A[i, j] > m && A[i, j] <= n)
                        {
                            m = A[i, j];
                            i1 = i;
                            j1 = j;
                        }
                    }
                }
                n = m;
                if (A[i1, j1] > 0) A[i1, j1] *= 2;
                else A[i1, j1] /= 2;
                I[k] = i1;
                J[k] = j1;


            }
            for (int i = 0; i < A.GetLength(0); i++)
            {
                for (int j = 0; j < A.GetLength(1); j++)
                {
                    if (A[i, j] == A[I[0], J[0]] || A[i, j] == A[I[1], J[1]] || A[i, j] == A[I[2], J[2]] || A[i, j] == A[I[3], J[3]] || A[i, j] == A[I[4], J[4]])
                    {
                    }

                    else
                    {
                        if (A[i, j] > 0) A[i, j] /= 2;
                        else A[i, j] *= 2;
                    }
                }
            }
        }
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
        maxA = FindRowWithMaxNegativeCount(A);
        maxB = FindRowWithMaxNegativeCount(B);

        // code here

        // create and use FindRowWithMaxNegativeCount(matrix);
        // in FindRowWithMaxNegativeCount create and use CountNegativeInRow(matrix, rowIndex); like in 2_22

        // end
    }
    int FindRowWithMaxNegativeCount(int[,]A)
    {
        int m = 0;
        for (int i1=0; i1<A.GetLength(0); i1++)
        {
            if (CountNegativeInRow(A,i1)>m)
            {
                m = i1;
            }
        }
        return m;
    }
    int CountNegativeInRow(int[,]A, int i)
    {
        int k = 0;
        for (int j=0; j < A.GetLength(1); j++)
        {
            if (A[i, j] < 0) k++;
        }
        return k;
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
        zadanie(ref A);
        zadanie(ref B);
        
        // create and use FindRowMaxIndex(matrix, rowIndex, out columnIndex);
        // create and use ReplaceMaxElementOdd(matrix, row, column);
        // create and use ReplaceMaxElementEven(matrix, row, column);

        // end
    }
    void zadanie(ref int[,]A)
    {
        for (int i = 0; i < A.GetLength(0); i++)
        {
            int j = FindRowMaxIndex(A, i, out int j0);
            if (i % 2 == 0) ReplaceMaxElementOdd(A, i, j);
            else ReplaceMaxElementEven(A, i, j);
        }

    }
    int FindRowMaxIndex(int[,]A, int i, out int j)
    {
        j = 0;
        
        for (int j0=0; j0<A.GetLength(1); j0++)
        {
            if (A[i, j0] > A[i,j])
            {
                
                j = j0;
            }
        }
        return j;
    }
    void ReplaceMaxElementEven(int[,] A, int i, int j)
    {
        A[i, j] = 0;
    }

    void ReplaceMaxElementOdd(int[,] A, int i, int j)
    {
        
            A[i, j] *= (j+1) ;
        
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

    public void Task_3_1(ref double[,] firstSumAndY, ref double[,] secondSumAndY)
    {
        // code here
        double a1 = 0.1, a2 = double.Pi / 5, b1 = 1, b2 = double.Pi, h1 = 0.1, h2 = double.Pi / 25;
        firstSumAndY = Answer(s1, y1, a1, b1, h1);
        secondSumAndY = Answer(s2, y2, a2, b2, h2);

        // end
    }

    delegate double y(double x);
    double y1(double x)
    {
        double y = Math.Exp(Math.Cos(x)) * Math.Cos(Math.Sin(x));
        return y;
    }
    double y2(double x)
    {
        double y = (x * x - double.Pi * double.Pi / 3) / 4;
        return y;
    }
    delegate double s(double x);
    double s1(double x)
    {
        double s0 = 1;
        double p = Math.Cos(x);
        for (int i = 2; Math.Abs(p) > 0.0001; i++)
        {
            s0 += p;
            p = Math.Cos(x * i) / Factorial(i);
        }
        return s0;
    }
    double s2(double x)
    {
        double s0 = 0;
        int z = -1;
        double p = z* Math.Cos(x);
        for (int i = 2; Math.Abs(p) > 0.0001; i++)
        {
            
            s0 += p;

            z = -z;
            p = z * Math.Cos(x * i) / (i * i);
        }
        return s0;
    }
    
    double[,] Answer(s s0, y y0, double a, double b, double h)
    {
        int i = 0;
        double[,] answer = new double[(int)((b - a) / h + 1), 2];
        for (double x = a; Math.Round(x, 2) <= b; x += h)
        {
            double s = s0(x);
            double y = y0(x);
            answer[i, 0] = s;
            answer[i, 1] = y;
            i++;
        }
        return answer;
    }
    public void Task_3_2(int[,] matrix)
    {
            // SortRowStyle sortStyle = default(SortRowStyle); - uncomment me

              // code here
            
            // create and use public delegate SumFunction(x) and public delegate YFunction(x)
            // create and use method GetSumAndY(sFunction, yFunction, a, b, h);
            // create and use 2 methods for both functions calculating at specific x

            // end
        }
        
        // create and use public delegate SortRowStyle(matrix, rowIndex);
        // create and use methods SortAscending(matrix, rowIndex) and SortDescending(matrix, rowIndex)
        // change method in variable sortStyle in the loop here and use it for row sorting

        // end
    

    public double Task_3_3(double[] array)
    {
        double answer = 0;
        SwapDirection swapper = default(SwapDirection);
        if (array[0]<srzn(array))
        {
            swapper=SwapRigth;
        }
        else
        {
            swapper=SwapLeft;
        }
        // code here
        array = swapper(array);
        answer = GetSum(array);
        // create and use public delegate SwapDirection(array);
        // create and use methods SwapRight(array) and SwapLeft(array)
        // create and use method GetSum(array, start, h) that sum elements with a negative indexes
        // change method in variable swapper in the if/else and than use swapper(matrix)

        // end

        return answer;
    }
    double GetSum(double[]A)
    {
        double s = 0;
        for (int i=1; i<A.Length; i+=2)
        {
            s+= A[i];
        }
        return s;
    }
    delegate double[] SwapDirection(double[] A);
    double[] SwapLeft(double[]A)
    {
        for (int i = 0; i < A.Length-1; i+=2) 
        {
            (A[i], A[i+1])= (A[i+1], A[i]);
        }
        return A;
    }
    double[] SwapRigth(double[]A)
    {
        for (int i=A.Length-1; i>0; i-=2)
        {
            (A[i], A[i-1]) = (A[i-1], (A[i]));
        }
        return A;
    }
    
    double srzn(double[]A)
    {
        double s = 0;
        int k=A.Length;
        for (int i=0; i<A.Length; i++)
        {
            
                s += A[i];
            
        }
        if (k == 0) return 0;
        else
        return s/k;

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

    public void Task_3_5(out int func1, out int func2)
    {
        double a1 = 0, b1 = 2, h1 = 0.1, a2 = -1, b2 = 1, h2 = 0.2;

        func1 = CountSignFlips(y3, a1, b1, h1);
        func2 = CountSignFlips(y4, a2, b2, h2);
        
        // code here

        // use public delegate YFunction(x, a, b, h) from Task_3_1
        // create and use method CountSignFlips(YFunction, a, b, h);
        // create and use 2 methods for both functions

        // end
    }
    int CountSignFlips(y y01, double a, double b, double h)
    {
        int k = 0;
        double y0 = y01(a);
        for (double x=a+h; x<=b; x+=h)
        {
            double y = y01(x);
            if (y* y0<0 || y==0)
            {
                k++;

            }
            y0 = y;
        }
        return k;
    }
    double y3(double x)
    {
        double y = x * x - Math.Sin(x);
        return y;
    }
    double y4(double x)
    {
        double y = Math.Exp(x) - 1;
        return y;
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

    public void Task_3_7(ref int[,] B, int[,] C)
    {
        // code here
        int m = 0;
        int ind = 0;
        CountPositive s = CountRowPositive;
        for (int i = 0; i<B.GetLength(0); i++)
        {
             if (s(B, i)>m)
            {
                m= s(B, i);
                ind= i;
            }
        }
        int n = 0;
        int indj = 0;
        CountPositive s1 = CountColumnPositive;
        for (int j=0; j<C.GetLength(1); j++)
        {
            if (s1(C,j)>n)
            {
                n = s1(C, j);
                indj= j;
            }
        }
        B = InsertColumn(B, C, ind, indj);
        // create and use public delegate CountPositive(matrix, index);
        // use CountRowPositive(matrix, rowIndex) from Task_2_7
        // use CountColumnPositive(matrix, colIndex) from Task_2_7
        // create and use method InsertColumn(matrixB, CountRow, matrixC, CountColumn);

        // end
    }
     delegate int CountPositive(int[,] A, int index);
    
    int[,] InsertColumn(int[,]A, int[,]B, int iind, int jind)
    {
        int[,] C = new int[A.GetLength(0) + 1, A.GetLength(1)];
        for (int i=0; i<A.GetLength(0); i++)
        {
            for (int j=0; j<A.GetLength(1); j++)
            {
                if (i<=iind)
                {
                    C[i,j]= A[i,j];
                }
                else
                {
                    C[i+1, j] = A[i,j];
                }
            }
        }
        for (int j=0; j<C.GetLength(1); j++)
        {
            C[iind+1, j] = B[j, jind];
        }
        return C;
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
        FindElementDelegate ma = FindMaxIndex;
        FindElementDelegate mi = FindMinIndex;
        ma(matrix, out int ima, out int jma);
        mi(matrix, out int imi, out int jmi);
        if (ima < imi)
        {
            matrix = RemoveRow(matrix, ima);
            matrix = RemoveRow(matrix, imi - 1);
        }
        else if (imi<ima)
        {
            matrix = RemoveRow(matrix, imi);
            matrix = RemoveRow(matrix, ima - 1);
        }
        else
        {
            matrix = RemoveRow(matrix, imi);
        }
        // end
    }
    delegate void FindElementDelegate(int[,] A, out int i, out int j);
    
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
        
        EvenOddRowsTransform(A, ReplaceMaxElementOdd, ReplaceMaxElementEven);
        EvenOddRowsTransform(B, ReplaceMaxElementOdd, ReplaceMaxElementEven);



        // end
    }
    public delegate void ReplaceMaxElement(int[,] A, int rowIndex, int max);
    void EvenOddRowsTransform(int[,]A, ReplaceMaxElement ReplaceMaxElementOdd, ReplaceMaxElement replaceMaxElementEven)
    {
        for (int i = 0; i < A.GetLength(0); i++)
        {
            int j = FindRowMaxIndex(A, i, out int j0);
            if (i % 2 == 0) ReplaceMaxElementOdd(A, i, j);
            else ReplaceMaxElementEven(A, i, j);
        }
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
        MatrixConverter[] mc = new MatrixConverter[4] {ToLowerTriangular, ToUpperTriangular, ToLeftDiagonal, ToRightDiagonal };
        

        mc[index](matrix);
        // code here

        // create public delegate MatrixConverter(matrix);
        // create and use method ToUpperTriangular(matrix);
        // create and use method ToLowerTriangular(matrix);
        // create and use method ToLeftDiagonal(matrix); - start from the left top angle
        // create and use method ToRightDiagonal(matrix); - start from the right bottom angle

        // end

        return matrix;
    }
    public delegate void MatrixConverter(double[,] A);
    void ToLowerTriangular(double[,]matrix)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            for (int k = j + 1; k < matrix.GetLength(0); k++)
            {
                double p = matrix[k, j] / matrix[j, j];
                for (int m = j; m < matrix.GetLength(1); m++)
                {
                    matrix[k, m] = matrix[k, m] - matrix[j, m] * p;
                }
            }
        }
    }

    void ToUpperTriangular(double[,] matrix)
    {
        for (int j = matrix.GetLength(0)-1; j >=0; j--)
        {
            for (int k = j - 1; k >=0; k--)
            {
                double p = matrix[k, j] / matrix[j, j];
                for (int m = j; m >=0; m++)
                {
                    matrix[k, m] = matrix[k, m] - matrix[j, m] * p;
                }
            }
        }
    }

    void ToLeftDiagonal(double[,]matrix)
    {
        ToLowerTriangular(matrix);
        ToUpperTriangular(matrix);
    }

    void ToRightDiagonal(double[,]matrix)
    {
        ToUpperTriangular(matrix);
        ToLowerTriangular(matrix);
    }
    #endregion
}
