using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Numerics;
using System.Reflection;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class Program
{
    public static void Main()
    {
        Program program = new Program();

        int[] a = new int[] { 1, 8,-3,5,5,1,0,4 };
        int[] b = new int[] { 1, -3,-5,5,-4,1,0,-1,-8,2,81,55,33,78,14,13,36,0 };
        int[,] ar = new int[,] { {1,2,3,4,5,-1 }, {6,7,8,9,10,-2}, {11,12,13,14,15,-3}, {-1,-2,-3,-4,-5,-1 }, { 6, 7, 8, 9,20,-2 }, { 1, 3, 3, 1, 5, 5 } };
        int[,] br = new int[,] { { 1,2,3,4 }, { 5,-5,5,-5 }, { 6,7,8,9 }, { -6,-5,-8,0} };
        int[] bu = new int[br.GetLength(0)];
        int[] anu = new int[br.GetLength(1)];
        program.Task_2_22(br, out bu, out anu);

    }
    #region Level 1
    public long Task_1_1(int n, int k)
    {
        long answer = Combinations(n, k);
        
        return answer;
    }
    public long Factorial(int n)
    {

        long fact = 1;
        for (int i = 2; i <= n; i++)
            fact *= i;
        return fact;

    }
    public long Combinations(int n, int k)
    {
        long answer = 0;
        if (k == 0 || k > 0 && k == n) answer = 1;
        else if (k > 0 && k < n)
            answer = Factorial(n) / (Factorial(k) * Factorial(n - k));
        else answer = 0;
        return answer;
    }
    public int Task_1_2(double[] first, double[] second)
    {///??????????????
        int answer = 0;
       
        if (first.Length != 3 || second.Length != 3)
        {
            answer = -1;
            return answer;
        }
        else
        {
            if (first[0] >= first[1] + first[2] || first[1] >= first[0] + first[2] || first[2] >= first[1] + first[0] || second[0] >= second[1] + second[2] || second[1] >= second[0] + second[2] || second[2] >= second[1] + second[0])
                answer =-1;
            else
            {
                if (GeronArea(first[0], first[1], first[2]) < GeronArea(second[0], second[1], second[2]))
                    answer = 2;
                else if (GeronArea(first[0], first[1], first[2]) == GeronArea(second[0], second[1], second[2]))
                    answer = 0;
                else if (GeronArea(first[0], first[1], first[2]) > GeronArea(second[0], second[1], second[2]))
                    answer = 1;
                // first = 1, second = 2, equal = 0, error = -1
                Console.WriteLine(answer);
                
            }
            return answer;
        }
    }
    public double GeronArea(double a, double b, double c)
    {
        double p = (a + b + c) / 2;
        double s = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        return s;
    }
    public int Task_1_3a(double v1, double a1, double v2, double a2, int time)
    {
        int answer = 0;

        double first = GetDistance(v1, a1, time);
        double second = GetDistance(v2, a2, time);
        // code here
        if (first > second)
            answer = 1;
        else if (first == second)
            answer = 0;
        else if (second > first)
            answer = 2;
        // create and use GetDistance(v, a, t); t - hours

        // end

        // first = 1, second = 2, equal = 0
        return answer;
    }
    public double GetDistance(double v, double a, int t)
    {
        double s = v * t + a * t * t / 2;
        return s;
    }
    public int Task_1_3b(double v1, double a1, double v2, double a2)
    {

        int time = 0;
      
        for (int t = 1; ; t++)
        {
          
            if (GetDistance(v1, a1, t) <= GetDistance(v2, a2, t)) return t;
        }
        // use GetDistance(v, a, t); t - hours
        return time;
        // end

        
        
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

      
            double[] C;
           
            int finalmax;
            int maxa = FindMaxIndex(A);
            int maxb = FindMaxIndex(B);
            
            
            if (A.Length - maxa > B.Length - maxb)
            {
                C = A;

                finalmax = maxa;

            }
            else
            {
                C = B;
                finalmax = maxb;


            }
            double ave = 0;
            double cnt = 0;
            
            for (int i = finalmax + 1; i < C.Length; i++)
            {
                ave += C[i];
                cnt++;
            }
            ave /= cnt;
            for (int i = 0; i < C.Length; i++)
            {
                if (C[i] == C[finalmax])
                    C[i] = ave;
            }

        




        // create and use FindMaxIndex(array);
        // only 1 array has to be changed!

        // end
    }
    int FindMaxIndex(double[] array)
    {
        //double max = double.MinValue;
        int maxInd=0;
        for(int i =0; i<array.Length; i++)
        {
            if (array[i] > array[maxInd])
            {
                //max = array[i];
                maxInd = i;
            }
        }
        return maxInd;
    }
    public void Task_2_3(ref int[,] B, ref int[,] C)
    {
        // code here

        //  create and use method FindDiagonalMaxIndex(matrix);

        // end
    }
    
    public (int[,], int[,]) Task_2_4(int[,] A, int[,] B)
    {
        // code here
        if (A.GetLength(0) != A.GetLength(1) || B.GetLength(0) != B.GetLength(1) || A.GetLength(0)!=B.GetLength(0))
            return (null, null);
        else
        {
            int ini = FindDiagonalMaxIndex(A);
            int jnj = FindDiagonalMaxIndex(B);
            for (int i = 0; i < A.GetLength(0); i++)
            {
                
                    int temp = A[ini, i];
                    A[ini, i] = B[i, jnj];
                    B[i, jnj] = temp;
                
            }
            //  create and use method FindDiagonalMaxIndex(matrix); like in Task_2_3
            return (A, B);
        }
        // end
    }
    int FindDiagonalMaxIndex(int[,] matrix)
    {
        int maxi = 0;
        for (int i = 0; i<matrix.GetLength(0); i++)
        {
            
            
                if ( matrix[i, i] > matrix[maxi, maxi])
                {
                    maxi = i;
                   
                }
            
        }
        return (maxi);
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

        
        int maxia = FindMax(A);
        int maxib = FindMax(B);
        int[] newa = DeleteElement(A, maxia);
        int[] newb = DeleteElement(B, maxib);

        int[] C = new int[newa.Length + newb.Length];
        int index = 0;
        foreach (int x in newa) C[index++] = x;
        foreach (int x in newb) C[index++] = x;
        A = C;
        //foreach (int el in C) Console.WriteLine(el);
            // create and use FindMax(matrix, out row, out column); like in Task_2_1
            // create and use DeleteElement(array, index);

        
        // end
    }
    int FindMax(int[] mass)
    {
        
        int max = 0;
        for (int i = 0; i<mass.Length; i++)
        {
            if (mass[i] > mass[max])    
                max = i;
            
        }
        return max;
    }
    int[] DeleteElement(int[] array, int index)
    {
        int []newarr = new int[array.Length - 1];
        for (int i = 0; i < index; i++)
            newarr[i] = array[i];
        for (int i = index; i < newarr.Length; i++)
            newarr[i] = array[i + 1];
        return newarr;
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
        int amax = FindMax(A);
        A = SortArrayPart(A, amax);
        int bmax = FindMax(B);
        B = SortArrayPart(B, bmax);
        // create and use SortArrayPart(array, startIndex);
       
        // end
    }
    int[] SortArrayPart(int[] array, int startIndex)
    {
        for(int i = startIndex+2, j = startIndex+3; i < array.Length;)
        {
            if(i==startIndex+1 || array[i] >= array[i-1])
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
    public int[] Task_2_9(int[,] A, int[,] C)
    {
        int[] answer = default(int[]);

        // code here

        // create and use SumPositiveElementsInColumns(matrix);

        // end

        return answer;
    }
    public static void PrintMatrix(int[,] mat)
    {
        for(int i = 0; i<mat.GetLength(0); i++)
        {
            for(int j = 0; j<mat.GetLength(1); j++)
            {
                Console.Write(mat[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
    public void Task_2_10(ref int[,] matrix)
    {
        // code here
        int max = 0;
        int maxE = int.MinValue;
        int minE = int.MaxValue;
        int min = 0;
        PrintMatrix(matrix);
        Console.WriteLine();
        Console.WriteLine(FindMaxColumnIndex(matrix));
        // create and use RemoveColumn(matrix, columnIndex);
        for(int i = 0; i<matrix.GetLength(0); i++)
        {
            for (int j = 0; j<matrix.GetLength(1); j++)
            {
                if (j <= i && matrix[i, j] > maxE)
                {
                    maxE = matrix[i, j];
                    max = j;
                }
                if (j > i && matrix[i, j] < minE)
                {
                    minE = matrix[i, j];
                    min = j;
                }
            }
        }
        Console.WriteLine(max + " " + min);
        matrix = RemoveColumn(matrix, max);
        if(max!=min)
            matrix = RemoveColumn(matrix, min);
        PrintMatrix(matrix);
        // end
    }
    int[,] RemoveColumn(int[,] matrix, int columnIndex)
    {
        int[,] newmat = new int[matrix.GetLength(0),matrix.GetLength(1)-1]; 
        for(int i = 0; i<newmat.GetLength(0); i++)
        {
            for(int j = 0; j<newmat.GetLength(1); j++)
            {
                if (j < columnIndex)
                    newmat[i, j] = matrix[i, j];
                else
                    newmat[i, j] = matrix[i, j + 1];
            }
        }


        return newmat;
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

        // create and use FindMaxColumnIndex(matrix);
        int cola = FindMaxColumnIndex(A);
        int colb = FindMaxColumnIndex(B);
        for(int i = 0; i<A.GetLength(0); i++)
        {
            int temp = A[i, cola];
            A[i, cola] = B[i, colb];
            B[i, colb] = temp;
        }
        // end
    }
    int FindMaxColumnIndex(int[,] matrix)
    {
        int max = int.MinValue;
        int maxInd=0;
        for(int j = 0; j < matrix.GetLength(0); j++)
        {
            for(int i = 0; i<matrix.GetLength(1); i++)
            {
                if (matrix[j, i] > max)
                {
                    max = matrix[j, i];
                    maxInd = i;
                }
            }
        }


        return maxInd;
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

        // create and use SortRow(matrix, rowIndex);
        for(int i = 0; i<matrix.GetLength(0); i++)
        {
            matrix = SortRow(matrix, i);
        }
        // end
    }
    int[,] SortRow(int[,] mat, int rowIndex)
    {
        for(int i = 1; i<mat.GetLength(1); )
        {
            if (i == 0 || mat[rowIndex, i] >= mat[rowIndex, i - 1])
                i++;
            else
            {
                int temp = mat[rowIndex, i];
                mat[rowIndex, i] = mat[rowIndex, i - 1];
                mat[rowIndex, i - 1] = temp;
                i--;
            }
        }

        return mat;
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

        // create and use SortNegative(array);
        A = SortNegative(A);
        B = SortNegative(B);
        foreach (int x in A) Console.Write(x+" ");
        Console.WriteLine();
        foreach (int x in B) Console.Write(x + " ");
        // end
    }
    public static int[] SortNegative(int[] array)
    {
        for (int k = 0; k < array.Length; k++)
        {
            if (array[k] <0)
            {
                int i = k, j = k - 1;
                while (j >= 0)
                {
                    if (array[j]  < 0 && array[j] < array[i])
                    {
                        var temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                        i = j;
                    }
                    j--;
                }
            }
        }


        return array;
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

        // create and use SortDiagonal(matrix);
        A = SortDiagonal(A);
        B = SortDiagonal(B);
        // end
    }
    public static int[,] SortDiagonal(int[,] matri)
    {
        for(int i = 1; i<matri.GetLength(0);)
        {
            if (i == 0 || matri[i, i] > matri[i - 1, i - 1])
                i++;
            else
            {
                int temp = matri[i, i];
                matri[i, i] = matri[i - 1, i - 1];
                matri[i - 1, i - 1] = temp;
                i--;
            }
        }


        return matri;
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
        PrintMatrix(A);
        Console.WriteLine();
        PrintMatrix(B);
        Console.WriteLine();
        // use RemoveColumn(matrix, columnIndex); from 2_10
        for (int i = 0; i<A.GetLength(1); i++)
        {
            int cnt = 0;
            for(int j = 0; j<A.GetLength(0); j++)
            {
                if (A[j, i] == 0)
                {
                    cnt++;
                    break;
                }
            }
            if (cnt == 0)
            {
                A = RemoveColumn(A, i);
                i--;
            }
        }
        for (int i = 0; i < B.GetLength(1); i++)
        {
            int cnt = 0;
            for (int j = 0; j < B.GetLength(0); j++)
            {
                if (B[j,i] == 0)
                {
                    cnt++;
                    break;
                }
            }
            if (cnt == 0)
            {
                B = RemoveColumn(B, i);
                i--;
            }
        }
        // end
        PrintMatrix(A);
        Console.WriteLine();
        PrintMatrix(B);
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
        cols = FindMaxNegativePerColumn(matrix);
        for(int i = 0; i<matrix.GetLength(0); i++)
        {
            rows[i] = CountNegativeInRow(matrix, i);
        }
        // code here
        PrintMatrix(matrix);
        Console.WriteLine();
        foreach (int d in rows) Console.Write(d + " ");
        Console.WriteLine();
        foreach (int d in cols) Console.Write(d + " ");
        Console.WriteLine();
        // create and use CountNegativeInRow(matrix, rowIndex);
        // create and use FindMaxNegativePerColumn(matrix);

        // end
    }
    int CountNegativeInRow(int[,]matrix, int rowIndex)
    {
        int cnt = 0;
        for(int i = 0; i<matrix.GetLength(1); i++)
        {
            if (matrix[rowIndex, i] < 0)
                cnt++;
        }

        return cnt;
    }
    int[] FindMaxNegativePerColumn(int[,] matrix)
    {
        
        int[] ar = new int[matrix.GetLength(1)];
        for(int i = 0; i<matrix.GetLength(1); i++)
        {
            int max = int.MinValue;
            for (int j = 0; j<matrix.GetLength(0); j++)
            {
                if (matrix[j, i] < 0 && matrix[j, i] > max)
                    max = matrix[j,i];
            }
            ar[i] = max;
        }

        return ar;
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
        int maxA = FindMaxColumnIndex(A);
        A = SwapColumnDiagonal(A, maxA);
        int maxB = FindMaxColumnIndex(B);
        B = SwapColumnDiagonal(B, maxB);
        // use FindMaxIndex(matrix, out row, out column); like in 2_1
        // create and use SwapColumnDiagonal(matrix, columnIndex);

        // end
    }
    
    int[,] SwapColumnDiagonal(int[,]matrix, int columnIndex)
    {
        for(int i = 0; i<matrix.GetLength(0); i++)
        {
            
            int temp = matrix[i, i];
            matrix[i, i] = matrix[i, columnIndex];
            matrix[i, columnIndex] = temp;
            
        }

        return matrix;
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
        int maxa = FindRowWithMaxNegativeCount(A);
        int maxb = FindRowWithMaxNegativeCount(B);
        for (int i = 0; i<A.GetLength(1); i++)
        {
            int temp = A[maxa, i];
            A[maxa, i] = B[maxb, i];
            B[maxb, i] = temp;
        }
        // create and use FindRowWithMaxNegativeCount(matrix); like in 2_25
        // in FindRowWithMaxNegativeCount use CountNegativeInRow(matrix, rowIndex); from 2_22

        // end
    }
    int FindRowWithMaxNegativeCount(int[,] matrix)
    {
        int max = 0, maxNegCount = -1;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            int negCount = CountNegativeInRow(matrix, i);
            if (negCount > maxNegCount)
            {
                maxNegCount = negCount;
                max = i;
            }
        }
        return max;
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
    int FindSequence(int[]array, int A, int B)
    {

        if (A >= B) return 0;
        bool inc = array[A] < array[A + 1];
        for (int i = A; i < B; i++)
        {
            if (inc && array[i] > array[i + 1]) return 0;
            if (!inc && array[i] < array[i + 1]) return 0;
        }
        return inc ? 1 : -1;
    }
    public void Task_2_28b(int[] first, int[] second, ref int[,] answerFirst, ref int[,] answerSecond)
    {
        // code here
        int cnt = 0;
        for (int i = 0; i < first.Length; i++)
        {
            for (int j = i + 1; j < first.Length; j++)
            {
                int seq = FindSequence(first, i, j);
                if (seq != 0) cnt++;
            }
        }
        answerFirst = new int[cnt, 2];
        cnt = 0;
        for (int i = 0; i < first.Length; i++)
        {
            for (int j = i + 1; j < first.Length; j++)
            {
                int seq = FindSequence(first, i, j);
                if (seq != 0)
                {
                    answerFirst[cnt, 0] = i;
                    answerFirst[cnt, 1] = j;
                    cnt++;
                }
            }
        }

        cnt = 0;
        for (int i = 0; i < second.Length; i++)
        {
            for (int j = i + 1; j < second.Length; j++)
            {
                int seq = FindSequence(second, i, j);
                if (seq != 0) cnt++;
            }
        }
        answerSecond = new int[cnt, 2];
        cnt = 0;
        for (int i = 0; i < second.Length; i++)
        {
            for (int j = i + 1; j < second.Length; j++)
            {
                int seq = FindSequence(second, i, j);
                if (seq != 0)
                {
                    answerSecond[cnt, 0] = i;
                    answerSecond[cnt, 1] = j;
                    cnt++;
                }
            }
        }
        // use FindSequence(array, A, B); from Task_2_28a or entirely Task_2_28a
        // A and B - start and end indexes of elements from array for search

        // end
    }
   
    
    public void Task_2_28c(int[] first, int[] second, ref int[] answerFirst, ref int[] answerSecond)
    {
        // code here
        int a = 0, b = 0;
        for (int i = 0; i < first.Length; i++)
        {
            for (int j = i + 1; j < first.Length; j++)
            {
                int seq = FindSequence(first, i, j);
                if (seq != 0 && b - a < j - i)
                {
                    a = i;
                    b = j;
                }
            }
        }
        answerFirst = new int[] { a, b };

        a = 0; b = 0;
        for (int i = 0; i < second.Length; i++)
        {
            for (int j = i + 1; j < second.Length; j++)
            {
                int seq = FindSequence(second, i, j);
                if (seq != 0 && b - a < j - i)
                {
                    a = i;
                    b = j;
                }
            }
        }
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

    public void Task_3_2(int[,] matrix)
    {
        SortRowStyle sortStyle = default(SortRowStyle);

        // code here
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            if (i % 2 == 0) sortStyle = SortAscending;
            else sortStyle = SortDescending;
            sortStyle(matrix, i);
        }
        // create and use public delegate SortRowStyle(matrix, rowIndex);
        // create and use methods SortAscending(matrix, rowIndex) and SortDescending(matrix, rowIndex)
        // change method in variable sortStyle in the loop here and use it for row sorting

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
        GetTriangle getTriangle = default(GetTriangle);
        // code here

        // create and use public delegate GetTriangle(matrix);
        // create and use methods GetUpperTriange(array) and GetLowerTriange(array)
        // create and use GetSum(GetTriangle, matrix)
        if (isUpperTriangle)
            answer = GetSum(GetUpperTriangle, matrix);
        else
            answer = GetSum(GetLowerTriangle, matrix);
        // end

        return answer;
    }

    public delegate int[] GetTriangle(int[,] matrix);
    int[] GetUpperTriangle(int[,] matrix)
    {
        int[] ans = new int[matrix.GetLength(0) * (matrix.GetLength(0) + 1) / 2];
        int index = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(0); j++)
            {
                if(j>=i)
                    ans[index++] = matrix[i, j];
            }
        }
        return ans;
    }
    int[] GetLowerTriangle(int[,] matrix)
    {
        int[] ans = new int[matrix.GetLength(0) * (matrix.GetLength(0) + 1) / 2];
        int index = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j <matrix.GetLength(0); j++)
            {
                if(j<=i)
                    ans[index++] = matrix[i, j];
            }
        }
        return ans;
    }

    int GetSum(GetTriangle getTriangle, int[,] matrix)
    {
        int[] arr = getTriangle(matrix);
        int ans = 0;
        foreach (int elem in arr)
            ans += elem * elem;
        return ans;
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
    public delegate int FindElementDelegate(int[,] matrix);
    int FindFirstRowMaxIndex(int[,] matrix)
    {
        int max = 0;
        for (int i = 0; i < matrix.GetLength(1); i++)
        {
            if (matrix[0, i] > matrix[0, max])
                max = i;
        }
        return max;
    }
    void SwapColumns(int[,] matrix, FindElementDelegate findDiagonalMaxIndex, FindElementDelegate findFirstRowMaxIndex)
    {
        int diagonalmax = findDiagonalMaxIndex(matrix);
        int firstmax = findFirstRowMaxIndex(matrix);
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            int temp = matrix[i, diagonalmax];
            matrix[i, diagonalmax] = matrix[i, firstmax];
            matrix[i, firstmax] = temp;
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
