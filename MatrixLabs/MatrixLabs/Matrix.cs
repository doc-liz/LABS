using System.Numerics;
using System.Text;

namespace MatrixLabs;

public class Matrix<T>:
    IAdditionOperators<Matrix<T>, Matrix<T>, Matrix<T>>,
    ISubtractionOperators<Matrix<T>, Matrix<T>, Matrix<T>>,
    IMultiplyOperators<Matrix<T>, Matrix<T>, Matrix<T>>,
    IMultiplyOperators<Matrix<T>, int, Matrix<T>>
where T : INumber<T>
{
    // Реализовать операции сложения, вычитания и умножения матриц.

    protected double[,] values;
    public int Size;

    public Matrix(int size)
    {
        Size = size;
        values = new double[Size, Size];
        for (var i = 0; i < Size; i++)
        {
            for (var j = 0; j < Size; j++)
            {
                values[i, j] = 0;
            }
        }
    }

    protected Matrix(Matrix<T> matrix)
    {
        Size = matrix.Size;
        values = new double[Size, Size];
        for (var i = 0; i < Size; i++)
        {
            for (var j = 0; j < Size; j++)
            {
                values[i, j] = matrix[i, j];
            }
        }
    }

    public virtual double this[int i, int j]
    {
        get => values[i, j];
        set => values[i, j] = value;
    }

    public static Matrix<T> operator +(Matrix<T> left, Matrix<T> right)
    {
        var result = new Matrix<T>(left.Size);
        for (var i = 0; i < left.Size; i++)
        {
            for (var j = 0; j < left.Size; j++)
            {
                result[i, j] = left[i, j] + right[i, j];
            }
        }

        return result;
    }

    public static Matrix<T> operator -(Matrix<T> left, Matrix<T> right)
    {
        var result = new Matrix<T>(left.Size);
        for (var i = 0; i < left.Size; i++)
        {
            for (var j = 0; j < left.Size; j++)
            {
                result[i, j] = left[i, j] - right[i, j];
            }
        }

        return result;
    }

    public static Matrix<T> operator *(Matrix<T> left, Matrix<T> right)
    {
        var result = new Matrix<T>(left.Size);
        for (var i = 0; i < left.Size; i++)
        {
            for (var j = 0; j < left.Size; j++)
            {
                for (var k = 0; k < left.Size; k++)
                {
                    result[i, j] = left[k, j] * right[i, k];
                }
            }
        }

        return result;
    }

    public static Matrix<T> operator *(Matrix<T> left, int right)
    {
        var result = new Matrix<T>(left.Size);
        for (var i = 0; i < left.Size; i++)
        {
            for (var j = 0; j < left.Size; j++)
            {
                result[i, j] = left[i, j] * right;
            }
        }

        return result;
    }

    public override string ToString()
    {
        var str = new StringBuilder();
        for (var i = 0; i < Size; i++)
        {
            for (var j = 0; j < Size; j++)
            {
                str.Append($"{values[i, j]}\t");
            }

            str.Append(Environment.NewLine);
        }

        return str.ToString();
    }

    public double Determinator()
    {
        var det = 1.0;
        var gaussMatr = MethodGaussa();
        for (var i = 0; i < Size; i++)
            det *= gaussMatr[i, i];
        return det;
    }

    private Matrix<T> MethodGaussa()
    {
        var gaussMatr = new Matrix<T>(this);
        for (var k = 0; k < Size - 1; k++)
        {
            for (var j = k + 1; j < Size; j++)
            {
                if (!(gaussMatr[k, k] == 0))
                {
                    double koe = gaussMatr[j, k] / gaussMatr[k, k];

                    for (var i = k; i < Size; i++)
                    {
                        gaussMatr[j, i] -= (int)koe * gaussMatr[k, i];
                    }
                }
            }
        }

        return gaussMatr;
    }

    public static Matrix<T> CreateRandom(int size)
    {
        var result = new Matrix<T>(size);
        var rnd = new Random();
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                result[i, j] = rnd.Next(10, 99);
            }
        }

        return result;
    }
}