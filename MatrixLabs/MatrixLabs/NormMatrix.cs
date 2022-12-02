using System.Numerics;

namespace MatrixLabs;

public class NormMatrix<T> : Matrix<T>,
    IAdditionOperators<NormMatrix<T>, Matrix<T>, NormMatrix<T>>,
    ISubtractionOperators<NormMatrix<T>, Matrix<T>, NormMatrix<T>>,
    IMultiplyOperators<NormMatrix<T>, Matrix<T>, NormMatrix<T>>,
    IMultiplyOperators<NormMatrix<T>, int, NormMatrix<T>>
    where T : INumber<T>
{
    public NormMatrix(int size) : base(size)
    {
        Norm();
    }

    protected NormMatrix(Matrix<T> matrix) : base(matrix)
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

    private static NormMatrix<T> ToNorm(Matrix<T> matrix) => new NormMatrix<T>(matrix);

    private void Norm()
    {
        var det = Determinator();
        for (var i = 0; i < Size; i++)
        {
            values[i, 0] = (int) (values[i, 0] / det);
        }
    }

    public static NormMatrix<T> operator +(NormMatrix<T> left, Matrix<T> right)
    {
        var result = (left as Matrix<T>) + right;
        return ToNorm(result);
    }

    public static NormMatrix<T> operator -(NormMatrix<T> left, Matrix<T> right)
    {
        var result = (left as Matrix<T>) - right;
        return ToNorm(result);
    }

    public static NormMatrix<T> operator *(NormMatrix<T> left, Matrix<T> right)
    {
        var result = (left as Matrix<T>) * right;
        return ToNorm(result);
    }

    public static NormMatrix<T> operator *(NormMatrix<T> left, int right)
    {
        var result = (left as Matrix<T>) * right;
        return ToNorm(result);
    }
}