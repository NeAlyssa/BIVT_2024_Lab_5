using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Numerics;
using System.Reflection;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class Program
{
    public static void Main()
    {
        Program program = new Program();
    }
    #region Level 1

    public static long Factorial(int n)
    {
        long f = 1;
        for (int i = 1; i <= n; i++) { f *= i; }
        return f;
    }

    public static long Combinations(int n, int k) { 
        return Factorial(n) / (Factorial(k) * Factorial(n - k));
    }

    public long Task_1_1(int n, int k)
    {
        long answer = 0;

        // code here

        if (n < 0 || k < 0 || k > n) { return 0; }
        answer = Combinations(n, k);

        // end

        return answer;
    }

    public static double GeronArea(double x, double y, double z) {
        double p = (x + y + z) / 2.0;
        return Math.Sqrt(p * (p - x) * (p - y) * (p - z));
    }

    public static bool TriangleExists(double[] sides) {
        double c1 = sides[0]; double c2 = sides[1]; double c3 = sides[2];
        if (c1 + c2 <= c3 || c1 + c2 <= c2 || c3 + c2 <= c1) { return false; }
        foreach (double x in sides) { if (x <= 0) return false; }
        return true;
    }

    public int Task_1_2(double[] first, double[] second)
    {
        int answer = 0;

        // code here

        if (!(TriangleExists(first) && TriangleExists(second))) { 
            return -1; 
        }
        double s1 = GeronArea(first[0], first[1], first[2]);
        double s2 = GeronArea(second[0], second[1], second[2]);
        if (s1 > s2) answer = 1;
        else if (s1 < s2) answer = 2;
        else answer = 0;

        // end
        return answer;
    }

    public static double GetDistance(double v, double a, int t) {
        return v * t + a * t * t / 2.0;
    }

    public int Task_1_3a(double v1, double a1, double v2, double a2, int time)
    {
        int answer = 0;

        // code here

        double d1 = GetDistance(v1, a1, time);
        double d2 = GetDistance(v2, a2, time);
        if (d1 > d2) answer = 1;
        else if (d1 < d2) answer = 2;
        else answer = 0;

        // end

        // first = 1, second = 2, equal = 0
        return answer;
    }

    public int Task_1_3b(double v1, double a1, double v2, double a2)
    {
        int answer = 0;

        // code here

        answer++;

        while (GetDistance(v1, a1, answer) > GetDistance(v2, a2, answer))
            answer++;

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

    public static bool ValidateMatrix(double[,] m, int a, int b) { 
        if (m.GetLength(0) == a && m.GetLength(1) == b) return true;
        return false;
    }

    public static bool ValidateArray(double[] arr, int a) { 
        if (arr.Length == a) return true;
        return false;
    }

    public static bool ValidateMatrix(int[,] m, int a, int b)
    {
        if (m.GetLength(0) == a && m.GetLength(1) == b) return true;
        return false;
    }

    public static bool ValidateArray(int[] arr, int a)
    {
        if (arr.Length == a) return true;
        return false;
    }


    public static int FindMaxindex(double[] arr) { 
        double maxi = double.MinValue; int index = -1;
        for (int i = 0; i < arr.Length; i++) { 
            if (arr[i] > maxi) { maxi = arr[i]; index = i; }
        }
        return index;
    }

    public void Task_2_2(double[] A, double[] B)
    {
        // code here

        if (ValidateArray(A, 9) && ValidateArray(B, 7)) { 
            int iA = FindMaxindex(A);
            int iB = FindMaxindex(B);
            double s = 0; double k = 0;
            if (9 - iA > 7 - iB)
            {
                for (int i = iA + 1; i < A.Length; i++)
                {
                    s += A[i]; k++;
                }
                A[iA] = s / k;
            }
            else {
                for (int i = iB + 1; i < B.Length; i++)
                {
                    s += B[i]; k++;
                }
                B[iB] = s / k;
            }
        }
        else if (ValidateArray(A, 7) && ValidateArray(B, 9))
        {
            int iA = FindMaxindex(A);
            int iB = FindMaxindex(B);
            double s = 0; double k = 0;
            if (7 - iA > 9 - iB)
            {
                for (int i = iA + 1; i < A.Length; i++)
                {
                    s += A[i]; k++;
                }
                A[iA] = s / k;
            }
            else
            {
                for (int i = iB + 1; i < B.Length; i++)
                {
                    s += B[i]; k++;
                }
                B[iB] = s / k;
            }
        }

        // end
    }

    public void Task_2_3(ref int[,] B, ref int[,] C)
    {
        // code here

        //  create and use method FindDiagonalMaxIndex(matrix);

        // end
    }


    public static int FindDiagonalMaxIndex(int[,] m) {
        int maxi = int.MinValue; int max_index = -1;
        int n = m.GetLength(0);
        for (int i = 0; i < n; i++) {
            if (m[i, i] > maxi) { 
                maxi = m[i, i]; max_index = i;
            }
        }
        return max_index;
    }

    public void Task_2_4(int[,] A, int[,] B)
    {
        // code here

        int maxA = FindDiagonalMaxIndex(A);
        int maxB = FindDiagonalMaxIndex(B);
        int[] rowA = new int[A.GetLength(0)];
        int[] colB = new int[B.GetLength(0)];
        for (int i = 0; i < A.GetLength(0); i++) { 
            rowA[i] = A[maxA, i];
        }
        for (int i = 0; i < B.GetLength(0); i++) {
            colB[i] = B[i, maxB];
        }

        for (int i = 0; i < A.GetLength(0); i++)
        {
            A[maxA, i] = colB[i];
        }
        for (int i = 0; i < B.GetLength(0); i++)
        {
            B[i, maxB] = rowA[i];
        }

        // end
    }

    public void Task_2_5(int[,] A, int[,] B)
    {
        // code here

        // create and use FindMaxInColumn(matrix, columnIndex, out rowIndex);

        // end
    }

    public static void FindMax(int[] arr, out int ind) {
        ind = -1;
        int maxi = int.MinValue;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] > maxi) { maxi = arr[i]; ind = i; }
        }
    }

    public int[] DeleteElement(int[] arr, int index)
    {
        int[] arr_less = new int[arr.Length - 1];
        for (int i = 0; i < arr.Length; i++) {
            if (i == index) { continue; }
            else if (i < index) { arr_less[i] = arr[i]; }
            else {  arr_less[i - 1] = arr[i]; }
        }

        return arr_less;
    }

    public int[] MergeArrays(int[] arr1, int[] arr2)
    {
        int[] merged = new int[arr1.Length + arr2.Length];
        int i = 0;
        foreach (int item in arr1) {
            merged[i++] = item;
        }
        foreach (int item in arr2)
        {
            merged[i++] = item;
        }

        return merged;
    }
    
    public void Task_2_6(ref int[] A, int[] B)
    {
        // code here
        int indA, indB;
        FindMax(A, out indA);
        FindMax(B, out indB);

        A = DeleteElement(A, indA);
        B = DeleteElement(B, indB);

        A = MergeArrays(A, B);
        // end
    }

    public void Task_2_7(ref int[,] B, int[,] C)
    {
        // code here

        // create and use CountRowPositive(matrix, rowIndex);
        // create and use CountColumnPositive(matrix, colIndex);

        // end
    }

    public static void SortArrayPart(int[] arr, int startIndex) {
        for (int i = startIndex + 1; i < arr.Length; i++)
        {
            int k = i; int j = i - 1;
            while (j >= startIndex + 1)
            {
                if (arr[j] > arr[k])
                {
                    int tmp = arr[j];
                    arr[j] = arr[k];
                    arr[k] = tmp;
                    k = j;
                }
                j--;
            }
        }
    }

    public void Task_2_8(int[] A, int[] B)
    {
        // code here

        int indA, indB;
        FindMax(A, out indA); FindMax(B, out indB);
        SortArrayPart(A, indA); SortArrayPart(B, indB);

        // end
    }

    public int[] Task_2_9(int[,] A, int[,] C)
    {
        int[] answer = default(int[]);

        // code here

        // create and use SumPositiveElementsInColumns(matrix);

        // end

        return answer;
    }

    public int[,] RemoveColumn(int[,] matrix, int columnIndex) {
        int[,] matrix2 = new int[matrix.GetLength(0), matrix.GetLength(1) - 1];
        for (int i = 0; i < matrix.GetLength(0); i++) {
            for (int j = 0; j < matrix.GetLength(1); j++) {
                if (j == columnIndex) { continue; }
                else if (j < columnIndex) { matrix2[i, j] = matrix[i, j]; }
                else { matrix2[i, j - 1] = matrix[i, j]; }
            }
        }

        return matrix2;
    }

    public void Task_2_10(ref int[,] matrix)
    {
        // code here

        int maxi = int.MinValue;
        int maxi_j = -1;
        int mini = int.MaxValue;
        int mini_j = -1;
        for (int i = 0; i < matrix.GetLength(0); i++) {
            for (int j = 0; j < matrix.GetLength(1); j++) {
                if (i >= j)
                {
                    if (matrix[i, j] > maxi) { maxi = matrix[i, j]; maxi_j = j; }
                }
                else {
                    if (matrix[i, j] < mini) { mini = matrix[i, j]; mini_j = j; }
                }
            }
        }

        if (maxi_j == mini_j)
        {
            matrix = RemoveColumn(matrix, maxi_j);
        }
        else if (maxi_j > mini_j)
        {
            matrix = RemoveColumn(matrix, maxi_j);
            matrix = RemoveColumn(matrix, mini_j);
        }
        else {
            matrix = RemoveColumn(matrix, mini_j);
            matrix = RemoveColumn(matrix, maxi_j);
        }

        // end
    }

    public void Task_2_11(int[,] A, int[,] B)
    {
        // code here

        // use FindMaxIndex(matrix, out row, out column); from Task_2_1

        // end
    }

    public int FindMaxColumnIndex(int[,] matrix) {
        int maxi = int.MinValue;
        int maxi_j = -1;

        for (int i = 0; i < matrix.GetLength(0); i++) {
            for (int j = 0; j < matrix.GetLength(1); j++) {
                if (matrix[i, j] > maxi) { maxi = matrix[i, j]; maxi_j = j; }
            }
        }

        return maxi_j;
    }

    public void Task_2_12(int[,] A, int[,] B)
    {
        // code here

        int maxA = FindMaxColumnIndex(A); int maxB = FindMaxColumnIndex(B);
        int tmp;
        for (int i = 0; i < A.GetLength(0); i++) {
            tmp = A[i, maxA];
            A[i, maxA] = B[i, maxB];
            B[i, maxB] = tmp;
        }

        // end
    }

    public void Task_2_13(ref int[,] matrix)
    {
        // code here

        // create and use RemoveRow(matrix, rowIndex);

        // end
    }

    public void SortRow(int[,] matrix, int rowIndex) {
        int n = matrix.GetLength(1); int tmp;
        for (int j = 1; j < n; j++) {
            while (j != 0 && matrix[rowIndex, j - 1] > matrix[rowIndex, j])
            {
                tmp = matrix[rowIndex, j];
                matrix[rowIndex, j] = matrix[rowIndex, j - 1];
                matrix[rowIndex, j - 1] = tmp;
                j--;
            }
        }
    }

    public void Task_2_14(int[,] matrix)
    {
        // code here

        for (int i = 0; i < matrix.GetLength(0); i++) {
            SortRow(matrix, i);
        }

        // end
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

    public void SortNegative(int[] arr) {
        int k_neg = 0;
        for (int i = 0; i < arr.Length; i++) { 
            if (arr[i] < 0) { k_neg++; }
        }

        int[] neg_indx = new int[k_neg];
        int neg_ind = 0;
        for (int i = 0; i < arr.Length; i++) {
            if (arr[i] < 0) { neg_indx[neg_ind++] = i; }
        }

        int n = neg_indx.Length; int tmp;
        for (int i = 1; i < n; i++) {
            while (i != 0 && arr[neg_indx[i]] > arr[neg_indx[i - 1]]) {
                tmp = arr[neg_indx[i]];
                arr[neg_indx[i]] = arr[neg_indx[i - 1]];
                arr[neg_indx[i - 1]] = tmp;
                i--;
            }
        }
    }

    public void Task_2_16(int[] A, int[] B)
    {
        // code here

        SortNegative(A); SortNegative(B);

        // end
    }

    public void Task_2_17(int[,] A, int[,] B)
    {
        // code here

        // create and use SortRowsByMaxElement(matrix);

        // end
    }

    public void SortDiagonal(int[,] matrix) { 
        int n = matrix.GetLength(0); int tmp;
        for (int i = 1; i < n; i++) {
            while (i != 0 && (matrix[i, i] < matrix[i - 1, i - 1])) { 
                tmp = matrix[i, i];
                matrix[i, i] = matrix[i - 1, i - 1];
                matrix[i - 1, i - 1] = tmp;
                i--;
            }
        }
    }

    public void Task_2_18(int[,] A, int[,] B)
    {
        // code here

        SortDiagonal(A); SortDiagonal(B);

        // end
    }

    public void Task_2_19(ref int[,] matrix)
    {
        // code here

        // use RemoveRow(matrix, rowIndex); from 2_13

        // end
    }

    public bool HasZeros(int[,] m, int colIndex) {
        for (int i = 0; i < m.GetLength(0); i++) {
            if (m[i, colIndex] == 0) return true;
        }
        return false;
    }

    //public int[] GetColsWithNoZeros(int[,] matrix) {
    //    int k = 0;
    //    for (int j = 0; j < matrix.GetLength(1); j++) {
    //        if (!(HasZeros(matrix, j))) { k++; }
    //    }
    //    int[] arr = new int[k];
    //    int i = 0;
    //    for (int j = 0; j < matrix.GetLength(1); j++)
    //    {
    //        if (!(HasZeros(matrix, j))) { arr[i++] = j; }
    //    }

    //    return arr;
    //}

    public void InsertSort(int[] arr) {
        int n = arr.Length; int tmp;
        for (int i = 1; i < n; i++) {
            while (i != 0 && arr[i - 1] < arr[i]) {
                tmp = arr[i];
                arr[i] = arr[i - 1];
                arr[i - 1] = tmp;
                i--;
            }
        }
    }

    public void Task_2_20(ref int[,] A, ref int[,] B)
    {
        // code here

        int kA = 0;
        for (int j = 0; j < A.GetLength(1); j++)
        {
            if (!(HasZeros(A, j))) { kA++; }
        }
        int[] arrA = new int[kA];
        int i = 0;
        for (int j = 0; j < A.GetLength(1); j++)
        {
            if (!(HasZeros(A, j))) { arrA[i++] = j; }
        }

        int kB = 0;
        for (int j = 0; j < B.GetLength(1); j++)
        {
            if (!(HasZeros(B, j))) { kB++; }
        }
        int[] arrB = new int[kB];
        i = 0;
        for (int j = 0; j < B.GetLength(1); j++)
        {
            if (!(HasZeros(B, j))) { arrB[i++] = j; }
        }

        InsertSort(arrA); InsertSort(arrB);

        foreach (int ind in arrA) {
            A = RemoveColumn(A, ind);
        }

        foreach (int ind in arrB)
        {
            B = RemoveColumn(B, ind);
        }

        // end
    }

    public void Task_2_21(int[,] A, int[,] B, out int[] answerA, out int[] answerB)
    {
        answerA = null;
        answerB = null;

        // code here

        // create and use CreateArrayFromMins(matrix);

        // end
    }

    public int CountNegativeInRow(int[,] matrix, int rowIndex) {
        int k = 0;
        for (int j = 0; j < matrix.GetLength(1); j++) {
            if (matrix[rowIndex, j] < 0) { k++; }
        }
        return k;
    }

    public int[] FindMaxNegativesPerColumn(int[,] matrix)
    {
        int[] arr = new int[matrix.GetLength(1)];
        for (int j = 0; j < matrix.GetLength(1); j++) {
            int maxi = int.MinValue;
            for (int i = 0; i < matrix.GetLength(0); i++) {
                if (matrix[i, j] > maxi && matrix[i, j] < 0) { maxi = matrix[i, j]; }
            }
            arr[j] = maxi;
        }
        return arr;
    }

    public void Task_2_22(int[,] matrix, out int[] rows, out int[] cols)
    {
        rows = null;
        cols = null;

        // code here

        rows = new int[matrix.GetLength(0)];
        cols = new int[matrix.GetLength(1)];

        for (int i = 0; i < matrix.GetLength(0); i++) {
            rows[i] = CountNegativeInRow(matrix, i);
        }
        cols = FindMaxNegativesPerColumn(matrix);

        // end
    }

    public void Task_2_23(double[,] A, double[,] B)
    {
        // code here

        // create and use MatrixValuesChange(matrix);

        // end
    }

    public void FindMaxIndex(int[,] matrix, out int row, out int col) {
        row = -1;
        col = -1;
        int maxi = int.MinValue;
        for (int i = 0; i < matrix.GetLength(0); i++) {
            for (int j = 0; j < matrix.GetLength(1); j++) {
                if (matrix[i, j] > maxi) { maxi = matrix[i, j]; row = i; col = j; }
            }
        }
    }

    public void SwapColumnDiagonal(int[,] matrix, int columnIndex) { 
        int n = matrix.GetLength(0); int tmp;
        for (int i = 0; i < n; i++) { 
            tmp = matrix[i, columnIndex];
            matrix[i, columnIndex] = matrix[i, i];
            matrix[i, i] = tmp;
        }
    }

    public void Task_2_24(int[,] A, int[,] B)
    {
        // code here

        int rowA, colA;
        FindMaxIndex(A, out rowA, out colA);
        SwapColumnDiagonal(A, colA);

        int rowB, colB;
        FindMaxIndex(B, out rowB, out colB);
        SwapColumnDiagonal(B, colB);

        // end
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


    public int FindRowWithMaxNegativeCount(int[,] matrix) {
        int max_count = -1;
        int row_ind = -1;
        for (int i = 0; i < matrix.GetLength(0); i++) {
            int k = CountNegativeInRow(matrix, i);
            if (k > max_count) { max_count = k; row_ind = i; }
        }

        return row_ind;
    }

    public void Task_2_26(int[,] A, int[,] B)
    {
        // code here

        int rowA, rowB, tmp;
        rowA = FindRowWithMaxNegativeCount(A);
        rowB = FindRowWithMaxNegativeCount(B);
        for (int j = 0; j < A.GetLength(0); j++) { 
            tmp = A[rowA, j];
            A[rowA, j] = B[rowB, j];
            B[rowB, j] = tmp;
        }

        // end
    }

    public void Task_2_27(int[,] A, int[,] B)
    {
        // code here

        // create and use FindRowMaxIndex(matrix, rowIndex, out columnIndex);
        // create and use ReplaceMaxElementOdd(matrix, row, column);
        // create and use ReplaceMaxElementEven(matrix, row, column);

        // end
    }

    public int FindSequence(int[] array, int A, int B) {
        bool f1 = true;
        for (int i = A; i <= B - 1; i++) {
            if (array[i] <= array[i + 1]) { continue; }
            else { f1 = false; break; }
        }
        if (f1) { return 1; }
        bool f2 = true;
        for (int i = A; i <= B - 1; i++)
        {
            if (array[i] >= array[i + 1]) { continue; }
            else { f2 = false; break; }
        }
        if (f2) { return -1; }
        return 0;
    }

    public void Task_2_28a(int[] first, int[] second, ref int answerFirst, ref int answerSecond)
    {
        // code here

        answerFirst = FindSequence(first, 0, first.Length - 1);
        answerSecond = FindSequence(second, 0, second.Length - 1);

        // end
    }

    public bool SequenceExists(int[] array, int A, int B) {
        int res = FindSequence(array, A, B);
        if (res == 0) { return false; }
        return true;
    }

    public int GetCountOfSequences(int[] array) {
        int n, count_for_answer;
        n = array.Length;
        count_for_answer = 0;
        for (int i = 0; i < n; i++)
        {
            int j = i + 1;
            while (j < n)
            {
                if (SequenceExists(array, i, j))
                {
                    count_for_answer++;
                }
                else { break; }
                j++;
            }
        }
        return count_for_answer;
    }

    public void Task_2_28b(int[] first, int[] second, ref int[,] answerFirst, ref int[,] answerSecond)
    {
        // code here
        int n, count_for_answer;
        n = first.Length;
        count_for_answer = 0;
        answerFirst = new int[GetCountOfSequences(first), 2];
        for (int i = 0; i < n; i++) {
            int j = i + 1;
            while (j < n) {
                if (SequenceExists(first, i, j))
                {
                    answerFirst[count_for_answer, 0] = i;
                    answerFirst[count_for_answer, 1] = j;
                    count_for_answer++;
                }
                else { break; }
                j++;
            }
        }

        n = second.Length;
        count_for_answer = 0;
        answerSecond = new int[GetCountOfSequences(second), 2];
        for (int i = 0; i < n; i++)
        {
            int j = i + 1;
            while (j < n)
            {
                if (SequenceExists(second, i, j))
                {
                    answerSecond[count_for_answer, 0] = i;
                    answerSecond[count_for_answer, 1] = j;
                    count_for_answer++;
                }
                else { break; }
                j++;
            }
        }

        // end
    }

    public void Task_2_28c(int[] first, int[] second, ref int[] answerFirst, ref int[] answerSecond)
    {
        // code here

        int[,] sequencesFirst = null;
        int[,] sequencesSecond = null;
        int maxi;
        maxi = int.MinValue;
        Task_2_28b(first, second, ref sequencesFirst, ref sequencesSecond);

        for (int i = 0; i < sequencesFirst.GetLength(0); i++) {
            if (sequencesFirst[i, 1] - sequencesFirst[i, 0] > maxi) { 
                maxi = sequencesFirst[i, 1] - sequencesFirst[i, 0];
                answerFirst = new int[]{ sequencesFirst[i, 0], sequencesFirst[i, 1]}; }
        }

        maxi = int.MinValue;
        for (int i = 0; i < sequencesSecond.GetLength(0); i++)
        {
            if (sequencesSecond[i, 1] - sequencesSecond[i, 0] > maxi)
            {
                maxi = sequencesSecond[i, 1] - sequencesSecond[i, 0];
                answerSecond = new int[] { sequencesSecond[i, 0], sequencesSecond[i, 1] };
            }
        }

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

    public delegate void SortRowStyle(int[,] matrix, int rowIndex);

    public void SortAscending(int[,] matrix, int rowIndex) {
        int n = matrix.GetLength(1); int tmp;
        for (int j = 1; j < n; j++) {
            while (j != 0 && matrix[rowIndex, j] < matrix[rowIndex, j - 1]) {
                tmp = matrix[rowIndex, j];
                matrix[rowIndex, j] = matrix[rowIndex, j - 1];
                matrix[rowIndex, j - 1] = tmp;
                j--;
            }
        }
    }

    public void SortDescending(int[,] matrix, int rowIndex) {
        int n = matrix.GetLength(1); int tmp;
        for (int j = 1; j < n; j++)
        {
            while (j != 0 && matrix[rowIndex, j] > matrix[rowIndex, j - 1])
            {
                tmp = matrix[rowIndex, j];
                matrix[rowIndex, j] = matrix[rowIndex, j - 1];
                matrix[rowIndex, j - 1] = tmp;
                j--;
            }
        }
    }

    public void Task_3_2(int[,] matrix)
    {
        SortRowStyle sortStyle = default(SortRowStyle);

        // code here

        for (int i = 0; i < matrix.GetLength(0); i++) {
            if (i % 2 == 0) { sortStyle = SortAscending; }
            else {  sortStyle = SortDescending; }
            sortStyle(matrix, i);
        }

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

        // end

        return answer;
    }

    public delegate int[] GetTriangle(int[,] matrix);

    public int[] GetUpperTriangle(int[,] matrix) {
        int n = matrix.GetLength(0);
        int[] upperTriangle = new int[((n * n - n) / 2) + n];

        int upper_count = 0;
        for (int i = 0; i < matrix.GetLength(0); i++) 
        {
            for (int j = i; j < matrix.GetLength(1); j++)
            {
                upperTriangle[upper_count++] = matrix[i, j];
            }
        }

        return upperTriangle;
    }

    public int[] GetLowerTriangle(int[,] matrix) {
        int n = matrix.GetLength(0);
        int[] lowerTriangle = new int[((n * n - n) / 2) + n];

        int lower_count = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j <= i; j++) 
            {
                lowerTriangle[lower_count++] = matrix[i, j];
            }
        }

        return lowerTriangle;
    }

    public int GetSum(GetTriangle getTriangle, int[,] matrix) {
        int sum = 0;
        int[] arr = getTriangle(matrix);
        foreach (int x in arr) {
            sum += x * x;
        }

        return sum;
    }

    public int Task_3_4(int[,] matrix, bool isUpperTriangle)
    {
        int answer = 0;
        // code here

        GetTriangle getTriangle;
        if (isUpperTriangle)
        {
            getTriangle = GetUpperTriangle;
        }
        else { getTriangle = GetLowerTriangle; }

        answer = GetSum(getTriangle, matrix);

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

        // end
    }

    public delegate int FindElementDelegate(int[,] matrix);

    public int FindFirstRowMaxIndex(int[,] matrix) { 
        int n = matrix.GetLength(1);
        int maxi = int.MinValue; int maxi_index = -1;
        for (int j = 0; j < n; j++) {
            if (matrix[0, j] > maxi) { maxi = matrix[0, j]; maxi_index = j; }
        }
        return maxi_index;
    }

    public void SwapColumns(int[,] matrix, FindElementDelegate diag, FindElementDelegate firstRow) {
        int col1 = diag(matrix);
        int col2 = firstRow(matrix);
        int tmp;
        for (int i = 0; i < matrix.GetLength(0); i++) { 
            tmp = matrix[i, col1];
            matrix[i, col1] = matrix[i, col2];
            matrix[i, col2] = tmp;
        }
    }

    public void Task_3_6(int[,] matrix)
    {
        // code here

        FindElementDelegate findElementDiagonal, findElementFirstRow;
        findElementDiagonal = FindDiagonalMaxIndex;
        findElementFirstRow = FindFirstRowMaxIndex;
        SwapColumns(matrix, findElementDiagonal, findElementFirstRow);

        // end
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

    public delegate int FindIndex(int[,] matrix);

    public int FindMaxBelowDiagonalIndex(int[,] matrix) {
        int maxi = int.MinValue; int maxi_index = -1;
        for (int i = 0; i < matrix.GetLength(0); i++) {
            for (int j = 0; j <= i; j++) {
                if (matrix[i, j] > maxi) { maxi = matrix[i, j]; maxi_index = j; }
            }
        }
        return maxi_index;
    }

    public int FindMinAboveDiagonalIndex(int[,] matrix) {
        int mini = int.MaxValue; int mini_index = -1;
        for (int i = 0; i < matrix.GetLength(0); i++) {
            for (int j = i + 1; j < matrix.GetLength(1); j++) {
                if (matrix[i, j] < mini) { mini = matrix[i, j]; mini_index = j; }
            }
        }
        return mini_index;
    }

    public void RemoveColumns(ref int[,] matrix, FindIndex below, FindIndex above) {
        int col1 = below(matrix);
        int col2 = above(matrix);
        if (col1 == col2)
        {
            matrix = RemoveColumn(matrix, col1);
        }
        else if (col1 > col2)
        {
            matrix = RemoveColumn(matrix, col1);
            matrix = RemoveColumn(matrix, col2);
        }
        else
        {
            matrix = RemoveColumn(matrix, col2);
            matrix = RemoveColumn(matrix, col1);
        }
    }

    public void Task_3_10(ref int[,] matrix)
    {
        FindIndex searchArea = default(FindIndex);

        // code here
        FindIndex searchArea2;

        searchArea = FindMaxBelowDiagonalIndex; searchArea2 = FindMinAboveDiagonalIndex;

        RemoveColumns(ref matrix, searchArea, searchArea2);
        
        // end
    }

    public void Task_3_13(ref int[,] matrix)
    {
        // code here

        // use public delegate FindElementDelegate(matrix) from Task_3_6
        // create and use method RemoveRows(matrix, findMax, findMin)

        // end
    }

    public delegate int[] GetNegativeArray(int[,] matrix);

    public void FindNegatives(int[,] matrix, GetNegativeArray aboutRows, GetNegativeArray aboutCols, out int[] rows, out int[] cols) {
        rows = new int[matrix.GetLength(1)];
        cols = new int[matrix.GetLength(0)];
        rows = aboutRows(matrix);
        cols = aboutCols(matrix);
    }

    public int[] GetNegativeCountPerRow(int[,] matrix) { 
        int[] arr = new int[matrix.GetLength(0)];
        for (int i = 0; i < arr.GetLength(0); i++)
        {
            arr[i] = CountNegativeInRow(matrix, i);
        }
        return arr;
    }

    public void Task_3_22(int[,] matrix, out int[] rows, out int[] cols)
    {

        rows = null;
        cols = null;

        // code here

        GetNegativeArray searcherRows, searcherCols;
        searcherRows = GetNegativeCountPerRow;
        searcherCols = FindMaxNegativesPerColumn;
        FindNegatives(matrix, searcherRows, searcherCols, out rows, out cols);

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

    public delegate bool IsSequence(int[] arr, int left, int right);

    public bool FindIncreasingSequence(int[] array, int A, int B) {
        if (FindSequence(array, A, B) == 1) return true;
        return false;
    }

    public bool FindDecreasingSequence(int[] array, int A, int B) {
        if (FindSequence(array, A, B) == -1) return true;
        return false;
    }

    public int DefineSequence(int[] array, IsSequence findIncreasingSequence, IsSequence findDecreasingSequence) {
        if (findIncreasingSequence(array, 0, array.Length - 1)) { return 1; }
        else if (findDecreasingSequence(array, 0, array.Length - 1)) { return -1; }
        return 0;
    }

    public void Task_3_28a(int[] first, int[] second, ref int answerFirst, ref int answerSecond)
    {
        // code here

        IsSequence findIncreasingSequence, findDecreasingSequence;
        findIncreasingSequence = FindIncreasingSequence; findDecreasingSequence = FindDecreasingSequence;
        answerFirst = DefineSequence(first, findIncreasingSequence, findDecreasingSequence);
        answerSecond = DefineSequence(second, findIncreasingSequence, findDecreasingSequence);

        // end
    }

    public int[] FindLongestSequence(int[] arr, IsSequence sequence) {
        int[] ans = new int[2];
        for (int i = 0; i < arr.Length; i++) {
            int j = i + 1;
            while (j < arr.Length) {
                if (sequence(arr, i, j) && ((j - i) > (ans[1] - ans[0]))) { ans[0] = i; ans[1] = j; }
                j++;
            }
        }
        return ans;
    }

    public void Task_3_28c(int[] first, int[] second, ref int[] answerFirstIncrease, ref int[] answerFirstDecrease, ref int[] answerSecondIncrease, ref int[] answerSecondDecrease)
    {
        // code here

        answerFirstIncrease = FindLongestSequence(first, FindIncreasingSequence);
        answerFirstDecrease = FindLongestSequence(first, FindDecreasingSequence);
        answerSecondIncrease = FindLongestSequence(second, FindIncreasingSequence);
        answerSecondDecrease = FindLongestSequence(second, FindDecreasingSequence);

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
