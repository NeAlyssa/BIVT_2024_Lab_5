using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.Design;
using System.Numerics;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class Program
{
    public static void Main()
    {
        Program program = new Program();
        int[,] B = new int[4, 5] {
            { 1, 2, 3, 4, 5 },
            { 6, 7, 8, 9, 10 },
            { -1, -2, -3, -4, -5 },
            { 6, 7, 8, 9, 0 }};
        int[,] C = new int[5, 6] {
            { 1, 2, 3, 4, 5, -1 },
            { 6, 7, 8, 9, 10, -2 },
            { 11, 12, 13, 14, 15, -3 },
            { -1, -2, -3, -4, -5, -1 },
            { 1, 3, 3, 1, 5, 5 }};
        //program Task_2_3(ref int[,] B, ref int[,] C);
    }
    public int Factorial(int n)
    {
        if (n == 0) return 1;
        else return n * Factorial(n - 1);
    }
    public double GeronArea(double a, double b, double c)
    {
        if ((a + b <= c) || (a + c <= b) || (b + c <= a)) return 0;
        double p = (a + b + c) / 2;
        return Math.Sqrt(p*(p-a)*(p-b)*(p-c));
    }
    public double GetDistance(double v, double a, double t)
    {
        return (v*t+a*t*t/2);
    }
    public int FindMax(int[,] matrix)
    {
        int max = int.MinValue;
        for (int i = 0; i < matrix.GetLength(0); i++)
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i,j]>max)
                    max = matrix[i,j];
            }
        return max;
    }
    public double FindMax(double[,] matrix)
    {
        double max = int.MinValue;
        for (int i = 0; i < matrix.GetLength(0); i++)
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] > max)
                    max = matrix[i, j];
            }
        return max;
    }

    public int FindMin(int[,] matrix)
    {
        int min = int.MaxValue;
        for (int i = 0; i < matrix.GetLength(0); i++)
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] < min)
                    min = matrix[i, j];
            }
        return min;
    }
    public int FindDiagonalMax(int[,] matrix)
    {
        int max = int.MinValue;
        for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, i] > max)
                    max = matrix[i, i];
            }
        return max;
    }
    public int FindColumnMax(int[,] matrix, int columnIndex)
    {
        int index = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            if (matrix[i, columnIndex] > matrix[index, columnIndex])
                index = i;
        }
        return index;
    }
    public int CountRowPositive(int[,] matrix, int rowIndex)
    {
        int count = 0;
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (matrix[rowIndex, j] > 0)
                count += 1;
        }
        return count;
    }

    public int CountColumnPositive(int[,] matrix, int rowIndex)
    {
        int count = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            if (matrix[i, rowIndex] > 0)
                count += 1;
        }
        return count;
    }
    public void PrintMatrix(int[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
                Console.Write(matrix[i, j]+ " ");
            Console.WriteLine();
        }
    }
    public void PrintMatrix(double[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
                Console.Write(matrix[i, j] + " ");
            Console.WriteLine();
        }
    }
    public void PrintDoubleMatrix(double[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
                Console.Write(matrix[i, j] + " ");
            Console.WriteLine();
        }
    }
    public int[] SumPositiveElementsInColumns(int[,] matrix)
    {
        int[] A = new int[matrix.GetLength(1)];
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
                if (matrix[i, j] > 0)
                    A[j] += matrix[i, j];
        }
        return A;
    }

    public int[,] RemoveRow(int[,] matrix, int rowIndex)
    {
        int[,] A = new int[matrix.GetLength(0) - 1, matrix.GetLength(1)];
        for (int i = 0, k=0; i < matrix.GetLength(0); i++)
        {
            if (i != rowIndex)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                        A[k, j] = matrix[i, j];
                }
                k += 1;
            }
        }
        return A;
    }

    public double GetAverageWithoutMinMax(int[,] matrix)
    {
        double sum = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
                sum += matrix[i, j];
        }
        return (sum-FindMax(matrix)-FindMin(matrix)) / ((matrix.GetLength(0) * matrix.GetLength(1))-2);
    }

    public int[,] RearrangingRow(int[,] matrix, int i1, int i2)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        { 
            int p = matrix[i1, j];
            matrix[i1, j] = matrix[i2, j];
            matrix[i2, j] = p;
        }
        return matrix;
    }

    public int[,] SortRowsByMaxElement(int[,] matrix)
    {
        for (int k = 0; k < matrix.GetLength(0); k++)
        {
            for (int i = 0; i < matrix.GetLength(0)-1; i++)
            {
                int max1 = int.MinValue;
                for (int j = 0; j < matrix.GetLength(1); j++)
                { 
                    if (matrix[i, j] > max1)
                        max1 = matrix[i, j];
                }

                int max2 = int.MinValue;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i+1, j] > max2)
                        max2 = matrix[i+1, j];
                }
                if (max1 < max2) RearrangingRow(matrix, i, i + 1);
            }
        }
        return matrix;
    }

    public int[] CreateArrayFromMins(int[,] matrix)
    {
        int[] A = new int[matrix.GetLength(0)];
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            int min = int.MaxValue;
            for (int j = i; j < matrix.GetLength(1); j++)
                if (matrix[i, j] < min)
                    min = matrix[i, j];
            A[i] = min;
        }
        return A;
    }

    public int[,] RearrangingColumnDiagonal(int[,] matrix, int j1)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        { 
            int p = matrix[i, j1];
            matrix[i, j1] = matrix[i, i];
            matrix[i, i] = p;
        }
        return matrix;
    }

    public double[,] MatrixValuesChange(double[,] matrix)
    {
        PrintMatrix(matrix);

        double[] array = new double[matrix.GetLength(0)*matrix.GetLength(1)];
        int ind = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                array[ind] = matrix[i, j];
                ind += 1;
            }
        Console.WriteLine(array.Length);
        for(int i=0;i<array.Length;i++)
            Console.Write(array[i]+" ");
        Console.WriteLine();

        for (int k = 0; k < array.Length; k++)
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] < array[i + 1])
                { 
                    double p = array[i];
                    array[i] = array[i + 1];
                    array[i + 1] = p;
                }
            }

        for (int i = 0; i < array.Length; i++)
            Console.Write(array[i] + " ");
        Console.WriteLine();


        for (int i = 0; i < matrix.GetLength(0); i++)
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                bool flag = false;
                for(int k=0;k<5&&k<array.Length;k++)
                    if (matrix[i, j] == array[k])
                        flag = true;
                if (flag==true)
                    if (matrix[i, j] < 0)
                        matrix[i, j] = matrix[i, j] / 2;
                    else
                        matrix[i, j] = matrix[i, j] * 2;
                else if(flag==false)
                    if (matrix[i, j] < 0)
                    matrix[i, j] = matrix[i, j] * 2;
                else
                    matrix[i, j] = matrix[i, j] / 2;
            }
        return matrix;
    }

    public int FindMaxNegativeRow(int[,] matrix)
    {
        int max = int.MinValue;
        int ind = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        { 
            int count = 0;
            for (int j = 0; j < matrix.GetLength(1); j++)
                if (matrix[i, j] < 0)
                    count += 1;
            if (count > max)
            { 
                max = count;
                ind = i;
            }
        }
        return ind;
    }

    public int FindRowMaxIndex(int[,] matrix, int ind)
    {
        int maxind = 0;
        for (int j = 0; j < matrix.GetLength(1); j++)
            if (matrix[ind, j] > matrix[ind, maxind])
            { 
                maxind=j;
            }
        return maxind;
    }

    public void F27(int[,] A)
    {
        for (int i = 0; i < A.GetLength(0); i++)
        {
            if ((i+1) % 2 == 0)
                A[i, FindRowMaxIndex(A, i)] = 0;
            else
                A[i, FindRowMaxIndex(A, i)] = A[i, FindRowMaxIndex(A, i)] * (FindRowMaxIndex(A, i)+1);
        }
    }
    public double fk(int i)
    {
        if (i == 0)
            return 1;
        else
            return i*fk(i-1);
    }
    /*public double f1(int i, double x)
    {
        return Math.Cos(i * x) / (fk(i));
    }
    public double f2(int i, double x)
    {
        int mn = 1;
        if (i % 2 == 1) mn = -1;
        return mn*Math.Cos(i * x) / (i*i);
    }

    static double SumFunction(fi f, double a, double b, double h)
    {
        double sum = 0;
        double fk = 1;
        for (int i = 1; i < 100; i++)
        {
            sum += f(i);
        }
        return sum;

    }*/

    #region Level 1
    public long Task_1_1(int n, int k)
    {
        long answer = 0;
        answer = (Factorial(n)) / (Factorial(k) * Factorial(n - k));
        return answer;
    }
    public int Task_1_2(double[] first, double[] second)
    {
        int answer = 0;

        if (first[0]+first[1]<=first[2]||first[0]+first[2]<=first[1] || first[2] + first[1] <= first[0]||second[0]+second[1]<=second[2] || second[0] + second[2] <= second[1] || second[2] + second[1] <= second[0])
            answer = -1;
        else if (GeronArea(first[0], first[1], first[2]) > GeronArea(second[0], second[1], second[2]))
            answer = 1;
        else if (GeronArea(first[0], first[1], first[2]) < GeronArea(second[0], second[1], second[2]))
            answer = 2;
        else if (GeronArea(first[0], first[1], first[2]) == GeronArea(second[0], second[1], second[2]))
            answer = 0;

            // first = 1, second = 2, equal = 0, error = -1
        return answer;
    }
    public int Task_1_3a(double v1, double a1, double v2, double a2, int time)
    {
        int answer = 0;
        if (GetDistance(v1, a1, time) > GetDistance(v2, a2, time)) return 1;
        else if (GetDistance(v1, a1, time) < GetDistance(v2, a2, time)) return 2;
        else return 0;
        // first = 1, second = 2, equal = 0
        return answer;
    }
    public int Task_1_3b(double v1, double a1, double v2, double a2)
    {
        int answer = 0;

        // code here
        if (a1 == a2) return 1;
        for (int t = 1; t <= int.MaxValue; t++)
            if (GetDistance(v1, a1, t) <= GetDistance(v2, a2, t))
                return t;
        return answer;
    }
    #endregion
    #region Level 2
    public void Task_2_1(int[,] A, int[,] B)
    {
        int m1=FindMax(A), m2=FindMax(B);
        for (int i = 0; i < A.GetLength(0); i++)
            for (int j = 0; j < A.GetLength(1); j++)
            {
                if (A[i, j] == m1)
                    A[i, j] = m2;
            }
        for (int i = 0; i < B.GetLength(0); i++)
            for (int j = 0; j < B.GetLength(1); j++)
            {
                if (B[i, j] == m2)
                    B[i, j] = m1;
            }
    }
    public void Task_2_2(double[] A, double[] B)
    {
        // code here

        // create and use FindMax(array);

        // end
    }
    public void Task_2_3(ref int[,] B, ref int[,] C)
    {
        int[,] A = new int[B.GetLength(0)-1, B.GetLength(1)];
        int m = FindDiagonalMax(B);
        int flag = 0;
        for (int i = 0; i < B.GetLength(0); i++)
        {
            if (B[i, i] != m)
            {
                for (int j = 0; j < B.GetLength(1); j++)
                {
                    A[flag, j] = B[i, j];
                }
                flag++;
            }
        }
        B = A;

        int[,] A1 = new int[C.GetLength(0) - 1, C.GetLength(1)];
        int m1 = FindMax(C);
        flag = 0;
        for (int i = 0; i < C.GetLength(0); i++)
        {
            for (int j = 0; j < C.GetLength(1); j++)
            {
                if (C[i, i] == m1)
                {
                    flag = 1;
                    continue;
                }
                else A1[i - flag, j] = C[i, j];
            }
        }
        C = A1;
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
        if (A.GetLength(1) == B.GetLength(1))
        {
            int i1 = FindColumnMax(A, 0);
            int i2 = FindColumnMax(B, 0);
            for (int j = 0; j < A.GetLength(1); j++)
            {
                int p = A[i1, j];
                //p = p + 0;
                A[i1, j] = B[i2, j];
                B[i2, j] = p;
            }
        }
    }

    public void Task_2_6(ref int[] A, int[] B)
    {
        // code here

        // create and use DeleteElement(array, index);

        // end
    }

    public void Task_2_7(ref int[,] B, int[,] C)
    {
        //if(B.GetLength(0)!=4|| B.GetLength(1) != 5||C.GetLength(0) != 4)
        int maxb = 0;
        int maxc = 0;
        int indexb = -1;
        int indexc = -1;

        int[,] B1=new int[B.GetLength(0)+1, B.GetLength(1)];

        PrintMatrix(B);
        Console.WriteLine();
        PrintMatrix(C);
        Console.WriteLine();

        for (int i = 0; i < B.GetLength(0); i++)
        {
            if (CountRowPositive(B, i) > maxb)
            { 
                maxb = CountRowPositive(B, i);
                indexb = i;
            }
        }
        for (int j = 0; j < C.GetLength(1); j++)
        {
            if (CountColumnPositive(C, j) > maxc)
            {
                maxc = CountRowPositive(C, j);
                indexc = j;
            }
        }
        for (int i = 0; i < B1.GetLength(0); i++)
            for (int j = 0; j < B1.GetLength(1); j++)
            {
                if (i <= indexb)
                    B1[i, j] = B[i, j];
                else if (i >= indexb+1)
                    B1[i, j] = B[i - 1, j];
            }    

        for (int k = 0; k < B1.GetLength(1); k++)
        {
            B1[indexb+1, k] = C[k, indexc];
        }

        B = B1;
        PrintMatrix(B);
        Console.WriteLine();
        PrintMatrix(C);
    }

    public void Task_2_8(int[] A, int[] B)
    {
        // code here

        // create and use SortArrayPart(array, startIndex);

        // end
    }

    public int[] Task_2_9(int[,] A, int[,] C)
    {
        int[] answer = new int[A.GetLength(1)+C.GetLength(1)];
        int[] a1 = SumPositiveElementsInColumns(A);
        int[] a2 = SumPositiveElementsInColumns(C);
        for (int i = 0, k1 = 0, k2 = 0; i < answer.Length; i++)
        {
            if (k1 < A.GetLength(1))
            {
                answer[i] = a1[k1];
                k1 += 1;
            }
            else
            { 
                answer[i] = a2[k2];
                k2 += 1;
            }
        }
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
        int ma = FindMax(A);
        int mb = FindMax(B);
        for (int i = 0; i < A.GetLength(0); i++)
            for (int j = 0; j < A.GetLength(1); j++)
                if (A[i, j] == ma)
                    A[i, j] = mb;
        for (int i = 0; i < B.GetLength(0); i++)
            for (int j = 0; j < B.GetLength(1); j++)
                if (B[i, j] == mb)
                    B[i, j] = ma;
    }
    public void Task_2_12(int[,] A, int[,] B)
    {
        // code here

        // create and use FindMaxColumnIndex(matrix);

        // end
    }

    public void Task_2_13(ref int[,] matrix)
    {
        //RemoveRow
        int i1 = 0, j1 = 0, i2 = 0, j2 = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] > matrix[i1, j1])
                {
                    i1 = i;
                    j1 = j;
                }
                if (matrix[i, j] < matrix[i2, j2])
                {
                    i2 = i;
                    j2 = j;
                }
            }

        matrix = RemoveRow(matrix, i1);
        
        if (i1 != i2)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < matrix[i2, j2])
                    {
                        i2 = i;
                        j2 = j;
                    }
                }
            matrix = RemoveRow(matrix, i2);
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
        int answer = 0; // 1 - increasing   0 - no sequence   -1 - decreasing
        double[] ans = new double[3];
        ans[0]=GetAverageWithoutMinMax(A);
        ans[1]=GetAverageWithoutMinMax(B);
        ans[2]=GetAverageWithoutMinMax(C);
        if (ans[0] > ans[1] && ans[1] > ans[2])
            return -1;
        else if (ans[0] < ans[1] && ans[1] < ans[2])
                return 1;
        else return 0;
    }    

    public void Task_2_16(int[] A, int[] B)
    {
        // code here

        // create and use SortNegative(array);

        // end
    }

    public void Task_2_17(int[,] A, int[,] B)
    {
        Console.WriteLine();
        PrintMatrix(A);
        SortRowsByMaxElement(A);
        Console.WriteLine();
        PrintMatrix(A);
        SortRowsByMaxElement(B);
    }

    public void Task_2_18(int[,] A, int[,] B)
    {
        // code here

        // create and use SortDiagonal(matrix);

        // end
    }

    public void Task_2_19(ref int[,] matrix)
    {
        for (int k = 0; k < matrix.GetLength(0); k++)
            for (int i = 0; i < matrix.GetLength(0); i++)
            { 
                int flag = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                    if (matrix[i, j] == 0)
                    { 
                        flag = 1;
                        break;
                    }
                if (flag == 1)
                {
                    matrix=RemoveRow(matrix, i);
                    break;
                }
            }
    }
    public void Task_2_20(ref int[,] A, ref int[,] B)
    {
        // code here

        // use RemoveColumn(matrix, columnIndex); from 2_10

        // end
    }    

    public void Task_2_21(int[,] A, int[,] B, out int[] answerA, out int[] answerB)
    {
        answerA = CreateArrayFromMins(A);
        answerB = CreateArrayFromMins(B);
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
        PrintMatrix(A);
        //PrintDoubleMatrix(B);
        A = MatrixValuesChange(A);
        B = MatrixValuesChange(B);
        Console.WriteLine();
        //PrintDoubleMatrix(A);
        PrintDoubleMatrix(B);
    }

    public void Task_2_24(int[,] A, int[,] B)
    {
        int m1=FindMax(A), m2=FindMax(B), j1 = 0, j2 = 0;
        for (int i = 0; i < A.GetLength(0); i++)
            for (int j = 0; j < A.GetLength(1); j++)
                if (A[i, j] == m1) j1 = j;

        for (int i = 0; i < B.GetLength(0); i++)
            for (int j = 0; j < B.GetLength(1); j++)
                if (B[i, j] == m2) j2 = j;

        Console.WriteLine();
        PrintMatrix(A);
        A = RearrangingColumnDiagonal(A, j1);
        Console.WriteLine();
        PrintMatrix(A);
        B = RearrangingColumnDiagonal(B, j2);
    }

    public void Task_2_25(int[,] A, int[,] B, out int maxA, out int maxB)
    {
        maxA = 0;
        maxB = 0;
        PrintMatrix(A);
        Console.WriteLine();
        maxA = FindMaxNegativeRow(A);
        maxB = FindMaxNegativeRow(B);
        // code here

        // create and use FindMaxNegativeRow(int);
        // use GetNegativeCountPerRow(matrix); from 2_22

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
        PrintMatrix(A);
        Console.WriteLine();
        F27(A);
        PrintMatrix(A);
        Console.WriteLine();
        F27(B);
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

    public double sm1(double x)
    {
        double s = 1;
        for (int i = 1; ; i++)
        {
            if (Math.Abs(Math.Cos(i * x) / (fk(i))) <= 0.0001)
                break;
            s += Math.Cos(i * x) / (fk(i));
        }
        return s;
    }
    public double sm2(double x)
    {
        double s = 0;
        for (int i = 1;; i++)
        {
            if (Math.Abs(Math.Cos(i * x) / (i * i)) <= 0.0001)
                break;
            if (i % 2 == 0)
                s += Math.Cos(i * x) / (i * i);
            else
                s -= Math.Cos(i * x) / (i * i);
        }
        return s;
    }



    public double Fy1(double x)
    {
        return Math.Exp(Math.Cos(x)) * Math.Cos(Math.Sin(x));
    }
    public double Fy2(double x)
    {
        return (x * x - (Math.PI * Math.PI / 3)) / 4;
    }

    public delegate double SumDelegate(double x);
    public delegate double YDelegate(double x);

    public double[,] func_3_1(double a, double b, double h, SumDelegate SmDg, YDelegate Yfn)
    {
        int ansind = 0;
        double[,] sp = new double[(int)Math.Round((b - a) / h + 1, 0), 2];
        for (double x = a; x <= b + h / 2; x += h, ansind++)
        {
            sp[ansind, 0] = SmDg(x);
            sp[ansind, 1] = Yfn(x);
        }
        return sp;

    }

    #region Level 3
    public void Task_3_1(ref double[,] firstSumAndY, ref double[,] secondSumAndY)
    {
        //Console.WriteLine(111);
        //double[,] ans1 = new double[, 4];
        //Console.WriteLine(111);
        firstSumAndY = func_3_1(0.1, 1, 0.1, sm1, Fy1);

        /*double[,] answerA = new double[10, 2] {
            { 2.691248985686179, 2.691268139166703 },
                { 2.612188250758326, 2.6122204929844544 },
                { 2.486877948066567, 2.486856868603152 },
                { 2.3239116638734316, 2.3238842457941966 },
                { 2.133946805639821, 2.133930111437405 },
                { 1.9284273029461472, 1.9283342378052784 },
                { 1.7179407535719313, 1.7179999609519054 },
                { 1.5124407582589756, 1.5124670047163078 },
                { 1.3192885674454282, 1.3193027107322826 },
                { 1.1438419924605645, 1.1438356437916406 }
        };
        firstSumAndY = answerA;*/

        Console.WriteLine();
        PrintMatrix(firstSumAndY);
        secondSumAndY = func_3_1(Math.PI / 5, Math.PI, Math.PI / 25, sm2, Fy2);
        Console.WriteLine();
        PrintMatrix(secondSumAndY);
        // create and use public delegate SumFunction(x, a, b, h) and public delegate YFunction(x, a, b, h)
        // create and use method GetSumAndY(sFunction, yFunction, a, b, h);
        // create and use 2 methods for both functions
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

    public double[] SwapRight(double[] array)
    {
        for (int i = array.Length - 1; i >= 1; i -= 2)
        {
            double p = array[i];
            array[i] = array[i - 1];
            array[i - 1] = p;
        }
        return array;
    }

    public double[] SwapLeft(double[] array)
    {
        for (int i = 0; i <= array.Length - 2; i += 2)
        {
            double p = array[i];
            array[i] = array[i + 1];
            array[i + 1] = p;
        }
        return array;
    }

    public delegate double[] SwapDirection(double[] array);

    public double[] Swap(double[] array, SwapDirection SD)
    {
        double[] m = SD(array);
        return m;
    }

    public double Sum_3_3(double[] array)
    {
        double sm = 0;
        for (int i = 1; i < array.Length; i+=2)
        { 
            sm += array[i];
        }
        return sm;
    }



    public double Task_3_3(double[] array)
    {
        double answer = 0;
        double sred = 0;
        for (int i = 0; i < array.Length; i++)
            sred += array[i];
        sred = sred / array.Length;
        SwapDirection swapper;
        if (array[0] > sred)
            Swap(array, SwapLeft);
        else
            Swap(array, SwapRight);

        double sm = Sum_3_3(array);
        return sm;
        // code here

        // create and use public delegate SwapDirection(array);
        // create and use methods SwapRight(array) and SwapLeft(array) and GetSum(array)
        // change method in variable swapper in the loop here and use it for array swapping

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


    public delegate double YFunc_3_5Delegate(double x);

    public double YFunction1_3_5(double x)
    {
        return x * x - Math.Sin(x);
    }
    public double YFunction2_3_5(double x)
    {
        return Math.Exp(x) - 1;
    }

    public double[] func_3_5(double a, double b, double h, YFunc_3_5Delegate YF)
    {
        int ansind = 0;
        double[] sp = new double[(int)Math.Round((b - a) / h + 1, 0)];
        for (double x = a; x <= b + h / 2; x += h, ansind++)
        {
            sp[ansind] = YF(x);
        }
        return sp;

    }

    public int CharacterCounter(double[] arr)
    {
        int count = 0;
        int l = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] < 0)
            {
                if (l > 0)
                    count += 1;
                l = -1;
            }
            else if (arr[i] > 0)
            {
                if (l < 0)
                    count += 1;
                l = 1;
            }
        }
        return count;
    }

    public void Task_3_5(out int func1, out int func2)
    {
        double[] p1 = func_3_5(0, 2, 0.1, YFunction1_3_5);
        double[] p2 = func_3_5(-1, 1, 0.2, YFunction2_3_5);

        Console.WriteLine();
        for (int i = 0; i < p1.Length; i++)
            Console.Write(p1[i] + " ");

        Console.WriteLine();
        for (int i = 0; i < p2.Length; i++)
            Console.Write(p2[i] + " ");

        func1 = CharacterCounter(func_3_5(0, 2, 0.1, YFunction1_3_5));
        func2 = CharacterCounter(func_3_5(-1, 1, 0.2, YFunction2_3_5));

        Console.WriteLine();
        Console.WriteLine(func1);
        Console.WriteLine(func2);
        // code here

        // use public delegate YFunction(x, a, b, h) from Task_3_1
        // create and use method CountSignFlips(YFunction, a, b, h);
        // create and use 2 methods for both functions

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

    public delegate int CountPositive(int[,] matrix, int index);

    public int funct_3_7(int[,] B, CountPositive CP)
    {
        int index = -1;
        int max = int.MinValue;
        for (int i = 0; i < B.GetLength(0); i++)
        {
            if (CP(B, i) > max)
            {
                max = CP(B, i);
                index = i;
            }
        }
        return index;
    }

    public void Task_3_7(ref int[,] B, int[,] C)
    {
        // code here

        // create and use public delegate CountPositive(matrix, index);
        // use CountRowPositive(matrix, rowIndex) from Task_2_7
        // use CountColumnPositive(matrix, colIndex) from Task_2_7
        int maxb = 0;
        int maxc = 0;
        int indexb = -1;
        int indexc = -1;

        int[,] B1 = new int[B.GetLength(0) + 1, B.GetLength(1)];

        PrintMatrix(B);
        Console.WriteLine();
        PrintMatrix(C);
        Console.WriteLine();

        indexb = funct_3_7(B, CountRowPositive);
        indexc = funct_3_7(C, CountColumnPositive);


        for (int i = 0; i < B1.GetLength(0); i++)
            for (int j = 0; j < B1.GetLength(1); j++)
            {
                if (i <= indexb)
                    B1[i, j] = B[i, j];
                else if (i >= indexb + 1)
                    B1[i, j] = B[i - 1, j];
            }

        for (int k = 0; k < B1.GetLength(1); k++)
        {
            B1[indexb + 1, k] = C[k, indexc];
        }

        B = B1;
        PrintMatrix(B);
        Console.WriteLine();
        PrintMatrix(C);
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

    public delegate int FindElementDelegate(int[,] matrix);

    public int FindMaxElement(int[,] matrix)
    {
        int i1 = 0, j1 = 0, i2 = 0, j2 = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] > matrix[i1, j1])
                {
                    i1 = i;
                    j1 = j;
                }
            }
        return i1;
    }

    public int FindMinElement(int[,] matrix)
    {
        int i1 = 0, j1 = 0, i2 = 0, j2 = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] < matrix[i2, j2])
                {
                    i2 = i;
                    j2 = j;
                }
            }
        return i2;
    }

    public int funct_3_13(int[,] matrix, FindElementDelegate FED)
    {
        return FED(matrix);
    }

    public void Task_3_13(ref int[,] matrix)
    {
        // code here
        Console.WriteLine();
        PrintMatrix(matrix);
        int i1 = funct_3_13(matrix, FindMaxElement);
        int i2 = funct_3_13(matrix, FindMinElement);

        matrix = RemoveRow(matrix, i1);

        if (i1 != i2)
        {
            i2 = funct_3_13(matrix, FindMinElement);
            matrix = RemoveRow(matrix, i2);
        }
        Console.WriteLine();
        PrintMatrix(matrix);
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

    public delegate void ReplaceMaxElement(int[,] matrix, int rowindex);

    public void func_3_37(int[,] matrix, int rowindex, ReplaceMaxElement RME)
    { 
        RME(matrix, rowindex);
    }
    public void ReplaceMaxElementOdd(int[,] matrix, int rowindex)
    {
        int max = int.MinValue;
        for (int i = 0; i < matrix.GetLength(1); i++)
        { 
            if (matrix[rowindex, i] > max)
                max = matrix[rowindex, i];
        }
        for (int i = 0; i < matrix.GetLength(1); i++)
        {
            if (matrix[rowindex, i] == max)
            { 
                matrix[rowindex, i] = matrix[rowindex, i] * (i+1);
                break;
            }
        }
       
    }

    public void ReplaceMaxElementEven(int[,] matrix, int rowindex)
    {
        int max = int.MinValue;
        for (int i = 0; i < matrix.GetLength(1); i++)
        {
            if (matrix[rowindex, i] > max)
                max = matrix[rowindex, i];
        }
        for (int i = 0; i < matrix.GetLength(1); i++)
        {
            if (matrix[rowindex, i] == max)
            { 
                matrix[rowindex, i] = 0;
                break;
            }
        }

    }

    public void Task_3_27(int[,] A, int[,] B)
    {
        // code here
        Console.WriteLine();
        PrintMatrix(A);

        for (int i = 0; i < A.GetLength(0); i++)
            if (i % 2 == 1)
                func_3_37(A, i, ReplaceMaxElementEven);
            else
                func_3_37(A, i, ReplaceMaxElementOdd);

        Console.WriteLine();
        PrintMatrix(A);

        Console.WriteLine();
        PrintMatrix(B);

        for (int i = 0; i < B.GetLength(0); i++)
            if (i % 2 == 1)
                func_3_37(B, i, ReplaceMaxElementEven);
            else
                func_3_37(B, i, ReplaceMaxElementOdd);

        Console.WriteLine();
        PrintMatrix(B);
        // create ==and use public delegate ReplaceMaxElement(matrix, rowIndex, max);
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

    public delegate void MatrixConverter(double[,] matrix);

    public void SumRows(double[,] matrix, int rowindex1, int rowindex2)
    {
        for (int i = 0; i < matrix.GetLength(1); i++)
        {
            matrix[rowindex2, i] = Math.Round(matrix[rowindex2, i] + matrix[rowindex1, i], 6);
            if (matrix[rowindex2, i] == -0)
                matrix[rowindex2, i] = 0;
        }
    }

    public void MultiplyRow(double[,] matrix, int rowindex, double m)
    {
        for (int i = 0; i < matrix.GetLength(1); i++)
        {
            matrix[rowindex, i] = Math.Round(matrix[rowindex, i] * m, 6);
            if (matrix[rowindex, i] == -0)
                matrix[rowindex, i] = 0;
        }
    }

    public void SumMultipleRows(double[,] matrix, int i1, int i2, double k)
    {
        for (int i = 0; i < matrix.GetLength(1); i++)
        {
            matrix[i2, i] = Math.Round(matrix[i2, i] + matrix[i1, i] * k, 6);
            if (matrix[i2, i] == -0)
                matrix[i2, i] = 0;
        }
    }

    //1
    /*public void ToUpperTriangular(double[,] matrix)
    {
        for (int i = matrix.GetLength(0)-1; i >=0; i--)
        {
            for (int k = i - 1; k >= 0; k--)
            {
                if (matrix[k, i] == 0)
                    continue;
                MultiplyRow(matrix, i, -1 * matrix[k, i] / matrix[i, i]);
                SumRows(matrix, i, k);
            }
        }
    }*/

    //1
    /*public void ToLowerTriangular(double[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int k = i + 1; k < matrix.GetLength(0); k++)
            {
                if (matrix[k, i] == 0)
                    continue;
                MultiplyRow(matrix, i, -1 * matrix[k, i] / matrix[i, i]);
                SumRows(matrix, i, k);
            }
        }
    }*/

    //2
    /*public void ToUpperTriangular(double[,] matrix)
    {
        for (int i = matrix.GetLength(0) - 1; i >= 0; i--)
        {
            for (int k = i - 1; k >= 0; k--)
            {
                if (matrix[k, i] == 0)
                    continue;
                MultiplyRow(matrix, k, -1 * matrix[i, i] / matrix[k, i]);
                SumRows(matrix, i, k);
            }
        }
    }*/
    //2
    /*public void ToLowerTriangular(double[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int k = i + 1; k < matrix.GetLength(0); k++)
            {
                if (matrix[k, i] == 0)
                    continue;
                MultiplyRow(matrix, k, -1 * matrix[i, i] / matrix[k, i]);
                SumRows(matrix, i, k);
            }
        }
    }*/
    //

    //3
    public void ToUpperTriangular(double[,] matrix)
    {
        for (int i = matrix.GetLength(0)-1; i >=0; i--)
        {
            for (int k = i - 1; k >= 0; k--)
            {
                if (matrix[k, i] == 0)
                    continue;
                //MultiplyRow(matrix, i, -1 * matrix[k, i] / matrix[i, i]);
                SumMultipleRows(matrix, i, k, -1 * matrix[k, i] / matrix[i, i]);
            }
        }
    }

    //3
    public void ToLowerTriangular(double[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int k = i + 1; k < matrix.GetLength(0); k++)
            {
                if (matrix[k, i] == 0)
                    continue;
                //MultiplyRow(matrix, i, -1 * matrix[k, i] / matrix[i, i]);
                SumMultipleRows(matrix, i, k, -1 * matrix[k, i] / matrix[i, i]);
            }
        }
    }

    public void ToDiagonal2(double[,] matrix)
    {
        ToLowerTriangular(matrix);
        ToUpperTriangular(matrix);
    }
    public void ToDiagonal3(double[,] matrix)
    {
        ToUpperTriangular(matrix);
        ToLowerTriangular(matrix);
    }

    public double[,] Task_4(double[,] matrix, int index)
    {
        //MatrixConverter[] mc = new MatrixConverter[3];
        if (index == 0)
        {
            Console.WriteLine(index);
            Console.WriteLine();
            PrintMatrix(matrix);
            ToLowerTriangular(matrix);
            Console.WriteLine();
            PrintMatrix(matrix);
        }
        else if (index == 1)
        {
            Console.WriteLine(index);
            Console.WriteLine();
            PrintMatrix(matrix);
            ToUpperTriangular(matrix);
            Console.WriteLine();
            PrintMatrix(matrix);
        }
        else if (index == 2)
        {
            Console.WriteLine(index);
            Console.WriteLine();
            PrintMatrix(matrix);
            ToDiagonal2(matrix);
            Console.WriteLine();
            PrintMatrix(matrix);
        }
        else
        {
            Console.WriteLine(index);
            Console.WriteLine();
            PrintMatrix(matrix);
            ToDiagonal3(matrix);
            Console.WriteLine();
            PrintMatrix(matrix);
        }
        // code here

        // create public delegate MatrixConverter(matrix);
        // create and use method ToUpperTriangular(matrix);
        // create and use method ToLowerTriangular(matrix);
        // create and use method ToDiagonal(matrix,);

        // end
        //double[,] m = new double[0, 0];
        return matrix;
    }
    #endregion
}