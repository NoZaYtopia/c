using System;
using System.Threading.Tasks;

public class MyMatrix
{
    public int m; // количество строк
    public int n; // количество столбцов
    public double[][] data; // значения
    
    public MyMatrix(int rows, int cols)
    {
        // Создаем матрицу, полностью инициализированную
        // значениями 0.0. Проверка входных параметров опущена.
        m = rows;
        n = cols;

        double[][] result = new double[rows][];
        for (int i = 0; i < rows; ++i)
            result[i] = new double[cols]; // автоинициализация в 0.0
        data = result;
    }

    public MyMatrix(int rows, int cols, double[][] data_in)
    {
        m = rows;
        n = cols;
        data = data_in;
    }

    public string MatrixAsString()
    {
        string s = "";
        for (int i = 0; i < n; ++i)
        {
            for (int j = 0; j < m; ++j)
                s += data[i][j].ToString("F3").PadLeft(8) + " ";
            s += Environment.NewLine;
        }
        return s;
    }

    public MyMatrix MatrixProduct(MyMatrix A, MyMatrix B)
    {
        int aRows = A.data.Length; int aCols = A.data[0].Length;
        int bRows = B.data.Length; int bCols = B.data[0].Length;

        if (aCols != bRows)
            throw new Exception("Non-conformable matrices in MatrixProduct");

        MyMatrix C = new MyMatrix(aRows, bCols);

        Parallel.For(0, aRows, i =>
        {
            for (int j = 0; j < bCols; ++j)
                for (int k = 0; k < aCols; ++k)
                    C.data[i][j] += A.data[i][k] * B.data[k][j];
        }
        );
        return C;
    }

    public MyMatrix GetInverse()
    {
        double[][] in_matr = this.data;
        double[][] out_matr = MatrixInverse(in_matr);
        MyMatrix B = new MyMatrix(this.m, this.n, out_matr);
        return B;
    }

    public double MatrixDeterminant()
    {
        double[][] matrix = this.data;
        int[] perm;
        int toggle;
        double[][] lum = MatrixDecompose(matrix, out perm, out toggle);
        if (lum == null)
            return 0;
        double result = toggle;
        for (int i = 0; i < lum.Length; ++i)
            result *= lum[i][i];
        return result;
    }

    public double[] LinSolve(double[] b)
    {
        return SystemSolve(this.data, b);

    }

    public int GetRank()
    {
        return Rank(this.data, this.m, this.n);
    }
    
    //tech->

    public double[][] MatrixDuplicate(double[][] matrix)
    {
        // Предполагается, что матрица не нулевая
        double[][] result = MatrixCreate(matrix.Length, matrix[0].Length);
        for (int i = 0; i < matrix.Length; ++i) // Копирование значений
            for (int j = 0; j < matrix[i].Length; ++j)
                result[i][j] = matrix[i][j];
        return result;
    }   //tech

    public static double[][] MatrixCreate(int rows, int cols)
    {
        // Создаем матрицу, полностью инициализированную
        // значениями 0.0. Проверка входных параметров опущена.
        double[][] result = new double[rows][];
        for (int i = 0; i < rows; ++i)
            result[i] = new double[cols]; // автоинициализация в 0.0
        return result;
    }     //tech

    public double[][] MatrixDecompose(double[][] matrix,out int[] perm, out int toggle)
    {
        // Разложение LUP Дулитла. Предполагается,
        // что матрица квадратная.
        int n = matrix.Length; // для удобства
        double[][] result = MatrixDuplicate(matrix);
        perm = new int[n];
        for (int i = 0; i < n; ++i) { perm[i] = i; }
        toggle = 1;
        for (int j = 0; j < n - 1; ++j) // каждый столбец
        {
            double colMax = Math.Abs(result[j][j]); // Наибольшее значение в столбце j
            int pRow = j;
            for (int i = j + 1; i < n; ++i)
            {
                if (result[i][j] > colMax)
                {
                    colMax = result[i][j];
                    pRow = i;
                }
            }
            if (pRow != j) // перестановка строк
            {
                double[] rowPtr = result[pRow];
                result[pRow] = result[j];
                result[j] = rowPtr;
                int tmp = perm[pRow]; // Меняем информацию о перестановке
                perm[pRow] = perm[j];
                perm[j] = tmp;
                toggle = -toggle; // переключатель перестановки строк
            }
            if (Math.Abs(result[j][j]) < 1.0E-20)
                return null;
            for (int i = j + 1; i < n; ++i)
            {
                result[i][j] /= result[j][j];
                for (int k = j + 1; k < n; ++k)
                    result[i][k] -= result[i][j] * result[j][k];
            }
        } // основной цикл по столбцу j
        return result;
    }   //tech

    public double[] HelperSolve(double[][] luMatrix, double[] b)
    {
        // Решаем luMatrix * x = b
        int n = luMatrix.Length;
        double[] x = new double[n];
        b.CopyTo(x, 0);
        for (int i = 1; i < n; ++i)
        {
            double sum = x[i];
            for (int j = 0; j < i; ++j)
                sum -= luMatrix[i][j] * x[j];
            x[i] = sum;
        }
        x[n - 1] /= luMatrix[n - 1][n - 1];
        for (int i = n - 2; i >= 0; --i)
        {
            double sum = x[i];
            for (int j = i + 1; j < n; ++j)
                sum -= luMatrix[i][j] * x[j];
            x[i] = sum / luMatrix[i][i];
        }
        return x;
    }   //tech

    public double[][] MatrixInverse(double[][] matrix)
    {
        int n = matrix.Length;
        double[][] result = MatrixDuplicate(matrix);
        int[] perm;
        int toggle;
        double[][] lum = MatrixDecompose(matrix, out perm, out toggle);
        if (lum == null)
            throw new Exception("Unable to compute inverse");
        double[] b = new double[n];
        for (int i = 0; i < n; ++i)
        {
            for (int j = 0; j < n; ++j)
            {
                if (i == perm[j])
                    b[j] = 1.0;
                else
                    b[j] = 0.0;
            }
            double[] x = HelperSolve(lum, b);
            for (int j = 0; j < n; ++j)
                result[j][i] = x[j];
        }
        return result;
    }   //tech

    public double[] SystemSolve(double[][] A, double[] b)   //tech
    {
        // Решаем Ax = b
        int n = A.Length;
        int[] perm;
        int toggle;
        double[][] luMatrix = MatrixDecompose(
          A, out perm, out toggle);
        if (luMatrix == null)
            return null; // или исключение
        double[] bp = new double[b.Length];
        for (int i = 0; i < n; ++i)
            bp[i] = b[perm[i]];
        double[] x = HelperSolve(luMatrix, bp);
        return x;
    }
    
    public int Rank(double[][] A,int m, int n)
    {
        int rank = Math.Min(m, n);

        // Приведение матрицы к ступенчатому виду
        for (int i = 0; i < rank; i++)
        {
            if (A[i][i] != 0)
            {
                for (int j = 0; j < m; j++)
                {
                    if (j != i)
                    {
                        double ratio = A[j][i] / A[i][i];

                        for (int k = 0; k < n; k++)
                        {
                            A[j][k] -= ratio * A[i][k];
                        }
                    }
                }
            }
            else
            {
                bool reduced = false;

                for (int j = i + 1; j < m; j++)
                {
                    if (A[j][i] != 0)
                    {
                        for (int k = 0; k < n; k++)
                        {
                            double temp = A[i][k];
                            A[i][k] = A[j][k];
                            A[j][k] = temp;
                        }

                        reduced = true;
                        break;
                    }
                }

                if (!reduced)
                {
                    rank--;
                    for (int j = 0; j < m; j++)
                    {
                        A[j][i] = A[j][rank];
                    }
                }

                i--;
            }
        }

        return rank;
    }   //tech
}