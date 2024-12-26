using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Numerics;
using System.Reflection;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class Program
{
    public static void Main()
    {
        Program program = new Program();
        int[,] A = {
                { 4 },
            { 6 },
            { -5 },
            { 9 },
            { 0 },
            { 14 },
            { 0 }};
        int[,] B = {
            { 1, 3, 5 },
            { 6, 8, 10 },
            { 11, 13, 15 },
            { -1, -3, -5 },
            { 0, 0, 0 },
            { 6, 8, 0 }};
        program.Task_2_20(ref A, ref B);
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

        if (GeronArea(a1, b1, c1) > GeronArea(a2, b2, c2)) answer = 1;
        else if (GeronArea(a1, b1, c1) == GeronArea(a2, b2, c2)) answer = 0;
        else if (GeronArea(a1, b1, c1) < GeronArea(a2, b2, c2)) answer = 2;

        if (a1 >= b1 + c1 || a2 >= b2 + c2 || b1 >= a1 + c1 || b2 >= a2 + c2 || c1 >= a1 + b1 || c2 >= a2 + b2) answer = -1;
        // create and use GeronArea(a, b, c);

        // end

        // first = 1, second = 2, equal = 0, error = -1
        return answer;
    }
    public double GeronArea(double a, double b, double c)
    {
        double p = (a + b + c) / 2;
        double s = Math.Sqrt((p * (p - a) * (p - b) * (p - c)));
        return s;
    }



    public int Task_1_3a(double v1, double a1, double v2, double a2, int time)
    {
        int answer = 0;

        // code here
        if (GetDistance(v1, a1, time) > GetDistance(v2, a2, time)) answer = 1;
        else if (GetDistance(v1, a1, time) == GetDistance(v2, a2, time)) answer = 0;
        else answer = 2;
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
        int answer = 1;

        // code here
        while (GetDistance(v1, a1, answer) > GetDistance(v2, a2, answer)) answer++;
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
        if (FindMaxIndex(A) < FindMaxIndex(B))
        {
            A[FindMaxIndex(A)] = FindMiddle(A);
            
        }
        else
        {
            B[FindMaxIndex(B)] = FindMiddle(B);
        }
        // create and use FindMaxIndex(array);
        // only 1 array has to be changed!

        // end
    }
    public int FindMaxIndex(double[] array)
    {
        double maxi = array[0];
        int ind = 0;
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] > maxi)
            {
                maxi = array[i];
                ind = i;
            }
        }
        return ind;
    }
    public double FindMiddle(double[] array)
    {
        double sum = 0;
        int count = 0;
        for (int i = FindMaxIndex(array) + 1; i < array.Length; i++)
        {
            sum += array[i];
            count++;
        }
        sum /= count;
        return sum;
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
        int[] copy = new int[A.Length];
        for (int i = 0; i < A.GetLength(0); i++)
        {
            copy[i] = A[FindDiagonalMaxIndex(A), i];
        }
        //  create and use method FindDiagonalMaxIndex(matrix); like in Task_2_3
        for (int i = 0; i < A.GetLength(0); i++)
        {
            A[FindDiagonalMaxIndex(A), i] = B[i, FindDiagonalMaxIndex(B)];
        }
        for (int i = 0; i < B.GetLength(0); i++)
        {
            B[i, FindDiagonalMaxIndex(B)] = copy[i];
        }
        // end
    }
    public int FindDiagonalMaxIndex(int[,] matrix)
    {
        int maxi = matrix[0, 0];
        int ind = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            if (matrix[i, i] > maxi)
            {
                maxi = matrix[i, i];
                ind = i;
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
        int[] end = new int[A.Length + B.Length - 2];
        for (int i = 0; i < A.Length - 1; i++)
        {
            end[i] = (DeleteElement(A, FindMax(A)))[i];
        }
        int count = 0;
        for (int i = A.Length - 1; i < end.Length; i++)
        {
            end[i] = (DeleteElement(B, FindMax(B)))[count];
            count++;
        }
        A = end;

        // create and use FindMax(matrix, out row, out column); like in Task_2_1
        // create and use DeleteElement(array, index);

        // end
    }
    public int FindMax(int[] array)
    {
        int ind = 0;
        int maxi = array[0];
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] > maxi)
            {
                maxi = array[i];
                ind = i;
            }
        }
        return ind;
    }
    public int[] DeleteElement(int[] array, int index)
    {
        int[] del = new int[array.Length - 1];
        for (int i = 0; i < index; i++)
        {
            del[i] = array[i];
        }
        for (int i = index; i < del.Length; i++)
        {
            del[i] = array[i + 1];
        }
        return del;
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
        A = SortArrayPart(A, FindMax(A));
        B = SortArrayPart(B, FindMax(B));
        // create and use SortArrayPart(array, startIndex);

        // end
    }
    public int[] SortArrayPart(int[] array, int startIndex)
    {
        for (int i = 0; i < array.Length - startIndex; i++)
        {
            for (int j = startIndex + 1; j < array.Length - i - 1; j++)
            {
                if (array[j] > array[j + 1])
                {
                    int temp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = temp;
                }
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

    public void Task_2_10(ref int[,] matrix)
    {
        // code here
        int maxi = matrix[0, 0];
        int imax = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (j <= i && maxi < matrix[i, j])
                {
                    maxi = matrix[i, j];
                    imax = j;
                }
            }
        }
        int mini = matrix[0, 0];
        int imin = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (j > i && mini < matrix[i, j])
                {
                    mini = matrix[i, j];
                    imin = j;
                }
            }
        }
        if (imax < imin)
        {
            matrix = RemoveColumn(ref matrix, imin);
            matrix = RemoveColumn(ref matrix, imax);
        }
        else if (imax > imin)
        {
            matrix = RemoveColumn(ref matrix, imax);
            matrix = RemoveColumn(ref matrix, imin);
        }
        else
        {
            matrix = RemoveColumn(ref matrix, imax);
        }

        // create and use RemoveColumn(matrix, columnIndex);

        // end
    }
    public int[,] RemoveColumn(ref int[,] matrix, int columnIndex)
    {
        int[,] answer = new int[matrix.GetLength(0), matrix.GetLength(1) - 1];
        for (int j = 0; j < columnIndex; j++)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                answer[i, j] = matrix[i, j];
            }
        }
        for (int j = columnIndex; j < answer.GetLength(1); j++)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                answer[i, j] = matrix[i, j + 1];
            }
        }
        matrix = answer;
        return matrix;
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
        int max1 = FindMaxColumnIndex(A);
        int max2 = FindMaxColumnIndex(B);
        for(int i = 0; i < A.GetLength(0); i++)
        {
            int temp = A[i, max1];
            A[i, max1] = B[i, max2];
            B[i, max2] = temp;
        }
        // create and use FindMaxColumnIndex(matrix);

        // end
    }
    public int FindMaxColumnIndex(int[,] matrix)
    {
        int maxi = matrix[0, 0];
        int ind = 0;
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (maxi < matrix[i, j])
                {
                    maxi = matrix[i, j];
                    ind = j;
                }
            }
        }
        return ind;
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
        {
            matrix = SortRow(matrix, i);
        }
        // create and use SortRow(matrix, rowIndex);

        // end
    }
    public int[,] SortRow(int[,] matrix, int rowIndex)
    {
        for (int i = 0; i < matrix.GetLength(1); i++)
        {
            for (int j = 0; j < matrix.GetLength(1) - i - 1; j++)
            {
                if (matrix[rowIndex, j] > matrix[rowIndex, j + 1])
                {
                    int temp = matrix[rowIndex, j];
                    matrix[rowIndex, j] = matrix[rowIndex, j + 1];
                    matrix[rowIndex, j + 1] = temp;
                }
            }
        }
        return matrix;
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
    public int[] SortNegative(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            for (int j = 0; j < array.Length - i - 1; j++)
            {
                if (array[j] < 0)
                {
                    int count = j + 1;
                    while (count < array.Length - 1 && array[count] >= 0)
                    {
                        count++;
                    }
                    if (array[count] > 0) continue;
                    if (array[count] > array[j])
                    {
                        int temp = array[j];
                        array[j] = array[count];
                        array[count] = temp;
                    }
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
        SortDiagonal(A);
        SortDiagonal(B);
        // create and use SortDiagonal(matrix);

        // end
    }
    public int[,] SortDiagonal(int[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(0) - i - 1; j++)
            {
                if (matrix[j, j] > matrix[j + 1, j + 1])
                {
                    int temp = matrix[j, j];
                    matrix[j, j] = matrix[j + 1, j + 1];
                    matrix[j + 1, j + 1] = temp;
                }
            }
        }
        return matrix;
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
        A = RemoveColumn1(ref A);
        B = RemoveColumn1(ref B);


        // use RemoveColumn(matrix, columnIndex); from 2_10

        // end
    }
    public int[,] RemoveColumn1(ref int[,] matrix)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            bool b = false;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, j] == 0)
                {
                    b = true; break;
                }
            }
            if (b == false)
            {
                RemoveColumn(ref matrix, j);
                j--;
            }
        }
        return matrix;
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
        for (int i = 0; i < rows.Length; i++)
        {
            rows[i] = CountNegativeInRow(matrix, i);
        }
        cols = FindMaxNegativePerColumn(matrix);
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
    public int[] FindMaxNegativePerColumn(int[,] matrix)
    {
        int[] answer = new int[matrix.GetLength(1)];
       
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            int maxi = int.MinValue;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, j] > maxi && matrix[i, j] < 0)
                {
                    maxi = matrix[i, j];
                }   
            }
            answer[j] = maxi;
        }
        return answer;
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
        A = SwapColumnDiagonal(A, FindMaxIndex(A));
        B = SwapColumnDiagonal(B, FindMaxIndex(B));
        // use FindMaxIndex(matrix, out row, out column); like in 2_1
        // create and use SwapColumnDiagonal(matrix, columnIndex);

        // end
    }
    public int FindMaxIndex(int[,] matrix)
    {
        int maxi = int.MinValue;
        int ind = 0;
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (maxi < matrix[i, j])
                {
                    maxi = matrix[i, j];
                    ind = j;
                }
            }
        }
        return ind;
    }
    public int[,] SwapColumnDiagonal(int[,] matrix, int columnIndex)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            int temp = matrix[i, columnIndex];
            matrix[i, columnIndex] = matrix[i, i];
            matrix[i, i] = temp;
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
        int a = FindRowWithMaxNegativeCount(A);
        int b = FindRowWithMaxNegativeCount(B);
        for (int j = 0; j < A.GetLength(1); j++)
        {
            int temp = A[a, j];
            A[a, j] = B[b, j];
            B[b, j] = temp;

        }
        // create and use FindRowWithMaxNegativeCount(matrix); like in 2_25
        // in FindRowWithMaxNegativeCount use CountNegativeInRow(matrix, rowIndex); from 2_22

        // end
    }
    public int FindRowWithMaxNegativeCount(int[,] matrix)
    {
        int ind = 0;
        int maxi = int.MinValue;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            if (maxi < CountNegativeInRow(matrix, i))
            {
                maxi = CountNegativeInRow(matrix, i);
                ind = i;
            }
        }
        return ind;
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
    public bool Up(int[] array, int A, int B)
    {
        for (int i = A; i < B; i++)
        {
            if (array[i] > array[i + 1])
                return false;
        }
        return true;
    }

    public bool Down(int[] array, int A, int B)
    {
        for (int i = A; i < B; i++)
        {
            if (array[i] < array[i + 1])
                return false;
        }
        return true;
    }
    public int FindSequence(int[] array, int A, int B)
    {
        if (Up(array, A, B)) return 1;
        if (Down(array, A, B)) return -1;
        return 0;


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
        int count = 0;
        for (int i = A; i < B; i++)
        {
            for (int j = i + 1; j <= B; j++)
            {
                if (FindSequence(array, i, j) != 0)
                    count++;
            }
        }
        int[,] C = new int[count, 2];
        int ind = 0;
        for (int i = A; i < B; i++)
        {
            for (int j = i + 1; j <= B; j++)
            {
                if (FindSequence(array, i, j) != 0)
                {
                    C[ind, 0] = i;
                    C[ind, 1] = j;
                    ind++;
                }
            }
        }
        return C;
    }


    public void Task_2_28c(int[] first, int[] second, ref int[] answerFirst, ref int[] answerSecond)
    {
        // code here
        int[,] F = FindSequence1(first, 0, first.Length - 1);
        answerFirst = FindMaxSequence(F);
        int[,] S = FindSequence1(second, 0, second.Length - 1);
        answerSecond = FindMaxSequence(S);
        // use FindSequence(array, A, B); from Task_2_28a or entirely Task_2_28a or Task_2_28b
        // A and B - start and end indexes of elements from array for search

        // end
    }
    public int[] FindMaxSequence(int[,] array)
    {
        int maxi = int.MinValue;
        int[] M = new int[2];
        for (int i = 0; i < array.GetLength(0); i++)
        {
            if (array[i, 1] - array[i, 0] > maxi)
            {
                maxi = array[i, 1] - array[i, 0];
                M[0] = array[i, 0];
                M[1] = array[i, 1];
            }

        }
        return M;
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
        SortRowStyle sortStyle = default(SortRowStyle);  //- uncomment me
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            if (i % 2 == 0) sortStyle = SortAscending;
            else sortStyle = SortDescending;
            sortStyle(matrix, i);
        }

    }
    public delegate void SortRowStyle(int[,] matrix, int rowIndex);
    public void SortAscending(int[,] matrix, int rowIndex)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1) - 1 - i; j++)
            {
                if (matrix[rowIndex, j] > matrix[rowIndex, j + 1])
                {
                    int temp = matrix[rowIndex, j];
                    matrix[rowIndex, j] = matrix[rowIndex, j + 1];
                    matrix[rowIndex, j + 1] = temp;
                }
            }
        }
    }
    public void SortDescending(int[,] matrix, int rowIndex)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1) - 1 - i; j++)
            {
                if (matrix[rowIndex, j] < matrix[rowIndex, j + 1])
                {
                    int temp = matrix[rowIndex, j];
                    matrix[rowIndex, j] = matrix[rowIndex, j + 1];
                    matrix[rowIndex, j + 1] = temp;
                }
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
        //GetTriangle getTriangle = default(GetTriangle);
        if (isUpperTriangle)
        {
            answer = GetSum(GetUpperTriange, matrix);
        }
        else
        {
            answer = GetSum(GetLowerTriange, matrix);
        }


        return answer;
    }
    public delegate int[] GetTriangle(int[,] matrix);
    public int[] GetUpperTriange(int[,] matrix)
    {
        int[] array = new int[matrix.GetLength(0) * (matrix.GetLength(0) + 1) / 2];
        int ind = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = i; j < matrix.GetLength(1); j++)
            {
                array[ind] = matrix[i, j];
                ind++;
            }
        }
        return array;
    }
    public int[] GetLowerTriange(int[,] matrix)
    {
        int[] array = new int[matrix.GetLength(0) * (matrix.GetLength(0) + 1) / 2];
        int ind = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j <= i; j++)
            {
                array[ind] = matrix[i, j];
                ind++;
            }
        }
        return array;
    }
    public int GetSum(GetTriangle getTriangle, int[,] matrix)
    {
        int sum = 0;
        int[] array = getTriangle(matrix);
        for (int i = 0; i < array.Length; i++)
        {
            sum += array[i] * array[i];
        }
        return sum;
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
        SwapColumns(matrix, FindDiagonalMaxIndex, FindFirstRowMaxIndex);
    }
    public delegate int FindElementDelegate(int[,]matrix);
    
    public int FindFirstRowMaxIndex(int[,] matrix)
    {
        int maxi = int.MinValue;
        int ind = 0;
        for (int j = 0;j < matrix.GetLength(1); j++)
        {
            if (matrix[1, j] > maxi)
            {
                maxi = matrix[1, j];
                ind = j;
            }
        }
        return ind;
    }
    public int[,] SwapColumns(int [,] matrix, FindElementDelegate findDiagonalMaxIndex , FindElementDelegate findFirstRowMaxIndex)
    {
        int a = findDiagonalMaxIndex(matrix);
        int b = findFirstRowMaxIndex(matrix);
        for (int i = 0;i < matrix.GetLength(0);i++)
        {
            int temp = matrix[i, a];
            matrix[i, a] = matrix[i, b];
            matrix[i, b] = temp;
        }
        return matrix;
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
       // FindIndex searchArea = default(FindIndex);
        RemoveColumns(ref matrix, FindMaxBelowDiagonalIndex, FindMinAboveDiagonalIndex);
    }
    public delegate int FindIndex(int[,]matrix);
    public int FindMaxBelowDiagonalIndex(int[,]matrix)
    {
        int maxi = int.MinValue;
        int ind = 0;
        for(int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j <= i; j++)
            {
                if(matrix[i, j] > maxi)
                {
                    maxi = matrix[i, j];
                    ind = j;
                }
            }
        }
        return ind;
    }
    public int FindMinAboveDiagonalIndex(int[,] matrix)
    {
        int mini = int.MaxValue;
        int ind = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = i + 1; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] < mini)
                {
                    mini = matrix[i, j];
                    ind = j;
                }
            }
        }
        return ind;
    }
    public void RemoveColumns(ref int[,] matrix, FindIndex findMaxBelowDiagonalIndex, FindIndex findMinAboveDiagonalIndex)
    {
        int max = findMaxBelowDiagonalIndex(matrix);
        int min = findMinAboveDiagonalIndex(matrix);
        if (max > min)
        {
            RemoveColumn(ref matrix, max);
            RemoveColumn(ref matrix, min);
        }
        else if (min > max)
        {
            RemoveColumn(ref matrix, min);
            RemoveColumn(ref matrix, max);
        }
        else if(max == min)
        {
            RemoveColumn(ref matrix, max);
        }
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

        
        FindNegatives(matrix, CountNegativeInRows, FindMaxNegativePerColumn, out rows, out cols);
    }
    public delegate int[] GetNegativeArray(int[,]matrix);
    public int[] CountNegativeInRows(int[,] matrix)
    {
        int[] answer = new int[matrix.GetLength(0)];
        
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            int count = 0;
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] < 0)
                {
                    count++;
                }
            }
            answer[i] = count;
        }
        return answer;
    }
    public void FindNegatives(int[,]matrix, GetNegativeArray searcherRows, GetNegativeArray searcherCols, out int [] rows, out int [] cols)
    {
        rows = searcherRows(matrix);
        cols = searcherCols(matrix);
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
    public delegate bool IsSequence(int []array, int left, int right);
    public bool FindIncreasingSequence(int[]array, int A,int  B)
    {
        int d = FindSequence(array, A, B);
        return d == 1;
    }
    public bool FindDecreasingSequence(int[]array,int A,int B)
    {
        int d = FindSequence(array, A, B);
        return d == -1;
    }
    public int DefineSequence(int[]array, IsSequence findIncreasingSequence, IsSequence findDecreasingSequence)
    {
        if (findIncreasingSequence(array, 0, array.Length - 1)) return 1;
        else if (findDecreasingSequence(array,0, array.Length - 1)) return -1;
        else return 0;
    }
    public void Task_3_28c(int[] first, int[] second, ref int[] answerFirstIncrease, ref int[] answerFirstDecrease, ref int[] answerSecondIncrease, ref int[] answerSecondDecrease)
    {
        // code here
        answerFirstDecrease = FindLongestSequence(first, FindDecreasingSequence);
        answerFirstIncrease = FindLongestSequence(first, FindIncreasingSequence);
        answerSecondDecrease = FindLongestSequence(second, FindDecreasingSequence);
        answerSecondIncrease = FindLongestSequence(second, FindIncreasingSequence);
        // create public delegate IsSequence(array, left, right);
        // use method FindIncreasingSequence(array, A, B); from Task_3_28a
        // use method FindDecreasingSequence(array, A, B); from Task_3_28a
        // create and use method FindLongestSequence(array, sequence);

        // end
    }
    public int[] FindLongestSequence(int[]array, IsSequence sequence)
    {
        int A = 0; 
        int B = 0;
        for (int i = 0; i < array.Length; i++)
        {
            for(int j = i + 1;j < array.Length; j++)
            {
                if (sequence(array, i, j) && j - i > B - A)
                {
                    A = i;
                    B = j;
                }
            }
            
        }
        return [A, B];
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
