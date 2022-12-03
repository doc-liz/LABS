using System.Numerics;

namespace MatrixLabs.Containers;

public class MatrixList<T> : MatrixContainer<T> where T : INumber<T>
{
    private List<Matrix<T>> matrices;

    public MatrixList(Matrix<T>[] matrixArray)
    {
        matrices = new List<Matrix<T>>();
        matrices.AddRange(matrixArray);
    }

    public override Matrix<T> SumAll()
    {
        var result = matrices[0];
        for (var i = 1; i < matrices.Count; i++)
        {
            result +=  matrices[i];
        }

        return result;
    }

    public override Matrix<T> MultiplyAll()
    {
        var result = matrices[0];
        for (var i = 1; i < matrices.Count; i++)
        {
            result *= matrices[i];
        }

        return result;
    }

    protected override void DeleteNegative()
    {
        for (int i = 0; i < matrices.Count; i++)
        {
            var matrix = matrices[i];
            if (IsContainsNegative(matrix))
            {
                matrices.Remove(matrices[i]);
                i--;
            }
        }
    }

    public override void SwitchLastFirst()
    {
        (matrices[0], matrices[^1]) = (matrices[^1], matrices[0]);
    }

    public override void Print()
    {
        foreach (var matrix in matrices)
        {
            Console.WriteLine(matrix);
            Console.WriteLine();
        }
    }
}