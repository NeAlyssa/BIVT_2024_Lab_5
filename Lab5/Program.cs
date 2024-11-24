using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Numerics;
using System.Reflection;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class Program
{

    public void PrintMatrix(int[,] matrix) {
        int n = matrix.GetLength(0);
        int m = matrix.GetLength(1);

        for (int i = 0; i < n; i++) {
            for (int j = 0; j < m; j++) {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

        public void PrintMatrix(double[,] matrix) {
        int n = matrix.GetLength(0);
        int m = matrix.GetLength(1);

        for (int i = 0; i < n; i++) {
            for (int j = 0; j < m; j++) {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
    public int Factorial(int n) {
        int result = 1;
        for (int i = 2; i <= n; i++) {
            result *= i;
        }
        return result;
    }
    public bool triangleExists(double a, double b, double c) {
        return (a < b + c) && (b < a + c) && (c < a + b);
    }
    public double GeronArea(double a, double b, double c) {
        double p = (a + b + c) / 2.0;

        double S = Math.Sqrt(p * (p - a) * (p - b) * (p - c));

        return S;
    }
    public double GetDistance(double v, double a, double t) {
        double S = v * t + a * t * t / 2.0;
        return S;
    }

    public void FindMax(int[,] matrix, out int maxI, out int maxJ) {
        
        maxI = -1;
        maxJ = -1;
        int maxValue = int.MinValue;

        int n = matrix.GetLength(0);
        int m = matrix.GetLength(1);

        for (int i = 0; i < n; i++) {
            for (int j = 0; j < m; j++) {
                if (matrix[i, j] > maxValue) {
                    maxValue = matrix[i, j];
                    maxI = i;
                    maxJ = j;
                }
            }
        }

    }
    public void FindMin(int[,] matrix, out int minI, out int minJ) {
        
        minI = -1;
        minJ = -1;
        int minValue = int.MaxValue;

        int n = matrix.GetLength(0);
        int m = matrix.GetLength(1);

        for (int i = 0; i < n; i++) {
            for (int j = 0; j < m; j++) {
                if (matrix[i, j] < minValue) {
                    minValue = matrix[i, j];
                    minI = i;
                    minJ = j;
                }
            }
        }

    }
    public int FindDiagonalMax(int[,] matrix) {
        int maxValue = int.MinValue;
        int maxI = -1;

        int n = matrix.GetLength(0);
        
        for (int i = 0; i < n; i++) {
            if (matrix[i, i] > maxValue) {
                maxValue = matrix[i, i];
                maxI = i;
            }
        }

        return maxI;
    }


    public int FindColumnMax(int[,] matrix, int columnIndex) {
        int maxValue = int.MinValue;
        int maxI = -1;
        
        int n = matrix.GetLength(0);

        for (int i = 0; i < n; i++) {
            if (matrix[i, columnIndex] > maxValue) {
                maxValue = matrix[i, columnIndex];
                maxI = i;
            }
        }

        return maxI;
    }

    public int CountRowPositive(int[,] matrix, int rowIndex) {
        int result = 0;

        int m = matrix.GetLength(1);
        for (int j = 0; j < m; j++) {
            if (matrix[rowIndex, j] > 0)
                result++;
        }
        return result;
    }

    public int CountRowNegative(int[,] matrix, int rowIndex) {
        int result = 0;

        int m = matrix.GetLength(1);
        for (int j = 0; j < m; j++) {
            if (matrix[rowIndex, j] < 0)
                result++;
        }
        return result;
    }

    public int CountColumnPositive(int[,] matrix, int colIndex) {
        int result = 0;

        int n = matrix.GetLength(0);

        for (int i = 0; i < n; i++) {
            if (matrix[i, colIndex] > 0)
                result++;
        }
        return result;
    }


    public int[] SumPositiveElementsInColumns(int[,] matrix) {

        int n = matrix.GetLength(0);
        int m = matrix.GetLength(1);
        
        int[] result = new int[m];

        for (int j = 0; j < m; j++) {
            int curSum = 0;
            for (int i = 0; i < n; i++) {
                if (matrix[i, j] > 0)
                    curSum += matrix[i, j];
            }

            result[j] = curSum;
        }

        return result;
    }

    public void RemoveRow(ref int[,] matrix, int rowIndex) {

        int n = matrix.GetLength(0);
        int m = matrix.GetLength(1);

        int[,] tmpMatrix = new int[n - 1, m];

        for (int i = 0; i < n - 1; i++) {
            for (int j = 0; j < m; j++) {
                if (i < rowIndex)
                    tmpMatrix[i, j] = matrix[i, j];
                else 
                    tmpMatrix[i, j] = matrix[i + 1, j];
            }
        }

        matrix = tmpMatrix;
    }

    public double GetAverageWithoutMinMax(int[,] matrix) {

        int n = matrix.GetLength(0);
        int m = matrix.GetLength(1);

        int maxI, maxJ, minI, minJ;
        FindMax(matrix, out maxI, out maxJ);
        FindMin(matrix, out minI, out minJ);

        int count = 0;
        double sum = 0, average = 0;

        for (int i = 0; i < n; i++) {
            for (int j = 0; j < m; j++) {
                if (!(i == maxI && j == maxJ) && !(i == minJ && j == minJ)) {
                    count++;
                    sum += matrix[i, j];
                }
            }
        }

        if (count != 0)
            average = sum / count;

        return average;
    }

    public void SortRowsByMaxElement(int[,] matrix) {
        int n = matrix.GetLength(0);
        int m = matrix.GetLength(1);

        for (int i = 1; i < n; i++) {

            for (int j = i; j > 0; j--) {

                if (matrix[j - 1, FindRowMaxIndex(matrix, j - 1)] < matrix[j, FindRowMaxIndex(matrix, j)]) {
                    for (int col = 0; col < m; col++) {
                        (matrix[j - 1, col], matrix[j, col]) = (matrix[j, col], matrix[j - 1, col]);
                    }
                } else 
                    break;

            }
        }
    }

    public int[] CreateArrayFromMins(int[,] matrix) {
        int n = matrix.GetLength(0);
        int m = matrix.GetLength(1);

        int[] result = new int[n];

        for (int i = 0; i < n; i++) {
            int minValue = int.MaxValue;

            for (int j = i; j < m; j++) {
                if (matrix[i, j] < minValue)
                    minValue = matrix[i, j];
            }
            result[i] = minValue;
        }

        return result;
    }

    public void MatrixValuesChange(double[,] matrix) {
        int n = matrix.GetLength(0);
        int m = matrix.GetLength(1);

        double[] arrayFromMatrix = new double[n * m];
        for (int i = 0, k = 0; i < n; i++) {
            for (int j = 0; j < m; j++, k++) {
                arrayFromMatrix[k] = matrix[i, j];
            }
        }

        for (int i = 1; i < arrayFromMatrix.Length; i++) {
            for (int j = i; j > 0; j--) {
                if (arrayFromMatrix[j - 1] < arrayFromMatrix[j]) 
                    (arrayFromMatrix[j - 1], arrayFromMatrix[j]) = (arrayFromMatrix[j], arrayFromMatrix[j - 1]);
                else
                    break;
            }
        }

        for (int i = 0; i < n; i++) {
            for (int j = 0; j < m; j++) {
                double current = matrix[i, j];

                bool increased = false;

                for (int k = 0; k < 5; k++) {
                    if (current == arrayFromMatrix[k]) {
                        matrix[i, j] = (current > 0) ? (current * 2) : (current / 2);
                        increased = true;
                        break;
                    }
                }

                if (!increased)
                    matrix[i, j] = (current > 0) ? (current / 2) : (current * 2);
            }
        }

    }

    public int FindMaxNegativeRow(int[,] matrix) {
        int n = matrix.GetLength(0);
        
        int maxValue = -1;
        int maxRowIndex = -1;

        for (int i = 0; i < n; i++) {
            if (CountRowNegative(matrix, i) > maxValue) {
                maxValue = CountRowNegative(matrix, i);
                maxRowIndex = i;
            }
        }

        return maxRowIndex;
    }

    public int FindRowMaxIndex(int[,] matrix, int rowIndex) {
        int m = matrix.GetLength(1);

        int maxValue = int.MinValue;
        int maxIndex = -1;

        for (int j = 0; j < m; j++) {
            if (matrix[rowIndex, j] > maxValue) {
                maxValue = matrix[rowIndex, j];
                maxIndex = j;
            }
        }
        return maxIndex;
    }

    public void ReplaceMaxElementOdd(int[,] matrix) {
        int n = matrix.GetLength(1);
        int m = matrix.GetLength(1);

        for (int i = 0; i < n; i += 2) {
            int maxRowIndex = FindRowMaxIndex(matrix, i);

            for (int j = 0; j < m; j++) {
                if (matrix[i, j] == matrix[i, maxRowIndex])
                    matrix[i, j] *= j + 1;
            }
        }
        
    }

    public void ReplaceMaxElementEven(int[,] matrix) {
        int n = matrix.GetLength(1);
        int m = matrix.GetLength(1);

        for (int i = 1; i < n; i += 2) {
            int maxRowIndex = FindRowMaxIndex(matrix, i);

            for (int j = 0; j < m; j++) {
                if (matrix[i, j] == matrix[i, maxRowIndex])
                    matrix[i, j] = 0;
            }
        }
    }


    public static void Main()
    {
        Program program = new Program();
        
        double[,] a = null, b = null;
        program.Task_3_1(ref a, ref b);
    
         
    }

    #region Level 1
    public long Task_1_1(int n, int k)
    {
        long answer = 0;

        // code here
        if (n < k || k < 0)
            return 0;

        answer = Factorial(n) / (Factorial(k) * Factorial(n - k));

        // end

        return answer;
    }
    
    public int Task_1_2(double[] first, double[] second)
    {
        int answer = 0;

        // code here
        double a1 = first[0], b1 = first[1], c1 = first[2];
        double a2 = second[0], b2 = second[1], c2 = second[2];
        
        if (!triangleExists(a1, b1, c1) || !triangleExists(a2, b2, c2))
            return -1;

        double firstArea = GeronArea(a1, b1, c1);
        double secondArea = GeronArea(a2, b2, c2);

        if (firstArea > secondArea)
            answer = 1;
        else if (secondArea > firstArea)
            answer = 2;
        else
            answer = 0;

        // end

        return answer;
    }

    public int Task_1_3a(double v1, double a1, double v2, double a2, int time)
    {
        int answer = 0;

        // code here
        double firstDistance = GetDistance(v1, a1, time);
        double secondDistance = GetDistance(v2, a2, time);
        if (firstDistance > secondDistance)
            answer = 1;
        else if (secondDistance > firstDistance)
            answer = 2;
        else    
            answer = 0;
        // end

        return answer;
    }

    public int Task_1_3b(double v1, double a1, double v2, double a2)
    {
        int answer = 0;

        // code here
        int t = 1;
        while (GetDistance(v1, a1, t) > GetDistance(v2, a2, t))
            t++;

        answer = t;
        // end

        return answer;
    }
    #endregion

    #region Level 2
    public void Task_2_1(int[,] A, int[,] B) // important: test errors?
    {
        // code here

        int aMaxI, aMaxJ, bMaxI, bMaxJ;

        FindMax(A, out aMaxI, out aMaxJ);
        FindMax(B, out bMaxI, out bMaxJ);

        (A[aMaxI, aMaxJ], B[bMaxI, bMaxJ]) = (B[bMaxI, bMaxJ], A[aMaxI, aMaxJ]);
        // end
    }

    public void Task_2_2(double[] A, double[] B)
    {
        // code here

        // create and use FindMax(array);

        // end
    }

    public void Task_2_3(ref int[,] B, ref int[,] C)
    {
        // code here

        int[,] tmpB = new int[4, 5];
        int[,] tmpC = new int[5, 6];    

        int maxB = FindDiagonalMax(B);
        int maxC = FindDiagonalMax(C);

        for (int i = 0; i < 4; i++) {
            for (int j = 0; j < 5; j++) {
                if (i < maxB)
                    tmpB[i, j] = B[i, j];
                else
                    tmpB[i, j] = B[i + 1, j];
            }
        }

        for (int i = 0; i < 5; i++) {
            for (int j = 0; j < 6; j++) {
                if (i < maxC)
                    tmpC[i, j] = C[i, j];
                else
                    tmpC[i, j] = C[i + 1, j];
            }
        }

        B = tmpB;
        C = tmpC;
        // end
    }

    public void Task_2_4(int[,] A, int[,] B)
    {
        // code here

        // use method FindDiagonalMax(matrix); from Task_2_3
        // use method FindDiagonalMaxIndex(matrix); from Task_2_3

        // end
    }

    public void Task_2_5(int[,] A, int[,] B)
    {
        // code here

        int maxA = FindColumnMax(A, 0);
        int maxB = FindColumnMax(B, 0);

        for (int j = 0; j < 6; j++) {
            (A[maxA, j], B[maxB, j]) = (B[maxB, j], A[maxA, j]);
        }

        // end
    }

    public void Task_2_6(ref int[] A, int[] B)
    {
        // code here

        // create and use DeleteElement(array, index);

        // end
    }

    public void Task_2_7(ref int[,] B, int[,] C)
    {
        // code here

        int maxBValue = 0;
        int maxBIndex = -1;
        for (int i = 0; i < 4; i++) {
            if (CountRowPositive(B, i) > maxBValue) {
                maxBValue = CountRowPositive(B, i);
                maxBIndex = i;
            }
        }

        int maxCValue = 0;
        int maxCIndex = -1;
        for (int j = 0; j < 6; j++) {
            if (CountColumnPositive(C, j) > maxCValue) {
                maxCValue = CountColumnPositive(C, j);
                maxCIndex = j;
            }
        }

        int[,] resultB = new int[5, 5];

        for (int i = 0; i < 5; i++) {
            for (int j = 0; j < 5; j++) {
                if (i <= maxBIndex) 
                    resultB[i, j] = B[i, j];
                else if (i == maxBIndex + 1)
                    resultB[i, j] = C[j, maxCIndex];
                else
                    resultB[i, j] = B[i - 1, j];
            }
        }

        B = resultB;


        // end
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
        int[] ASums = SumPositiveElementsInColumns(A);
        int[] CSums = SumPositiveElementsInColumns(C);

        answer = new int[ASums.Length + CSums.Length];

        for (int i = 0; i < ASums.Length; i++) {
            answer[i] = ASums[i];
        }

        for (int i = 0; i < CSums.Length; i++) {
            answer[i + ASums.Length] = CSums[i];
        }


        // end

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

        int AMaxI, AMaxJ, BMaxI, BMaxJ;

        FindMax(A, out AMaxI, out AMaxJ);
        FindMax(B, out BMaxI, out BMaxJ);

        (A[AMaxI, AMaxJ], B[BMaxI, BMaxJ]) = (B[BMaxI, BMaxJ], A[AMaxI, AMaxJ]);

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

        int matrixMaxI, matrixMaxJ, matrixMinI, matrixMinJ;

        FindMax(matrix, out matrixMaxI, out matrixMaxJ);
        FindMin(matrix, out matrixMinI, out matrixMinJ);

        RemoveRow(ref matrix, matrixMaxI);

        if (matrixMinI < matrixMaxI)
            RemoveRow(ref matrix, matrixMinI);
        else if (matrixMinI > matrixMaxI)
            RemoveRow(ref matrix, matrixMinI - 1);
        // end
    }
    
    public void Task_2_14(int[,] matrix)
    {
        // code here

        // create and use SortRow(matrix, rowIndex);

        // end
    }
    
    public int Task_2_15(int[,] A, int[,] B, int[,] C)
    {
        int answer = 0; // 1 - increasing   0 - no sequence   -1 - decreasing

        // code here

        double[] sequence = {GetAverageWithoutMinMax(A), GetAverageWithoutMinMax(B), GetAverageWithoutMinMax(C)};

        if (sequence[0] < sequence[1] && sequence[1] < sequence[2])
            answer = 1;
        else if (sequence[0] > sequence[1] && sequence[1] > sequence[2])
            answer = -1;
        else
            answer = 0;
        // end

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

        SortRowsByMaxElement(A);
        SortRowsByMaxElement(B);

        // end
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
        while (true) {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            for (int i = 0; i < n; i++) {
                for (int j = 0; j < m; j++) {
                    if (matrix[i, j] == 0) {
                        RemoveRow(ref matrix, i);
                        goto nextIteration;
                    }
                }
            }

            break;

            nextIteration:;
        }

        // end
    }
    public void Task_2_20(ref int[,] A, ref int[,] B)
    {
        // code here

        // use RemoveColumn(matrix, columnIndex); from 2_10

        // end
    }    

    public void Task_2_21(int[,] A, int[,] B, out int[] answerA, out int[] answerB)
    {
        // code here
        answerA = CreateArrayFromMins(A);
        answerB = CreateArrayFromMins(B);
        // end
    }

    public void Task_2_22(int[,] matrix, out int[] rows, out int[] cols)
    {
        rows = null;
        cols = null;

        // code here

        // create and use GetNegativeCountPerRow(matrix);
        // create and use GetMaxNegativePerColumn(matrix);

        // end
    }

    public void Task_2_23(double[,] A, double[,] B)
    {
        // code here

        MatrixValuesChange(A);
        MatrixValuesChange(B);

        // end
    }

    public void Task_2_24(int[,] A, int[,] B)
    {
        // code here

        // use FindMax(matrix); from 2_1

        // end
    }

    public void Task_2_25(int[,] A, int[,] B, out int maxA, out int maxB)
    {
        maxA = 0;
        maxB = 0;

        // code here
       
       maxA = FindMaxNegativeRow(A);
       maxB = FindMaxNegativeRow(B);

        // end
    }

    public void Task_2_26(int[,] A, int[,] B)
    {
        // code here

        // use GetNegativeCountPerRow(matrix); from 2_22
        // create and use FindMaxIndex(array);

        // end
    }

    public void Task_2_27(int[,] A, int[,] B)
    {
        // code here
        
        ReplaceMaxElementEven(A);
        ReplaceMaxElementOdd(A);

        ReplaceMaxElementEven(B);
        ReplaceMaxElementOdd(B);
        
        // end
    }

    public void Task_2_28a(int[] first, int[] second, ref int answerFirst, ref int answerSecond)
    {
        // code here

        // create and use FindSequence(array, A, B); // 1 - increasing, 0 - no sequence,  -1 - decreasing

        // end
    }

    public void Task_2_28b(int[] first, int[] second, ref int[,] answerFirst, ref int[,] answerSecond)
    {
        // code here

        // use FindSequence(array, A, B); from Task_2_28a or entirely Task_2_28a

        // end
    }

    public void Task_2_28c(int[] first, int[] second, ref int[] answerFirst, ref int[] answerSecond)
    {
        // code here

        // use FindSequence(array, A, B); from Task_2_28a or entirely Task_2_28a or Task_2_28b

        // end
    }
    #endregion

    #region Level 3
 

        public delegate double SumFunction(int i, double x);
        public delegate double YFunction(double x);
        public double s1Term(int i, double x) {
            return Math.Cos(i * x) / Factorial(i);
        }
        public double s2Term(int i, double x) {
            return Math.Pow(-1, i) * Math.Cos(i * x) / (i * i);
        }
        public double y1(double x) {
            return Math.Exp(Math.Cos(x)) * Math.Cos(Math.Sin(x));
        }
        public double y2(double x) {
            return ((x * x) - Math.PI * Math.PI / 3) / 4;
        }
        public double CalculateSum(SumFunction sumFunction, double x, int i) {
            double epsilon = 0.00001;
            double sum = 0;
            double curTerm = sumFunction(i, x);

            while (Math.Abs(curTerm) >= epsilon) {
                sum += curTerm;
                curTerm = sumFunction(++i, x);
            }
            return sum;
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
    
        // code here 
            double a1 = 0.1, b1 = 1, h1 = 0.1;
            firstSumAndY = new double[(int) ((b1 - a1) / h1) + 1, 2];
            GetSumAndY(s1Term, y1, a1, b1, h1, firstSumAndY);

    
            double a2 = Math.PI / 5, b2 = Math.PI, h2 = Math.PI / 25;
            secondSumAndY = new double[(int) ((b2 - a2) / h2) + 1, 2];
            GetSumAndY(s2Term, y2, a2, b2, h2, secondSumAndY, 1);

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
        // create and use methods SwapRight(array) and SwapLeft(array) and GetSum(array)
        // change method in variable swapper in the loop here and use it for array swapping

        // end

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
        // use method FindDiagonalMaxIndex(matrix) from Task_2_3;
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
    public void Task_4(double[,] matrix, int index)
    {
        // MatrixConverter[] mc = new MatrixConverter[3]; - uncomment me

        // code here

        // create public delegate MatrixConverter(matrix);
        // create and use method ToUpperTriangular(matrix);
        // create and use method ToLowerTriangular(matrix);
        // create and use method ToDiagonal(matrix,);

        // end
    }
    #endregion
}