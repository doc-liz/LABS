using System.Numerics;

namespace MatrixLabs;

public class NormMatrix : Matrix,
    IAdditionOperators<NormMatrix, Matrix, NormMatrix>,
    ISubtractionOperators<NormMatrix, Matrix, NormMatrix>,
    IMultiplyOperators<NormMatrix, Matrix, NormMatrix>,
    IMultiplyOperators<NormMatrix, int, NormMatrix>
{
    public NormMatrix(int size) : base(size)
    {
        Norm();
    }

    private NormMatrix(Matrix matrix) : base(matrix.Size)
    {
        for (var i = 0; i < matrix.Size; i++)
        {
            for (var j = 0; j < matrix.Size; j++)
            {
                values[i, j] = matrix[i, j];
            }
        }
        Norm();
    }

    public int this[int i, int j]
    {
        get => values[i, j];
        set
        {
            values[i, j] = value;
            Norm();
        }
    }
    private static NormMatrix ToNorm(Matrix matrix) => new NormMatrix(matrix);
    private void Norm()
    {
        throw new NotImplementedException();
    }

    public static NormMatrix operator +(NormMatrix left, Matrix right)
    {
        var result = (left as Matrix) + right;
        return ToNorm(result);
    }

    public static NormMatrix operator -(NormMatrix left, Matrix right)
    {
        var result = (left as Matrix) - right;
        return ToNorm(result);
    }

    public static NormMatrix operator *(NormMatrix left, Matrix right)
    {
        var result = (left as Matrix) * right;
        return ToNorm(result);
    }

    public static NormMatrix operator *(NormMatrix left, int right)
    {
        var result = (left as Matrix) * right;
        return ToNorm(result);
    }
}