using System.Drawing.Drawing2D;
using MatrixLabs;

namespace UIMatrixCalculator.Components;

public class MatrixTextBoxes
{
    private TextBox[,] Cells { get; }

    public Control[] GetCells()
    {
        var list = new List<TextBox>();
        foreach (var cell in Cells)
        {
            list.Add(cell);
        }

        return list.ToArray();
    }
    public Point Position { get; }
    public int Size { get; }
    public int Width => Size * (CellWidth + offset);
    public int Height => Size * (CellHeight + offset);
    private static int CellWidth = 50;
    private static int CellHeight = 25;
    private readonly int offset = 2;

    public MatrixTextBoxes(int size, Point position)
    {
        Cells = new TextBox[size, size];
        Size = size;
        Position = position;
        for (var i = 0; i < size; i++)
        {
            for (var j = 0; j < size; j++)
            {
                var cell = new TextBox();
                cell.Size = new Size(CellWidth, CellHeight);
                cell.Location = new Point(
                    position.X + cell.Size.Width * i + offset,
                    position.Y + cell.Size.Height * j + offset
                );
                Cells[i, j] = cell;
            }
        }
    }

    public Matrix<Rational> CreateMatrix()
    {
        var matrix = new Matrix<Rational>(Size);
        for (var i = 0; i < Size; i++)
        {
            for (var j = 0; j < Size; j++)
            {
                matrix[i, j] = Rational.Parse(Cells[i, j].Text.Trim(), null);
            }
        }

        return matrix;
    }
}