using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Numerics;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class Program
{
    public static void Main()
    {
        Program program = new Program();
    }
    #region Level 1
    public static long Factorial(int n) {
        long answer = 1;
        for (int i = 1; i <= n; i++) {
            answer *= i;
        }
        return answer;
    }
    
    public static long Combinations(int n, int k) {
        return Factorial(n) / (Factorial(k) * Factorial(n - k));
    }

    public long Task_1_1(int n, int k)
    {
        if (n < 0 || k < 0) return 0;

        return Combinations(n, k);
    }

    public static double geronArea(double a, double b, double c) {
        double p = (a + b + c) / 2;
        return Math.Pow(p * (p - a) * (p - b) * (p - c), 0.5);
    }

    public int Task_1_2(double[] first, double[] second)
    {
        int answer = 0;

        for (int i = 0; i < 3; i++) {
            if (first[i] <= 0 || second[i] <= 0) return -1;
        }

        if (first[0] + first[1] <= first[2] || first[0] + first[2] <= first[1] || first[1] + first[2] <= first[0]) return -1;
        if (second[0] + second[1] <= second[2] || second[0] + second[2] <= second[1] || second[1] + second[2] <= second[0]) return -1;        

        double S1 = geronArea(first[0], first[1], first[2]);
        double S2 = geronArea(second[0], second[1], second[2]);

        if (S1 > S2) answer = 1;
        else if (S1 < S2) answer = 2;
        // first = 1, second = 2, equal = 0, error = -1
        return answer;
    }

    public static double GetDistance(double v, double a, double t) {
        return v * t + a * t * t / 2.0;
    }

    public int Task_1_3a(double v1, double a1, double v2, double a2, int time)
    {
        int answer = 0;

        double S1 = GetDistance(v1, a1, time);
        double S2 = GetDistance(v2, a2, time);

        if (S1 > S2) answer = 1;
        else if (S1 < S2) answer = 2;

        // first = 1, second = 2, equal = 0
        return answer;
    }

    public int Task_1_3b(double v1, double a1, double v2, double a2)
    {
        for (int t = 1; ; t++) {
            double S1 = GetDistance(v1, a1, t);
            double S2 = GetDistance(v2, a2, t);
            if (S1 <= S2) return t;
        }
    }
    #endregion

    #region Level 2

    // minindex for 3_13
    public static void FindMinIndex(int[,] matrix, out int row, out int column)
    {
        int rows = matrix.GetLength(0), columns = matrix.GetLength(1);
        row = 0;
        column = 0;

        int minValue = int.MaxValue;

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                if (matrix[i, j] < minValue)
                {
                    minValue = matrix[i, j];
                    row = i;
                    column = j;
                }
            }
        }
    }

    public static void FindMaxIndex(int[,] matrix, out int row, out int column) {
        int rows = matrix.GetLength(0), columns = matrix.GetLength(1);
        row = 0;
        column = 0;

        int maxValue = int.MinValue;

        for (int i = 0; i < rows; i++) {
            for (int j = 0; j < columns; j++) {
                if (matrix[i, j] > maxValue) {
                    maxValue = matrix[i, j];
                    row = i;
                    column = j;
                }
            }
        }
    }
    public void Task_2_1(int[,] A, int[,] B)
    {
        int row1, column1, row2, column2;
        FindMaxIndex(A, out row1, out column1);
        FindMaxIndex(B, out row2, out column2);

        int temp = A[row1, column1];
        A[row1, column1] = B[row2, column2];
        B[row2, column2] = temp;
    }

    public void Task_2_2(double[] A, double[] B)
    {
        // code here

        // create and use FindMaxIndex(array);
        // only 1 array has to be changed!

        // end
    }

    public static int FindDiagonalMaxIndex(int[,] matrix) {
        int rows = matrix.GetLength(0), columns = matrix.GetLength(1);
        if (rows != columns) return -1;

        int maxValue = int.MinValue, pos = -1;

        for (int i = 0; i < rows; i++) {
            for (int j = 0; j < columns; j++) {
                if (i == j && maxValue < matrix[i, j]) {
                    maxValue = matrix[i, j];
                    pos = i;
                }
            }
        }

        return pos;
    }
    public void Task_2_3(ref int[,] B, ref int[,] C)
    {
        int maxB = FindDiagonalMaxIndex(B);
        int maxC = FindDiagonalMaxIndex(C);

        int[,] newB = new int[4, 5];
        int[,] newC = new int[5, 6];

        for (int i = 0; i < 5; i++) {
            if (i == maxB) continue;
            for (int j = 0; j < 5; j++) {
                newB[(i > maxB) ? i - 1 : i, j] = B[i, j];
            }
        }

        for (int i = 0; i < 6; i++) {
            if (i == maxC) continue;
            for (int j = 0; j < 6; j++) {
                newC[(i > maxC) ? i - 1 : i, j] = C[i, j];
            }
        }

        B = newB;
        C = newC;
    }

    public void Task_2_4(int[,] A, int[,] B)
    {
        // code here

        //  create and use method FindDiagonalMaxIndex(matrix); like in Task_2_3

        // end
    }

    public static void FindMaxInColumn(int[,] matrix, int columnIndex, out int rowIndex) {
        int rows = matrix.GetLength(0), columns = matrix.GetLength(1);
        rowIndex = 0;
        int maxValue = int.MinValue, maxRow = 0;
        for (int i = 0; i < rows; i++) {
            if (matrix[i, 0] > maxValue) {
                maxRow = i;
                maxValue = matrix[maxRow, 0];
            }
        }

        rowIndex = maxRow;
    }
    public void Task_2_5(int[,] A, int[,] B)
    {
        int rowA, rowB;
        FindMaxInColumn(A, 0, out rowA);
        FindMaxInColumn(B, 0, out rowB);

        for (int j = 0; j < 6; j++) {
            int temp = A[rowA, j];
            A[rowA, j] = B[rowB, j];
            B[rowB, j] = temp;
        }
    }

    public void Task_2_6(ref int[] A, int[] B)
    {
        // code here

        // create and use FindMax(matrix, out row, out column); like in Task_2_1
        // create and use DeleteElement(array, index);

        // end
    }

    public static int CountRowPositive(int[,] matrix, int rowIndex) {
        int answer = 0;

        for (int j = 0; j < matrix.GetLength(1); j++) {
            if (matrix[rowIndex, j] > 0) answer++;
        }

        return answer;
    }

    public static int CountColumnPositive(int[,] matrix, int colIndex) {
        int answer = 0;

        for (int i = 0; i < matrix.GetLength(0); i++) {
            if (matrix[i, colIndex] > 0) answer++;
        }

        return answer;
    }
    public void Task_2_7(ref int[,] B, int[,] C)
    {
        int maxPosRow = 0, maxPosRowIndex = -1;
        int maxPosCol = 0, maxPosColIndex = -1;

        for (int i = 0; i < B.GetLength(0); i++) {
            int counter = CountRowPositive(B, i);
            if (maxPosRow < counter) {
                maxPosRow = counter;
                maxPosRowIndex = i;
            }
        }


        for (int j = 0; j < C.GetLength(1); j++) {
            int counter = CountColumnPositive(C, j);
            if (maxPosCol < counter) {
                maxPosCol = counter;
                maxPosColIndex = j;
            }
        }

        int[,] newB = new int[5, 5];

        for (int j = 0; j < 5; j++) {
            newB[maxPosRowIndex + 1, j] = C[j, maxPosColIndex];
        }
        
        for (int i = 0; i < 4; i++) {
            for (int j = 0; j < 5; j++) {
                newB[i <= maxPosRowIndex ? i : i + 1, j] = B[i, j];
            }
        }

        B = newB;
    }

    public void Task_2_8(int[] A, int[] B)
    {
        // code here

        // create and use SortArrayPart(array, startIndex);

        // end
    }

    public static int SumPositiveElementsInColumn(int[,] matrix, int colIndex) {
        int answer = 0;

        for (int i = 0; i < matrix.GetLength(0); i++) {
            if (matrix[i, colIndex] > 0) answer += matrix[i, colIndex];
        }
        return answer;
    }

    public int[] Task_2_9(int[,] A, int[,] C)
    {
        int[] answer = new int[A.GetLength(1) + C.GetLength(1)];

        for (int j = 0; j < A.GetLength(1); j++) {
            answer[j] = SumPositiveElementsInColumn(A, j);
        }

        for (int j = 0; j < C.GetLength(1); j++) {
            answer[A.GetLength(1) + j] = SumPositiveElementsInColumn(C, j);
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
        int rowA, columnA;
        int rowB, columnB;

        FindMaxIndex(A, out rowA, out columnA);
        FindMaxIndex(B, out rowB, out columnB);

        int temp = A[rowA, columnA];
        A[rowA, columnA] = B[rowB, columnB];
        B[rowB, columnB] = temp;
    }
    public void Task_2_12(int[,] A, int[,] B)
    {
        // code here

        // create and use FindMaxColumnIndex(matrix);

        // end
    }

    public static int[,] RemoveRow(int[,] matrix, int rowIndex) {
        int rows = matrix.GetLength(0), columns = matrix.GetLength(1);
        int[,] answer = new int[rows - 1, columns];

        for (int i = 0; i < rows; i++) {
            if (i == rowIndex) continue;
            for (int j = 0; j < columns; j++) {
                answer[i < rowIndex ? i : i - 1, j] = matrix[i, j];
            }
        }

        return answer;
    }

    public void Task_2_13(ref int[,] matrix)
    {
        int maxValue = int.MinValue, maxRow = -1;
        int minValue = int.MaxValue, minRow = -1;

        int rows = matrix.GetLength(0), columns = matrix.GetLength(1);

        for (int i = 0; i < rows; i++) {
            for (int j = 0; j < columns; j++) {
                if (maxValue < matrix[i, j]) {
                    maxValue = matrix[i, j];
                    maxRow = i;
                }

                if (minValue > matrix[i, j]) {
                    minValue = matrix[i, j];
                    minRow = i;
                }
            }
        }

        if (maxRow < minRow) {
            matrix = RemoveRow(matrix, minRow);
            matrix = RemoveRow(matrix, maxRow);
        } else if (maxRow > minRow) {
            matrix = RemoveRow(matrix, maxRow);
            matrix = RemoveRow(matrix, minRow);
        } else if (maxRow == minRow) matrix = RemoveRow(matrix, maxRow);
    }

    public void Task_2_14(int[,] matrix)
    {
        // code here

        // create and use SortRow(matrix, rowIndex);

        // end
    }

    public static double GetAverageWithoutMinMax(int[,] matrix) {
        int rows = matrix.GetLength(0), columns = matrix.GetLength(1);
        double answer = 0;
        double counter = 0;

        int maxVal = int.MinValue, maxRow = -1, maxCol = -1;
        int minVal = int.MaxValue, minRow = -1, minCol = -1;

        for (int i = 0; i < rows; i++) {
            for (int j = 0; j < columns; j++) {
                if (maxVal < matrix[i, j]) {
                    maxVal = matrix[i, j];
                    maxRow = i;
                    maxCol = j;
                }
                if (minVal > matrix[i, j]) {
                    minVal = matrix[i, j];
                    minRow = i;
                    minCol = j;
                }
            }
        }

        for (int i = 0; i < rows; i++) {
            for (int j = 0; j < columns; j++) {
                if ((i == maxRow && j == maxCol) || (i == minRow && i == minCol)) continue;
                answer += matrix[i, j];
                counter++;
            }
        }

        answer /= counter;

        return answer;
    }

    public int Task_2_15(int[,] A, int[,] B, int[,] C)
    {
        int answer = 0;

        double[] avgArr = new double[3] { GetAverageWithoutMinMax(A), GetAverageWithoutMinMax(B), GetAverageWithoutMinMax(C) };

        if (avgArr[0] < avgArr[1] && avgArr[1] < avgArr[2]) answer = 1;
        else if (avgArr[0] > avgArr[1] && avgArr[1] > avgArr[2]) answer = -1;
        // 1 - increasing   0 - no sequence   -1 - decreasing
        return answer;
    }

    public void Task_2_16(int[] A, int[] B)
    {
        // code here

        // create and use SortNegative(array);

        // end
    }

    public static void SortRowsByMaxElement(ref int[,] matrix) {
        int rows = matrix.GetLength(0), cols = matrix.GetLength(1);

        int[] maxInRow = new int[rows];

        for (int i = 0; i < rows; i++) {
            int maxVal = int.MinValue;
            for (int j = 0; j < cols; j++) {
                if (maxVal < matrix[i, j]) maxVal = matrix[i, j];
            }
            maxInRow[i] = maxVal;
        }

        for (int i = 0; i < rows; i++) {
            for (int ii = 0; ii < rows - (i + 1); ii++) {
                if (maxInRow[ii] < maxInRow[ii + 1]) {
                    int temp = maxInRow[ii];
                    maxInRow[ii] = maxInRow[ii + 1];
                    maxInRow[ii + 1] = temp;

                    for (int jj = 0; jj < cols; jj++) {
                        int temp2 = matrix[ii, jj];
                        matrix[ii, jj] = matrix[ii + 1, jj];
                        matrix[ii + 1, jj] = temp2;
                    }
                }
            }
        }
    }
    public void Task_2_17(int[,] A, int[,] B)
    {
        SortRowsByMaxElement(ref A);
        SortRowsByMaxElement(ref B);
    }

    public void Task_2_18(int[,] A, int[,] B)
    {
        // code here

        // create and use SortDiagonal(matrix);

        // end
    }

    public void Task_2_19(ref int[,] matrix)
    {
        int rows = matrix.GetLength(0), columns = matrix.GetLength(1);

        int counter = 0;

        for (int i = 0; i < rows; i++) {
            for (int j = 0; j < columns; j++) {
                if (matrix[i, j] == 0) {
                    counter++;
                    break;
                }
            }
        }

        int[] toDelete = new int[counter];

        int ii = 0;
        
        for (int i = 0; i < rows; i++) {
            for (int j = 0; j < columns; j++) {
                if (matrix[i, j] == 0) {
                    toDelete[ii++] = i;
                    break;
                }
            }
        }

        for (int i = toDelete.Length - 1; i >= 0; i--) {
            matrix = RemoveRow(matrix, toDelete[i]);
        }
    }
    public void Task_2_20(ref int[,] A, ref int[,] B)
    {
        // code here

        // use RemoveColumn(matrix, columnIndex); from 2_10

        // end
    }

    public static void CreateArrayFromMins(int[,] matrix, ref int[] answer) {
        for (int i = 0; i < matrix.GetLength(0); i++) {
            int minVal = int.MaxValue;
            for (int j = i; j < matrix.GetLength(1); j++) {
                if (minVal > matrix[i, j]) minVal = matrix[i, j];
            }
            answer[i] = minVal;
        }
    }
    public void Task_2_21(int[,] A, int[,] B, out int[] answerA, out int[] answerB)
    {
        answerA = new int[A.GetLength(0)];
        answerB = new int[B.GetLength(0)];

        CreateArrayFromMins(A, ref answerA);
        CreateArrayFromMins(B, ref answerB);
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

    public static void MatrixValuesChange(ref double[,] matrix) {
        int rows = matrix.GetLength(0), columns = matrix.GetLength(1);
        int[][] sortedCells = new int[rows*columns][];

        int counter = 0;
        for (int i = 0; i < rows; i++) {
            for (int j = 0; j < columns; j++) {
                sortedCells[counter++] = new int[] {i, j};
            }
        }

        for (int i = 0; i < counter; i++) {
            for (int j = 0; j < counter - (i + 1); j++) {
                int row = sortedCells[j][0], col = sortedCells[j][1];
                int row2 = sortedCells[j + 1][0], col2 = sortedCells[j + 1][1];

                if (matrix[row, col] > matrix[row2, col2]) {
                    int[] temp = sortedCells[j];
                    sortedCells[j] = sortedCells[j + 1];
                    sortedCells[j + 1] = temp;
                }
            }
        }

        for (int i = rows * columns - 1; i >= 0; i--) {
            int row = sortedCells[i][0], col = sortedCells[i][1];
            if (i >= rows * columns - 5) {
                matrix[row, col] *= matrix[row, col] > 0 ? 2.0 : 0.5;
            } else {
                matrix[row, col] *= matrix[row, col] > 0 ? 0.5 : 2.0;
            }
        }
    }
    public void Task_2_23(double[,] A, double[,] B)
    {
        MatrixValuesChange(ref A);
        MatrixValuesChange(ref B);
    }

    public void Task_2_24(int[,] A, int[,] B)
    {
        // code here

        // use FindMaxIndex(matrix, out row, out column); like in 2_1
        // create and use SwapColumnDiagonal(matrix, columnIndex);

        // end
    }

    public static int FindRowWithMaxNegativeCount(int[,] matrix) {
        int maxCount = 0, pos = 0;
        for (int i = 0; i < matrix.GetLength(0); i++) {
            int countNeg = CountNegativeInRow(matrix, i);
            if (maxCount < countNeg) {
                maxCount = countNeg;
                pos = i;
            }
        }

        return pos;
    }

    public static int CountNegativeInRow(int[,] matrix, int rowIndex) {
        int answer = 0;
        for (int j = 0; j < matrix.GetLength(1); j++) {
            if (matrix[rowIndex, j] < 0) answer++;
        }

        return answer;
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

    public static void FindRowMaxIndex(int[,] matrix, int rowIndex, out int columnIndex) {
        int maxVal = int.MinValue;
        columnIndex = 0;
        for (int j = 0; j < matrix.GetLength(1); j++) {
            if (maxVal < matrix[rowIndex, j]) {
                maxVal = matrix[rowIndex, j];
                columnIndex = j;
            }
        }
    }

    public static void ReplaceMaxElementOdd(ref int[,] matrix, int row, int column) {
        matrix[row, column] *= column + 1;
    }

    public static void ReplaceMaxElementEven(ref int[,] matrix, int row, int column) {
        matrix[row, column] = 0;
    }

    public void Task_2_27(int[,] A, int[,] B)
    {
        int rowsA = A.GetLength(0), colsA = A.GetLength(1);
        int rowsB = B.GetLength(0), colsB = B.GetLength(1);

        for (int i = 0; i < rowsA; i++) {
            int index;
            FindRowMaxIndex(A, i, out index);
            if (i % 2 != 0) ReplaceMaxElementEven(ref A, i, index);
            else ReplaceMaxElementOdd(ref A, i, index);
        }

        for (int i = 0; i < rowsB; i++) {
            int index;
            FindRowMaxIndex(B, i, out index);
            if (i % 2 != 0) ReplaceMaxElementEven(ref B, i, index);
            else ReplaceMaxElementOdd(ref B, i, index);
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

    public double[,] GetSumAndY(SumFunction sFunction, YFunction yFunction, double a, double b, double h) {
        double[,] answer = new double[(int) ( (b - a) / h ) + 1, 2];

        for (int i = 0; i < answer.GetLength(0); i++)
        {
            answer[i, 0] = sFunction(a + i * h);
            answer[i, 1] = yFunction(a + i * h);
        }

        return answer;
    }

    public double y_A(double x) {
        return Math.Exp(Math.Cos(x)) * Math.Cos(Math.Sin(x));
    }

    public double y_B(double x) {
        return (x * x - (Math.PI * Math.PI / 3)) / 4;
    }

    public double s_A(double x)
    {
        double answer = 1.0, lastFactorial = 1.0, elem = Math.Cos(x);

        for (int i = 2; Math.Abs(elem) > 0.0001; i++)
        {
            answer += elem;
            lastFactorial *= i;
            elem = Math.Cos(i * x) / lastFactorial;
        }

        return answer;
    }

    public double s_B(double x)
    {
        double answer = 0, sign = -1.0, elem = -Math.Cos(x);

        for (int i = 2; Math.Abs(elem) > 0.0001; i++)
        {
            answer += elem;
            sign = -sign;
            elem = sign * Math.Cos(i * x) / (i * i);
        }

        return answer;
    }

    public void Task_3_1(ref double[,] firstSumAndY, ref double[,] secondSumAndY)
    {
        firstSumAndY = GetSumAndY(s_A, y_A, 0.1, 1.0, 0.1);
        secondSumAndY = GetSumAndY(s_B, y_B, Math.PI / 5.0, Math.PI, Math.PI / 25.0);
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

    public void SwapRight(ref double[] array)
    {
        for (int i = array.Length - 1; i > 0; i -= 2)
        {
            double temp = array[i];
            array[i] = array[i - 1];
            array[i - 1] = temp;
        }
    }

    public void SwapLeft(ref double[] array)
    {
        for (int i = 0; i < array.Length; i += 2)
        {
            double temp = array[i];
            array[i] = array[i + 1];
            array[i + 1] = temp;
        }
    }

    public double GetSum(double[] array, int start, int h)
    {
        double answer = 0;

        for (int i = start; i < array.Length; i += h) 
            answer += array[i];

        return answer;
    }

    public double Task_3_3(double[] array)
    {
        double answer = 0;
        double average = 0;

        for (int i = 0; i < array.Length; i++) average += array[i];

        if (array.Length != 0)
            average /= array.Length;
        
        SwapDirection swapper = default(SwapDirection);

        if (array[0] > average)
            swapper = SwapLeft;
        else
            swapper = SwapRight;

        swapper(ref array);
        answer = GetSum(array, 1, 2); // нечетные индексы

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

    public int CountSignFlips(YFunction y, double a, double b, double h)
    {
        int answer = 0;
        double last = y(a);
        
        for (double i = a + h; i <= b; i += h)
        {
            if (y(i) == 0) continue;

            double curr = y(i);
            if (last > 0 && curr < 0 || last < 0 && curr > 0) answer++;
            last = curr;
        }

        return answer;
    }

    public double y_A_3_5(double x)
    {
        return x * x - Math.Sin(x);
    }

    public double y_B_3_5(double x)
    {
        return Math.Exp(x) - 1;
    }

    public void Task_3_5(out int func1, out int func2)
    {
        func1 = CountSignFlips(y_A_3_5, 0.0, 2.0, 0.1);
        func2 = CountSignFlips(y_B_3_5, -1.0, 1.0, 0.2);
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

    public void InsertColumn(ref int[,] matrixB, int CountRow, int[,] matrixC, int CountColumn)
    {
        int rowsB = matrixB.GetLength(0), colsB = matrixB.GetLength(1);
        int rowsC = matrixC.GetLength(0), colsC = matrixC.GetLength(1);

        int[,] newB = new int[rowsB + 1, colsB];

        for (int j = 0; j < colsB; j++)
        {
            newB[CountRow + 1, j] = matrixC[j, CountColumn];
        }

        for (int i = 0; i < rowsB; i++)
        {
            for (int j = 0; j < colsB; j++)
            {
                newB[i <= CountRow ? i : i + 1, j] = matrixB[i, j];
            }
        }

        matrixB = newB;
    }

    public void Task_3_7(ref int[,] B, int[,] C)
    {
        int maxRow = int.MinValue, maxCol = int.MinValue;
        int maxRowPos = 0, maxColPos = 0;

        for (int i = 0; i < B.GetLength(0); i++)
        {
            int count = CountRowPositive(B, i);
            if (count > maxRow)
            {
                maxRow = count;
                maxRowPos = i;
            }
        }

        for (int j = 0; j < C.GetLength(1); j++)
        {
            int count = CountColumnPositive(C, j);
            if (count > maxCol)
            {
                maxCol = count;
                maxColPos = j;
            }
        }

        InsertColumn(ref B, maxRowPos, C, maxColPos);
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
        int rowMin, rowMax;
        int colMin, colMax;

        findMin(matrix, out rowMin, out colMin);
        findMax(matrix, out rowMax, out colMax);

        if (rowMin == rowMax)
        {
            matrix = RemoveRow(matrix, rowMin);
        }
        else if (rowMin > rowMax)
        {
            matrix = RemoveRow(matrix, rowMin);
            matrix = RemoveRow(matrix, rowMax);
        } else if (rowMin < rowMax)
        {
            matrix = RemoveRow(matrix, rowMax);
            matrix = RemoveRow(matrix, rowMin);
        }
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
        int rows = matrix.GetLength(0);

        for (int i = 0; i < rows; i++)
        {
            int col;
            FindRowMaxIndex(matrix, i, out col);

            if (i % 2 != 0) ReplaceMaxElementEven(ref matrix, i, col); // != 0 т.к индексы идут с 0, а люди считают с 1
            else ReplaceMaxElementOdd(ref matrix, i, col);
        }
    }

    public void Task_3_27(int[,] A, int[,] B)
    {
        EvenOddRowsTransform(ref A, ReplaceMaxElementOdd, ReplaceMaxElementEven);
        EvenOddRowsTransform(ref B, ReplaceMaxElementOdd, ReplaceMaxElementEven);
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

    public static void ToUpperTriangular(double[,] matrix) {
        int n = matrix.GetLength(0);

        for (int j = 0; j <= n - 2; j++) {
            for (int k = j + 1; k <= n - 1; k++) {
                double p = matrix[k, j] / matrix[j, j];
                for (int m = j; m <= n - 1; m++) matrix[k, m] = matrix[k, m] - matrix[j, m] * p;
            }
        }
    }

    public static void ToLowerTriangular(double[,] matrix) {
        int n = matrix.GetLength(0);

        for (int j = n - 1; j >= 0; j--) {
            for (int k = j - 1; k >= 0; k--) {
                double p = matrix[k, j] / matrix[j, j];

                for (int m = j; m >= 0; m--) matrix[k, m] = matrix[k, m] - matrix[j, m] * p;
            }
        }
    }

    public static void ToLeftDiagonal(double[,] matrix) {
        ToUpperTriangular(matrix);
        ToLowerTriangular(matrix);
    }

    public static void ToRightDiagonal(double[,] matrix) {
        ToLowerTriangular(matrix);
        ToUpperTriangular(matrix);
    }
    public double[,] Task_4(double[,] matrix, int index)
    {
        if (matrix.GetLength(0) != matrix.GetLength(1)) return matrix;
        MatrixConverter[] mc = new MatrixConverter[4] {ToUpperTriangular, ToLowerTriangular, ToLeftDiagonal, ToRightDiagonal};

        mc[index](matrix);

        return matrix;
    }
    #endregion
}
