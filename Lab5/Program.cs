using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Numerics;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Console;

public class Program
{
    public static void Main()
    {
        Program program = new Program();
        int[,] matrix1 = {
            {-1,2,-3,-4},
            {0,-2,4,-5},
            {9,0,3,6},
            {9,-8,7,7}
        };
        int[,] matrix2 = {
            {1,2,3,-4},
            {0,-2,0,-5},
            {9,0,3,6},
            {9,8,7,-7}
        };
        // program.Task_2_28a(new int[] {1,2,-5,-9,-3,4,-1}, new int[] {0,9,-4,-9,-2,5}, ref a, ref b);
        int[] rows; int[] columns;
        // program.Task_2_26(matrix1, matrix2);
        program.Task_3_10(ref matrix1);

    }
    #region Level 1
    public void WriteArr(int[] arr)
    {
        for (int j = 0; j<arr.Length; j++)
        {
            Write($"{arr[j]} ");
        }
        WriteLine("");
    }

    public void WriteArr(int[,] matrix)
    {
        for (int i = 0; i<matrix.GetLength(0); i++)
        {
            for (int j = 0; j<matrix.GetLength(1); j++)
            {
                Write($"{matrix[i,j]} ");
            }
            WriteLine("");
        }
    }
    public long Factorial(int n)
    {
        if (n == 1) return 1;
        return n * Factorial(n-1);
    }
    public long Task_1_1(int n, int k)
    {
        long answer = 0;
        if (k == 0 || k > 0 && k == n) return 1;
        else if (k < 0 || k>n) return 0;

        answer = Factorial(n)/(Factorial(k)*Factorial(n-k));
        return answer;
    }
    
    public double GeronArea(double a, double b, double c)
    {
        double p = (a+b+c)/2;
        double s = Math.Sqrt(p*(p-a)*(p-b)*(p-c));
        return s;
    }
    public int Task_1_2(double[] first, double[] second)
    {
        int answer = 0;
        if (first.Length != 3 || second.Length != 3) return -1;
        for (int i=0; i<3; i++)
        {
            if (first[i] <=0 || second[i] <= 0)
                return -1;              
        }
        double a1 = first[0], b1 = first[1], c1 = first[2];
        double a2 = second[0], b2 = second[1], c2 = second[2];
        if (a1 >= b1+c1 || b1 >= a1+c1 || c1 >= a1+b1 || a2 >= b2+c2 || b2 >= a2+c2 || c2 >= a2+b2) return -1;

        double s1 = GeronArea(a1, b1, c1); 
        double s2 = GeronArea(a2, b2, c2);
        if (s1>s2)
            answer = 1;
        else if (s1<s2)
            answer = 2;
        return answer;
    }


    public double GetDistance(double v, double a, int t)
    {
        double s = v*t + a*t*t/2;
        return s;
    }
    public int Task_1_3a(double v1, double a1, double v2, double a2, int time)
    {
        int answer = 0;
        if (time <= 0 || v1 <= 0 || v2 <= 0 || a1 <= 0 || a2 <= 0) return -1;
        double s1 = GetDistance(v1, a1, time);
        double s2 = GetDistance(v2, a2, time);

        if (s1 > s2)
            answer = 1;
        else if (s1 < s2)
            answer = 2;
        return answer;
    }

    public int Task_1_3b(double v1, double a1, double v2, double a2)
    {
        int answer = 1;
        if (v1 <= 0 || v2 <= 0 || a1 <= 0 || a2 <= 0) return -1;
        double s1 = GetDistance(v1, a1, 1);
        double s2 = GetDistance(v2, a2, 1);
        for (int time = 2; s1 > s2; time++)
        {
            s1 = GetDistance(v1, a1, time);
            s2 = GetDistance(v2, a2, time);
            answer = time;
        }
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
    int FindMaxIndex(double[] array)
    {
        int max_index = 0;
        for (int i = 1; i < array.Length; i++)
            if (array[i] > array[max_index])
                max_index = i;
        return max_index;
    }
    public void Task_2_2(double[] A, double[] B)
    {
        int max_indexA = FindMaxIndex(A);
        int max_indexB = FindMaxIndex(B);
        double[] arr; int max_index;
        if (A.Length - max_indexA > B.Length - max_indexB)
        {
            arr = A;
            max_index = max_indexA;
        }
        else 
        {
            arr = B;
            max_index = max_indexB;
        }
        double mid = 0, n = 0;
        for (int i = max_index + 1; i < arr.Length; i++)
        {
            mid += arr[i];
            n ++;
        }
        mid /= n;
        double max = arr[max_index];
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == max) arr[i] = mid;
        }
    }

    public void Task_2_3(ref int[,] B, ref int[,] C)
    {
        // code here

        //  create and use method FindDiagonalMaxIndex(matrix);

        // end
    }

    public int FindDiagonalMaxIndex(int[,] matrix)
    {
        int max_index = 0;
        for (int i = 0; i<matrix.GetLength(0); i++)
        {
            if (matrix[max_index,max_index]<matrix[i,i])
                max_index = i;
        }
        return max_index;
    }

    public void Task_2_4(int[,] A, int[,] B)
    { 
        int max_indexA = FindDiagonalMaxIndex(A);
        int max_indexB = FindDiagonalMaxIndex(B);

        int[] C = new int[5];
        for (int i = 0; i<A.GetLength(0); i++)
        {
            C[i] = A[max_indexA,i];
            A[max_indexA,i] = B[i,max_indexB];
            B[i,max_indexB] = C[i];
        }
    }

    public void Task_2_5(int[,] A, int[,] B)
    {
        // code here

        // create and use FindMaxInColumn(matrix, columnIndex, out rowIndex);

        // end
    }

    public int[] DeleteElement(ref int[] arr, int index)
    {
        int[] C = new int[arr.Length-1];
        for (int i = 0; i<arr.Length; i++)
        {
            if (i < index)
                C[i] = arr[i];
            else if (i > index)
                C[i-1] = arr[i];
        }
        arr = C;
        return arr;
    }
    public int FindMax(int[] arr)
    {
        int max_index = 0;
        for (int i=0; i<arr.Length; i++)
        {
            if (arr[max_index] < arr[i])
                max_index = i;   
        }
        return max_index;
    }
    public void Task_2_6(ref int[] A, int[] B)
    {
        int max_indexA = FindMax(A);
        int max_indexB = FindMax(B);
        DeleteElement(ref A, max_indexA);
        DeleteElement(ref B, max_indexB);
        
        int[] C = new int[A.Length+B.Length];
        for (int i = 0; i<A.Length+B.Length; i++)
        {
            if (i<A.Length)
                C[i] = A[i];
            else
                C[i] = B[i-A.Length];
        }
        A = C;
    }

    public void Task_2_7(ref int[,] B, int[,] C)
    {
        // code here

        // create and use CountRowPositive(matrix, rowIndex);
        // create and use CountColumnPositive(matrix, colIndex);

        // end
    }

    public int[] SortArrayPart(ref int[] arr, int index)
    {
        // гномья сортировка
        for (int i = index+2, j = index+3; i<arr.Length;)
        {
            if (i == index+1 || arr[i] >= arr[i-1])
            {
                i = j;
                j++;
            }
            else
            {
                int temp = arr[i];
                arr[i] = arr[i-1];
                arr[i-1] = temp;
                i--;
            }
        }

        return arr;
    }
    public void Task_2_8(int[] A, int[] B)
    {
        int max_indexA = FindMax(A);
        int max_indexB = FindMax(B);
        SortArrayPart(ref A, max_indexA);
        SortArrayPart(ref B, max_indexB);
    }

    public int[] Task_2_9(int[,] A, int[,] C)
    {
        int[] answer = default(int[]);

        // code here

        // create and use SumPositiveElementsInColumns(matrix);

        // end

        return answer;
    }

    public int[,] RemoveColumn(ref int[,] matrix, int index)
    {
        int n = matrix.GetLength(0), m = matrix.GetLength(1);
        int[,] C = new int[n,m-1];
        for (int j = 0; j<m;j++)
        {
            for (int i = 0; i<n; i++)
            {
                if (j<index)
                    C[i,j] = matrix[i,j];
                else if (j>index)
                    C[i,j-1] = matrix[i,j];
            }
        }
        matrix = C;
        return matrix;
    }

    public void Task_2_10(ref int[,] matrix)
    {
        int n = matrix.GetLength(0);
        int max_index = 0, min_index = 0;
        int max = matrix[0,0], min = matrix[0,1];
        for (int i = 0; i<n; i++)
        {
            for (int j = 0; j<i+1; j++)
            {
                if (matrix[i,j]>max)
                {
                    max = matrix[i,j];
                    max_index = j;
                }
            }
            for (int k = i+1; k<n; k++)
            {
                if (matrix[i,k]<min)
                {
                    min = matrix[i,k];
                    min_index = k;
                }
            }
        }

        if (max_index != min_index && max_index>min_index)
        {
            RemoveColumn(ref matrix, max_index);
            RemoveColumn(ref matrix, min_index);
        }
        else if (max_index != min_index && max_index<min_index)
        {
            RemoveColumn(ref matrix, min_index);
            RemoveColumn(ref matrix, max_index);
        }
        else
            RemoveColumn(ref matrix, min_index);
    }

    public void Task_2_11(int[,] A, int[,] B)
    {
        // code here

        // use FindMaxIndex(matrix, out row, out column); from Task_2_1

        // end
    }
    public int FindMaxColumnIndex(int[,] matrix)
    {
        int max_index = 0; int max = matrix[0,0];
        for (int i = 0; i<matrix.GetLength(0); i++)
        {
            for (int j = 0; j<matrix.GetLength(1); j++)
            {
                if (matrix[i,j]>max)
                {
                    max = matrix[i,j];
                    max_index = j;
                }
            }
        }
        return max_index;
    }
    public void Task_2_12(int[,] A, int[,] B)
    {
        int max_indexA = FindMaxColumnIndex(A);
        int max_indexB = FindMaxColumnIndex(B);
        for (int i = 0; i<A.GetLength(0); i++)
        {
            int temp = A[i,max_indexA];
            A[i,max_indexA] = B[i,max_indexB];
            B[i,max_indexB] = temp;
        }
    }

    public void Task_2_13(ref int[,] matrix)
    {
        // code here

        // create and use RemoveRow(matrix, rowIndex);

        // end
    }

    public int[,] SortRow(ref int[,] matrix, int index)
    {
        // гномья сортировка
        for (int i = 1, j = 2; i<matrix.GetLength(1);)
        {
            if (i==0 || matrix[index,i]>matrix[index,i-1])
            {
                i = j;
                j++;
            }
            else
            {
                int temp = matrix[index,i];
                matrix[index,i] = matrix[index,i-1];
                matrix[index,i-1] = temp;
                i--;
            }
        }
        return matrix;
    }
    public void Task_2_14(int[,] matrix)
    {
        for (int i = 0; i<matrix.GetLength(0);i++)
            SortRow(ref matrix, i);
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

    public int[] SortNegative(ref int[] matrix)
    {
        int negCount = 0;
        for (int i = 0; i<matrix.Length; i++)
        {
            if (matrix[i]<0)
                negCount++;
        }
        if (negCount == 0 || negCount == 1) return matrix;

        int[] negative = new int[negCount];
        for (int i = 0, j = 0; i<matrix.Length; i++)
        {
            if (matrix[i]<0)
            {
                negative[j] = matrix[i];
                j++;
            }
        }
        // сортировка
        for (int i = 1, j = 2; i<negative.Length;)
        {
            if (i==0 || negative[i]<negative[i-1])
            {
                i = j;
                j++;
            }
            else
            {
                int temp = negative[i];
                negative[i] = negative[i-1];
                negative[i-1] = temp;
                i--;
            }
        }
        int l = 0;
        for (int i = 0; i<matrix.Length; i++)
        {
            if (matrix[i]<0)
            {
                matrix[i] = negative[l];
                l++;
            }
        }
        return matrix;
    }

    public void Task_2_16(int[] A, int[] B)
    {
        SortNegative(ref A);
        SortNegative(ref B);
    }

    public void Task_2_17(int[,] A, int[,] B)
    {
        // code here

        // create and use SortRowsByMaxElement(matrix);

        // end
    }

    public int[,] SortDiagonal(ref int[,] matrix)
    {
        for (int i = 1, j = 2; i<matrix.GetLength(0);)
        {
            if (i == 0 || matrix[i,i]>=matrix[i-1,i-1])
            {
                i = j;
                j++;
            }
            else
            {
                int temp = matrix[i,i];
                matrix[i,i] = matrix[i-1,i-1];
                matrix[i-1,i-1] = temp;
                i--;
            }
        }
        return matrix;
    }

    public void Task_2_18(int[,] A, int[,] B)
    {
        SortDiagonal(ref A);
        SortDiagonal(ref B);
    }


    public void Task_2_19(ref int[,] matrix)
    {
        // code here

        // use RemoveRow(matrix, rowIndex); from 2_13

        // end
    }
    public int[,] RemoveAllColumns(ref int[,] arr)
    {
        for (int j = 0; j<arr.GetLength(1); j++)
        {
            bool nul = false;
            for (int i = 0; i<arr.GetLength(0);i++)
            {
                if (arr[i,j] == 0)
                {
                    nul = true;
                    break;
                }
            }
            if (nul == false)
            {
                RemoveColumn(ref arr, j);
                j--;
            }
        }
        return arr;
    }
    public void Task_2_20(ref int[,] A, ref int[,] B)
    {
        RemoveAllColumns(ref A);
        RemoveAllColumns(ref B);
    }    

    public void Task_2_21(int[,] A, int[,] B, out int[] answerA, out int[] answerB)
    {
        answerA = null;
        answerB = null;

        // code here

        // create and use CreateArrayFromMins(matrix);

        // end
    }

    public int[] GetNegativeCountPerRow(int[,] matrix)
    {
        int[] arr = new int[matrix.GetLength(0)];
        for (int i = 0; i<arr.GetLength(0); i++)
        {
            int count = 0;
            for (int j = 0; j<matrix.GetLength(1); j++)
            {
                if (matrix[i,j] < 0)
                    count++;
            }
            arr[i] = count;
        }
        return arr;
    }

    public int[] GetMaxNegativePerColumn(int[,] matrix)
    {
        int[] arr = new int[matrix.GetLength(1)];
        for (int j = 0; j<arr.Length; j++)
        {
            int count = 0;
            for (int i = 0; i<matrix.GetLength(0); i++)
            {
                if (matrix[i,j]<0)
                    count++;
            }

            if (count == 0) 
            {
                arr[j] = 0;
                continue;
            }

            int max_index = 0;
            for (int i = 0; i<matrix.GetLength(0); i++)
            {
                if (matrix[max_index,j]>=0)
                    max_index = i+1;
                else if (matrix[i,j] < 0 && matrix[i,j]>matrix[max_index,j])
                    max_index = i;
            }
            arr[j] = matrix[max_index,j];
        }
        return arr;
    }

    public void Task_2_22(int[,] matrix, out int[] rows, out int[] cols)
    {
        rows = GetNegativeCountPerRow(matrix);
        cols = GetMaxNegativePerColumn(matrix);
    }

    public void Task_2_23(double[,] A, double[,] B)
    {
        // code here

        // create and use MatrixValuesChange(matrix);

        // end
    }

    public int FindMax(int[,] matrix)
    {
        int max_index = 0; int max = matrix[0,0];
        for (int i = 0; i<matrix.GetLength(0); i++)
        {
            for (int j = 0; j<matrix.GetLength(1); j++)
            {
                if (matrix[i,j]>max)
                {
                    max = matrix[i,j];
                    max_index = j;
                }
            }
        }
        return max_index;
    }

    public int[,] ChangeDiagonalAndMaxColumn(ref int[,] matrix, int index)
    {
        int[] C = new int[matrix.GetLength(1)];
        for (int i = 0; i<matrix.GetLength(0); i++)
        {
            C[i] = matrix[i,i];
            matrix[i,i] = matrix[i,index];
            matrix[i,index] = C[i];
        }
        return matrix;
    }
    public void Task_2_24(int[,] A, int[,] B)
    {
        int max_indexA = FindMax(A);
        int max_indexB = FindMax(B);

        ChangeDiagonalAndMaxColumn(ref A,max_indexA);
        ChangeDiagonalAndMaxColumn(ref B, max_indexB);
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

    public int FindMaxIndex(int[] arr)
    {
        int max_index = 0; 
        for (int i = 0; i<arr.Length-1; i++)
        {
            if (arr[i] > arr[max_index])
                max_index = i;
        }
        return max_index;
    }
    public void Task_2_26(int[,] A, int[,] B)
    {
        int[] negmaxCountA = GetNegativeCountPerRow(A);
        int[] negmaxCountB = GetNegativeCountPerRow(B);

        int indexA = FindMaxIndex(negmaxCountA);
        int indexB = FindMaxIndex(negmaxCountB);
        int[] C = new int[A.GetLength(1)];
        for (int j =0; j<A.GetLength(1); j++)
        {
            C[j] = A[indexA,j];
            A[indexA,j] = B[indexB,j];
            B[indexB,j] = C[j];
        }
    }

    public void Task_2_27(int[,] A, int[,] B)
    {
        // code here

        // create and use FindRowMaxIndex(matrix, rowIndex, out columnIndex);
        // create and use ReplaceMaxElementOdd(matrix, row, column);
        // create and use ReplaceMaxElementEven(matrix, row, column);

        // end
    }

    public int FindSequence(int[] arr, int A, int B)
    {
        if (A >= B) return 0;
        bool isSeq = arr[A] < arr[A + 1];
        for (int i = A; i < B; i++)
        {
            if (isSeq && arr[i] > arr[i + 1]) return 0;
            if (!isSeq && arr[i] < arr[i + 1]) return 0;
        }
        return (isSeq?1:-1);
    }

    public void Task_2_28a(int[] first, int[] second, ref int answerFirst, ref int answerSecond)
    {
        answerFirst = FindSequence(first, 0, first.Length-1);
        answerSecond = FindSequence(second, 0, second.Length-1);
    }

    public void Task_2_28b(int[] first, int[] second, ref int[,] answerFirst, ref int[,] answerSecond)
    {
        
        int n = 0;
        for (int i = 0; i < first.Length; i++)
        {
            for (int j = i + 1; j < first.Length; j++)
            {
                int isSeq = FindSequence(first, i, j);
                if (isSeq != 0) n++;
            }
        }
        answerFirst = new int[n, 2];
        n = 0;
        for (int i = 0; i < first.Length; i++)
        {
            for (int j = i + 1; j < first.Length; j++)
            {
                int isSeq = FindSequence(first, i, j);
                if (isSeq != 0)
                {
                    answerFirst[n, 0] = i;
                    answerFirst[n, 1] = j;
                    n++;
                }
            }
        }

        n = 0;
        for (int i = 0; i < second.Length; i++)
        {
            for (int j = i + 1; j < second.Length; j++)
            {
                int isSeq = FindSequence(second, i, j);
                if (isSeq != 0) n++;
            }
        }
        answerSecond = new int[n, 2];
        n = 0;
        for (int i = 0; i < second.Length; i++)
        {
            for (int j = i + 1; j < second.Length; j++)
            {
                int isSeq = FindSequence(second, i, j);
                if (isSeq != 0)
                {
                    answerSecond[n, 0] = i;
                    answerSecond[n, 1] = j;
                    n++;
                }
            }
        }
    }

    public void Task_2_28c(int[] first, int[] second, ref int[] answerFirst, ref int[] answerSecond)
    {
        int a = 0, b = 0;
        for (int i = 0; i < first.Length; i++)
        {
            for (int j = i + 1; j < first.Length; j++)
            {
                int isSeq = FindSequence(first, i, j);
                if (isSeq != 0 && b - a < j - i)
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
                int isSeq = FindSequence(second, i, j);
                if (isSeq != 0 && b - a < j - i)
                {
                    a = i;
                    b = j;
                }
            }
        }
        answerSecond = new int[] { a, b };
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

    public delegate void SortRowStyle(ref int[,] arr, int i);
    public void SortAscending(ref int[,] arr, int i)
    {
        for (int j = 1; j<arr.GetLength(1); j++)
        {
            int key = arr[i,j]; int jj = j-1;
            while (jj>=0 && arr[i,jj]>key)
            {
                arr[i,jj+1] = arr[i,jj];
                jj--;
            }
            arr[i,jj+1] = key;
        }
    }
    public void SortDescending(ref int[,] arr, int i)
    {
        for (int j = 1; j<arr.GetLength(1); j++)
        {
            int key = arr[i,j]; int jj = j-1;
            while (jj>=0 && arr[i,jj]<key)
            {
                arr[i,jj+1] = arr[i,jj];
                jj--;
            }
            arr[i,jj+1] = key;
        }
    }
    public void Task_3_2(int[,] matrix)
    {
        SortRowStyle sortStyle = default(SortRowStyle);
        for (int i = 0; i<matrix.GetLength(0); i++)
        {
            sortStyle = (i%2 == 0)?SortAscending:SortDescending;
            sortStyle(ref matrix,i);
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

    public delegate int[] GetTriangle(int[,] arr);
    public int[] GetUpperTriange(int[,] arr)
    {
        int n = arr.GetLength(0);
        int[] triangle = new int[n*(n+1)/2];
        int a = 0;
        for (int i = 0; i<n; i++)
        {
            for (int j = i; j<n; j++)
            {
                triangle[a] = arr[i,j];
                a++;
            }
        }
        return triangle;
    }
    public int[] GetLowerTriange(int[,] arr)
    {
        int n = arr.GetLength(0);
        int[] triangle = new int[n*(n+1)/2];
        int a = 0;
        for (int i = 0; i<n; i++)
        {
            for (int j = 0; j<=i; j++)
            {
                triangle[a] = arr[i,j];
                a++;
            }
        }
        return triangle;
    }
    
    public int GetSum(GetTriangle getTriangle, int[,] arr)
    {
        int sum = 0;
        int[] array = getTriangle(arr);
        for (int i = 0; i<array.Length; i++)
            sum += array[i]*array[i];
        return sum;
    }
    public int Task_3_4(int[,] matrix, bool isUpperTriangle)
    {
        int answer = 0;
        GetTriangle getTriangle = default(GetTriangle);
        getTriangle = (isUpperTriangle)?GetUpperTriange:GetLowerTriange;
        answer = GetSum(getTriangle,matrix);
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

    public delegate int FindElementDelegate(int[,] arr);
    public int FindFirstRowMaxIndex(int[,] arr)
    {
        int max_index = 0;
        for (int j = 0; j<arr.GetLength(1); j++)
        {
            if (arr[0,j] > arr[0,max_index])
                max_index = j;
        }
        return max_index;
    }

    public void SwapColumns(ref int[,] arr, FindElementDelegate findDiagonalMaxIndex, FindElementDelegate findFirstRowMaxIndex)
    {
        int[] C = new int[arr.GetLength(1)];
        int a = FindDiagonalMaxIndex(arr);
        int b = findFirstRowMaxIndex(arr);
        if (a == b) return;
        for (int i = 0; i<arr.GetLength(0); i++)
        {
            C[i] = arr[i,a];
            arr[i,a] = arr[i,b];
            arr[i,b] = C[i];
        }
    }
    public void Task_3_6(int[,] matrix)
    {
        SwapColumns(ref matrix, FindDiagonalMaxIndex, FindFirstRowMaxIndex);
    }

    public void Task_3_7(ref int[,] B, int[,] C)
    {
        // create and use public delegate CountPositive(matrix, index);
        // use CountRowPositive(matrix, rowIndex) from Task_2_7
        // use CountColumnPositive(matrix, colIndex) from Task_2_7
        // create and use method InsertColumn(matrixB, CountRow, matrixC, CountColumn);

        // end
    }

    public delegate int FindIndex(int[,] arr);
    public int FindMaxBelowDiagonalIndex(int[,] arr)
    {
        int max = arr[0,0]; int max_index = 0;
        for (int i = 0; i<arr.GetLength(0); i++)
        {
            for (int j = 0; j<=i; j++)
            {
                if (max<arr[i,j])
                {
                    max = arr[i,j];
                    max_index = j;
                }
            }
        }
        return max_index;
    }
    public int FindMinAboveDiagonalIndex(int[,] arr)
    {
        int min = arr[0,0]; int min_index = 0;
        for (int i = 0; i<arr.GetLength(0)-1; i++)
        {
            for (int j =i+1; j<arr.GetLength(1); j++)
            {
                if (min>arr[i,j])
                {
                    min = arr[i,j];
                    min_index = j;
                }
            }
        }
        return min_index;
    }
    public void RemoveColumns(ref int[,] arr, FindIndex findMaxBelowDiagonalIndex,FindIndex findMinAboveDiagonalIndex)
    {
        int first = findMaxBelowDiagonalIndex(arr);
        int second = findMinAboveDiagonalIndex(arr);
        Write($"{first} {second}");
        if (first == second)
            RemoveColumn(ref arr, first);
        else if (first>second)
        {
            RemoveColumn(ref arr, first);
            RemoveColumn(ref arr, second);
        }
        else
        {
            RemoveColumn(ref arr, second);
            RemoveColumn(ref arr, first);
        }
    }
    public void Task_3_10(ref int[,] matrix)
    {
        FindIndex searchArea = default(FindIndex);
        RemoveColumns(ref matrix, FindMaxBelowDiagonalIndex, FindMinAboveDiagonalIndex);
    }

    public void Task_3_13(ref int[,] matrix)
    {
        // code here

        // use public delegate FindElementDelegate(matrix) from Task_3_6
        // create and use method RemoveRows(matrix, findMax, findMin)

        // end
    }

    public delegate int[] GetNegativeArray(int[,] arr);
    public void FindNegatives(int[,] arr, GetNegativeArray searcherRows, GetNegativeArray searcherCols, out int[] rows, out int[] cols)
    {
        rows = searcherRows(arr);
        cols = searcherCols(arr);
    }
    public void Task_3_22(int[,] matrix, out int[] rows, out int[] cols)
    {
        rows = null;
        cols = null;

        FindNegatives(matrix, GetNegativeCountPerRow, GetMaxNegativePerColumn, out rows, out cols);
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

    public delegate bool IsSequence(int[] arr, int left, int right);
    
    public bool findIncreasingSequence(int[] arr, int a, int b)
    {
        int c = FindSequence(arr,a,b);
        return (c == 1);
    }
    public bool findDecreasingSequence(int[] arr, int a, int b)
    {
        int c = FindSequence(arr,a,b);
        return (c == -1);
    }
    public int DefineSequence(int[] arr, IsSequence findIncreasingSequence, IsSequence findDecreasingSequence)
    {
        if (findIncreasingSequence(arr,0,arr.Length-1))
            return 1;
        else if (findDecreasingSequence(arr,0,arr.Length-1))
            return -1;
        else
            return 0;
    }
    public void Task_3_28a(int[] first, int[] second, ref int answerFirst, ref int answerSecond)
    {
        answerFirst = DefineSequence(first, findIncreasingSequence, findDecreasingSequence);
        answerSecond = DefineSequence(second, findIncreasingSequence, findDecreasingSequence);
    }

    public int[] FindLongestSequence(int[] arr, IsSequence sequence)
    {
        int a = 0, b = 0;
        for (int i = 0; i <  arr.Length; i++)
            for (int j = i + 1; j < arr.Length; j++)
                if (sequence(arr, i, j) && j - i > b-a)
                {
                    a = i; 
                    b = j;
                }
        return [a, b];
    }
    public void Task_3_28c(int[] first, int[] second, ref int[] answerFirstIncrease, ref int[] answerFirstDecrease, ref int[] answerSecondIncrease, ref int[] answerSecondDecrease)
    {
        answerFirstDecrease = FindLongestSequence(first, findDecreasingSequence);
        answerFirstIncrease = FindLongestSequence(first, findIncreasingSequence);
        answerSecondDecrease = FindLongestSequence(second, findDecreasingSequence);
        answerSecondIncrease = FindLongestSequence(second, findIncreasingSequence);
    }
    #endregion
    #region bonus part

    public delegate int[] MatrixConverter(int[,] arr);
    public int[,] ToUpperTriangular(int[,] arr)
    {
        return arr;
    }
    public int[,] ToLowerTriangular(int[,] arr)
    {
        return arr;
    }
    public double[,] Task_4(double[,] matrix, int index)
    {
        MatrixConverter[] mc = new MatrixConverter[4];

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
