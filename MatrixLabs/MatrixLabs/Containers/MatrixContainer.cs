using System.Numerics;

namespace MatrixLabs.Containers;

public abstract class MatrixContainer<T> where T : INumber<T>
{
    public abstract Matrix<T> SumAll();
    public abstract Matrix<T> MultiplyAll();
    protected abstract void DeleteNegative();

    public abstract void SwitchLastFirst();

    protected bool IsContainsNegative(Matrix<T> matrix)
    {
        for (var j = 0; j < matrix.Size; j++)
        {
            for (var k = 0; k < matrix.Size; k++)
            {
                if (matrix[j, k] < T.Zero)
                {
                    return true;
                }
            }
        }

        return false;
    }
}