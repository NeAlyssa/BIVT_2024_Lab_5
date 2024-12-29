using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Numerics;
using System.Reflection;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class Program
{
    public static void Main()
    {
        Program program = new Program();
    }
    #region Level 1
    public long Task_1_1(int n, int k) // dotnet test --filter Tests.ProgramTests.Task_1_1Test
    {
        

        // code here
        
        if (n < k || n < 0 || k < 0) return 0;
        long answer = Combinations(n, k);
        return answer;
        // end
    }

    public long Combinations(int n, int k) {
        long ans = Factorial(n) / Factorial(k) * Factorial(n - k);
        return ans;
    }

    public long Factorial(int n) {
        int factorial = 1;
        for (int i = 1; i <= n; i++)
        {
            factorial *= i;
        }
        return factorial;
    }

    public int Task_1_2(double[] first, double[] second) // dotnet test --filter Tests.ProgramTests.Task_1_2Test
    {
        // code here
        if (first[0] >= first[1] + first[2] || first[1] >= first[0] + first[2] || first[2] >= first[1] + first[0]) return -1;
        if (second[0] >= second[1] + second[2] || second[1] >= second[0] + second[2] || second[2] >= second[1] + second[0]) return -1;
        double first_result = GeronArea(first[0], first[1], first[2]);
        double second_result = GeronArea(second[0], second[1], second[2]);

        if (first_result == second_result) return 0;
        else if (first_result > second_result) return 1;
        return 2; 
    }

    public double GeronArea(double a, double b, double c) {
        double p = (double) (a + b + c)/2;
        Console.WriteLine(("ddd", p));
        double answer = Math.Sqrt(p*(p-a)*(p-b)*(p-c));
        return answer;
    }

    public int Task_1_3a(double v1, double a1, double v2, double a2, int time) // dotnet test --filter Tests.ProgramTests.Task_1_3aTest
    {
        // code here
        double s1 = GetDistance(v1, a1, time), s2 = GetDistance(v2, a2, time);
        Console.WriteLine((s1, s2));
        if (s1 > s2) return 1;
        else if (s1 < s2) return 2;
        return 0;
        // end
    }

    public double GetDistance(double v, double a, int time) {
        return  v*time+a*time*time/2;
    }

    public int Task_1_3b(double v1, double a1, double v2, double a2) // dotnet test --filter Tests.ProgramTests.Task_1_3bTest
    {
        int answer = 0;

        // code here
        for (int i=1; ; i++)
        {
            if (GetDistance(v1, a1, i) <= GetDistance(v2, a2, i)) return i;
        }
        // end
        return answer;
    }
    #endregion

    #region Level 2
    public void Task_2_1(int[,] A, int[,] B) // dotnet test --filter Tests.ProgramTests.Task_1_3bTest
    {
        // code here

        // create and use FindMaxIndex(matrix, out row, out column);

        // end
    }

    public void Task_2_2(double[] A, double[] B) // dotnet test --filter Tests.ProgramTests.Task_2_2Test
    {
        // code here
        int indexMaxA = FindMaxIndex(A), indexMaxB = FindMaxIndex(B);
        if (indexMaxA < indexMaxB) {
            A[indexMaxA] = CalcAvg(A, indexMaxA+1);
        } else {
            B[indexMaxB] = CalcAvg(B, indexMaxB+1);
        }
        // end
    }

    public double CalcAvg(double[] array, int ind) {
        double sum = 0;
        int count = 0;
        for (int i=ind; i<array.Length; i++) {
            sum += array[i];
            count++;
        }
        return sum/count;
    }

    public int FindMaxIndex(double[] array) {
        int resultIndex = 0;
        for (int i=0; i<array.Length; i++) {
            double element = array[i];
            if (element > array[resultIndex]) resultIndex = i;
        }
        return resultIndex;
    }

    public void Task_2_3(ref int[,] B, ref int[,] C)
    {
        // code here
        // end
    }

    public int FindDiagonalMaxIndex(int[,] matrix) {
        int maxInd = 0;
        for (int i=1; i<matrix.GetLength(0); i++) {
            if (matrix[maxInd, maxInd] < matrix[i, i]) maxInd = i;
        }
        return maxInd;
    }

    public void Task_2_4(int[,] A, int[,] B) // dotnet test --filter Tests.ProgramTests.Task_2_4Test
    {
        // code here

        int maxIndRow = FindDiagonalMaxIndex(A);
        int maxIndCol = FindDiagonalMaxIndex(B);

        for (int i=0; i<B.GetLength(0); i++) {
            int tmp = A[maxIndRow, i];
            A[maxIndRow, i] = B[i, maxIndCol];
            B[i, maxIndCol] = tmp;
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

    public void Task_2_6(ref int[] A, int[] B) // dotnet test --filter Tests.ProgramTests.Task_2_6Test
    {
        // code here
        int maxIndexA = FindMax(A), maxIndexB = FindMax(B);
        int[] newA = DeleteElement(A, maxIndexA), newB = DeleteElement(B, maxIndexB);

        int[] resultArray = new int[newA.Length + newB.Length];
        int a = 0;
        foreach (int i in newA) resultArray[a++] = i;
        foreach (int i in newB) resultArray[a++] = i;

        // Обновляем массив A с новым объединенным массивом
        A = resultArray;
        // end
    }

    public int FindMax(int[] array) {
        int indMax = 0;

        for (int i=0; i<array.Length; i++) {
            if (array[i] > array[indMax]) indMax = i;
        }

        return indMax;
    }

    public int[] DeleteElement(int[] array, int index) {
        int[] newArray = new int[array.Length-1];

        for (int i=0, j=0; i<array.Length; i++) {
            if (i != index) {newArray[j] = array[i]; j++;}
        }

        return newArray;
    }

    public void Task_2_7(ref int[,] B, int[,] C)
    {
        // code here

        // create and use CountRowPositive(matrix, rowIndex);
        // create and use CountColumnPositive(matrix, colIndex);

        // end
    }

    public void Task_2_8(int[] A, int[] B) // dotnet test --filter Tests.ProgramTests.Task_2_8Test
    {
        // code here

        SortArrayPart(A, FindMax(A)+1);
        SortArrayPart(B, FindMax(B)+1);

        // end
    }
    
    public void SortArrayPart(int[] array, int ind) {
        for (int i=ind; i<array.Length-1; i++) {
            for (int j=ind; j<array.Length-1-(i-ind); j++) {
                if (array[j]>array[j+1]) {
                    int tmp = array[j];
                    array[j] = array[j+1];
                    array[j+1] = tmp;
                }
            }
        }
    }

    public int[] Task_2_9(int[,] A, int[,] C)
    {
        int[] answer = default(int[]);

        // code here

        // create and use SumPositiveElementsInColumns(matrix);

        // end

        return answer;
    }

    public void Task_2_10(ref int[,] matrix) // dotnet test --filter Tests.ProgramTests.Task_2_10Test
    {
        int maxBD = int.MinValue, minAD = int.MaxValue, indMax = -1, indMin = -1;
        
        for (int i=0; i<matrix.GetLength(0); i++) {
            for (int j=0; j<matrix.GetLength(1); j++) {
                if (i>=j && matrix[i, j]>maxBD) {
                    maxBD = matrix[i, j];
                    indMax = j;
                }
                if (i < j && matrix[i, j] < minAD)
                {
                    minAD = matrix[i, j];
                    indMin = j;
                }
            }
        }
        if (indMax == indMin) matrix = RemoveColumn(matrix, indMin);
        else
        {
            matrix = RemoveColumn(matrix, indMin);
            matrix = RemoveColumn(matrix, indMax);
        }
    }

    public static int[,] RemoveColumn(int[,] matrix, int ind)
    {
        int[,] newMatrix = new int[matrix.GetLength(0), matrix.GetLength(1) - 1];

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0, jj = 0; j < matrix.GetLength(1); j++)
            {
                if (j == ind) continue; 
                newMatrix[i, jj] = matrix[i, j];
                jj++;
            }
        }

        return newMatrix;
    }


    public void Task_2_11(int[,] A, int[,] B)
    {
        // code here

        // use FindMaxIndex(matrix, out row, out column); from Task_2_1

        // end
    }
    public void Task_2_12(int[,] A, int[,] B) // dotnet test --filter Tests.ProgramTests.Task_2_12Test
    {
        // code here
        int maxColA = FindMaxColumnIndex(A);
        int maxColB = FindMaxColumnIndex(B);

        for (int i = 0; i < A.GetLength(0); i++) {
            int temp = A[i, maxColA];
            A[i, maxColA] = B[i, maxColB];
            B[i, maxColB] = temp;
        }
        // end
    }

    public int FindMaxColumnIndex(int[,] matrix) {
        int maxCol = 0;
        int maxVal = matrix[0, 0];

        for (int j = 0; j < matrix.GetLength(1); j++) {
            for (int i = 0; i < matrix.GetLength(0); i++) {
                if (matrix[i, j] > maxVal) {
                    maxVal = matrix[i, j];
                    maxCol = j;
                }
            }
        }
        return maxCol;
    }

    public void Task_2_13(ref int[,] matrix)
    {
        // code here

        // end
    }

    public void Task_2_14(int[,] matrix) // dotnet test --filter Tests.ProgramTests.Task_2_14Test
    {
        // code here

        for (int i = 0; i < matrix.GetLength(0); i++) SortRow(matrix, i);

        // end
    }

    public void SortRow(int[,] matrix, int rowIndex) {
        int colCount = matrix.GetLength(1);
        for (int i = 0; i < colCount - 1; i++) {
            for (int j = i + 1; j < colCount; j++) {
                if (matrix[rowIndex, i] > matrix[rowIndex, j]) {
                    int tmp = matrix[rowIndex, i];
                    matrix[rowIndex, i] = matrix[rowIndex, j];
                    matrix[rowIndex, j] = tmp;
                }
            }
        }
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

    public void Task_2_16(int[] A, int[] B) // dotnet test --filter Tests.ProgramTests.Task_2_16Test
    {
        // code here

        A = SortNegative(A);
        B = SortNegative(B);

        // end
    }
    
    public static int[] SortNegative(int[] array)
    {
        int negativeCount = 0;

        for (int i = 0; i < array.Length; i++) {
            if (array[i] < 0) {
                negativeCount++;
            }
        }

        if (negativeCount == 0) return array;

        int[] negativeNumbers = new int[negativeCount];
        int negIdx = 0;

        for (int i = 0; i < array.Length; i++) {
            if (array[i] < 0) {
                negativeNumbers[negIdx++] = array[i];
            }
        }

        for (int i = 1; i < negativeNumbers.Length; i++) {
            for (int j = i; j > 0 && negativeNumbers[j] > negativeNumbers[j - 1]; j--) {
                (negativeNumbers[j], negativeNumbers[j - 1]) = (negativeNumbers[j - 1], negativeNumbers[j]);
            }
        }

        int negPtr = 0;
        for (int i = 0; i < array.Length; i++) {
            if (array[i] < 0) {
                array[i] = negativeNumbers[negPtr++];
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

    public void Task_2_18(int[,] A, int[,] B) // dotnet test --filter Tests.ProgramTests.Task_2_18Test
    {
        // code here

        SortDiagonal(ref A);
        SortDiagonal(ref B);

        // end
    }

    public static void SortDiagonal(ref int[,] matrix)
    {
        int n = matrix.GetLength(0);
        int[] diagonal = new int[n];

        for (int i = 0; i < n; i++) {
            diagonal[i] = matrix[i, i];
        }

        for (int i = 1; i < diagonal.Length; i++) {
            for (int j = i; j > 0 && diagonal[j] < diagonal[j - 1]; j--) {
                (diagonal[j], diagonal[j - 1]) = (diagonal[j - 1], diagonal[j]);
            }
        }

        for (int i = 0; i < n; i++) {
            matrix[i, i] = diagonal[i];
        }
    }

    public void Task_2_19(ref int[,] matrix)
    {
        // code here

        // use RemoveRow(matrix, rowIndex); from 2_13

        // end
    }
    public void Task_2_20(ref int[,] A, ref int[,] B) // dotnet test --filter Tests.ProgramTests.Task_2_20Test
    {
        // code here
        CheckAndRemoveCols(ref A);
        CheckAndRemoveCols(ref B);

        // end
    }

    public void CheckAndRemoveCols(ref int[,] matrix)
    {
        int colCount = matrix.GetLength(1);

        for (int j = 0; j < colCount; j++) {
            bool hasZero = false;

            for (int i = 0; i < matrix.GetLength(0); i++) {
                if (matrix[i, j] == 0) {
                    hasZero = true;
                    break;
                }
            }
            if (!hasZero) {
                matrix = RemoveColumn(matrix, j);
                colCount--;
                j--;
            }
        }
    }

    public void Task_2_21(int[,] A, int[,] B, out int[] answerA, out int[] answerB)
    {
        answerA = null;
        answerB = null;

        // code here

        // create and use CreateArrayFromMins(matrix);

        // end
    }

    public void Task_2_22(int[,] matrix, out int[] rows, out int[] cols) // dotnet test --filter Tests.ProgramTests.Task_2_22Test
    {
        // code here

        rows = new int[matrix.GetLength(0)];
        cols = new int[matrix.GetLength(1)];

        for (int i = 0; i < matrix.GetLength(0); i++) {
            rows[i] = CountNegativeInRow(matrix, i);
        }

        for (int j = 0; j < matrix.GetLength(1); j++) {
            cols[j] = FindMaxNegativePerColumn(matrix, j);
    }
        // end
    }

    public static int CountNegativeInRow(int[,] matrix, int rowIndex)
    {
        int count = 0;
        for (int j = 0; j < matrix.GetLength(1); j++) {
            if (matrix[rowIndex, j] < 0) {
                count++;
            }
        }
        return count;
    }

    public int FindMaxNegativePerColumn(int[,] matrix, int colIndex)
    {
        int maxNeg = int.MinValue;
        for (int i = 0; i < matrix.GetLength(0); i++) {
            if (matrix[i, colIndex] < 0 && matrix[i, colIndex] > maxNeg) {
                maxNeg = matrix[i, colIndex];
            }
        }
        if (maxNeg == int.MinValue) return 0;
        return maxNeg;
    }

    public void Task_2_23(double[,] A, double[,] B)
    {
        // code here

        // create and use MatrixValuesChange(matrix);

        // end
    }

    public void Task_2_24(int[,] A, int[,] B) // dotnet test --filter Tests.ProgramTests.Task_2_24Test
    {
        // code here

        int rowA = 0, colA = 0, rowB = 0, colB = 0;

        FindMaxIndex(A, out rowA, out colA);
        FindMaxIndex(B, out rowB, out colB);

        SwapColumnDiagonal(A, colA);
        SwapColumnDiagonal(B, colB);
        // end
    }

    public void FindMaxIndex(int[,] matrix, out int row, out int col) {
        row = 0;
        col = 0;
        int max = int.MinValue;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] > max)
                {
                    max = matrix[i, j];
                    row = i;
                    col = j;
                }
            }
        }
    }

    public void SwapColumnDiagonal(int[,] matrix, int colIndex) {
        for (int i=0; i<matrix.GetLength(0); i++)
        {
            int temp = matrix[i, i];
            matrix[i, i] = matrix[i, colIndex];
            matrix[i, colIndex] = temp;
        }
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

    public void Task_2_26(int[,] A, int[,] B) // dotnet test --filter Tests.ProgramTests.Task_2_26Test
    {
        // code here

        int rowA = FindRowWithMaxNegativeCount(A);
        int rowB = FindRowWithMaxNegativeCount(B);
        SwapRows(A, rowA, B, rowB);
        // end
    }
    public static int FindRowWithMaxNegativeCount(int[,] matrix)
    {
        int[] countNeg = new int[matrix.GetLength(0)];
        int indexMaxNegRow = 0;

        for (int i = 0; i < countNeg.GetLength(0); i++) {
            countNeg[i] = CountNegativeInRow(matrix, i);
        }

        for (int i = 1; i < countNeg.Length; i++) {
            if (countNeg[i] > countNeg[indexMaxNegRow]) indexMaxNegRow = i;
        }

        return indexMaxNegRow;
    }

    public static void SwapRows(int[,] A, int rowA, int[,] B, int rowB)
    {
        for (int j = 0; j < A.GetLength(1); j++) {
            int tmp = B[rowB, j];
            B[rowB, j] = A[rowA, j];
            A[rowA, j] = tmp;
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

    public void Task_2_28a(int[] first, int[] second, ref int answerFirst, ref int answerSecond) // dotnet test --filter Tests.ProgramTests.Task_2_28aTest
    {
        // code here

        answerFirst = FindSequence(first, 0, first.Length - 1);
        answerSecond = FindSequence(second, 0, second.Length - 1);
        Console.WriteLine((answerFirst, answerSecond));

        // end
    }

    public static int FindSequence(int[] array, int A, int B) {
        bool flagIncreasing = true, flagDecreasing = true;
        for (int i=A; i<B; i++) {
            if (array[i] > array[i+1]) flagIncreasing = false;
            if (array[i] < array[i+1]) flagDecreasing = false;
        }
        if (!flagIncreasing && !flagDecreasing) return 0;
        if (flagIncreasing) return 1;
        return -1;

    }

    public void Task_2_28b(int[] first, int[] second, ref int[,] answerFirst, ref int[,] answerSecond) // dotnet test --filter Tests.ProgramTests.Task_2_28bTest
    {
        // code here
    FindMonotonicIntervals(first, ref answerFirst);
    FindMonotonicIntervals(second, ref answerSecond);
        // end
    }

    public void FindMonotonicIntervals(int[] data, ref int[,] result)
    {
        int count = 0;
        for (int i = 0; i < data.Length; i++) {
            for (int j = i + 1; j < data.Length; j++) {
                if (FindSequence(data, i, j) != 0) count++;
            }
        }
        result = new int[count, 2];
        int ind = 0;
        for (int i = 0; i < data.Length; i++) {
            for (int j = i + 1; j < data.Length; j++) {
                if (FindSequence(data, i, j) != 0) {
                    result[ind, 0] = i;
                    result[ind, 1] = j;
                    ind++;
                }
            }
        }
    }


    public void Task_2_28c(int[] first, int[] second, ref int[] answerFirst, ref int[] answerSecond) // dotnet test --filter Tests.ProgramTests.Task_2_28cTest
    {
        // code here
        answerFirst = FindTheLongestInterval(first);
        answerSecond = FindTheLongestInterval(second);
        // end
    }

    
    public static int[] FindTheLongestInterval(int[] array) {
        int[] result = new int[] { 0, 0 };

        for (int start = 0; start < array.Length; start++) {
            for (int end = start + 1; end < array.Length; end++) {
                if (FindSequence(array, start, end) != 0) {
                    if (end - start > result[1] - result[0]) {
                        result[0] = start;
                        result[1] = end;
                    }
                }
            }
        }
        return result;
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
    public void Task_3_2(int[,] matrix) // dotnet test --filter Tests.ProgramTests.Task_3_2Test
    {
        SortRowStyle sortStyle = default(SortRowStyle);

        // code here
        for (int i = 0; i < matrix.GetLength(0); i++) {
            if (i % 2 == 0) sortStyle = SortAscending;
            else sortStyle = SortDescending;

            sortStyle(matrix, i);
        }
        // end
    }

    public void SortAscending(int[,] matrix, int rowIndex)
    {
        int[] row = new int[matrix.GetLength(1)];

        for (int j = 0; j < matrix.GetLength(1); j++) {
            row[j] = matrix[rowIndex, j];
        }
        for (int i = 0; i < row.Length - 1; i++) {
            for (int j = 0; j < row.Length - 1 - i; j++) {
                if (row[j] > row[j + 1]) {
                    int temp = row[j];
                    row[j] = row[j + 1];
                    row[j + 1] = temp;
                }
            }
        }

        for (int j = 0; j < matrix.GetLength(1); j++) {
            matrix[rowIndex, j] = row[j];
        }
    }

    public void SortDescending(int[,] matrix, int rowIndex)
    {
        int[] row = new int[matrix.GetLength(1)];

        for (int j = 0; j < matrix.GetLength(1); j++) {
            row[j] = matrix[rowIndex, j];
        }
        for (int i = 0; i < row.Length - 1; i++) {
            for (int j = 0; j < row.Length - 1 - i; j++) {
                if (row[j] < row[j + 1]) {
                    int temp = row[j];
                    row[j] = row[j + 1];
                    row[j + 1] = temp;
                }
            }
        }

        for (int j = 0; j < matrix.GetLength(1); j++) {
            matrix[rowIndex, j] = row[j];
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

    public int Task_3_4(int[,] matrix, bool isUpperTriangle)  // dotnet test --filter Tests.ProgramTests.Task_3_4Test
    {
        int answer = 0;

        // code here
        GetTriangle getTriangle = isUpperTriangle ? new GetTriangle(GetUpperTriangle) : new GetTriangle(GetLowerTriangle);

        answer = GetSum(getTriangle, matrix);
        // end

        return answer;
    }

    public delegate int GetTriangle(int[,] matrix);
    public int GetUpperTriangle(int[,] matrix)
    {
        int size = matrix.GetLength(0);
        int sum = 0;

        for (int i = 0; i < size; i++) {
            for (int j = i; j < size; j++) {
                sum += matrix[i, j] * matrix[i, j];
            }
        }

        return sum;
    }
    public int GetLowerTriangle(int[,] matrix)
    {
        int size = matrix.GetLength(0);
        int sum = 0;

        for (int i = 0; i < size; i++) {
            for (int j = 0; j <= i; j++) sum += matrix[i, j] * matrix[i, j];
        }

        return sum;
    }

    public int GetSum(GetTriangle getTriangle, int[,] matrix)
    {
        return getTriangle(matrix);
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

    public void Task_3_6(int[,] matrix) // dotnet test --filter Tests.ProgramTests.Task_3_6Test
    {
        // code here

        FindElementDelegate findDiagonalMaxIndex = new FindElementDelegate(FindDiagonalMaxIndex);
        FindElementDelegate findFirstRowMaxIndex = new FindElementDelegate(FindFirstRowMaxIndex);

        SwapColumns(matrix, findDiagonalMaxIndex, findFirstRowMaxIndex);

        // end
    }

    public delegate int FindElementDelegate(int[,] matrix);
    public int FindFirstRowMaxIndex(int[,] matrix)
    {
        int size = matrix.GetLength(1);
        int maxIndex = 0;
        for (int i = 1; i < size; i++) {
            if (matrix[0, i] > matrix[0, maxIndex]) {
                maxIndex = i;
            }
        }

        return maxIndex;
    }

    public void SwapColumns(int[,] matrix, FindElementDelegate findDiagonalMaxIndex, FindElementDelegate findFirstRowMaxIndex)
    {
        int diagonalMaxIndex = findDiagonalMaxIndex(matrix);
        int firstRowMaxIndex = findFirstRowMaxIndex(matrix);

        int size = matrix.GetLength(0);

        for (int i = 0; i < size; i++) {
            int temp = matrix[i, diagonalMaxIndex];
            matrix[i, diagonalMaxIndex] = matrix[i, firstRowMaxIndex];
            matrix[i, firstRowMaxIndex] = temp;
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

    public void Task_3_10(ref int[,] matrix) // dotnet test --filter Tests.ProgramTests.Task_3_10Test
    {
        // FindIndex searchArea = default(FindIndex);

        // code here

        FindIndex searchArea = default(FindIndex);

        matrix = RemoveColumns(matrix, FindMaxBelowDiagonalIndex, FindMinAboveDiagonalIndex);
        // end
    }
    public delegate int FindIndex(int[,] matrix);

    public static int[,] RemoveColumns(int[,] matrix, FindIndex firstCol, FindIndex secondCol)
    {
        int col1 = firstCol(matrix);
        int col2 = secondCol(matrix);

        if (col1 == col2) matrix = RemoveColumn(matrix, col1);
        else if (col2 > col1) {
            matrix = RemoveColumn(matrix, col2);
            matrix = RemoveColumn(matrix, col1);
        }
        else {
            matrix = RemoveColumn(matrix, col1);
            matrix = RemoveColumn(matrix, col2);
        }

        return matrix;
    }

    public static int FindMaxBelowDiagonalIndex(int[,] matrix)
    {
        int n = matrix.GetLength(0);
        int maxVal = matrix[0, 0];
        int maxIdx = 0;

        for (int i = 0; i < n; i++) {
            for (int j = 0; j <= i; j++) {
                if (matrix[i, j] > maxVal)
                {
                    maxVal = matrix[i, j];
                    maxIdx = j;
                }
            }
        }

        return maxIdx;
    }

    public static int FindMinAboveDiagonalIndex(int[,] matrix)
    {
        int minVal = matrix[0, 1];
        int minIdx = 1;

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = i + 1; j < matrix.GetLength(0); j++)
            {
                if (matrix[i, j] < minVal)
                {
                    minVal = matrix[i, j];
                    minIdx = j;
                }
            }
        }

        return minIdx;
    }



    public void Task_3_13(ref int[,] matrix)
    {
        // code here

        // use public delegate FindElementDelegate(matrix) from Task_3_6
        // create and use method RemoveRows(matrix, findMax, findMin)

        // end
    }

    public void Task_3_22(int[,] matrix, out int[] rows, out int[] cols) // dotnet test --filter Tests.ProgramTests.Task_3_22Test
    {

        rows = null;
        cols = null;

        // code here

        rows = GetNegativeCountPerRow(matrix);
        cols = GetMaxNegativePerColumn(matrix);

        FindNegatives(matrix, GetNegativeCountPerRow, GetMaxNegativePerColumn, out rows, out cols);
        // end
    }

    public delegate int[] GetNegativeArray(int[,] matrix);

    public static int[] GetNegativeCountPerRow(int[,] matrix)
    {
        int rowCount = matrix.GetLength(0);
        int[] rowNegatives = new int[rowCount];

        for (int i = 0; i < rowCount; i++) {
            int count = 0;
            for (int j = 0; j < matrix.GetLength(1); j++) {
                if (matrix[i, j] < 0) {
                    count++;
                }
            }
            rowNegatives[i] = count;
        }

        return rowNegatives;
    }

    public static int[] GetMaxNegativePerColumn(int[,] matrix)
    {
        int colCount = matrix.GetLength(1);
        int[] colMaxNegatives = new int[colCount];

        for (int j = 0; j < colCount; j++) {
            int maxNegative = int.MinValue;
            for (int i = 0; i < matrix.GetLength(0); i++) {
                if (matrix[i, j] < 0 && matrix[i, j] > maxNegative) {
                    maxNegative = matrix[i, j];
                }
            }
            colMaxNegatives[j] = maxNegative == int.MinValue ? 0 : maxNegative;
        }

        return colMaxNegatives;
    }

    public static void FindNegatives(int[,] matrix, GetNegativeArray searcherRows, GetNegativeArray searcherCols, out int[] rows, out int[] cols)
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

    public void Task_3_28a(int[] first, int[] second, ref int answerFirst, ref int answerSecond) // dotnet test --filter Tests.ProgramTests.Task_3_28aTest
    {
        // code here

        answerFirst = DefineSequence(first, FindIncreasingSequence, FindDecreasingSequence);
        answerSecond = DefineSequence(second, FindIncreasingSequence, FindDecreasingSequence);
        // end
    }

    public delegate bool IsSequence(int[] array, int left, int right);

    public static bool FindIncreasingSequence(int[] array, int left, int right)
    {
        for (int i = left; i < right; i++) {
            if (array[i] >= array[i + 1]) {
                return false;
            }
        }
        return true;
    }

    public static bool FindDecreasingSequence(int[] array, int left, int right)
    {
        for (int i = left; i < right; i++) {
            if (array[i] <= array[i + 1]) {
                return false;
            }
        }
        return true;
    }

    public static int DefineSequence(int[] array, IsSequence increasing, IsSequence decreasing)
    {
        if (increasing(array, 0, array.Length - 1)) {
            return 1;
        } else if (decreasing(array, 0, array.Length - 1)) {
            return -1;
        } else {
            return 0;
        }
    }

    public void Task_3_28c(int[] first, int[] second, ref int[] answerFirstIncrease, ref int[] answerFirstDecrease, ref int[] answerSecondIncrease, ref int[] answerSecondDecrease) // dotnet test --filter Tests.ProgramTests.Task_3_28cTest
    {
        // code here

        answerFirstIncrease = FindLongestSequence(first, FindIncreasingSequence);
        answerFirstDecrease = FindLongestSequence(first, FindDecreasingSequence);
        answerSecondIncrease = FindLongestSequence(second, FindIncreasingSequence);
        answerSecondDecrease = FindLongestSequence(second, FindDecreasingSequence);
        // end
    }

    public static int[] FindLongestSequence(int[] array, IsSequence sequence) {
        int[] result = new int[] { 0, 0 };

        for (int startIndex = 0; startIndex < array.Length; startIndex++) {
            for (int endIndex = startIndex + 1; endIndex < array.Length; endIndex++) {
                if (sequence(array, startIndex, endIndex) && endIndex - startIndex > result[1] - result[0]) {
                    result[0] = startIndex;
                    result[1] = endIndex;
                }
            }
        }

        return result;
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
