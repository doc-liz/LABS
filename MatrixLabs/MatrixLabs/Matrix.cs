using System.Numerics;
using System.Text;

namespace MatrixLabs;

public class Matrix :
    IAdditionOperators<Matrix, Matrix, Matrix>,
    ISubtractionOperators<Matrix, Matrix, Matrix>,
    IMultiplyOperators<Matrix, Matrix, Matrix>,
    IMultiplyOperators<Matrix, int, Matrix>
{
    // Реализовать операции сложения, вычитания и умножения матриц.

    protected int[,] values;
    public int Size;

    public Matrix(int size)
    {
        Size = size;
        values = new int[Size,Size];
    }

    public int this[int i, int j]
    {
        get => values[i, j];
        set => values[i, j] = value;
    }

    public static Matrix operator +(Matrix left, Matrix right)
    {
        var result = new Matrix(left.Size);
        for (var i = 0; i < left.Size; i++)
        {
            for (var j = 0; j < left.Size; j++)
            {
                result[i, j] = left[i, j] + right[i, j];
            }
        }

        return result;
    }

    public static Matrix operator -(Matrix left, Matrix right)
    {
        var result = new Matrix(left.Size);
        for (var i = 0; i < left.Size; i++)
        {
            for (var j = 0; j < left.Size; j++)
            {
                result[i, j] = left[i, j] - right[i, j];
            }
        }

        return result;
    }

    public static Matrix operator *(Matrix left, Matrix right)
    {
        var result = new Matrix(left.Size);
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

    public static Matrix operator *(Matrix left, int right)
    {
        var result = new Matrix(left.Size);
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
}