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

    public static void Main()
    {
        Program program = new Program();
    }
    #region Level 1
        public int Factorial(int n){

        int answer = 1;
        for(int i = 1; i <= n; i++){
            answer *= i;
        }

        return answer;
    }
    public long Task_1_1(int n, int k)
    {
        long answer = 0;

        answer = Factorial(n)/(Factorial(k)*Factorial(n-k));

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
    public double GetDistance(double v, double a, int t){
        return v*t+a*t*t/2;
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
    }

    public void Task_2_8(int[] A, int[] B)
    {
        // code here

        // create and use SortArrayPart(array, startIndex);

        // end
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
 
        public delegate double SumFunction(int i, double x, ref int ch);
        public delegate double YFunction(double x);
        public double s1(int i, double x, ref int iFactorial) {
            if (i > 0) 
                iFactorial *= i;

            return Math.Cos(i * x) / iFactorial;
        }
        public double s2(int i, double x, ref int sign) {
            sign *= -1;
            return sign * Math.Cos(i * x) / (i * i);
        }
        public double y1(double x) {return Math.Exp(Math.Cos(x)) * Math.Cos(Math.Sin(x));}
        public double y2(double x) {return ((x * x) - Math.PI * Math.PI / 3) / 4;}
        public double CalculateSum(SumFunction sumFunction, double x, int i) {
            double eps = 0.0001, s = 0;
            int ch = 1;
            double cur = sumFunction(i, x, ref ch);

            while (Math.Abs(cur) > eps) {
                s += cur;
                cur = sumFunction(++i, x, ref ch);
            }
            return s;
        }
        public void GetSumAndY(SumFunction sFunction, YFunction yFunction, double a, double b, double h, double[,] SumAndY, int startI = 0) {
            for (int i = 0; i < (b - a) / h + 1; i++) {
                double x = a + i * h;

                double sum = CalculateSum(sFunction, x, startI);
                double y = yFunction(x);

                SumAndY[i, 0] = sum;
                SumAndY[i, 1] = y;
            }
        }
       public void Task_3_1(ref double[,] firstSumAndY, ref double[,] secondSumAndY) {
    
            double a1 = 0.1, b1 = 1, h1 = 0.1;
            firstSumAndY = new double[(int) ((b1 - a1) / h1) + 1, 2];
            GetSumAndY(s1, y1, a1, b1, h1, firstSumAndY);
    
            double a2 = Math.PI / 5, b2 = Math.PI, h2 = Math.PI / 25;
            secondSumAndY = new double[(int) ((b2 - a2) / h2) + 1, 2];
            GetSumAndY(s2, y2, a2, b2, h2, secondSumAndY, 1);
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

    
    public delegate void SwapDirection(double[] arr);

    public void SwapRight(double[] arr) {
        for (int i = 0; i < arr.Length - 1; i += 2) {
            (arr[i], arr[i + 1]) = (arr[i + 1], arr[i]);
        }
    }

    public void SwapLeft(double[] arr) {
        for (int i = arr.Length - 1; i > 0; i -= 2) {
            (arr[i], arr[i - 1]) = (arr[i - 1], arr[i]);
        }
    }

    public double GetSum(double[] arr) {
        double s = 0;
        for (int i = 1; i < arr.Length; i += 2) {
            s += arr[i];
        }
        return s;
    }

    public double Task_3_3(double[] array)
    {
        double answer = 0, s = 0;
        SwapDirection swapper = default(SwapDirection);     

        foreach (double elem in array) s += elem;
        double average = s / array.Length;

        if (array[0] > average) swapper = SwapRight;
        else swapper = SwapLeft;
        swapper(array);
        answer = GetSum(array);

        return answer;
    }

    public int Task_3_4(int[,] matrix, bool isUpperTriangle)
    {
        int answer = 0;

        // code here

        // create and use public delegate GetTriangle(matrix);
        // create and use methods GetUpperTriange(array) and GetLowerTriange(array)
        // and GetSum(GetTriangle, matrix)
        // create and use method GetSum(array) similar to GetSum in Task_3_3

        // end

        return answer;
    }


    public int CountSignFlips(YFunction yFunction, double a, double b, double h) {
        int cnt = 0;
        for (double x = a + h; x <= b; x += h) {
            double prev = yFunction(x - h), cur = yFunction(x);
            if ((prev >= 0 && cur < 0) || (prev <= 0 && cur > 0) || (x == b && cur == 0))
                cnt++;
        }

        return cnt;
    }

    public double y5_1(double x) {return x * x - Math.Sin(x);}

    public double y5_2(double x) {return Math.Exp(x) - 1;}
    public void Task_3_5(out int func1, out int func2)
    {
        double a1 = 0, b1 = 2, h1 = 0.1;
        func1 = CountSignFlips(y5_1, a1, b1, h1);
        double a2 = -1, b2 = 1, h2 = 0.2;
        func2 = CountSignFlips(y5_2, a2, b2, h2);
    }

    public void Task_3_6(int[,] matrix)
    {
        // code here

        // create and use public delegate FindElementDelegate(matrix);
        // use method FindDiagonalMaxIndex(matrix) from Task_2_3;
        // create and use method FindFirstRowMaxIndex(matrix);
        // create and use method SwapColumns(matrix, FindDiagonalMaxIndex, FindFirstRowMaxIndex);

        // end
    }

    public delegate int CountPositive(int[,] matrix, int index);
    public void Task_3_7(ref int[,] B, int[,] C)
    {
        CountPositive countPositive = CountRowPositive;
        int rowIndex = 0, colIndex = 0,rowMx = 0,colMx = 0;
        int mx = 0,cnt;
        for(int i = 0;i < B.GetLength(0);i++){
           cnt = countPositive(B, rowIndex);
           if (cnt > mx){
            mx = cnt;
            rowMx = rowIndex;
           }
           rowIndex++;
        }
        mx = 0;
        countPositive = CountColumnPositive;
        for(int i = 0;i < C.GetLength(1);i++){
           cnt = countPositive(C, colIndex);
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

    public delegate void FindElementDelegate(int[,] matrix, out int foundI, out int foundJ);
    public void RemoveRows(ref int[,] matrix, FindElementDelegate findElementDelegate1, FindElementDelegate findElementDelegate2) {
        int rowMx = 0, colMx = 0,rowMn = 0, colMn = 0;

        findElementDelegate1(matrix,out rowMx, out colMx);
        findElementDelegate2(matrix,out rowMn, out colMn);

        RemoveRow(ref matrix, rowMx);
        if (rowMx != rowMn){
            rowMn -= rowMx < rowMn ? 1 : 0;
            RemoveRow(ref matrix, rowMn);
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

    public delegate void ReplaceMaxElement(int[,] matrix, int i,out  int colind);
    public delegate void ReplaceMaxElement2(ref int[,] matrix, int i, int colind);
    public void EvenOddRowsTransform(int[,] matrix, ReplaceMaxElement Find, ReplaceMaxElement2 replaceMaxElement1, ReplaceMaxElement2 replaceMaxElement2) {
        int colInd;
        for(int i = 0; i < matrix.GetLength(0);i++){
            Find(matrix, i, out colInd);
            if ((i+1) % 2 > 0)
            replaceMaxElement1(ref matrix,i, colInd);
            else
            replaceMaxElement2(ref matrix,i, colInd);
        }
    }
    public void Task_3_27(int[,] A, int[,] B)
    {  
        EvenOddRowsTransform(A, FindRowMaxIndex, ReplaceMaxElementOdd, ReplaceMaxElementEven);
        EvenOddRowsTransform(B, FindRowMaxIndex, ReplaceMaxElementOdd, ReplaceMaxElementEven);
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

    public delegate void MatrixConverter(double[,] A);
    public void ToUpperTriangular(double[,] A) {
        for (int j = 0; j < A.GetLength(1); j++) {
            for (int i = j + 1; i < A.GetLength(0); i++) {
                double k = - (A[i, j] / A[j, j]);
                A[i, j] = 0;
                for (int z = j + 1; k < A.GetLength(1); k++) {A[i, z] += A[j, z] * k;}
            }
        }
    }

    public void ToLowerTriangular(double[,] A) {
        for (int j = A.GetLength(1) - 1; j >= 0; j--) {
            for (int i = j - 1; i >= 0; i--) {
                double k = - (A[i, j] / A[j, j]);
                A[i, j] = 0;
                for (int z = j - 1; k >= 0; k--) {A[i, z] += A[j, z] * k;}
            }
        }
    }
    public void ToLeftDiagonal(double[,] A) {
        ToUpperTriangular(A);
        ToLowerTriangular(A);
    }
    public void ToRightDiagonal(double[,] A) {
        ToLowerTriangular(A);
        ToUpperTriangular(A);
    }
    public double[,] Task_4(double[,] matrix, int index)
    {
        MatrixConverter[] mc = {ToUpperTriangular, ToLowerTriangular, ToLeftDiagonal, ToRightDiagonal};
        mc[index](matrix);
        return matrix;
    }
    #endregion
}
