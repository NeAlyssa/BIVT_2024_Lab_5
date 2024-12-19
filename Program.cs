using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Numerics;
using System.Reflection;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class Program
{

    public static void Main()
    {
        Program program = new Program();
    }

    public int Factorial(int n)
    {
        int fact = 1;
        for (int i = 1; i <= n; i++)
        {
            fact *= i;
        }

        return fact;
    }

    #region Level 1
    public long Task_1_1(int n, int k)
    {
        if (k <= 0 || n < 0 || n <= k) { return 0; }
        long answer = 0;

        answer = (long)Factorial(n) / (Factorial(k) * Factorial(n - k));


        return answer;
    }


    public bool CheckTriangle(double a, double b, double c)
    {
        return (a + b > c && a + c > b && b + c > a);
    }

    public double GeronArea(double a, double b, double c)
    {
        double p = (a + b + c) / 2;
        double square = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        return square;
    }

    public int Task_1_2(double[] first, double[] second)
    {
        int answer = 0;

        double a1 = first[0], b1 = first[1], c1 = first[2];
        double a2 = second[0], b2 = second[1], c2 = second[2];

        if (CheckTriangle(a1, b1, c1) == false || CheckTriangle(a2, b2, c2) == false)
        {
            answer = -1;
        }
        else
        {
            if (GeronArea(a1, b1, c1) == GeronArea(a2, b2, c2)) answer = 0;
            else if (GeronArea(a1, b1, c1) > GeronArea(a2, b2, c2)) answer = 1;
            else if (GeronArea(a1, b1, c1) < GeronArea(a2, b2, c2)) answer = 2;
        }

        return answer;
    }




    public double GetDistance(double v, double a, double t)
    {
        double dist = v * t + a * t * t / 2;
        return dist;
    }
    public int Task_1_3a(double v1, double a1, double v2, double a2, int time)
    {

        int answer = 0;
        if (GetDistance(v1, a1, time) == GetDistance(v2, a2, time)) answer = 0;

        else if (GetDistance(v1, a1, time) > GetDistance(v2, a2, time)) answer = 1;

        else if (GetDistance(v1, a1, time) < GetDistance(v2, a2, time)) answer = 2;

        return answer;
    }


    public int Task_1_3b(double v1, double a1, double v2, double a2)
    {
        int t = 1;
        while (GetDistance(v1, a1, t) > GetDistance(v2, a2, t))
            t++;
        return t;
    }
    #endregion

    #region Level 2

    public void FindMaxIndex(int[,] matrix, out int indexi, out int indexj)
    {
        indexi = -1;
        indexj = -1;
        int max = matrix[0, 0];
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] > max)
                {
                    max = matrix[i, j];
                    indexi = i;
                    indexj = j;
                }
            }
        }


    }
    public void Task_2_1(int[,] A, int[,] B)
    {
        int iA, jA, iB, jB;
        FindMaxIndex(A, out iA, out jA);
        FindMaxIndex(B, out iB, out jB);

        (A[iA, jA], B[iB, jB]) = (B[iB, jB], A[iA, jA]);

    }


    public void Task_2_2(double[] A, double[] B)
    {
        // code here

        // create and use FindMaxIndex(array);
        // only 1 array have to be changed!

        // end
    }


    public int FindDiaginalMaxIndex(int[,] matrix)
    {
        int max = matrix[0, 0];
        int row = -1;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            if (max < matrix[i, i])
            {
                max = matrix[i, i];
                row = i;
            }
        }
        return row;
    }

    public void Task_2_3(ref int[,] B, ref int[,] C)
    {
        // В матрицах В размера 5 × 5 и С размера 6 × 6 удалить строку, содержащую
        // максимальный элемент на диагонали.Поиск максимального элемента диагонали
        // осуществить в методе.
        // code here
        int rowB = FindDiaginalMaxIndex(B);
        int rowC = FindDiaginalMaxIndex(C);

        int[,] newB = new int[4, 5];
        int[,] newC = new int[5, 6];

        for (int i = 0; i < B.GetLength(0) - 1; i++)
        {
            for (int j = 0; j < B.GetLength(1); j++)
            {
                if (i < rowB) newB[i, j] = B[i, j];
                else newB[i, j] = B[i + 1, j];
            }
        }


        for (int i = 0; i < C.GetLength(0) - 1; i++)
        {
            for (int j = 0; j < C.GetLength(1); j++)
            {
                if (i < rowC) newC[i, j] = C[i, j];
                else newC[i, j] = C[i + 1, j];
            }
        }
        B = newB;
        C = newC;

        //  create and use method FindDiagonalMaxIndex(matrix);

        // end
    }

    public void Task_2_4(int[,] A, int[,] B)
    {
        // code here

        //  create and use method FindDiagonalMaxIndex(matrix); like in Task_2_3

        // end
    }

    public int FindMaxInColumn(int[,] matrix)
    {
        int max = matrix[0, 0];
        int index = -1;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            if (max < matrix[i, 0]) { max = matrix[i, 0]; index = i; }
        }
        return index;
    }
    public void Task_2_5(int[,] A, int[,] B)
    {
        int indexA = FindMaxInColumn(A);
        int indexB = FindMaxInColumn(B);

        for (int j = 0; j < A.GetLength(1); j++)
        {
            (A[indexA, j], B[indexB, j]) = (B[indexB, j], A[indexA, j]);
        }
    }

    public void Task_2_6(ref int[] A, int[] B)
    {
        // code here

        // create and use FindMax(matrix, out row, out column); like in Task_2_1
        // create and use DeleteElement(array, index);

        // end
    }


    public int CountRowPositive(int[,] matrix)
    {
        int max = 0;
        int rowIndex = -1;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            int count = 0;
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] > 0) count++;
            }

            if (max < count)
            {
                max = count;
                rowIndex = i;
            }
        }
        return rowIndex;
    }

    public int CountColumnPositive(int[,] matrix)
    {
        int max = 0;
        int colIndex = -1;
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            int count = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, j] > 0) count++;
            }

            if (max < count)
            {
                max = count;
                colIndex = j;
            }
        }
        return colIndex;
    }
    public void Task_2_7(ref int[,] B, int[,] C)
    {
        int[,] newB = new int[5, 5];
        int rowIndex = CountRowPositive(B);
        int colIndex = CountColumnPositive(C);

        for (int i = 0; i <= rowIndex; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                newB[i, j] = B[i, j];
            }
        }

        for (int i = rowIndex + 1; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (i == rowIndex + 1)
                {
                    newB[i, j] = C[j, colIndex];
                }
                else
                {
                    newB[i, j] = B[i - 1, j];
                }
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

    public int SumPositiveElementsInColumns(int[,] matrix, int colIndex)
    {
        int sum = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            if (matrix[i, colIndex] > 0)
            {
                sum += matrix[i, colIndex];
            }
        }
        return sum;

    }
    public int[] Task_2_9(int[,] A, int[,] C)
    {
        int[] answer = new int[A.GetLength(1) + C.GetLength(1)];
        int sum = 0;
        int index = 0;
        for (int j = 0; j < A.GetLength(1); j++)
        {
            sum = SumPositiveElementsInColumns(A, j);
            answer[j] = sum;
            index = j;
        }
        index++;
        for (int j = 0; j < C.GetLength(1); j++)
        {
            sum = SumPositiveElementsInColumns(C, j);
            answer[index] = sum;
            index++;

        }
        return answer;
    }

    public void Task_2_10(ref int[,] matrix)
    {
        // code here

        // create and use RemoveColumn(matrix, columnIndex);

        // end
    }

    public (int, int) FindMaxIndex(int[,] matrix)
    {
        int max = matrix[0, 0];
        (int indexi, int indexj) = (-1, -1);
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (max < matrix[i, j])
                {
                    max = matrix[i, j];
                    indexi = i;
                    indexj = j;
                }
            }
        }
        return (indexi, indexj);
    }
    public void Task_2_11(int[,] A, int[,] B)
    {
        (int iA, int jA) = FindMaxIndex(A);
        (int iB, int jB) = FindMaxIndex(B);

        (A[iA, jA], B[iB, jB]) = (B[iB, jB], A[iA, jA]);
    }
    public void Task_2_12(int[,] A, int[,] B)
    {
        // code here

        // create and use FindMaxColumnIndex(matrix);

        // end
    }

    public void FindMaxElement(int[,] matrix, out int maxI, out int maxJ)
    {

        maxI = -1;
        maxJ = -1;
        int maxVal = int.MinValue;

        int rowInd = matrix.GetLength(0);
        int colInd = matrix.GetLength(1);

        for (int i = 0; i < rowInd; i++)
        {
            for (int j = 0; j < colInd; j++)
            {
                if (matrix[i, j] > maxVal)
                {
                    maxVal = matrix[i, j];
                    maxI = i;
                    maxJ = j;
                }
            }
        }

    }
    public void FindMinElement(int[,] matrix, out int minI, out int minJ)
    {

        minI = -1;
        minJ = -1;
        int minValue = int.MaxValue;

        int rowInd = matrix.GetLength(0);
        int colInd = matrix.GetLength(1);

        for (int i = 0; i < rowInd; i++)
        {
            for (int j = 0; j < colInd; j++)
            {
                if (matrix[i, j] < minValue)
                {
                    minValue = matrix[i, j];
                    minI = i;
                    minJ = j;
                }
            }
        }

    }
    public void RemoveRow(ref int[,] matrix, int rowIndex)
    {

        int rowInd = matrix.GetLength(0);
        int colInd = matrix.GetLength(1);

        int[,] newMatrix = new int[rowInd - 1, colInd];

        for (int i = 0; i < rowInd - 1; i++)
        {
            for (int j = 0; j < colInd; j++)
            {
                if (i < rowIndex) { newMatrix[i, j] = matrix[i, j]; }
                else { newMatrix[i, j] = matrix[i + 1, j]; }
            }
        }
        matrix = newMatrix;
    }

    public void Task_2_13(ref int[,] matrix)
    {
        // В заданной матрице удалить строки, содержащие максимальный и минимальный элементы матрицы.
        // Удаление строки оформить в виде метода.
        int MaxI, MaxJ, MinI, MinJ;
        FindMaxElement(matrix, out MaxI, out MaxJ);
        FindMinElement(matrix, out MinI, out MinJ);

        int Row1 = Math.Min(MinI, MaxI), Row2 = Math.Max(MinI, MaxI);

        RemoveRow(ref matrix, Row2);

        if (Row1 != Row2)
        {
            RemoveRow(ref matrix, Row1);
        }
            
        // create and use RemoveRow(matrix, rowIndex);

        // end
    }


    public void Task_2_14(int[,] matrix)
    {
        // code here

        // create and use SortRow(matrix, rowIndex);

        // end
    }
    public int GetAverageWithoutMinMax(int[,] matrix)
    {
        int maxval = matrix[0, 0], minval = matrix[0, 0];
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
                if (maxval < matrix[i, j]) { maxval = matrix[i, j]; }

            for (int j = 0; j < matrix.GetLength(1); j++)
                if (minval > matrix[i, j]) { minval = matrix[i, j]; }
        }
        int sum = 0, count = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] == maxval || matrix[i, j] == minval) continue;
                else { sum += matrix[i, j]; count++; }
            }
        }
        return sum / count;
    }

    public int Task_2_15(int[,] A, int[,] B, int[,] C)
    {
        // Для каждой из трех заданных матриц найти среднее значение ее элементов без учета
        // максимального и минимального элементов. Полученные значения занести в одномерный массив.
        // Определить, образовали ли полученные значения убывающую или возрастающую последовательность.
        // Нахождение среднего значения элементов матрицы оформить в вид метода.
        if (A == null || A.GetLength(0) == 0 || A.GetLength(1) == 0) return 0;
        if (B == null || B.GetLength(0) == 0 || B.GetLength(1) == 0) return 0;
        if (C == null || C.GetLength(0) == 0 || C.GetLength(1) == 0) return 0;
        int[] ans = new int[3];
        ans[0] = GetAverageWithoutMinMax(A);
        ans[1] = GetAverageWithoutMinMax(B);
        ans[2] = GetAverageWithoutMinMax(C);
        if (ans[0] < ans[1] && ans[1] < ans[2]) return 1;
        else if (ans[0] > ans[1] && ans[1] > ans[2]) return -1;
        else return 0;

        // code here

        // create and use GetAverageWithoutMinMax(matrix);

        // end

        // 1 - increasing   0 - no sequence   -1 - decreasing

    }

    public void Task_2_16(int[] A, int[] B)
    {
        // code here

        // create and use SortNegative(array);

        // end
    }

    public void Task_2_17(int[,] A, int[,] B)
    {
        if (A == null || A.GetLength(0) == 0 || A.GetLength(1) == 0) return;
        if (B == null || B.GetLength(0) == 0 || B.GetLength(1) == 0) return;
        SortRowsByMaxElement(A);
        SortRowsByMaxElement(B);

        static int FindRowMax(int[,] matrix, int rowIndex)
        {
            int columnCount = matrix.GetLength(1);
            int maxVal = int.MinValue;
            for (int j = 1; j < columnCount; j++)
            {
                if (maxVal < matrix[rowIndex, j])
                {
                    maxVal = matrix[rowIndex, j];
                }
            }

            return maxVal;
        }

        static void SwapRows(int[,] matrix, int firstRowIndex, int secondRowIndex)
        {
            int columnCount = matrix.GetLength(1);
            for (int j = 0; j < columnCount; j++)
            {
                int temp = matrix[firstRowIndex, j];
                matrix[firstRowIndex, j] = matrix[secondRowIndex, j];
                matrix[secondRowIndex, j] = temp;
            }
        }

        static void SortRowsByMaxElement(int[,] matrix)
        {
            int columnCount = matrix.GetLength(1);
            int rowCount = matrix.GetLength(0);
            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < rowCount - i - 1; j++)
                {
                    int firstRowValue = FindRowMax(matrix, j);
                    int secondRowValue = FindRowMax(matrix, j + 1);
                    if (firstRowValue < secondRowValue)
                    {
                        SwapRows(matrix, j, j + 1);
                    }
                }
            }

        }
    }

    public void Task_2_18(int[,] A, int[,] B)
    {


        // code here

        // create and use SortDiagonal(matrix);

        // end
    }
    public void Task_2_19(ref int[,] matrix)
    {
        if (matrix == null || matrix.GetLength(0) == 0 || matrix.GetLength(1) == 0) return;

        while (FindRowWithZero(matrix) != -1)
        {
            RemoveRow(ref matrix);
        }
    

    static int FindRowWithZero(int[,] matrix)
    {
        int rowCount = matrix.GetLength(0);
        int columnCount = matrix.GetLength(1);
        for (int i = 0; i < rowCount; i++)
        {
            for (int j = 0; j < columnCount; j++)
            {
                if (matrix[i, j] == 0)
                {
                    return i;
                }
            }
        }
        return -1;
    }

    static void RemoveRow(ref int[,] matrix)
    {
        int rowCount = matrix.GetLength(0);
        int columnCount = matrix.GetLength(1);
        int rowIndex = FindRowWithZero(matrix);

        if (rowIndex == -1) return; 

        int[,] newMatrix = new int[rowCount - 1, columnCount];

        for (int i = 0; i < rowCount - 1; i++)
        {

            for (int j = 0; j < columnCount; j++)
            {
                if (i < rowIndex) newMatrix[i, j] = matrix[i, j];
                else newMatrix[i, j] = matrix[i + 1, j];
            }
        }

        matrix = newMatrix;
    }

}
    // use RemoveRow(matrix, rowIndex); from 2_13

    // end

    public void Task_2_20(ref int[,] A, ref int[,] B)
    {
        // code here

        // use RemoveColumn(matrix, columnIndex); from 2_10

        // end
    }

    public void Task_2_21(int[,] A, int[,] B, out int[] answerA, out int[] answerB)
    {
        // Для двух заданных квадратных матриц составить одномерные массивы из минимальных элементов строк,
        // расположенных правее элементов главной диагонали (включая диагональ).
        // Формирование одномерного массива оформить в виде метода.
        /*
        1 2 3     a00 a01 a02   проходимся по строкам с условием, что j >= i
        4 5 6     a10 a11 a12
        7 8 9     a20 a21 a22
         */
        answerA = null;
        answerB = null;
        if (A == null || A.GetLength(0) == 0 || A.GetLength(1) == 0) return;
        if (B == null || B.GetLength(0) == 0 || B.GetLength(1) == 0) return;
        answerA = CreateArrayFromMins(A);
        answerB = CreateArrayFromMins(B);


        static int FindMinIndex(int[,] matrix, int rowIndex)
        {
            
            int columnCount = matrix.GetLength(1);

            int minCol = rowIndex;
            for (int j = rowIndex; j < columnCount; j++)
                if (matrix[rowIndex, minCol] > matrix[rowIndex, j])
                {
                    minCol = j;
                }
            return minCol;

        }
        static int[] CreateArrayFromMins(int[,] matrix)
        {
            int rowCount = matrix.GetLength(0);
            int columnCount = matrix.GetLength(1);
            int[] array = new int[rowCount];
            for (int i = 0; i < rowCount; i++)
            {
                int j = FindMinIndex(matrix, i);
                array[i] = matrix[i, j];
            }
            return array;
        }

        // code here

        // create and use CreateArrayFromMins(matrix);

        // end
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
        // В двух заданных матрицах по пять наибольших элементов увеличить вдвое, остальные вдвое уменьшить.
        // Преобразование матрицы оформить в виде метода.
        if (A == null || A.GetLength(0) == 0 || A.GetLength(1) == 0) { return; }
        if (B == null || B.GetLength(0) == 0 || B.GetLength(1) == 0) { return; }
        MatrixValuesChange(A);
        MatrixValuesChange(B);

        // create and use MatrixValuesChange(matrix);

        // end
    }
    public void MatrixValuesChange(double[,] matrix)
    {
        int n = matrix.GetLength(0);
        int m = matrix.GetLength(1);

        double[] arrayFromMatrix = new double[n * m];
        for (int i = 0, k = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++, k++)
            {
                arrayFromMatrix[k] = matrix[i, j];
            }
        }

        for (int i = 1; i < arrayFromMatrix.Length; i++)
        {
            for (int j = i; j > 0; j--)
            {
                if (arrayFromMatrix[j - 1] < arrayFromMatrix[j])
                    (arrayFromMatrix[j - 1], arrayFromMatrix[j]) = (arrayFromMatrix[j], arrayFromMatrix[j - 1]);
                else
                    break;
            }
        }

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                double current = matrix[i, j];

                bool increased = false;

                for (int k = 0; k < 5; k++)
                {
                    if (current == arrayFromMatrix[k])
                    {
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

    public void Task_2_24(int[,] A, int[,] B)
    {
        // code here
        

        // use FindMaxIndex(matrix, out row, out column); like in 2_1
        // create and use SwapColumnDiagonal(matrix, columnIndex);

        // end
    }

    public void Task_2_25(int[,] A, int[,] B, out int maxA, out int maxB)
    {
        // В двух заданных матрицах найти строку, содержащую максимальное количество отрицательных элементов.
        // Нахождение количества отрицательных элементов строк матрицы и поиск среди них максимального оформить в виде методов.
        maxA = FindRowWithMaxNegativeCount(A);
        maxB = FindRowWithMaxNegativeCount(B);
        if (A == null || A.GetLength(0) == 0 || A.GetLength(1) == 0) { return; }
        if (B == null || B.GetLength(0) == 0 || B.GetLength(1) == 0) { return; }
        static int CountNegativeElementInRow(int[,] matrix, int rowIndex)
        {
            int count = 0;
            int colCount = matrix.GetLength(1);
            for (int j = 0; j < colCount; j++)
            {
                if (matrix[rowIndex, j] < 0) { count++; }
            }
            return count;
        }

        static int FindRowWithMaxNegativeCount(int[,] matrix)
        {
            int maxCount = 0;
            int index = 0;
            int rowCount = matrix.GetLength(0);
            for (int i = 0; i < rowCount; i++)
            { 
                int count = CountNegativeElementInRow(matrix, i);
                if (maxCount < count) { maxCount = count; index = i; }
            }
            return index;
        }


        // create and use FindRowWithMaxNegativeCount(matrix);
        // in FindRowWithMaxNegativeCount create and use CountNegativeInRow(matrix, rowIndex); like in 2_22

        // end
    }

    public void Task_2_26(int[,] A, int[,] B)
    {
        // code here

        // create and use FindRowWithMaxNegativeCount(matrix); like in 2_25
        // in FindRowWithMaxNegativeCount use CountNegativeInRow(matrix, rowIndex); from 2_22

        // end
    }
    public int FindMaxElement(int[,] matrix, int rowIndex)
    {
        int colCount = matrix.GetLength(1);
        int colIndex = 0;
        for (int j = 1; j < colCount; j++)
        {
            if (matrix[rowIndex, colIndex] < matrix[rowIndex, j])
            {
                colIndex = j;
            }
        }
        return colIndex;
    }

    public void ReplaceMaxElementEven(int[,] matrix)
    {
        int rowCount = matrix.GetLength(0);
        for (int i = 0; i < rowCount; i += 2)
        {
            int maxCol = FindMaxElement(matrix, i);
            matrix[i, maxCol] *= (maxCol + 1);
        }
    }

    public void ReplaceMaxElementOdd(int[,] matrix)
    {
        int rowCount = matrix.GetLength(0);
        for (int i = 1; i < rowCount; i += 2)
        {
            int maxCol = FindMaxElement(matrix, i);
            matrix[i, maxCol] = 0;
        }
    }
    public void Task_2_27(int[,] A, int[,] B)
    {
        // В двух заданных матрицах максимальные элементы четных строк заменить
        // нулями, нечетных – умножить на номер столбца, в котором они находятся.
        // Использовать методы.
        if (A == null || A.GetLength(0) == 0) { return; }
        if (B == null || B.GetLength(0) == 0) { return; }

        ReplaceMaxElementEven(A);
        ReplaceMaxElementOdd(A);
        ReplaceMaxElementEven(B);
        ReplaceMaxElementOdd(B);

        
        // create and use FindRowMaxIndex(matrix, rowIndex, out columnIndex);
        // create and use ReplaceMaxElementOdd(matrix, row, column);
        // create and use ReplaceMaxElementEven(matrix, row, column);

        // end
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
    public delegate double SumFunction(int i, double x, ref int changes);
    public delegate double YFunction(double x);
    public double sum1Func(int i, double x, ref int Fact)
    {
        if (i > 0) { Fact *= i; }
        double member = Math.Cos(i * x) / Fact;
        return member;
    }
    public double sum2Func(int i, double x, ref int p)
    {
        p *= -1;
        double member = p * Math.Cos(i * x) / (i * i);
        return member;
    }
    public double Y1(double x)
    {
        double y = Math.Exp(Math.Cos(x)) * Math.Cos(Math.Sin(x));
        return y;
    }
    public double Y2(double x)
    {
        double y = ((x * x) - Math.Pow(Math.PI, 2) / 3) / 4;
        return y;
    }
    public double CountSum(SumFunction sumFunc, double x, int i)
    {
        double sum = 0;
        int changes = 1;
       
        double currentmem = sumFunc(i, x, ref changes);

        while (Math.Abs(currentmem) > 0.0001)
        {
            sum += currentmem;
            currentmem = sumFunc(++i, x, ref changes);
        }
        return sum;
    }
    public void GetSumAndY(SumFunction sumFunc, YFunction yFunc, double a, double b, double h, double[,] matrixSumAndY, int startI = 0)
    {
        for (int i = 0; i < (b - a) / h + 1; i++)
        {
            double x = a + i * h;
            double sum = CountSum(sumFunc, x, startI);
            double y = yFunc(x);
            matrixSumAndY[i, 0] = sum;
            matrixSumAndY[i, 1] = y;
        }
    }
    public void Task_3_1(ref double[,] firstSumAndY, ref double[,] secondSumAndY)
    {

        // code here 
        double a1 = 0.1, b1 = 1, h1 = 0.1;
        double a2 = Math.PI / 5, b2 = Math.PI, h2 = Math.PI / 25;


        firstSumAndY = new double[(int)((b1 - a1) / h1) + 1, 2];
        GetSumAndY(sum1Func, Y1, a1, b1, h1, firstSumAndY);

        secondSumAndY = new double[(int)((b2 - a2) / h2) + 1, 2];
        GetSumAndY(sum2Func, Y2, a2, b2, h2, secondSumAndY, 1);
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

    public delegate double[] SwapDirection(double[] array);

    public static double SumElementsWithOddInd(double[] array)
    {
        if (array == null || array.Length == 0)
            return 0;

        double sum = 0;
        for (int i = 1; i < array.Length; i += 2)
            sum += array[i];
        return sum;
    }

    public static double CalculateAverageVal(double[] array)
    {
        if (array == null || array.Length == 0)
            return 0;

        double sum = 0;
        for (int i = 0; i < array.Length; i++)
        {
            sum += array[i];
        }
        return sum / array.Length;
    }

    public static double[] SwapLeft(double[] array)
    {
        for (int i = 0; i < array.Length - 1; i += 2)
        {
            (array[i], array[i + 1]) = (array[i + 1], array[i]);
        }
        return array;
    }

    public static double[] SwapRight(double[] array)
    {
        for (int i = array.Length - 1; i > 0; i -= 2)
        {
            (array[i], array[i - 1]) = (array[i - 1], array[i]);
        }
        return array;
    }

    public static void SwapDirect(SwapDirection swapDir, ref double[] array)
    {
        array = swapDir(array); // Перестановка через делегат
    }


    public double Task_3_3(double[] array)
    {
        if (array == null || array.Length == 0)
            return 0;

        double averageVal = CalculateAverageVal(array);

        if (array[0] > averageVal)
            SwapDirect(SwapLeft, ref array);
        else
            SwapDirect(SwapRight, ref array);

        double answer = SumElementsWithOddInd(array);
        return answer;
        // SwapDirection swapper = default(SwapDirection); - uncomment me

        // code here

        // create and use public delegate SwapDirection(array);
        // create and use methods SwapRight(array) and SwapLeft(array)
        // create and use method GetSum(array, start, h) that sum elements with a negative indexes
        // change method in variable swapper in the if/else and than use swapper(matrix)

        // end


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

    // public delegate double YFunction(double x);
    public double Func1(double x)
    {
        return x * x - Math.Sin(x);
    }

    public double Func2(double x)
    {
        return Math.Exp(x) - 1;
    }

    public int CountSignFlips(YFunction yFunc, double a, double b, double h)
    {


        int count = 0;
        double prevY = yFunc(a);

        for (double x = a + h; x <= b; x += h)
        {
            double currentY = yFunc(x);
            if (prevY * currentY < 0)
                count++;
            if (currentY != 0)
                prevY = currentY; 
        }

        return count;
    }
    public void Task_3_5(out int func1, out int func2)
    {
        func1 = 0;
        func2 = 0;
        double a1 = 0, b1 = 2, h1 = 0.1;
        double a2 = -1, b2 = 1, h2 = 0.2;
        func1 = CountSignFlips(Func1, a1, b1, h1);
        func2 = CountSignFlips(Func2, a2, b2, h2);

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
    public delegate int CountPositive(int[,] matrix);
    public int[,] InsertColumn(int[,] B, CountPositive CountRowPositive, int[,] C, CountPositive CountColumnPositive)
    {
        int countRowB = B.GetLength(0), countColB = B.GetLength(1);
        int maxIndexI = CountRowPositive(B);
        int maxIndexJ = CountColumnPositive(C);

        int[,] A = new int[countRowB + 1, countColB];
        for (int i = 0; i < countColB; i++)
        {
            A[maxIndexI + 1, i] = C[i, maxIndexJ];
        }

        for (int i = 0; i <= maxIndexI; i++)
        {
            for (int j = 0; j < A.GetLength(1); j++)
            {
                A[i, j] = B[i, j];
            }
        }

        for (int i = maxIndexI + 2; i < A.GetLength(0); i++)
        {
            for (int j = 0; j < A.GetLength(1); j++)
            {
                A[i, j] = B[i - 1, j];
            }
        }
        return A;
    }
    public void Task_3_7(ref int[,] B, int[,] C)
    {
        B = InsertColumn(B, CountRowPositive, C, CountColumnPositive);
        // create and use public delegate CountPositive(matrix, index);
        // use CountRowPositive(matrix, rowIndex) from Task_2_7
        // use CountColumnPositive(matrix, colIndex) from Task_2_7
        // create and use method InsertColumn(matrixB, CountRow, matrixC, CountColumn);
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

    public delegate void FindElementDelegate(int[,] matrix, out int rowIndex, out int colIndex);
    public void RemoveRows(ref int[,] matrix, FindElementDelegate findMax, FindElementDelegate findMin)
    {
        int maxI, maxJ, minI, minJ;

        findMax(matrix, out maxI, out maxJ);
        findMin(matrix, out minI, out minJ);

        int row1 = Math.Min(minI, maxI);
        int row2 = Math.Max(minI, maxI);

        RemoveRow(ref matrix, row2);

        if (row1 != row2)
        {
            RemoveRow(ref matrix, row1);
        }
    }
    public void Task_3_13(ref int[,] matrix)
    {
        RemoveRows(ref matrix, FindMaxElement, FindMinElement);
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
    public delegate void ReplaceMaxElement(int[,] matrix);
    public void EvenOddRowsTransform(int[,] matrix, ReplaceMaxElement ReplaceMaxElementOdd, ReplaceMaxElement ReplaceMaxElementEven)
    {
        ReplaceMaxElementEven(matrix);
        ReplaceMaxElementOdd(matrix);
    }
    public void Task_3_27(int[,] A, int[,] B)
    {
        if (A == null || A.GetLength(0) == 0) { return; }
        if (B == null || B.GetLength(0) == 0) { return; }
        EvenOddRowsTransform(A, ReplaceMaxElementOdd, ReplaceMaxElementEven);
        EvenOddRowsTransform(B, ReplaceMaxElementOdd, ReplaceMaxElementEven);
        // В двух заданных матрицах максимальные элементы четных строк заменить
        // нулями, нечетных – умножить на номер столбца, в котором они находятся.

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
