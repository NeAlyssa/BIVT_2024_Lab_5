using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data.Common;
using System.Numerics;
using System.Reflection;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
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
        answer = Factorial(n) / (Factorial(k) * Factorial(n - k));
        // end
        return answer;
    }
    int Factorial(int n)
    {
        int faktor = 1;
        for(int i = 1; i <= n; i++)
        {
            faktor *= i;
        }
        return faktor;
    }

    public int Task_1_2(double[] first, double[] second)
    {
        int answer = 0;

        // code here

        double s = GeronArea(first[0], first[1], first[2]);
        double s_2 = GeronArea(second[0], second[1], second[2]);
        if(pravilno(first[0], first[1], first[2]) == 0 || pravilno(second[0], second[1], second[2]) == 0)
            answer = -1;
        else if (s > s_2)
            answer = 1;
        else if (s < s_2)
            answer = 2;
        else if (s == s_2)
            answer = 0;

        // end

        // first = 1, second = 2, equal = 0, error = -1
        return answer;
    }
    double GeronArea(double a, double b, double c)
    {
        double p = (a + b + c) / 2;
        double s = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        return s;
    }
    int pravilno(double a, double b, double c) 
    { 
    if(a + b > c && a + c > b && c + b > a)
            return -1;
        return 0;
    }
    


    public int Task_1_3a(double v1, double a1, double v2, double a2, int time)
    {
        int answer = 0;

        // code here
        // create and use GetDistance(v, a, t); t - hours

        double s1 = GetDistance(v1, a1, time);
        double s2 = GetDistance(v2, a2, time);
        if (s1 > s2)
            answer = 1;
        else if (s2 > s1)
            answer = 2;
        else
            answer = 0;
        // end
        // first = 1, second = 2, equal = 0
        return answer;
    }
    double GetDistance(double v, double a, double t)
    {
        double s = v * t + (a * t * t) / 2;
        return s;
    }

    public int Task_1_3b(double v1, double a1, double v2, double a2)
    {
        int answer = 0;

        // code here
        // use GetDistance(v, a, t); t - hours
        int t = 1;
        while(GetDistance(v1, a1, t) > GetDistance(v2, a2, t))
        {
            t++;
        }
        answer = t;

        // end

        return answer;
    }
    #endregion

    #region Level 2
    public void Task_2_1(int[,] A, int[,] B)
    {
        // code here kkk
        // create and use FindMaxIndex(matrix, out row, out column);
        int index, index2;
        int index3, index4;
        FindMaxIndex(A, out index, out index2);
        FindMaxIndex(B, out index3, out index4);
        int num = A[index, index2];
        A[index, index2] = B[index3, index4];
        B[index3, index4] = num;
        // end

    }
    public void FindMaxIndex(int[,] A, out int index, out int index2)
    {
        int max = int.MinValue;
        int a0 = A.GetLength(0);
        int a1 = A.GetLength(1);
        index = index2 = 0;
        for (int i = 0; i < a0; i++)
        {
            for (int j = 0; j < a1; j++)
            {
                if (max < A[i, j])
                {
                    max = A[i, j];
                    index = i;
                    index2 = j;
                }
            }
        }
    }

    public void Task_2_2(double[] A, double[] B)
    {
        // code here

        // create and use FindMaxIndex(array);
        // only 1 array has to be changed!
        //delrow
        //FindDiagonalMaxIndex

        // end
    }

    public void Task_2_3(ref int[,] B, ref int[,] C)
    {
        // code here
        //  create and use method FindDiagonalMaxIndex(matrix);
        if (B.GetLength(0) != B.GetLength(1) || C.GetLength(0) != C.GetLength(1) || C.GetLength(1) != 6 || B.GetLength(1) != 5) return;

        
        int index1 = FindDiagonalMaxIndex(B);
        int index2 = FindDiagonalMaxIndex(C);

        B = index(B, index1);
        C = index(C, index2);
        // end
    }
    int[,] index(int[,] B, int index1)
    {
        int[,] new_B = new int[B.GetLength(0) - 1, B.GetLength(1)];
        for (int i = 0; i < B.GetLength(0); i++)
        {
            if (i == index1) i++;
            for (int j = 0; j < B.GetLength(1); j++)
            {
                if (i < index1)
                    new_B[i, j] = B[i, j];
                else
                    new_B[i - 1, j] = B[i, j];
            }
        }
        return new_B;
    }
    int FindDiagonalMaxIndex(int[,] matrix)
    {
        int max = int.MinValue;
        int max_i = -1;
        for(int i = 0; i < matrix.GetLength(0); i++)
        {
            if (matrix[i,i] > max)
            {
                max = matrix[i,i];
                max_i = i;
            }
                
        }
        return max_i;
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
        // create and use FindMaxInColumn(matrix, columnIndex, out rowIndex);
        
        if (A.GetLength(0) != 4 || A.GetLength(1) != 6 || B.GetLength(1) != 6 || B.GetLength(0) != 6) return;
        int max_1 = int.MinValue;
        int max_i_1 = -1;
        int max_2 = int.MinValue;
        int max_i_2 = -1;
        for (int i = 0; i < A.GetLength(0); i++)
        {
            if(max_1 < A[i, 0])
            {
                max_1 = A[i, 0];
                max_i_1 = i;
            }
        }
        for (int i = 0; i < B.GetLength(0); i++)
        {
            if (max_2 < B[i, 0])
            {
                max_2 = B[i, 0];
                max_i_2 = i;
            }
        }
        for (int i = 0; i < A.GetLength(1); i++)
        {
            int num = A[max_i_1, i];
            A[max_i_1, i] = B[max_i_2, i];
            B[max_i_2, i] = num;
        }
        


        // end
    }
    //FindMaxInColumn(matrix, columnIndex, out rowIndex)

    public void Task_2_6(ref int[] A, int[] B)
    {
        // code here

        // create and use FindMax(matrix, out row, out column); like in Task_2_1
        // create and use DeleteElement(array, index);

        // end
    }

    public void Task_2_7(ref int[,] B, int[,] C)
    {
        // code here ььь

        // create and use CountRowPositive(matrix, rowIndex);
        // create and use CountColumnPositive(matrix, colIndex);
        if (B.GetLength(0) != 4 || B.GetLength(1) != 5 || C.GetLength(1) != 6 || C.GetLength(0) != 5) return;
        
        int[,] new_B = new int[B.GetLength(0) + 1, B.GetLength(1)];
        int rowIndex = CountRowPositive(B);
        int colIndex = CountColumnPositive(C);
        for (int i = 0;i < new_B.GetLength(0);i++)
        {
            for (int j = 0; j < new_B.GetLength(1); j++)
            {
                if (i == rowIndex + 1)
                {
                    new_B[i, j] = C[j, colIndex];
                }
                if (i < rowIndex + 1)
                {
                new_B[i, j] = B[i, j];
                }
                if (i > rowIndex + 1)
                {
                    new_B[i, j] = B[i - 1, j];
                }

            }
        }
        B = new_B;
        
        // end
    }
    int CountRowPositive(int[,] matrix)
    {
        int max = 0;
        int max_i = -1;
        int max_i_i;
        for (int i = 0;i < matrix.GetLength(0); i++)
        {
            max_i_i = 0;
            for (int j = 0; j < matrix.GetLength(0); j++)
            {
                if (matrix[i, j] > 0)
                    max_i_i++;
            }
            if(max_i_i > max)
            {
                max = max_i_i;
                max_i = i;
            }
        }
        return max_i;
    }
    int CountColumnPositive(int[,] matrix)
    {
        int max = 0;
        int max_i = -1;
        int max_i_i;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            max_i_i = 0;
            for (int j = 0; j < matrix.GetLength(0); j++)
            {
                if (matrix[j, i] > 0)
                    max_i_i++;
            }
            if (max_i_i > max)
            {
                max = max_i_i;
                max_i = i;
            }
        }
        return max_i;
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

        // code here ььь
        
        // create and use SumPositiveElementsInColumns(matrix);
        if (C.GetLength(0) != 6 || C.GetLength(1) != 5 || A.GetLength(0) != 7 || A.GetLength(1) != 4) return default;
        
        
        int[] tot = SumPositiveElementsInColumns(A);
        int[] total = new int[A.GetLength(1) + C.GetLength(1)];
        for(int i = 0; i < tot.Length; i++)
        {
            total[i] = tot[i];
        }
        int[] al = SumPositiveElementsInColumns(C);
        int z = A.GetLength(1);
        for (int i = 0; i < C.GetLength(1); i++)
        {
            total[z] = al[i];
            z++;
        }
        answer = total;
        // end

        return answer;
    }
    int[] SumPositiveElementsInColumns(int[,] A) 
    { 
        int[] total = new int[A.GetLength(1)];
        int sum = 0;
        for (int i = 0; i < A.GetLength(1); i++)
        {
            sum = 0;
            for (int j = 0; j < A.GetLength(0); j++)
            {

                if (A[j, i] > 0) 
                {
                    sum += A[j, i];
                }
            }
            total[i] = sum;
            
        }
        return total;
    }


    public void Task_2_10(ref int[,] matrix)
    {
        // code here

        // create and use RemoveColumn(matrix, columnIndex);

        // end
    }

    public void Task_2_11(int[,] A, int[,] B)
    {
        // code here ььь

        // use FindMaxIndex(matrix, out row, out column); from Task_2_1
        
        int row, column;
        int row2, column2;
        FindMaxIndex1(A, out row, out column);
        FindMaxIndex1(B, out row2, out column2);
        int num = A[row, column];
        A[row, column] = B[row2, column2];
        B[row2, column2] = num;
        // end
    }
    public void FindMaxIndex1(int[,] A, out int index, out int index2)
    {
        int max = int.MinValue;
        int a0 = A.GetLength(0);
        int a1 = A.GetLength(1);
        index = index2 = 0;
        for (int i = 0; i < a0; i++)
        {
            for (int j = 0; j < a1; j++)
            {
                if (max < A[i, j])
                {
                    max = A[i, j];
                    index = i;
                    index2 = j;
                }
            }
        }
    }
    
    public void Task_2_12(int[,] A, int[,] B)
    {
        // code here

        // create and use FindMaxColumnIndex(matrix);

        // end
    }

    public void Task_2_13(ref int[,] matrix)
    {
        // code here ььь

        // create and use RemoveRow(matrix, rowIndex);
        
        int max = int.MinValue;
        int max_i = -1;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] > max)
                {
                    max = matrix[i, j];
                    max_i = i;
                }
            }
        }
        int min = int.MaxValue;
        int max_i_2 = -1;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] < min)
                {
                    min = matrix[i, j];
                    max_i_2 = i;
                }
            }
        }
        if(max_i == max_i_2)
            matrix = RemoveRow(matrix, max_i);
        else if(max_i < max_i_2)
        {
            matrix = RemoveRow(matrix, max_i);
            matrix = RemoveRow(matrix, max_i_2 - 1);
        }
        else if (max_i > max_i_2)
        {
            matrix = RemoveRow(matrix, max_i_2);
            matrix = RemoveRow(matrix, max_i - 1);
        }
        
        // end
    }
    int[,] RemoveRow(int[,] matrix, int rowIndex)
    {
        int[,] total = new int[matrix.GetLength(0) - 1, matrix.GetLength(1)];
        
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (rowIndex < i)
                {
                    total[i - 1,j] = matrix[i, j];
                }
                else if (rowIndex > i)
                {
                    total[i, j] = matrix[i, j];
                }
            }
        }
        return total;
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

        // code here ььь

        // create and use GetAverageWithoutMinMax(matrix);
        
        // end
        int[] total = new int[3];
        total[0] = GetAverageWithoutMinMax(A);
        total[1] = GetAverageWithoutMinMax(B);
        total[2] = GetAverageWithoutMinMax(C);
        if(total[0] == total[1] && total[1] == total[2] && total[2] == total[0])
        {
            answer = 0;
        }
        else if (total[0] < total[1] && total[1] < total[2])
            answer = 1;
        else if (total[0] > total[1] && total[1] > total[2])
            answer = -1;
        // 1 - increasing   0 - no sequence   -1 - decreasing
        return answer;
    }
    int GetAverageWithoutMinMax(int[,] matrix)
    {
        int sum = 0;
        int max = int.MinValue;
        int min = int.MaxValue;
        int num = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] > max)
                {
                    max = matrix[i, j];
                }
                else if (matrix[i, j] < min)
                {
                    min = matrix[i, j];
                }
                sum += matrix[i, j];
                num++;
            }
        }
        sum = sum - min - max;
        num -= 2;
        int sr = sum / num;
        return sr;
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
        A = SortRowsByMaxElements(A);
        B = SortRowsByMaxElements(B);
        // create and use SortRowsByMaxElement(matrix);
    }
    int[,] SortRowsByMaxElements(int[,] matrix)
    {
        int[] total_max_A = new int[matrix.GetLength(0)];
        int[] total_index_A = new int[matrix.GetLength(0)];
        int[,] neww = new int[matrix.GetLength(0), matrix.GetLength(1)];
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            int max = int.MinValue;
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] > max)
                {
                    max = matrix[i, j];
                }
            }
            total_max_A[i] = max;
            total_index_A[i] = i;
        }

        for (int i = 0; i < total_max_A.Length; i++)
        {
            for (int j = 0; j < total_max_A.Length - i - 1; j++)
            {
                if (total_max_A[j] < total_max_A[j + 1])
                {
                    int num = total_max_A[j + 1];
                    total_max_A[j + 1] = total_max_A[j];
                    total_max_A[j] = num;
                    int num_ind = total_index_A[j + 1];
                    total_index_A[j + 1] = total_index_A[j];
                    total_index_A[j] = num_ind;
                }
            }
        }
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                neww[i, j] = matrix[total_index_A[i], j];
            }
        }
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                matrix[i, j] = neww[i, j];
            }
        }

        return matrix;
    }



    public void Task_2_18(int[,] A, int[,] B)
    {
        // code here

        // create and use SortDiagonal(matrix);

        // end
    }

    public void Task_2_19(ref int[,] matrix)
    {
        // code here ььь

        // use RemoveRow(matrix, rowIndex); from 2_13
        
        for (int i = 0;i < matrix.GetLength(0); i++)
        {
            bool swap = false;
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] == 0)
                    swap = true;
            }
            if (swap) 
            { 
                matrix = RemoveRow(matrix, i);
                i--;
                
            } 
        }
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

        // code here ььь
        answerA = new int[A.GetLength(0)];
        answerB = new int[B.GetLength(0)];
        if (A.GetLength(0) != A.GetLength(1) && B.GetLength(0) != B.GetLength(1)) return;
        answerA = CreateArrayFromMins(A);
        answerB = CreateArrayFromMins(B);
        
        // create and use CreateArrayFromMins(matrix);

        // end
    }
    int[] CreateArrayFromMins(int[,] matrix)
    {
        int[] total = new int[matrix.GetLength(0)];
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            int min = int.MaxValue;
            for (int j = i; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] < min)
                    min = matrix[i, j];

            }
            total[i] = min;
        }
        return total;
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
        // code here ььь
        MatrixValuesChange(ref A);
        MatrixValuesChange(ref B);
        // create and use MatrixValuesChange(matrix);

        // end tot_B.Length - 5
    }
    void MatrixValuesChange(ref double[,] matrix)
    {
        double[] tot_A = new double[matrix.GetLength(0) * matrix.GetLength(1)];
        int h = 0;
        
        for (int i1 = 0; i1 < matrix.GetLength(0); i1++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                tot_A[h] = matrix[i1, j];
                h++;
            }
        }
        for (int i1 = 0; i1 < tot_A.Length; i1++)
        {
            for (int j = 0; j < tot_A.Length - i1 - 1; j++)
            {
                if (tot_A[j] > tot_A[j + 1])
                {
                    double tem = tot_A[j];
                    tot_A[j] = tot_A[j + 1];
                    tot_A[j + 1] = tem;
                }
            }
        }
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if(tot_A.Length <= 5)
                {
                    if (matrix[i, j] > 0)
                        matrix[i, j] = matrix[i, j] * 2;
                    if (matrix[i, j] < 0)
                        matrix[i, j] = matrix[i, j] / 2;

                }
                else if (matrix[i, j] == tot_A[tot_A.Length - 5] || matrix[i, j] == tot_A[tot_A.Length - 4] || matrix[i, j] == tot_A[tot_A.Length - 3] || matrix[i, j] == tot_A[tot_A.Length - 2] || matrix[i, j] == tot_A[tot_A.Length - 1])
                {
                    if (matrix[i, j] > 0)
                        matrix[i, j] = matrix[i, j] * 2;
                    if (matrix[i, j] < 0)
                        matrix[i, j] = matrix[i, j] / 2;

                }
                else
                {
                    if (matrix[i, j] > 0)
                        matrix[i, j] = matrix[i, j] / 2;
                    if (matrix[i, j] < 0)
                        matrix[i, j] = matrix[i, j] * 2;

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
        maxA = 0;
        maxB = 0;

        // code here ььь
        maxA = FindRowWithMaxNegativeCount(A);
        maxB = FindRowWithMaxNegativeCount(B);

        // create and use FindRowWithMaxNegativeCount(matrix);
        // in FindRowWithMaxNegativeCount create and use CountNegativeInRow(matrix, rowIndex); like in 2_22

        // end
    }
    int FindRowWithMaxNegativeCount(int[,] matrix)
    {
        int[] tot = new int[2];
        int total_min = -1;
        int index_min = -1;

        for(int i = 0; i < matrix.GetLength(0); i++)
        {
            int minn = 0;
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] < 0)
                    minn++;
            }
            if (total_min < minn)
            {
                total_min = minn;
                index_min = i;
            }
                
        }
        return index_min;
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
        // code here ььь

        // create and use FindRowMaxIndex(matrix, rowIndex, out columnIndex);
        // create and use ReplaceMaxElementOdd(matrix, row, column); нечет 
        // create and use ReplaceMaxElementEven(matrix, row, column); четный
        
        ReplaceMaxElementOdd(A);
        ReplaceMaxElementEven(A);
        ReplaceMaxElementOdd(B);
        ReplaceMaxElementEven(B);
        
        // end
    }
    public void ReplaceMaxElementEven(int[,] matrix)
    {
        int maxx = -1;
        for (int i = 1; i < matrix.GetLength(0); i += 2)
        {
            maxx = FindRowMaxIndex(matrix, i);
            matrix[i, maxx] = 0;
        }
    }
    public void ReplaceMaxElementOdd(int[,] matrix)
    {
        int maxx = -1;
        for (int i = 0; i < matrix.GetLength(0); i += 2)
        {
            maxx = FindRowMaxIndex(matrix, i);
            matrix[i, maxx] = matrix[i, maxx] * (maxx + 1);
        }
    }
    int FindRowMaxIndex(int[,] matrix, int rowIndex)
    {
        int index = -1;
        int max = int.MinValue;
        for(int j = 0; j < matrix.GetLength(1); j++)
        {
            if(matrix[rowIndex, j] > max)
            {
                max = matrix[rowIndex, j];
                index = j;
            }
        }
        return index;
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
    public delegate double SumFunction(double x);
    public delegate double YFunction(double x);

    public static double[,] GetSumAndY(SumFunction sFunc, YFunction yfunction, double a, double b, double h)
    {
        double[,] A = new double[(int)((b - a) / h) + 1, 2];

        int ind = 0;
        for (double x = a; x <= b + h / 10; x += h)
        {
            double sum = sFunc(x);
            double y = yfunction(x);
            A[ind, 0] = sum;
            A[ind, 1] = y;
            ind++;
        }
        return A;
    }
    public static double S1(double x)
    {
        double sum = 0;
        double cast = 0;
        int i = 1;
        while (true)
        {
            int d = Factorial1(i);
            cast = Math.Cos(i * x) / d;
            if (Math.Abs(cast) <= 0.0001)
            {
                break;
            }
            sum += cast;
            i++;
        }
        return sum + 1;
    }
    public static int Factorial1(int n)
    {
        int faktor = 1;
        for (int i = 1; i <= n; i++)
        {
            faktor *= i;
        }
        return faktor;
    }
    public static double S2(double x)
    {
        double sum = 0;
        int i = 1;
        double cast = 0;
        int minus = -1;
        while (true)
        {
            cast = 1 * minus * Math.Cos(i * x) / (i * i);
            if (Math.Abs(cast) <= 0.0001)
            {
                break;
            }
            sum += cast;
            i++;
            minus *= -1;
        }
        return sum;
    }

    public static double Y1(double x)
    {
        double y = (Math.Exp(Math.Cos(x)) * Math.Cos(Math.Sin(x)));
        return y;
    }

    public static double Y2(double x)
    {
        double y = (x * x - (Math.PI * Math.PI) / 3) / 4;
        return y;
    }


    public void Task_3_1(ref double[,] firstSumAndY, ref double[,] secondSumAndY)
    {
        // code here
        double a = 0.1, b = 1, h = 0.1;
        double a2 = Math.PI / 5, b2 = Math.PI, h2 = Math.PI / 25;
        firstSumAndY = GetSumAndY(S1, Y1, a, b, h);
        secondSumAndY = GetSumAndY(S2, Y2, a2, b2, h2);
        // create and use public delegate SumFunction(double x) and public delegate YFunction(x)
        // create and use method GetSumAndY(sFunction, yFunction, a, b, h);
        // create and use 2 methods for both functions calculating at specific x

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
    public delegate void SwapDirection(ref double[] array);

    static double Srednee(double[] array)
    {
        double sum = 0;
        for (int i = 0; i < array.Length; i++)
        {
            sum += array[i];
        }
        sum = sum / (double)array.Length;
        return sum;
    }
    public void SwapRight(ref double[] array)
    {
        for (int i = 0; i < array.Length; i += 2)
        {
            double temp = array[i + 1];
            array[i + 1] = array[i];
            array[i] = temp;
        }
    }
    public void SwapLeft(ref double[] array)
    {
        for (int i = array.Length - 2; i >= 0; i -= 2)
        {
            double temp = array[i + 1];
            array[i + 1] = array[i];
            array[i] = temp;
        }
    }
    public double GetSum(double[] array, int start, int h)
    {
        double sum = 0;
        for (int i = start; i < array.Length; i += h)
        {
            sum += array[i];
        }
        return sum;
    }

    public double Task_3_3(double[] array)
    {
        if (array == null || array.Length == 0) return default;

        double answer = 0;
        int start = 1;
        int h = 2;
        SwapDirection swapper = default(SwapDirection);

        double average = Srednee(array);
        if (array[0] < average)
        {
            swapper = SwapLeft;
        }
        else
        {
            swapper = SwapRight;
        }
        swapper(ref array);
        answer = GetSum(array, start, h);
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

        // create and use public delegate GetTriangle(matrix);
        // create and use methods GetUpperTriange(array) and GetLowerTriange(array)
        // create and use GetSum(GetTriangle, matrix)

        // end

        return answer;
    }

    public int CountSignFlips(YFunction yfun, double a, double b, double h)
    {
        int total_number = 0;
        double first_y = yfun(a);
        for (double x = a + h; x <= b; x += h)
        {
            double second_y = yfun(x);
            if (first_y * second_y < 0)
            {
                total_number++;
            }
            if (second_y != 0)
            {
                first_y = second_y;
            }
        }
        return total_number;
    }
    public double Func1(double x)
    {
        double y = x * x - Math.Sin(x);
        return y;
    }

    public double Func2(double x)
    {
        double y = Math.Exp(x) - 1;
        return y;
    }
    public void Task_3_5(out int func1, out int func2)
    {
        // code here
        func1 = 0;
        func2 = 0;

        double a = 0, b = 2, h = 0.1;
        double a2 = -1, b2 = 1, h2 = 0.2;
        func1 = CountSignFlips(Func1, a, b, h);
        func2 = CountSignFlips(Func2, a2, b2, h2);
        // use public delegate YFunction(x, a, b, h) from Task_3_1
        // create and use method CountSignFlips(YFunction, a, b, h);
        // create and use 2 methods for both functions
        // end
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
    public delegate int CountPositive(int[,] matrix);

    public int[,] InsertColumn(int[,] matrixB, CountPositive CountRowPositive, int[,] matrixC, CountPositive CountColumnPositive)
    {
        int b0 = matrixB.GetLength(0);
        int b1 = matrixB.GetLength(1);
        int index_i = CountRowPositive(matrixB);
        int index_j = CountColumnPositive(matrixC);
        int[,] neww = new int[b0 + 1, b1];
        for(int i = 0; i < b1; i++)
        {
            neww[index_i + 1, i] = matrixC[i, index_j];
        }
        for(int i = 0; i <= index_i; i++)
        {
            for(int j = 0; j < b1; j++)
            {
                neww[i, j] = matrixB[i, j];
            }
        }
        for(int i = index_i + 2; i < b0 + 1; i++)
        {
            for(int j = 0; j < b1; j++)
            {
                neww[i, j] = matrixB[i - 1, j];
            }
        }
        return neww;
    }
    public void Task_3_7(ref int[,] B, int[,] C)
    {
        
    // code here
        B = InsertColumn(B, CountRowPositive, C, CountColumnPositive);
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
    
    public delegate int FindElementDelegate(int[,] matrix);
    public static int FindMax(int[,] matrix)
    {
        int max = int.MinValue;
        int a0 = matrix.GetLength(0);
        int a1 = matrix.GetLength(1);
        for (int i = 0; i < a0; i++)
        {
            for (int j = 0; j < a1; j++)
            {
                if (matrix[i, j] > max)
                {
                    max = matrix[i, j];
                }
            }
        }
        return max;
    }
    public static int FindMin(int[,] matrix)
    {
        int min = int.MaxValue;
        int a0 = matrix.GetLength(0);
        int a1 = matrix.GetLength(1);
        for (int i = 0; i < a0; i++)
        {
            for (int j = 0; j < a1; j++)
            {
                if (min > matrix[i, j])
                {
                    min = matrix[i, j];
                }
            }
        }
        return min;
    }
    public static int[,] RemoveRows(int[,] matrix, FindElementDelegate Max, FindElementDelegate Min)
    {
        int max = Max(matrix);
        int min = Min(matrix);
        int total_numb = 0;
        int a0 = matrix.GetLength(0);
        int a1 = matrix.GetLength(1);
        for (int i = 0; i < a0; i++)
        {
            for (int j = 0; j < a1; j++)
            {
                if (matrix[i, j] == max || matrix[i, j] == min)
                {
                    total_numb++;
                    break;
                }
            }
        }
        int[] index = new int[total_numb];
        total_numb = 0;
        for (int i = 0; i < a0; i++)
        {
            for (int j = 0; j < a1; j++)
            {
                if (matrix[i, j] == min || matrix[i, j] == max)
                {
                    index[total_numb] = i;
                    total_numb++;
                    break;
                }
            }
        }
        int[,] neww = new int[a0 - total_numb, a1];
        total_numb = 0;
        for (int i = 0; i < a0; i++)
        {
            if (total_numb < index.Length && i == index[total_numb])
            {
                total_numb++;
                continue;
            }
            else
            {
                for (int j = 0; j < a1; j++)
                {
                    neww[i - total_numb, j] = matrix[i, j];
                }
            }
        }
        return neww;
    }

    public void Task_3_13(ref int[,] matrix)
    {
        // code here
        matrix = RemoveRows(matrix, FindMax, FindMin);
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
    public delegate void ReplaceMaxElement(int[,] matrix);
    public void EvenOddRowsTransform(int[,] matrix, ReplaceMaxElement ReplaceMaxElementOdd, ReplaceMaxElement ReplaceMaxElementEven)
    {
        ReplaceMaxElementEven(matrix);
        ReplaceMaxElementOdd(matrix);
    }

    public void Task_3_27(int[,] A, int[,] B)
    {
        // code here рррр
        EvenOddRowsTransform(A, ReplaceMaxElementOdd, ReplaceMaxElementEven);
        EvenOddRowsTransform(B, ReplaceMaxElementOdd, ReplaceMaxElementEven);
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
