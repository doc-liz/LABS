using System.Numerics;
using MatrixLabs.Containers;

namespace MatrixLabs;

public class FileParser
{
    public static MatrixArray<T> CreateMatrixArray<T>(string path) where T : INumber<T>
    {
        var matrices = Parse<T>(path);
        return new MatrixArray<T>(matrices);
    }

    public static MatrixList<T> CreateMatrixList<T>(string path) where T : INumber<T>
    {
        var matrices = Parse<T>(path);
        return new MatrixList<T>(matrices);
    }

    public static MatrixArrayList<T> CreateMatrixArrayList<T>(string path) where T : INumber<T>
    {
        var matrices = Parse<T>(path);
        return new MatrixArrayList<T>(matrices);
    }

    private static Matrix<T>[] Parse<T>(string path) where T : INumber<T>
    {
        using (var reader = new StreamReader(path))
        {
            var text = reader.ReadToEnd().Split(Environment.NewLine + Environment.NewLine);
            var elements = new Matrix<T>[text.Length];
            var k = 0;
            foreach (var line in text)
            {
                var lines = line.Split(Environment.NewLine);
                var matrix = new Matrix<T>(lines.Length - 1);
                for (var i = 0; i < lines.Length - 1; i++)
                {
                    var matrStr = lines[i + 1].Split(' ');
                    for (var j = 0; j < lines.Length - 1; j++)
                    {
                        matrix[i, j] = T.Parse(matrStr[j], null);
                    }
                }

                elements[k] = matrix;
                k++;
            }

            return elements;
        }
    }
}