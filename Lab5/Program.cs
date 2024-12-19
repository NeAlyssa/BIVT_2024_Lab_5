using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Numerics;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;
using String = System.String;


public class Program
{
    const double Eps = 0.0001001;
    public static void Main()
    {
        Program program = new Program();
    }
    #region Level 1
    
    public long Factorial(int n) 
    {
        if(n < 0) return 0;
        long res = 1;
        for(long i = 2; i <= n; i++) res *= i;
        return res;
    }


    public long Combinations(int n, int k)
    {
        return Factorial(n) / (Factorial(k) * Factorial(n - k));
    }
    
    public long Task_1_1(int n, int k)
    {
        
        if(k > n || n < 0 || k < 0) return 0;
        long answer = Combinations(n, k);
        return answer;
    }
    
    public double GeronArea(double a, double b, double c) 
    {
        double p = (a + b + c) / 2;
        return Math.Sqrt(p*(p-a)*(p-b)*(p-c));
    }
    
    public bool IsTriangleExists(double a, double b, double c) 
    {
        return !(a + b <= c || a + c <= b || b + c <= a);
    }
    
    public int Task_1_2(double[] first, double[] second)
    {
        // create and use GeronArea(a, b, c);
        // first = 1, second = 2, equal = 0, error = -1
        
        if(!IsTriangleExists(first[0], first[1], first[2]) || !IsTriangleExists(second[0], second[1], second[2])) return -1; 
        double S1 = GeronArea(first[0], first[1], first[2]), S2 = GeronArea(second[0], second[1], second[2]); 
        if(S1 == S2) return 0;
        else if(S1 > S2) return 1;
        else return 2;
    }

    public double GetDistance(double v, double a, int t) 
    {
        return v*t + a*t*t/2;
    }
    
    public int Task_1_3a(double v1, double a1, double v2, double a2, int time)
    {

        if(v1 < 0 || a1 < 0 || v2 < 0 || a2 < 0 || time < 0) return -1;
        
        double d1 = GetDistance(v1, a1, time), d2 = GetDistance(v2, a2, time);
        
        if(d1 == d2) return 0;
        else if (d1 > d2) return 1;
        else return 2;
        
    }

    public int Task_1_3b(double v1, double a1, double v2, double a2)
    {
        double s1, s2;
        for (int t = 1;; t++)
        {
            s1 = GetDistance(v1, a1, t);
            s2 = GetDistance(v2, a2, t);
            if (s1 <= s2) return t;
        }
    }
    #endregion

    #region Level 2

    public void FindMaxIndex(int[,] matrix, out int row, out int column)
    {
        int mx = int.MinValue;
        row = -1; column = -1;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] > mx)
                {
                    mx = matrix[i, j];
                    row = i; column = j;
                }
            }
        }
    }  
    
    public void FindMinIndex(int[,] matrix, out int row, out int column)
    {
        int mn = int.MaxValue;
        row = -1; column = -1;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] < mn)
                {
                    mn = matrix[i, j];
                    row = i; column = j;
                }
            }
        }
    }  
    
    public void Task_2_1(int[,] A, int[,] B)
    {
        int rowA, columnA, rowB, columnB, temp;
        FindMaxIndex(A, out rowA, out columnA);
        FindMaxIndex(B, out rowB, out columnB);
        (A[rowA, columnA], B[rowB, columnB]) = (B[rowB, columnB], A[rowA, columnA]);
    }

    public void Task_2_2(double[] A, double[] B)
    {
        // code here

        // create and use FindMaxIndex(array);
        // only 1 array has to be changed!

        // end
    }

    public int FindDiagonalMaxIndex(int[,] matrix)
    {
        int mx = int.MinValue, ind = -1;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            if (matrix[i, i] > mx)
            {
                mx = matrix[i,i]; 
                ind = i;
            }
        }

        return ind;
    }

    public int[,] RemoveRow(int[,] matrix, int row)
    {
        int rows = matrix.GetLength(0), cols = matrix.GetLength(1), r = 0;
        int[,] newMatrix = new int[rows - 1, cols];
        for (int i = 0; i < rows; i++)
        {
            if (i == row) continue;
            for (int j = 0; j < cols; j++) newMatrix[r, j] = matrix[i, j];
            r++;
        }
        return newMatrix;
    }
    
    public void Task_2_3(ref int[,] B, ref int[,] C)
    {
        B = RemoveRow(B, FindDiagonalMaxIndex(B));
        C = RemoveRow(C, FindDiagonalMaxIndex(C));
    }

    public void Task_2_4(int[,] A, int[,] B)
    {
        // code here

        //  create and use method FindDiagonalMaxIndex(matrix); like in Task_2_3

        // end
    }

    public void FindMaxInColumn(int[,] matrix, int columnIndex, out int rowIndex)
    {
        int rows = matrix.GetLength(0), max = int.MinValue;
        rowIndex = -1;
        for (int i = 0; i < rows; i++)
        {
            if (matrix[i, columnIndex] > max)
            {
                max = matrix[i, columnIndex];
                rowIndex = i;
            }
        }
    }
    
    public void Task_2_5(int[,] A, int[,] B)
    {
        int rowA, rowB;
        FindMaxInColumn(A, 1, out rowA);
        FindMaxInColumn(B, 1, out rowB);
        for(int i = 0; i < 6; i++) (A[rowA, i], B[rowB, i]) = (B[rowB, i], A[rowA, i]);
    }

    public void Task_2_6(ref int[] A, int[] B)
    {
        // code here

        // create and use FindMax(matrix, out row, out column); like in Task_2_1
        // create and use DeleteElement(array, index);

        // end
    }

    public int CountRowPositive(int[,] matrix, int rowIndex)
    {
        int cols = matrix.GetLength(1), count = 0;
        for (int j = 0; j < cols; j++)
        {
            if (matrix[rowIndex, j] > 0) count++;
        }
        return count;
    }

    public int CountColumnPositive(int[,] matrix, int colIndex)
    {
        int rows = matrix.GetLength(0), count = 0;
        for (int i = 0; i < rows; i++)
        {
            if (matrix[i, colIndex] > 0) count++;
        }
        return count;
    }
    
    
    public void Task_2_7(ref int[,] B, int[,] C)
    {
        // code here

        int maxRowPositives = int.MinValue, maxRowIndex = -1, positives;
        int maxColPositives = int.MinValue, maxColIndex = -1, r = 0;

        for (int i = 0; i < B.GetLength(0); i++)
        {
            positives = CountRowPositive(B, i);
            if (positives > maxRowPositives)
            {
                maxRowPositives = positives;
                maxRowIndex = i;
            }
        }
        for (int j = 0; j < C.GetLength(1); j++)
        {
            positives = CountColumnPositive(C, j);
            if (positives > maxColPositives)
            {
                maxColPositives = positives;
                maxColIndex = j;
            }
        }

        int[] toInsert = new int[C.GetLength(0)];
        for (int i = 0; i < C.GetLength(0); i++) toInsert[i] = C[i, maxColIndex];
        
        int[,] newB = new int[B.GetLength(0) + 1, B.GetLength(1)];

        for (int i = 0; i < B.GetLength(0); i++)
        {
            for (int j = 0; j < B.GetLength(1); j++) newB[r, j] = B[i, j];

            if (i == maxRowIndex)
            {
                r++;
                for (int j = 0; j < toInsert.Length; j++) newB[r, j] = toInsert[j];
            }
            r++;
        }

        B = newB;
    }

    public void Task_2_8(int[] A, int[] B)
    {
        // code here

        // create and use SortArrayPart(array, startIndex);

        // end
    }

    public int[] SumPositiveElementsInColumns(int[,] matrix)
    {
        int rows = matrix.GetLength(0), cols = matrix.GetLength(1), sum;
        int[] columnSums = new int[cols];
        for (int j = 0; j < cols; j++)
        {
            sum = 0;
            for (int i = 0; i < rows; i++)
            {
                if (matrix[i, j] > 0) sum += matrix[i, j];
            }
            columnSums[j] = sum;
        }
        return columnSums;
    }
    
    public int[] Task_2_9(int[,] A, int[,] C)
    {

        int[] sumA = SumPositiveElementsInColumns(A), sumC= SumPositiveElementsInColumns(C);
        int[] answer = new int[sumA.Length + sumC.Length];

        int r = 0;
        for (int i = 0; i < sumA.Length; i++)
        {
            answer[r] = sumA[i];
            r++;
        }

        for (int i = 0; i < sumC.Length; i++)
        {
            answer[r] = sumC[i];
            r++;
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

        FindMaxIndex(A, out int rowA, out int colA);
        FindMaxIndex(B, out int rowB, out int colB);
        (A[rowA, colA], B[rowB, colB]) = (B[rowB, colB], A[rowA, colA]);
        
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
        FindMinIndex(matrix, out int rowMin, out _);
        FindMaxIndex(matrix, out int rowMax, out _);
        
        if(rowMin == rowMax) matrix = RemoveRow(matrix, rowMin);
        else if(rowMin > rowMax) matrix = RemoveRow(RemoveRow(matrix, rowMin), rowMax);
        else matrix = RemoveRow(RemoveRow(matrix, rowMin), rowMax - 1);
    }

    public void Task_2_14(int[,] matrix)
    {
        // code here

        // create and use SortRow(matrix, rowIndex);

        // end
    }

    public double GetAverageWithoutMinMax(int[,] matrix)
    {
        double sum = 0;
        int mx = int.MinValue, mn = int.MaxValue;
        int n = matrix.GetLength(0), m = matrix.GetLength(1);
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                sum += matrix[i, j];
                if (matrix[i, j] > mx) mx = matrix[i, j];
                if (matrix[i, j] < mn) mn = matrix[i, j];
            }
        }

        if (mn == mx) return (sum - mn) / (n * m);
        else return (sum - mn - mx) / (n * m);

    }
    
    public int Task_2_15(int[,] A, int[,] B, int[,] C)
    {

        double[] arr = { GetAverageWithoutMinMax(A), GetAverageWithoutMinMax(B), GetAverageWithoutMinMax(C) };

        if (arr[0] == arr[1] && arr[1] == arr[2]) return 0;
        if (arr[0] >= arr[1] && arr[1] >= arr[2]) return -1;
        if (arr[0] <= arr[1] && arr[1] <= arr[2]) return 1;
        return 0;
        
        // 1 - increasing   0 - no sequence   -1 - decreasing
    }

    public void Task_2_16(int[] A, int[] B)
    {
        // code here

        // create and use SortNegative(array);

        // end
    }

    public void SwapRows(int[,] matrix, int row1, int row2)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        for (int j = 0; j < cols; j++) (matrix[row1, j], matrix[row2, j]) = (matrix[row2, j], matrix[row1, j]);
    }
    
    public int[] GetMaxElementsOfRows(int[,] matrix)
    {
        int rows = matrix.GetLength(0), cols = matrix.GetLength(1), max;
        int[] maxElements = new int[rows];
        for (int i = 0; i < rows; i++)
        {
            max = int.MinValue;
            for (int j = 0; j < cols; j++)
            {
                if (matrix[i, j] > max) max = matrix[i, j];
            }
            maxElements[i] = max;
        }
        return maxElements;
    }

    public void SortRowsByMaxElement(int[,] matrix, int mode)
    {
        
        int[] maxElements = GetMaxElementsOfRows(matrix);
        for (int i = 1, j = 2; i < maxElements.Length;)
        {
            if (i == 0 || Compare(maxElements[i], maxElements[i - 1], mode))
            {
                i = j;
                j++;
            }
            else
            {
                (maxElements[i], maxElements[i - 1]) = (maxElements[i - 1], maxElements[i]);
                SwapRows(matrix, i, i - 1);
                i--;
            }
        }

        bool Compare(int a, int b, int mode)
        {
            if (mode > 0) return a >= b;
            else return a <= b;
        }
    }
    
    public void Task_2_17(int[,] A, int[,] B)
    {
        SortRowsByMaxElement(A, -1);
        SortRowsByMaxElement(B, -1);
    }

    public void Task_2_18(int[,] A, int[,] B)
    {
        // code here

        // create and use SortDiagonal(matrix);

        // end
    }

    public void Task_2_19(ref int[,] matrix)
    {
        for (int i = matrix.GetLength(0) - 1; i >= 0; i--)
        {
            bool flag = false;
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] == 0)
                {
                    flag = true;
                    break;
                }
            }
            if(flag) matrix = RemoveRow(matrix, i);
        }
    }
    public void Task_2_20(ref int[,] A, ref int[,] B)
    {
        // code here

        // use RemoveColumn(matrix, columnIndex); from 2_10

        // end
    }

    public int[] CreateArrayFromMins(int[,] matrix)
    {
        int[] arr = new int[matrix.GetLength(0)];
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            int mn = int.MaxValue;
            for (int j = i; j < matrix.GetLength(1); j++)
            {
                if(matrix[i, j] < mn) mn = matrix[i, j];
            }
            arr[i] = mn;
        }
        return arr;
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

        // create and use CountNegativeInRow(matrix, rowIndex);
        // create and use FindMaxNegativePerColumn(matrix);

        // end
    }

    public void MatrixValuesChange(ref double[,] matrix)
    {
        int n = matrix.GetLength(0), m = matrix.GetLength(1);
        double[] matrix1d = new double[n*m];
        int[][] ind = new int[n*m][];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                matrix1d[i * m + j] = matrix[i, j];
                ind[i * m + j] = new int[] { i, j };
            }
        }
        
        for (int i = 0; i < n * m; i++)
        {
            for (int j = 0; j < (n * m) - i - 1; j++)
            {
                if (matrix1d[j] < matrix1d[j + 1])
                {
                    (matrix1d[j], matrix1d[j + 1]) = (matrix1d[j + 1], matrix1d[j]);
                    (ind[j], ind[j + 1]) = (ind[j + 1], ind[j]);
                }
            }
        }
        
        for (int i = 0; i < n * m; i++)
        {
            int row = ind[i][0], col = ind[i][1];
            if (i < 5) SuperDouble(ref matrix[row, col]);
            else SuperAntiDouble(ref matrix[row, col]);
        }
        void SuperDouble(ref double a)
        {
            if (a < 0) a /= 2;
            else a *= 2;
        }

        void SuperAntiDouble(ref double a)
        {
            if (a < 0) a *= 2;
            else a /= 2;
        }
    }
    
    public void Task_2_23(double[,] A, double[,] B)
    {
        MatrixValuesChange(ref A); MatrixValuesChange(ref B);
    }

    public void Task_2_24(int[,] A, int[,] B)
    {
        // code here

        // use FindMaxIndex(matrix, out row, out column); like in 2_1
        // create and use SwapColumnDiagonal(matrix, columnIndex);

        // end
    }

    public int CountNegativeInRow(int[,] matrix, int rowIndex)
    {
        int count = 0, cols = matrix.GetLength(1);
        for (int j = 0; j < cols; j++)
        {
            if (matrix[rowIndex, j] < 0) count++;
        }
        return count;
    }

    public int FindRowWithMaxNegativeCount(int[,] matrix)
    {
        int max = -1, maxRow = -1, rows = matrix.GetLength(0), cnt;
        for (int i = 0; i < rows; i++)
        {
            cnt = CountNegativeInRow(matrix, i);
            if (cnt > max)
            {
                max = cnt;
                maxRow = i;
            }
        }
        return maxRow;
    }

    
    public void Task_2_25(int[,] A, int[,] B, out int maxA, out int maxB)
    {
        maxA = FindRowWithMaxNegativeCount(A);
        maxB = FindRowWithMaxNegativeCount(B);
    }

    public void Task_2_26(int[,] A, int[,] B)
    {
        // code here

        // create and use FindRowWithMaxNegativeCount(matrix); like in 2_25
        // in FindRowWithMaxNegativeCount use CountNegativeInRow(matrix, rowIndex); from 2_22

        // end
    }

    public void FindRowMaxIndex(ref int[,] matrix, int rowIndex, out int colIndex)
    {
        int max = int.MinValue;
        colIndex = -1;
        for (int i = 0; i < matrix.GetLength(1); i++)
        {
            if (matrix[rowIndex, i] > max)
            {
                max = matrix[rowIndex, i]; 
                colIndex = i;
            }
        }
    }

    public void ReplaceMaxElementOdd(ref int[,] matrix, int row, int column)
    {
        matrix[row, column] *= column + 1;
    }

    public void ReplaceMaxElementEven(ref int[,] matrix, int row, int column)
    {
        matrix[row, column] = 0;
    }
    
    public void Task_2_27(int[,] A, int[,] B)
    {
        int m = A.GetLength(0);
        for (int i = 1; i < m; i += 2)
        {
            FindRowMaxIndex(ref A, i, out int col);
            ReplaceMaxElementEven(ref A, i, col);
        }

        for (int i = 0; i < m; i += 2)
        {
            FindRowMaxIndex(ref A, i, out int col);
            ReplaceMaxElementOdd(ref A, i, col);
        }
        
        m = B.GetLength(0);
        for (int i = 1; i < m; i += 2)
        {
            FindRowMaxIndex(ref B, i, out int col);
            ReplaceMaxElementEven(ref B, i, col);
        }

        for (int i = 0; i < m; i += 2)
        {
            FindRowMaxIndex(ref B, i, out int col);
            ReplaceMaxElementOdd(ref B, i, col);
        }
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

    public double[,] GetSumAndY(SumFunction sFunction, YFunction yFunction, double a, double b, double h)
    {
        int size = (int)Math.Ceiling((b - a) / h) + 1;
        double[,] arr = new double[size, 2];
        for (int i = 0; i < size; i++) (arr[i, 0], arr[i, 1]) = (sFunction(a + i*h), yFunction(a + i*h));
        return arr;
    }
    
    public void Task_3_1(ref double[,] firstSumAndY, ref double[,] secondSumAndY)
    {
        // create and use public delegate SumFunction(x) and public delegate YFunction(x)
        // create and use method GetSumAndY(sFunction, yFunction, a, b, h);
        // create and use 2 methods for both functions calculating at specific x

        double a = 0.1, b = 1, h = 0.1;
        firstSumAndY = GetSumAndY(firstS, firstY, a, b, h);
        a = Math.PI / 5;
        b = Math.PI;
        h = Math.PI / 25;
        secondSumAndY = GetSumAndY(secondS, secondY, a, b, h);

        double firstS(double x)
        {
            double s = 1, add;
            for (int i = 1; ; i++)
            {
                add = Math.Cos(i * x) / Factorial(i);
                if (Math.Abs(add) <  Eps) break;
                s += add;
            }
            return s;
        }
        
        double secondS(double x)
        {
            double s = 0, add;
            double sign = -1;
            for (int i = 1; ; i++)
            {
                add = sign * Math.Cos(i * x) / (i * i);
                if (Math.Abs(add) < Eps) break;
                s += add;
                sign *= -1;
            }
            return s;
        }

        double firstY(double x) => Math.Exp(Math.Cos(x)) * Math.Cos(Math.Sin(x));
        
        double secondY(double x) => (x*x - (Math.PI * Math.PI)/3) / 4;
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

    public double SumArray(double[] array)
    {
        double s = 0;
        for (int i = 0; i < array.Length; i++) s += array[i];
        return s;
    }
    
    public delegate void SwapDirection(ref double[] array);

    public double GetSum(ref double[] array, int start, int h)
    {
        double s = 0;
        for(int i = start; i < array.Length; i += h) s += array[i];
        return s;
    }
    public double Task_3_3(double[] array)
    {
        double answer = 0;
        double avg = SumArray(array) / array.Length;
        SwapDirection swapper = default(SwapDirection);

        if (array[0] > avg) swapper = SwapLeft;
        else swapper = SwapRight;

        swapper(ref array);

        return GetSum(ref array, 1, 2);

        void SwapRight(ref double[] array)
        {
            for(int i = array.Length - 1; i > 0; i -= 2) (array[i], array[i - 1]) = (array[i - 1], array[i]);
        }

        void SwapLeft(ref double[] array)
        {
            for(int i = 0; i < array.Length - 1; i += 2) (array[i], array[i + 1]) = (array[i], array[i + 1]);
        }

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
    
    
    public int CountSignFlips(YFunction yFunction, double a, double b, double h)
    {
        int size = (int)Math.Ceiling((b - a) / h) + 1, ind = 0, cnt = 0;
        double[] values = new double[size];
        for (double x = a; x <= b; x += h) values[ind++] = yFunction(x);
        double prevNonZero = values[0];
        Console.WriteLine(String.Join(", ", values));
        for (int i = 1; i < size; i++)
        {
            if (values[i] == 0) continue;
            if ((prevNonZero > 0 && values[i] < 0) || (prevNonZero < 0 && values[i] > 0)) cnt++;
            prevNonZero = values[i];
        }
        return cnt;
    }
    
    public void Task_3_5(out int func1, out int func2)
    {
        func1 = CountSignFlips(firstFunc, 0, 2, 0.1);
        func2 = CountSignFlips(secondFunc, -1, 1, 0.2);
        double firstFunc(double x) => x * x - Math.Sin(x);
        double secondFunc(double x) => Math.Exp(x) - 1;
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

    public delegate int CountPositive(int[,] matrix, int index); 
    
    public int[,] InsertColumn(int[,] matrixB, int insertAfterRow, int[,] matrixC, int columnIndexC)
    {
        int rowsB = matrixB.GetLength(0),  colsB = matrixB.GetLength(1), rowsC = matrixC.GetLength(0);
        int[] columnToInsert = new int[rowsC];
        for (int i = 0; i < rowsC; i++) columnToInsert[i] = matrixC[i, columnIndexC];
        int[,] newB = new int[rowsB + 1, colsB];
        int colIndex;
        for (int i = 0; i < (rowsB + 1); i++)
        {
            if(i <= insertAfterRow) {for (int j = 0; j < colsB; j++) newB[i, j] = matrixB[i, j];}
            else if (insertAfterRow + 1 == i) {for (int j = 0; j < colsB; j++) newB[i, j] = columnToInsert[j];}
            else for (int j = 0; j < colsB; j++) newB[i, j] = matrixB[i - 1, j];
        }
        return newB;
    }

    
    public void Task_3_7(ref int[,] B, int[,] C)
    {
        CountPositive operation = CountRowPositive;

        int positives;
        int maxRowPositives = int.MinValue, maxRowIndex = -1;
        int maxColPositives = int.MinValue, maxColIndex = -1;

        for (int i = 0; i < B.GetLength(0); i++)
        {
            positives = operation(B, i);
            if (positives > maxRowPositives)
            {
                maxRowPositives = positives;
                maxRowIndex = i;
            }
        }
        
        operation = CountColumnPositive;
        for (int j = 0; j < C.GetLength(1); j++)
        {
            positives = operation(C, j);
            if (positives > maxColPositives)
            {
                maxColPositives = positives;
                maxColIndex = j;
            }
        }
        
        B = InsertColumn(B, maxRowIndex, C, maxColIndex);
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

    public delegate void FindElementDelegate(int[,] matrix, out int row, out int col);

    public void RemoveRows(ref int[,] matrix, FindElementDelegate findMax, FindElementDelegate findMin)
    {
        FindElementDelegate operation = findMin;
        operation(matrix, out int rowMin, out _);
        operation = findMax;
        operation(matrix, out int rowMax, out _);
        
        if(rowMin == rowMax) matrix = RemoveRow(matrix, rowMin);
        else if(rowMin > rowMax) matrix = RemoveRow(RemoveRow(matrix, rowMin), rowMax);
        else matrix = RemoveRow(RemoveRow(matrix, rowMin), rowMax - 1);
    }
    
    public void Task_3_13(ref int[,] matrix)
    {
        RemoveRows(ref matrix, FindMaxIndex, FindMinIndex);
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

    
    public delegate void ReplaceMaxElement(ref int[,] matrix, int rowIndex, int colIndex);
    
    public void EvenOddRowsTransform(ref int[,] matrix, ReplaceMaxElement replaceMaxElementOdd, ReplaceMaxElement replaceMaxElementEven)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            FindRowMaxIndex(ref matrix, i, out int col);
            if(i % 2 == 1) replaceMaxElementOdd(ref matrix, i, col);
            else replaceMaxElementEven(ref matrix, i, col);
        }
    }
    
    public void Task_3_27(int[,] A, int[,] B)
    {
        EvenOddRowsTransform(ref A, ReplaceMaxElementEven, ReplaceMaxElementOdd);
        EvenOddRowsTransform(ref B, ReplaceMaxElementEven, ReplaceMaxElementOdd);
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
    
    public delegate double[,] MatrixConverter(double[,] matrix);

    public double[,] ToUpperTriangular(double[,] matrix)
    {
        int n = matrix.GetLength(0);
        
        for (int j = 0; j < n - 1; j++)
        {
            for (int k = j + 1; k < n; k++)
            {
                double p = matrix[k, j] / matrix[j, j];
                for (int m = j; m < n; m++) matrix[k, m] -= p * matrix[j, m];
            }
        }
        return matrix;
    }

    public double[,] FlipMatrix(double[,] matrix)
    {
        int n = matrix.GetLength(0);
        double[,] result = new double[n, n];
        for (int i = n - 1; i >= 0; i--)
        {
            for(int j = n - 1; j >= 0; j--) result[n - i - 1, n - j - 1] = matrix[i, j];
        }

        return result;
    }
    
    public double[,] ToLowerTriangular(double[,] matrix)
    {
        return FlipMatrix(ToUpperTriangular(FlipMatrix(matrix)));
    }

    public double[,] ToLeftDiagonal(double[,] matrix)
    {
        return ToLowerTriangular(ToUpperTriangular(matrix));
    }
    
    
    public double[,] ToRightDiagonal(double[,] matrix)
    {
        return ToUpperTriangular(ToLowerTriangular(matrix));
    }

    
    public double[,] Task_4(double[,] matrix, int index)
    {
        MatrixConverter[] mc = {ToUpperTriangular, ToLowerTriangular, ToLeftDiagonal, ToRightDiagonal};
        matrix = mc[index](matrix);
        // double[,] test_matrix =
        // {
        //     {2, 1, -1},
        //     {1, -1, 1},
        //     {-1, 1, 2}};
        //
        // test_matrix = mc[0](test_matrix);
        // for (int i = 0; i < test_matrix.GetLength(0); i++)
        // {
        //     for(int j = 0; j < test_matrix.GetLength(1); j++) Console.Write($"{test_matrix[i, j]:f2}\t");
        //     Console.WriteLine();
        // }
        return matrix;
    }
    #endregion
}
