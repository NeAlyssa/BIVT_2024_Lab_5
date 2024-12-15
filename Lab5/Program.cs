using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        int[,] matrix5x5 = new int[,] {
            { 1, 2, 3, 4, 5 },
            { 6, 7, 8, 9, 10 },
            { 11, 12, 13, 14, 15 },
            { -1, -2, -3, -4, -5 },
            { 0, 7, 8, 9, 1 }};
            int[,] matrix5x52 = new int[,] {
            { 1, 2, 3, 4, 5 },
            { 6, 7, 8, 9, 10 },
            { 11, 12, 13, 14, 15 },
            { -1, -2, -3, -4, -5 },
            { 6, 7, 8, 9, 0 }};
        PrintMatrix(matrix5x5);
        System.Console.WriteLine();
        int[] arr = new int[7]{10, -4, 2, -3, 4, 5, -1};
        program.SwapColumnDiagonal(matrix5x5, 1);
        PrintMatrix(matrix5x5);
    }

    public static void PrintMatrix(int[,] matrix){
        int AHeight = matrix.GetLength(0), AWeight = matrix.GetLength(1);

        for (int i = 0; i < AHeight; i++){
            for (int j = 0; j < AWeight; j++){
                System.Console.Write($"{matrix[i, j], 6}");
            }
            System.Console.WriteLine();
        }
    }
    
    public static void PrintMatrixDouble(double[,] matrix){
        int AHeight = matrix.GetLength(0), AWeight = matrix.GetLength(1);

        for (int i = 0; i < AHeight; i++){
            for (int j = 0; j < AWeight; j++){
                System.Console.Write(matrix[i, j] + " ");
            }
            System.Console.WriteLine();
        }
    }

    #region Level 1
    
    public int Factorial(int n){
        int ans = 1;
        for (int i=1; i <= n; i++){
            ans*=i;
        }
        return ans;
    }

    public long Combinations(int n, int k){
        return Factorial(n)/(Factorial(k)*Factorial(n-k));
    }

    public long Task_1_1(int n, int k)
    {
        long answer = 0;

        // code here
        if (k == 0 || k > 0 && k == n) {
            return 1;
        }
        answer = Combinations(n, k);

        // create and use Combinations(n, k);
        // create and use Factorial(n);

        // end

        return answer;
    }
// 1,5, 1, 2,5 | 1,25, 1, 1 | 2
    public double GeronArea(double a, double b, double c){
        if (a <= 0 || b <= 0 || c <= 0){
            return -1;
        }
        double p = (a+b+c)/2;
        double s = Math.Sqrt(p*(p-a)*(p-b)*(p-c));
        if (s <= 0){
            return -1;
        }
        return s;
    }

    public int Task_1_2(double[] first, double[] second)
    {
        //int answer = 0;
        if (first.Length != second.Length || first.Length != 3){
            return -1;
        }
        double fisrtTriangle = GeronArea(first[0], first[1], first[2]);
        double secondTriangle = GeronArea(second[0], second[1], second[2]);
        // code here

        if (fisrtTriangle < 0 || secondTriangle < 0){
            return -1;
        }

        // create and use GeronArea(a, b, c);
        if (fisrtTriangle > secondTriangle){
            return 1;
        }
        else if (fisrtTriangle < secondTriangle){
            return 2;
        }
        else if (fisrtTriangle == secondTriangle){
            return 0;
        }
        else{
            return -1;
        }
        // end

        // first = 1, second = 2, equal = 0, error = -1
        //return answer;
    }

    public double GetDistance(double v, double a, double t){
        double s = v*t + (a*t*t)/2;
        if (s <= 0){
            return -1;
        }
        return s;
    }

    public int Task_1_3a(double v1, double a1, double v2, double a2, int time)
    {
        int answer = 0;

        // code here
        double firstRider = GetDistance(v1, a1, time);
        double secondRider = GetDistance(v2, a2, time);
        if (firstRider > secondRider){
            return 1;
        }
        else if (firstRider < secondRider){
            return 2;
        }
        else {
            return 0;
        }
        // create and use GetDistance(v, a, t); t - hours

        // end

        // first = 1, second = 2, equal = 0
    }

    public int Task_1_3b(double v1, double a1, double v2, double a2)
    {
        int time = 1;

        // code here
        while (GetDistance(v1, a1, time) > GetDistance(v2, a2, time)){
            time++;
        }
        // use GetDistance(v, a, t); t - hours

        // end

        return time;
    }
    #endregion

    #region Level 2
    public void Task_2_1(int[,] A, int[,] B)
    {
        // code here
        
        // create and use FindMaxIndex(matrix, out row, out column);

        // end
    }

    public int FindMaxIndex(double[] array){
        double maxVal = double.MinValue;
        int maxIndex = -1;
        for (int i = 0; i < array.Length; i++){
            if (array[i] > maxVal){
                maxVal = array[i];
                maxIndex = i;
            }
        }
        return maxIndex;
    }

    public void Task_2_2(double[] A, double[] B)
    {
        // code here
        if (A.Length != 7 || B.Length != 9){
            return ;
        }

        int aIndex = FindMaxIndex(A);
        int bIndex = FindMaxIndex(B);
        int aLen = A.Length - aIndex;
        int bLen = B.Length - bIndex;
        double sum = 0;
        int count = 0;
        if (aLen > bLen){
            for (int i = aIndex+1; i < A.Length; i++){
                sum += A[i];
                count++;
            }
            double med = sum/count;
            A[aIndex] = med;
        }
        else if (aLen < bLen){
            for (int i = bIndex+1; i < B.Length; i++){
                sum += B[i];
                count++;
            }
            double med = sum/count;
            B[bIndex] = med;
        }
        // create and use FindMaxIndex(array);
        // only 1 array has to be changed!

        // end
    }

    public int FindDiagonalMaxIndex(int[,] matrix){
        int maxVal = int.MinValue;
        int maxIndex = -1;
        int row = matrix.GetLength(0);
        int col = matrix.GetLength(1);
        if (row != col || row ==0){
            return -1;
        }
        for (int i = 0; i < row; i++){
            if (matrix[i, i] > maxVal){
                maxVal = matrix[i, i];
                maxIndex = i;
            }
        }
        return maxIndex;
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

        PrintMatrix(A);
        System.Console.WriteLine();
        PrintMatrix(B);
        System.Console.WriteLine();
        int rowA = A.GetLength(0);
        int colA = A.GetLength(1);
        int rowB = B.GetLength(0);
        int colB = B.GetLength(1);
        if (rowB != rowA || rowA != colA || colA != colB || colB != 5){
            return;
        }

        int bIndex = FindDiagonalMaxIndex(B);
        int cIndex = FindDiagonalMaxIndex(A);
        for (int i = 0; i < rowB; i++){
            int tmp = A[bIndex, i];
            A[bIndex, i] = B[i, cIndex];
            B[i, cIndex] = tmp;
        }
        //  create and use method FindDiagonalMaxIndex(matrix); like in Task_2_3
        PrintMatrix(A);
        System.Console.WriteLine();
        PrintMatrix(B);
        // end
    }

    public void Task_2_5(int[,] A, int[,] B)
    {
        // code here

        // create and use FindMaxInColumn(matrix, columnIndex, out rowIndex);

        // end
    }

    void FindMax(int[] array, out int row){
        row = 0;
        for (int i = 0; i < array.Length; i++){
            if (array[i] > array[row]){
                row = i;
            }
        }
    }

    public int[] DeleteElement(int[] array, int index){
        int[] newArr = new int[array.Length-1];
        for (int i = 0; i < array.Length; i++){
            if (i < index){
                newArr[i] = array[i];
            }
            else if (i > index){
                newArr[i-1] = array[i];
            }
            else{
                continue;
            }
        }
        return newArr;
    }

    public int[] ConnectArrays(int[] arrayA, int[] arrayB){
        int[] connectArr = new int[arrayA.Length + arrayB.Length];
        for (int i = 0; i < arrayA.Length; i++){
            connectArr[i] = arrayA[i];
        }
        for (int i = 0; i < arrayB.Length; i++){
            connectArr[i+arrayA.Length] = arrayB[i];
        }
        return connectArr;
    }

    public void Task_2_6(ref int[] A, int[] B)
    {
        if (A.Length != 7 || B.Length != 8){
            return;
        }
        // code here
        FindMax(A, out int rowA);
        A = DeleteElement(A, rowA);

        FindMax(B, out int rowB);
        B = DeleteElement(B, rowB);
        // create and use FindMax(matrix, out row, out column); like in Task_2_1
        // create and use DeleteElement(array, index);
        A = ConnectArrays(A, B);
        // end
    }

    public void Task_2_7(ref int[,] B, int[,] C)
    {
        // code here

        // create and use CountRowPositive(matrix, rowIndex);
        // create and use CountColumnPositive(matrix, colIndex);

        // end
    }

    void SortArrayPart(int[] array, int startIndex){
        for (int i = startIndex+1; i < array.Length; i++){
            int k = i; int j = i-1;
            while (j >= startIndex+1){
                if (array[j] > array[k]){
                    int tmp = array[j];
                    array[j] = array[k];
                    array[k] = tmp;
                    k = j;
                }
                j--;
            }
        }
    }
    public void Task_2_8(int[] A, int[] B)
    {
        // code here
        if (A.Length!=9 || B.Length!=11){
            return;
        }
        int maxIndex = 0;
        for (int i = 0; i < A.Length; i++){
            if (A[i] > A[maxIndex]){
                maxIndex = i;
            }
        }
        SortArrayPart(A, maxIndex);

        maxIndex = 0;
        for (int i = 0; i < B.Length; i++){
            if (B[i] > B[maxIndex]){
                maxIndex = i;
            }
        }
        SortArrayPart(B, maxIndex);
        // create and use SortArrayPart(array, startIndex);

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


    public int[,] RemoveColumn(int[,] matrix, int columnIndex){
        int[,] newMatrix = new int[matrix.GetLength(0), matrix.GetLength(1)-1];
        for (int i = 0; i < matrix.GetLength(0); i++){
            for (int j = 0; j < matrix.GetLength(1); j++){
                if (j < columnIndex){
                    newMatrix[i, j] = matrix[i, j];
                }
                else if(j > columnIndex){
                    newMatrix[i, j-1] = matrix[i, j];
                }
                else{
                    continue;
                }
            }
        }
        return newMatrix;
    }
    public void Task_2_10(ref int[,] matrix)
    {
        // code here
        if (matrix.GetLength(0) != matrix.GetLength(1) || matrix.GetLength(0) < 1){
            return;
        }
        int maxI = 0; int maxJ = 0;
        for (int i = 0; i < matrix.GetLength(0); i++){
            for (int j = 0; j <= i; j++){
                if (matrix[i, j] > matrix[maxI, maxJ]){
                    maxI = i;
                    maxJ = j;
                }
            }
        }
        int maxI2 = 0; int maxJ2 = 0;
        for (int i = 0; i < matrix.GetLength(0); i++){
            for (int j = i+1; j < matrix.GetLength(1); j++){
                if (matrix[i, j] > matrix[maxI2, maxJ2]){
                    maxI2 = i;
                    maxJ2 = j;
                }
            }
        }   
        if (maxJ == maxJ2){
            matrix = RemoveColumn(matrix, maxJ);
        }
        
        else if (maxJ > maxJ2){
            matrix = RemoveColumn(matrix, maxJ);
            matrix = RemoveColumn(matrix, maxJ2);
        }

        else{
            matrix = RemoveColumn(matrix, maxJ2);
            matrix = RemoveColumn(matrix, maxJ);
        }

        
        // create and use RemoveColumn(matrix, columnIndex);

        // end
    }

    public void Task_2_11(int[,] A, int[,] B)
    {
        // code here

        // use FindMaxIndex(matrix, out row, out column); from Task_2_1

        // end
    }
 
    public int FindMaxColumnIndex(int[,] matrix){
        int maxI = 0; int maxJ = 0;
        for (int i = 0; i < matrix.GetLength(0); i++){
            for (int j = 0; j < matrix.GetLength(1); j++){
                if (matrix[i, j] > matrix[maxI, maxJ]){
                    maxI = i;
                    maxJ = j;
                }
            }
        }
        return maxJ;
    }
    public void Task_2_12(int[,] A, int[,] B)
    {
        if (A.GetLength(0) != B.GetLength(1) || A.GetLength(1) != B.GetLength(1)
         || A.GetLength(0) < 1 || A.GetLength(1) < 1){
            return;
        }
        // code here
        int jA = FindMaxColumnIndex(A);
        int jB = FindMaxColumnIndex(B);

        int[] arrA = new int[A.GetLength(0)];
        for (int i = 0; i < A.GetLength(0); i++){
            arrA[i] = A[i, jA];
        }
        for (int i = 0; i < A.GetLength(0); i++){
            for (int j = 0; j < A.GetLength(1); j++){   
                if (j == jA){
                    A[i, j] = B[i, jB];
                    continue;
                }
                if (j == jB){
                    B[i, j] = arrA[i];
                }
            }
        }
        // create and use FindMaxColumnIndex(matrix);

        // end
    }

    public void Task_2_13(ref int[,] matrix)
    {
        // code here

        // create and use RemoveRow(matrix, rowIndex);

        // end
    }
    void SortRow(int[,] matrix, int rowIndex){
        for (int i = 0; i < matrix.GetLength(1); i++){
            int k = i; int j = k-1;
            while (j>=0){
                if (matrix[rowIndex, j] > matrix[rowIndex, k]){
                    int tmp = matrix[rowIndex, j];
                    matrix[rowIndex, j] = matrix[rowIndex, k];
                    matrix[rowIndex, k] = tmp;
                    k = j;
                }
                j--;
            }
        }
    }
    public void Task_2_14(int[,] matrix)
    {
        // code here
        for (int i = 0; i < matrix.GetLength(0); i++){
            SortRow(matrix, i);
        }
        // create and use SortRow(matrix, rowIndex);

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

    void SortNegative(int[] array){
        int count=0;
        for (int i = 0; i < array.Length; i++){
            if (array[i] < 0){
                count++;
            }
        }
        int[] arrIndex = new int[count];
        int ind = 0;
        for (int i = 0; i < array.Length; i++){
            if (array[i] < 0){
                arrIndex[ind] = i;
                ind++;
            }
        }

        for (int i = 0; i < arrIndex.Length; i++){
            int k = i; int j = k-1;
            while (j>=0){
                if (array[arrIndex[j]] < array[arrIndex[k]]){
                    int tmp = array[arrIndex[j]];
                    array[arrIndex[j]] = array[arrIndex[k]];
                    array[arrIndex[k]] = tmp;

                    // tmp = arrIndex[j];
                    // arrIndex[j] = arrIndex[k];
                    // arrIndex[k] = tmp;
                    k = j;
                }
                j--;
            }
        }
    }

    public void Task_2_16(int[] A, int[] B)
    {
        // code here
        SortNegative(A);
        SortNegative(B);
        // create and use SortNegative(array);

        // end
    }

    public void Task_2_17(int[,] A, int[,] B)
    {
        // code here

        // create and use SortRowsByMaxElement(matrix);

        // end
    }
    void SortDiagonal(int[,] matrix){
        for (int i = 0; i < matrix.GetLength(0); i++){
            int k = i; int j = k-1;
            while (j>=0){
                if (matrix[j, j] > matrix[k, k]){
                    int tmp = matrix[j, j];
                    matrix[j, j] = matrix[k, k];
                    matrix[k, k] = tmp;
                    k = j;
                }
                j--;
            }
        }
    }
    public void Task_2_18(int[,] A, int[,] B)
    {
        // code here
        
        SortDiagonal(A);
        SortDiagonal(B);
        // create and use SortDiagonal(matrix);

        // end
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
        for (int j = 0; j < A.GetLength(1); j++){
            bool flag = false;
            for (int i = 0; i < A.GetLength(0); i++){
                if (A[i, j] == 0){
                    flag = true;
                    break;
                }
            }
            if (!flag){
                A = RemoveColumn(A, j);
                j--;
            }
        }

        for (int j = 0; j < B.GetLength(1); j++){
            bool flag = false;
            for (int i = 0; i < B.GetLength(0); i++){
                if (B[i, j] == 0){
                    flag = true;
                    break;
                }
            }
            if (!flag){
                B = RemoveColumn(B, j);
                j--;
            }
        }
        // use RemoveColumn(matrix, columnIndex); from 2_10

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

    public int CountNegativeInRow(int[,] matrix, int rowIndex){
        int count=0;
        for (int j = 0; j < matrix.GetLength(1); j++){
            if (matrix[rowIndex, j] < 0){
                count++;
            }
        }
        return count;
    }
    public int FindMaxNegativePerColumn(int[,] matrix, int columnIndex){
        int maxNeg = int.MinValue; //in answer matrix has neg in all the columns
        for (int i = 0; i < matrix.GetLength(0); i++){
            if (matrix[i, columnIndex] > maxNeg && matrix[i, columnIndex] < 0){
                maxNeg = matrix[i, columnIndex];
            }
        }
        return maxNeg;
    }

    public void Task_2_22(int[,] matrix, out int[] rows, out int[] cols)
    {
        rows = new int[matrix.GetLength(0)];
        cols = new int[matrix.GetLength(1)];

        // code here
        for (int i = 0; i < matrix.GetLength(0); i++){
            rows[i] = CountNegativeInRow(matrix, i);
        }
        for (int j = 0; j < matrix.GetLength(1); j++){
            cols[j] = FindMaxNegativePerColumn(matrix, j);
        }
        // create and use CountNegativeInRow(matrix, rowIndex);
        // create and use FindMaxNegativePerColumn(matrix, columnIndex);

        // end
    }

    public void Task_2_23(double[,] A, double[,] B)
    {
        // code here

        // create and use MatrixValuesChange(matrix);

        // end
    }

    public void FindMaxIndex(int[,] matrix, out int row, out int column){
        int maxI = 0; int maxJ = 0;
        for (int i = 0; i < matrix.GetLength(0); i++){
            for (int j = 0; j < matrix.GetLength(1); j++){
                if (matrix[i, j] > matrix[maxI, maxJ]){
                    maxI=i;
                    maxJ=j;
                }
            }
        }
        row = maxI; column = maxJ;
    }

    void SwapColumnDiagonal(int[,] matrix, int columnIndex){
        int[] arr = new int[matrix.GetLength(0)];
        int[] arr2 = new int[matrix.GetLength(1)];
        for (int i = 0; i < matrix.GetLength(0); i++){
            arr[i] = matrix[i, i];
            arr2[i] = matrix[i, columnIndex];
        }
        for (int i = 0; i < matrix.GetLength(0); i++){
            for (int j = 0; j < matrix.GetLength(1); j++){
                if (i==j){
                    matrix[i, i] = arr2[i];
                }
                if (j == columnIndex){
                    matrix[i, j] = arr[i];
                }
            }
        }
    }

    public void Task_2_24(int[,] A, int[,] B)
    {
        // code here
        FindMaxIndex(A, out int _, out int maxJ);
        SwapColumnDiagonal(A, maxJ);

        FindMaxIndex(B, out int _, out int maxJ2);
        SwapColumnDiagonal(B, maxJ2);
        // use FindMaxIndex(matrix, out row, out column); like in 2_1
        // create and use SwapColumnDiagonal(matrix, columnIndex);

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

    public int FindRowWithMaxNegativeCount(int[,] matrix){
        int maxCount = 0;int count; int row = 0;
        for (int i = 0; i < matrix.GetLength(0); i++){
            
            count = CountNegativeInRow(matrix, i);
            if (count > maxCount){
                maxCount=count;
                row = i;
            }
        }
        return row;
    }

    public void Task_2_26(int[,] A, int[,] B)
    {
        // code here
        int row1 = FindRowWithMaxNegativeCount(A);
        int row2 = FindRowWithMaxNegativeCount(B);
        int[] arr1 = new int[A.GetLength(1)];
        int[] arr2 = new int[B.GetLength(1)];
        for (int j = 0; j < A.GetLength(1); j++){
            arr1[j] = A[row1, j];
            arr2[j] = B[row2, j];
        }
        
        for (int j = 0; j < A.GetLength(1); j++){
            A[row1, j] = arr2[j];
            B[row2, j] = arr1[j];
        }
        
        // create and use FindRowWithMaxNegativeCount(matrix); like in 2_25
        // in FindRowWithMaxNegativeCount use CountNegativeInRow(matrix, rowIndex); from 2_22

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

    public int FindSequence(int[] array, int A, int B){
        bool flag = true;
        for (int i = A; i < (B-1); i++){
            if (array[i] < array[i+1]){
                flag = false;
                break;
            }
        }
        if (flag == true){
            return -1;
        }
        flag = true;
        for (int i = A; i < (B-1); i++){
            if (array[i] > array[i+1]){
                flag = false;
                break;
            }
        }
        if (flag == true){
            return 1;
        }
        else{
            return 0;
        }
    }

    public void Task_2_28a(int[] first, int[] second, ref int answerFirst, ref int answerSecond)
    {
        // code here
        answerFirst = FindSequence(first, 0, first.Length-1);
        answerSecond = FindSequence(second, 0, second.Length);
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

        // create and use public delegate SumFunction(x) and public delegate YFunction(x)
        // create and use method GetSumAndY(sFunction, yFunction, a, b, h);
        // create and use 2 methods for both functions calculating at specific x

        // end
    }
    public delegate void SortRowStyle(int[,] matrix, int rowIndex);
 
    public void SortAscending(int[,] matrix, int rowIndex){
        for(int i = 0; i< matrix.GetLength(1); i++){
            int k = i; int j = k-1;
            while(j>=0){
                if (matrix[rowIndex, j] > matrix[rowIndex, k]){
                    int tmp = matrix[rowIndex, j];
                    matrix[rowIndex, j] = matrix[rowIndex, k];
                    matrix[rowIndex, k] = tmp;
                    k = j;
                }
                j--;
            }
        }
    }
 
    public void SortDescending(int[,] matrix, int rowIndex){
        for(int i = 0; i< matrix.GetLength(1); i++){
            int k = i; int j = k-1;
            while(j>=0){
                if (matrix[rowIndex, j] < matrix[rowIndex, k]){
                    int tmp = matrix[rowIndex, j];
                    matrix[rowIndex, j] = matrix[rowIndex, k];
                    matrix[rowIndex, k] = tmp;
                    k = j;
                }
                j--;
            }
        }
    }
    public void Task_3_2(int[,] matrix)
    {
        // SortRowStyle sortStyle = default(SortRowStyle); - uncomment me
        SortRowStyle sortStyle = default(SortRowStyle);
        // code here
        for (int i = 0; i < matrix.GetLength(0); i++){
            if (i%2==0){
                sortStyle = SortAscending;
            }
            else{
                sortStyle = SortDescending;
            }
            sortStyle(matrix, i);
        }
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

        // end

        return answer;
    }
    public delegate int[] GetTriangle(int[,] matrix);
    public int[] GelLowerTriange(int[,] matrix){
        int row = matrix.GetLength(0);
        int[] lowerTriangle = new int[row * (row + 1) / 2];
        int index = 0;
        for (int i = 0; i < row; i++){
            for (int j = 0; j<= i; j++){
                lowerTriangle[index] = matrix[i, j];
                index++;
            }
        }
        return lowerTriangle;
    }

    public int[] GetUpperTriange(int[,] matrix){
        int row = matrix.GetLength(0);
        int[] upperTriangle = new int[row * (row + 1) / 2];
        int index = 0;
        for (int i = 0; i < row; i++){
            for (int j = i; j< matrix.GetLength(1); j++){
                upperTriangle[index] = matrix[i, j];
                index++;
            }
        }
        return upperTriangle;
    }

    public int GetSum(GetTriangle getTriangle, int[,] matrix){
        int[] triangleElements = getTriangle(matrix);
        int sum = 0;
        foreach (int member in triangleElements){
            sum += member*member;
        }
        return sum;
    }

    public int Task_3_4(int[,] matrix, bool isUpperTriangle)
    {
        int answer = 0;

        // code here
        GetTriangle getTriangle;
        if (isUpperTriangle){
            getTriangle = GetUpperTriange;
        }
        else{
            getTriangle = GelLowerTriange;
        }

        answer = GetSum(getTriangle, matrix);
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

        // end
    }
    public delegate int FindElementDelegate(int[,] matrix);

    // public int FindDiagonalMaxIndex(int[,] matrix){
    //     int maxIndex = 0;
    //     for (int i = 0; i < matrix.GetLength(0); i++){
    //         if (matrix[i, i] > matrix[maxIndex, maxIndex]){
    //             maxIndex = i;
    //         }
    //     }
    //     return maxIndex;
    // }

    public int FindFirstRowMaxIndex(int [,] matrix){
        int maxJ = 0;
        for (int j = 0; j < matrix.GetLength(1); j++){
            if (matrix[0, j] > matrix[0, maxJ]){
                maxJ = j;
            }
        }
        return maxJ;
    }

    public void SwapColumns(int[,] matrix, int col1, int col2){
        for (int i = 0; i < matrix.GetLength(0); i++){
            int tmp = matrix[i, col1];
            matrix[i, col1] = matrix[i, col2];
            matrix[i, col2] = tmp;
        }

    }

    public void Task_3_6(int[,] matrix)
    {
        // code here

        FindElementDelegate diagonalSearch = FindDiagonalMaxIndex;
        FindElementDelegate columnSearch = FindFirstRowMaxIndex;

        int diagonalIndex = diagonalSearch(matrix);
        int columnIndex = columnSearch(matrix);
        SwapColumns(matrix, diagonalIndex, columnIndex);

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

        // end
    }
    public delegate int FindIndex(int[,] matrix);

    public int FindMaxBelowDiagonalIndex(int[,] matrix){
        int maxI = 0;
        int maxJ = 0;
        int maxVal = int.MinValue;
        for (int i = 0; i < matrix.GetLength(0); i++){
            for (int j = 0; j <= i; j++){
                if (matrix[i, j] >maxVal){
                    maxI = i; 
                    maxJ = j;
                    maxVal = matrix[i, j];
                }
            }
        }
        return maxJ;
    }

    public int FindMinAboveDiagonalIndex(int[,] matrix){
        int minI = 0;
        int minJ = 0;
        int minVal = int.MaxValue;
        for (int i = 0; i < matrix.GetLength(0); i++){
            for (int j = i+1; j < matrix.GetLength(1); j++){
                if (matrix[i, j] < minVal){
                    minI = i;
                    minJ = j;
                    minVal = matrix[i, j];
                }
            }
        }
        return minJ;
    }

    public void RemoveColumns(ref int[,] matrix, int maxBelowIndex, int minAboveIndex)
    {   
        if (maxBelowIndex == minAboveIndex){
            matrix = RemoveColumn(matrix, Math.Max(maxBelowIndex, minAboveIndex));
        }
        else{
            matrix = RemoveColumn(matrix, Math.Max(maxBelowIndex, minAboveIndex));
            matrix = RemoveColumn(matrix, Math.Min(maxBelowIndex, minAboveIndex));
        }
    }



    public void Task_3_10(ref int[,] matrix)
    {
        FindIndex searchArea = default(FindIndex); 
        
        // code here

        searchArea = FindMaxBelowDiagonalIndex;
        int maxBelowIndex = searchArea(matrix);

        searchArea = FindMinAboveDiagonalIndex;
        int minAboveIndex = searchArea(matrix);

        RemoveColumns(ref matrix, maxBelowIndex, minAboveIndex);
        
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
    
    public delegate int GetNegativeArray(int[,] matrix, int rowIndex);
    public void FindNegatives(int[,] matrix, out int[] rows, out int[] cols){
        rows = new int[matrix.GetLength(0)];
        cols = new int[matrix.GetLength(1)];
        GetNegativeArray searcher = CountNegativeInRow;
        for (int i = 0; i < matrix.GetLength(0); i++){
            rows[i] = searcher(matrix, i);
        }
        searcher = FindMaxNegativePerColumn;
        for (int j = 0; j < matrix.GetLength(1); j++){
            cols[j] = searcher(matrix, j);
        }
    }

    public void Task_3_22(int[,] matrix, out int[] rows, out int[] cols)
    {

        rows = new int[matrix.GetLength(0)];
        cols = new int[matrix.GetLength(1)];

        FindNegatives(matrix, out rows, out cols); 
        // code here
        //
        // create and use public delegate GetNegativeArray(matrix);
        // use GetNegativeCountPerRow(matrix) from Task_2_22 (CountNegativeInRow)   
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

    public delegate int IsSequence(int[] array, int left, int right);

    public int FindIncreasingSequence(int[] array, int A, int B){
        bool flag = true;
        for (int i = A; i < (B-1); i++){
            if (array[i] > array[i+1]){
                flag = false;
                return 0;
            }
        }
        return 1;
    }

    public int FindDecreasingSequence(int[] array, int A, int B){
        bool flag = true;
        for (int i = A; i < (B-1); i++){
            if (array[i] < array[i+1]){
                flag = false;
                return 0;
            }
        }
        return 1;
    }

    public int DefineSequence(int [] array, int A, int B){
        IsSequence check = FindIncreasingSequence;
        if (check(array, A, B) == 1){
            return 1;
        }
        check = FindDecreasingSequence;
        if (check(array, A, B) == 1){
            return -1;
        }
        else{
            return 0;
        }
    }

    public void Task_3_28a(int[] first, int[] second, ref int answerFirst, ref int answerSecond)
    {
        // code here
        answerFirst = DefineSequence(first, 0, first.Length-1);
        answerSecond = DefineSequence(second, 0, second.Length-1);
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
