using System.Collections;
using System.Numerics;

namespace MatrixLabs;

public class Container<T> where T : INumber<T>
{
    private Matrix<T>[] matrixArray;
    private ArrayList matrixArrayList;

    public Container(Matrix<T>[] matrixArray)
    {
        this.matrixArray = matrixArray;
        matrixArrayList.AddRange(matrixArray);
    }

    public Matrix<T> SumAllForArray()
    {
        var result = matrixArray[0];
        for (int i = 1; i < matrixArrayList.Count; i++)
        {
            result = result + (matrixArray[i]);
        }

        return result;
    }

    public Matrix<T> SumAllForArrayList()
    {
        var result = matrixArrayList[0] as Matrix<T>;
        for (int i = 1; i < matrixArrayList.Count; i++)
        {
            result = result + (matrixArrayList[i] as Matrix<T>);
        }

        return result;
    }

    public Matrix<T> MultiplyAllForArray()
    {
        var result = matrixArray[0];
        for (int i = 1; i < matrixArrayList.Count; i++)
        {
            result = result * (matrixArray[i]);
        }

        return result;
    }

    public Matrix<T> MultiplyAllForArrayList()
    {
        var result = matrixArrayList[0] as Matrix<T>;
        for (int i = 1; i < matrixArrayList.Count; i++)
        {
            result = result * (matrixArrayList[i] as Matrix<T>);
        }

        return result;
    }

    private void DeleteNegative()
    {
        for (int i = 0; i < matrixArrayList.Count; i++)
        {
            var matrix = (matrixArrayList[i] as Matrix<T>);
            if (IsContainsNegative(matrix))
            {
                matrixArrayList.Remove(matrixArrayList[i]);
                i--;
            }
        }
    }

    private bool IsContainsNegative(Matrix<T> matrix)
    {
        for (int j = 0; j < matrix.Size; j++)
        {
            for (int k = 0; k < matrix.Size; k++)
            {
                if (matrix[j, k] < 0)
                {
                    return true;
                }
            }
        }

        return false;
    }
}