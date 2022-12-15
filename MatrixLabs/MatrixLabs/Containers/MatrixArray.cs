using System.Numerics;

namespace MatrixLabs.Containers;

public class MatrixArray<T> : MatrixContainer<T> where T : INumber<T>
{
    private Matrix<T>[] matrices;

    public MatrixArray(Matrix<T>[] matrices)
    {
        this.matrices = matrices;
        DeleteNegative();
    }

    public override Matrix<T> SumAll()
    {
        var result = matrices[0];
        for (var i = 1; i < matrices.Length; i++)
        {
            result += matrices[i];
        }

        return result;
    }

    public override Matrix<T> MultiplyAll()
    {
        var result = matrices[0];
        for (var i = 1; i < matrices.Length; i++)
        {
            result *= matrices[i];
        }

        return result;
    }

    protected override void DeleteNegative()
    {
        var list = new List<Matrix<T>>();
        foreach (var matrix in matrices)
        {
            if (IsContainsNegative(matrix))
            {
                continue;
            }

            list.Add(matrix);
        }

        matrices = list.ToArray();
    }

    public override void SwitchLastFirst()
    {
        (matrices[0], matrices[^1]) = (matrices[^1], matrices[0]);
    }

    public override void Print()
    {
        foreach (var matrix in matrices)
        {
            Console.WriteLine(matrix + Environment.NewLine);
        }
    }
}