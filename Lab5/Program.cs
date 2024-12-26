using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Numerics;
using System.Reflection;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class Program
{
    public static void Main()
    {
        Program program = new Program();
        int[,] matrix1 = new int[,] {
            { 1, 2, 3, 4, 5 },
            { 6, 7, 8, 9, 10 },
            { -1, -2, -3, -4, -5 },
            { 6, 7, 8, 9, 0 }};
        int[,] matrix2 = new int[5, 6] {
            { 1, 2, 3, 4, 5, -1 },
            { 6, 7, 8, 9, 10, -2 },
            { 11, 12, 13, 14, 15, -3 },
            { -1, -2, -3, -4, -5, -1 },
            { 1, 3, 3, 1, 5, 5 }};
        program.Task_2_3(ref matrix1, ref matrix2);
        program.Print(matrix1);
        Console.WriteLine();
        program.Print(matrix2);
    }
    public void Print(int[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write(matrix[i,j] + " ");
            }
            Console.WriteLine();
        }
    }

    #region Level 1
    public long Task_1_1(int n, int k)
    {
        long answer = 0;

        // code here
        answer = Combinations(n, k);
        // create and use Combinations(n, k);
        // create and use Factorial(n);

        // end

        return answer;
    }
    public int Factorial(int n)
    {
        if (n == 1) return 1;
        return n * Factorial(n - 1);
    }
    public int Combinations(int n, int k)
    {
        return Factorial(n) / (Factorial(k) * Factorial(n - k));
    }





    public int Task_1_2(double[] first, double[] second)
    {
        int answer = 0;

        // code here
        double a1 = first[0], b1 = first[1], c1 = first[2];
        double a2 = second[0], b2 = second[1], c2 = second[2];
        // create and use GeronArea(a, b, c);

        if (GeronArea(a1, b1, c1) > GeronArea(a2, b2, c2)) answer = 1;
        else if (GeronArea(a1, b1, c1) == GeronArea(a2, b2, c2)) answer = 0;
        else answer = 2;

        //if (a1 <= 0 || b1 <= 0 || c1 <= 0 || a2 <= 0 || b2 <= 0 || a2 <= 0)
        //    answer = -1;
        if (!(a1 < b1 + c1 && b1 < a1 + c1 && c1 < a1 + b1) || !(a2 < b2 + c2 && b2 < a2 + c2 && c2 < a2 + b2))
            answer = -1;
        // end

        // first = 1, second = 2, equal = 0, error = -1
        return answer;
    }
    public double GeronArea(double a, double b, double c)
    {
        double S = 0;
        double p = (a + b + c) / 2;
        S = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        return S;
    }








    public int Task_1_3a(double v1, double a1, double v2, double a2, int time)
    {
        int answer = 0;

        // code here
        if (GetDistance(v1, a1, time) > GetDistance(v2, a2, time))
            answer = 1;
        else if ((GetDistance(v1, a1, time) < GetDistance(v2, a2, time)))
            answer = 2;
        else answer = 0;

        // create and use GetDistance(v, a, t); t - hours

        // end

        // first = 1, second = 2, equal = 0
        return answer;
    }

    public double GetDistance(double v, double a, double t)
    {
        return v * t + a * t * t / 2;
    }




    public int Task_1_3b(double v1, double a1, double v2, double a2)
    {
        int answer = 0;

        // code here
        answer = 1;
        while ((GetDistance(v1, a1, answer) > GetDistance(v2, a2, answer)))
        {
            answer++;
        }
        // use GetDistance(v, a, t); t - hours

        // end

        return answer;
    }
    #endregion

    #region Level 2
    public void Task_2_1(int[,] A, int[,] B)
    {
        // code here
        int ai, aj, bi, bj;
        FindMaxIndex(A, out ai, out aj);
        FindMaxIndex(B, out bi, out bj);
        // create and use FindMaxIndex(matrix, out row, out column);
        int temp = A[ai, aj];
        A[ai, aj] = B[bi, bj];
        B[bi, bj] = temp;


        // end
    }

    public void FindMaxIndex(int[,] A, out int row, out int column)
    {
        int maxi = A[0, 0];
        row = column = 0;
        for (int i = 0; i < A.GetLength(0); i++)
        {
            for (int j = 0; j < A.GetLength(1); j++)
            {
                if (maxi < A[i, j])
                {
                    maxi = A[i, j];
                    row = i;
                    column = j;
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
        //  create and use method FindDiagonalMaxIndex(matrix);
        //int[,] new_b = new int[B.GetLength(0) - 1, B.GetLength(1)];
        //int[,] new_c = new int[C.GetLength(0) - 1, C.GetLength(1)];
        //for (int i = 0; i < new_b.GetLength(0); i++)
        //{
        //    for (int j = 0; j < B.GetLength(1); j++)
        //    {
        //        if (i < FindDiagonalMaxIndex(B))
        //            new_b[i, j] = B[i, j];
        //        else
        //            new_b[i, j] = B[i + 1, j];
        //    }
        //}
        //for (int i = 0; i < new_c.GetLength(0); i++)
        //{
        //    for (int j = 0; j < C.GetLength(1); j++)
        //    {
        //        if (i < FindDiagonalMaxIndex(C))
        //            new_c[i, j] = C[i, j];
        //        else
        //            new_c[i, j] = C[i + 1, j];
        //    }
        //}
        //B = new_b;
        //C = new_c;
        int indexB=FindDiagonalMaxIndex(B);
        int indexC=FindDiagonalMaxIndex(C);
        AdditionalMethodDRYForRemovingRows(ref B, indexB);
        AdditionalMethodDRYForRemovingRows(ref C, indexC);

        // end
    }
    public void AdditionalMethodDRYForRemovingRows(ref int[,] matrix, int index)
    {
        int[,] new_matrix = new int[matrix.GetLength(0) - 1, matrix.GetLength(1)];
        for (int i = 0; i < new_matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if ( i < index)
                    new_matrix[i, j] = matrix[i, j];
                else
                {
                    new_matrix[i, j] = matrix[i+1, j];
                }
            }
        }
        matrix = new_matrix;
    }

    public int FindDiagonalMaxIndex(int[,] matrix)
    {
        int index = 0, maxi = int.MinValue;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            if (maxi < matrix[i, i])
            {
                maxi = matrix[i, i];
                index = i;
            }
        }
        return index;
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
        int Aindex, Bindex;
        FindMaxInColumn(A, 0, out Aindex);
        FindMaxInColumn(B, 0, out Bindex);
        for (int j = 0; j < A.GetLength(1); j++)
        {
            int temp = A[Aindex, j];
            A[Aindex, j] = B[Bindex, j];
            B[Bindex, j] = temp;

        }
        // create and use FindMaxInColumn(matrix, columnIndex, out rowIndex);

        // end
    }
    public void FindMaxInColumn(int[,] matrix, int columnIndex, out int rowIndex)
    {
        rowIndex = 0;
        int maxi = int.MinValue;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            if (maxi < matrix[i, columnIndex])
            {
                maxi = matrix[i, columnIndex];
                rowIndex = i;
            }
        }
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
        // create and use CountRowPositive(matrix, rowIndex);
        // create and use CountColumnPositive(matrix, colIndex);

        //считаем макс позитив
        int ipos = 0;
        int maxi_B = int.MinValue;
        for (int row = 0; row < 4; row++)
        {
            if (maxi_B < CountRowPositive(B, row))
            {
                maxi_B = CountRowPositive(B, row);
                ipos = row;
            }
        }
        int jpos = 0;
        int maxi_C = int.MinValue;
        for (int col = 0; col < 6; col++)
        {
            if (maxi_C < CountColumnPositive(C, col))
            {
                maxi_C = CountColumnPositive(C, col);
                jpos = col;
            }
        }

        int[,] new_b = new int[5, 5];
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (i <= ipos)
                {
                    new_b[i, j] = B[i, j];
                }
                else if (i == ipos + 1)
                {
                    new_b[i, j] = C[j, jpos];
                }
                else new_b[i, j] = B[i - 1, j];
            }
        }
        B = new_b;
        // end
    }
    public int CountRowPositive(int[,] matrix, int rowIndex)
    {
        int count = 0;
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (matrix[rowIndex, j] > 0)
            {
                count++;
            }
        }
        return count;
    }
    public int CountColumnPositive(int[,] matrix, int colIndex)
    {
        int count = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            if (matrix[i, colIndex] > 0)
            {
                count++;
            }
        }
        return count;
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

        // code here
        answer = new int[A.GetLength(1) + C.GetLength(1)];
        // create and use SumPositiveElementsInColumns(matrix);
        int[] array1 = SumPositiveElementsInColumns(A);
        int[] array2 = SumPositiveElementsInColumns(C);

        for (int i = 0; i < array1.Length; i++)
            answer[i] = array1[i];
        for (int i = 0; i < array2.Length; i++)
            answer[i + array1.Length] = array2[i];

        // end

        return answer;
    }

    public int[] SumPositiveElementsInColumns(int[,] matrix)
    {
        int[] answer = new int[matrix.GetLength(1)];
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            int summa = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, j] > 0)
                {
                    summa += matrix[i, j];
                }
            }
            answer[j] = summa;
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
        // code here

        // use FindMaxIndex(matrix, out row, out column); from Task_2_1

        int ai, aj, bi, bj;
        FindMaxIndex(A, out ai, out aj);
        FindMaxIndex(B, out bi, out bj);
        int temp = A[ai, aj];
        A[ai, aj] = B[bi, bj];
        B[bi, bj] = temp;

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

        // create and use RemoveRow(matrix, rowIndex);
        int maxI = 0, minI = 0, maxi = matrix[0, 0], mini = matrix[0, 0];
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (mini > matrix[i, j])
                {
                    mini = matrix[i, j];
                    minI = i;
                }
                if (maxi < matrix[i, j])
                {
                    maxi = matrix[i, j];
                    maxI = i;
                }
            }
        }
        RemoveRow(ref matrix, maxI);
        if (minI < maxI)
        {
            RemoveRow(ref matrix, minI);
        }
        else if (minI > maxI)
        {
            RemoveRow(ref matrix, minI - 1);
        }

        //if (minI != maxI) 
        //    RemoveRow(ref matrix, minI);
        //else
        //    RemoveRow(ref matrix, maxI);

        // end
    }
    public void RemoveRow(ref int[,] matrix, int rowIndex)
    {
        int[,] new_array = new int[matrix.GetLength(0) - 1, matrix.GetLength(1)];
        for (int i = 0; i < new_array.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (i < rowIndex)
                {
                    new_array[i, j] = matrix[i, j];
                }
                else
                {
                    new_array[i, j] = matrix[i + 1, j];
                }
            }
        }

        matrix = new_array;
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
        double[] array = { GetAverageWithoutMinMax(A), GetAverageWithoutMinMax(B), GetAverageWithoutMinMax(C) };
        if (array[0] < array[1] && array[1] < array[2])
            answer = 1;
        else if (array[0] > array[1] && array[1] > array[2])
            answer = -1;
        else answer = 0;

        // create and use GetAverageWithoutMinMax(matrix);

        // end

        // 1 - increasing   0 - no sequence   -1 - decreasing
        return answer;
    }

    public double GetAverageWithoutMinMax(int[,] matrix)
    {
        double answer = 0;
        int Imax = 0, Jmax = 0, Imin = 0, Jmin = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[Imax, Jmax] < matrix[i, j])
                {
                    Imax = i; Jmax = j;
                }
                if (matrix[Imin, Jmin] > matrix[i, j])
                {
                    Imin = i; Jmin = j;
                }
            }
        }
        int count = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if ((i != Imax && j != Jmax) && (i != Imin && j != Jmin))
                {
                    answer += matrix[i, j];
                    count++;
                }
            }
        }
        if (answer != 0)
            answer /= count;
        return answer;
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
        int[] array_A = new int[A.GetLength(0)];
        int[] array_B = new int[B.GetLength(0)];
        for (int rowA = 0; rowA < A.GetLength(0); rowA++)
        {
            array_A[rowA] = FindMaxInROW(A, rowA);
        }
        for (int rowB = 0; rowB < B.GetLength(0); rowB++)
        {
            array_B[rowB] = FindMaxInROW(B, rowB);
        }
        SortRowsByMaxElement(ref A, ref array_A);
        SortRowsByMaxElement(ref B, ref array_B);
        // create and use SortRowsByMaxElement(matrix);

        // end
    }
    public void SortRowsByMaxElement(ref int[,] matrix, ref int[] array) // 54321
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(0) - 1 - i; j++)
            {
                if (array[j] < array[j + 1])
                {
                    int temp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = temp;
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        int t = matrix[j, col];
                        matrix[j, col] = matrix[j + 1, col];
                        matrix[j + 1, col] = t;

                    }
                }
            }
        }

    }

    public int FindMaxInROW(int[,] matrix, int rowIndex)
    {
        int maxi = int.MinValue;
        for (int j = 0; j < matrix.GetLength(0); j++)
        {
            if (maxi < matrix[rowIndex, j])
            {
                maxi = matrix[rowIndex, j];
            }
        }
        return maxi;
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
        // use RemoveRow(matrix, rowIndex); from 2_13



        //int count = 0;
        //for(int i = 0; i < matrix.GetLength(0); i++)
        //{
        //    for (int j = 0; j < matrix.GetLength(1); j++)
        //    {
        //        if (matrix[i,j] == 0)
        //        {
        //            RemoveRow(ref matrix, i-count);
        //            count++;

        //        }
        //    }
        //}

        //for (int i = matrix.GetLength(0) - 1; i > 0; i--)
        //{
        //    for (int j =  matrix.GetLength(1) - 1; j > 0; j--)
        //    {
        //        if (matrix[i, j] == 0)
        //        {
        //            RemoveRow(ref matrix, i);
        //        }
        //    }
        //}

        //cконца шоб строки не съезжали
        for (int i = matrix.GetLength(0) - 1; i >= 0; i--)
        {
            if (TrueIfZeroInRow(matrix, i))
            {
                RemoveRow(ref matrix, i);
            }
        }


        // end
    }

    public bool TrueIfZeroInRow(int[,] matrix, int row)
    {
        bool hasZero = false;
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (matrix[row, j] == 0)
            {
                hasZero = true;
                break;
            }
        }
        return hasZero;
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

        // code here

        // create and use CreateArrayFromMins(matrix);
        answerA = CreateArrayFromMins(A);
        answerB = CreateArrayFromMins(B);
        // end
    }

    public int[] CreateArrayFromMins(int[,] matrix)
    {
        int[] array = new int[matrix.GetLength(0)];
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            int min = int.MaxValue;
            for (int j = i; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] < min)
                {
                    min = matrix[i, j];
                    array[i] = min;
                }
            }
        }
        return array;
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

        // create and use MatrixValuesChange(matrix);
        MatrixValuesChange(A);
        MatrixValuesChange(B);
        // end
    }

    public void MatrixValuesChange(double[,] matrix)
    {
        double[] array = new double[matrix.GetLength(0) * matrix.GetLength(1)];
        int index = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                array[index++] = matrix[i, j];
            }
        }

        for (int i = 0; i < array.Length; i++)
        {
            for (int j = 0; j < array.Length - i - 1; j++)
            {
                if (array[j] < array[j + 1])
                {
                    double temp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = temp;
                }
            }
        }
        //5 max массив 2 на 2
        if (array.Length < 5)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > 0) matrix[i, j] *= 2;
                    else matrix[i, j] *= 0.5;
                }
            }
        }
        else
        {
            double[] largest = new double[5];
            for (int i = 0; i < 5; i++)
            {
                largest[i] = array[i];
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    bool flag = false; //эл есть в массиве максиму
                    for (int k = 0; k < largest.Length; k++)
                    {
                        if (matrix[i, j] == largest[k])
                        {
                            flag = true;
                            break;
                        }
                    }

                    if (flag)
                    {
                        if (matrix[i, j] > 0) matrix[i, j] *= 2;
                        else matrix[i, j] *= 0.5;
                    }
                    else
                    {
                        if (matrix[i, j] < 0) matrix[i, j] *= 2;
                        else matrix[i, j] /= 2;

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
        maxA = 0;
        maxB = 0;

        // code here
        maxA = FindRowWithMaxNegativeCount(A);
        maxB = FindRowWithMaxNegativeCount(B);
        // create and use FindRowWithMaxNegativeCount(matrix);
        // in FindRowWithMaxNegativeCount create and use CountNegativeInRow(matrix, rowIndex); like in 2_22

        // end
    }
    public int FindRowWithMaxNegativeCount(int[,] matrix)
    {
        int maxi = int.MinValue;
        int row = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            if (CountNegativeInRow(matrix, i) > maxi)
            {
                maxi = CountNegativeInRow(matrix, i);
                row = i;
            }
        }
        return row;
    }

    public int CountNegativeInRow(int[,] matrix, int rowIndex)
    {
        int count = 0;
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (matrix[rowIndex, j] < 0)
            {
                count++;
            }
        }

        return count;
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
        //int columnIndex_A, columnIndex_B;
        //int len_a = A.GetLength(0);
        //int len_b = B.GetLength(0);
        //for (int i = 0; i < len_a; i++)
        //{
        //    if (i % 2 != 0)
        //    {
        //        FindRowMaxIndex(ref A, i, out columnIndex_A);
        //        ReplaceMaxElementEven(ref A, i, columnIndex_A);
        //    }
        //    else
        //    {
        //        FindRowMaxIndex(ref A, i, out columnIndex_A);
        //        ReplaceMaxElementOdd(ref A, i, columnIndex_A);
        //    }
        //}

        //for (int i = 0; i < len_b; i++)
        //{
        //    if (i % 2 != 0)
        //    {
        //        FindRowMaxIndex(ref B, i, out columnIndex_B);
        //        ReplaceMaxElementEven(ref B, i, columnIndex_B);
        //    }
        //    else
        //    {
        //        FindRowMaxIndex(ref B, i, out columnIndex_B);
        //        ReplaceMaxElementOdd(ref B, i, columnIndex_B);
        //    }
        //}

        AdditionalMethodDRYForTask_2_27(ref B);
        AdditionalMethodDRYForTask_2_27(ref A);
        // create and use FindRowMaxIndex(matrix, rowIndex, out columnIndex);
        // create and use ReplaceMaxElementOdd(matrix, row, column);
        // create and use ReplaceMaxElementEven(matrix, row, column);

        // end
    }
    public void AdditionalMethodDRYForTask_2_27(ref int[,] matrix)
    {
        int columnIndex;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            if (i % 2 != 0)
            {
                FindRowMaxIndex(ref matrix, i, out columnIndex);
                ReplaceMaxElementEven(ref matrix, i, columnIndex);
            }
            else
            {
                FindRowMaxIndex(ref matrix, i, out columnIndex);
                ReplaceMaxElementOdd(ref matrix, i, columnIndex);
            }
        }
    }
    public void FindRowMaxIndex(ref int[,] matrix, int rowIndex, out int columnIndex)
    {
        columnIndex = 0;
        int index = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[rowIndex, j] > matrix[index, columnIndex])
                {
                    index = 0;
                    columnIndex = j;
                }
            }
        }
    }
    public void ReplaceMaxElementEven(ref int[,] matrix, int row, int col)
    {
        matrix[row, col] = 0;
    }
    public void ReplaceMaxElementOdd(ref int[,] matrix, int row, int col)
    {
        matrix[row, col] *= col + 1;
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

        // create and use public delegate SumFunction(x, a, b, h) and public delegate YFunction(x, a, b, h)
        // create and use method GetSumAndY(sFunction, yFunction, a, b, h);
        // create and use 2 methods for both functions
        double a1 = 0.1, b1 = 1, h1 = 0.1;
        firstSumAndY = GetSumAndY(Sum1, y1, a1, b1, h1);

        double a2 = Math.PI / 5, b2 = Math.PI, h2 = Math.PI / 25;
        secondSumAndY = GetSumAndY(Sum2, y2, a2, b2, h2);

        // end
    }

    public delegate double YFunction(double x, double a, double b, double h);
    public double y1(double x, double a, double b, double h)
    {
        return Math.Exp(Math.Cos(x)) * Math.Cos(Math.Sin(x));
    }
    public double y2(double x, double a, double b, double h)
    {
        return (x * x - Math.PI * Math.PI / 3) / 4;
    }
    public delegate double SumFunction(double x, double a, double b, double h);
    public double Sum1(double x, double a, double b, double h)
    {
        double sum = 1;
        double elem = Math.Cos(x);
        for (int i = 2; Math.Abs(elem) > 0.0001; i++)
        {
            sum += elem;
            elem = Math.Cos(x * i) / Factorial(i);
        }
        return sum;
    }
    public double Sum2(double x, double a, double b, double h)
    {
        double sum = 0;
        int p = -1;
        double elem = p * Math.Cos(x);
        for (int i = 2; Math.Abs(elem) > 0.0001; i++)
        {
            sum += elem;
            p = -p;
            elem = p * Math.Cos(x * i) / (i * i);
        }
        return sum;
    }
    public double[,] GetSumAndY(SumFunction sFunction, YFunction yFunction, double a, double b, double h)
    {
        double[,] answer = new double[(int)((b - a) / h) + 1, 2];
        int i = 0;
        for (double x = a; Math.Round(x, 2) <= b; x += h)
        {
            double sum = sFunction(x, a, b, h);
            double y = yFunction(x, a, b, h);
            answer[i, 0] = sum;
            answer[i, 1] = y;
            i++;
        }
        return answer;
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

    public double Task_3_3(double[] array)
    {
        double answer = 0;
        // SwapDirection swapper = default(SwapDirection); - uncomment me

        // code here

        // create and use public delegate SwapDirection(array);
        // create and use methods SwapRight(array) and SwapLeft(array)
        // create and use method GetSum(array, start, h) that sum elements with a negative indexes
        // change method in variable swapper in the if/else and than use swapper(matrix)
        double avarage = 0;
        int count = 0;
        SwapDirection swapper;
        for (int i = 0; i < array.Length; i++)
        {
            avarage += array[i];
            count++;
        }
        if (count > 0) avarage /= count;

        if (array[0] > avarage) swapper = SwapRight;
        else swapper = SwapLeft;

        swapper(array);
        answer = GetSum(array);
        // end

        return answer;
    }
    public delegate void SwapDirection(double[] array);
    public void SwapRight(double[] array)
    {
        for (int i = 0; i < array.Length - 1; i++)
        {
            double temp = array[i];
            array[i] = array[i + 1];
            array[i + 1] = temp;
        }
    }
    public void SwapLeft(double[] array)
    {
        for (int i = array.Length - 1; i > 0; i -= 2)
        {
            double temp = array[i];
            array[i] = array[i - 1];
            array[i - 1] = temp;
        }
    }
    public double GetSum(double[] array)
    {
        double s = 0;
        for (int i = 1; i < array.Length; i += 2)
        {
            s += array[i];
        }
        return s;
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
        func1 = 0;
        func2 = 0;

        // code here

        // use public delegate YFunction(x, a, b, h) from Task_3_1
        // create and use method CountSignFlips(YFunction, a, b, h);
        // create and use 2 methods for both functions

        func1 = CountSignFlips(f1, 0, 2, 0.1);
        func2 = CountSignFlips(f2, -1, 1, 0.2);
        // end
    }

    public double f1(double x, double a, double b, double h)
    {
        return x * x - Math.Sin(x);
    }
    public double f2(double x, double a, double b, double h)
    {
        return Math.Exp(x) - 1;
    }
    public int CountSignFlips(YFunction y, double a, double b, double h)
    {
        int count = 1;
        double last_y = y(a, a, b, h);
        for (double x = a + h; x <= b; x += h)
        {
            if (y(a, a, b, h) == 0) continue;
            double now = y(x, a, b, h);
            if (last_y > 0 && now < 0 || last_y < 0 && now>0) count ++;
            last_y = now;
        }
        return count;
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

        // create and use public delegate CountPositive(matrix, index);
        // use CountRowPositive(matrix, rowIndex) from Task_2_7
        // use CountColumnPositive(matrix, colIndex) from Task_2_7
        // create and use method InsertColumn(matrixB, CountRow, matrixC, CountColumn);
        B = InsertColumn(B, CountRowPositive, C, CountColumnPositive);
        // end
    }
    public delegate int CountPositive(int[,] matrix, int index);
    public int[,] InsertColumn(int[,] matrixB, CountPositive CountRow, int[,] matrixC, CountPositive CountColumn)
    {
        int[,] matrix = new int[matrixB.GetLength(0) + 1, matrixB.GetLength(1)];

        int max_count_B = 0, max_count_C = 0, max_row = 0, max_col = 0;
        for (int i = 0; i < matrixB.GetLength(0); i++)
        {
            int count = CountRow(matrixB, i);
            if (max_count_B < count)
            {
                max_count_B = count;
                max_row = i;
            }
        }

        for (int i = 0; i < matrixC.GetLength(1); i++)
        {
            int count = CountColumn(matrixC, i);
            if (max_count_C < count)
            {
                max_count_C = count;
                max_col = i;
            }
        }

        for (int i = 0; i < matrixB.GetLength(1); i++)
        {
            matrix[max_row + 1, i] = matrixC[i, max_col];
        }
        for (int i = 0; i <= max_row; i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                matrix[i, j] = matrixB[i, j];
            }
        }
        for (int i = max_row + 2; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                matrix[i, j] = matrixB[i - 1, j];
            }
        }

        return matrix;
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
        RemoveRows(ref matrix, FindMax, FindMin);
        

        // end
    }
    public delegate int FindElementDelegate(int[,] matrix);
    public int FindMax(int[,] matrix)
    {
        int maxi = matrix[0, 0];
        int index = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] > maxi)
                {
                    maxi = matrix[i, j];
                    index = i;
                }
            }
        }
        return index;
    }
    public int FindMin(int[,] matrix)
    {
        int mini = matrix[0, 0];
        int index = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] < mini)
                {
                    mini = matrix[i, j];
                    index = i;
                }
            }
        }
        return index;
    }
    public void RemoveRows(ref int[,] matrix, FindElementDelegate FindMax, FindElementDelegate FindMin)
    {
        int Imax = FindMax(matrix), Imin = FindMin(matrix);
        //int[,] new_matrix = new int[matrix.GetLength(0)-2, matrix.GetLength(1)];

        if (Imax == Imin)
        {
            RemoveRow(ref matrix, Imax);
        }
        else
        {
            RemoveRow(ref matrix, Math.Max(Imax, Imin));
            RemoveRow(ref matrix, Math.Min(Imax, Imin));
        }

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

        EvenOddRowsTransform(ref A, ReplaceMaxElementOdd, ReplaceMaxElementEven);
        EvenOddRowsTransform(ref B, ReplaceMaxElementOdd, ReplaceMaxElementEven);

        // end
    }
    public delegate void ReplaceMaxElement(ref int[,] matrix, int rowIndex, int max);
    public void EvenOddRowsTransform(ref int[,] matrix, ReplaceMaxElement replaceMaxElementOdd, ReplaceMaxElement replaceMaxElementEven)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            int col = 0;
            FindRowMaxIndex(ref matrix, i, out col);
            if (i % 2 != 0)
            {
                replaceMaxElementEven(ref matrix, i, col);
            }
            else
            {
                replaceMaxElementOdd(ref matrix, i, col);
            }

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
