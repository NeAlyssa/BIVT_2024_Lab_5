using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Numerics;
using System.Reflection;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class Program
{
    public int Factorial(int n){

        int answer = 1;
        for(int i = 1; i <= n; i++){
            answer *= i;
        }

        return answer;
    }

    public double GeronArea(double a, double b, double c){

        double p = (a+b+c)/2;
        double s = Math.Sqrt(p*(p-a)*(p-b)*(p-c));

        return s;
    }

    public bool istriangle(double a, double b, double c){
        bool f = false;
        if (a+b > c && b+c > a && a+c > b){
            f = true;
        }
        return f;
    }

    public double GetDistance(double v, double a, int t){
        return v*t+a*t*t/2;
    }

    public void FindMaxIndex(int[,] matrix, out int row, out int col){
        int mx = int.MinValue;
        row = col = 0;
        for(int i = 0;i < matrix.GetLength(0); i++){
            for(int j = 0;j < matrix.GetLength(1); j++){
                if (matrix[i,j] > mx){
                    mx = matrix[i,j];
                    row =  i;
                    col = j;
                }
            }
        }
    }

    public int FindDiagonalMaxIndex(int[,] matrix){
        int ind = 0;
        int mx = int.MinValue;
        for(int i = 0;i < matrix.GetLength(0); i++){
            if (mx < matrix[i,i]){
                mx = matrix[i,i];
                ind = i;
            }
        }
        return ind;
    }

    public void delrow(ref int[,] A, int row){
        int n = A.GetLength(0), m = A.GetLength(1);
        int[,] B = new int[n-1,m];
        for (int i = 0; i < n-1; i++){
           if (i < row){
            for (int j = 0; j < m; j++){
                B[i, j] = A[i, j];
            }
           }
            else{
                for (int j = 0; j < m; j++){
                    B[i, j] = A[i+1, j];
                }
            }
        }
        A = B;
    }

    public void FindMaxInColumn(int [,] matrix, int columnIndex,  out int rowIndex){
        rowIndex = 0;
        int mx = int.MinValue;
        for(int i = 0;i < matrix.GetLength(0);i++){
            if (matrix[i,columnIndex] > mx){
                mx = matrix[i,columnIndex];
                rowIndex = i;
            }
        }
    }

    public int CountRowPositive(int [,] matrix, int rowIndex){
        int cnt = 0;

            for(int j = 0; j < matrix.GetLength(1);j++){
                cnt += matrix[rowIndex,j] > 0 ? 1 : 0;
            }
            
        return cnt;
    }

      public int CountColumnPositive(int [,] matrix,  int colIndex){
        int cnt = 0;
            for(int i = 0; i < matrix.GetLength(0);i++){
                cnt += matrix[i,colIndex] > 0 ? 1 : 0;
            }
        
        return cnt;
    }

    public int[] SumPositiveElementsInColumns(int [,] matrix){
        int[] a = new int[matrix.GetLength(1)];
        for(int j = 0;j < matrix.GetLength(1);j++){
            int s = 0;
            for (int i = 0; i < matrix.GetLength(0);i++){
                s += matrix[i,j] > 0 ? matrix[i,j] : 0;   
            }
            a[j] = s;
        }
        return a;

    }

    public void PrintMatrix(int [,] A){
        for(int i = 0;i < A.GetLength(0);i++){
            for(int j = 0;j < A.GetLength(1) ;j++){
                Console.Write(A[i,j]);
                Console.Write(" ");
            }
            Console.WriteLine();
        }
    }
    public void FindMinIndex(int[,] matrix, out int row, out int col){
        int mn = int.MaxValue;
        row = col = 0;
        for(int i = 0;i < matrix.GetLength(0); i++){
            for(int j = 0;j < matrix.GetLength(1); j++){
                if (matrix[i,j] < mn){
                    mn = matrix[i,j];
                    row =  i;
                    col = j;
                }
            }
        }
    }

    public void RemoveRow(ref int[,] matrix, int row){
        int n = matrix.GetLength(0), m = matrix.GetLength(1);
        int[,] buf = new int[n-1,m];
        for(int i = 0;i < n-1;i++){
            if (i < row){
               for(int j = 0;j < m;j++){
                buf[i,j] = matrix[i,j];
                }
            }
            else{
                for(int j = 0;j < m;j++){
                    buf[i,j] = matrix[i+1,j];
                }
            }
        }
    matrix = buf;
    }

    public int GetAverageWithoutMinMax(int[,] matrix){
        int mn = int.MaxValue, mx = int.MinValue, s = 0;
        int n = matrix.GetLength(0), m = matrix.GetLength(1);
        for(int i = 0;i < n;i++){
            for(int j = 0;j < m;j++){
                s += matrix[i,j];
                if (mx > matrix[i,j]) mx = matrix[i,j];
                if (mn < matrix[i,j]) mn = matrix[i,j];
            }
        }
        return (s-mx-mn)/(n*m-2);
    }

    public int[] RowsMaxElement(int [,] matrix){
        int[] a = new int[matrix.GetLength(0)];
        for(int i = 0;i < matrix.GetLength(0);i++){
            int mx = int.MinValue;
            for (int j = 0; j < matrix.GetLength(1);j++){
                if (mx < matrix[i,j])  mx = matrix[i,j];
            }
            a[i] = mx;
        }
        return a;

    }

public void SortRowsByMaxElement(ref int [,] A,ref int[] a){
    int n = A.GetLength(0), m = A.GetLength(1);
        for(int i = 0;i < n-1;i++){
            for(int j = 0;j < n-i-1;j++){
                if (a[j] < a[j+1]){
                    int buf = a[j+1];
                    a[j+1] = a[j];
                    a[j] = buf;
                    for(int k = 0;k < m;k++){
                        int temp = A[j+1,k];
                        A[j+1,k] = A[j,k];
                        A[j,k] = temp;
                    }
                }
            }
        } 
    }

public int[] CreateArrayFromMins(int[,] A, int[] arr){
    int n = A.GetLength(0);
    arr = new int[n];
    for(int i = 0;i < n;i++){
        int mn = int.MaxValue;
        for(int j = i;j < n;j++){
            if (mn > A[i,j]) mn = A[i,j];
        }
        arr[i] = mn;
    }
    return arr;
}

public void Matrix_to_array(double [,] A, ref double[] arr){
        int n = A.GetLength(0), m = A.GetLength(1), k = 0;
        arr = new double[n*m];
        for(int i = 0;i < n;i++){
            for(int j = 0;j < m;j++){
                arr[k++] = A[i,j];
            }
        }
}

public void rock_sort(ref double[] a){
    int n = a.Length;
    for(int i = 0;i < n-1;i++){
        for(int j = 0;j < n-i-1;j++){
            if (a[j] < a[j+1]){
                double buf = a[j+1];
                a[j+1] = a[j];
                a[j] = buf;
            }
        }
    }
}

public void MatrixValuesChange(ref double[,] A, double [] mxA){
    int n = A.GetLength(0), m = A.GetLength(1);
        for(int i = 0;i < n;i++){
            for(int j = 0;j < m;j++){
                if (mxA[0] == A[i,j] || mxA[1] == A[i,j] || mxA[2] == A[i,j] || mxA[3] == A[i,j] || mxA[4] == A[i,j]){
                    A[i,j] *= A[i,j] > 0 ? 2 : 0.5;
                }
                else A[i,j] *= A[i,j] > 0 ? 0.5 : 2;
            }
        }
}

public int FindRowWithMaxNegativeCount(int[,] A){
    int mx = 0,temp, answer = 0;
    for(int i = 0; i < A.GetLength(0);i++){
        temp = CountNegativeInRow(A,i);
        if (mx < temp){
            mx = temp;
            answer = i;
        };
    }
    return answer;
}

public int CountNegativeInRow(int[,] A, int row){
    int answer = 0;
    for(int j = 0;j < A.GetLength(1);j++){
        answer += A[row,j] <  0 ? 1 : 0;
    }
    return answer;
}

    public void FindRowMaxIndex(int[,] matrix, int rowIndex, out int ind) {
        int m = matrix.GetLength(1);
        int mx = int.MinValue;
        ind = 0;
        for (int j = 0; j < m; j++) {
            if (matrix[rowIndex, j] > mx) {
                mx = matrix[rowIndex, j];
                ind= j;
            }
        }
    }

public void ReplaceMaxElementOdd(ref int[,] A, int row, int col){
    A[row,col] *= col + 1;
}

public void ReplaceMaxElementEven(ref int[,] A, int row, int col){
    A[row,col] = 0;
}

    public static void Main()
    {
        Program program = new Program();
        double[,] a = new double[,] {
            { 1, -2 },
            { 5, -5 }};
         double[,] b = new double[,] {
            { 1, -2, 3 },
            { 5, -5, 5 },
            { 6, 7, 8 }}; 
        program.Task_2_23(a,b);
    }
    #region Level 1
    public long Task_1_1(int n, int k)
    {
        long answer = 0;

        answer = Factorial(n)/(Factorial(k)*Factorial(n-k));

        return answer;
    }

    public int Task_1_2(double[] first, double[] second)
    {
        int answer = 1;
        double s1 = 0,s2 = 0;
        
        s1 = GeronArea(first[0], first[1], first[2]);
        s2 = GeronArea(second[0], second[1], second[2]);

        if (!istriangle(first[0], first[1], first[2]) || !istriangle(second[0], second[1], second[2])){
            answer = -1;
        }
        else if (s2 > s1){
            answer = 2;
        }
        else if (s2 == s1){
            answer = 0;
        }

        // first = 1, second = 2, equal = 0, error = -1
        return answer;
    }

    public int Task_1_3a(double v1, double a1, double v2, double a2, int time)
    {
        int answer = 1;
        double s1 = GetDistance(v1,a1,time), s2 = GetDistance(v2,a2,time);

        if (s2 > s1){
            answer = 2;
        }
        else if (s2 == s1){
            answer = 0;
        }

        // first = 1, second = 2, equal = 0
        return answer;
    }

    public int Task_1_3b(double v1, double a1, double v2, double a2)
    {
        int time = 1;

        while (GetDistance(v1,a1,time) > GetDistance(v2,a2,time)){
            time++;
        }

        return time;
    }
    #endregion

    #region Level 2
    public void Task_2_1(int[,] A, int[,] B)
    {
        int rowA,rowB,colA,colB ;
        
        FindMaxIndex(A, out rowA, out colA);
        FindMaxIndex(B, out rowB, out colB);

        int buf = A[rowA,colA];
        A[rowA,colA] = B[rowB,colB];
        B[rowB,colB] = buf;
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
        int indMB = 0, indMC = 0;
        
        indMB = FindDiagonalMaxIndex(B);
        indMC = FindDiagonalMaxIndex(C);

        delrow(ref B,indMB);
        delrow(ref C,indMC);
    }

    public void Task_2_4(int[,] A, int[,] B)
    {
        // code here

        //  create and use method FindDiagonalMaxIndex(matrix); like in Task_2_3

        // end
    }

    public void Task_2_5(int[,] A, int[,] B)
    {
        int rowIndexA = 0,rowIndexB = 0;

        FindMaxInColumn(A, 0, out rowIndexA);
        FindMaxInColumn(B, 0, out rowIndexB);

        for(int i = 0;i < A.GetLength(1);i++){
            int buf = A[rowIndexA,i];
            A[rowIndexA,i] = B[rowIndexB,i];
            B[rowIndexB,i] = buf;
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
        int rowIndex = 0, colIndex = 0,rowMx = 0,colMx = 0;
        int mx = 0,cnt;
        for(int i = 0;i < B.GetLength(0);i++){
           cnt = CountRowPositive(B, rowIndex);
           if (cnt > mx){
            mx = cnt;
            rowMx = rowIndex;
           }
           rowIndex++;
        }
        mx = 0;
        for(int i = 0;i < C.GetLength(1);i++){
           cnt = CountColumnPositive(C, colIndex);
           if (cnt > mx){
            mx = cnt;
            colMx = colIndex;
           }
           colIndex++;
        }         

        int n = B.GetLength(0), m = B.GetLength(1);
        int[,] D = new int[n+1,m];
        for (int i = 0; i < n+1; i++){
           if (i <= rowMx){
            for (int j = 0; j < m; j++){
                D[i, j] = B[i, j];
            }
           }
           else if (i == rowMx + 1){
            for (int j = 0; j < m; j++){
                D[i,j] = C[j,colMx];
            }
           }
            else{
                for (int j = 0; j < m; j++){
                    D[i, j] = B[i-1, j];
                }
            }
        }
        B = D;
        PrintMatrix(B);
        Console.Write(rowMx);
    }

    public void Task_2_8(int[] A, int[] B)
    {
        // code here

        // create and use SortArrayPart(array, startIndex);

        // end
    }

    public int[] Task_2_9(int[,] A, int[,] C)
    {
        int[] answer = new int[A.GetLength(1) + C.GetLength(1)], buf = default(int[]), buf1 = default(int[]);

        buf = SumPositiveElementsInColumns(A);
        buf1 = SumPositiveElementsInColumns(C);
        
        for(int i = 0;i < answer.Length;i++){
            if (i <  buf.Length){
                answer[i] += buf[i];
            }
            else{
                answer[i] += buf1[i-buf.Length];
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
        int rowA = 0, rowB = 0, colA = 0, colB = 0;

        FindMaxIndex(A, out rowA, out colA);
        FindMaxIndex(B, out rowB, out colB);

        int buf = A[rowA,colA];
        A[rowA,colA] = B[rowB,colB];
        B[rowB,colB] = buf;

    }
    public void Task_2_12(int[,] A, int[,] B)
    {
        // code here

        // create and use FindMaxColumnIndex(matrix);

        // end
    }

    public void Task_2_13(ref int[,] matrix)
    {
        int rowMx = 0, colMx = 0,rowMn = 0, colMn = 0;

        FindMaxIndex(matrix,out rowMx, out colMx);
        FindMinIndex(matrix,out rowMn, out colMn);

        RemoveRow(ref matrix, rowMx);
        if (rowMx != rowMn){
            rowMn -= rowMx < rowMn ? 1 : 0;
            RemoveRow(ref matrix, rowMn);
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
        int answer = 0;
        int[] average = new int [3];

        average[0] = GetAverageWithoutMinMax(A);
        average[1] = GetAverageWithoutMinMax(B);
        average[2] = GetAverageWithoutMinMax(C);

        if (average[0] > average[1] && average[1] > average[2]) answer = -1;
        else if (average[0] < average[1] && average[1] < average[2]) answer = 1;
        else answer = 0;

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
        int[] a = RowsMaxElement(A), b = RowsMaxElement(B);
        SortRowsByMaxElement(ref A, ref a);
        SortRowsByMaxElement(ref B, ref b);

    }

    public void Task_2_18(int[,] A, int[,] B)
    {
        // code here

        // create and use SortDiagonal(matrix);

        // end
    }

    public void Task_2_19(ref int[,] matrix)
    {
        int cnt = matrix.GetLength(0);
        int[] m0 = new int[cnt];
        bool f = true;
        for(int i = 0; i < matrix.GetLength(0);i++){
            f = true;
            for(int j = 0; j < matrix.GetLength(1);j++){
                if (matrix[i,j] == 0){
                    cnt--;
                    f = false;
                    break;
                }
            }
            if (f){
                m0[i] = 1;
            }
        }
        for (int i = 0; i < m0.Length;i++){
            if (m0[i] == 0){
                RemoveRow(ref matrix, i);
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
        answerA = null;
        answerB = null;

        answerA = CreateArrayFromMins(A,answerA);
        answerB = CreateArrayFromMins(B,answerB);
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
        double[] mxAt = null, mxBt = null;

        Matrix_to_array(A,ref mxAt);
        Matrix_to_array(B,ref mxBt);
        
        rock_sort(ref mxAt);
        rock_sort(ref mxBt);

        double[] mxA =  mxAt.Length >= 5 ? new double[5] : new double[mxAt.Length], mxB = mxBt.Length >= 5 ? new double[5] : new double[mxBt.Length];
        for(int i = 0; i < mxA.Length;i++){
                mxA[i] = mxAt[i];
        }
        for(int i = 0; i < mxB.Length;i++){
            mxB[i] = mxBt[i];
        }

        MatrixValuesChange(ref A, mxA);
        MatrixValuesChange(ref B, mxB);


        // end
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

    public void Task_2_27(int[,] A, int[,] B)
    {
        int colInd = 0;
        for(int i = 0; i < A.GetLength(0);i++){
            FindRowMaxIndex(A, i, out colInd);
            if ((i+1) % 2 > 0)
            ReplaceMaxElementOdd(ref A, i, colInd);
            else
            ReplaceMaxElementEven(ref A, i, colInd);
        }

        for(int i = 0; i < B.GetLength(0);i++){
            FindRowMaxIndex(B, i, out colInd);
            if ((i+1) % 2 > 0)
            ReplaceMaxElementOdd(ref B, i, colInd);
            else
            ReplaceMaxElementEven(ref B, i, colInd);
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

    public void Task_3_13(ref int[,] matrix)
    {
        // code here

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
