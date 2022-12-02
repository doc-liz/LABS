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

    protected NormMatrix(Matrix matrix) : base(matrix)
    {
        Norm();
    }

    public override double this[int i, int j]
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
        var det = Determinator();
        for (var i = 0; i < Size; i++)
        {
            values[i, 0] = (int)(values[i, 0] / det);
        }
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