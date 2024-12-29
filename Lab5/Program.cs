using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Numerics;
using System.Reflection;
using System.Reflection.Metadata;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using static Program;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class Program
{
	public static void Main()
	{
		Program program = new Program();
		double[,] r1 = null, r2 = null;
		program.Task_3_1(ref r1, ref r2);
	}
	#region Level 1
	public long Task_1_1(int n, int k)
	{
		long answer = 0;

		// code here
		if (n <= 0 || k <= 0)
		{
			return 0;
		}
		answer = Combinations(n, k);
		Console.WriteLine(answer);
		// create and use Combinations(n, k);
		// create and use Factorial(n);

		// end

		return answer;
	}
	public long Combinations(int n, int k)
	{
		return Factorial(n) / (Factorial(k) * Factorial(n - k));
	}
	public long Factorial(int n)
	{
		long fct = 1;
		for (int i = 1; i <= n; ++i)
		{
			fct *= i;
		}
		return fct;
	}

	public int Task_1_2(double[] first, double[] second)
	{
		int answer = 0;

		// code here
		if (first.Length != 3 || second.Length != 3)
		{
			return -1;
		}
		for (int i = 0; i < 3; i++)
		{
			if (first[i] <= 0 || second[i] <= 0)
				return -1;
		}
		double aa = first[0], ab = first[1], ac = first[2], ba = second[0], bb = second[1], bc = second[2];
		if (aa >= ab + ac || ab >= aa + ac || ac >= aa + ab || ba >= bb + bc || bb >= ba + bc || bc >= ba + bb)
		{
			return -1;
		}
		if (GeronArea(aa, ab, ac) > GeronArea(ba, bb, bc))
		{
			answer = 1;
		} else if (GeronArea(aa, ab, ac) == GeronArea(ba, bb, bc))
		{
			answer = 0;
		} else if (GeronArea(aa, ab, ac) < GeronArea(ba, bb, bc))
		{
			answer = 2;
		} else
		{
			answer = -1;
		}
		Console.Write(answer + " ");
		// create and use GeronArea(a, b, c);

		// end

		// first = 1, second = 2, equal = 0, error = -1
		return answer;
	}
	public double GeronArea(double a, double b, double c)
	{
		double p = (a + b + c) / 2;
		return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
	}


	public int Task_1_3a(double v1, double a1, double v2, double a2, int time)
	{
		int answer = 0;

		// code here
		if (time <= 0 || v1 <= 0 || v2 <= 0 || a1 <= 0 || a2 <= 0)
		{
			return -1;
		}
		double s1 = GetDistance(v1, a1, time);
		double s2 = GetDistance(v2, a2, time);
		if (s1 > s2)
		{
			answer = 1;
		} else if (s1 < s2)
		{
			answer = 2;
		} else
		{
			answer = 0;
		}
		// create and use GetDistance(v, a, t); t - hours

		// end

		// first = 1, second = 2, equal = 0
		return answer;
	}
	public double GetDistance(double v, double a, int t)
	{
		return v * t + a * t * t / 2;
	}


	public int Task_1_3b(double v1, double a1, double v2, double a2)
	{
		int answer = 0;

		// code here
		answer = 1;
		if (v1 <= 0 || v2 <= 0 || a1 <= 0 || a2 <= 0)
		{
			return -1;
		}
		double prv = GetDistance(v1, a1, 1);
		double scd = GetDistance(v2, a2, 1);
		for (int tm = 2; scd < prv; ++tm)
		{
			prv = GetDistance(v1, a1, tm);
			scd = GetDistance(v2, a2, tm);
			answer = tm;
		}
		// use GetDistance(v, a, t); t - hours

		// end

		return answer;
	}
	#endregion

	#region Level 2
	public void Task_2_1(int[,] A, int[,] B)
	{
		// code here
		int n1 = A.GetLength(0);
		int m1 = A.GetLength(1);
		int n2 = B.GetLength(0);
		int m2 = B.GetLength(1);
		if (n1 != 5 || m1 != 6 || n2 != 3 || m2 != 5)
		{
			return;
		}
		int mi1, mj1, mi2, mj2;
		FindMaxIndex(A, out mi1, out mj1);
		FindMaxIndex(B, out mi2, out mj2);
		int t = A[mi1, mj1];
		A[mi1, mj1] = B[mi2, mj2];
		B[mi2, mj2] = t;
		// create and use FindMaxIndex(matrix, out row, out column);

		// end
	}
	public void FindMaxIndex(int[,] matrix, out int row, out int column)
	{
		row = 0;
		column = 0;
		for (int i = 0; i < matrix.GetLength(0); i++)
		{
			for (int j = 0; j < matrix.GetLength(1); j++)
			{
				if (matrix[i, j] > matrix[row, column])
				{
					row = i; column = j;
				}
			}
		}
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
		// code here
		int n1 = B.GetLength(0);
		int m1 = B.GetLength(1);
		int n2 = C.GetLength(0);
		int m2 = C.GetLength(1);
		if (n1 != 5 || m1 != 5 || n1 != m1 || n2 != 6 || m2 != 6 || n2 != m2)
		{
			return;
		}
		B = DeleteMaxElRow(B);
		C = DeleteMaxElRow(C);
		//  create and use method FindDiagonalMaxIndex(matrix);

		// end
	}
	public int FindDiagonalMaxIndex(int[,] matrix)
	{
		int mai = 0;
		for (int i = 0; i < matrix.GetLength(0); i++)
		{
			if (matrix[i, i] > matrix[mai, mai])
			{
				mai = i;
			}
		}
		return mai;
	}
	public int[,] DeleteMaxElRow(int[,] matrix)
	{
        int td1 = FindDiagonalMaxIndex(matrix);
        int[,] nm = new int[matrix.GetLength(0) - 1, matrix.GetLength(1)];
        for (int i = 0; i < td1; i++)
        {
            for (int j = 0; j < matrix.GetLength(1); ++j)
            {
                nm[i, j] = matrix[i, j];
            }
        }
        for (int i = td1 + 1; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); ++j)
            {
                nm[i - 1, j] = matrix[i, j];
            }
        }
        matrix = nm;
		return matrix;
    }
	public void Task_2_4(int[,] A, int[,] B)
	{
		// code here

		//  create and use method FindDiagonalMaxIndex(matrix); like in Task_2_3

		// end
	}

	public void Task_2_5(int[,] A, int[,] B)
	{
		// code here
		int n1 = A.GetLength(0);
		int m1 = A.GetLength(1);
		int n2 = B.GetLength(0);
		int m2 = B.GetLength(1);
		if (n1 != 4 || m1 != 6 || n2 != 6 || m2 != 6 || n2 != m2)
		{
			return;
		}
		int ri1 = 0;
		int ri2 = 0;
		FindMaxInColumn(A, 0, out ri1);
		FindMaxInColumn(B, 0, out ri2);
		for (int j = 0; j < 6; ++j)
		{
			int tmp = A[ri1, j];
			A[ri1, j] = B[ri2, j];
			B[ri2, j] = tmp;
		}
		// create and use FindMaxInColumn(matrix, columnIndex, out rowIndex);

		// end
	}
	public void FindMaxInColumn(int[,] matrix, int columnIndex, out int rowIndex)
	{
		rowIndex = 0;
		for (int i = 0; i < matrix.GetLength(0); i++)
		{
			if (matrix[i, columnIndex] > matrix[rowIndex, columnIndex])
			{
				rowIndex = i;
			}
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
		// code here

		int mvb = -1;
		int mbi = -1;
		for (int i = 0; i < 4; i++)
		{
			if (CountRowPositive(B, i) > mvb)
			{
				mvb = CountRowPositive(B, i);
				mbi = i;
			}
		}

		int mvc = -1;
		int mci = -1;
		for (int j = 0; j < 6; j++)
		{
			if (CountColumnPositive(C, j) > mvc)
			{
				mvc = CountColumnPositive(C, j);
				mci = j;
			}
		}

		int[,] resultB = new int[5, 5];

		for (int i = 0; i < 5; i++)
		{
			for (int j = 0; j < 5; j++)
			{
				if (i <= mbi)
					resultB[i, j] = B[i, j];
				else if (i == mbi + 1)
					resultB[i, j] = C[j, mci];
				else
					resultB[i, j] = B[i - 1, j];
			}
		}

		B = resultB;
		// create and use CountRowPositive(matrix, rowIndex);
		// create and use CountColumnPositive(matrix, colIndex);

		// end
	}
	public int CountRowPositive(int[,] matrix, int rowIndex)
	{
		int c = 0;
		for (int i = 0; i < matrix.GetLength(1); i++)
		{
			if (matrix[rowIndex, i] > 0)
			{
				c++;
			}
		}
		return c;
	}
	public int CountColumnPositive(int[,] matrix, int colIndex)
	{
		int c = 0;
		for (int i = 0; i < matrix.GetLength(0); i++)
		{
			if (matrix[i, colIndex] > 0)
			{
				c++;
			}
		}
		return c;
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
		int n1 = A.GetLength(0);
		int m1 = A.GetLength(1);
		int n2 = C.GetLength(0);
		int m2 = C.GetLength(1);
		int[] a1 = SumPositiveElementsInColumns(A);
		int[] c1 = SumPositiveElementsInColumns(C);
		int[] all = new int[m1 + m2];
		for (int i = 0; i < m1; ++i)
		{
			all[i] = a1[i];
		}
		for (int i = m1; i < m1 + m2; ++i)
		{
			all[i] = c1[i - m1];
		}
		answer = all;
		// create and use SumPositiveElementsInColumns(matrix);

		// end

		return answer;
	}
	public int[] SumPositiveElementsInColumns(int[,] matrix)
	{
		int[] arr = new int[matrix.GetLength(1)];
		for (int j = 0; j < matrix.GetLength(1); j++)
		{
			for (int i = 0; i < matrix.GetLength(0); i++)
			{
				if (matrix[i, j] > 0)
				{
					arr[j] += matrix[i, j];
				}
			}
		}
		return arr;
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
		int mi1, mj1, mi2, mj2;
		FindMaxIndex(A, out mi1, out mj1);
		FindMaxIndex(B, out mi2, out mj2);
		int t = A[mi1, mj1];
		A[mi1, mj1] = B[mi2, mj2];
		B[mi2, mj2] = t;
		// use FindMaxIndex(matrix, out row, out column); from Task_2_1

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
		int mai, maj, mii, mij;

		FindMaxIndex(matrix, out mai, out maj);
		FindMinIndex(matrix, out mii, out mij);

		int fr = Math.Min(mii, mai);
		int sr = Math.Max(mii, mai);

		RemoveRow(ref matrix, sr);

		if (fr != sr)
			RemoveRow(ref matrix, fr);
		// create and use RemoveRow(matrix, rowIndex);

		// end
	}
	public void FindMinIndex(int[,] matrix, out int row, out int col)
	{
		row = 0;
		col = 0;
		for (int i = 0; i < matrix.GetLength(0); i++)
		{
			for (int j = 0; j < matrix.GetLength(1); j++)
			{
				if (matrix[i, j] < matrix[row, col])
				{
					row = i;
					col = j;
				}
			}
		}

	}

	public void RemoveRow(ref int[,] matrix, int rowIndex)
	{
		int[,] nm = new int[matrix.GetLength(0) - 1, matrix.GetLength(1)];
		for (int i = 0; i < rowIndex; i++)
		{
			for (int j = 0; j < matrix.GetLength(1); j++)
			{
				nm[i, j] = matrix[i, j];
			}
		}
		for (int i = rowIndex + 1; i < matrix.GetLength(0); i++)
		{
			for (int j = 0; j < matrix.GetLength(1); j++)
			{
				nm[i - 1, j] = matrix[i, j];
			}
		}
		matrix = nm;
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

		// code here
		double[] sq = { GetAverageWithoutMinMax(A), GetAverageWithoutMinMax(B), GetAverageWithoutMinMax(C) };
		if (sq[1] > sq[0] && sq[1] < sq[2])
		{
			answer = 1;
		}
		else if (sq[1] < sq[0] && sq[1] > sq[2])
		{
			answer = -1;
		}
		else
		{
			answer = 0;
		}
		// create and use GetAverageWithoutMinMax(matrix);

		// end

		// 1 - increasing   0 - no sequence   -1 - decreasing
		return answer;
	}
	public double GetAverageWithoutMinMax(int[,] matrix)
	{
		int n = matrix.GetLength(0);
		int m = matrix.GetLength(1);
		int mai, maj, mii, mij;
		FindMaxIndex(matrix, out mai, out maj);
		FindMinIndex(matrix, out mii, out mij);
		int amnt = 0;
		double avg = 0;
		for (int i = 0; i < n; i++)
		{
			for (int j = 0; j < m; j++)
			{
				if (!(i == mai && j == maj) && !(i == mii && j == mij))
				{
					amnt++;
					avg += matrix[i, j];
				}
			}
		}
		if (amnt != 0)
		{
			avg /= amnt;
		}
		return avg;
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
		// create and use SortRowsByMaxElement(matrix);

		// end
	}
	public int FindMaxInRowInd(int[,] matrix, int row)
	{
		int mi = 0;
		for (int i = 0; i < matrix.GetLength(1); i++)
		{
			if (matrix[row, i] > matrix[row, mi])
			{
				mi = i;
			}
		}
		return mi;
	}
	public void SortRowsByMaxElement(int[,] matrix)
	{
		int n = matrix.GetLength(0);
		int m = matrix.GetLength(1);

		for (int i = 1; i < n; ++i)
		{
			for (int j = i; j > 0; --j)
			{
				if (matrix[j - 1, FindMaxInRowInd(matrix, j - 1)] < matrix[j, FindMaxInRowInd(matrix, j)])
				{
					for (int k = 0; k < m; ++k)
					{
						(matrix[j - 1, k], matrix[j, k]) = (matrix[j, k], matrix[j - 1, k]);
					}
				}
				else
				{
					break;
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
		// code here

		// use RemoveRow(matrix, rowIndex); from 2_13
		while (true)
		{
			int n = matrix.GetLength(0);
			int m = matrix.GetLength(1);
			for (int i = 0; i < n; i++)
			{
				for (int j = 0; j < m; j++)
				{
					if (matrix[i, j] == 0)
					{
						RemoveRow(ref matrix, i);
						goto itr;
					}
				}
			}

			break;

		itr:;
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
		answerA = null;
		answerB = null;

		// code here
		answerA = CreateArrayFromMins(A);
		answerB = CreateArrayFromMins(B);
		// create and use CreateArrayFromMins(matrix);

		// end
	}
	public int[] CreateArrayFromMins(int[,] matrix)
	{
		int n = matrix.GetLength(0);
		int m = matrix.GetLength(1);
		int[] answer = new int[n];
		for (int i = 0; i < n; i++)
		{
			int mi = int.MaxValue;
			for (int j = i; j < m; ++j)
			{
				if (matrix[i, j] < mi)
				{
					mi = matrix[i, j];
				}
			}
			answer[i] = mi;
		}
		return answer;
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
		// code here
		MatrixValuesChange(A);
		MatrixValuesChange(B);
		// create and use MatrixValuesChange(matrix);

		// end
	}
	public void MatrixValuesChange(double[,] matrix)
	{
		int n = matrix.GetLength(0);
		int m = matrix.GetLength(1);

		double[] transf = new double[n * m];
		for (int i = 0, k = 0; i < n; i++)
		{
			for (int j = 0; j < m; j++, k++)
			{
				transf[k] = matrix[i, j];
			}
		}

		for (int i = 1; i < transf.Length; i++)
		{
			for (int j = i; j > 0; j--)
			{
				if (transf[j - 1] < transf[j])
					(transf[j - 1], transf[j]) = (transf[j], transf[j - 1]);
				else
					break;
			}
		}

		for (int i = 0; i < n; i++)
		{
			for (int j = 0; j < m; j++)
			{
				double current = matrix[i, j];

				bool inc = false;

				for (int k = 0; k < 5; k++)
				{
					if (current == transf[k])
					{
						matrix[i, j] = (current > 0) ? (current * 2) : (current / 2);
						inc = true;
						break;
					}
				}

				if (!inc)
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
		maxA = 0;
		maxB = 0;

		// code here
		maxA = FindRowWithMaxNegativeCount(A);
		maxB = FindRowWithMaxNegativeCount(B);
		// create and use FindRowWithMaxNegativeCount(matrix);
		// in FindRowWithMaxNegativeCount create and use CountNegativeInRow(matrix, rowIndex); like in 2_22

		// end
	}
	public int CountNegativeInRow(int[,] matrix, int rowIndex)
	{
		int n = matrix.GetLength(1);
		int cnt = 0;
		for (int i = 0; i < n; i++)
		{
			if (matrix[rowIndex, i] < 0)
			{
				cnt++;
			}
		}
		return cnt;
	}
	public int FindRowWithMaxNegativeCount(int[,] matrix)
	{
		int n = matrix.GetLength(0);
		int mr = 0;
		int mv = -1;
		for (int i = 0; i < n; ++i)
		{
			int cnt = CountNegativeInRow(matrix, i);
			if (cnt > mv)
			{
				mv = cnt;
				mr = i;
			}
		}
		return mr;
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
		// code here
		TransformMatrix_2_27(A);
		TransformMatrix_2_27(B);
		// create and use FindRowMaxIndex(matrix, rowIndex, out columnIndex);
		// create and use ReplaceMaxElementOdd(matrix, row, column);
		// create and use ReplaceMaxElementEven(matrix, row, column);

		// end
	}
	public void FindRowMaxIndex(int[,] matrix, int rowIndex, out int columnIndex)
	{
		int m = matrix.GetLength(1);
		columnIndex = 0;
		for (int j = 0; j < m; ++j)
		{
			if (matrix[rowIndex, j] > matrix[rowIndex, columnIndex])
			{
				columnIndex = j;
			}
		}
	}
	public void ReplaceMaxElementOdd(int[,] matrix, int row, int column)
	{
		matrix[row, column] *= (column + 1);
	}
	public void ReplaceMaxElementEven(int[,] matrix, int row, int column)
	{
		matrix[row, column] = 0;
	}
	public void TransformMatrix_2_27(int[,] matrix)
	{
        int ci = 0;
        int n = matrix.GetLength(0);
        int m = matrix.GetLength(1);
        for (int i = 0; i < n; ++i)
        {
            FindRowMaxIndex(matrix, i, out ci);
            if ((i + 1) % 2 == 0)
            {
                ReplaceMaxElementEven(matrix, i, ci);
            }
            else
            {
                ReplaceMaxElementOdd(matrix, i, ci);
            }
            ci = 0;
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
	public double S1part(double x)
	{
		double sum = 1;
		int i = 1;
		double val;
		while (true)
		{
			val = Math.Cos(i * x) / (double)Factorial(i);
			if (Math.Abs(val) <= 0.0001)
			{
				break;
			}
			sum += val;
			i++;
		}
		return sum;
	}
	public double S2part(double x)
	{
		double sum = 0;
		int i = 1;
		double val;
		while (true)
		{
			val = Math.Pow(-1, i) * Math.Cos(i * x) / (i * i);
			if (Math.Abs(val) <= 0.0001)
			{
				break;
			}
			sum += val;
			i++;
		}
		return sum;
	}
	public double yfunc_a(double x)
	{
		return Math.Exp(Math.Cos(x)) * Math.Cos(Math.Sin(x));
	}
	public double yfunc_b(double x)
	{
		return (x * x - (Math.PI * Math.PI) / 3) / 4;
	}
	public double[,] GetSumAndY(SumFunction s_func, YFunction y_func, double a, double b, double h)
	{
		double[,] A = new double[(int)((b - a) / h) + 1, 2];
		int ind = 0;
		for (double x = a; x <= b + h / 10; x += h)
		{
			double sum = s_func(x);
			double y = y_func(x);
			A[ind, 0] = sum;
			A[ind, 1] = y;
			ind++;
		}
		return A;
	}
	public void Task_3_1(ref double[,] firstSumAndY, ref double[,] secondSumAndY)
	{
		// code here
		double a1 = 0.1, b1 = 1, h1 = 0.1;
		double a2 = Math.PI / 5, b2 = Math.PI, h2 = Math.PI / 25;
		firstSumAndY = GetSumAndY(S1part, yfunc_a, a1, b1, h1);
		secondSumAndY = GetSumAndY(S2part, yfunc_b, a2, b2, h2);
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
		SwapDirection swapper = default(SwapDirection);

		// code here
		double avg = CalcAvg(array);
		if (array[0] > avg)
		{
			swapper = SwapRight;
		} else
		{
			swapper = SwapLeft;
		}
		swapper(array);
		answer = GetSum(array);
		// create and use public delegate SwapDirection(array);
		// create and use methods SwapRight(array) and SwapLeft(array)
		// create and use method GetSum(array, start, h) that sum elements with a negative indexes
		// change method in variable swapper in the if/else and than use swapper(matrix)

		// end

		return answer;
	}
	public delegate void SwapDirection(double[] array);
	public void SwapRight(double[] array)
	{
		for (int i = 0; i < array.Length - 1; i += 2)
		{
			(array[i], array[i + 1]) = (array[i + 1], array[i]);
		}
	}

	public void SwapLeft(double[] array)
	{
		for (int i = array.Length - 1; i > 0; i -= 2)
		{
			(array[i], array[i - 1]) = (array[i - 1], array[i]);

		}
	}
	public double CalcAvg(double[] array)
	{
		double sum = 0;
		foreach (int x in array)
		{
			sum += x;
		}
		return sum / array.Length;
	}
	public double GetSum(double[] array)
	{
		double sum = 0;
		for (int i = 1; i < array.Length; i += 2)
		{
			sum += array[i];
		}
		return sum;
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
		func1 = CountSignFlips(yfunc_5_1, 0, 2, 0.1);
		func2 = CountSignFlips(yfunc_5_2, -1, 1, 0.2);
		// use public delegate YFunction(x, a, b, h) from Task_3_1
		// create and use method CountSignFlips(YFunction, a, b, h);
		// create and use 2 methods for both functions

		// end
	}

	public double yfunc_5_1(double x)
	{
		return x * x - Math.Sin(x);
	}
	public double yfunc_5_2(double x)
	{
		return Math.Exp(x) - 1;
	}
	public int CountSignFlips(YFunction y, double a, double b, double h)
	{
        int cnt = 0;
        double last_y = y(a);
        for (double x = a + h; x <= b; x += h)
        {
            if (y(x) == 0) continue;
            double now = y(x);
			if (last_y * now < 0)
			{
				++cnt;
			}
            last_y = now;
        }
        return cnt;
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
		B = InsertColumn(B, CountRowPositive, C, CountColumnPositive);
		// create and use public delegate CountPositive(matrix, index);
		// use CountRowPositive(matrix, rowIndex) from Task_2_7
		// use CountColumnPositive(matrix, colIndex) from Task_2_7
		// create and use method InsertColumn(matrixB, CountRow, matrixC, CountColumn);

		// end
	}

	public delegate int CountPositive(int[,] matrix, int index);

	public int[,] InsertColumn(int[,] matrixB, CountPositive CountRow, int[,] matrixC, CountPositive CountColumn)
	{
		int cnt = 0, cnt2 = 0;
		int mi = 0, mj = 0;
		int mv = -1, mvc = -1;
		for (int i = 0; i < matrixB.GetLength(0); i++)
		{
			cnt = CountRow(matrixB, i);
			cnt2 = CountColumn(matrixC, i);
			if (cnt > mv)
			{
				mv = cnt;
				mi = i;
			}
			if (cnt2 > mvc)
			{
				mvc = cnt2;
				mj = i;
			}
		}
		int[,] mod = new int[matrixB.GetLength(0) + 1, matrixB.GetLength(1)];
		for (int i = 0; i < matrixB.GetLength(1); ++i)
		{
			mod[mi + 1, i] = matrixC[i, mj];
		}
		for (int i = 0; i <= mi; ++i)
		{
			for (int j = 0; j < mod.GetLength(1); ++j)
			{
				mod[i, j] = matrixB[i, j];
			}
		}
		for (int i = mi + 2; i < mod.GetLength(0); ++i)
		{
			for (int j = 0; j < mod.GetLength(1); ++j)
			{
				mod[i, j] = matrixB[i - 1, j];
			}
		}
		return mod;
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
		matrix = RemoveRows(matrix, FindMax, FindMin);
		// end
	}

	public delegate int FindElementDelegate(int[,] matrix);

	public int FindMax(int[,] matrix)
	{
		int max = matrix[0, 0];
		for (int i = 0; i < matrix.GetLength(0); ++i)
		{
			for (int j = 0; j < matrix.GetLength(1); ++j)
			{
				if (matrix[i, j] > max)
				{
					max = matrix[i, j];
				}
			}
		}
		return max;
	}

	public int FindMin(int[,] matrix)
	{
		int min = matrix[0, 0];
		for (int i = 0; i < matrix.GetLength(0); i++)
		{
			for (int j = 0; j < matrix.GetLength(1); j++)
			{
				if (matrix[i, j] < min)
				{
					min = matrix[i, j];
				}
			}
		}
		return min;
	}

	public int[,] RemoveRows(int[,] matrix, FindElementDelegate fmax, FindElementDelegate fmin)
	{
		int mx = fmax(matrix);
		int mi = fmin(matrix);
		int cnt = 0;
		for (int i = 0; i < matrix.GetLength(0); i++)
		{
			for (int j = 0; j < matrix.GetLength(1); j++)
			{
				if (matrix[i, j] == mx || matrix[i, j] == mi)
				{
					cnt++;
					break;
				}
			}
		}
		int[] todel = new int[cnt];
		cnt = 0;
		for (int i = 0; i < matrix.GetLength(0); i++)
		{
			for (int j = 0; j < matrix.GetLength(1); j++)
			{
				if (matrix[i, j] == mx || matrix[i, j] == mi)
				{
					todel[cnt] = i;
					cnt++;
					break;
				}
			}
		}
		int[,] modif = new int[matrix.GetLength(0) - cnt, matrix.GetLength(1)];
		cnt = 0;
		for (int i = 0; i < matrix.GetLength(0); ++i)
		{
			if (cnt < todel.Length && i == todel[cnt])
			{
				cnt++;
				continue;
			}
			else
			{
				for (int j = 0; j < modif.GetLength(1); j++)
				{
					modif[i - cnt, j] = matrix[i, j];
				}
			}
		}
		return modif;

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
		EvenOddRowsTransform(A, ReplaceMaxElementOdd, ReplaceMaxElementEven);
		EvenOddRowsTransform(B, ReplaceMaxElementOdd, ReplaceMaxElementEven);
		// create and use public delegate ReplaceMaxElement(matrix, rowIndex, max);
		// use ReplaceMaxElementOdd(matrix) from Task_2_27
		// use ReplaceMaxElementEven(matrix) from Task_2_27
		// create and use method EvenOddRowsTransform(matrix, replaceMaxElementOdd, replaceMaxElementEven);

		// end
	}

	public delegate void ReplaceMaxElement(int[,] matrix, int row, int column);
	public void EvenOddRowsTransform(int [,] matrix, ReplaceMaxElement rmo, ReplaceMaxElement rme)
	{
		for(int i =0; i < matrix.GetLength(0); i++)
		{
			int ind = FindMaxInRowInd(matrix, i);
			if ((i + 1) % 2 == 0)
			{
				rme(matrix, i, ind);
			}
			else
			{
				rmo(matrix, i, ind);
			}
		}

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

	public void ToUpperTriangular(double [,] matrix)
	{
		int n = matrix.GetLength(0);
		int m = matrix.GetLength(1);
		for (int j = m - 1; j >= 0; --j)
		{
			for(int i = j-1 ; i >= 0; --i)
			{
				double mult = (matrix[i, j] / matrix[j, i]);
				matrix[i, j] = 0;

				for(int k = j-1; k >= 0; --k)
				{
					matrix[i, k] -= matrix[j, k] * mult;
				}
			}
		}
	}

	public void ToLowerTriangular(double [,] matrix)
	{
		int n = matrix.GetLength(0);
		int m = matrix.GetLength(1);
		for(int j = m - 1;j >= 0; --j)
		{
			for(int i = j-1 ;i >= 0; --i)
			{
				double mult = (matrix[i, j] / matrix[j, i]);
				matrix[i, j] = 0;
				for(int k = j-1; k >= 0; --k)
				{
					matrix[i,k]-= (matrix[j, k]*mult);
				}
			}
		}
	}

	public void ToLeftDiagonal(double [,] matrix)
	{
		ToUpperTriangular(matrix);
		ToLowerTriangular(matrix);
	}
    public void ToRightDiagonal(double[,] matrix)
    {
        ToLowerTriangular(matrix);
		ToUpperTriangular(matrix);
    }

	public double[,] Task_4(double[,] matrix, int index)
	{
		MatrixConverter[] mc ={ ToUpperTriangular, ToLowerTriangular, ToLeftDiagonal, ToRightDiagonal };

		// code here
		mc[index](matrix);
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
