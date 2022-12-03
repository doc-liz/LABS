using System.Collections;
using System.Numerics;

namespace MatrixLabs.Containers;

public class MatrixArrayList<T> : MatrixContainer<T> where T : INumber<T>
{
    private readonly ArrayList matrices;

    public MatrixArrayList(Matrix<T>[] matrixArray)
    {
        matrices = new ArrayList();
        matrices.AddRange(matrixArray);
    }

    public override Matrix<T> SumAll()
    {
        var result = matrices[0] as Matrix<T>;
        for (var i = 1; i < matrices.Count; i++)
        {
            result += matrices[i] as Matrix<T>;
        }

        return result;
    }

    public override Matrix<T> MultiplyAll()
    {
        var result = matrices[0] as Matrix<T>;
        for (var i = 1; i < matrices.Count; i++)
        {
            result *= matrices[i] as Matrix<T>;
        }

        return result;
    }

    protected override void DeleteNegative()
    {
        for (var i = 0; i < matrices.Count; i++)
        {
            var matrix = matrices[i] as Matrix<T>;
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
            Console.WriteLine(matrix + Environment.NewLine);
        }
    }
}